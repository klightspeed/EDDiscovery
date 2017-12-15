﻿using BaseUtils.Win32Constants;
using EliteDangerousCore;
using EliteDangerousCore.CompanionAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDiscovery.Forms
{
    public partial class CommanderForm : ExtendedControls.DraggableForm
    {
        Font font;

        public CommanderForm()
        {
            InitializeComponent();
            EDDiscovery.EDDTheme theme = EDDiscovery.EDDTheme.Instance;
            font = new Font(theme.FontName, 10);
            bool winborder = theme.ApplyToForm(this, font);
            panelTop.Visible = panelTop.Enabled = !winborder;
        }

        private void CommanderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            font.Dispose();
            font = null;
        }

        public void Init(bool enablecmdredit)
        {
            textBoxBorderCmdr.Enabled = enablecmdredit;
            UpdateCAPIState();
        }

        public void Init(EDCommander cmdr, bool enablecmdredit)
        {
            textBoxBorderCmdr.Text = cmdr.Name;
            textBoxBorderCmdr.Enabled = enablecmdredit;
            textBoxBorderJournal.Text = cmdr.JournalDir;
            textBoxBorderEDSMName.Text = cmdr.EdsmName;
            textBoxBorderEDSMAPI.Text = cmdr.APIKey;
            checkBoxCustomEDSMFrom.Checked = cmdr.SyncFromEdsm;
            checkBoxCustomEDSMTo.Checked = cmdr.SyncToEdsm;
            checkBoxCustomEDDNTo.Checked = cmdr.SyncToEddn;
            checkBoxEGOSync.Checked = cmdr.SyncToEGO;
            textBoxEGOName.Text = cmdr.EGOName;
            textBoxEGOAPI.Text = cmdr.EGOAPIKey;

            UpdateCAPIState();
        }

        public void Update(EDCommander cmdr)
        {
            cmdr.Name = textBoxBorderCmdr.Text;
            cmdr.JournalDir = textBoxBorderJournal.Text;
            cmdr.EdsmName = textBoxBorderEDSMName.Text;
            cmdr.APIKey = textBoxBorderEDSMAPI.Text;
            cmdr.SyncFromEdsm = checkBoxCustomEDSMFrom.Checked;
            cmdr.SyncToEdsm = checkBoxCustomEDSMTo.Checked;
            cmdr.SyncToEddn = checkBoxCustomEDDNTo.Checked;
            cmdr.SyncToEGO = checkBoxEGOSync.Checked;
            cmdr.EGOName = textBoxEGOName.Text;
            cmdr.EGOAPIKey = textBoxEGOAPI.Text;
        }

        public bool Valid { get { return textBoxBorderCmdr.Text != ""; } }
        public string CommanderName { get { return textBoxBorderCmdr.Text; } }

        void UpdateCAPIState()
        {
            buttonExtCAPI.Text = Properties.Strings.Commander_CompanionLogin_Submit_Login;           // default state.. information needed.
            labelCAPIState.Text = Properties.Strings.Commander_CompanionLogin_State_NoCreds;
            labelCAPILogin.Text = Properties.Strings.Commander_CompanionLogin_Username;
            textBoxBorderCompanionLogin.Visible = textBoxBorderCompanionPassword.Visible = labelCAPILogin.Visible = labelCAPIPassword.Visible = true;
            toolTip1.SetToolTip(textBoxBorderCompanionLogin, Properties.Strings.Commander_CompanionLogin_Username_ToolTip);
            buttonExtCAPI.Enabled = false;
            checkBoxCAPIEnable.Visible = false;

            if (textBoxBorderCmdr.Text.Length > 0)
            {
                bool isdisabled;
                CompanionCredentials.State s = CompanionCredentials.CredentialState(textBoxBorderCmdr.Text, out isdisabled);

                if (s == CompanionCredentials.State.CONFIRMED)
                {
                    labelCAPIState.Text = Properties.Strings.Commander_CompanionLogin_State_Confirmed;
                    textBoxBorderCompanionLogin.Visible = labelCAPILogin.Visible = 
                    textBoxBorderCompanionPassword.Visible = labelCAPIPassword.Visible = false;
                    textBoxBorderCompanionLogin.Text = textBoxBorderCompanionPassword.Text = "";
                    buttonExtCAPI.Text = Properties.Strings.Commander_CompanionLogin_Submit_Clear;
                    buttonExtCAPI.Enabled = true;
                    checkBoxCAPIEnable.Location = labelCAPILogin.Location;
                    checkBoxCAPIEnable.Visible = true;
                    checkBoxCAPIEnable.Checked = !isdisabled;
                }
                else if (s == CompanionCredentials.State.NEEDS_CONFIRMATION)
                {
                    labelCAPIState.Text = Properties.Strings.Commander_CompanionLogin_State_NeedConfirmation;
                    labelCAPILogin.Text = Properties.Strings.Commander_CompanionLogin_ConfirmCode;
                    textBoxBorderCompanionPassword.Visible = labelCAPIPassword.Visible = false;
                    textBoxBorderCompanionLogin.Text = textBoxBorderCompanionPassword.Text = "";
                    buttonExtCAPI.Text = Properties.Strings.Commander_CompanionLogin_Submit_Clear;           // default state is clear/abort
                    buttonExtCAPI.Enabled = true;
                    toolTip1.SetToolTip(textBoxBorderCompanionLogin, Properties.Strings.Commander_CompanionLogin_ConfirmCode_ToolTip);

                    if ( capi.NeedLogin )
                    {
                        try
                        {
                            capi.LoginAs(textBoxBorderCmdr.Text);
                        }
                        catch ( Exception ex)
                        {
                            ExtendedControls.MessageBoxTheme.Show(this, Properties.Strings.Commander_CompanionLogin_LoginFailed + Environment.NewLine + ex.Message, Properties.Strings.Commander_CompanionLogin_LoginFailed_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        CompanionAPIClass capi = new CompanionAPIClass();

        private void buttonExtCAPI_Click(object sender, EventArgs e)
        {
            CompanionCredentials.State s = CompanionCredentials.State.NO_CREDENTIALS;

            if (textBoxBorderCmdr.Text.Length > 0)
            {
                bool isdisabled;
                s = CompanionCredentials.CredentialState(textBoxBorderCmdr.Text, out isdisabled);
            }

            if (s == CompanionCredentials.State.NO_CREDENTIALS && textBoxBorderCompanionPassword.Visible)
            {
                try
                {
                    capi.LoginAs(textBoxBorderCmdr.Text, textBoxBorderCompanionLogin.Text.Trim(), textBoxBorderCompanionPassword.Text.Trim());
                }
                catch (Exception ex)
                {
                    ExtendedControls.MessageBoxTheme.Show(this, Properties.Strings.Commander_CompanionLogin_LoginFailed + Environment.NewLine + ex.Message, Properties.Strings.Commander_CompanionLogin_LoginFailed_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (s == CompanionCredentials.State.CONFIRMED || textBoxBorderCmdr.Text.Length == 0)
            {
                if (ExtendedControls.MessageBoxTheme.Show(this, Properties.Strings.Commander_CompanionLogin_ConfirmClear, Properties.Strings.Commander_CompanionLogin_ConfirmClear_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    capi.Logout();
                    CompanionCredentials.DeleteCredentials(textBoxBorderCmdr.Text);
                }
            }
            else
            {
                try
                {
                    capi.Confirm(textBoxBorderCompanionLogin.Text.Trim());
                }
                catch (Exception ex)
                {
                    ExtendedControls.MessageBoxTheme.Show(this, Properties.Strings.Commander_CompanionLogin_ConfirmFailed + Environment.NewLine + ex.Message, Properties.Strings.Commander_CompanionLogin_ConfirmFailed_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            UpdateCAPIState();
        }


        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBoxBorderCompanionLogin.Text.Length>0 || textBoxBorderCompanionPassword.Text.Length>0)
            {
                if (ExtendedControls.MessageBoxTheme.Show(this, Properties.Strings.Commander_CompanionLogin_ConfirmAbandon, Properties.Strings.Commander_CompanionLogin_ConfirmAbandon_Title, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void checkBoxCAPIEnable_CheckedChanged(object sender, EventArgs e)
        {
            CompanionCredentials.SetDisabled(textBoxBorderCmdr.Text, !checkBoxCAPIEnable.Checked);      // rewrites the file with the disabled state
        }

        #region Window Control

        private void label_index_MouseDown(object sender, MouseEventArgs e)
        {
            OnCaptionMouseDown((Control)sender, e);
        }

        private void panel_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        private void textBoxBorderCompanionLogin_TextChanged(object sender, EventArgs e)
        {
            if (textBoxBorderCompanionLogin.Visible)
            {
                if (textBoxBorderCompanionPassword.Visible)     // Login..
                    buttonExtCAPI.Enabled = (textBoxBorderCompanionLogin.Text.Length > 0 && textBoxBorderCompanionPassword.Text.Length > 0);
                else
                    buttonExtCAPI.Text = textBoxBorderCompanionLogin.Text.Length > 0 ? Properties.Strings.Commander_CompanionLogin_Submit_Confirm : Properties.Strings.Commander_CompanionLogin_Submit_Clear;           // single enabled, in confirm, set to confirm if text, else clear
            }
        }

        private void textBoxBorderCompanionPassword_TextChanged(object sender, EventArgs e)
        {
            textBoxBorderCompanionLogin_TextChanged(sender, e);

        }

        private void buttonExtBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = Properties.Strings.Commander_JournalDir_Desc;

            if (fbd.ShowDialog(this) == DialogResult.OK)
                textBoxBorderJournal.Text = fbd.SelectedPath;

        }

    }
}
