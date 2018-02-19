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
using EliteDangerousCore.JournalEvents;

namespace EDDiscovery.ModApi.Javascript
{
    public class JournalEntryInstance : ObjectInstance
    {
        public class PowerStatesInfoInstance : ObjectInstance
        {
            public PowerStatesInfoInstance(ScriptEngine engine) : base(engine.Object.InstancePrototype)
            {
                PopulateFunctions();
            }

            public PowerStatesInfoInstance(ScriptEnvironment env, JournalLocOrJump.PowerStatesInfo state) : base(env.JournalEntryPrototype.PowerStatesInfoPrototype)
            {
                this.State = state.State;
                this.Trend = state.Trend;
            }

            [JSProperty]
            public string State { get; set; }

            [JSProperty]
            public int Trend { get; set; }
        }

        public class FactionInstance : ObjectInstance
        {
            public FactionInstance(ScriptEngine engine) : base(engine.Object.InstancePrototype)
            {
                PopulateFunctions();
            }

            public FactionInstance(ScriptEnvironment env, JournalLocOrJump.FactionInformation faction) : base(env.JournalEntryPrototype.FactionPrototype)
            {
                this.Allegiance = faction.Allegiance;
                this.FactionState = faction.FactionState;
                this.Government = faction.Government;
                this.Influence = faction.Influence;
                this.Name = faction.Name;
                this.PendingStates = faction.PendingStates.Select(s => new PowerStatesInfoInstance(env, s)).ToArray();
                this.RecoveringStates = faction.RecoveringStates.Select(s => new PowerStatesInfoInstance(env, s)).ToArray();
            }

            [JSProperty]
            public string Allegiance { get; set; }

            [JSProperty]
            public string FactionState { get; set; }

            [JSProperty]
            public string Government { get; set; }

            [JSProperty]
            public double Influence { get; set; }

            [JSProperty]
            public string Name { get; set; }

            [JSProperty]
            public PowerStatesInfoInstance[] PendingStates { get; set; }

            [JSProperty]
            public PowerStatesInfoInstance[] RecoveringStates { get; set; }
        }

        public class StarPlanetRingInstance : ObjectInstance
        {
            public StarPlanetRingInstance(ScriptEngine engine) : base(engine.Object.InstancePrototype)
            {
                PopulateFunctions();
            }

            public StarPlanetRingInstance(ScriptEnvironment env, JournalScan.StarPlanetRing ring) : base(env.JournalEntryPrototype.StarPlanetRingPrototype)
            {
                this.RingClass = ring.RingClass;
                this.Name = ring.Name;
                this.InnerRad = ring.InnerRad;
                this.OuterRad = ring.OuterRad;
                this.MassMT = ring.MassMT;

            }

            [JSProperty]
            public string Name { get; set; }

            [JSProperty]
            public string RingClass { get; set; }

            [JSProperty]
            public double InnerRad { get; set; }

            [JSProperty]
            public double OuterRad { get; set; }

            [JSProperty]
            public double MassMT { get; set; }

        }

        public class BodyParentInstance : ObjectInstance
        {
            public BodyParentInstance(ScriptEngine engine) : base(engine.Object.InstancePrototype)
            {
                PopulateFunctions();
            }

            public BodyParentInstance(ScriptEnvironment env, JournalScan.BodyParent parent) : base(env.JournalEntryPrototype.BodyParentPrototype)
            {
                this.BodyType = parent.Type;
                this.BodyID = parent.BodyID;
            }

            [JSProperty]
            public string BodyType { get; set; }

            [JSProperty]
            public int BodyID { get; set; }
        }

        public class JournalLocOrJumpInstance : JournalEntryInstance
        {
            protected JournalLocOrJumpInstance(JournalLocOrJumpInstance prototype) : base(prototype)
            {
            }

            public JournalLocOrJumpInstance(JournalEntryInstance prototype) : base(prototype)
            {
                PopulateFunctions();
            }

