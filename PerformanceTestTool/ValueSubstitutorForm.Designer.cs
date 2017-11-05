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

partial class ValueSubstitutorForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValueSubstitutorForm));
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.inputHeaderLabel = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.parameterSubstitutionHeaderLabel = new System.Windows.Forms.Label();
			this.parametersDataGridView = new System.Windows.Forms.DataGridView();
			this.ValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ValueTypeColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.ParameterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DataTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.EnabledColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ReplacedValuesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.deleteSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startButton = new System.Windows.Forms.Button();
			this.runProgressBar = new System.Windows.Forms.ProgressBar();
			this.progressHeaderLabel = new System.Windows.Forms.Label();
			this.statusLabel = new System.Windows.Forms.Label();
			this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.parametersToolStrip = new System.Windows.Forms.ToolStrip();
			this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.saveAsToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.inputToolStrip = new System.Windows.Forms.ToolStrip();
			this.openToolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.saveToolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.saveAsToolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.databaseLabel = new System.Windows.Forms.Label();
			this.taskCollectionComboBox = new ComboBoxCustom();
			this.parameterFileComboBox = new ComboBoxCustom();
			this.databaseComboBox = new ComboBoxCustom();
			this.valueSubstitutionBorderLabel = new BorderLabel();
			this.taskCollectionBorderLabel = new BorderLabel();
			this.progressBorderLabel = new BorderLabel();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.parametersDataGridView)).BeginInit();
			this.contextMenuStrip2.SuspendLayout();
			this.parametersToolStrip.SuspendLayout();
			this.inputToolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "xml";
			this.openFileDialog1.Filter = "Task Collection files|*.xml|All files|*.*";
			this.openFileDialog1.Title = "Open Task Collection file";
			// 
			// inputHeaderLabel
			// 
			this.inputHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.inputHeaderLabel.BackColor = System.Drawing.Color.Gray;
			this.inputHeaderLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.inputHeaderLabel.ForeColor = System.Drawing.Color.White;
			this.inputHeaderLabel.Location = new System.Drawing.Point(12, 24);
			this.inputHeaderLabel.Name = "inputHeaderLabel";
			this.inputHeaderLabel.Size = new System.Drawing.Size(660, 17);
			this.inputHeaderLabel.TabIndex = 54;
			this.inputHeaderLabel.Text = "::: Task Collection :::::::";
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(684, 24);
			this.menuStrip1.TabIndex = 55;
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
			// parameterSubstitutionHeaderLabel
			// 
			this.parameterSubstitutionHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.parameterSubstitutionHeaderLabel.BackColor = System.Drawing.Color.Gray;
			this.parameterSubstitutionHeaderLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.parameterSubstitutionHeaderLabel.ForeColor = System.Drawing.Color.White;
			this.parameterSubstitutionHeaderLabel.Location = new System.Drawing.Point(12, 97);
			this.parameterSubstitutionHeaderLabel.Name = "parameterSubstitutionHeaderLabel";
			this.parameterSubstitutionHeaderLabel.Size = new System.Drawing.Size(660, 17);
			this.parameterSubstitutionHeaderLabel.TabIndex = 57;
			this.parameterSubstitutionHeaderLabel.Text = "::: Value substitution :::::::";
			// 
			// parametersDataGridView
			// 
			this.parametersDataGridView.AllowDrop = true;
			this.parametersDataGridView.AllowUserToResizeRows = false;
			this.parametersDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.parametersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.parametersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ValueColumn,
            this.ValueTypeColumn,
            this.ParameterColumn,
            this.DataTypeColumn,
            this.EnabledColumn,
            this.ReplacedValuesColumn});
			this.parametersDataGridView.ContextMenuStrip = this.contextMenuStrip2;
			this.parametersDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.parametersDataGridView.Location = new System.Drawing.Point(21, 155);
			this.parametersDataGridView.Name = "parametersDataGridView";
			this.parametersDataGridView.Size = new System.Drawing.Size(642, 76);
			this.parametersDataGridView.TabIndex = 3;
			this.parametersDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.ParametersDataGridView_DataError);
			this.parametersDataGridView.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.ParametersDataGridView_DefaultValuesNeeded);
			this.parametersDataGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.ParametersDataGridView_DragDrop);
			this.parametersDataGridView.DragOver += new System.Windows.Forms.DragEventHandler(this.ParametersDataGridView_DragOver);
			this.parametersDataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ParametersDataGridView_MouseDown);
			// 
			// ValueColumn
			// 
			this.ValueColumn.HeaderText = "Value";
			this.ValueColumn.MinimumWidth = 90;
			this.ValueColumn.Name = "ValueColumn";
			this.ValueColumn.Width = 140;
			// 
			// ValueTypeColumn
			// 
			this.ValueTypeColumn.HeaderText = "Value Type";
			this.ValueTypeColumn.Items.AddRange(new object[] {
            "Normal",
            "RegEx"});
			this.ValueTypeColumn.MinimumWidth = 90;
			this.ValueTypeColumn.Name = "ValueTypeColumn";
			this.ValueTypeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.ValueTypeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.ValueTypeColumn.Width = 90;
			// 
			// ParameterColumn
			// 
			this.ParameterColumn.HeaderText = "Parameter";
			this.ParameterColumn.MinimumWidth = 90;
			this.ParameterColumn.Name = "ParameterColumn";
			this.ParameterColumn.Width = 140;
			// 
			// DataTypeColumn
			// 
			this.DataTypeColumn.HeaderText = "Data Type";
			this.DataTypeColumn.MinimumWidth = 90;
			this.DataTypeColumn.Name = "DataTypeColumn";
			this.DataTypeColumn.Width = 90;
			// 
			// EnabledColumn
			// 
			this.EnabledColumn.HeaderText = "Enabled";
			this.EnabledColumn.MinimumWidth = 80;
			this.EnabledColumn.Name = "EnabledColumn";
			this.EnabledColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.EnabledColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.EnabledColumn.Width = 80;
			// 
			// ReplacedValuesColumn
			// 
			this.ReplacedValuesColumn.HeaderText = "Hits";
			this.ReplacedValuesColumn.MinimumWidth = 50;
			this.ReplacedValuesColumn.Name = "ReplacedValuesColumn";
			this.ReplacedValuesColumn.ReadOnly = true;
			this.ReplacedValuesColumn.Width = 50;
			// 
			// contextMenuStrip2
			// 
			this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteSelectedToolStripMenuItem});
			this.contextMenuStrip2.Name = "contextMenuStrip2";
			this.contextMenuStrip2.Size = new System.Drawing.Size(154, 26);
			// 
			// deleteSelectedToolStripMenuItem
			// 
			this.deleteSelectedToolStripMenuItem.Name = "deleteSelectedToolStripMenuItem";
			this.deleteSelectedToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.deleteSelectedToolStripMenuItem.Text = "Delete selected";
			this.deleteSelectedToolStripMenuItem.Click += new System.EventHandler(this.DeleteSelectedToolStripMenuItem_Click);
			// 
			// startButton
			// 
			this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.startButton.BackColor = System.Drawing.Color.Transparent;
			this.startButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.startButton.Location = new System.Drawing.Point(597, 373);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(75, 24);
			this.startButton.TabIndex = 5;
			this.startButton.Text = "Start";
			this.startButton.UseVisualStyleBackColor = false;
			this.startButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// runProgressBar
			// 
			this.runProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.runProgressBar.BackColor = System.Drawing.Color.WhiteSmoke;
			this.runProgressBar.Location = new System.Drawing.Point(21, 321);
			this.runProgressBar.Name = "runProgressBar";
			this.runProgressBar.Size = new System.Drawing.Size(642, 23);
			this.runProgressBar.TabIndex = 58;
			// 
			// progressHeaderLabel
			// 
			this.progressHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressHeaderLabel.BackColor = System.Drawing.Color.Gray;
			this.progressHeaderLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.progressHeaderLabel.ForeColor = System.Drawing.Color.White;
			this.progressHeaderLabel.Location = new System.Drawing.Point(12, 279);
			this.progressHeaderLabel.Name = "progressHeaderLabel";
			this.progressHeaderLabel.Size = new System.Drawing.Size(660, 17);
			this.progressHeaderLabel.TabIndex = 61;
			this.progressHeaderLabel.Text = "::: Progress :::::::";
			// 
			// statusLabel
			// 
			this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.statusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.statusLabel.Location = new System.Drawing.Point(21, 347);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(590, 13);
			this.statusLabel.TabIndex = 62;
			this.statusLabel.Text = "Status: Idle";
			// 
			// saveFileDialog2
			// 
			this.saveFileDialog2.Filter = "Xml files|*.xml|All files|*.*";
			// 
			// openFileDialog2
			// 
			this.openFileDialog2.Filter = "Xml files|*.xml|All files|*.*";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.Filter = "Task Collection files|*.xml|All files|*.*";
			this.saveFileDialog1.Title = "Save Task Collection file";
			// 
			// parametersToolStrip
			// 
			this.parametersToolStrip.AllowDrop = true;
			this.parametersToolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.parametersToolStrip.AutoSize = false;
			this.parametersToolStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.parametersToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.saveAsToolStripButton});
			this.parametersToolStrip.Location = new System.Drawing.Point(21, 126);
			this.parametersToolStrip.Name = "parametersToolStrip";
			this.parametersToolStrip.Size = new System.Drawing.Size(642, 25);
			this.parametersToolStrip.TabIndex = 2;
			this.parametersToolStrip.Text = "toolStrip1";
			this.parametersToolStrip.DragDrop += new System.Windows.Forms.DragEventHandler(this.ParametersToolStrip_DragDrop);
			this.parametersToolStrip.DragOver += new System.Windows.Forms.DragEventHandler(this.ParametersToolStrip_DragOver);
			// 
			// newToolStripButton
			// 
			this.newToolStripButton.Image = global::PerformanceTestTool.Properties.Resources.page_add_small;
			this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripButton.Name = "newToolStripButton";
			this.newToolStripButton.Size = new System.Drawing.Size(51, 22);
			this.newToolStripButton.Text = "New";
			this.newToolStripButton.Click += new System.EventHandler(this.NewToolStripButton_Click);
			// 
			// openToolStripButton
			// 
			this.openToolStripButton.Image = global::PerformanceTestTool.Properties.Resources.folder;
			this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripButton.Name = "openToolStripButton";
			this.openToolStripButton.Size = new System.Drawing.Size(65, 22);
			this.openToolStripButton.Text = "Open...";
			this.openToolStripButton.Click += new System.EventHandler(this.OpenToolStripButton_Click);
			// 
			// saveToolStripButton
			// 
			this.saveToolStripButton.Enabled = false;
			this.saveToolStripButton.Image = global::PerformanceTestTool.Properties.Resources.disk;
			this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripButton.Name = "saveToolStripButton";
			this.saveToolStripButton.Size = new System.Drawing.Size(51, 22);
			this.saveToolStripButton.Text = "Save";
			this.saveToolStripButton.Click += new System.EventHandler(this.SaveToolStripButton_Click);
			// 
			// saveAsToolStripButton
			// 
			this.saveAsToolStripButton.Enabled = false;
			this.saveAsToolStripButton.Image = global::PerformanceTestTool.Properties.Resources.disk;
			this.saveAsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveAsToolStripButton.Name = "saveAsToolStripButton";
			this.saveAsToolStripButton.Size = new System.Drawing.Size(76, 22);
			this.saveAsToolStripButton.Text = "Save As...";
			this.saveAsToolStripButton.Click += new System.EventHandler(this.SaveAsToolStripButton_Click);
			// 
			// inputToolStrip
			// 
			this.inputToolStrip.AllowDrop = true;
			this.inputToolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.inputToolStrip.AutoSize = false;
			this.inputToolStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.inputToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton1,
            this.saveToolStripButton1,
            this.saveAsToolStripButton1});
			this.inputToolStrip.Location = new System.Drawing.Point(21, 53);
			this.inputToolStrip.Name = "inputToolStrip";
			this.inputToolStrip.Size = new System.Drawing.Size(642, 25);
			this.inputToolStrip.TabIndex = 0;
			this.inputToolStrip.Text = "toolStrip1";
			this.inputToolStrip.DragDrop += new System.Windows.Forms.DragEventHandler(this.InputToolStrip_DragDrop);
			this.inputToolStrip.DragOver += new System.Windows.Forms.DragEventHandler(this.InputToolStrip_DragOver);
			// 
			// openToolStripButton1
			// 
			this.openToolStripButton1.Image = global::PerformanceTestTool.Properties.Resources.folder;
			this.openToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripButton1.Name = "openToolStripButton1";
			this.openToolStripButton1.Size = new System.Drawing.Size(65, 22);
			this.openToolStripButton1.Text = "Open...";
			this.openToolStripButton1.Click += new System.EventHandler(this.OpenToolStripButton1_Click);
			// 
			// saveToolStripButton1
			// 
			this.saveToolStripButton1.Enabled = false;
			this.saveToolStripButton1.Image = global::PerformanceTestTool.Properties.Resources.disk;
			this.saveToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripButton1.Name = "saveToolStripButton1";
			this.saveToolStripButton1.Size = new System.Drawing.Size(51, 22);
			this.saveToolStripButton1.Text = "Save";
			this.saveToolStripButton1.Click += new System.EventHandler(this.SaveToolStripButton1_Click);
			// 
			// saveAsToolStripButton1
			// 
			this.saveAsToolStripButton1.Enabled = false;
			this.saveAsToolStripButton1.Image = global::PerformanceTestTool.Properties.Resources.disk;
			this.saveAsToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveAsToolStripButton1.Name = "saveAsToolStripButton1";
			this.saveAsToolStripButton1.Size = new System.Drawing.Size(76, 22);
			this.saveAsToolStripButton1.Text = "Save As...";
			this.saveAsToolStripButton1.Click += new System.EventHandler(this.SaveAsToolStripButton1_Click);
			// 
			// databaseLabel
			// 
			this.databaseLabel.AllowDrop = true;
			this.databaseLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.databaseLabel.AutoSize = true;
			this.databaseLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.databaseLabel.Location = new System.Drawing.Point(19, 242);
			this.databaseLabel.Name = "databaseLabel";
			this.databaseLabel.Size = new System.Drawing.Size(85, 13);
			this.databaseLabel.TabIndex = 64;
			this.databaseLabel.Text = "Database name:";
			this.databaseLabel.DragDrop += new System.Windows.Forms.DragEventHandler(this.DatabaseLabel_DragDrop);
			this.databaseLabel.DragOver += new System.Windows.Forms.DragEventHandler(this.DatabaseLabel_DragOver);
			// 
			// taskCollectionComboBox
			// 
			this.taskCollectionComboBox.AllowDrop = true;
			this.taskCollectionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.taskCollectionComboBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.taskCollectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.taskCollectionComboBox.FormattingEnabled = true;
			this.taskCollectionComboBox.Location = new System.Drawing.Point(284, 55);
			this.taskCollectionComboBox.Name = "taskCollectionComboBox";
			this.taskCollectionComboBox.Size = new System.Drawing.Size(370, 21);
			this.taskCollectionComboBox.TabIndex = 1;
			this.taskCollectionComboBox.TabStop = false;
			this.taskCollectionComboBox.SelectionChangeCommitted += new System.EventHandler(this.TaskCollectionComboBox_SelectionChangeCommitted);
			this.taskCollectionComboBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.TaskCollectionComboBox_DragDrop);
			this.taskCollectionComboBox.DragOver += new System.Windows.Forms.DragEventHandler(this.TaskCollectionComboBox_DragOver);
			// 
			// parameterFileComboBox
			// 
			this.parameterFileComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.parameterFileComboBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.parameterFileComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.parameterFileComboBox.FormattingEnabled = true;
			this.parameterFileComboBox.Location = new System.Drawing.Point(284, 128);
			this.parameterFileComboBox.Name = "parameterFileComboBox";
			this.parameterFileComboBox.Size = new System.Drawing.Size(370, 21);
			this.parameterFileComboBox.TabIndex = 65;
			this.parameterFileComboBox.TabStop = false;
			this.parameterFileComboBox.SelectionChangeCommitted += new System.EventHandler(this.ParameterFileComboBox_SelectionChangeCommitted);
			// 
			// databaseComboBox
			// 
			this.databaseComboBox.AllowDrop = true;
			this.databaseComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.databaseComboBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.databaseComboBox.FormattingEnabled = true;
			this.databaseComboBox.Location = new System.Drawing.Point(108, 239);
			this.databaseComboBox.Name = "databaseComboBox";
			this.databaseComboBox.Size = new System.Drawing.Size(555, 21);
			this.databaseComboBox.TabIndex = 4;
			this.databaseComboBox.TextChanged += new System.EventHandler(this.DatabaseComboBox_TextChanged);
			this.databaseComboBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.DatabaseComboBox_DragDrop);
			this.databaseComboBox.DragOver += new System.Windows.Forms.DragEventHandler(this.DatabaseComboBox_DragOver);
			// 
			// valueSubstitutionBorderLabel
			// 
			this.valueSubstitutionBorderLabel.AllowDrop = true;
			this.valueSubstitutionBorderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.valueSubstitutionBorderLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.valueSubstitutionBorderLabel.Location = new System.Drawing.Point(12, 117);
			this.valueSubstitutionBorderLabel.Name = "valueSubstitutionBorderLabel";
			this.valueSubstitutionBorderLabel.Size = new System.Drawing.Size(660, 152);
			this.valueSubstitutionBorderLabel.TabIndex = 56;
			this.valueSubstitutionBorderLabel.DragDrop += new System.Windows.Forms.DragEventHandler(this.ValueSubstitutionBorderLabel_DragDrop);
			this.valueSubstitutionBorderLabel.DragOver += new System.Windows.Forms.DragEventHandler(this.ValueSubstitutionBorderLabel_DragOver);
			// 
			// taskCollectionBorderLabel
			// 
			this.taskCollectionBorderLabel.AllowDrop = true;
			this.taskCollectionBorderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.taskCollectionBorderLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.taskCollectionBorderLabel.Location = new System.Drawing.Point(12, 44);
			this.taskCollectionBorderLabel.Name = "taskCollectionBorderLabel";
			this.taskCollectionBorderLabel.Size = new System.Drawing.Size(660, 43);
			this.taskCollectionBorderLabel.TabIndex = 52;
			this.taskCollectionBorderLabel.DragDrop += new System.Windows.Forms.DragEventHandler(this.TaskCollectionBorderLabel_DragDrop);
			this.taskCollectionBorderLabel.DragOver += new System.Windows.Forms.DragEventHandler(this.TaskCollectionBorderLabel_DragOver);
			// 
			// progressBorderLabel
			// 
			this.progressBorderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBorderLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.progressBorderLabel.Location = new System.Drawing.Point(12, 299);
			this.progressBorderLabel.Name = "progressBorderLabel";
			this.progressBorderLabel.Size = new System.Drawing.Size(660, 65);
			this.progressBorderLabel.TabIndex = 60;
			// 
			// ValueSubstitutorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Silver;
			this.ClientSize = new System.Drawing.Size(684, 405);
			this.Controls.Add(this.taskCollectionComboBox);
			this.Controls.Add(this.parameterFileComboBox);
			this.Controls.Add(this.databaseComboBox);
			this.Controls.Add(this.databaseLabel);
			this.Controls.Add(this.inputToolStrip);
			this.Controls.Add(this.parametersToolStrip);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.progressHeaderLabel);
			this.Controls.Add(this.runProgressBar);
			this.Controls.Add(this.startButton);
			this.Controls.Add(this.parametersDataGridView);
			this.Controls.Add(this.parameterSubstitutionHeaderLabel);
			this.Controls.Add(this.valueSubstitutionBorderLabel);
			this.Controls.Add(this.inputHeaderLabel);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.taskCollectionBorderLabel);
			this.Controls.Add(this.progressBorderLabel);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "ValueSubstitutorForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Value Substitutor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ValueSubstitutorForm_FormClosing);
			this.Resize += new System.EventHandler(this.ValueSubstitutorForm_Resize);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.parametersDataGridView)).EndInit();
			this.contextMenuStrip2.ResumeLayout(false);
			this.parametersToolStrip.ResumeLayout(false);
			this.parametersToolStrip.PerformLayout();
			this.inputToolStrip.ResumeLayout(false);
			this.inputToolStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

	}

	#endregion
	private System.Windows.Forms.OpenFileDialog openFileDialog1;
	private BorderLabel taskCollectionBorderLabel;
	private System.Windows.Forms.Label inputHeaderLabel;
	private System.Windows.Forms.MenuStrip menuStrip1;
	private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
	private System.Windows.Forms.Label parameterSubstitutionHeaderLabel;
	private BorderLabel valueSubstitutionBorderLabel;
	private System.Windows.Forms.DataGridView parametersDataGridView;
	private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
	private System.Windows.Forms.ToolStripMenuItem deleteSelectedToolStripMenuItem;
	private System.Windows.Forms.Button startButton;
	private ComboBoxCustom taskCollectionComboBox;
	private System.Windows.Forms.ProgressBar runProgressBar;
	private System.Windows.Forms.Label progressHeaderLabel;
	private BorderLabel progressBorderLabel;
	private System.Windows.Forms.Label statusLabel;
	private System.Windows.Forms.SaveFileDialog saveFileDialog2;
	private System.Windows.Forms.OpenFileDialog openFileDialog2;
	private System.Windows.Forms.SaveFileDialog saveFileDialog1;
	private System.Windows.Forms.ToolStrip parametersToolStrip;
	private System.Windows.Forms.ToolStripButton newToolStripButton;
	private System.Windows.Forms.ToolStripButton openToolStripButton;
	private System.Windows.Forms.ToolStripButton saveToolStripButton;
	private System.Windows.Forms.ToolStripButton saveAsToolStripButton;
	private System.Windows.Forms.ToolStrip inputToolStrip;
	private System.Windows.Forms.ToolStripButton openToolStripButton1;
	private System.Windows.Forms.ToolStripButton saveToolStripButton1;
	private System.Windows.Forms.ToolStripButton saveAsToolStripButton1;
	private ComboBoxCustom databaseComboBox;
	private System.Windows.Forms.Label databaseLabel;
	private ComboBoxCustom parameterFileComboBox;
	private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn;
	private System.Windows.Forms.DataGridViewComboBoxColumn ValueTypeColumn;
	private System.Windows.Forms.DataGridViewTextBoxColumn ParameterColumn;
	private System.Windows.Forms.DataGridViewTextBoxColumn DataTypeColumn;
	private System.Windows.Forms.DataGridViewCheckBoxColumn EnabledColumn;
	private System.Windows.Forms.DataGridViewTextBoxColumn ReplacedValuesColumn;
}
