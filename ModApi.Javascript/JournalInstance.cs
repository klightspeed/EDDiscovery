using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jurassic;
using Jurassic.Library;
using EliteDangerousCore;
using EliteDangerousCore.JournalEvents;

namespace EDDiscovery.ModApi.Javascript
{
    public class JournalInstance : ObjectInstance
    {
        private struct JournalEntryHandler
        {
            public bool FilterCommander;
            public FunctionInstance Handler;
        }

        private ScriptEnvironment Environment;
        private ConcurrentDictionary<string, List<JournalEntryHandler>> EventListeners = new ConcurrentDictionary<string, List<JournalEntryHandler>>();

        public JournalInstance(ScriptEnvironment env) : base(env.JournalPrototype ?? env.Engine.Object.InstancePrototype)
        {
            this.PopulateFunctions();
        }

        public JournalInstance(ScriptEnvironment env, JournalInstance prototype) : base(prototype)
        {
            this.Environment = env;
            this.CurrentCommander = new CommanderInstance(env, EDCommander.Current);
        }

        #region Javascript-visible methods
        [JSFunction(Name = "addEventListener")]
        public void AddEventListener(string entry, bool filtercmdr, FunctionInstance func)
        {
            if (Environment != null)
            {
                List<JournalEntryHandler> handlers = EventListeners.GetOrAdd(entry, (e) => new List<JournalEntryHandler>());
                handlers.Add(new JournalEntryHandler { FilterCommander = filtercmdr, Handler = func });
            }
        }

        [JSFunction(Name = "removeEventListener")]
        public void RemoveEventListener(string entry, bool filtercmdr, FunctionInstance func = null)
        {
            if (Environment != null)
            {
                List<JournalEntryHandler> handlers;
                if (EventListeners.TryGetValue(entry, out handlers))
                {
                    if (func != null)
                    {
                        int index = handlers.FindIndex(h => h.FilterCommander == filtercmdr && h.Handler == func);
                        if (index >= 0)
                        {
                            handlers.RemoveAt(index);
                        }
                    }
                    else
                    {
                        handlers.Clear();
                    }
                }
            }
        }

        [JSFunction(Name = "addEventListener")]
        public void AddEventListener(string entry, FunctionInstance func)
        {
            AddEventListener(entry, true, func);
        }

        [JSFunction(Name = "removeEventListener")]
        public void RemoveEventListener(string entry, FunctionInstance func = null)
        {
            RemoveEventListener(entry, true, func);
        }

        [JSFunction(Name = "getAllEntries")]
        public ArrayInstance GetAll(DateTime? start = null, DateTime? stop = null)
        {
            if (Environment == null)
                return null;

            return Engine.Array.Construct(JournalEntry.GetAll(CurrentCommander.Index, start, stop).Select(e => JournalEntryInstance.Create(Environment, e)).ToArray());
        }

        [JSFunction(Name = "getByEventType")]
        public ArrayInstance GetByEventType(string type, DateTime? start = null, DateTime? stop = null)
        {
            if (Environment == null)
                return null;

            JournalTypeEnum entrytype = (JournalTypeEnum)Enum.Parse(typeof(JournalTypeEnum), type);
            return Engine.Array.Construct(JournalEntry.GetByEventType(entrytype, CurrentCommander.Index, start ?? new DateTime(2014, 1, 1), stop ?? DateTime.UtcNow).Select(e => JournalEntryInstance.Create(Environment, e)).ToArray());
        }

        [JSFunction(Name = "getLastEvent")]
        public JournalEntryInstance GetLastEvent(DateTime? end, FunctionInstance filter)
        {
            if (Environment == null)
                return null;

            Func<JournalEntry, bool> xfilter = je => true;

            if (filter != null)
                xfilter = je => TypeConverter.ToBoolean(filter.Call(this, JournalEntryInstance.Create(Environment, je)));

            JournalEntry ret = JournalEntry.GetLast(CurrentCommander.Index, end ?? DateTime.UtcNow, xfilter);
            return ret == null ? null : JournalEntryInstance.Create(Environment, ret);
        }

        [JSFunction(Name = "changeCommander")]
        public void ChangeCommander(string name)
        {
            if (Environment == null)
                return;

            var cmdr = EDCommander.GetCommander(name);
            if (cmdr != null)
            {
                CurrentCommander = new CommanderInstance(Environment, cmdr);
            }
        }

        [JSFunction(Name = "changeCommander")]
        public void ChangeCommander(int nr)
        {
            if (Environment == null)
                return;

            var cmdr = EDCommander.GetCommander(nr);
            if (cmdr != null)
            {
                CurrentCommander = new CommanderInstance(Environment, cmdr);
            }
        }

        [JSFunction(Name = "createNewListener")]
        public JournalInstance CreateNewListener()
        {
            if (Environment == null)
                return null;

            return new JournalInstance(Environment);
        }
        #endregion

        #region Javascript-visible properties
        [JSProperty(Name = "currentCommander")]
        public CommanderInstance CurrentCommander { get; private set; }
        #endregion

        #region Event subscription

        protected void InvokeListener(object obj, string eventtype)
        {
            if (EventListeners.ContainsKey(eventtype))
            {
                foreach (JournalEntryHandler handler in EventListeners[eventtype])
                {
                    handler.Handler.Call(this, obj);
                }
            }
        }

        protected void InvokeListener(JournalEntry je, ref JournalEntryInstance ji, string eventtype)
        {
            if (EventListeners.ContainsKey(eventtype))
            {
                foreach (JournalEntryHandler handler in EventListeners[eventtype])
                {
                    if (!handler.FilterCommander || je.CommanderId == this.CurrentCommander.Index)
                    {
                        if (ji == null && je != null)
                        {
                            ji = JournalEntryInstance.Create(Environment, je);
                        }

                        handler.Handler.Call(this, ji);
                    }
                }
            }
        }

        public void OnNewJournalEntry(JournalEntry je)
        {
            JournalEntryInstance ji = null;

            InvokeListener(je, ref ji, null);

            if (je is JournalLocOrJump)
            {
                InvokeListener(je, ref ji, "@Location");
            }

            if (je is IMaterialCommodityJournalEntry)
            {
                InvokeListener(je, ref ji, "@MaterialCommodity");
            }

            if (je is ILedgerJournalEntry)
            {
                InvokeListener(je, ref ji, "@Ledger");
            }

            if (je is ILedgerNoCashJournalEntry)
            {
                InvokeListener(je, ref ji, "@LedgerNoCash");
            }

            if (je is IMissions)
            {
                InvokeListener(je, ref ji, "@Missions");
            }

            if (je is IShipInformation)
            {
                InvokeListener(je, ref ji, "@ShipInformation");
            }

            if (je is IBodyNameAndID)
            {
                InvokeListener(je, ref ji, "@WithSystem");
            }

            if (je is ISystemStationMarket)
            {
                InvokeListener(je, ref ji, "@WithStationSystem");
            }

            if (je is IStationEntry)
            {
                InvokeListener(je, ref ji, "@WithStationType");
            }

            InvokeListener(je, ref ji, "@Any");
        }

        public void OnRefresh(HistoryList hl)
        {
            InvokeListener(CommanderInstance.GetCommander(Environment, hl.CommanderId), "@Refresh");
        }
        #endregion
    }
}