            protected JournalLocOrJumpInstance(ScriptEnvironment env, JournalLocOrJumpInstance prototype, JournalEntry je) : base(prototype, je)
            {
                JournalLocOrJump jl = (JournalLocOrJump)je;
                this.StarSystem = jl.StarSystem;
                if (jl.HasCoordinate) this.StarPos = new SystemInstance.CoordsInstance(env, jl.StarPos.X, jl.StarPos.Y, jl.StarPos.Z);
                this.StarPosFromEDSM = jl.StarPosFromEDSM;
                this.SystemAddress = jl.SystemAddress;
                this.Allegiance = jl.Allegiance;
                this.Economy = jl.Economy;
                this.Economy_Localised = jl.Economy_Localised;
                this.Faction = jl.Faction;
                this.FactionState = jl.FactionState;
                this.Government = jl.Government;
                this.Government_Localised = jl.Government_Localised;
                this.Population = jl.Population;
                this.PowerplayState = jl.PowerplayState;
                this.Security = jl.Security;
                this.Security_Localised = jl.Security_Localised;
                this.Wanted = jl.Wanted;
                this.Powers = jl.Powers;
                this.Factions = jl.Factions.Select(f => new FactionInstance(env, f)).ToArray();
            }

            [JSProperty]
            public string StarSystem { get; set; }

            [JSProperty]
            public SystemInstance.CoordsInstance StarPos { get; set; }

            [JSProperty]
            public long? SystemAddress { get; set; }

            [JSProperty]
            public bool StarPosFromEDSM { get; set; }

            [JSProperty]
            public bool EDSMFirstDiscover { get; set; }

            [JSProperty]
            public string Faction { get; set; }

            [JSProperty]
            public string FactionState { get; set; }

            [JSProperty]
            public string Allegiance { get; set; }

            [JSProperty]
            public string Economy { get; set; }

            [JSProperty]
            public string Economy_Localised { get; set; }

            [JSProperty]
            public string Government { get; set; }

            [JSProperty]
            public string Government_Localised { get; set; }

            [JSProperty]
            public string Security { get; set; }

            [JSProperty]
            public string Security_Localised { get; set; }

            [JSProperty]
            public long? Population { get; set; }

            [JSProperty]
            public string PowerplayState { get; set; }

            [JSProperty]
            public string[] Powers { get; set; }

            [JSProperty]
            public bool? Wanted { get; set; }

            [JSProperty]
            public FactionInstance[] Factions { get; set; }
        }

        public class JournalLocationInstance : JournalLocOrJumpInstance
        {
            public JournalLocationInstance(JournalLocOrJumpInstance prototype) : base(prototype)
            {
                PopulateFunctions();
            }

            public JournalLocationInstance(ScriptEnvironment env, JournalEntry je) : base(env, env.JournalEntryPrototype.JournalLocationPrototype, je)
            {
                JournalLocation jl = (JournalLocation)je;
                this.Docked = jl.Docked;
                this.StationName = jl.StationName;
                this.StationType = jl.StationType;
                this.Body = jl.Body;
                this.BodyID = jl.BodyID;
                this.BodyDesignation = jl.BodyDesignation;
                this.BodyType = jl.BodyType;
                this.Latitude = jl.Latitude;
                this.Longitude = jl.Longitude;
            }

            [JSProperty]
            public bool Docked { get; set; }

            [JSProperty]
            public string StationName { get; set; }

            [JSProperty]
            public string StationType { get; set; }

            [JSProperty]
            public string Body { get; set; }

            [JSProperty]
            public int? BodyID { get; set; }

            [JSProperty]
            public string BodyType { get; set; }

            [JSProperty]
            public string BodyDesignation { get; set; }

            [JSProperty]
            public double? Latitude { get; set; }

            [JSProperty]
            public double? Longitude { get; set; }
        }

        public class JournalFSDJumpInstance : JournalLocOrJumpInstance
        {
            public JournalFSDJumpInstance(JournalLocOrJumpInstance prototype) : base(prototype)
            {
                PopulateFunctions();
            }

            public JournalFSDJumpInstance(ScriptEnvironment env, JournalEntry je) : base(env, env.JournalEntryPrototype.JournalFSDJumpPrototype, je)
            {
                JournalFSDJump jfsd = (JournalFSDJump)je;
                this.JumpDist = jfsd.JumpDist;
                this.FuelLevel = jfsd.FuelLevel;
                this.FuelUsed = jfsd.FuelUsed;
                this.BoostUsed = jfsd.BoostUsed;
                this.BoostValue = jfsd.BoostValue;
                this.IsRealJournalEvent = jfsd.RealJournalEvent;
            }

