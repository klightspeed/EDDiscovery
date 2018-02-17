using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jurassic;
using Jurassic.Library;

namespace EDDiscovery.ModApi.Javascript
{
    public class CommanderInstance : ObjectInstance
    {
        public CommanderInstance(ScriptEngine engine, EliteDangerousCore.EDCommander cmdr) : base(engine)
        {
            this.PopulateFields();
            this.Name = cmdr.Name;
            this.Index = cmdr.Nr;
        }

        [JSProperty(Name = "index")]
        public int Index { get; set; }

        [JSProperty(Name = "name")]
        public string Name { get; set; }
    }
}
