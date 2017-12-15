/*
 * Copyright © 2015 - 2017 EDDiscovery development team
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;

namespace EDDiscovery
{
        partial class FormMap
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

            #region Windows Form Designer generated code

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
            this.components = new System.ComponentModel.Container();
            this.glControlContainer = new System.Windows.Forms.Panel();
            this.textboxFrom = new ExtendedControls.AutoCompleteTextBox();
            this.labelSystemCoords = new System.Windows.Forms.Label();
            this.toolStripShowAllStars = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonGoBackward = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonGoForward = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLastKnownPosition = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAutoForward = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonHome = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonHistory = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTarget = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButtonVisitedStars = new System.Windows.Forms.ToolStripDropDownButton();
            this.drawLinesBetweenStarsWithPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawADiscOnStarsWithPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useWhiteForDiscsInsteadOfAssignedMapColourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButtonFilterStars = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.showStarstoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showStationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableColoursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButtonNameStars = new System.Windows.Forms.ToolStripDropDownButton();
            this.showDiscsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showNamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButtonBookmarks = new System.Windows.Forms.ToolStripDropDownButton();
            this.showBookmarksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showNoteMarksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newRegionBookmarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButtonGalObjects = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripButtonGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFineGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCoords = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonPerspective = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonEliteMovement = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dropdownMapNames = new System.Windows.Forms.ToolStripDropDownButton();
            this.dropdownFilterDate = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonHelp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownRecord = new System.Windows.Forms.ToolStripDropDownButton();
            this.recordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordStepToStepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newRecordStepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemClearRecording = new System.Windows.Forms.ToolStripMenuItem();
            this.playbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dotSelectedSystemCoords = new System.Windows.Forms.PictureBox();
            this.dotSystemCoords = new System.Windows.Forms.PictureBox();
            this.buttonCenter = new System.Windows.Forms.Button();
            this.buttonLookAt = new System.Windows.Forms.Button();
            this.labelClickedSystemCoords = new System.Windows.Forms.Label();
            this.systemselectionMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewOnEDSMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelRight = new System.Windows.Forms.Panel();
            this.toolStripShowAllStars.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dotSelectedSystemCoords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dotSystemCoords)).BeginInit();
            this.systemselectionMenuStrip.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControlContainer
            // 
            this.glControlContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glControlContainer.BackColor = System.Drawing.Color.Black;
            this.glControlContainer.Location = new System.Drawing.Point(0, 44);
            this.glControlContainer.Name = "glControlContainer";
            this.glControlContainer.Size = new System.Drawing.Size(1114, 753);
            this.glControlContainer.TabIndex = 0;
            // 
            // textboxFrom
            // 
            this.textboxFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textboxFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textboxFrom.Location = new System.Drawing.Point(3, 9);
            this.textboxFrom.Name = "textboxFrom";
            this.textboxFrom.Size = new System.Drawing.Size(125, 20);
            this.textboxFrom.TabIndex = 16;
            this.textboxFrom.TabStop = false;
            this.textboxFrom.Text = "Sol";
            this.toolTip1.SetToolTip(this.textboxFrom, Properties.Strings.Map3D_CenterSystemName_ToolTip);
            // 
            // labelSystemCoords
            // 
            this.labelSystemCoords.AutoSize = true;
            this.labelSystemCoords.Location = new System.Drawing.Point(211, 3);
            this.labelSystemCoords.Name = "labelSystemCoords";
            this.labelSystemCoords.Size = new System.Drawing.Size(57, 13);
            this.labelSystemCoords.TabIndex = 18;
            this.labelSystemCoords.Text = "Sol x=0.00";
            // 
            // toolStripShowAllStars
            // 
            this.toolStripShowAllStars.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStripShowAllStars.AutoSize = false;
            this.toolStripShowAllStars.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripShowAllStars.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonGoBackward,
            this.toolStripButtonGoForward,
            this.toolStripButtonLastKnownPosition,
            this.toolStripButtonAutoForward,
            this.toolStripButtonHome,
            this.toolStripButtonHistory,
            this.toolStripButtonTarget,
            this.toolStripSeparator5,
            this.toolStripDropDownButtonVisitedStars,
            this.toolStripDropDownButtonFilterStars,
            this.toolStripDropDownButtonNameStars,
            this.toolStripDropDownButtonBookmarks,
            this.toolStripDropDownButtonGalObjects,
            this.toolStripButtonGrid,
            this.toolStripButtonFineGrid,
            this.toolStripButtonCoords,
            this.toolStripSeparator3,
            this.toolStripButtonPerspective,
            this.toolStripSeparator1,
            this.toolStripButtonEliteMovement,
            this.toolStripSeparator2,
            this.dropdownMapNames,
            this.dropdownFilterDate,
            this.toolStripSeparator6,
            this.toolStripButtonHelp,
            this.toolStripSeparator7,
            this.toolStripDropDownRecord});
            this.toolStripShowAllStars.Location = new System.Drawing.Point(0, 0);
            this.toolStripShowAllStars.Name = "toolStripShowAllStars";
            this.toolStripShowAllStars.Size = new System.Drawing.Size(589, 40);
            this.toolStripShowAllStars.TabIndex = 19;
            this.toolStripShowAllStars.Text = "toolStrip1";
            // 
            // toolStripButtonGoBackward
            // 
            this.toolStripButtonGoBackward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonGoBackward.Image = global::EDDiscovery.Icons.Controls.Map3D_Navigation_GoBackward;
            this.toolStripButtonGoBackward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonGoBackward.Name = "toolStripButtonGoBackward";
            this.toolStripButtonGoBackward.Size = new System.Drawing.Size(23, 37);
            this.toolStripButtonGoBackward.Text = Properties.Strings.Map3D_Navigation_GoBackward;
            this.toolStripButtonGoBackward.ToolTipText = Properties.Strings.Map3D_Navigation_GoBackward_ToolTip;
            this.toolStripButtonGoBackward.Click += new System.EventHandler(this.toolStripButtonGoBackward_Click);
            // 
            // toolStripButtonGoForward
            // 
            this.toolStripButtonGoForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonGoForward.Image = global::EDDiscovery.Icons.Controls.Map3D_Navigation_GoForward;
            this.toolStripButtonGoForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonGoForward.Name = "toolStripButtonGoForward";
            this.toolStripButtonGoForward.Size = new System.Drawing.Size(23, 37);
            this.toolStripButtonGoForward.Text = Properties.Strings.Map3D_Navigation_GoForward;
            this.toolStripButtonGoForward.ToolTipText = Properties.Strings.Map3D_Navigation_GoForward_ToolTip;
            this.toolStripButtonGoForward.Click += new System.EventHandler(this.toolStripButtonGoForward_Click);
            // 
            // toolStripButtonLastKnownPosition
            // 
            this.toolStripButtonLastKnownPosition.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLastKnownPosition.Image = global::EDDiscovery.Icons.Controls.Map3D_Navigation_LastKnownPosition;
            this.toolStripButtonLastKnownPosition.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLastKnownPosition.Name = "toolStripButtonLastKnownPosition";
            this.toolStripButtonLastKnownPosition.Size = new System.Drawing.Size(23, 37);
            this.toolStripButtonLastKnownPosition.Text = Properties.Strings.Map3D_Navigation_LastKnownPosition;
            this.toolStripButtonLastKnownPosition.ToolTipText = Properties.Strings.Map3D_Navigation_LastKnownPosition_ToolTip;
            this.toolStripButtonLastKnownPosition.Click += new System.EventHandler(this.toolStripLastKnownPosition_Click);
            // 
            // toolStripButtonAutoForward
            // 
            this.toolStripButtonAutoForward.Checked = true;
            this.toolStripButtonAutoForward.CheckOnClick = true;
            this.toolStripButtonAutoForward.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonAutoForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAutoForward.Image = global::EDDiscovery.Icons.Controls.Map3D_Navigation_GoForwardOnJump;
            this.toolStripButtonAutoForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAutoForward.Name = "toolStripButtonAutoForward";
            this.toolStripButtonAutoForward.Size = new System.Drawing.Size(23, 37);
            this.toolStripButtonAutoForward.Text = Properties.Strings.Map3D_Navigation_GoForwardOnJump;
            this.toolStripButtonAutoForward.ToolTipText = Properties.Strings.Map3D_Navigation_GoForwardOnJump_ToolTip;
            this.toolStripButtonAutoForward.Click += new System.EventHandler(this.toolStripButtonAutoForward_Click);
            // 
            // toolStripButtonHome
            // 
            this.toolStripButtonHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonHome.Image = global::EDDiscovery.Icons.Controls.Map3D_Navigation_GoToHomeSystem;
            this.toolStripButtonHome.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHome.Name = "toolStripButtonHome";
            this.toolStripButtonHome.Size = new System.Drawing.Size(23, 37);
            this.toolStripButtonHome.Text = Properties.Strings.Map3D_Navigation_GoToHomeSystem;
            this.toolStripButtonHome.ToolTipText = Properties.Strings.Map3D_Navigation_GoToHomeSystem_ToolTip;
            this.toolStripButtonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // toolStripButtonHistory
            // 
            this.toolStripButtonHistory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonHistory.Image = global::EDDiscovery.Icons.Controls.Map3D_Navigation_GoToHistorySelection;
            this.toolStripButtonHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHistory.Name = "toolStripButtonHistory";
            this.toolStripButtonHistory.Size = new System.Drawing.Size(23, 37);
            this.toolStripButtonHistory.Text = Properties.Strings.Map3D_Navigation_GoToHistorySelection;
            this.toolStripButtonHistory.ToolTipText = Properties.Strings.Map3D_Navigation_GoToHistorySelection_ToolTip;
            this.toolStripButtonHistory.Click += new System.EventHandler(this.buttonHistory_Click);
            // 
            // toolStripButtonTarget
            // 
            this.toolStripButtonTarget.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonTarget.Image = global::EDDiscovery.Icons.Controls.Map3D_Navigation_GoToTarget;
            this.toolStripButtonTarget.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTarget.Name = "toolStripButtonTarget";
            this.toolStripButtonTarget.Size = new System.Drawing.Size(23, 37);
            this.toolStripButtonTarget.Text = Properties.Strings.Map3D_Navigation_GoToTarget;
            this.toolStripButtonTarget.ToolTipText = Properties.Strings.Map3D_Navigation_GoToTarget_ToolTip;
            this.toolStripButtonTarget.Click += new System.EventHandler(this.toolStripButtonTarget_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 40);
            // 
            // toolStripDropDownButtonVisitedStars
            // 
            this.toolStripDropDownButtonVisitedStars.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonVisitedStars.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawLinesBetweenStarsWithPositionToolStripMenuItem,
            this.drawADiscOnStarsWithPositionToolStripMenuItem,
            this.useWhiteForDiscsInsteadOfAssignedMapColourToolStripMenuItem});
            this.toolStripDropDownButtonVisitedStars.Image = global::EDDiscovery.Icons.Controls.Map3D_Travel_Menu;
            this.toolStripDropDownButtonVisitedStars.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonVisitedStars.Name = "toolStripDropDownButtonVisitedStars";
            this.toolStripDropDownButtonVisitedStars.Size = new System.Drawing.Size(29, 37);
            this.toolStripDropDownButtonVisitedStars.Text = Properties.Strings.Map3D_Travel_Menu;
            this.toolStripDropDownButtonVisitedStars.ToolTipText = Properties.Strings.Map3D_Travel_Menu_ToolTip;
            // 
            // drawLinesBetweenStarsWithPositionToolStripMenuItem
            // 
            this.drawLinesBetweenStarsWithPositionToolStripMenuItem.Checked = true;
            this.drawLinesBetweenStarsWithPositionToolStripMenuItem.CheckOnClick = true;
            this.drawLinesBetweenStarsWithPositionToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.drawLinesBetweenStarsWithPositionToolStripMenuItem.Image = global::EDDiscovery.Icons.Controls.Map3D_Travel_DrawLines;
            this.drawLinesBetweenStarsWithPositionToolStripMenuItem.Name = "drawLinesBetweenStarsWithPositionToolStripMenuItem";
            this.drawLinesBetweenStarsWithPositionToolStripMenuItem.Size = new System.Drawing.Size(342, 22);
            this.drawLinesBetweenStarsWithPositionToolStripMenuItem.Text = Properties.Strings.Map3D_Travel_DrawLines;
            this.drawLinesBetweenStarsWithPositionToolStripMenuItem.ToolTipText = Properties.Strings.Map3D_Travel_DrawLines_ToolTip;
            this.drawLinesBetweenStarsWithPositionToolStripMenuItem.Click += new System.EventHandler(this.drawLinesBetweenStarsWithPositionToolStripMenuItem_Click);
            // 
            // drawADiscOnStarsWithPositionToolStripMenuItem
            // 
            this.drawADiscOnStarsWithPositionToolStripMenuItem.Checked = true;
            this.drawADiscOnStarsWithPositionToolStripMenuItem.CheckOnClick = true;
            this.drawADiscOnStarsWithPositionToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.drawADiscOnStarsWithPositionToolStripMenuItem.Image = global::EDDiscovery.Icons.Controls.Map3D_Travel_DrawStars;
            this.drawADiscOnStarsWithPositionToolStripMenuItem.Name = "drawADiscOnStarsWithPositionToolStripMenuItem";
            this.drawADiscOnStarsWithPositionToolStripMenuItem.Size = new System.Drawing.Size(342, 22);
            this.drawADiscOnStarsWithPositionToolStripMenuItem.Text = Properties.Strings.Map3D_Travel_DrawStars;
            this.drawADiscOnStarsWithPositionToolStripMenuItem.ToolTipText = Properties.Strings.Map3D_Travel_DrawStars_ToolTip;
            this.drawADiscOnStarsWithPositionToolStripMenuItem.Click += new System.EventHandler(this.drawADiscOnStarsWithPositionToolStripMenuItem_Click);
            // 
            // useWhiteForDiscsInsteadOfAssignedMapColourToolStripMenuItem
            // 
            this.useWhiteForDiscsInsteadOfAssignedMapColourToolStripMenuItem.Checked = true;
            this.useWhiteForDiscsInsteadOfAssignedMapColourToolStripMenuItem.CheckOnClick = true;
            this.useWhiteForDiscsInsteadOfAssignedMapColourToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useWhiteForDiscsInsteadOfAssignedMapColourToolStripMenuItem.Image = global::EDDiscovery.Icons.Controls.Map3D_Travel_WhiteStars;
            this.useWhiteForDiscsInsteadOfAssignedMapColourToolStripMenuItem.Name = "useWhiteForDiscsInsteadOfAssignedMapColourToolStripMenuItem";
            this.useWhiteForDiscsInsteadOfAssignedMapColourToolStripMenuItem.Size = new System.Drawing.Size(342, 22);
            this.useWhiteForDiscsInsteadOfAssignedMapColourToolStripMenuItem.Text = Properties.Strings.Map3D_Travel_WhiteStars;
            this.useWhiteForDiscsInsteadOfAssignedMapColourToolStripMenuItem.ToolTipText = Properties.Strings.Map3D_Travel_WhiteStars_ToolTip;
            this.useWhiteForDiscsInsteadOfAssignedMapColourToolStripMenuItem.Click += new System.EventHandler(this.useWhiteForDiscsInsteadOfAssignedMapColourToolStripMenuItem_Click);
            // 
            // toolStripDropDownButtonFilterStars
            // 
            this.toolStripDropDownButtonFilterStars.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonFilterStars.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator4,
            this.showStarstoolStripMenuItem,
            this.showStationsToolStripMenuItem,
            this.enableColoursToolStripMenuItem});
            this.toolStripDropDownButtonFilterStars.Image = global::EDDiscovery.Icons.Controls.Map3D_Filter_Menu;
            this.toolStripDropDownButtonFilterStars.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonFilterStars.Name = "toolStripDropDownButtonFilterStars";
            this.toolStripDropDownButtonFilterStars.Size = new System.Drawing.Size(29, 37);
            this.toolStripDropDownButtonFilterStars.Text = Properties.Strings.Map3D_Filter_Menu;
            this.toolStripDropDownButtonFilterStars.ToolTipText = Properties.Strings.Map3D_Filter_Menu_ToolTip;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(150, 6);
            // 
            // showStarstoolStripMenuItem
            // 
            this.showStarstoolStripMenuItem.Checked = true;
            this.showStarstoolStripMenuItem.CheckOnClick = true;
            this.showStarstoolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showStarstoolStripMenuItem.Image = global::EDDiscovery.Icons.Controls.Map3D_Filter_ShowAllStars;
            this.showStarstoolStripMenuItem.Name = "showStarstoolStripMenuItem";
            this.showStarstoolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.showStarstoolStripMenuItem.Text = Properties.Strings.Map3D_Filter_ShowAllStars;
            this.showStarstoolStripMenuItem.ToolTipText = Properties.Strings.Map3D_Filter_ShowAllStars_ToolTip;
            this.showStarstoolStripMenuItem.Click += new System.EventHandler(this.showStarstoolStripMenuItem_Click);
            // 
            // showStationsToolStripMenuItem
            // 
            this.showStationsToolStripMenuItem.Checked = true;
            this.showStationsToolStripMenuItem.CheckOnClick = true;
            this.showStationsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showStationsToolStripMenuItem.Image = global::EDDiscovery.Icons.Controls.Map3D_Filter_ShowPopSystems;
            this.showStationsToolStripMenuItem.Name = "showStationsToolStripMenuItem";
            this.showStationsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.showStationsToolStripMenuItem.Text = Properties.Strings.Map3D_Filter_ShowPopSystems;
            this.showStationsToolStripMenuItem.ToolTipText = Properties.Strings.Map3D_Filter_ShowPopSystems_ToolTip;
            this.showStationsToolStripMenuItem.Click += new System.EventHandler(this.showStationsToolStripMenuItem_Click);
            // 
            // toolStripDropDownButtonNameStars
            // 
            this.toolStripDropDownButtonNameStars.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonNameStars.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDiscsToolStripMenuItem,
            this.showNamesToolStripMenuItem});
            this.toolStripDropDownButtonNameStars.Image = global::EDDiscovery.Icons.Controls.Map3D_Stars_Menu;
            this.toolStripDropDownButtonNameStars.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonNameStars.Name = "toolStripDropDownButtonNameStars";
            this.toolStripDropDownButtonNameStars.Size = new System.Drawing.Size(29, 37);
            this.toolStripDropDownButtonNameStars.Text = Properties.Strings.Map3D_Stars_Menu;
            this.toolStripDropDownButtonNameStars.ToolTipText = Properties.Strings.Map3D_Stars_Menu_ToolTip;
            // 
            // enableColoursToolStripMenuItem
            // 
            this.enableColoursToolStripMenuItem.CheckOnClick = true;
            this.enableColoursToolStripMenuItem.Image = global::EDDiscovery.Icons.Controls.Map3D_Stars_DisplayColours;
            this.enableColoursToolStripMenuItem.Name = "enableColoursToolStripMenuItem";
            this.enableColoursToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.enableColoursToolStripMenuItem.Text = Properties.Strings.Map3D_Stars_DisplayColours;
            this.enableColoursToolStripMenuItem.ToolTipText = Properties.Strings.Map3D_Stars_DisplayColours_ToolTip;
            this.enableColoursToolStripMenuItem.Click += new System.EventHandler(this.enableColoursToolStripMenuItem_Click);
            // 
            // showDiscsToolStripMenuItem
            // 
            this.showDiscsToolStripMenuItem.CheckOnClick = true;
            this.showDiscsToolStripMenuItem.Image = global::EDDiscovery.Icons.Controls.Map3D_Stars_ShowDiscs;
            this.showDiscsToolStripMenuItem.Name = "showDiscsToolStripMenuItem";
            this.showDiscsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.showDiscsToolStripMenuItem.Text = Properties.Strings.Map3D_Stars_ShowDiscs;
            this.showDiscsToolStripMenuItem.ToolTipText = Properties.Strings.Map3D_Stars_ShowDiscs_ToolTip;
            this.showDiscsToolStripMenuItem.Click += new System.EventHandler(this.showDiscsToolStripMenuItem_Click);
            // 
            // showNamesToolStripMenuItem
            // 
            this.showNamesToolStripMenuItem.CheckOnClick = true;
            this.showNamesToolStripMenuItem.Image = global::EDDiscovery.Icons.Controls.Map3D_Stars_ShowNames;
            this.showNamesToolStripMenuItem.Name = "showNamesToolStripMenuItem";
            this.showNamesToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.showNamesToolStripMenuItem.Text = Properties.Strings.Map3D_Stars_ShowNames;
            this.showNamesToolStripMenuItem.ToolTipText = Properties.Strings.Map3D_Stars_ShowNames_ToolTip;
            this.showNamesToolStripMenuItem.Click += new System.EventHandler(this.showNamesToolStripMenuItem_Click);
            // 
            // toolStripDropDownButtonBookmarks
            // 
            this.toolStripDropDownButtonBookmarks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonBookmarks.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showBookmarksToolStripMenuItem,
            this.showNoteMarksToolStripMenuItem,
            this.newRegionBookmarkToolStripMenuItem});
            this.toolStripDropDownButtonBookmarks.Image = global::EDDiscovery.Icons.Controls.Map3D_Bookmarks_Menu;
            this.toolStripDropDownButtonBookmarks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonBookmarks.Name = "toolStripDropDownButtonBookmarks";
            this.toolStripDropDownButtonBookmarks.Size = new System.Drawing.Size(29, 37);
            this.toolStripDropDownButtonBookmarks.Text = Properties.Strings.Map3D_Bookmarks_Menu;
            this.toolStripDropDownButtonBookmarks.ToolTipText = Properties.Strings.Map3D_Bookmarks_Menu_ToolTip;
            // 
            // showBookmarksToolStripMenuItem
            // 
            this.showBookmarksToolStripMenuItem.Checked = true;
            this.showBookmarksToolStripMenuItem.CheckOnClick = true;
            this.showBookmarksToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showBookmarksToolStripMenuItem.Image = global::EDDiscovery.Icons.Controls.Map3D_Bookmarks_ShowBookmarks;
            this.showBookmarksToolStripMenuItem.Name = "showBookmarksToolStripMenuItem";
            this.showBookmarksToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.showBookmarksToolStripMenuItem.Text = Properties.Strings.Map3D_Bookmarks_ShowBookmarks;
            this.showBookmarksToolStripMenuItem.ToolTipText = Properties.Strings.Map3D_Bookmarks_ShowBookmarks_ToolTip;
            this.showBookmarksToolStripMenuItem.Click += new System.EventHandler(this.showBookmarksToolStripMenuItem_Click);
            // 
            // showNoteMarksToolStripMenuItem
            // 
            this.showNoteMarksToolStripMenuItem.Checked = true;
            this.showNoteMarksToolStripMenuItem.CheckOnClick = true;
            this.showNoteMarksToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showNoteMarksToolStripMenuItem.Image = global::EDDiscovery.Icons.Controls.Map3D_Bookmarks_ShowNotemarks;
            this.showNoteMarksToolStripMenuItem.Name = "showNoteMarksToolStripMenuItem";
            this.showNoteMarksToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.showNoteMarksToolStripMenuItem.Text = Properties.Strings.Map3D_Bookmarks_ShowNotemarks;
            this.showNoteMarksToolStripMenuItem.ToolTipText = Properties.Strings.Map3D_Bookmarks_ShowNotemarks_ToolTip;
            this.showNoteMarksToolStripMenuItem.Click += new System.EventHandler(this.showNoteMarksToolStripMenuItem_Click);
            // 
            // newRegionBookmarkToolStripMenuItem
            // 
            this.newRegionBookmarkToolStripMenuItem.Image = global::EDDiscovery.Icons.Controls.Map3D_Bookmarks_AddRegionBookmark;
            this.newRegionBookmarkToolStripMenuItem.Name = "newRegionBookmarkToolStripMenuItem";
            this.newRegionBookmarkToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.newRegionBookmarkToolStripMenuItem.Text = Properties.Strings.Map3D_Bookmarks_AddRegionBookmark;
            this.newRegionBookmarkToolStripMenuItem.ToolTipText = Properties.Strings.Map3D_Bookmarks_AddRegionBookmark_ToolTip;
            this.newRegionBookmarkToolStripMenuItem.Click += new System.EventHandler(this.newRegionBookmarkToolStripMenuItem_Click);
            // 
            // toolStripDropDownButtonGalObjects
            // 
            this.toolStripDropDownButtonGalObjects.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonGalObjects.Image = global::EDDiscovery.Icons.Controls.Map3D_GalObjects;
            this.toolStripDropDownButtonGalObjects.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonGalObjects.Name = "toolStripDropDownButtonGalObjects";
            this.toolStripDropDownButtonGalObjects.Size = new System.Drawing.Size(29, 37);
            this.toolStripDropDownButtonGalObjects.Text = Properties.Strings.Map3D_GalObjects;
            this.toolStripDropDownButtonGalObjects.ToolTipText = Properties.Strings.Map3D_GalObjects_ToolTip;
            // 
            // toolStripButtonGrid
            // 
            this.toolStripButtonGrid.CheckOnClick = true;
            this.toolStripButtonGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonGrid.Image = global::EDDiscovery.Icons.Controls.Map3D_Grid_Grid;
            this.toolStripButtonGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonGrid.Name = "toolStripButtonGrid";
            this.toolStripButtonGrid.Size = new System.Drawing.Size(23, 37);
            this.toolStripButtonGrid.Text = Properties.Strings.Map3D_Grid_Grid;
            this.toolStripButtonGrid.ToolTipText = Properties.Strings.Map3D_Grid_Grid_ToolTip;
            this.toolStripButtonGrid.Click += new System.EventHandler(this.toolStripButtonGrid_Click);
            // 
            // toolStripButtonFineGrid
            // 
            this.toolStripButtonFineGrid.CheckOnClick = true;
            this.toolStripButtonFineGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFineGrid.Image = global::EDDiscovery.Icons.Controls.Map3D_Grid_FineGrid;
            this.toolStripButtonFineGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFineGrid.Name = "toolStripButtonFineGrid";
            this.toolStripButtonFineGrid.Size = new System.Drawing.Size(23, 37);
            this.toolStripButtonFineGrid.Text = Properties.Strings.Map3D_Grid_FineGrid;
            this.toolStripButtonFineGrid.ToolTipText = Properties.Strings.Map3D_Grid_FineGrid_ToolTip;
            this.toolStripButtonFineGrid.Click += new System.EventHandler(this.toolStripButtonFineGrid_Click);
            // 
            // toolStripButtonCoords
            // 
            this.toolStripButtonCoords.CheckOnClick = true;
            this.toolStripButtonCoords.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCoords.Image = global::EDDiscovery.Icons.Controls.Map3D_Grid_Coords;
            this.toolStripButtonCoords.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCoords.Name = "toolStripButtonCoords";
            this.toolStripButtonCoords.Size = new System.Drawing.Size(23, 37);
            this.toolStripButtonCoords.Text = Properties.Strings.Map3D_Grid_Coords;
            this.toolStripButtonCoords.ToolTipText = Properties.Strings.Map3D_Grid_Coords_ToolTip;
            this.toolStripButtonCoords.Click += new System.EventHandler(this.toolStripButtonCoords_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 40);
            // 
            // toolStripButtonPerspective
            // 
            this.toolStripButtonPerspective.CheckOnClick = true;
            this.toolStripButtonPerspective.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPerspective.Image = global::EDDiscovery.Icons.Controls.Map3D_Perspective;
            this.toolStripButtonPerspective.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPerspective.Name = "toolStripButtonPerspective";
            this.toolStripButtonPerspective.Size = new System.Drawing.Size(23, 37);
            this.toolStripButtonPerspective.Text = Properties.Strings.Map3D_Perspective;
            this.toolStripButtonPerspective.ToolTipText = Properties.Strings.Map3D_Perspective_ToolTip;
            this.toolStripButtonPerspective.Click += new System.EventHandler(this.toolStripButtonPerspective_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // toolStripButtonEliteMovement
            // 
            this.toolStripButtonEliteMovement.CheckOnClick = true;
            this.toolStripButtonEliteMovement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEliteMovement.Image = global::EDDiscovery.Icons.Controls.Map3D_EliteMovement;
            this.toolStripButtonEliteMovement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEliteMovement.Name = "toolStripButtonEliteMovement";
            this.toolStripButtonEliteMovement.Size = new System.Drawing.Size(23, 37);
            this.toolStripButtonEliteMovement.Text = Properties.Strings.Map3D_EliteMovement;
            this.toolStripButtonEliteMovement.ToolTipText = Properties.Strings.Map3D_EliteMovement_ToolTip;
            this.toolStripButtonEliteMovement.Click += new System.EventHandler(this.toolStripButtonEliteMovement_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // dropdownMapNames
            // 
            this.dropdownMapNames.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dropdownMapNames.Image = global::EDDiscovery.Icons.Controls.Map3D_MapNames;
            this.dropdownMapNames.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dropdownMapNames.Name = "dropdownMapNames";
            this.dropdownMapNames.Size = new System.Drawing.Size(29, 37);
            this.dropdownMapNames.Text = Properties.Strings.Map3D_MapNames;
            this.dropdownMapNames.ToolTipText = Properties.Strings.Map3D_MapNames_ToolTip;
            // 
            // dropdownFilterDate
            // 
            this.dropdownFilterDate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dropdownFilterDate.Image = global::EDDiscovery.Icons.Controls.Map3D_FilterDate;
            this.dropdownFilterDate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dropdownFilterDate.Name = "dropdownFilterDate";
            this.dropdownFilterDate.Size = new System.Drawing.Size(29, 37);
            this.dropdownFilterDate.Text = Properties.Strings.Map3D_FilterDate;
            this.dropdownFilterDate.ToolTipText = Properties.Strings.Map3D_FilterDate_ToolTip;
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 40);
            // 
            // toolStripButtonHelp
            // 
            this.toolStripButtonHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonHelp.Image = global::EDDiscovery.Icons.Controls.Map3D_Help;
            this.toolStripButtonHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHelp.Name = "toolStripButtonHelp";
            this.toolStripButtonHelp.Size = new System.Drawing.Size(23, 37);
            this.toolStripButtonHelp.Text = Properties.Strings.Map3D_Help;
            this.toolStripButtonHelp.ToolTipText = Properties.Strings.Map3D_Help_ToolTip;
            this.toolStripButtonHelp.Click += new System.EventHandler(this.toolStripButtonHelp_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 40);
            // 
            // toolStripDropDownRecord
            // 
            this.toolStripDropDownRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownRecord.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recordToolStripMenuItem,
            this.recordStepToStepToolStripMenuItem,
            this.newRecordStepToolStripMenuItem,
            this.pauseRecordToolStripMenuItem,
            this.toolStripMenuItemClearRecording,
            this.playbackToolStripMenuItem,
            this.saveToFileToolStripMenuItem,
            this.LoadFileToolStripMenuItem});
            this.toolStripDropDownRecord.Image = global::EDDiscovery.Icons.Controls.Map3D_Recorder_Menu;
            this.toolStripDropDownRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownRecord.Name = "toolStripDropDownRecord";
            this.toolStripDropDownRecord.Size = new System.Drawing.Size(29, 20);
            this.toolStripDropDownRecord.Text = Properties.Strings.Map3D_Recorder_Menu;
            this.toolStripDropDownRecord.ToolTipText = Properties.Strings.Map3D_Recorder_Menu_ToolTip;
            this.toolStripDropDownRecord.DropDownOpening += new System.EventHandler(this.toolStripDropDownRecord_DropDownOpening);
            // 
            // recordToolStripMenuItem
            // 
            this.recordToolStripMenuItem.Image = global::EDDiscovery.Icons.Controls.Map3D_Recorder_Record;
            this.recordToolStripMenuItem.Name = "recordToolStripMenuItem";
            this.recordToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.recordToolStripMenuItem.Text = Properties.Strings.Map3D_Recorder_Record;
            this.recordToolStripMenuItem.ToolTipText = Properties.Strings.Map3D_Recorder_Record_ToolTip;
            this.recordToolStripMenuItem.Click += new System.EventHandler(this.recordToolStripMenuItem_Click);
            // 
            // recordStepToStepToolStripMenuItem
            // 
            this.recordStepToStepToolStripMenuItem.Image = global::EDDiscovery.Icons.Controls.Map3D_Recorder_RecordStep;
            this.recordStepToStepToolStripMenuItem.Name = "recordStepToStepToolStripMenuItem";
            this.recordStepToStepToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.recordStepToStepToolStripMenuItem.Text = Properties.Strings.Map3D_Recorder_RecordStep;
            this.recordStepToStepToolStripMenuItem.ToolTipText = Properties.Strings.Map3D_Recorder_RecordStep_ToolTip;
            this.recordStepToStepToolStripMenuItem.Click += new System.EventHandler(this.recordStepToStepToolStripMenuItem_Click);
            // 
            // newRecordStepToolStripMenuItem
            // 
            this.newRecordStepToolStripMenuItem.Image = global::EDDiscovery.Icons.Controls.Map3D_Recorder_NewRecordStep;
            this.newRecordStepToolStripMenuItem.Name = "newRecordStepToolStripMenuItem";
            this.newRecordStepToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.newRecordStepToolStripMenuItem.Text = Properties.Strings.Map3D_Recorder_NewRecordStep;
            this.newRecordStepToolStripMenuItem.ToolTipText = Properties.Strings.Map3D_Recorder_NewRecordStep_ToolTip;
            this.newRecordStepToolStripMenuItem.Click += new System.EventHandler(this.newRecordStepToolStripMenuItem_Click);
            // 
            // pauseRecordToolStripMenuItem
            // 
            this.pauseRecordToolStripMenuItem.Image = global::EDDiscovery.Icons.Controls.Map3D_Recorder_Pause;
            this.pauseRecordToolStripMenuItem.Name = "pauseRecordToolStripMenuItem";
            this.pauseRecordToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.pauseRecordToolStripMenuItem.Text = Properties.Strings.Map3D_Recorder_Pause;
            this.pauseRecordToolStripMenuItem.ToolTipText = Properties.Strings.Map3D_Recorder_Pause_ToolTip;
            this.pauseRecordToolStripMenuItem.Click += new System.EventHandler(this.pauseRecordToolStripMenuItem_Click);
            // 
            // toolStripMenuItemClearRecording
            // 
            this.toolStripMenuItemClearRecording.Image = global::EDDiscovery.Icons.Controls.Map3D_Recorder_Clear;
            this.toolStripMenuItemClearRecording.Name = "toolStripMenuItemClearRecording";
            this.toolStripMenuItemClearRecording.Size = new System.Drawing.Size(187, 22);
            this.toolStripMenuItemClearRecording.Text = Properties.Strings.Map3D_Recorder_Clear;
            this.toolStripMenuItemClearRecording.ToolTipText = Properties.Strings.Map3D_Recorder_Clear_ToolTip;
            this.toolStripMenuItemClearRecording.Click += new System.EventHandler(this.toolStripMenuItemClearRecording_Click);
            // 
            // playbackToolStripMenuItem
            // 
            this.playbackToolStripMenuItem.Image = global::EDDiscovery.Icons.Controls.Map3D_Recorder_Play;
            this.playbackToolStripMenuItem.Name = "playbackToolStripMenuItem";
            this.playbackToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.playbackToolStripMenuItem.Text = Properties.Strings.Map3D_Recorder_Play;
            this.playbackToolStripMenuItem.ToolTipText = Properties.Strings.Map3D_Recorder_Play_ToolTip;
            this.playbackToolStripMenuItem.Click += new System.EventHandler(this.playbackToolStripMenuItem_Click);
            // 
            // saveToFileToolStripMenuItem
            // 
            this.saveToFileToolStripMenuItem.Image = global::EDDiscovery.Icons.Controls.Map3D_Recorder_Save;
            this.saveToFileToolStripMenuItem.Name = "saveToFileToolStripMenuItem";
            this.saveToFileToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.saveToFileToolStripMenuItem.Text = Properties.Strings.Map3D_Recorder_Save;
            this.saveToFileToolStripMenuItem.ToolTipText = Properties.Strings.Map3D_Recorder_Save_ToolTip;
            this.saveToFileToolStripMenuItem.Click += new System.EventHandler(this.saveToFileToolStripMenuItem_Click);
            // 
            // LoadFileToolStripMenuItem
            // 
            this.LoadFileToolStripMenuItem.Image = global::EDDiscovery.Icons.Controls.Map3D_Recorder_Load;
            this.LoadFileToolStripMenuItem.Name = "LoadFileToolStripMenuItem";
            this.LoadFileToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.LoadFileToolStripMenuItem.Text = Properties.Strings.Map3D_Recorder_Load;
            this.LoadFileToolStripMenuItem.ToolTipText = Properties.Strings.Map3D_Recorder_Load_ToolTip;
            this.LoadFileToolStripMenuItem.Click += new System.EventHandler(this.LoadFileToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 800);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1114, 22);
            this.statusStrip.TabIndex = 21;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(35, 17);
            this.statusLabel.Text = "x=0.0";
            // 
            // dotSelectedSystemCoords
            // 
            this.dotSelectedSystemCoords.Image = global::EDDiscovery.Icons.Controls.Map3D_OrangeDot;
            this.dotSelectedSystemCoords.InitialImage = global::EDDiscovery.Icons.Controls.Map3D_OrangeDot;
            this.dotSelectedSystemCoords.Location = new System.Drawing.Point(193, 22);
            this.dotSelectedSystemCoords.Name = "dotSelectedSystemCoords";
            this.dotSelectedSystemCoords.Size = new System.Drawing.Size(12, 12);
            this.dotSelectedSystemCoords.TabIndex = 26;
            this.dotSelectedSystemCoords.TabStop = false;
            this.toolTip1.SetToolTip(this.dotSelectedSystemCoords, Properties.Strings.Map3D_OrangeDot_ToolTip);
            this.dotSelectedSystemCoords.Click += new System.EventHandler(this.dotSelectedSystemCoords_Click);
            // 
            // dotSystemCoords
            // 
            this.dotSystemCoords.Image = global::EDDiscovery.Icons.Controls.Map3D_YellowDot;
            this.dotSystemCoords.InitialImage = global::EDDiscovery.Icons.Controls.Map3D_YellowDot;
            this.dotSystemCoords.Location = new System.Drawing.Point(193, 4);
            this.dotSystemCoords.Name = "dotSystemCoords";
            this.dotSystemCoords.Size = new System.Drawing.Size(12, 12);
            this.dotSystemCoords.TabIndex = 25;
            this.dotSystemCoords.TabStop = false;
            this.toolTip1.SetToolTip(this.dotSystemCoords, Properties.Strings.Map3D_YellowDot_ToolTip);
            this.dotSystemCoords.Click += new System.EventHandler(this.dotSystemCoords_Click);
            // 
            // buttonCenter
            // 
            this.buttonCenter.Image = global::EDDiscovery.Icons.Controls.Map3D_Navigation_CenterOnSystem;
            this.buttonCenter.Location = new System.Drawing.Point(134, 7);
            this.buttonCenter.Name = "buttonCenter";
            this.buttonCenter.Size = new System.Drawing.Size(23, 23);
            this.buttonCenter.TabIndex = 17;
            this.buttonCenter.TabStop = false;
            this.toolTip1.SetToolTip(this.buttonCenter, Properties.Strings.Map3D_Navigation_CenterOnSystem_ToolTip);
            this.buttonCenter.UseVisualStyleBackColor = true;
            this.buttonCenter.Click += new System.EventHandler(this.buttonCenter_Click);
            // 
            // buttonLookAt
            // 
            this.buttonLookAt.Image = global::EDDiscovery.Icons.Controls.Map3D_Navigation_LookAtSystem;
            this.buttonLookAt.Location = new System.Drawing.Point(164, 7);
            this.buttonLookAt.Name = "buttonLookAt";
            this.buttonLookAt.Size = new System.Drawing.Size(23, 23);
            this.buttonLookAt.TabIndex = 27;
            this.toolTip1.SetToolTip(this.buttonLookAt, Properties.Strings.Map3D_Navigation_LookAtSystem_ToolTip);
            this.buttonLookAt.UseVisualStyleBackColor = true;
            this.buttonLookAt.Click += new System.EventHandler(this.buttonLookAt_Click);
            // 
            // labelClickedSystemCoords
            // 
            this.labelClickedSystemCoords.AutoSize = true;
            this.labelClickedSystemCoords.Location = new System.Drawing.Point(211, 22);
            this.labelClickedSystemCoords.Name = "labelClickedSystemCoords";
            this.labelClickedSystemCoords.Size = new System.Drawing.Size(57, 13);
            this.labelClickedSystemCoords.TabIndex = 24;
            this.labelClickedSystemCoords.Text = "Sol x=0.00";
            this.labelClickedSystemCoords.Click += new System.EventHandler(this.labelClickedSystemCoords_Click);
            // 
            // systemselectionMenuStrip
            // 
            this.systemselectionMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewOnEDSMToolStripMenuItem});
            this.systemselectionMenuStrip.Name = "systemselectionMenuStrip";
            this.systemselectionMenuStrip.Size = new System.Drawing.Size(151, 26);
            // 
            // viewOnEDSMToolStripMenuItem
            // 
            this.viewOnEDSMToolStripMenuItem.Name = "viewOnEDSMToolStripMenuItem";
            this.viewOnEDSMToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.viewOnEDSMToolStripMenuItem.Text = Properties.Strings.Map3D_ViewOnEDSM;
            this.viewOnEDSMToolStripMenuItem.Click += new System.EventHandler(this.viewOnEDSMToolStripMenuItem_Click);
            // 
            // panelRight
            // 
            this.panelRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRight.Controls.Add(this.buttonLookAt);
            this.panelRight.Controls.Add(this.labelClickedSystemCoords);
            this.panelRight.Controls.Add(this.dotSelectedSystemCoords);
            this.panelRight.Controls.Add(this.textboxFrom);
            this.panelRight.Controls.Add(this.buttonCenter);
            this.panelRight.Controls.Add(this.labelSystemCoords);
            this.panelRight.Controls.Add(this.dotSystemCoords);
            this.panelRight.Location = new System.Drawing.Point(608, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(506, 40);
            this.panelRight.TabIndex = 27;
            // 
            // FormMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 822);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.glControlContainer);
            this.Controls.Add(this.toolStripShowAllStars);
            this.Controls.Add(this.panelRight);
            this.Icon = global::EDDiscovery.Properties.Resources.edlogo_3mo_icon;
            this.Name = "FormMap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Properties.Strings.Map3D_Title;
            this.toolStripShowAllStars.ResumeLayout(false);
            this.toolStripShowAllStars.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dotSelectedSystemCoords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dotSystemCoords)).EndInit();
            this.systemselectionMenuStrip.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            }


            #endregion

            private Panel glControlContainer;
            internal ExtendedControls.AutoCompleteTextBox textboxFrom;
            private Label labelSystemCoords;
        private ToolStrip toolStripShowAllStars;
        private ToolStripButton toolStripButtonLastKnownPosition;
        private ToolStripButton toolStripButtonGrid;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusLabel;
        private ToolTip toolTip1;
        private ToolStripButton toolStripButtonPerspective;
        private Label labelClickedSystemCoords;
        private PictureBox dotSystemCoords;
        private PictureBox dotSelectedSystemCoords;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripDropDownButton dropdownMapNames;
        private ToolStripDropDownButton dropdownFilterDate;
        private ContextMenuStrip systemselectionMenuStrip;
        private ToolStripMenuItem viewOnEDSMToolStripMenuItem;
        private ToolStripButton toolStripButtonFineGrid;
        private ToolStripButton toolStripButtonCoords;
        private ToolStripButton toolStripButtonEliteMovement;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private Panel panelRight;
        private ToolStripDropDownButton toolStripDropDownButtonFilterStars;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripDropDownButton toolStripDropDownButtonBookmarks;
        private ToolStripMenuItem showBookmarksToolStripMenuItem;
        private ToolStripMenuItem showNoteMarksToolStripMenuItem;
        private ToolStripMenuItem newRegionBookmarkToolStripMenuItem;
        private ToolStripMenuItem showStarstoolStripMenuItem;
        private ToolStripMenuItem showStationsToolStripMenuItem;
        private ToolStripButton toolStripButtonGoBackward;
        private ToolStripButton toolStripButtonGoForward;
        private ToolStripButton toolStripButtonAutoForward;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton toolStripButtonHelp;
        private ToolStripButton toolStripButtonHome;
        private ToolStripButton toolStripButtonHistory;
        private ToolStripButton toolStripButtonTarget;
        private ToolStripDropDownButton toolStripDropDownButtonGalObjects;
        private ToolStripDropDownButton toolStripDropDownButtonNameStars;
        private ToolStripMenuItem showDiscsToolStripMenuItem;
        private ToolStripMenuItem showNamesToolStripMenuItem;
        private ToolStripMenuItem enableColoursToolStripMenuItem;
        private ToolStripDropDownButton toolStripDropDownRecord;
        private ToolStripMenuItem recordToolStripMenuItem;
        private ToolStripMenuItem playbackToolStripMenuItem;
        private ToolStripMenuItem saveToFileToolStripMenuItem;
        private ToolStripMenuItem LoadFileToolStripMenuItem;
        private ToolStripMenuItem pauseRecordToolStripMenuItem;
        private ToolStripMenuItem recordStepToStepToolStripMenuItem;
        private Button buttonCenter;
        private Button buttonLookAt;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem toolStripMenuItemClearRecording;
        private ToolStripMenuItem newRecordStepToolStripMenuItem;
        private ToolStripDropDownButton toolStripDropDownButtonVisitedStars;
        private ToolStripMenuItem drawLinesBetweenStarsWithPositionToolStripMenuItem;
        private ToolStripMenuItem drawADiscOnStarsWithPositionToolStripMenuItem;
        private ToolStripMenuItem useWhiteForDiscsInsteadOfAssignedMapColourToolStripMenuItem;
    }
    }
