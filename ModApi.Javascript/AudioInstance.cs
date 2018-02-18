using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jurassic;
using Jurassic.Library;
using ActionLanguage;
using Conditions;
using AudioExtensions;

namespace EDDiscovery.ModApi.Javascript
{
    public class AudioInstance : ObjectInstance
    {
        private ActionCoreController ActionController;
        private ScriptEnvironment Environment;

        public AudioInstance(ScriptEnvironment env, ActionCoreController actionController) : base(env.Engine.Object.InstancePrototype)
        {
            PopulateFunctions();

            ActionController = actionController;
            Environment = env;

            SpeechDefaults = Engine.Object.Construct();
            SpeechDefaults["culture"] = "Default";
            SpeechDefaults["voice"] = "Default";
            SpeechDefaults["rate"] = 0;
            SpeechDefaults["prefix"] = null;
            SpeechDefaults["postfix"] = null;
            SpeechDefaults["mix"] = null;
            SpeechDefaults["volume"] = 60;
            SpeechDefaults["maxdelay"] = 0;
            SpeechDefaults["priority"] = "Normal";
            SpeechDefaults["effects"] = null;

            AudioDefaults = Engine.Object.Construct();
            AudioDefaults["volume"] = 60;
            AudioDefaults["maxdelay"] = 0;
            AudioDefaults["priority"] = "Normal";
            AudioDefaults["effects"] = null;
        }


        [JSProperty(Name = "speechDefaults")]
        public ObjectInstance SpeechDefaults { get; private set; }

        [JSProperty(Name = "audioDefaults")]
        public ObjectInstance AudioDefaults { get; private set; }

        private class AudioSettings
        {
            public int volume;
            public int maxdelay;
            public AudioQueue.Priority priority;
            public SoundEffectSettings effects;
            public FunctionInstance onstart;
            public FunctionInstance onfinish;
            public FunctionInstance onerror;

            protected ObjectInstance settings;
            protected AudioInstance audio;

            public AudioSettings(AudioInstance audio, ObjectInstance settings, ObjectInstance defaults)
            {
                this.audio = audio;
                this.settings = settings;

                volume = TypeConverter.ToInteger(settings?.GetPropertyValue("volume") ?? 60);
                maxdelay = TypeConverter.ToInteger(settings?.GetPropertyValue("maxdelay") ?? 0);
                priority = AudioQueue.GetPriority(settings?.GetPropertyValue("priority") as string ?? "Normal");
                effects = GetSoundEffects(settings, defaults);
                onstart = settings?.GetPropertyValue("onstart") as FunctionInstance;
                onfinish = settings?.GetPropertyValue("onfinish") as FunctionInstance;
                onerror = settings?.GetPropertyValue("onerror") as FunctionInstance;
            }

            protected SoundEffectSettings GetSoundEffects(ObjectInstance settings, ObjectInstance defaults)
            {
                var localsettings = settings?.GetPropertyValue("effects") as ObjectInstance;
                ConditionVariables local = new ConditionVariables();

                if (localsettings != null)
                {
                    foreach (var kvp in settings.Properties)
                    {
                        local[kvp.Name] = kvp.Value?.ToString();
                    }
                }

                ConditionVariables global = new ConditionVariables();

                var globalsettings = defaults["effects"] as ObjectInstance;
                if (globalsettings != null)
                {
                    foreach (var kvp in globalsettings.Properties)
                    {
                        global[kvp.Name] = kvp.Value?.ToString();
                    }
                }

                return SoundEffectSettings.Set(global, local);
            }

            public void RaiseError(string message)
            {
                if (onerror != null)
                {
                    audio.Environment.CallbackProcessor(e => onerror.Call(settings, message));
                }
            }
        }

        private class SaySettings : AudioSettings
        {
            public string text;
            public string culture;
            public string voice;
            public int rate;
            public string prefixsound;
            public string postfixsound;
            public string mixsound;

            public SaySettings(string text, AudioInstance audio, ObjectInstance settings, ObjectInstance defaults)
                : base(audio, settings, defaults)
            {
                this.text = text;
                culture = TypeConverter.ToString(settings?.GetPropertyValue("culture") ?? defaults["culture"] ?? "Default");
                voice = TypeConverter.ToString(settings?.GetPropertyValue("voice") ?? defaults["voice"] ?? "Default");
                rate = TypeConverter.ToInteger(settings?.GetPropertyValue("rate") ?? defaults["rate"] ?? 0);
                prefixsound = settings?.GetPropertyValue("prefix") as string;
                postfixsound = settings?.GetPropertyValue("postfix") as string;
                mixsound = settings?.GetPropertyValue("mix") as string;
            }
        }