            [JSProperty]
            public double JumpDist { get; set; }

            [JSProperty]
            public double FuelUsed { get; set; }

            [JSProperty]
            public double FuelLevel { get; set; }

            [JSProperty]
            public bool BoostUsed { get; set; }

            [JSProperty]
            public double BoostValue { get; set; }

            [JSProperty]
            public bool IsRealJournalEvent { get; private set; }
        }

        public class JournalWithSystemInstance : JournalEntryInstance
        {
            protected JournalWithSystemInstance(JournalWithSystemInstance prototype) : base(prototype)
            {
            }

            public JournalWithSystemInstance(JournalEntryInstance prototype) : base(prototype)
            {
                PopulateFunctions();
            }

            protected JournalWithSystemInstance(ScriptEnvironment env, JournalWithSystemInstance prototype, JournalEntry je) : base(prototype, je)
            {
                IBodyNameAndID jb = (IBodyNameAndID)je;
                this.StarSystem = jb.StarSystem;
                this.SystemAddress = jb.SystemAddress;
                this.Body = jb.Body;
                this.BodyID = jb.BodyID;
                this.BodyType = jb.BodyType;
                this.BodyDesignation = jb.BodyDesignation;
            }

            public new static JournalWithSystemInstance Create(ScriptEnvironment env, JournalEntry je)
            {
                return new JournalWithSystemInstance(env, env.JournalEntryPrototype.JournalWithSystemPrototype, je);
            }

            [JSProperty]
            public string StarSystem { get; set; }

            [JSProperty]
            public long? SystemAddress { get; set; }

            [JSProperty]
            public string Body { get; set; }

            [JSProperty]
            public int? BodyID { get; set; }

            [JSProperty]
            public string BodyType { get; set; }

            [JSProperty]
            public string BodyDesignation { get; set; }
        }

        public class JournalWithStationSystemInstance : JournalEntryInstance
        {
            protected JournalWithStationSystemInstance(JournalWithStationSystemInstance prototype) : base(prototype)
            {
            }

            public JournalWithStationSystemInstance(JournalEntryInstance prototype) : base(prototype)
            {
                PopulateFunctions();
            }

            protected JournalWithStationSystemInstance(ScriptEnvironment env, JournalWithStationSystemInstance prototype, JournalEntry je) : base(prototype, je)
            {
                ISystemStationMarket js = (ISystemStationMarket)je;
                this.StarSystem = js.StarSystem;
                this.StationName = js.StationName;
                this.MarketID = js.MarketID;
            }

            public new static JournalWithStationSystemInstance Create(ScriptEnvironment env, JournalEntry je)
            {
                if (je is JournalDocked)
                {
                    return new JournalDockedInstance(env, je);
                }
                else
                {
                    return new JournalWithStationSystemInstance(env, env.JournalEntryPrototype.JournalWithStationSystemPrototype, je);
                }
            }

            [JSProperty]
            public string StarSystem { get; set; }

            [JSProperty]
            public string StationName { get; set; }

            [JSProperty]
            public long? MarketID { get; set; }
        }

        public class JournalDockedInstance : JournalWithStationSystemInstance
        {
            public JournalDockedInstance(JournalWithStationSystemInstance prototype) : base(prototype)
            {
                PopulateFunctions();
            }

            public JournalDockedInstance(ScriptEnvironment env, JournalEntry je) : base(env, env.JournalEntryPrototype.JournalDockedPrototype, je)
            {
                JournalDocked jd = (JournalDocked)je;
                this.Faction = jd.Faction;
                this.FactionState = jd.FactionState;
                this.Economy = jd.Economy;
                this.Economy_Localised = jd.Economy_Localised;
                this.Government = jd.Government;
                this.Government_Localised = jd.Government_Localised;
                this.Allegiance = jd.Allegiance;
                this.StationServices = jd.StationServices.ToArray();
                this.Wanted = jd.Wanted;
                this.CockpitBreach = jd.CockpitBreach;
            }

            [JSProperty]
            public string Faction { get; set; }

            [JSProperty]
            public string FactionState { get; set; }

            [JSProperty]
            public string Allegiance { get; set; }

            [JSProperty]
            public string Economy { get; set; }

