using EDDiscovery;
using EDDiscovery.DB;
using EDDiscovery2.DB;
using EDDiscovery2.EDDB;
using EDDiscovery2.HTTP;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace EDDiscovery2.EDSM
{
    class EDSMClass : HttpCom
    {
        public string commanderName;
        public string apiKey;

        private readonly string fromSoftwareVersion;
        private readonly string fromSoftware;



        public EDSMClass()
        {
            fromSoftware = "EDDiscovery";
            _serverAddress = "http://www.edsm.net/";

            var assemblyFullName = Assembly.GetExecutingAssembly().FullName;
            fromSoftwareVersion = assemblyFullName.Split(',')[1].Split('=')[1];
        }

        public JObject SubmitDistances(string cmdr, string from, string to, double dist)
        {
            return SubmitDistances(cmdr, from, new Dictionary<string, double> { { to, dist } });
        }

        public JObject SubmitDistances(string cmdr, string from, Dictionary<string, double> distances)
        {
            JObject query = new JObject
            {
                { "data", new JObject {
                    { "ver", 2 },
                    { "commander", cmdr },
                    { "fromSoftware", fromSoftware },
                    { "fromSoftwareVersion", fromSoftwareVersion },
                    { "p0", new JObject {
                        { "name", from }
                    }},
                    { "refs", new JArray(distances.Select(kvp => new JObject { { "name", kvp.Key }, { "dist", kvp.Value } }).ToArray()) }
                }}
            };

            var response = RequestPost(query.ToString(), "api-v1/submit-distances");
            return JObject.Parse(response.Body);
        }

        public bool ShowDistanceResponse(JObject edsm, out string respstr, out Boolean trilOK)
        {
            bool retval = true;
            trilOK = false;

            respstr = "";

            try
            {
                if (edsm == null)
                    return false;

                JObject basesystem = (JObject)edsm["basesystem"];
                JArray distances = (JArray)edsm["distances"];


                if (distances != null)
                    foreach (var st in distances)
                    {
                        int statusnum = st["msgnum"].Value<int>();

                        if (statusnum == 201)
                            retval = false;

                        respstr += "Status " + statusnum.ToString() + " : " + st["msg"].Value<string>() + Environment.NewLine;

                    }

                if (basesystem != null)
                {

                    int statusnum = basesystem["msgnum"].Value<int>();

                    if (statusnum == 101)
                        retval = false;

                    if (statusnum == 102 || statusnum == 104)
                        trilOK = true;

                    respstr += "System " + statusnum.ToString() + " : " + basesystem["msg"].Value<string>() + Environment.NewLine;
                }

                return retval;
            }
            catch (Exception ex)
            {
                respstr += "Excpetion in ShowDistanceResponse: " + ex.Message;
                return false;
            }
        }

        private List<SystemClass> GetSystems(string request, ref DateTime maxdate, string savefile = null)
        {
            var response = RequestGet(request);

            if (savefile != null)
            {
                File.WriteAllText(savefile, response.Body);
            }

            var json = JArray.Parse(response.Body);
            List<SystemClass> listSystems = new List<SystemClass>();

            foreach (JObject jo in json)
            {
                string name = jo["name"].Value<string>();

                SystemClass system = new SystemClass(jo, SystemInfoSource.EDSM);

                if (system.UpdateDate.Subtract(maxdate).TotalSeconds > 0)
                    maxdate = system.UpdateDate;

                if (system.HasCoordinate)
                    listSystems.Add(system);
            }

            return listSystems;
        }

        public List<SystemClass> GetSystems(DateTime date, ref DateTime maxdate)
        {
            if (date.Subtract(new DateTime(2015, 5, 10)).TotalDays < 0)
                date = new DateTime(2015, 5, 10, 0, 0, 0, DateTimeKind.Utc);

            string datestr = HttpUtility.UrlEncode(date.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
            return GetSystems("api-v1/systems?startdatetime=" + datestr + "&coords=1&submitted=1&known=1", ref maxdate);
        }

        public List<SystemClass> GetAllSystems(ref DateTime maxdate, string savefile = null)
        {
            return GetSystems("dump/systemsWithCoordinates.json", ref maxdate, savefile);
        }

        private List<DistanceClass> GetDistances(string request, ref DateTime maxdate, string savefile = null)
        {
            var response = RequestGet(request);

            if (savefile != null)
            {
                File.WriteAllText(savefile, response.Body);
            }

            var json = JArray.Parse(response.Body);
            List<DistanceClass> listDistances = new List<DistanceClass>();
            foreach (JObject jo in json)
            {
                var submittedby = jo["submitted_by"] as JArray;
                var createdby = submittedby == null ? null : submittedby.FirstOrDefault();

                DistanceClass dist = new DistanceClass
                {
                    NameA = jo["sys1"]["name"].Value<string>(),
                    NameB = jo["sys2"]["name"].Value<string>(),
                    Dist = jo["distance"].Value<float>(),
                    CommanderCreate = createdby == null ? "" : createdby["cmdrname"].Value<string>(),
                    CreateTime = jo["date"].Value<DateTime>(),
                    Status = DistancsEnum.EDSC
                };

                if (dist.NameA != null && dist.NameB != null)
                {
                    listDistances.Add(dist);
                    if (dist.CreateTime.Subtract(maxdate).TotalSeconds > 0)
                        maxdate = dist.CreateTime;
                }
            }

            return listDistances;
        }

        public List<DistanceClass> GetDistances(DateTime date, ref DateTime maxdate)
        {
            if (date.Subtract(new DateTime(2015, 5, 10)).TotalDays < 0)
                date = new DateTime(2015, 5, 10, 0, 0, 0, DateTimeKind.Utc);

            string datestr = HttpUtility.UrlEncode(date.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
            return GetDistances("api-v1/distances?startdatetime=" + datestr + "&submitted=1", ref maxdate);
        }

        public List<DistanceClass> GetAllDistances(ref DateTime maxdate, string savefile = null)
        {
            return GetDistances("dump/distances.json", ref maxdate, savefile);
        }

        public string GetNewSystems(SQLiteDBClass db)
        {
            DateTime date = new DateTime(2010, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime lastsyst = date;

            string retstr = "";

            db.GetAllSystems();

            if (SQLiteDBClass.globalSystems != null && SQLiteDBClass.globalSystems.Count != 0)
            {
                DateTime NewSysTime = SQLiteDBClass.globalSystems.Max(x => x.UpdateDate);
                string lastsyststr = db.GetSettingString("EDSMLastSystems", NewSysTime.ToString("yyyy-MM-dd HH:mm:mm", CultureInfo.InvariantCulture));

                if (lastsyststr.Equals("2010-01-01 00:00:00") || !DateTime.TryParseExact(lastsyststr, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out lastsyst))
                {
                    lastsyst = NewSysTime;
                }
            }
            List<SystemClass> listNewSystems = GetSystems(lastsyst, ref date);

            List<SystemClass> systems2Store = new List<SystemClass>();

            foreach (SystemClass system in listNewSystems)
            {
                // Check if sys exists first
                SystemClass sys = SystemData.GetSystem(system.name);
                if (sys == null)
                    systems2Store.Add(system);
                else if (!sys.name.Equals(system.name) || sys.x != system.x || sys.y != system.y || sys.z != system.z)  // Case or position changed
                    systems2Store.Add(system);
            }
            SystemClass.Store(systems2Store);

            retstr = systems2Store.Count.ToString() + " new systems from EDSM." + Environment.NewLine;

            db.PutSettingString("EDSMLastSystems", date.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));

            return retstr;
        }


        internal string GetHiddenSystems()
        {
            EDDBClass eddb = new EDDBClass();

            try
            {
                string edsmhiddensystems = Path.Combine(Tools.GetAppDataDirectory(), "edsmhiddensystems.json");
                bool newfile = false;
                eddb.DownloadFile("http://www.edsm.net/api-v1/hidden-systems", edsmhiddensystems, out newfile);

                string json = EDDiscovery.EDDiscoveryForm.LoadJsonFile(edsmhiddensystems);

                return json;
            }
            
            catch (Exception ex)
            {
                Trace.WriteLine($"Exception: {ex.Message}");
                Trace.WriteLine($"ETrace: {ex.StackTrace}");
                return null;
            }
        
        }

        public List<DistanceClass> GetDistances(string systemname)
        {
            List<DistanceClass> listDistances = new List<DistanceClass>();
            try
            {
                string query;
                query = "?sysname=" + HttpUtility.UrlEncode(systemname) + "&coords=1&distances=1&submitted=1";

                var response = RequestGet("api-v1/system" + query);
                var json = response.Body;

                //http://www.edsm.net/api-v1/system?sysname=Col+359+Sector+CP-Y+c1-18&coords=1&include_hidden=1&distances=1&submitted=1

                if (json.Length > 1)
                {
                    JObject ditancesresp = (JObject)JObject.Parse(json);

                    JArray distances = (JArray)ditancesresp["distances"];

                    if (distances != null)
                    {
                        foreach (JObject jo in distances)
                        {
                            DistanceClass dc = new DistanceClass();

                            dc.NameA = systemname;
                            dc.NameB = jo["name"].Value<string>();
                            dc.Dist = jo["dist"].Value<float>();
//                            dc.CommanderCreate = jo[]

                            listDistances.Add(dc);
                        }
                    }
                }
            }
            catch
            {
            }
            return listDistances;
        }

        public int GetComments(DateTime starttime, out List<SystemNoteClass> notes)
        {
            notes = new List<SystemNoteClass>();

            var json = GetComments(starttime);
            if (json == null)
            {
                return 0;
            }

            JObject msg = JObject.Parse(json);
            int msgnr = msg["msgnum"].Value<int>();

            JArray comments = (JArray)msg["comments"];
            if (comments != null)
            {
                foreach (JObject jo in comments)
                {
                    SystemNoteClass note = new SystemNoteClass();
                    note.Name = jo["system"].Value<string>();
                    note.Note = jo["comment"].Value<string>();
                    note.Time = DateTime.ParseExact(jo["lastUpdate"].Value<string>(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal).ToLocalTime();
                    notes.Add(note);
                }
            }

            return msgnr;
        }

        public string GetComments(DateTime starttime)
        {
            SQLiteDBClass db = new SQLiteDBClass();

            string query = "get-comments?startdatetime=" + HttpUtility.UrlEncode(starttime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)) + "&apiKey=" + apiKey + "&commanderName=" + HttpUtility.UrlEncode(commanderName);
            //string query = "get-comments?apiKey=" + apiKey + "&commanderName=" + HttpUtility.UrlEncode(commanderName);
            var response = RequestGet("api-logs-v1/" + query);
            return response.Body;
        }


        public string GetComment(string systemName)
        {
            string query;
            query = "get-comment?systemName=" + HttpUtility.UrlEncode(systemName);

            var response = RequestGet("api-logs-v1/" + query);
            return response.Body;
        }

        public string SetComment(SystemNoteClass sn)
        {
            string query;
            query = "set-comment?systemName=" + HttpUtility.UrlEncode(sn.Name) + "&commanderName=" + HttpUtility.UrlEncode(commanderName) + "&apiKey=" + apiKey + "&comment=" + HttpUtility.UrlEncode(sn.Note);
            var response = RequestGet("api-logs-v1/" + query);
            return response.Body;
        }

        public string SetLog(string systemName, DateTime dateVisited)
        {
            string query;
            query = "set-log?systemName=" + HttpUtility.UrlEncode(systemName) + "&commanderName=" + HttpUtility.UrlEncode(commanderName) + "&apiKey=" + apiKey +
                 "&fromSoftware=" + HttpUtility.UrlEncode(fromSoftware) + "&fromSoftwareVersion=" + HttpUtility.UrlEncode(fromSoftwareVersion) +
                  "&dateVisited=" + HttpUtility.UrlEncode(dateVisited.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
            var response = RequestGet("api-logs-v1/" + query);
            return response.Body;
        }

        public string SetLogWithPos(string systemName, DateTime dateVisited, double x, double y, double z)
        {
            var culture = new System.Globalization.CultureInfo("en-US");
            string query;
            query = "set-log?systemName=" + HttpUtility.UrlEncode(systemName) + "&commanderName=" + HttpUtility.UrlEncode(commanderName) + "&apiKey=" + apiKey +
                 "&fromSoftware=" + HttpUtility.UrlEncode(fromSoftware) + "&fromSoftwareVersion=" + HttpUtility.UrlEncode(fromSoftwareVersion) +
                 "&x=" + HttpUtility.UrlEncode(x.ToString(culture)) + "&y=" + HttpUtility.UrlEncode(y.ToString(culture)) + "&z=" + HttpUtility.UrlEncode(z.ToString(culture)) +
                  "&dateVisited=" + HttpUtility.UrlEncode(dateVisited.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
            var response = RequestGet("api-logs-v1/" + query);
            return response.Body;
        }

        public int GetLogs(DateTime starttime, out List<VisitedSystemsClass> log)
        {
            log = new List<VisitedSystemsClass>();

            string query = "get-logs?startdatetime=" + HttpUtility.UrlEncode(starttime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)) + "&apiKey=" + apiKey + "&commanderName=" + HttpUtility.UrlEncode(commanderName);
            //string query = "get-logs?apiKey=" + apiKey + "&commanderName=" + HttpUtility.UrlEncode(commanderName);
            var response = RequestGet("api-logs-v1/" + query);
            var json = response.Body;

            if (json == null)
                return 0;

            JObject msg = JObject.Parse(json);
            int msgnr = msg["msgnum"].Value<int>();

            JArray logs = (JArray)msg["logs"];

            if (logs != null)
            {
                foreach (JObject jo in logs)
                {
                    VisitedSystemsClass pos = new VisitedSystemsClass();


                    pos.Name = jo["system"].Value<string>();
                    string str = jo["date"].Value<string>();

                    pos.Time = DateTime.ParseExact(str, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal).ToLocalTime();

                    log.Add(pos);
              
                }
            }

            return msgnr;
        }

        public bool IsKnownSystem(string sysName)
        {
            string query = "system?sysname=" + HttpUtility.UrlEncode(sysName) + "&commanderName=" + HttpUtility.UrlEncode(commanderName) + "&apiKey=" + apiKey;
            var response = RequestGet("api-v1/" + query);
            var json = response.Body;
            if (json == null)
                return false;

            return (json.ToString() != "[]");
        }

        public List<String> GetPushedSystems()
        {
            List<String> systems = new List<string>();
            string query = "api-v1/systems?pushed=1";

            var response = RequestGet(query);
            var json = response.Body;
            if (json == null)
                return systems;

            JArray msg = JArray.Parse(json);

            if (msg != null)
            {
                foreach (JObject sysname in msg)
                {
                    systems.Add(sysname["name"].ToString());
                }
            }
                    return systems;



        }

        public bool ShowSystemInEDSM(string sysName)
        {
            string url = GetUrlToEDSMSystem(sysName);
            if (string.IsNullOrEmpty(url))
            {
                return false;
            }
            else
            {
                System.Diagnostics.Process.Start(url);
            }
            return true;
        }

        public string GetUrlToEDSMSystem(string sysName)
        {
            string encodedSys = HttpUtility.UrlEncode(sysName);
            string query = "system?sysname=" + encodedSys + "&commanderName=" + HttpUtility.UrlEncode(commanderName) + "&apiKey=" + apiKey + "&showId=1";
            var response = RequestGet("api-v1/" + query);
            var json = response.Body;
            if (json == null || json.ToString() == "[]")
                return "";

            JObject msg = JObject.Parse(json);
            string sysID = msg["id"].Value<string>();

            string url = "http://www.edsm.net/show-system/index/id/" + sysID + "/name/" + encodedSys;
            return url;
        }

    }
}