        private class PlaySettings : AudioSettings
        {
            public string sound;

            public PlaySettings(string sound, AudioInstance audio, ObjectInstance settings, ObjectInstance defaults)
                : base(audio, settings, defaults)
            {
                this.sound = sound;
            }
        }

        [JSFunction(Name = "say")]
        public void Say(string text, ObjectInstance settings = null)
        {
            ActionController.Form.BeginInvoke(new Action<SaySettings>(DoSay), new SaySettings(text, this, settings, SpeechDefaults));
        }

        private void DoSay(SaySettings settings)
        {
            if (settings.maxdelay > 0)
            {
                int queue = ActionController.AudioQueueSpeech.InQueuems();

                if (queue >= settings.maxdelay)
                {
                    settings.RaiseError("Abort say due to queue being at " + queue);
                    return;
                }
            }

            var ms = ActionController.SpeechSynthesizer.Speak(settings.text, settings.culture, settings.voice, settings.rate);

            if (ms == null)
            {
                settings.RaiseError("Unable to render speech");
                return;
            }

            AudioQueue.AudioSample audio = ActionController.AudioQueueSpeech.Generate(ms, settings.effects, true);

            if (audio == null)
            {
                settings.RaiseError("Say could not create audio, check Effects settings");
                return;
            }

            if (settings.mixsound != null)
            {
                AudioQueue.AudioSample mix = ActionController.AudioQueueSpeech.Generate(settings.mixsound);

                if (mix == null)
                {
                    settings.RaiseError("Say could not create mix audio, check audio file format is supported and effects settings");
                    return;
                }

                audio = ActionController.AudioQueueSpeech.Mix(audio, mix);     // audio in MIX format
            }

            if (settings.prefixsound != null)
            {
                AudioQueue.AudioSample p = ActionController.AudioQueueSpeech.Generate(settings.prefixsound);

                if (p == null)
                {
                    settings.RaiseError("Say could not create prefix audio, check audio file format is supported and effects settings");
                    return;
                }

                audio = ActionController.AudioQueueSpeech.Append(p, audio);        // audio in AUDIO format.
            }

            if (settings.postfixsound != null)
            {
                AudioQueue.AudioSample p = ActionController.AudioQueueSpeech.Generate(settings.postfixsound);

                if (p == null)
                {
                    settings.RaiseError("Say could not create postfix audio, check audio file format is supported and effects settings");
                    return;
                }

                audio = ActionController.AudioQueueSpeech.Append(audio, p);         // Audio in P format
            }

            if (settings.onstart != null)
            {
                audio.sampleStartEvent += (s, o) => Environment.CallbackProcessor(e => settings.onstart.Call(this, settings));
            }

            if (settings.onfinish != null)
            {
                audio.sampleOverEvent += (s, o) => Environment.CallbackProcessor(e => settings.onfinish.Call(this, settings));
            }

            ActionController.AudioQueueSpeech.Submit(audio, settings.volume, settings.priority);
        }

        [JSFunction(Name = "playAudio")]
        public void PlayAudio(string name, ObjectInstance settings = null)
        {
            ActionController.Form.BeginInvoke(new Action<PlaySettings>(DoPlay), new PlaySettings(name, this, settings, AudioDefaults));
        }

        private void DoPlay(PlaySettings settings)
        {
            AudioQueue.AudioSample audio = ActionController.AudioQueueWave.Generate(settings.sound, settings.effects);

            if (audio == null)
            {
                settings.RaiseError("Unable to create audio, check audio file format is supported and effects settings");
                return;
            }

            if (settings.onstart != null)
            {
                audio.sampleStartEvent += (s, o) => Environment.CallbackProcessor(e => settings.onstart.Call(this, settings));
            }

            if (settings.onfinish != null)
            {
                audio.sampleOverEvent += (s, o) => Environment.CallbackProcessor(e => settings.onfinish.Call(this, settings));
            }

            ActionController.AudioQueueWave.Submit(audio, settings.volume, settings.priority);
        }
    }
}
