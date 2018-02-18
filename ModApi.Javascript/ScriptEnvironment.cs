using ActionLanguage;
using EliteDangerousCore;
using Jurassic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDiscovery.ModApi.Javascript
{
    public class ScriptEnvironment
    {
        public ScriptEnvironment(HistoryList history, ActionCoreController actionController, string configPrefix, Action<Action<ScriptEnvironment>> callbackProcessor)
        {
            Engine = new ScriptEngine();
            CallbackProcessor = callbackProcessor;
            Journal = new JournalInstance(this);
            Audio = new AudioInstance(this, actionController);
            Config = new ConfigInstance(this, configPrefix);
            History = new HistoryInstance(this, history);
            CommanderPrototype = new CommanderInstance(Engine);
            HistoryEntryPrototype = new HistoryEntryInstance(Engine);
            JournalEntryPrototype = new JournalEntryInstance(Engine);
            SystemPrototype = new SystemInstance(Engine);

            Engine.SetGlobalValue("Journal", Journal);
            Engine.SetGlobalValue("Audio", Audio);
            Engine.SetGlobalValue("History", History);
            Engine.SetGlobalValue("Config", Config);
        }

        public JournalInstance Journal { get; private set; }
        public AudioInstance Audio { get; private set; }
        public HistoryInstance History { get; private set; }
        public ConfigInstance Config { get; private set; }
        public ScriptEngine Engine { get; private set; }
        public Action<Action<ScriptEnvironment>> CallbackProcessor { get; private set; }

        public CommanderInstance CommanderPrototype { get; private set; }
        public HistoryEntryInstance HistoryEntryPrototype { get; private set; }
        public JournalEntryInstance JournalEntryPrototype { get; private set; }
        public SystemInstance SystemPrototype { get; private set; }
    }
}
