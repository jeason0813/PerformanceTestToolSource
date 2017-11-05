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

partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changeConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.openResultXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.recentFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.tasksEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stylesheetEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.valueSubstitutorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveXsdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.commandLineParametersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.checkForupdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.executionTimeTimer = new System.Windows.Forms.Timer(this.components);
			this.osLabel = new System.Windows.Forms.Label();
			this.versionLabel = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.maxMemoryLabel = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.ramLabel = new System.Windows.Forms.Label();
			this.physicalCPULabel = new System.Windows.Forms.Label();
			this.logicalCPULabel = new System.Windows.Forms.Label();
			this.taskCollectionDescriptionHeaderLabel = new System.Windows.Forms.Label();
			this.sqlServerHeaderLabel = new System.Windows.Forms.Label();
			this.statusHeaderLabel = new System.Windows.Forms.Label();
			this.taskCollectionDescriptionTextBox = new System.Windows.Forms.TextBox();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.runTasksButton = new System.Windows.Forms.Button();
			this.timeElapsedLabel = new System.Windows.Forms.Label();
			this.completedLabel = new System.Windows.Forms.Label();
			this.completedProgressBar = new System.Windows.Forms.ProgressBar();
			this.startedLabel = new System.Windows.Forms.Label();
			this.statusLabel = new System.Windows.Forms.Label();
			this.startedProgressBar = new System.Windows.Forms.ProgressBar();
			this.tasksTextBox = new System.Windows.Forms.TextBox();
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
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeConnectionToolStripMenuItem,
            this.toolStripSeparator3,
            this.openResultXmlToolStripMenuItem,
            this.toolStripSeparator6,
            this.recentFilesToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// changeConnectionToolStripMenuItem
			// 
			this.changeConnectionToolStripMenuItem.Image = global::PerformanceTestTool.Properties.Resources.database_key_small;
			this.changeConnectionToolStripMenuItem.Name = "changeConnectionToolStripMenuItem";
			this.changeConnectionToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
			this.changeConnectionToolStripMenuItem.Text = "&Change Connection...";
			this.changeConnectionToolStripMenuItem.Click += new System.EventHandler(this.ChangeConnectionToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(211, 6);
			// 
			// openResultXmlToolStripMenuItem
			// 
			this.openResultXmlToolStripMenuItem.Image = global::PerformanceTestTool.Properties.Resources.folder;
			this.openResultXmlToolStripMenuItem.Name = "openResultXmlToolStripMenuItem";
			this.openResultXmlToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openResultXmlToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
			this.openResultXmlToolStripMenuItem.Text = "&Open Result Xml...";
			this.openResultXmlToolStripMenuItem.Click += new System.EventHandler(this.OpenResultXmlToolStripMenuItem_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(211, 6);
			// 
			// recentFilesToolStripMenuItem
			// 
			this.recentFilesToolStripMenuItem.Name = "recentFilesToolStripMenuItem";
			this.recentFilesToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
			this.recentFilesToolStripMenuItem.Text = "&Recent Files";
			this.recentFilesToolStripMenuItem.DropDownOpening += new System.EventHandler(this.RecentFilesToolStripMenuItem_DropDownOpening);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(211, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.toolStripSeparator5,
            this.tasksEditorToolStripMenuItem,
            this.stylesheetEditorToolStripMenuItem,
            this.toolStripSeparator7,
            this.valueSubstitutorToolStripMenuItem,
            this.toolStripSeparator2,
            this.preferencesToolStripMenuItem});
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.optionsToolStripMenuItem.Text = "&Options";
			// 
			// startToolStripMenuItem
			// 
			this.startToolStripMenuItem.Image = global::PerformanceTestTool.Properties.Resources.cog_go;
			this.startToolStripMenuItem.Name = "startToolStripMenuItem";
			this.startToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.startToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
			this.startToolStripMenuItem.Text = "&Start";
			this.startToolStripMenuItem.Click += new System.EventHandler(this.StartToolStripMenuItem_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(260, 6);
			// 
			// tasksEditorToolStripMenuItem
			// 
			this.tasksEditorToolStripMenuItem.Image = global::PerformanceTestTool.Properties.Resources.cog1;
			this.tasksEditorToolStripMenuItem.Name = "tasksEditorToolStripMenuItem";
			this.tasksEditorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D1)));
			this.tasksEditorToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
			this.tasksEditorToolStripMenuItem.Text = "&Task Collection Editor...";
			this.tasksEditorToolStripMenuItem.Click += new System.EventHandler(this.TasksEditorToolStripMenuItem_Click);
			// 
			// stylesheetEditorToolStripMenuItem
			// 
			this.stylesheetEditorToolStripMenuItem.Image = global::PerformanceTestTool.Properties.Resources.page_small;
			this.stylesheetEditorToolStripMenuItem.Name = "stylesheetEditorToolStripMenuItem";
			this.stylesheetEditorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D2)));
			this.stylesheetEditorToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
			this.stylesheetEditorToolStripMenuItem.Text = "St&ylesheet Collection Editor...";
			this.stylesheetEditorToolStripMenuItem.Click += new System.EventHandler(this.StylesheetEditorToolStripMenuItem_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(260, 6);
			// 
			// valueSubstitutorToolStripMenuItem
			// 
			this.valueSubstitutorToolStripMenuItem.Image = global::PerformanceTestTool.Properties.Resources.edit;
			this.valueSubstitutorToolStripMenuItem.Name = "valueSubstitutorToolStripMenuItem";
			this.valueSubstitutorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
			this.valueSubstitutorToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
			this.valueSubstitutorToolStripMenuItem.Text = "&Value Substitutor...";
			this.valueSubstitutorToolStripMenuItem.Click += new System.EventHandler(this.ValueSubstitutorToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(260, 6);
			// 
			// preferencesToolStripMenuItem
			// 
			this.preferencesToolStripMenuItem.Image = global::PerformanceTestTool.Properties.Resources.bullet_wrench1;
			this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
			this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
			this.preferencesToolStripMenuItem.Text = "&Preferences...";
			this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.PreferencesToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveXsdToolStripMenuItem,
            this.toolStripSeparator4,
            this.commandLineParametersToolStripMenuItem1,
            this.checkForupdatesToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// saveXsdToolStripMenuItem
			// 
			this.saveXsdToolStripMenuItem.Name = "saveXsdToolStripMenuItem";
			this.saveXsdToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
			this.saveXsdToolStripMenuItem.Text = "&Save Schema Definition for Result Xml...";
			this.saveXsdToolStripMenuItem.Click += new System.EventHandler(this.SaveXsdToolStripMenuItem_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(281, 6);
			// 
			// commandLineParametersToolStripMenuItem1
			// 
			this.commandLineParametersToolStripMenuItem1.Image = global::PerformanceTestTool.Properties.Resources.cmd_small;
			this.commandLineParametersToolStripMenuItem1.Name = "commandLineParametersToolStripMenuItem1";
			this.commandLineParametersToolStripMenuItem1.Size = new System.Drawing.Size(284, 22);
			this.commandLineParametersToolStripMenuItem1.Text = "&Command Line Parameters...";
			this.commandLineParametersToolStripMenuItem1.Click += new System.EventHandler(this.CommandLineParametersToolStripMenuItem1_Click);
			// 
			// checkForupdatesToolStripMenuItem
			// 
			this.checkForupdatesToolStripMenuItem.Image = global::PerformanceTestTool.Properties.Resources.update;
			this.checkForupdatesToolStripMenuItem.Name = "checkForupdatesToolStripMenuItem";
			this.checkForupdatesToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
			this.checkForupdatesToolStripMenuItem.Text = "Check for &updates...";
			this.checkForupdatesToolStripMenuItem.Click += new System.EventHandler(this.CheckForupdatesToolStripMenuItem_Click);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Image = global::PerformanceTestTool.Properties.Resources.help1;
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
			this.aboutToolStripMenuItem.Text = "&About...";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
			// 
			// executionTimeTimer
			// 
			this.executionTimeTimer.Tick += new System.EventHandler(this.Timer1_Tick);
			// 
			// osLabel
			// 
			this.osLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.osLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.osLabel.Location = new System.Drawing.Point(138, 50);
			this.osLabel.Name = "osLabel";
			this.osLabel.Size = new System.Drawing.Size(528, 13);
			this.osLabel.TabIndex = 12;
			this.osLabel.Text = "label1";
			// 
			// versionLabel
			// 
			this.versionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.versionLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.versionLabel.Location = new System.Drawing.Point(138, 102);
			this.versionLabel.Name = "versionLabel";
			this.versionLabel.Size = new System.Drawing.Size(528, 13);
			this.versionLabel.TabIndex = 11;
			this.versionLabel.Text = "label1";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.label7.Location = new System.Drawing.Point(18, 50);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(93, 13);
			this.label7.TabIndex = 10;
			this.label7.Text = "Operating System:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.label4.Location = new System.Drawing.Point(18, 102);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(45, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Version:";
			// 
			// maxMemoryLabel
			// 
			this.maxMemoryLabel.AutoSize = true;
			this.maxMemoryLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.maxMemoryLabel.Location = new System.Drawing.Point(138, 115);
			this.maxMemoryLabel.Name = "maxMemoryLabel";
			this.maxMemoryLabel.Size = new System.Drawing.Size(35, 13);
			this.maxMemoryLabel.TabIndex = 8;
			this.maxMemoryLabel.Text = "label1";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.label6.Location = new System.Drawing.Point(18, 115);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(95, 13);
			this.label6.TabIndex = 7;
			this.label6.Text = "Max Memory (MB):";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.label3.Location = new System.Drawing.Point(18, 63);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(114, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Physical Memory (MB):";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.label2.Location = new System.Drawing.Point(18, 89);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(105, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Physical CPU Count:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.label1.Location = new System.Drawing.Point(18, 76);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Logical CPU Count:";
			// 
			// ramLabel
			// 
			this.ramLabel.AutoSize = true;
			this.ramLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.ramLabel.Location = new System.Drawing.Point(138, 63);
			this.ramLabel.Name = "ramLabel";
			this.ramLabel.Size = new System.Drawing.Size(35, 13);
			this.ramLabel.TabIndex = 3;
			this.ramLabel.Text = "label1";
			// 
			// physicalCPULabel
			// 
			this.physicalCPULabel.AutoSize = true;
			this.physicalCPULabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.physicalCPULabel.Location = new System.Drawing.Point(138, 89);
			this.physicalCPULabel.Name = "physicalCPULabel";
			this.physicalCPULabel.Size = new System.Drawing.Size(35, 13);
			this.physicalCPULabel.TabIndex = 2;
			this.physicalCPULabel.Text = "label1";
			// 
			// logicalCPULabel
			// 
			this.logicalCPULabel.AutoSize = true;
			this.logicalCPULabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.logicalCPULabel.Location = new System.Drawing.Point(138, 76);
			this.logicalCPULabel.Name = "logicalCPULabel";
			this.logicalCPULabel.Size = new System.Drawing.Size(35, 13);
			this.logicalCPULabel.TabIndex = 0;
			this.logicalCPULabel.Text = "label1";
			// 
			// taskCollectionDescriptionHeaderLabel
			// 
			this.taskCollectionDescriptionHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.taskCollectionDescriptionHeaderLabel.BackColor = System.Drawing.Color.Gray;
			this.taskCollectionDescriptionHeaderLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.taskCollectionDescriptionHeaderLabel.ForeColor = System.Drawing.Color.White;
			this.taskCollectionDescriptionHeaderLabel.Location = new System.Drawing.Point(12, 144);
			this.taskCollectionDescriptionHeaderLabel.Name = "taskCollectionDescriptionHeaderLabel";
			this.taskCollectionDescriptionHeaderLabel.Size = new System.Drawing.Size(660, 17);
			this.taskCollectionDescriptionHeaderLabel.TabIndex = 12;
			this.taskCollectionDescriptionHeaderLabel.Text = "::: Task Collection Description :::::::";
			// 
			// sqlServerHeaderLabel
			// 
			this.sqlServerHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.sqlServerHeaderLabel.BackColor = System.Drawing.Color.Gray;
			this.sqlServerHeaderLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sqlServerHeaderLabel.ForeColor = System.Drawing.Color.White;
			this.sqlServerHeaderLabel.Location = new System.Drawing.Point(12, 24);
			this.sqlServerHeaderLabel.Name = "sqlServerHeaderLabel";
			this.sqlServerHeaderLabel.Size = new System.Drawing.Size(660, 17);
			this.sqlServerHeaderLabel.TabIndex = 13;
			this.sqlServerHeaderLabel.Text = "::: SQL Server :::::::";
			// 
			// statusHeaderLabel
			// 
			this.statusHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.statusHeaderLabel.BackColor = System.Drawing.Color.Gray;
			this.statusHeaderLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statusHeaderLabel.ForeColor = System.Drawing.Color.White;
			this.statusHeaderLabel.Location = new System.Drawing.Point(12, 294);
			this.statusHeaderLabel.Name = "statusHeaderLabel";
			this.statusHeaderLabel.Size = new System.Drawing.Size(660, 17);
			this.statusHeaderLabel.TabIndex = 16;
			this.statusHeaderLabel.Text = "::: Status :::::::";
			// 
			// taskCollectionDescriptionTextBox
			// 
			this.taskCollectionDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.taskCollectionDescriptionTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.taskCollectionDescriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.taskCollectionDescriptionTextBox.Location = new System.Drawing.Point(13, 165);
			this.taskCollectionDescriptionTextBox.Multiline = true;
			this.taskCollectionDescriptionTextBox.Name = "taskCollectionDescriptionTextBox";
			this.taskCollectionDescriptionTextBox.ReadOnly = true;
			this.taskCollectionDescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.taskCollectionDescriptionTextBox.Size = new System.Drawing.Size(658, 118);
			this.taskCollectionDescriptionTextBox.TabIndex = 0;
			this.taskCollectionDescriptionTextBox.TabStop = false;
			this.taskCollectionDescriptionTextBox.Enter += new System.EventHandler(this.TaskCollectionDescriptionTextBox_Enter);
			this.taskCollectionDescriptionTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TaskCollectionDescriptionTextBox_KeyDown);
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.DefaultExt = "xsd";
			this.saveFileDialog1.FileName = "PerformanceTestToolXmlResult.xsd";
			this.saveFileDialog1.Filter = "Xsd files|*.xsd|All files|*.*";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "xml";
			this.openFileDialog1.Filter = "Result Xml files|*.xml|All files|*.*";
			// 
			// runTasksButton
			// 
			this.runTasksButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.runTasksButton.BackColor = System.Drawing.Color.Transparent;
			this.runTasksButton.Image = global::PerformanceTestTool.Properties.Resources.cog_go;
			this.runTasksButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.runTasksButton.Location = new System.Drawing.Point(597, 430);
			this.runTasksButton.Name = "runTasksButton";
			this.runTasksButton.Size = new System.Drawing.Size(75, 24);
			this.runTasksButton.TabIndex = 0;
			this.runTasksButton.Text = "Start";
			this.runTasksButton.UseVisualStyleBackColor = false;
			this.runTasksButton.Click += new System.EventHandler(this.RunTasksButton_Click);
			// 
			// timeElapsedLabel
			// 
			this.timeElapsedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.timeElapsedLabel.AutoSize = true;
			this.timeElapsedLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.timeElapsedLabel.Location = new System.Drawing.Point(617, 403);
			this.timeElapsedLabel.Name = "timeElapsedLabel";
			this.timeElapsedLabel.Size = new System.Drawing.Size(49, 13);
			this.timeElapsedLabel.TabIndex = 60;
			this.timeElapsedLabel.Text = "00:00:00";
			// 
			// completedLabel
			// 
			this.completedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.completedLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.completedLabel.Location = new System.Drawing.Point(21, 361);
			this.completedLabel.Name = "completedLabel";
			this.completedLabel.Size = new System.Drawing.Size(642, 13);
			this.completedLabel.TabIndex = 59;
			this.completedLabel.Text = "Connections completed";
			this.completedLabel.Visible = false;
			// 
			// completedProgressBar
			// 
			this.completedProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.completedProgressBar.BackColor = System.Drawing.Color.WhiteSmoke;
			this.completedProgressBar.ForeColor = System.Drawing.Color.DarkGray;
			this.completedProgressBar.Location = new System.Drawing.Point(21, 377);
			this.completedProgressBar.Name = "completedProgressBar";
			this.completedProgressBar.Size = new System.Drawing.Size(642, 23);
			this.completedProgressBar.TabIndex = 58;
			// 
			// startedLabel
			// 
			this.startedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.startedLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.startedLabel.Location = new System.Drawing.Point(21, 317);
			this.startedLabel.Name = "startedLabel";
			this.startedLabel.Size = new System.Drawing.Size(642, 13);
			this.startedLabel.TabIndex = 56;
			this.startedLabel.Text = "Connections started";
			this.startedLabel.Visible = false;
			// 
			// statusLabel
			// 
			this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.statusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.statusLabel.Location = new System.Drawing.Point(21, 403);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(590, 13);
			this.statusLabel.TabIndex = 55;
			this.statusLabel.Text = "Status: Idle";
			// 
			// startedProgressBar
			// 
			this.startedProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.startedProgressBar.BackColor = System.Drawing.Color.WhiteSmoke;
			this.startedProgressBar.ForeColor = System.Drawing.Color.DarkGray;
			this.startedProgressBar.Location = new System.Drawing.Point(21, 333);
			this.startedProgressBar.Name = "startedProgressBar";
			this.startedProgressBar.Size = new System.Drawing.Size(642, 23);
			this.startedProgressBar.TabIndex = 54;
			// 
			// tasksTextBox
			// 
			this.tasksTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tasksTextBox.BackColor = System.Drawing.Color.Gray;
			this.tasksTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tasksTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.tasksTextBox.Font = new System.Drawing.Font("Trebuchet MS", 8.25F);
			this.tasksTextBox.ForeColor = System.Drawing.Color.White;
			this.tasksTextBox.Location = new System.Drawing.Point(568, 144);
			this.tasksTextBox.Name = "tasksTextBox";
			this.tasksTextBox.ReadOnly = true;
			this.tasksTextBox.ShortcutsEnabled = false;
			this.tasksTextBox.Size = new System.Drawing.Size(100, 13);
			this.tasksTextBox.TabIndex = 61;
			this.tasksTextBox.TabStop = false;
			this.tasksTextBox.Text = "Tasks:";
			this.tasksTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tasksTextBox.Enter += new System.EventHandler(this.TasksTextBox_Enter);
			// 
			// borderLabel2
			// 
			this.borderLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.borderLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.borderLabel2.Location = new System.Drawing.Point(12, 314);
			this.borderLabel2.Name = "borderLabel2";
			this.borderLabel2.Size = new System.Drawing.Size(660, 106);
			this.borderLabel2.TabIndex = 57;
			// 
			// borderLabel3
			// 
			this.borderLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.borderLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.borderLabel3.Location = new System.Drawing.Point(12, 44);
			this.borderLabel3.Name = "borderLabel3";
			this.borderLabel3.Size = new System.Drawing.Size(660, 90);
			this.borderLabel3.TabIndex = 14;
			// 
			// borderLabel1
			// 
			this.borderLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.borderLabel1.Location = new System.Drawing.Point(12, 164);
			this.borderLabel1.Name = "borderLabel1";
			this.borderLabel1.Size = new System.Drawing.Size(660, 120);
			this.borderLabel1.TabIndex = 17;
			// 
			// MainForm
			// 
			this.AcceptButton = this.runTasksButton;
			this.AllowDrop = true;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Silver;
			this.ClientSize = new System.Drawing.Size(684, 461);
			this.Controls.Add(this.tasksTextBox);
			this.Controls.Add(this.timeElapsedLabel);
			this.Controls.Add(this.completedLabel);
			this.Controls.Add(this.completedProgressBar);
			this.Controls.Add(this.startedLabel);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.startedProgressBar);
			this.Controls.Add(this.borderLabel2);
			this.Controls.Add(this.statusHeaderLabel);
			this.Controls.Add(this.osLabel);
			this.Controls.Add(this.sqlServerHeaderLabel);
			this.Controls.Add(this.versionLabel);
			this.Controls.Add(this.taskCollectionDescriptionTextBox);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.taskCollectionDescriptionHeaderLabel);
			this.Controls.Add(this.maxMemoryLabel);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.runTasksButton);
			this.Controls.Add(this.ramLabel);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.physicalCPULabel);
			this.Controls.Add(this.logicalCPULabel);
			this.Controls.Add(this.borderLabel3);
			this.Controls.Add(this.borderLabel1);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Title";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
			this.DragOver += new System.Windows.Forms.DragEventHandler(this.MainForm_DragOver);
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

	}

	#endregion

	private System.Windows.Forms.Button runTasksButton;
	private System.Windows.Forms.MenuStrip menuStrip1;
	private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem changeConnectionToolStripMenuItem;
	private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
	private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
	private System.Windows.Forms.Timer executionTimeTimer;
	private System.Windows.Forms.Label maxMemoryLabel;
	private System.Windows.Forms.Label label6;
	private System.Windows.Forms.Label label3;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.Label ramLabel;
	private System.Windows.Forms.Label physicalCPULabel;
	private System.Windows.Forms.Label logicalCPULabel;
	private System.Windows.Forms.Label osLabel;
	private System.Windows.Forms.Label versionLabel;
	private System.Windows.Forms.Label label7;
	private System.Windows.Forms.Label label4;
	private System.Windows.Forms.ToolStripMenuItem tasksEditorToolStripMenuItem;
	private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
	private System.Windows.Forms.ToolStripMenuItem stylesheetEditorToolStripMenuItem;
	private System.Windows.Forms.TextBox taskCollectionDescriptionTextBox;
	private System.Windows.Forms.Label taskCollectionDescriptionHeaderLabel;
	private System.Windows.Forms.Label sqlServerHeaderLabel;
	private BorderLabel borderLabel3;
	private System.Windows.Forms.Label statusHeaderLabel;
	private BorderLabel borderLabel1;
	private System.Windows.Forms.SaveFileDialog saveFileDialog1;
	private System.Windows.Forms.ToolStripMenuItem saveXsdToolStripMenuItem;
	private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
	private System.Windows.Forms.ToolStripMenuItem openResultXmlToolStripMenuItem;
	private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
	private System.Windows.Forms.OpenFileDialog openFileDialog1;
	private System.Windows.Forms.ToolStripMenuItem commandLineParametersToolStripMenuItem1;
	private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
	private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
	private System.Windows.Forms.Label timeElapsedLabel;
	private System.Windows.Forms.Label completedLabel;
	private System.Windows.Forms.ProgressBar completedProgressBar;
	private System.Windows.Forms.Label startedLabel;
	private System.Windows.Forms.Label statusLabel;
	private System.Windows.Forms.ProgressBar startedProgressBar;
	private BorderLabel borderLabel2;
	private System.Windows.Forms.TextBox tasksTextBox;
	private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
	private System.Windows.Forms.ToolStripMenuItem recentFilesToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem checkForupdatesToolStripMenuItem;
	private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
	private System.Windows.Forms.ToolStripMenuItem valueSubstitutorToolStripMenuItem;
}
