using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Reflection;
using Jurassic;
using Jurassic.Library;
using EliteDangerousCore;
using Newtonsoft.Json.Linq;

namespace EDDiscovery.ModApi.Javascript
{
    public class JournalEntryInstance : JournalObjectInstance<JournalEntry>
    {
        private JournalEntry _JournalEntry;

        static JournalEntryInstance()
        {
            ExcludeProperties = new HashSet<string>
            {
                "Icon",
            };
        }

        public JournalEntryInstance(ScriptEngine engine) : base(engine)
        {
        }

        public JournalEntryInstance(ScriptEnvironment env, JournalEntry je) : base(env.JournalEntryPrototype, je)
        {
            _JournalEntry = je;
            JournalEntryID = je.Id;
            Timestamp = je.EventTimeUTC;
            Event = je.EventTypeStr;
            CommanderID = je.CommanderId;
            EdsmID = je.EdsmID;
        }

        #region Javascript-visible methods
        [JSFunction(Name = "getRawEvent")]
        public object GetRawEvent()
        {
            return JSONObject.Parse(Engine, JournalEntry.GetJsonString(JournalEntryID));
        }

        [JSFunction(Name = "fillInformation")]
        public void FillInformation(FunctionInstance func)
        {
            string summary;
            string info;
            string description;
            _JournalEntry.FillInformation(out summary, out info, out description);
            func.Call(this, summary, info, description);
        }
        #endregion

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
        #endregion
    }
}
