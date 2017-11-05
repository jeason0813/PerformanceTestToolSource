/*
Copyright (C) 2017 Lars Hove Christiansen
http://virtcore.com

This file is a part of Performance Test Tool

	Performance Test Tool is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	Performance Test Tool is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with Performance Test Tool. If not, see <http://www.gnu.org/licenses/>.
*/

partial class WorkloadManagerForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkloadManagerForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.hiddenModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.setupHeaderLabel = new System.Windows.Forms.Label();
			this.startButton = new System.Windows.Forms.Button();
			this.statusHeaderLabel = new System.Windows.Forms.Label();
			this.statusLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.runsTextBox = new System.Windows.Forms.TextBox();
			this.timeBetweenRunsTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.taskCollectionTextBox = new System.Windows.Forms.TextBox();
			this.stylesheetCollectionTextBox = new System.Windows.Forms.TextBox();
			this.customTaskCollectionCheckBox = new System.Windows.Forms.CheckBox();
			this.customStylesheetCollectionCheckBox = new System.Windows.Forms.CheckBox();
			this.findTaskCollectionButton = new System.Windows.Forms.Button();
			this.findStylesheetCollectionButton = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
			this.includeLogCheckBox = new System.Windows.Forms.CheckBox();
			this.includeStylesheetsCheckBox = new System.Windows.Forms.CheckBox();
			this.findLogDirButton = new System.Windows.Forms.Button();
			this.logDirTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.runLabel = new System.Windows.Forms.Label();
			this.runProgressBar = new System.Windows.Forms.ProgressBar();
			this.logOptionsHeaderLabel = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.timeElapsedLabel = new System.Windows.Forms.Label();
			this.executionTimeTimer = new System.Windows.Forms.Timer(this.components);
			this.borderLabel2 = new BorderLabel();
			this.borderLabel3 = new BorderLabel();
			this.borderLabel1 = new BorderLabel();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(684, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.toolStripSeparator1,
            this.hiddenModeToolStripMenuItem});
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.optionsToolStripMenuItem.Text = "&Options";
			// 
			// startToolStripMenuItem
			// 
			this.startToolStripMenuItem.Image = global::PerformanceTestTool.Properties.Resources.cog_go;
			this.startToolStripMenuItem.Name = "startToolStripMenuItem";
			this.startToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.startToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.startToolStripMenuItem.Text = "&Start";
			this.startToolStripMenuItem.Click += new System.EventHandler(this.StartToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(144, 6);
			// 
			// hiddenModeToolStripMenuItem
			// 
			this.hiddenModeToolStripMenuItem.CheckOnClick = true;
			this.hiddenModeToolStripMenuItem.Name = "hiddenModeToolStripMenuItem";
			this.hiddenModeToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.hiddenModeToolStripMenuItem.Text = "&Hidden mode";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Image = global::PerformanceTestTool.Properties.Resources.help1;
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.aboutToolStripMenuItem.Text = "&About...";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
			// 
			// setupHeaderLabel
			// 
			this.setupHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.setupHeaderLabel.BackColor = System.Drawing.Color.Gray;
			this.setupHeaderLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.setupHeaderLabel.ForeColor = System.Drawing.Color.White;
			this.setupHeaderLabel.Location = new System.Drawing.Point(12, 24);
			this.setupHeaderLabel.Name = "setupHeaderLabel";
			this.setupHeaderLabel.Size = new System.Drawing.Size(660, 17);
			this.setupHeaderLabel.TabIndex = 15;
			this.setupHeaderLabel.Text = "::: Workload Setup :::::::";
			// 
			// startButton
			// 
			this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.startButton.BackColor = System.Drawing.Color.Transparent;
			this.startButton.Image = global::PerformanceTestTool.Properties.Resources.cog_go;
			this.startButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.startButton.Location = new System.Drawing.Point(597, 430);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(75, 24);
			this.startButton.TabIndex = 0;
			this.startButton.Text = "Start";
			this.startButton.UseVisualStyleBackColor = false;
			this.startButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// statusHeaderLabel
			// 
			this.statusHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.statusHeaderLabel.BackColor = System.Drawing.Color.Gray;
			this.statusHeaderLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statusHeaderLabel.ForeColor = System.Drawing.Color.White;
			this.statusHeaderLabel.Location = new System.Drawing.Point(12, 335);
			this.statusHeaderLabel.Name = "statusHeaderLabel";
			this.statusHeaderLabel.Size = new System.Drawing.Size(660, 17);
			this.statusHeaderLabel.TabIndex = 24;
			this.statusHeaderLabel.Text = "::: Workload Run Status :::::::";
			// 
			// statusLabel
			// 
			this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.statusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.statusLabel.Location = new System.Drawing.Point(21, 403);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(590, 13);
			this.statusLabel.TabIndex = 21;
			this.statusLabel.Text = "Status: Idle";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.label1.Location = new System.Drawing.Point(21, 53);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 25;
			this.label1.Text = "Runs:";
			// 
			// runsTextBox
			// 
			this.runsTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.runsTextBox.Location = new System.Drawing.Point(127, 50);
			this.runsTextBox.Name = "runsTextBox";
			this.runsTextBox.Size = new System.Drawing.Size(51, 20);
			this.runsTextBox.TabIndex = 1;
			// 
			// timeBetweenRunsTextBox
			// 
			this.timeBetweenRunsTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.timeBetweenRunsTextBox.Location = new System.Drawing.Point(127, 76);
			this.timeBetweenRunsTextBox.Name = "timeBetweenRunsTextBox";
			this.timeBetweenRunsTextBox.Size = new System.Drawing.Size(51, 20);
			this.timeBetweenRunsTextBox.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.label2.Location = new System.Drawing.Point(21, 79);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 13);
			this.label2.TabIndex = 27;
			this.label2.Text = "Time between runs:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.label7.Location = new System.Drawing.Point(179, 79);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(20, 13);
			this.label7.TabIndex = 37;
			this.label7.Text = "ms";
			// 
			// taskCollectionTextBox
			// 
			this.taskCollectionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.taskCollectionTextBox.BackColor = System.Drawing.Color.Gainsboro;
			this.taskCollectionTextBox.Enabled = false;
			this.taskCollectionTextBox.Location = new System.Drawing.Point(184, 106);
			this.taskCollectionTextBox.Name = "taskCollectionTextBox";
			this.taskCollectionTextBox.Size = new System.Drawing.Size(444, 20);
			this.taskCollectionTextBox.TabIndex = 4;
			// 
			// stylesheetCollectionTextBox
			// 
			this.stylesheetCollectionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.stylesheetCollectionTextBox.BackColor = System.Drawing.Color.Gainsboro;
			this.stylesheetCollectionTextBox.Enabled = false;
			this.stylesheetCollectionTextBox.Location = new System.Drawing.Point(184, 132);
			this.stylesheetCollectionTextBox.Name = "stylesheetCollectionTextBox";
			this.stylesheetCollectionTextBox.Size = new System.Drawing.Size(444, 20);
			this.stylesheetCollectionTextBox.TabIndex = 7;
			// 
			// customTaskCollectionCheckBox
			// 
			this.customTaskCollectionCheckBox.AutoSize = true;
			this.customTaskCollectionCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.customTaskCollectionCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.customTaskCollectionCheckBox.Location = new System.Drawing.Point(24, 108);
			this.customTaskCollectionCheckBox.Name = "customTaskCollectionCheckBox";
			this.customTaskCollectionCheckBox.Size = new System.Drawing.Size(129, 17);
			this.customTaskCollectionCheckBox.TabIndex = 3;
			this.customTaskCollectionCheckBox.Text = "Load Task Collection:";
			this.customTaskCollectionCheckBox.UseVisualStyleBackColor = false;
			this.customTaskCollectionCheckBox.CheckedChanged += new System.EventHandler(this.CustomTaskCollectionCheckBox_CheckedChanged);
			// 
			// customStylesheetCollectionCheckBox
			// 
			this.customStylesheetCollectionCheckBox.AutoSize = true;
			this.customStylesheetCollectionCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.customStylesheetCollectionCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.customStylesheetCollectionCheckBox.Location = new System.Drawing.Point(24, 134);
			this.customStylesheetCollectionCheckBox.Name = "customStylesheetCollectionCheckBox";
			this.customStylesheetCollectionCheckBox.Size = new System.Drawing.Size(154, 17);
			this.customStylesheetCollectionCheckBox.TabIndex = 6;
			this.customStylesheetCollectionCheckBox.Text = "Load Stylesheet Collection:";
			this.customStylesheetCollectionCheckBox.UseVisualStyleBackColor = false;
			this.customStylesheetCollectionCheckBox.CheckedChanged += new System.EventHandler(this.CustomStylesheetCollectionCheckBox_CheckedChanged);
			// 
			// findTaskCollectionButton
			// 
			this.findTaskCollectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.findTaskCollectionButton.BackColor = System.Drawing.Color.Transparent;
			this.findTaskCollectionButton.Enabled = false;
			this.findTaskCollectionButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
			this.findTaskCollectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.findTaskCollectionButton.Image = global::PerformanceTestTool.Properties.Resources.folder;
			this.findTaskCollectionButton.Location = new System.Drawing.Point(634, 106);
			this.findTaskCollectionButton.Name = "findTaskCollectionButton";
			this.findTaskCollectionButton.Size = new System.Drawing.Size(25, 19);
			this.findTaskCollectionButton.TabIndex = 5;
			this.findTaskCollectionButton.UseVisualStyleBackColor = false;
			this.findTaskCollectionButton.Click += new System.EventHandler(this.FindTaskCollectionButton_Click);
			// 
			// findStylesheetCollectionButton
			// 
			this.findStylesheetCollectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.findStylesheetCollectionButton.BackColor = System.Drawing.Color.Transparent;
			this.findStylesheetCollectionButton.Enabled = false;
			this.findStylesheetCollectionButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
			this.findStylesheetCollectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.findStylesheetCollectionButton.Image = global::PerformanceTestTool.Properties.Resources.folder;
			this.findStylesheetCollectionButton.Location = new System.Drawing.Point(634, 132);
			this.findStylesheetCollectionButton.Name = "findStylesheetCollectionButton";
			this.findStylesheetCollectionButton.Size = new System.Drawing.Size(25, 19);
			this.findStylesheetCollectionButton.TabIndex = 8;
			this.findStylesheetCollectionButton.UseVisualStyleBackColor = false;
			this.findStylesheetCollectionButton.Click += new System.EventHandler(this.FindStylesheetCollectionButton_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "xml";
			this.openFileDialog1.Filter = "Task Collection files|*.xml|All files|*.*";
			// 
			// openFileDialog2
			// 
			this.openFileDialog2.DefaultExt = "xml";
			this.openFileDialog2.Filter = "Stylesheet Collection files|*.xml|All files|*.*";
			// 
			// includeLogCheckBox
			// 
			this.includeLogCheckBox.AutoSize = true;
			this.includeLogCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.includeLogCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.includeLogCheckBox.Location = new System.Drawing.Point(24, 192);
			this.includeLogCheckBox.Name = "includeLogCheckBox";
			this.includeLogCheckBox.Size = new System.Drawing.Size(104, 17);
			this.includeLogCheckBox.TabIndex = 9;
			this.includeLogCheckBox.Text = "Save Result Xml";
			this.includeLogCheckBox.UseVisualStyleBackColor = false;
			this.includeLogCheckBox.CheckedChanged += new System.EventHandler(this.IncludeLogCheckBox_CheckedChanged);
			// 
			// includeStylesheetsCheckBox
			// 
			this.includeStylesheetsCheckBox.AutoSize = true;
			this.includeStylesheetsCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.includeStylesheetsCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.includeStylesheetsCheckBox.Location = new System.Drawing.Point(24, 215);
			this.includeStylesheetsCheckBox.Name = "includeStylesheetsCheckBox";
			this.includeStylesheetsCheckBox.Size = new System.Drawing.Size(170, 17);
			this.includeStylesheetsCheckBox.TabIndex = 10;
			this.includeStylesheetsCheckBox.Text = "Save Transformed Stylesheets";
			this.includeStylesheetsCheckBox.UseVisualStyleBackColor = false;
			this.includeStylesheetsCheckBox.CheckedChanged += new System.EventHandler(this.IncludeStylesheetsCheckBox_CheckedChanged);
			// 
			// findLogDirButton
			// 
			this.findLogDirButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.findLogDirButton.BackColor = System.Drawing.Color.Transparent;
			this.findLogDirButton.Enabled = false;
			this.findLogDirButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
			this.findLogDirButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.findLogDirButton.Image = global::PerformanceTestTool.Properties.Resources.folder;
			this.findLogDirButton.Location = new System.Drawing.Point(634, 237);
			this.findLogDirButton.Name = "findLogDirButton";
			this.findLogDirButton.Size = new System.Drawing.Size(25, 19);
			this.findLogDirButton.TabIndex = 12;
			this.findLogDirButton.UseVisualStyleBackColor = false;
			this.findLogDirButton.Click += new System.EventHandler(this.FindLogDirButton_Click);
			// 
			// logDirTextBox
			// 
			this.logDirTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.logDirTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.logDirTextBox.Enabled = false;
			this.logDirTextBox.Location = new System.Drawing.Point(98, 237);
			this.logDirTextBox.Name = "logDirTextBox";
			this.logDirTextBox.Size = new System.Drawing.Size(530, 20);
			this.logDirTextBox.TabIndex = 11;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.label4.Location = new System.Drawing.Point(21, 240);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(71, 13);
			this.label4.TabIndex = 47;
			this.label4.Text = "Log directory:";
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.linkLabel1.Enabled = false;
			this.linkLabel1.Location = new System.Drawing.Point(95, 260);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(441, 13);
			this.linkLabel1.TabIndex = 48;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Log directories will be postfixed with the run number, e.g. C:\\MyLogDir_1, C:\\MyL" +
    "ogDir_2, ...";
			// 
			// runLabel
			// 
			this.runLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.runLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.runLabel.Location = new System.Drawing.Point(21, 361);
			this.runLabel.Name = "runLabel";
			this.runLabel.Size = new System.Drawing.Size(642, 13);
			this.runLabel.TabIndex = 50;
			this.runLabel.Text = "Run";
			this.runLabel.Visible = false;
			// 
			// runProgressBar
			// 
			this.runProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.runProgressBar.BackColor = System.Drawing.Color.WhiteSmoke;
			this.runProgressBar.Location = new System.Drawing.Point(21, 377);
			this.runProgressBar.Name = "runProgressBar";
			this.runProgressBar.Size = new System.Drawing.Size(642, 23);
			this.runProgressBar.TabIndex = 49;
			// 
			// logOptionsHeaderLabel
			// 
			this.logOptionsHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.logOptionsHeaderLabel.BackColor = System.Drawing.Color.Gray;
			this.logOptionsHeaderLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.logOptionsHeaderLabel.ForeColor = System.Drawing.Color.White;
			this.logOptionsHeaderLabel.Location = new System.Drawing.Point(12, 167);
			this.logOptionsHeaderLabel.Name = "logOptionsHeaderLabel";
			this.logOptionsHeaderLabel.Size = new System.Drawing.Size(660, 17);
			this.logOptionsHeaderLabel.TabIndex = 51;
			this.logOptionsHeaderLabel.Text = "::: Log Options :::::::";
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label9.Location = new System.Drawing.Point(24, 101);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(636, 2);
			this.label9.TabIndex = 42;
			// 
			// timeElapsedLabel
			// 
			this.timeElapsedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.timeElapsedLabel.AutoSize = true;
			this.timeElapsedLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.timeElapsedLabel.Location = new System.Drawing.Point(617, 403);
			this.timeElapsedLabel.Name = "timeElapsedLabel";
			this.timeElapsedLabel.Size = new System.Drawing.Size(49, 13);
			this.timeElapsedLabel.TabIndex = 53;
			this.timeElapsedLabel.Text = "00:00:00";
			// 
			// executionTimeTimer
			// 
			this.executionTimeTimer.Tick += new System.EventHandler(this.ExecutionTimer_Tick);
			// 
			// borderLabel2
			// 
			this.borderLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.borderLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.borderLabel2.Location = new System.Drawing.Point(12, 355);
			this.borderLabel2.Name = "borderLabel2";
			this.borderLabel2.Size = new System.Drawing.Size(660, 65);
			this.borderLabel2.TabIndex = 23;
			// 
			// borderLabel3
			// 
			this.borderLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.borderLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.borderLabel3.Location = new System.Drawing.Point(12, 44);
			this.borderLabel3.Name = "borderLabel3";
			this.borderLabel3.Size = new System.Drawing.Size(660, 113);
			this.borderLabel3.TabIndex = 16;
			// 
			// borderLabel1
			// 
			this.borderLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.borderLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.borderLabel1.Location = new System.Drawing.Point(12, 187);
			this.borderLabel1.Name = "borderLabel1";
			this.borderLabel1.Size = new System.Drawing.Size(660, 91);
			this.borderLabel1.TabIndex = 52;
			// 
			// WorkloadManagerForm
			// 
			this.AcceptButton = this.startButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Silver;
			this.ClientSize = new System.Drawing.Size(684, 461);
			this.Controls.Add(this.timeElapsedLabel);
			this.Controls.Add(this.logOptionsHeaderLabel);
			this.Controls.Add(this.runLabel);
			this.Controls.Add(this.runProgressBar);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.findLogDirButton);
			this.Controls.Add(this.logDirTextBox);
			this.Controls.Add(this.includeStylesheetsCheckBox);
			this.Controls.Add(this.includeLogCheckBox);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.findStylesheetCollectionButton);
			this.Controls.Add(this.findTaskCollectionButton);
			this.Controls.Add(this.customStylesheetCollectionCheckBox);
			this.Controls.Add(this.customTaskCollectionCheckBox);
			this.Controls.Add(this.stylesheetCollectionTextBox);
			this.Controls.Add(this.taskCollectionTextBox);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.timeBetweenRunsTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.runsTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.statusHeaderLabel);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.borderLabel2);
			this.Controls.Add(this.startButton);
			this.Controls.Add(this.setupHeaderLabel);
			this.Controls.Add(this.borderLabel3);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.borderLabel1);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "WorkloadManagerForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Title";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

	}

	#endregion

	private System.Windows.Forms.MenuStrip menuStrip1;
	private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
	private System.Windows.Forms.Label setupHeaderLabel;
	private BorderLabel borderLabel3;
	private System.Windows.Forms.Button startButton;
	private System.Windows.Forms.Label statusHeaderLabel;
	private System.Windows.Forms.Label statusLabel;
	private BorderLabel borderLabel2;
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.TextBox runsTextBox;
	private System.Windows.Forms.TextBox timeBetweenRunsTextBox;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.Label label7;
	private System.Windows.Forms.TextBox taskCollectionTextBox;
	private System.Windows.Forms.TextBox stylesheetCollectionTextBox;
	private System.Windows.Forms.CheckBox customTaskCollectionCheckBox;
	private System.Windows.Forms.CheckBox customStylesheetCollectionCheckBox;
	private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
	private System.Windows.Forms.Button findTaskCollectionButton;
	private System.Windows.Forms.Button findStylesheetCollectionButton;
	private System.Windows.Forms.OpenFileDialog openFileDialog1;
	private System.Windows.Forms.OpenFileDialog openFileDialog2;
	private System.Windows.Forms.CheckBox includeLogCheckBox;
	private System.Windows.Forms.CheckBox includeStylesheetsCheckBox;
	private System.Windows.Forms.Button findLogDirButton;
	private System.Windows.Forms.TextBox logDirTextBox;
	private System.Windows.Forms.Label label4;
	private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
	private System.Windows.Forms.LinkLabel linkLabel1;
	private System.Windows.Forms.Label runLabel;
	private System.Windows.Forms.ProgressBar runProgressBar;
	private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
	private System.Windows.Forms.Label logOptionsHeaderLabel;
	private BorderLabel borderLabel1;
	private System.Windows.Forms.Label label9;
	private System.Windows.Forms.Label timeElapsedLabel;
	private System.Windows.Forms.Timer executionTimeTimer;
	private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
	private System.Windows.Forms.ToolStripMenuItem hiddenModeToolStripMenuItem;
}