            [JSProperty]
            public string Economy_Localised { get; set; }

            [JSProperty]
            public string Government { get; set; }

            [JSProperty]
            public string Government_Localised { get; set; }

            [JSProperty]
            public string[] StationServices { get; set; }

            [JSProperty]
            public bool? Wanted { get; set; }

            [JSProperty]
            public bool? CockpitBreach { get; set; }
        }

        public class JournalWithStationTypeInstance : JournalEntryInstance
        {
            protected JournalWithStationTypeInstance(JournalWithStationTypeInstance prototype) : base(prototype)
            {
            }

            public JournalWithStationTypeInstance(JournalEntryInstance prototype) : base(prototype)
            {
                PopulateFunctions();
            }

            protected JournalWithStationTypeInstance(ScriptEnvironment env, JournalWithStationTypeInstance prototype, JournalEntry je) : base(prototype, je)
            {
                IStationEntry js = (IStationEntry)je;
                this.StationName = js.StationName;
                this.StationType = js.StationType;
                this.MarketID = js.MarketID;

                if (je is JournalDockingDenied)
                {
                    this["Reason"] = ((JournalDockingDenied)je).Reason;
                }
                else if (je is JournalDockingGranted)
                {
                    this["LandingPad"] = ((JournalDockingGranted)je).LandingPad;
                }
            }

            public new static JournalWithStationTypeInstance Create(ScriptEnvironment env, JournalEntry je)
            {
                return new JournalWithStationTypeInstance(env, env.JournalEntryPrototype.JournalWithStationTypePrototype, je);
            }

            [JSProperty]
            public string StationName { get; set; }

            [JSProperty]
            public string StationType { get; set; }

            [JSProperty]
            public long? MarketID { get; set; }
        }

        public class JournalScanInstance : JournalEntryInstance
        {
            protected JournalScanInstance(JournalScanInstance prototype) : base(prototype)
            {
            }

            public JournalScanInstance(JournalEntryInstance prototype) : base(prototype)
            {
                PopulateFunctions();
            }

            protected JournalScanInstance(ScriptEnvironment env, JournalScanInstance prototype, JournalScan je) : base(prototype, je)
            {
                this.ScanType = je.ScanType;
                this.BodyName = je.BodyName;
                this.BodyID = je.BodyID;
                this.DistanceFromArrivalLS = je.DistanceFromArrivalLS;
                this.RotationPeriod = je.nRotationPeriod;
                this.SurfaceTemperature = je.nSurfaceTemperature;
                this.Radius = je.nRadius;
                this.SemiMajorAxis = je.nSemiMajorAxis;
                this.OrbitalPeriod = je.nOrbitalPeriod;
                this.OrbitalInclination = je.nOrbitalInclination;
                this.ArgOfPeriapsis = je.nPeriapsis;
                this.Eccentricity = je.nEccentricity;
                this.AxialTilt = je.nAxialTilt;
                this.Rings = je.Rings == null ? null : je.Rings.Select(r => new StarPlanetRingInstance(env, r)).ToArray();
                this.EstimatedValue = je.EstimatedValue;
                this.Parents = je.Parents == null ? null : je.Parents.Select(p => new BodyParentInstance(env, p)).ToArray();
                this.IsEDSMBody = je.IsEDSMBody;
            }

            public new static JournalScanInstance Create(ScriptEnvironment env, JournalEntry je)
            {
                JournalScan js = (JournalScan)je;

                if (js.StarType != null)
                {
                    return new JournalScanStarInstance(env, js);
                }
                else if (js.PlanetClass != null)
                {
                    return new JournalScanPlanetInstance(env, js);
                }
                else
                {
                    return new JournalScanInstance(env, env.JournalEntryPrototype.JournalScanPrototype, js);
                }
            }

            [JSProperty]
            public string ScanType { get; set; }                        // 3.0 scan type  Basic, Detailed, NavBeacon, NavBeaconDetail or empty for older ones

            [JSProperty]
            public string BodyName { get; set; }                        // direct (meaning no translation)

            [JSProperty]
            public int? BodyID { get; set; }                            // direct

            [JSProperty]
            public double DistanceFromArrivalLS { get; set; }           // direct

            [JSProperty]
            public double? RotationPeriod { get; set; }                // direct

