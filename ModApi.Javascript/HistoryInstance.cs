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
        private ConcurrentDictionary<string, List<FunctionInstance>> EventHandlers = new ConcurrentDictionary<string, List<FunctionInstance>>();
        private ScriptEnvironment Environment;

        public HistoryInstance(ScriptEnvironment env, HistoryList hl) : base(env.Engine.Object.InstancePrototype)
        {
            PopulateFunctions();
            Environment = env;
            History = hl;
        }

        #region Javascript-visible methods
        [JSFunction(Name = "addEventHandler")]
        public void AddEventHandler(string entry, bool filtercmdr, FunctionInstance func)
        {
            List<FunctionInstance> handlers = EventHandlers.GetOrAdd(entry, (e) => new List<FunctionInstance>());
            lock (handlers)
            {
                handlers.Add(func);
            }
        }

        [JSFunction(Name = "removeEventHandler")]
        public void RemoveEventHandler(string entry, bool filtercmdr, FunctionInstance func = null)
        {
            List<FunctionInstance> handlers;
            if (EventHandlers.TryGetValue(entry, out handlers))
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

        [JSFunction(Name = "addEventHandler")]
        public void AddEventHandler(string entry, FunctionInstance func)
        {
            AddEventHandler(entry, true, func);
        }

        [JSFunction(Name = "removeEventHandler")]
        public void RemoveEventHandler(string entry, FunctionInstance func = null)
        {
            RemoveEventHandler(entry, true, func);
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

        private void OnNewHistoryEntry(HistoryEntry he, string eventtype)
        {
            string evtype = eventtype;

            if (evtype == null)
            {
                evtype = he.EntryType.ToString();
            }

            List<FunctionInstance> handlers;
            if (EventHandlers.TryGetValue(eventtype, out handlers))
            {
                HistoryEntryInstance ji = he == null ? null : new HistoryEntryInstance(Environment, he);
                FunctionInstance[] handlerlist;

                lock (handlers)
                {
                    handlerlist = new FunctionInstance[handlers.Count];
                    handlers.CopyTo(handlerlist);
                }

                foreach (FunctionInstance handler in handlerlist)
                {
                    handler.Call(this, ji);
                }
            }

            if (eventtype == null)
            {
                JournalEntry je = he.journalEntry;

                if (je is JournalLocOrJump)
                {
                    OnNewHistoryEntry(he, "@Location");
                }
                
                if (je is IMaterialCommodityJournalEntry)
                {
                    OnNewHistoryEntry(he, "@MaterialCommodity");
                }

                if (je is ILedgerJournalEntry)
                {
                    OnNewHistoryEntry(he, "@Ledger");
                }

                if (je is ILedgerNoCashJournalEntry)
                {
                    OnNewHistoryEntry(he, "@LedgerNoCash");
                }

                if (je is IMissions)
                {
                    OnNewHistoryEntry(he, "@Missions");
                }

                if (je is IShipInformation)
                {
                    OnNewHistoryEntry(he, "@ShipInformation");
                }

                if (je is IBodyNameAndID)
                {
                    OnNewHistoryEntry(he, "@WithSystem");
                }

                OnNewHistoryEntry(he, "@Any");
            }

        }

        public void OnNewHistoryEntry(HistoryEntry he)
        {
            OnNewHistoryEntry(he, null);
        }

        public void OnRefresh(HistoryList hl)
        {
            History = hl;
            CurrentCommander = new CommanderInstance(Environment, EDCommander.GetCommander(hl.CommanderId));
            OnNewHistoryEntry(null, "@Refresh");
        }
    }
}
