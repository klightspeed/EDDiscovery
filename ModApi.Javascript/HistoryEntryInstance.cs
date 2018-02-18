using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jurassic;
using Jurassic.Library;
using EliteDangerousCore;

namespace EDDiscovery.ModApi.Javascript
{
    public class HistoryEntryInstance : ObjectInstance
    {
        private HistoryEntry _HistoryEntry;

        public HistoryEntryInstance(ScriptEngine engine) : base(engine.Object.InstancePrototype)
        {
            this.PopulateFunctions();
            this.System = new SystemInstance(engine);
        }

        public HistoryEntryInstance(ScriptEnvironment env, HistoryEntry he) : base(env.HistoryEntryPrototype)
        {
            this._HistoryEntry = he;
            this.JournalEntryID = he.Journalid;
            this.CommanderID = he.Commander.Nr;
            this.Timestamp = he.EventTimeUTC;
            this.EdsmID = he.journalEntry?.EdsmID ?? 0;
            this.Event = he.EntryType.ToString();
            this.JournalEntry = he.journalEntry == null ? null : new JournalEntryInstance(env, he.journalEntry);
            this.EventDescription = he.EventDescription;
            this.EventDetailedInfo = he.EventDetailedInfo;
            this.EventSummary = he.EventSummary;
            this.System = new SystemInstance(env, he.System);
        }

        #region Javascript-visible properties
        [JSProperty(Name = "id")]
        public long JournalEntryID { get; private set; }

        [JSProperty(Name = "commanderId")]
        public long CommanderID { get; private set; }

        [JSProperty(Name = "timestamp")]
        public DateTime Timestamp { get; private set; }

        [JSProperty(Name = "event")]
        public string Event { get; private set; }

        [JSProperty(Name = "edsmID")]
        public long EdsmID { get; private set; }

        [JSProperty(Name = "journalEntry")]
        public JournalEntryInstance JournalEntry { get; set; }

        [JSProperty(Name = "eventDescription")]
        public string EventDescription { get; set; }

        [JSProperty(Name = "eventDetailedInfo")]
        public string EventDetailedInfo { get; set; }

        [JSProperty(Name = "eventSummary")]
        public string EventSummary { get; set; }

        [JSProperty(Name = "system")]
        public SystemInstance System { get; set; }
        #endregion

    }
}
