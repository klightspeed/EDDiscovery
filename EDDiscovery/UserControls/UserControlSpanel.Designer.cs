/*
 * Copyright © 2016 - 2017 EDDiscovery development team
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
namespace EDDiscovery.UserControls
{
    partial class UserControlSpanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlSpanel));
            this.pictureBox = new ExtendedControls.PictureBoxHotspot();
            this.contextMenuStripConfig = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showSystemInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHabitationMinimumAndMaximumDistanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTargetLine = new System.Windows.Forms.ToolStripMenuItem();
            this.EDSMButtonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTime = new System.Windows.Forms.ToolStripMenuItem();
            this.iconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDescriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showNotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showXYZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackBoxAroundTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDistancesOnFSDJumpsOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandTextOverEmptyColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dontShowInformationWhenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showNothingWhenDockedtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dontshowwhenInGalaxyPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dontshowwhenInSystemMapPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OrdertoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderNotesAfterXYZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderTargetDistanceXYZNotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureEventFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureFieldFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.surfaceScanDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanNoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scan15sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scan30sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scan60sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanUntilNextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanRightMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanLeftMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanAboveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanBelowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanOnTopMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonExt0 = new ExtendedControls.ButtonExt();
            this.buttonExt1 = new ExtendedControls.ButtonExt();
            this.buttonExt2 = new ExtendedControls.ButtonExt();
            this.buttonExt3 = new ExtendedControls.ButtonExt();
            this.buttonExt4 = new ExtendedControls.ButtonExt();
            this.buttonExt5 = new ExtendedControls.ButtonExt();
            this.buttonExt6 = new ExtendedControls.ButtonExt();
            this.buttonExt7 = new ExtendedControls.ButtonExt();
            this.buttonExt8 = new ExtendedControls.ButtonExt();
            this.buttonExt9 = new ExtendedControls.ButtonExt();
            this.buttonExt10 = new ExtendedControls.ButtonExt();
            this.buttonExt11 = new ExtendedControls.ButtonExt();
            this.buttonExt12 = new ExtendedControls.ButtonExt();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.contextMenuStripConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(892, 680);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.ClickElement += new ExtendedControls.PictureBoxHotspot.OnElement(this.pictureBox_ClickElement);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // contextMenuStripConfig
            // 
            this.contextMenuStripConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showSystemInformationToolStripMenuItem,
            this.showHabitationMinimumAndMaximumDistanceToolStripMenuItem,
            this.toolStripMenuItemTargetLine,
            this.EDSMButtonToolStripMenuItem,
            this.toolStripMenuItemTime,
            this.iconToolStripMenuItem,
            this.showDescriptionToolStripMenuItem,
            this.showInformationToolStripMenuItem,
            this.showNotesToolStripMenuItem,
            this.showXYZToolStripMenuItem,
            this.showTargetToolStripMenuItem,
            this.blackBoxAroundTextToolStripMenuItem,
            this.showDistancesOnFSDJumpsOnlyToolStripMenuItem,
            this.expandTextOverEmptyColumnsToolStripMenuItem,
            this.dontShowInformationWhenToolStripMenuItem,
            this.OrdertoolStripMenuItem,
            this.configureEventFilterToolStripMenuItem,
            this.configureFieldFilterToolStripMenuItem,
            this.surfaceScanDetailsToolStripMenuItem,
            this.showInPositionToolStripMenuItem});
            this.contextMenuStripConfig.Name = "contextMenuStripConfig";
            this.contextMenuStripConfig.Size = new System.Drawing.Size(347, 466);
            // 
            // showSystemInformationToolStripMenuItem
            // 
            this.showSystemInformationToolStripMenuItem.Checked = true;
            this.showSystemInformationToolStripMenuItem.CheckOnClick = true;
            this.showSystemInformationToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showSystemInformationToolStripMenuItem.Name = "showSystemInformationToolStripMenuItem";
            this.showSystemInformationToolStripMenuItem.Size = new System.Drawing.Size(346, 22);
            this.showSystemInformationToolStripMenuItem.Text = Strings.Controls.SPanel_ShowSysInfo;
            this.showSystemInformationToolStripMenuItem.Click += new System.EventHandler(this.showSystemInformationToolStripMenuItem_Click);
            // 
            // showHabitationMinimumAndMaximumDistanceToolStripMenuItem
            // 
            this.showHabitationMinimumAndMaximumDistanceToolStripMenuItem.Checked = true;
            this.showHabitationMinimumAndMaximumDistanceToolStripMenuItem.CheckOnClick = true;
            this.showHabitationMinimumAndMaximumDistanceToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showHabitationMinimumAndMaximumDistanceToolStripMenuItem.Name = "showHabitationMinimumAndMaximumDistanceToolStripMenuItem";
            this.showHabitationMinimumAndMaximumDistanceToolStripMenuItem.Size = new System.Drawing.Size(346, 44);
            this.showHabitationMinimumAndMaximumDistanceToolStripMenuItem.Text = Strings.Controls.SPanel_ShowHabitZone;
            this.showHabitationMinimumAndMaximumDistanceToolStripMenuItem.Click += new System.EventHandler(this.showHabitationMinimumAndMaximumDistanceToolStripMenuItem_Click);
            // 
            // toolStripMenuItemTargetLine
            // 
            this.toolStripMenuItemTargetLine.Checked = true;
            this.toolStripMenuItemTargetLine.CheckOnClick = true;
            this.toolStripMenuItemTargetLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemTargetLine.Name = "toolStripMenuItemTargetLine";
            this.toolStripMenuItemTargetLine.Size = new System.Drawing.Size(346, 22);
            this.toolStripMenuItemTargetLine.Text = Strings.Controls.SPanel_ShowTargetLine;
            this.toolStripMenuItemTargetLine.Click += new System.EventHandler(this.toolStripMenuItemTargetLine_Click);
            // 
            // EDSMButtonToolStripMenuItem
            // 
            this.EDSMButtonToolStripMenuItem.Checked = true;
            this.EDSMButtonToolStripMenuItem.CheckOnClick = true;
            this.EDSMButtonToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EDSMButtonToolStripMenuItem.Name = "EDSMButtonToolStripMenuItem";
            this.EDSMButtonToolStripMenuItem.Size = new System.Drawing.Size(346, 22);
            this.EDSMButtonToolStripMenuItem.Text = Strings.Controls.SPanel_EDSM;
            this.EDSMButtonToolStripMenuItem.Click += new System.EventHandler(this.EDSMButtonToolStripMenuItem_Click);
            // 
            // toolStripMenuItemTime
            // 
            this.toolStripMenuItemTime.Checked = true;
            this.toolStripMenuItemTime.CheckOnClick = true;
            this.toolStripMenuItemTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemTime.Name = "toolStripMenuItemTime";
            this.toolStripMenuItemTime.Size = new System.Drawing.Size(346, 22);
            this.toolStripMenuItemTime.Text = Strings.Controls.SPanel_Time;
            this.toolStripMenuItemTime.Click += new System.EventHandler(this.toolStripMenuItemTime_Click);
            // 
            // iconToolStripMenuItem
            // 
            this.iconToolStripMenuItem.Checked = true;
            this.iconToolStripMenuItem.CheckOnClick = true;
            this.iconToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.iconToolStripMenuItem.Name = "iconToolStripMenuItem";
            this.iconToolStripMenuItem.Size = new System.Drawing.Size(346, 22);
            this.iconToolStripMenuItem.Text = Strings.Controls.SPanel_EventFilter;
            this.iconToolStripMenuItem.Click += new System.EventHandler(this.iconToolStripMenuItem_Click);
            // 
            // showDescriptionToolStripMenuItem
            // 
            this.showDescriptionToolStripMenuItem.Checked = true;
            this.showDescriptionToolStripMenuItem.CheckOnClick = true;
            this.showDescriptionToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showDescriptionToolStripMenuItem.Name = "showDescriptionToolStripMenuItem";
            this.showDescriptionToolStripMenuItem.Size = new System.Drawing.Size(346, 22);
            this.showDescriptionToolStripMenuItem.Text = Strings.Controls.SPanel_ShowDesc;
            this.showDescriptionToolStripMenuItem.Click += new System.EventHandler(this.showDescriptionToolStripMenuItem_Click);
            // 
            // showInformationToolStripMenuItem
            // 
            this.showInformationToolStripMenuItem.Checked = true;
            this.showInformationToolStripMenuItem.CheckOnClick = true;
            this.showInformationToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showInformationToolStripMenuItem.Name = "showInformationToolStripMenuItem";
            this.showInformationToolStripMenuItem.Size = new System.Drawing.Size(346, 22);
            this.showInformationToolStripMenuItem.Text = Strings.Controls.SPanel_ShowInfo;
            this.showInformationToolStripMenuItem.Click += new System.EventHandler(this.showInformationToolStripMenuItem_Click);
            // 
            // showNotesToolStripMenuItem
            // 
            this.showNotesToolStripMenuItem.Checked = true;
            this.showNotesToolStripMenuItem.CheckOnClick = true;
            this.showNotesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showNotesToolStripMenuItem.Name = "showNotesToolStripMenuItem";
            this.showNotesToolStripMenuItem.Size = new System.Drawing.Size(346, 22);
            this.showNotesToolStripMenuItem.Text = Strings.Controls.SPanel_ShowNotes;
            this.showNotesToolStripMenuItem.Click += new System.EventHandler(this.showNotesToolStripMenuItem_Click);
            // 
            // showXYZToolStripMenuItem
            // 
            this.showXYZToolStripMenuItem.Checked = true;
            this.showXYZToolStripMenuItem.CheckOnClick = true;
            this.showXYZToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showXYZToolStripMenuItem.Name = "showXYZToolStripMenuItem";
            this.showXYZToolStripMenuItem.Size = new System.Drawing.Size(346, 22);
            this.showXYZToolStripMenuItem.Text = Strings.Controls.SPanel_ShowXYZ;
            this.showXYZToolStripMenuItem.Click += new System.EventHandler(this.showXYZToolStripMenuItem_Click);
            // 
            // showTargetToolStripMenuItem
            // 
            this.showTargetToolStripMenuItem.Checked = true;
            this.showTargetToolStripMenuItem.CheckOnClick = true;
            this.showTargetToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showTargetToolStripMenuItem.Name = "showTargetToolStripMenuItem";
            this.showTargetToolStripMenuItem.Size = new System.Drawing.Size(346, 22);
            this.showTargetToolStripMenuItem.Text = Strings.Controls.SPanel_TargetDist;
            this.showTargetToolStripMenuItem.Click += new System.EventHandler(this.showTargetToolStripMenuItem_Click);
            // 
            // blackBoxAroundTextToolStripMenuItem
            // 
            this.blackBoxAroundTextToolStripMenuItem.Checked = true;
            this.blackBoxAroundTextToolStripMenuItem.CheckOnClick = true;
            this.blackBoxAroundTextToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.blackBoxAroundTextToolStripMenuItem.Name = "blackBoxAroundTextToolStripMenuItem";
            this.blackBoxAroundTextToolStripMenuItem.Size = new System.Drawing.Size(346, 22);
            this.blackBoxAroundTextToolStripMenuItem.Text = Strings.Controls.SPanel_BlackBorder;
            this.blackBoxAroundTextToolStripMenuItem.Click += new System.EventHandler(this.blackBoxAroundTextToolStripMenuItem_Click);
            // 
            // showDistancesOnFSDJumpsOnlyToolStripMenuItem
            // 
            this.showDistancesOnFSDJumpsOnlyToolStripMenuItem.Checked = true;
            this.showDistancesOnFSDJumpsOnlyToolStripMenuItem.CheckOnClick = true;
            this.showDistancesOnFSDJumpsOnlyToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showDistancesOnFSDJumpsOnlyToolStripMenuItem.Name = "showDistancesOnFSDJumpsOnlyToolStripMenuItem";
            this.showDistancesOnFSDJumpsOnlyToolStripMenuItem.Size = new System.Drawing.Size(346, 22);
            this.showDistancesOnFSDJumpsOnlyToolStripMenuItem.Text = Strings.Controls.SPanel_FSDCoords;
            this.showDistancesOnFSDJumpsOnlyToolStripMenuItem.Click += new System.EventHandler(this.showDistancesOnFSDJumpsOnlyToolStripMenuItem_Click);
            // 
            // expandTextOverEmptyColumnsToolStripMenuItem
            // 
            this.expandTextOverEmptyColumnsToolStripMenuItem.Checked = true;
            this.expandTextOverEmptyColumnsToolStripMenuItem.CheckOnClick = true;
            this.expandTextOverEmptyColumnsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.expandTextOverEmptyColumnsToolStripMenuItem.Name = "expandTextOverEmptyColumnsToolStripMenuItem";
            this.expandTextOverEmptyColumnsToolStripMenuItem.Size = new System.Drawing.Size(346, 22);
            this.expandTextOverEmptyColumnsToolStripMenuItem.Text = Strings.Controls.SPanel_ExpandText;
            this.expandTextOverEmptyColumnsToolStripMenuItem.Click += new System.EventHandler(this.expandTextOverEmptyColumnsToolStripMenuItem_Click);
            // 
            // dontShowInformationWhenToolStripMenuItem
            // 
            this.dontShowInformationWhenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showNothingWhenDockedtoolStripMenuItem,
            this.dontshowwhenInGalaxyPanelToolStripMenuItem,
            this.dontshowwhenInSystemMapPanelToolStripMenuItem});
            this.dontShowInformationWhenToolStripMenuItem.Name = "dontShowInformationWhenToolStripMenuItem";
            this.dontShowInformationWhenToolStripMenuItem.Size = new System.Drawing.Size(346, 22);
            this.dontShowInformationWhenToolStripMenuItem.Text = Strings.Controls.SPanel_DontShow_Menu;
            // 
            // showNothingWhenDockedtoolStripMenuItem
            // 
            this.showNothingWhenDockedtoolStripMenuItem.Checked = true;
            this.showNothingWhenDockedtoolStripMenuItem.CheckOnClick = true;
            this.showNothingWhenDockedtoolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showNothingWhenDockedtoolStripMenuItem.Name = "showNothingWhenDockedtoolStripMenuItem";
            this.showNothingWhenDockedtoolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.showNothingWhenDockedtoolStripMenuItem.Text = Strings.Controls.SPanel_DontShow_Landed;
            this.showNothingWhenDockedtoolStripMenuItem.Click += new System.EventHandler(this.showNothingWhenDockedtoolStripMenuItem_Click);
            // 
            // dontshowwhenInGalaxyPanelToolStripMenuItem
            // 
            this.dontshowwhenInGalaxyPanelToolStripMenuItem.Checked = true;
            this.dontshowwhenInGalaxyPanelToolStripMenuItem.CheckOnClick = true;
            this.dontshowwhenInGalaxyPanelToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dontshowwhenInGalaxyPanelToolStripMenuItem.Name = "dontshowwhenInGalaxyPanelToolStripMenuItem";
            this.dontshowwhenInGalaxyPanelToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.dontshowwhenInGalaxyPanelToolStripMenuItem.Text = Strings.Controls.SPanel_DontShow_GalMap;
            this.dontshowwhenInGalaxyPanelToolStripMenuItem.Click += new System.EventHandler(this.dontshowwhenInGalaxyPanelToolStripMenuItem_Click);
            // 
            // dontshowwhenInSystemMapPanelToolStripMenuItem
            // 
            this.dontshowwhenInSystemMapPanelToolStripMenuItem.Checked = true;
            this.dontshowwhenInSystemMapPanelToolStripMenuItem.CheckOnClick = true;
            this.dontshowwhenInSystemMapPanelToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dontshowwhenInSystemMapPanelToolStripMenuItem.Name = "dontshowwhenInSystemMapPanelToolStripMenuItem";
            this.dontshowwhenInSystemMapPanelToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.dontshowwhenInSystemMapPanelToolStripMenuItem.Text = Strings.Controls.SPanel_DontShow_SysMap;
            this.dontshowwhenInSystemMapPanelToolStripMenuItem.Click += new System.EventHandler(this.dontshowwhenInSystemPanelToolStripMenuItem_Click);
            // 
            // OrdertoolStripMenuItem
            // 
            this.OrdertoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orderDefaultToolStripMenuItem,
            this.orderNotesAfterXYZToolStripMenuItem,
            this.orderTargetDistanceXYZNotesToolStripMenuItem});
            this.OrdertoolStripMenuItem.Name = "OrdertoolStripMenuItem";
            this.OrdertoolStripMenuItem.Size = new System.Drawing.Size(346, 22);
            this.OrdertoolStripMenuItem.Text = Strings.Controls.SPanel_ColumnOrder_Menu;
            // 
            // orderDefaultToolStripMenuItem
            // 
            this.orderDefaultToolStripMenuItem.Name = "orderDefaultToolStripMenuItem";
            this.orderDefaultToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.orderDefaultToolStripMenuItem.Text = Strings.Controls.SPanel_ColumnOrder_Default;
            this.orderDefaultToolStripMenuItem.Click += new System.EventHandler(this.defaultToolStripMenuItem_Click);
            // 
            // orderNotesAfterXYZToolStripMenuItem
            // 
            this.orderNotesAfterXYZToolStripMenuItem.Name = "orderNotesAfterXYZToolStripMenuItem";
            this.orderNotesAfterXYZToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.orderNotesAfterXYZToolStripMenuItem.Text = Strings.Controls.SPanel_ColumnOrder_NotesAfterCoords;
            this.orderNotesAfterXYZToolStripMenuItem.Click += new System.EventHandler(this.notesAfterXYZToolStripMenuItem_Click);
            // 
            // orderTargetDistanceXYZNotesToolStripMenuItem
            // 
            this.orderTargetDistanceXYZNotesToolStripMenuItem.Name = "orderTargetDistanceXYZNotesToolStripMenuItem";
            this.orderTargetDistanceXYZNotesToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.orderTargetDistanceXYZNotesToolStripMenuItem.Text = Strings.Controls.SPanel_ColumnOrder_DistCoordNotes;
            this.orderTargetDistanceXYZNotesToolStripMenuItem.Click += new System.EventHandler(this.targetDistanceXYZNotesToolStripMenuItem_Click);
            // 
            // configureEventFilterToolStripMenuItem
            // 
            this.configureEventFilterToolStripMenuItem.Name = "configureEventFilterToolStripMenuItem";
            this.configureEventFilterToolStripMenuItem.Size = new System.Drawing.Size(346, 22);
            this.configureEventFilterToolStripMenuItem.Text = Strings.Controls.SPanel_EventFilter;
            this.configureEventFilterToolStripMenuItem.Click += new System.EventHandler(this.configureEventFilterToolStripMenuItem_Click);
            // 
            // configureFieldFilterToolStripMenuItem
            // 
            this.configureFieldFilterToolStripMenuItem.Name = "configureFieldFilterToolStripMenuItem";
            this.configureFieldFilterToolStripMenuItem.Size = new System.Drawing.Size(346, 22);
            this.configureFieldFilterToolStripMenuItem.Text = Strings.Controls.SPanel_FieldFilter;
            this.configureFieldFilterToolStripMenuItem.Click += new System.EventHandler(this.configureFieldFilterToolStripMenuItem_Click);
            // 
            // surfaceScanDetailsToolStripMenuItem
            // 
            this.surfaceScanDetailsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scanNoToolStripMenuItem,
            this.scan15sToolStripMenuItem,
            this.scan30sToolStripMenuItem,
            this.scan60sToolStripMenuItem,
            this.scanUntilNextToolStripMenuItem});
            this.surfaceScanDetailsToolStripMenuItem.Name = "surfaceScanDetailsToolStripMenuItem";
            this.surfaceScanDetailsToolStripMenuItem.Size = new System.Drawing.Size(346, 22);
            this.surfaceScanDetailsToolStripMenuItem.Text = Strings.Controls.SPanel_ScanDisplay_Menu;
            // 
            // scanNoToolStripMenuItem
            // 
            this.scanNoToolStripMenuItem.Checked = true;
            this.scanNoToolStripMenuItem.CheckOnClick = true;
            this.scanNoToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.scanNoToolStripMenuItem.Name = "scanNoToolStripMenuItem";
            this.scanNoToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.scanNoToolStripMenuItem.Text = Strings.Controls.SPanel_ScanDisplay_DontShow;
            this.scanNoToolStripMenuItem.Click += new System.EventHandler(this.scanNoToolStripMenuItem_Click);
            // 
            // scan15sToolStripMenuItem
            // 
            this.scan15sToolStripMenuItem.CheckOnClick = true;
            this.scan15sToolStripMenuItem.Name = "scan15sToolStripMenuItem";
            this.scan15sToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.scan15sToolStripMenuItem.Text = Strings.Controls.SPanel_ScanDisplay_15s;
            this.scan15sToolStripMenuItem.Click += new System.EventHandler(this.scan15sToolStripMenuItem_Click);
            // 
            // scan30sToolStripMenuItem
            // 
            this.scan30sToolStripMenuItem.CheckOnClick = true;
            this.scan30sToolStripMenuItem.Name = "scan30sToolStripMenuItem";
            this.scan30sToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.scan30sToolStripMenuItem.Text = Strings.Controls.SPanel_ScanDisplay_30s;
            this.scan30sToolStripMenuItem.Click += new System.EventHandler(this.scan30sToolStripMenuItem_Click);
            // 
            // scan60sToolStripMenuItem
            // 
            this.scan60sToolStripMenuItem.CheckOnClick = true;
            this.scan60sToolStripMenuItem.Name = "scan60sToolStripMenuItem";
            this.scan60sToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.scan60sToolStripMenuItem.Text = Strings.Controls.SPanel_ScanDisplay_60s;
            this.scan60sToolStripMenuItem.Click += new System.EventHandler(this.scan60sToolStripMenuItem_Click);
            // 
            // scanUntilNextToolStripMenuItem
            // 
            this.scanUntilNextToolStripMenuItem.CheckOnClick = true;
            this.scanUntilNextToolStripMenuItem.Name = "scanUntilNextToolStripMenuItem";
            this.scanUntilNextToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.scanUntilNextToolStripMenuItem.Text = Strings.Controls.SPanel_ScanDisplay_UntilNext;
            this.scanUntilNextToolStripMenuItem.Click += new System.EventHandler(this.scanUntilNextToolStripMenuItem_Click);
            // 
            // showInPositionToolStripMenuItem
            // 
            this.showInPositionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scanRightMenuItem,
            this.scanLeftMenuItem,
            this.scanAboveMenuItem,
            this.scanBelowMenuItem,
            this.scanOnTopMenuItem});
            this.showInPositionToolStripMenuItem.Name = "showInPositionToolStripMenuItem";
            this.showInPositionToolStripMenuItem.Size = new System.Drawing.Size(346, 22);
            this.showInPositionToolStripMenuItem.Text = Strings.Controls.SPanel_ScanPosition_Menu;
            // 
            // scanRightMenuItem
            // 
            this.scanRightMenuItem.Name = "scanRightMenuItem";
            this.scanRightMenuItem.Size = new System.Drawing.Size(115, 22);
            this.scanRightMenuItem.Text = Strings.Controls.SPanel_ScanPosition_ToRight;
            this.scanRightMenuItem.Click += new System.EventHandler(this.scanRightMenuItem_Click);
            // 
            // scanLeftMenuItem
            // 
            this.scanLeftMenuItem.Name = "scanLeftMenuItem";
            this.scanLeftMenuItem.Size = new System.Drawing.Size(115, 22);
            this.scanLeftMenuItem.Text = Strings.Controls.SPanel_ScanPosition_ToLeft;
            this.scanLeftMenuItem.Click += new System.EventHandler(this.scanLeftMenuItem_Click);
            // 
            // scanAboveMenuItem
            // 
            this.scanAboveMenuItem.DoubleClickEnabled = true;
            this.scanAboveMenuItem.Name = "scanAboveMenuItem";
            this.scanAboveMenuItem.Size = new System.Drawing.Size(115, 22);
            this.scanAboveMenuItem.Text = Strings.Controls.SPanel_ScanPosition_Above;
            this.scanAboveMenuItem.Click += new System.EventHandler(this.scanAboveMenuItem_Click);
            // 
            // scanBelowMenuItem
            // 
            this.scanBelowMenuItem.Name = "scanBelowMenuItem";
            this.scanBelowMenuItem.Size = new System.Drawing.Size(115, 22);
            this.scanBelowMenuItem.Text = Strings.Controls.SPanel_ScanPosition_Below;
            this.scanBelowMenuItem.Click += new System.EventHandler(this.scanBelowMenuItem_Click);
            // 
            // scanOnTopMenuItem
            // 
            this.scanOnTopMenuItem.Name = "scanOnTopMenuItem";
            this.scanOnTopMenuItem.Size = new System.Drawing.Size(115, 22);
            this.scanOnTopMenuItem.Text = Strings.Controls.SPanel_ScanPosition_OnTop;
            this.scanOnTopMenuItem.Click += new System.EventHandler(this.scanOnTopMenuItem_Click);
            // 
            // buttonExt0
            // 
            this.buttonExt0.BackColor = System.Drawing.Color.Transparent;
            this.buttonExt0.BorderColorScaling = 1.25F;
            this.buttonExt0.ButtonColorScaling = 0.5F;
            this.buttonExt0.ButtonDisabledScaling = 0.5F;
            this.buttonExt0.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonExt0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonExt0.Image = global::EDDiscovery.Icons.Controls.SPanel_ResizeColumn;
            this.buttonExt0.Location = new System.Drawing.Point(17, 26);
            this.buttonExt0.Name = "buttonExt0";
            this.buttonExt0.Size = new System.Drawing.Size(24, 24);
            this.buttonExt0.TabIndex = 1;
            this.buttonExt0.Tag = "0";
            this.buttonExt0.UseVisualStyleBackColor = false;
            this.buttonExt0.Visible = false;
            this.buttonExt0.MouseDown += new System.Windows.Forms.MouseEventHandler(this.divider_MouseDown);
            this.buttonExt0.MouseMove += new System.Windows.Forms.MouseEventHandler(this.divider_MouseMove);
            this.buttonExt0.MouseUp += new System.Windows.Forms.MouseEventHandler(this.divider_MouseUp);
            // 
            // buttonExt1
            // 
            this.buttonExt1.BackColor = System.Drawing.Color.Transparent;
            this.buttonExt1.BorderColorScaling = 1.25F;
            this.buttonExt1.ButtonColorScaling = 0.5F;
            this.buttonExt1.ButtonDisabledScaling = 0.5F;
            this.buttonExt1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonExt1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonExt1.Image = global::EDDiscovery.Icons.Controls.SPanel_ResizeColumn;
            this.buttonExt1.Location = new System.Drawing.Point(43, 48);
            this.buttonExt1.Name = "buttonExt1";
            this.buttonExt1.Size = new System.Drawing.Size(24, 24);
            this.buttonExt1.TabIndex = 1;
            this.buttonExt1.Tag = "1";
            this.buttonExt1.UseVisualStyleBackColor = false;
            this.buttonExt1.Visible = false;
            this.buttonExt1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.divider_MouseDown);
            this.buttonExt1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.divider_MouseMove);
            this.buttonExt1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.divider_MouseUp);
            // 
            // buttonExt2
            // 
            this.buttonExt2.BackColor = System.Drawing.Color.Transparent;
            this.buttonExt2.BorderColorScaling = 1.25F;
            this.buttonExt2.ButtonColorScaling = 0.5F;
            this.buttonExt2.ButtonDisabledScaling = 0.5F;
            this.buttonExt2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonExt2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonExt2.Image = global::EDDiscovery.Icons.Controls.SPanel_ResizeColumn;
            this.buttonExt2.Location = new System.Drawing.Point(69, 70);
            this.buttonExt2.Name = "buttonExt2";
            this.buttonExt2.Size = new System.Drawing.Size(24, 24);
            this.buttonExt2.TabIndex = 1;
            this.buttonExt2.Tag = "2";
            this.buttonExt2.UseVisualStyleBackColor = false;
            this.buttonExt2.Visible = false;
            this.buttonExt2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.divider_MouseDown);
            this.buttonExt2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.divider_MouseMove);
            this.buttonExt2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.divider_MouseUp);
            // 
            // buttonExt3
            // 
            this.buttonExt3.BackColor = System.Drawing.Color.Transparent;
            this.buttonExt3.BorderColorScaling = 1.25F;
            this.buttonExt3.ButtonColorScaling = 0.5F;
            this.buttonExt3.ButtonDisabledScaling = 0.5F;
            this.buttonExt3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonExt3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonExt3.Image = global::EDDiscovery.Icons.Controls.SPanel_ResizeColumn;
            this.buttonExt3.Location = new System.Drawing.Point(95, 92);
            this.buttonExt3.Name = "buttonExt3";
            this.buttonExt3.Size = new System.Drawing.Size(24, 24);
            this.buttonExt3.TabIndex = 1;
            this.buttonExt3.Tag = "3";
            this.buttonExt3.UseVisualStyleBackColor = false;
            this.buttonExt3.Visible = false;
            this.buttonExt3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.divider_MouseDown);
            this.buttonExt3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.divider_MouseMove);
            this.buttonExt3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.divider_MouseUp);
            // 
            // buttonExt4
            // 
            this.buttonExt4.BackColor = System.Drawing.Color.Transparent;
            this.buttonExt4.BorderColorScaling = 1.25F;
            this.buttonExt4.ButtonColorScaling = 0.5F;
            this.buttonExt4.ButtonDisabledScaling = 0.5F;
            this.buttonExt4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonExt4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonExt4.Image = global::EDDiscovery.Icons.Controls.SPanel_ResizeColumn;
            this.buttonExt4.Location = new System.Drawing.Point(121, 122);
            this.buttonExt4.Name = "buttonExt4";
            this.buttonExt4.Size = new System.Drawing.Size(24, 24);
            this.buttonExt4.TabIndex = 1;
            this.buttonExt4.Tag = "4";
            this.buttonExt4.UseVisualStyleBackColor = false;
            this.buttonExt4.Visible = false;
            this.buttonExt4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.divider_MouseDown);
            this.buttonExt4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.divider_MouseMove);
            this.buttonExt4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.divider_MouseUp);
            // 
            // buttonExt5
            // 
            this.buttonExt5.BackColor = System.Drawing.Color.Transparent;
            this.buttonExt5.BorderColorScaling = 1.25F;
            this.buttonExt5.ButtonColorScaling = 0.5F;
            this.buttonExt5.ButtonDisabledScaling = 0.5F;
            this.buttonExt5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonExt5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonExt5.Image = global::EDDiscovery.Icons.Controls.SPanel_ResizeColumn;
            this.buttonExt5.Location = new System.Drawing.Point(147, 144);
            this.buttonExt5.Name = "buttonExt5";
            this.buttonExt5.Size = new System.Drawing.Size(24, 24);
            this.buttonExt5.TabIndex = 1;
            this.buttonExt5.Tag = "5";
            this.buttonExt5.UseVisualStyleBackColor = false;
            this.buttonExt5.Visible = false;
            this.buttonExt5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.divider_MouseDown);
            this.buttonExt5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.divider_MouseMove);
            this.buttonExt5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.divider_MouseUp);
            // 
            // buttonExt6
            // 
            this.buttonExt6.BackColor = System.Drawing.Color.Transparent;
            this.buttonExt6.BorderColorScaling = 1.25F;
            this.buttonExt6.ButtonColorScaling = 0.5F;
            this.buttonExt6.ButtonDisabledScaling = 0.5F;
            this.buttonExt6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonExt6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonExt6.Image = global::EDDiscovery.Icons.Controls.SPanel_ResizeColumn;
            this.buttonExt6.Location = new System.Drawing.Point(121, 172);
            this.buttonExt6.Name = "buttonExt6";
            this.buttonExt6.Size = new System.Drawing.Size(24, 24);
            this.buttonExt6.TabIndex = 1;
            this.buttonExt6.Tag = "6";
            this.buttonExt6.UseVisualStyleBackColor = false;
            this.buttonExt6.Visible = false;
            this.buttonExt6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.divider_MouseDown);
            this.buttonExt6.MouseMove += new System.Windows.Forms.MouseEventHandler(this.divider_MouseMove);
            this.buttonExt6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.divider_MouseUp);
            // 
            // buttonExt7
            // 
            this.buttonExt7.BackColor = System.Drawing.Color.Transparent;
            this.buttonExt7.BorderColorScaling = 1.25F;
            this.buttonExt7.ButtonColorScaling = 0.5F;
            this.buttonExt7.ButtonDisabledScaling = 0.5F;
            this.buttonExt7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonExt7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonExt7.Image = global::EDDiscovery.Icons.Controls.SPanel_ResizeColumn;
            this.buttonExt7.Location = new System.Drawing.Point(95, 196);
            this.buttonExt7.Name = "buttonExt7";
            this.buttonExt7.Size = new System.Drawing.Size(24, 24);
            this.buttonExt7.TabIndex = 1;
            this.buttonExt7.Tag = "7";
            this.buttonExt7.UseVisualStyleBackColor = false;
            this.buttonExt7.Visible = false;
            this.buttonExt7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.divider_MouseDown);
            this.buttonExt7.MouseMove += new System.Windows.Forms.MouseEventHandler(this.divider_MouseMove);
            this.buttonExt7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.divider_MouseUp);
            // 
            // buttonExt8
            // 
            this.buttonExt8.BackColor = System.Drawing.Color.Transparent;
            this.buttonExt8.BorderColorScaling = 1.25F;
            this.buttonExt8.ButtonColorScaling = 0.5F;
            this.buttonExt8.ButtonDisabledScaling = 0.5F;
            this.buttonExt8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonExt8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonExt8.Image = global::EDDiscovery.Icons.Controls.SPanel_ResizeColumn;
            this.buttonExt8.Location = new System.Drawing.Point(69, 226);
            this.buttonExt8.Name = "buttonExt8";
            this.buttonExt8.Size = new System.Drawing.Size(24, 24);
            this.buttonExt8.TabIndex = 1;
            this.buttonExt8.Tag = "8";
            this.buttonExt8.UseVisualStyleBackColor = false;
            this.buttonExt8.Visible = false;
            this.buttonExt8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.divider_MouseDown);
            this.buttonExt8.MouseMove += new System.Windows.Forms.MouseEventHandler(this.divider_MouseMove);
            this.buttonExt8.MouseUp += new System.Windows.Forms.MouseEventHandler(this.divider_MouseUp);
            // 
            // buttonExt9
            // 
            this.buttonExt9.BackColor = System.Drawing.Color.Transparent;
            this.buttonExt9.BorderColorScaling = 1.25F;
            this.buttonExt9.ButtonColorScaling = 0.5F;
            this.buttonExt9.ButtonDisabledScaling = 0.5F;
            this.buttonExt9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonExt9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonExt9.Image = global::EDDiscovery.Icons.Controls.SPanel_ResizeColumn;
            this.buttonExt9.Location = new System.Drawing.Point(43, 250);
            this.buttonExt9.Name = "buttonExt9";
            this.buttonExt9.Size = new System.Drawing.Size(24, 24);
            this.buttonExt9.TabIndex = 1;
            this.buttonExt9.Tag = "9";
            this.buttonExt9.UseVisualStyleBackColor = false;
            this.buttonExt9.Visible = false;
            this.buttonExt9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.divider_MouseDown);
            this.buttonExt9.MouseMove += new System.Windows.Forms.MouseEventHandler(this.divider_MouseMove);
            this.buttonExt9.MouseUp += new System.Windows.Forms.MouseEventHandler(this.divider_MouseUp);
            // 
            // buttonExt10
            // 
            this.buttonExt10.BackColor = System.Drawing.Color.Transparent;
            this.buttonExt10.BorderColorScaling = 1.25F;
            this.buttonExt10.ButtonColorScaling = 0.5F;
            this.buttonExt10.ButtonDisabledScaling = 0.5F;
            this.buttonExt10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonExt10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonExt10.Image = global::EDDiscovery.Icons.Controls.SPanel_ResizeColumn;
            this.buttonExt10.Location = new System.Drawing.Point(17, 272);
            this.buttonExt10.Name = "buttonExt10";
            this.buttonExt10.Size = new System.Drawing.Size(24, 24);
            this.buttonExt10.TabIndex = 1;
            this.buttonExt10.Tag = "10";
            this.buttonExt10.UseVisualStyleBackColor = false;
            this.buttonExt10.Visible = false;
            this.buttonExt10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.divider_MouseDown);
            this.buttonExt10.MouseMove += new System.Windows.Forms.MouseEventHandler(this.divider_MouseMove);
            this.buttonExt10.MouseUp += new System.Windows.Forms.MouseEventHandler(this.divider_MouseUp);
            // 
            // buttonExt11
            // 
            this.buttonExt11.BackColor = System.Drawing.Color.Transparent;
            this.buttonExt11.BorderColorScaling = 1.25F;
            this.buttonExt11.ButtonColorScaling = 0.5F;
            this.buttonExt11.ButtonDisabledScaling = 0.5F;
            this.buttonExt11.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonExt11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonExt11.Image = global::EDDiscovery.Icons.Controls.SPanel_ResizeColumn;
            this.buttonExt11.Location = new System.Drawing.Point(43, 302);
            this.buttonExt11.Name = "buttonExt11";
            this.buttonExt11.Size = new System.Drawing.Size(24, 24);
            this.buttonExt11.TabIndex = 1;
            this.buttonExt11.Tag = "10";
            this.buttonExt11.UseVisualStyleBackColor = false;
            this.buttonExt11.Visible = false;
            this.buttonExt11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.divider_MouseDown);
            this.buttonExt11.MouseMove += new System.Windows.Forms.MouseEventHandler(this.divider_MouseMove);
            this.buttonExt11.MouseUp += new System.Windows.Forms.MouseEventHandler(this.divider_MouseUp);
            // 
            // buttonExt12
            // 
            this.buttonExt12.BackColor = System.Drawing.Color.Transparent;
            this.buttonExt12.BorderColorScaling = 1.25F;
            this.buttonExt12.ButtonColorScaling = 0.5F;
            this.buttonExt12.ButtonDisabledScaling = 0.5F;
            this.buttonExt12.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonExt12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonExt12.Image = global::EDDiscovery.Icons.Controls.SPanel_ResizeColumn;
            this.buttonExt12.Location = new System.Drawing.Point(69, 330);
            this.buttonExt12.Name = "buttonExt12";
            this.buttonExt12.Size = new System.Drawing.Size(24, 24);
            this.buttonExt12.TabIndex = 1;
            this.buttonExt12.Tag = "10";
            this.buttonExt12.UseVisualStyleBackColor = false;
            this.buttonExt12.Visible = false;
            this.buttonExt12.MouseDown += new System.Windows.Forms.MouseEventHandler(this.divider_MouseDown);
            this.buttonExt12.MouseMove += new System.Windows.Forms.MouseEventHandler(this.divider_MouseMove);
            this.buttonExt12.MouseUp += new System.Windows.Forms.MouseEventHandler(this.divider_MouseUp);
            // 
            // UserControlSpanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonExt12);
            this.Controls.Add(this.buttonExt11);
            this.Controls.Add(this.buttonExt10);
            this.Controls.Add(this.buttonExt9);
            this.Controls.Add(this.buttonExt8);
            this.Controls.Add(this.buttonExt7);
            this.Controls.Add(this.buttonExt6);
            this.Controls.Add(this.buttonExt5);
            this.Controls.Add(this.buttonExt4);
            this.Controls.Add(this.buttonExt3);
            this.Controls.Add(this.buttonExt2);
            this.Controls.Add(this.buttonExt1);
            this.Controls.Add(this.buttonExt0);
            this.Controls.Add(this.pictureBox);
            this.Name = "UserControlSpanel";
            this.Size = new System.Drawing.Size(892, 680);
            this.Resize += new System.EventHandler(this.UserControlSpanel_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.contextMenuStripConfig.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ExtendedControls.PictureBoxHotspot pictureBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripConfig;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTargetLine;
        private System.Windows.Forms.ToolStripMenuItem EDSMButtonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTime;
        private System.Windows.Forms.ToolStripMenuItem showDescriptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showNotesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showXYZToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showTargetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackBoxAroundTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDistancesOnFSDJumpsOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expandTextOverEmptyColumnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem surfaceScanDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanNoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scan15sToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scan30sToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scan60sToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanUntilNextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanRightMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanLeftMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanAboveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanBelowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanOnTopMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OrdertoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderDefaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderNotesAfterXYZToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderTargetDistanceXYZNotesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureEventFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureFieldFilterToolStripMenuItem;
        private ExtendedControls.ButtonExt buttonExt0;
        private ExtendedControls.ButtonExt buttonExt1;
        private ExtendedControls.ButtonExt buttonExt2;
        private ExtendedControls.ButtonExt buttonExt3;
        private ExtendedControls.ButtonExt buttonExt4;
        private ExtendedControls.ButtonExt buttonExt5;
        private ExtendedControls.ButtonExt buttonExt6;
        private ExtendedControls.ButtonExt buttonExt7;
        private ExtendedControls.ButtonExt buttonExt8;
        private ExtendedControls.ButtonExt buttonExt9;
        private ExtendedControls.ButtonExt buttonExt10;
        private ExtendedControls.ButtonExt buttonExt11;
        private ExtendedControls.ButtonExt buttonExt12;
        private System.Windows.Forms.ToolStripMenuItem iconToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showSystemInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showHabitationMinimumAndMaximumDistanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dontShowInformationWhenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showNothingWhenDockedtoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dontshowwhenInGalaxyPanelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dontshowwhenInSystemMapPanelToolStripMenuItem;
    }
}