            [JSProperty]
            public double? SurfaceTemperature { get; set; }            // direct

            [JSProperty]
            public double? Radius { get; set; }                        // direct

            [JSProperty]
            public double? SemiMajorAxis { get; set; }                 // direct

            [JSProperty]
            public double? Eccentricity { get; set; }                  // direct

            [JSProperty]
            public double? OrbitalInclination { get; set; }            // direct

            [JSProperty]
            public double? ArgOfPeriapsis { get; set; }                // direct

            [JSProperty]
            public double? OrbitalPeriod { get; set; }                 // direct

            [JSProperty]
            public double? AxialTilt { get; set; }                 // direct, radians

            [JSProperty]
            public bool HasRings { get { return Rings != null && Rings.Length > 0; } }

            [JSProperty]
            public StarPlanetRingInstance[] Rings { get; set; }

            [JSProperty]
            public int EstimatedValue { get; set; }

            [JSProperty]
            public ObjectInstance[] Parents { get; set; }

            [JSProperty]
            public bool IsEDSMBody { get; private set; }
        }

        public class JournalScanStarInstance : JournalScanInstance
        {
            public JournalScanStarInstance(JournalScanInstance prototype) : base(prototype)
            {
                PopulateFunctions();
            }

            public JournalScanStarInstance(ScriptEnvironment env, JournalScan je) : base(env, env.JournalEntryPrototype.JournalScanStarPrototype, je)
            {
                this.StarType = je.StarType;
                this.StarTypeText = je.StarTypeText;
                this.StellarMass = je.nStellarMass;
                this.AbsoluteMagnitude = je.nAbsoluteMagnitude;
                this.Luminosity = je.Luminosity;
                this.Age = je.nAge;
                this.HabitableZoneInner = je.HabitableZoneInner;
                this.HabitableZoneOuter = je.HabitableZoneOuter;
            }

            [JSProperty]
            public string StarType { get; set; }                        // null if no StarType, direct from journal, K, A, B etc

            [JSProperty]
            public string StarTypeText { get; set; }                    // Long form star name, from StarTypeID

            [JSProperty]
            public double? StellarMass { get; set; }                   // direct

            [JSProperty]
            public double? AbsoluteMagnitude { get; set; }             // direct

            [JSProperty]
            public string Luminosity { get; set; }

            [JSProperty]
            public double? Age { get; set; }                           // direct

            [JSProperty]
            public double? HabitableZoneInner { get; set; }             // calculated

            [JSProperty]
            public double? HabitableZoneOuter { get; set; }             // calculated
        }

        public class JournalScanPlanetInstance : JournalScanInstance
        {
            public JournalScanPlanetInstance(JournalScanInstance prototype) : base(prototype)
            {
                PopulateFunctions();
            }

            public JournalScanPlanetInstance(ScriptEnvironment env, JournalScan je) : base(env, env.JournalEntryPrototype.JournalScanPlanetPrototype, je)
            {
                this.PlanetClass = je.PlanetClass;
                this.TidalLock = je.nTidalLock;
                this.TerraformState = je.TerraformState;
                this.Atmosphere = je.Atmosphere;
                this.AtmosphereComposition = je.AtmosphereComposition;
                this.Volcanism = je.Volcanism;
                this.SurfaceGravity = je.nSurfaceGravity;
                this.SurfacePressure = je.nSurfacePressure;
                this.IsLandable = je.IsLandable;
                this.MassEM = je.nMassEM;
                this.Materials = je.Materials;
            }

            [JSProperty]
            public string PlanetClass { get; set; }                     // planet class, direct

            [JSProperty]
            public bool? TidalLock { get; set; }                       // direct

            [JSProperty]
            public string TerraformState { get; set; }                  // direct, can be empty or a string

            [JSProperty]
            public string Atmosphere { get; set; }                      // direct from journal, if not there or blank, tries AtmosphereType (Earthlikes)

            [JSProperty]
            public Dictionary<string, double> AtmosphereComposition { get; set; }

            [JSProperty]
            public string Volcanism { get; set; }                       // direct from journal

            [JSProperty]
            public double? SurfaceGravity { get; set; }                // direct

            [JSProperty]
            public double? SurfacePressure { get; set; }               // direct

            [JSProperty]
            public bool IsLandable { get; set; }

