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
    public class SystemInstance : ObjectInstance
    {
        public class CoordsInstance : ObjectInstance
        {
            public CoordsInstance(ScriptEngine engine, double x, double y, double z) : base(engine)
            {
                this.X = x;
                this.Y = y;
                this.Z = z;
                this.PopulateFields();
            }

            [JSProperty(Name = "x")]
            public double X { get; set; }

            [JSProperty(Name = "y")]
            public double Y { get; set; }

            [JSProperty(Name = "z")]
            public double Z { get; set; }
        }

        public SystemInstance(ScriptEngine engine, ISystem system) : base(engine)
        {
            this.Name = system.Name;
            this.SystemAddress = system.SystemAddress;
            this.EdsmId = system.EDSMID;
            this.Coords = system.HasCoordinate ? null : new CoordsInstance(Engine, system.X, system.Y, system.Z);
            this.PopulateFields();
        }

        [JSProperty(Name = "name")]
        public string Name { get; set; }

        [JSProperty(Name = "systemAddress")]
        public long? SystemAddress { get; set; }

        [JSProperty(Name = "edsmId")]
        public long? EdsmId { get; set; }

        [JSProperty(Name = "coords")]
        public CoordsInstance Coords { get; set; }
    }
}
