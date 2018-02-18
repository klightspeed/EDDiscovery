using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jurassic;
using Jurassic.Library;
using EliteDangerousCore.DB;

namespace EDDiscovery.ModApi.Javascript
{
    public class ConfigInstance : ObjectInstance
    {
        private string Prefix;

        public ConfigInstance(ScriptEngine engine, string prefix) : base(engine)
        {
            Prefix = prefix;
        }

        [JSFunction(Name = "get")]
        public string Get(string name)
        {
            return SQLiteConnectionUser.GetSettingString(Prefix + "::" + name, null);
        }

        [JSFunction(Name = "set")]
        public void Set(string name, string value)
        {
            SQLiteConnectionUser.PutSettingString(Prefix + "::" + name, value);
        }

        [JSFunction(Name = "remove")]
        public void Remove(string name)
        {
            Set(name, null);
        }
    }
}
