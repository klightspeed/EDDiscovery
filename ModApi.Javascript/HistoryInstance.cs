using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jurassic;
using Jurassic.Library;
using EliteDangerousCore;
using System.Collections.Concurrent;
using EliteDangerousCore.JournalEvents;

namespace EDDiscovery.ModApi.Javascript
{
    public class HistoryInstance : ObjectInstance
    {
        private HistoryList History;
        private Dictionary<string, List<FunctionInstance>> EventListeners = new Dictionary<string, List<FunctionInstance>>();
        private ScriptEnvironment Environment;

        public HistoryInstance(ScriptEnvironment env, HistoryList hl) : base(env.Engine.Object.InstancePrototype)
        {
            PopulateFunctions();
            Environment = env;
            History = hl;
        }

        #region Javascript-visible methods
        [JSFunction(Name = "addEventListener")]
        public void AddEventListener(string entry, bool filtercmdr, FunctionInstance func)
        {
            List<FunctionInstance> handlers = EventListeners.GetOrAdd(entry, (e) => new List<FunctionInstance>());
            lock (handlers)
            {
                handlers.Add(func);
            }
        }

        [JSFunction(Name = "removeEventListener")]
        public void RemoveEventListener(string entry, bool filtercmdr, FunctionInstance func = null)
        {
            List<FunctionInstance> handlers;
            if (EventListeners.TryGetValue(entry, out handlers))
            {
                lock (handlers)
                {
                    if (func != null)
                    {
                        int index = handlers.IndexOf(func);
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
            return Engine.Array.Construct(History.EntryOrder.Where(e => (start == null || e.EventTimeUTC >= start) && (stop == null || e.EventTimeUTC <= stop)).Select(e => new HistoryEntryInstance(Environment, e)).ToArray());
        }

        [JSFunction(Name = "getByEventType")]
        public ArrayInstance GetByEventType(string type, DateTime? start = null, DateTime? stop = null)
        {
            JournalTypeEnum entrytype = (JournalTypeEnum)Enum.Parse(typeof(JournalTypeEnum), type);
            return Engine.Array.Construct(History.EntryOrder.Where(e => e.EntryType == entrytype && (start == null || e.EventTimeUTC >= start) && (stop == null || e.EventTimeUTC <= stop)).Select(e => new HistoryEntryInstance(Environment, e)).ToArray());
        }

        [JSFunction(Name = "getLastEvent")]
        public HistoryEntryInstance GetLastEvent(DateTime? end, FunctionInstance filter)
        {
            Func<HistoryEntry, bool> xfilter = je => true;

            if (filter != null)
                xfilter = je => TypeConverter.ToBoolean(filter.Call(this, new HistoryEntryInstance(Environment, je)));

            HistoryEntry ret = History.GetLastHistoryEntry(e => (end == null || e.EventTimeUTC <= end) && xfilter(e));
            return ret == null ? null : new HistoryEntryInstance(Environment, ret);
        }
        #endregion

        #region Javascript-visible properties
        [JSProperty(Name = "currentCommander")]
        public CommanderInstance CurrentCommander { get; private set; }
        #endregion

        private void InvokeListener(string eventtype)
        {
            if (EventListeners.ContainsKey(eventtype))
            {
                foreach (FunctionInstance handler in EventListeners[eventtype])
                {
                    handler.Call(this);
                }
            }
        }

        private void InvokeListener(HistoryEntry he, ref HistoryEntryInstance ji, string eventtype)
        {
            if (EventListeners.ContainsKey(eventtype))
            {
                foreach (FunctionInstance handler in EventListeners[eventtype])
                {
                    if (ji == null && he != null)
                    {
                        ji = new HistoryEntryInstance(Environment, he);
                    }

                    handler.Call(this, ji);
                }
            }
        }

        public void OnNewHistoryEntry(HistoryEntry he)
        {
            HistoryEntryInstance ji = null;

            InvokeListener(he, ref ji, he.EntryType.ToString());

            JournalEntry je = he.journalEntry;

            if (je != null)
            {
                if (je is JournalLocOrJump)
                {
                    InvokeListener(he, ref ji, "@Location");
                }

                if (je is IMaterialCommodityJournalEntry)
                {
                    InvokeListener(he, ref ji, "@MaterialCommodity");
                }

                if (je is ILedgerJournalEntry)
                {
                    InvokeListener(he, ref ji, "@Ledger");
                }

                if (je is ILedgerNoCashJournalEntry)
                {
                    InvokeListener(he, ref ji, "@LedgerNoCash");
                }

                if (je is IMissions)
                {
                    InvokeListener(he, ref ji, "@Missions");
                }

                if (je is IShipInformation)
                {
                    InvokeListener(he, ref ji, "@ShipInformation");
                }

                if (je is IBodyNameAndID)
                {
                    InvokeListener(he, ref ji, "@WithSystem");
                }

                if (je is ISystemStationMarket)
                {
                    InvokeListener(he, ref ji, "@WithStationSystem");
                }

                if (je is IStationEntry)
                {
                    InvokeListener(he, ref ji, "@WithStationType");
                }
            }

            InvokeListener(he, ref ji, "@Any");
        }

        public void OnRefresh(HistoryList hl)
        {
            History = hl;
            CurrentCommander = new CommanderInstance(Environment, EDCommander.GetCommander(hl.CommanderId));
            InvokeListener("@Refresh");
        }
    }
}
