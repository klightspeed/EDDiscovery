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
        private EliteDangerousCore.EDCommander Commander;

        public CommanderInstance(ScriptEngine engine) : base(engine.Object.InstancePrototype)
        {
            PopulateFunctions();
        }

        public CommanderInstance(ScriptEnvironment env, EliteDangerousCore.EDCommander cmdr) : base(env.CommanderPrototype)
        {
            this.Name = cmdr.Name;
            this.Index = cmdr.Nr;
            Commander = cmdr;
        }

        [JSProperty(Name = "index")]
        public int Index { get; set; }

        [JSProperty(Name = "name")]
        public string Name { get; set; }
    }
}