            [JSProperty]
            public double? MassEM { get; set; }                        // direct, not in description of event, mass in EMs

            [JSProperty]
            public Dictionary<string, double> Materials { get; set; }
        }

        private JournalEntry _JournalEntry;
        private FactionInstance FactionPrototype;
        private StarPlanetRingInstance StarPlanetRingPrototype;
        private BodyParentInstance BodyParentPrototype;
        private PowerStatesInfoInstance PowerStatesInfoPrototype;
        private JournalLocOrJumpInstance JournalLocOrJumpPrototype;
        private JournalLocationInstance JournalLocationPrototype;
        private JournalFSDJumpInstance JournalFSDJumpPrototype;
        private JournalWithSystemInstance JournalWithSystemPrototype;
        private JournalWithStationSystemInstance JournalWithStationSystemPrototype;
        private JournalWithStationTypeInstance JournalWithStationTypePrototype;
        private JournalScanInstance JournalScanPrototype;
        private JournalScanStarInstance JournalScanStarPrototype;
        private JournalScanPlanetInstance JournalScanPlanetPrototype;
        private JournalDockedInstance JournalDockedPrototype;

        protected JournalEntryInstance(ObjectInstance prototype) : base(prototype)
        {
        }

        protected JournalEntryInstance(JournalEntryInstance prototype, JournalEntry je) : base(prototype)
        {
            _JournalEntry = je;
            JournalEntryID = je.Id;
            Timestamp = je.EventTimeUTC;
            Event = je.EventTypeStr;
            CommanderID = je.CommanderId;
            EdsmID = je.EdsmID;
            IsBeta = je.Beta;
        }

        public JournalEntryInstance(ScriptEngine engine) : base(engine.Object.InstancePrototype)
        {
            PopulateFunctions();
            FactionPrototype = new FactionInstance(engine);
            PowerStatesInfoPrototype = new PowerStatesInfoInstance(engine);
            StarPlanetRingPrototype = new StarPlanetRingInstance(engine);
            BodyParentPrototype = new BodyParentInstance(engine);
            JournalLocOrJumpPrototype = new JournalLocOrJumpInstance(this);
            JournalLocationPrototype = new JournalLocationInstance(JournalLocOrJumpPrototype);
            JournalFSDJumpPrototype = new JournalFSDJumpInstance(JournalLocOrJumpPrototype);
            JournalWithSystemPrototype = new JournalWithSystemInstance(this);
            JournalWithStationSystemPrototype = new JournalWithStationSystemInstance(this);
            JournalDockedPrototype = new JournalDockedInstance(JournalWithStationSystemPrototype);
            JournalWithStationTypePrototype = new JournalWithStationTypeInstance(this);
            JournalScanPrototype = new JournalScanInstance(this);
            JournalScanStarPrototype = new JournalScanStarInstance(JournalScanPrototype);
            JournalScanPlanetPrototype = new JournalScanPlanetInstance(JournalScanPrototype);
        }

        protected JournalEntryInstance(ScriptEnvironment env, JournalEntry je) : this(env.JournalEntryPrototype, je)
        {
        }

        public static JournalEntryInstance Create(ScriptEnvironment env, JournalEntry je)
        {
            if (je is JournalLocation)
            {
                return new JournalLocationInstance(env, je);
            }
            else if (je is JournalFSDJump)
            {
                return new JournalFSDJumpInstance(env, je);
            }
            else if (je is IBodyNameAndID)
            {
                return JournalWithSystemInstance.Create(env, je);
            }
            else if (je is IStationEntry)
            {
                return JournalWithStationTypeInstance.Create(env, je);
            }
            else if (je is ISystemStationMarket)
            {
                return JournalWithStationSystemInstance.Create(env, je);
            }
            else if (je is JournalScan)
            {
                return JournalScanInstance.Create(env, je);
            }
            else
            {
                return new JournalEntryInstance(env, je);
            }
        }

        #region Javascript-visible methods
        [JSFunction(Name = "getRawEvent")]
        public ObjectInstance GetRawEvent()
        {
            return JSONObject.Parse(Engine, JournalEntry.GetJsonString(JournalEntryID)) as ObjectInstance;
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

        [JSProperty(Name = "isBeta")]
        public bool IsBeta { get; private set; }
        #endregion
    }
}
