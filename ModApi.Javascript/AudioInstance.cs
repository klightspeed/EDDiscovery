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
        private ActionCoreController Controller;

        public AudioInstance(ScriptEngine engine, ActionCoreController controller) : base(engine)
        {
            Controller = controller;

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

        private SoundEffectSettings GetSoundEffects(ObjectInstance settings)
        {
            ConditionVariables local = new ConditionVariables();

            if (settings != null)
            {
                foreach (var kvp in settings.Properties)
                {
                    local[kvp.Name] = kvp.Value?.ToString();
                }
            }

            ConditionVariables global = new ConditionVariables();

            var globalsettings = SpeechDefaults["effects"] as ObjectInstance;
            if (globalsettings != null)
            {
                foreach (var kvp in globalsettings.Properties)
                {
                    global[kvp.Name] = kvp.Value?.ToString();
                }
            }

            return SoundEffectSettings.Set(global, local);
        }

        [JSProperty(Name = "speechDefaults")]
        public ObjectInstance SpeechDefaults { get; private set; }

        [JSProperty(Name = "audioDefaults")]
        public ObjectInstance AudioDefaults { get; private set; }

        [JSFunction(Name = "say")]
        public void Say(string text, ObjectInstance settings = null)
        {
            string culture = TypeConverter.ToString(settings?.GetPropertyValue("culture") ?? SpeechDefaults["culture"] ?? "Default");
            string voice = TypeConverter.ToString(settings?.GetPropertyValue("voice") ?? SpeechDefaults["voice"] ?? "Default");
            int rate = TypeConverter.ToInteger(settings?.GetPropertyValue("rate") ?? SpeechDefaults["rate"] ?? 0);
            string prefixsound = settings?.GetPropertyValue("prefix") as string;
            string postfixsound = settings?.GetPropertyValue("postfix") as string;
            string mixsound = settings?.GetPropertyValue("mix") as string;
            int volume = TypeConverter.ToInteger(settings?.GetPropertyValue("volume") ?? 60);
            int maxdelay = TypeConverter.ToInteger(settings?.GetPropertyValue("maxdelay") ?? 0);
            AudioQueue.Priority priority = AudioQueue.GetPriority(settings?.GetPropertyValue("priority") as string ?? "Normal");
            SoundEffectSettings effects = GetSoundEffects(settings?.GetPropertyValue("effects") as ObjectInstance);
            FunctionInstance onstart = settings?.GetPropertyValue("onstart") as FunctionInstance;
            FunctionInstance onfinish = settings?.GetPropertyValue("onfinish") as FunctionInstance;

            if (maxdelay > 0)
            {
                int queue = Controller.AudioQueueSpeech.InQueuems();

                if (queue >= maxdelay)
                {
                    throw new JavaScriptException(Engine, "SayError", "Abort say due to queue being at " + queue);
                }
            }

            var ms = Controller.SpeechSynthesizer.Speak(text, culture, voice, rate);

            if (ms == null)
            {
                throw new JavaScriptException(Engine, "SayError", "Unable to render speech");
            }

            AudioQueue.AudioSample audio = Controller.AudioQueueSpeech.Generate(ms, effects, true);

            if (audio == null)
            {
                throw new JavaScriptException(Engine, "SayError", "Say could not create audio, check Effects settings");
            }

            if (mixsound != null)
            {
                AudioQueue.AudioSample mix = Controller.AudioQueueSpeech.Generate(mixsound);

                if (audio == null)
                {
                    throw new JavaScriptException(Engine, "SayError", "Say could not create mix audio, check audio file format is supported and effects settings");
                }

                audio = Controller.AudioQueueSpeech.Mix(audio, mix);     // audio in MIX format
            }

            if (prefixsound != null)
            {
                AudioQueue.AudioSample p = Controller.AudioQueueSpeech.Generate(prefixsound);

                if (p == null)
                {
                    throw new JavaScriptException(Engine, "SayError", "Say could not create prefix audio, check audio file format is supported and effects settings");
                }

                audio = Controller.AudioQueueSpeech.Append(p, audio);        // audio in AUDIO format.
            }

            if (postfixsound != null)
            {
                AudioQueue.AudioSample p = Controller.AudioQueueSpeech.Generate(postfixsound);

                if (p == null)
                {
                    throw new JavaScriptException(Engine, "SayError", "Say could not create postfix audio, check audio file format is supported and effects settings");
                }

                audio = Controller.AudioQueueSpeech.Append(audio, p);         // Audio in P format
            }

            if (onstart != null)
            {
                audio.sampleStartEvent += (s, o) => onstart.Call(this, settings);
            }

            if (onfinish != null)
            {
                audio.sampleOverEvent += (s, o) => onfinish.Call(this, settings);
            }

            Controller.AudioQueueSpeech.Submit(audio, volume, priority);
        }

        [JSFunction(Name = "playAudio")]
        public void PlayAudio(string name, ObjectInstance settings = null)
        {
            int volume = TypeConverter.ToInteger(settings?.GetPropertyValue("volume") ?? 60);
            int maxdelay = TypeConverter.ToInteger(settings?.GetPropertyValue("maxdelay") ?? 0);
            AudioQueue.Priority priority = AudioQueue.GetPriority(settings?.GetPropertyValue("priority") as string ?? "Normal");
            SoundEffectSettings effects = GetSoundEffects(settings?.GetPropertyValue("effects") as ObjectInstance);
            FunctionInstance onstart = settings?.GetPropertyValue("onstart") as FunctionInstance;
            FunctionInstance onfinish = settings?.GetPropertyValue("onfinish") as FunctionInstance;

            AudioQueue.AudioSample audio = Controller.AudioQueueWave.Generate(name, effects);

            if (audio == null)
            {
                throw new JavaScriptException(Engine, "AudioError", "Unable to create audio, check audio file format is supported and effects settings");
            }

            if (onstart != null)
            {
                audio.sampleStartEvent += (s, o) => onstart.Call(this, settings);
            }

            if (onfinish != null)
            {
                audio.sampleOverEvent += (s, o) => onfinish.Call(this, settings);
            }

            Controller.AudioQueueWave.Submit(audio, volume, priority);
        }
    }
}
