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
        private HistoryList _History;
        private ConcurrentDictionary<string, List<FunctionInstance>> EventHandlers = new ConcurrentDictionary<string, List<FunctionInstance>>();

        public HistoryInstance(ScriptEngine engine, HistoryList hl) : base(engine)
        {
            _History = hl;
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
            return Engine.Array.Construct(_History.EntryOrder.Where(e => (start == null || e.EventTimeUTC >= start) && (stop == null || e.EventTimeUTC <= stop)).Select(e => new HistoryEntryInstance(Engine, e)).ToArray());
        }

        [JSFunction(Name = "getByEventType")]
        public ArrayInstance GetByEventType(string type, DateTime? start = null, DateTime? stop = null)
        {
            JournalTypeEnum entrytype = (JournalTypeEnum)Enum.Parse(typeof(JournalTypeEnum), type);
            return Engine.Array.Construct(_History.EntryOrder.Where(e => e.EntryType == entrytype && (start == null || e.EventTimeUTC >= start) && (stop == null || e.EventTimeUTC <= stop)).Select(e => new HistoryEntryInstance(Engine, e)).ToArray());
        }

        [JSFunction(Name = "getLastEvent")]
        public HistoryEntryInstance GetLastEvent(DateTime? end, FunctionInstance filter)
        {
            Func<HistoryEntry, bool> xfilter = je => true;

            if (filter != null)
                xfilter = je => TypeConverter.ToBoolean(filter.Call(this, new HistoryEntryInstance(Engine, je)));

            HistoryEntry ret = _History.GetLastHistoryEntry(e => (end == null || e.EventTimeUTC <= end) && xfilter(e));
            return ret == null ? null : new HistoryEntryInstance(Engine, ret);
        }
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
                HistoryEntryInstance ji = he == null ? null : new HistoryEntryInstance(this.Engine, he);
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

                OnNewHistoryEntry(he, "@Any");
            }

        }

        public void OnNewHistoryEntry(HistoryEntry he)
        {
            OnNewHistoryEntry(he, null);
        }

        public void OnRefresh(HistoryList hl)
        {
            _History = hl;
            OnNewHistoryEntry(null, "@Refresh");
        }
    }
}
