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
    public class CommanderInstance : ObjectInstance
    {
        private EDCommander Commander;

        public CommanderInstance(ScriptEngine engine) : base(engine.Object.InstancePrototype)
        {
            PopulateFunctions();
        }

        public CommanderInstance(ScriptEnvironment env, EDCommander cmdr) : base(env.CommanderPrototype)
        {
            this.Name = cmdr.Name;
            this.Index = cmdr.Nr;
            Commander = cmdr;
        }

        public static CommanderInstance GetCommander(ScriptEnvironment env, int cmdrid)
        {
            EDCommander cmdr = EDCommander.GetCommander(cmdrid);
            if (cmdr == null)
            {
                return null;
            }
            else
            {
                return new CommanderInstance(env, cmdr);
            }
        }

        public static CommanderInstance GetCommander(ScriptEnvironment env, string name)
        {
            EDCommander cmdr = EDCommander.GetCommander(name);
            if (cmdr == null)
            {
                return null;
            }
            else
            {
                return new CommanderInstance(env, cmdr);
            }
        }

        [JSProperty(Name = "index")]
        public int Index { get; set; }

        [JSProperty(Name = "name")]
        public string Name { get; set; }
    }
}
