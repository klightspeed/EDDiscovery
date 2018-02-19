﻿using System;
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
        private ConcurrentDictionary<string, List<JournalEntryHandler>> EventHandlers = new ConcurrentDictionary<string, List<JournalEntryHandler>>();

        public JournalInstance(ScriptEnvironment env) : base(env.Engine.Object.InstancePrototype)
        {
            Environment = env;
            this.PopulateFunctions();
            this.CurrentCommander = new CommanderInstance(env, EDCommander.Current);
        }

        #region Javascript-visible methods
        [JSFunction(Name = "addEventHandler")]
        public void AddEventHandler(string entry, bool filtercmdr, FunctionInstance func)
        {
            func["FilterCommander"] = filtercmdr;
            List<JournalEntryHandler> handlers = EventHandlers.GetOrAdd(entry, (e) => new List<JournalEntryHandler>());
            lock (handlers)
            {
                handlers.Add(new JournalEntryHandler { FilterCommander = filtercmdr, Handler = func });
            }
        }

        [JSFunction(Name = "removeEventHandler")]
        public void RemoveEventHandler(string entry, bool filtercmdr, FunctionInstance func = null)
        {
            func["FilterCommander"] = filtercmdr;
            List<JournalEntryHandler> handlers;
            if (EventHandlers.TryGetValue(entry, out handlers))
            {
                lock (handlers)
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
            return Engine.Array.Construct(JournalEntry.GetAll(CurrentCommander.Index, start, stop).Select(e => JournalEntryInstance.Create(Environment, e)).ToArray());
        }

        [JSFunction(Name = "getByEventType")]
        public ArrayInstance GetByEventType(string type, DateTime? start = null, DateTime? stop = null)
        {
            JournalTypeEnum entrytype = (JournalTypeEnum)Enum.Parse(typeof(JournalTypeEnum), type);
            return Engine.Array.Construct(JournalEntry.GetByEventType(entrytype, CurrentCommander.Index, start ?? new DateTime(2014, 1, 1), stop ?? DateTime.UtcNow).Select(e => JournalEntryInstance.Create(Environment, e)).ToArray());
        }

        [JSFunction(Name = "getLastEvent")]
        public JournalEntryInstance GetLastEvent(DateTime? end, FunctionInstance filter)
        {
            Func<JournalEntry, bool> xfilter = je => true;

            if (filter != null)
                xfilter = je => TypeConverter.ToBoolean(filter.Call(this, JournalEntryInstance.Create(Environment, je)));

            JournalEntry ret = JournalEntry.GetLast(CurrentCommander.Index, end ?? DateTime.UtcNow, xfilter);
            return ret == null ? null : JournalEntryInstance.Create(Environment, ret);
        }

        [JSFunction(Name = "changeCommander")]
        public void ChangeCommander(string name)
        {
            var cmdr = EDCommander.GetCommander(name);
            if (cmdr != null)
            {
                CurrentCommander = new CommanderInstance(Environment, cmdr);
            }
        }

        [JSFunction(Name = "changeCommander")]
        public void ChangeCommander(int nr)
        {
            var cmdr = EDCommander.GetCommander(nr);
            if (cmdr != null)
            {
                CurrentCommander = new CommanderInstance(Environment, cmdr);
            }
        }
        #endregion

        #region Javascript-visible properties
        [JSProperty(Name = "currentCommander")]
        public CommanderInstance CurrentCommander { get; private set; }
        #endregion

        #region Event subscription
        protected void OnNewJournalEntry(JournalEntry je, string eventtype)
        {
            string evtype = eventtype;

            if (evtype == null)
            {
                evtype = je.EventTypeStr;
            }

            List<JournalEntryHandler> handlers;
            if (EventHandlers.TryGetValue(eventtype, out handlers))
            {
                JournalEntryInstance ji = je == null ? null : JournalEntryInstance.Create(Environment, je);
                JournalEntryHandler[] handlerlist;

                lock (handlers)
                {
                    handlerlist = new JournalEntryHandler[handlers.Count];
                    handlers.CopyTo(handlerlist);
                }

                foreach (JournalEntryHandler handler in handlerlist)
                {
                    if (CurrentCommander.Index == je.CommanderId || handler.FilterCommander == false)
                    {
                        handler.Handler.Call(this, ji);
                    }
                }
            }

            if (eventtype == null)
            {
                if (je is JournalLocOrJump)
                {
                    OnNewJournalEntry(je, "@Location");
                }
                
                if (je is IMaterialCommodityJournalEntry)
                {
                    OnNewJournalEntry(je, "@MaterialCommodity");
                }

                if (je is ILedgerJournalEntry)
                {
                    OnNewJournalEntry(je, "@Ledger");
                }

                if (je is ILedgerNoCashJournalEntry)
                {
                    OnNewJournalEntry(je, "@LedgerNoCash");
                }

                if (je is IMissions)
                {
                    OnNewJournalEntry(je, "@Missions");
                }

                if (je is IShipInformation)
                {
                    OnNewJournalEntry(je, "@ShipInformation");
                }

                if (je is IBodyNameAndID)
                {
                    OnNewJournalEntry(je, "@WithSystem");
                }

                OnNewJournalEntry(je, "@Any");
            }
        }

        public void OnNewJournalEntry(JournalEntry je)
        {
            OnNewJournalEntry(je, null);
        }

        public void OnRefresh(HistoryList hl)
        {
            OnNewJournalEntry(null, "@Refresh");
        }
        #endregion
    }
}
