﻿/*
 * Copyright © 2017 EDDiscovery development team
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this
 * file except in compliance with the License. You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software distributed under
 * the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF
 * ANY KIND, either express or implied. See the License for the specific language
 * governing permissions and limitations under the License.
 * 
 * EDDiscovery is not affiliated with Frontier Developments plc.
 */

using System.Collections.Generic;
using BaseUtils;
using ActionLanguage;
using System.Windows.Forms;
using Conditions;
using System;
using EliteDangerousCore;

namespace EDDiscovery.Actions
{
    public class ActionDLLCall : ActionBase
    {
        List<string> FromString(string input)       
        {
            StringParser sp = new StringParser(input);
            List<string> s = sp.NextQuotedWordList(replaceescape: false);
            return (s != null && s.Count >= 2 ) ? s : null;
        }

        public override string VerifyActionCorrect()
        {
            return (FromString(userdata) != null) ? null : "DLLCall command line not in correct format";
        }

        public override bool ConfigurationMenu(Form parent, ActionCoreController cp, List<string> eventvars)
        {
            List<string> l = FromString(userdata);
            List<string> r = ExtendedControls.PromptMultiLine.ShowDialog(parent, "Configure DLLCall Dialog", cp.Icon,
                            new string[] { "DLL", "Acion", "P1", "P2" , "P3", "P4" , "P5", "P6" }, l?.ToArray(), true);

            if (r != null)
                userdata = r.ToStringCommaList(1, false);     

            return (r != null);
        }

        public override bool ExecuteAction(ActionProgramRun ap)
        {
            List<string> preexpand = FromString(UserData);

            if (preexpand != null)
            {
                List<string> exp;

                if (ap.functions.ExpandStrings(preexpand, out exp) != ConditionFunctions.ExpandResult.Failed && preexpand.Count>=2)
                {
                    System.Diagnostics.Debug.WriteLine("dll call " + string.Join(",", preexpand));

                    if (exp[1].Equals("JournalEntry", StringComparison.InvariantCultureIgnoreCase))
                    {
                        long? jid = null;
                        if (exp.Count == 3)
                            jid = exp[2].InvariantParseLongNull();

                        if ( jid.HasValue )
                        {
                            HistoryEntry h = (ap.actioncontroller as ActionController).DiscoveryForm.history.GetByJID(jid.Value);

                            if ( h != null)
                            {
                                Tuple<bool,bool> ret = (ap.actioncontroller as ActionController).DiscoveryForm.DLLManager.ActionJournalEntry(exp[0], DLL.EDDDLLCallerHE.CreateFromHistoryEntry(h));
                                if ( ret.Item1 == false )
                                    ap.ReportError("DLLCall cannot find DLL '" + exp[0] + "'");
                                else if ( ret.Item2 == false )
                                    ap.ReportError("DLL '" + exp[0] + "' does not implement ActionJournalEntry");
                            }
                            else
                                ap.ReportError("DLLCall JournalEntry history does not have that JID");
                        }
                        else
                            ap.ReportError("DLLCall JournalEntry missing Journal ID");
                    }
                    else
                    {
                        string[] paras = exp.GetRange(2, exp.Count - 2).ToArray();

                        Tuple<string, bool> res = (ap.actioncontroller as ActionController).DiscoveryForm.DLLManager.ActionCommand(exp[0], exp[1], paras);

                        if (res.Item2 == false)
                            ap.ReportError("DLLCall cannot find DLL '" + exp[0] + "'");
                        else if (res.Item1 == null)
                            ap.ReportError("DLL '" + exp[0] + "' does not implement ActionCommand");
                        else
                            ap["DLLResult"] = res.Item1;
                    }
                }
                else
                    ap.ReportError(exp[0]);
            }
            else
                ap.ReportError("DLLCall command line not in correct format");


            return true;
        }
    }
}
