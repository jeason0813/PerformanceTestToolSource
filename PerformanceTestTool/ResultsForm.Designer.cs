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

partial class ResultsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultsForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openResultXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveStylesheetAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.pageSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.recentFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.xmlWebBrowser = new System.Windows.Forms.WebBrowser();
			this.resultsXmlHeaderLabel = new System.Windows.Forms.Label();
			this.descriptionTextBox = new System.Windows.Forms.TextBox();
			this.transformedStylesheetHeaderLabel = new System.Windows.Forms.Label();
			this.stylesheetHeaderLabel = new System.Windows.Forms.Label();
			this.stylesheetWebBrowser = new System.Windows.Forms.WebBrowser();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tabControlEX2 = new Dotnetrix.Controls.TabControlEX();
			this.dataTabPage = new Dotnetrix.Controls.TabPageEX();
			this.dataHeaderLabel = new System.Windows.Forms.Label();
			this.tabControlEX1 = new Dotnetrix.Controls.TabControlEX();
			this.performanceCountersTabPage = new Dotnetrix.Controls.TabPageEX();
			this.removeZeroDeltaCheckBox = new System.Windows.Forms.CheckBox();
			this.removeAllZeroColumnsCheckBox = new System.Windows.Forms.CheckBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.shownTextBox = new System.Windows.Forms.TextBox();
			this.filterHeaderLabel = new System.Windows.Forms.Label();
			this.clearButton = new System.Windows.Forms.Button();
			this.applyFilterButton = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.performanceCounterResultsHeaderLabel = new System.Windows.Forms.Label();
			this.performanceCounterListView = new System.Windows.Forms.ListView();
			this.performanceCounterObjectNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.performanceCounterCounterNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.performanceCounterInstanceNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.performanceCounterMinimumColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.performanceCounterMaximumColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.performanceCounterAverageColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.performanceCounterDeltaColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.xmlTabPage = new Dotnetrix.Controls.TabPageEX();
			this.htmlTabPage = new Dotnetrix.Controls.TabPageEX();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.instanceNameComboBox = new ComboBoxCustom();
			this.counterNameComboBox = new ComboBoxCustom();
			this.objectNameComboBox = new ComboBoxCustom();
			this.borderLabel5 = new BorderLabel();
			this.borderLabel6 = new BorderLabel();
			this.borderLabel3 = new BorderLabel();
			this.stylesheetComboBox = new ComboBoxCustom();
			this.borderLabel2 = new BorderLabel();
			this.borderLabel4 = new BorderLabel();
			this.borderLabel1 = new BorderLabel();
			this.menuStrip1.SuspendLayout();
			this.tabControlEX2.SuspendLayout();
			this.dataTabPage.SuspendLayout();
			this.performanceCountersTabPage.SuspendLayout();
			this.xmlTabPage.SuspendLayout();
			this.htmlTabPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(684, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openResultXmlToolStripMenuItem,
            this.toolStripSeparator3,
            this.saveAsToolStripMenuItem,
            this.saveStylesheetAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.pageSetupToolStripMenuItem,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.recentFilesToolStripMenuItem,
            this.toolStripSeparator4,
            this.closeToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// openResultXmlToolStripMenuItem
			// 
			this.openResultXmlToolStripMenuItem.Image = global::PerformanceTestTool.Properties.Resources.folder;
			this.openResultXmlToolStripMenuItem.Name = "openResultXmlToolStripMenuItem";
			this.openResultXmlToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openResultXmlToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
			this.openResultXmlToolStripMenuItem.Text = "&Open Result Xml...";
			this.openResultXmlToolStripMenuItem.Click += new System.EventHandler(this.OpenResultXmlToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(283, 6);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Image = global::PerformanceTestTool.Properties.Resources.disk;
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
			this.saveAsToolStripMenuItem.Text = "Save Result &Xml As...";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
			// 
			// saveStylesheetAsToolStripMenuItem
			// 
			this.saveStylesheetAsToolStripMenuItem.Enabled = false;
			this.saveStylesheetAsToolStripMenuItem.Image = global::PerformanceTestTool.Properties.Resources.disk;
			this.saveStylesheetAsToolStripMenuItem.Name = "saveStylesheetAsToolStripMenuItem";
			this.saveStylesheetAsToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
			this.saveStylesheetAsToolStripMenuItem.Text = "Save Active Transformed &Stylesheet As...";
			this.saveStylesheetAsToolStripMenuItem.Click += new System.EventHandler(this.SaveStylesheetAsToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(283, 6);
			// 
			// pageSetupToolStripMenuItem
			// 
			this.pageSetupToolStripMenuItem.Enabled = false;
			this.pageSetupToolStripMenuItem.Name = "pageSetupToolStripMenuItem";
			this.pageSetupToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
			this.pageSetupToolStripMenuItem.Text = "Page Set&up...";
			this.pageSetupToolStripMenuItem.Click += new System.EventHandler(this.PageSetupToolStripMenuItem_Click);
			// 
			// printToolStripMenuItem
			// 
			this.printToolStripMenuItem.Enabled = false;
			this.printToolStripMenuItem.Name = "printToolStripMenuItem";
			this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
			this.printToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
			this.printToolStripMenuItem.Text = "&Print...";
			this.printToolStripMenuItem.Click += new System.EventHandler(this.PrintToolStripMenuItem_Click);
			// 
			// printPreviewToolStripMenuItem
			// 
			this.printPreviewToolStripMenuItem.Enabled = false;
			this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
			this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
			this.printPreviewToolStripMenuItem.Text = "Print Pre&view...";
			this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.PrintPreviewToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(283, 6);
			// 
			// recentFilesToolStripMenuItem
			// 
			this.recentFilesToolStripMenuItem.Name = "recentFilesToolStripMenuItem";
			this.recentFilesToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
			this.recentFilesToolStripMenuItem.Text = "&Recent Files";
			this.recentFilesToolStripMenuItem.DropDownOpening += new System.EventHandler(this.RecentFilesToolStripMenuItem_DropDownOpening);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(283, 6);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
			this.closeToolStripMenuItem.Text = "&Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "&Edit";
			// 
			// searchToolStripMenuItem
			// 
			this.searchToolStripMenuItem.Enabled = false;
			this.searchToolStripMenuItem.Image = global::PerformanceTestTool.Properties.Resources.find_small;
			this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
			this.searchToolStripMenuItem.ShortcutKeyDisplayString = "";
			this.searchToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
			this.searchToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.searchToolStripMenuItem.Text = "&Find";
			this.searchToolStripMenuItem.Click += new System.EventHandler(this.SearchToolStripMenuItem_Click);
			// 
			// xmlWebBrowser
			// 
			this.xmlWebBrowser.AllowNavigation = false;
			this.xmlWebBrowser.AllowWebBrowserDrop = false;
			this.xmlWebBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.xmlWebBrowser.Location = new System.Drawing.Point(1, 22);
			this.xmlWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.xmlWebBrowser.Name = "xmlWebBrowser";
			this.xmlWebBrowser.Size = new System.Drawing.Size(674, 383);
			this.xmlWebBrowser.TabIndex = 2;
			// 
			// resultsXmlHeaderLabel
			// 
			this.resultsXmlHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.resultsXmlHeaderLabel.BackColor = System.Drawing.Color.Gray;
			this.resultsXmlHeaderLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.resultsXmlHeaderLabel.ForeColor = System.Drawing.Color.White;
			this.resultsXmlHeaderLabel.Location = new System.Drawing.Point(0, 1);
			this.resultsXmlHeaderLabel.Name = "resultsXmlHeaderLabel";
			this.resultsXmlHeaderLabel.Size = new System.Drawing.Size(676, 17);
			this.resultsXmlHeaderLabel.TabIndex = 14;
			this.resultsXmlHeaderLabel.Text = "::: Result Xml :::::::";
			// 
			// descriptionTextBox
			// 
			this.descriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.descriptionTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.descriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.descriptionTextBox.Location = new System.Drawing.Point(76, 55);
			this.descriptionTextBox.Multiline = true;
			this.descriptionTextBox.Name = "descriptionTextBox";
			this.descriptionTextBox.ReadOnly = true;
			this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.descriptionTextBox.Size = new System.Drawing.Size(592, 33);
			this.descriptionTextBox.TabIndex = 2;
			this.descriptionTextBox.TabStop = false;
			this.descriptionTextBox.Enter += new System.EventHandler(this.DescriptionTextBox_Enter);
			this.descriptionTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DescriptionTextBox_KeyDown);
			// 
			// transformedStylesheetHeaderLabel
			// 
			this.transformedStylesheetHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.transformedStylesheetHeaderLabel.BackColor = System.Drawing.Color.Gray;
			this.transformedStylesheetHeaderLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.transformedStylesheetHeaderLabel.ForeColor = System.Drawing.Color.White;
			this.transformedStylesheetHeaderLabel.Location = new System.Drawing.Point(1, 108);
			this.transformedStylesheetHeaderLabel.Name = "transformedStylesheetHeaderLabel";
			this.transformedStylesheetHeaderLabel.Size = new System.Drawing.Size(675, 17);
			this.transformedStylesheetHeaderLabel.TabIndex = 18;
			this.transformedStylesheetHeaderLabel.Text = "::: Transformed Stylesheet :::::::";
			// 
			// stylesheetHeaderLabel
			// 
			this.stylesheetHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.stylesheetHeaderLabel.BackColor = System.Drawing.Color.Gray;
			this.stylesheetHeaderLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.stylesheetHeaderLabel.ForeColor = System.Drawing.Color.White;
			this.stylesheetHeaderLabel.Location = new System.Drawing.Point(0, 1);
			this.stylesheetHeaderLabel.Name = "stylesheetHeaderLabel";
			this.stylesheetHeaderLabel.Size = new System.Drawing.Size(676, 17);
			this.stylesheetHeaderLabel.TabIndex = 15;
			this.stylesheetHeaderLabel.Text = "::: Stylesheet :::::::";
			// 
			// stylesheetWebBrowser
			// 
			this.stylesheetWebBrowser.AllowWebBrowserDrop = false;
			this.stylesheetWebBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.stylesheetWebBrowser.Location = new System.Drawing.Point(1, 129);
			this.stylesheetWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.stylesheetWebBrowser.Name = "stylesheetWebBrowser";
			this.stylesheetWebBrowser.Size = new System.Drawing.Size(674, 276);
			this.stylesheetWebBrowser.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.label2.Location = new System.Drawing.Point(6, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Description:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.label1.Location = new System.Drawing.Point(6, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Stylesheet:";
			// 
			// tabControlEX2
			// 
			this.tabControlEX2.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.tabControlEX2.Appearance = Dotnetrix.Controls.TabAppearanceEX.FlatTab;
			this.tabControlEX2.BackColor = System.Drawing.Color.Silver;
			this.tabControlEX2.Controls.Add(this.dataTabPage);
			this.tabControlEX2.Controls.Add(this.performanceCountersTabPage);
			this.tabControlEX2.Controls.Add(this.xmlTabPage);
			this.tabControlEX2.Controls.Add(this.htmlTabPage);
			this.tabControlEX2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlEX2.ForeColor = System.Drawing.Color.Black;
			this.tabControlEX2.ItemSize = new System.Drawing.Size(54, 21);
			this.tabControlEX2.Location = new System.Drawing.Point(0, 24);
			this.tabControlEX2.Name = "tabControlEX2";
			this.tabControlEX2.SelectedIndex = 0;
			this.tabControlEX2.SelectedTabColor = System.Drawing.Color.Silver;
			this.tabControlEX2.Size = new System.Drawing.Size(684, 437);
			this.tabControlEX2.TabColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.tabControlEX2.TabIndex = 1;
			this.tabControlEX2.UseVisualStyles = false;
			this.tabControlEX2.SelectedIndexChanged += new System.EventHandler(this.TabControlEX2_SelectedIndexChanged);
			// 
			// dataTabPage
			// 
			this.dataTabPage.Controls.Add(this.dataHeaderLabel);
			this.dataTabPage.Controls.Add(this.tabControlEX1);
			this.dataTabPage.Location = new System.Drawing.Point(4, 4);
			this.dataTabPage.Name = "dataTabPage";
			this.dataTabPage.Size = new System.Drawing.Size(676, 408);
			this.dataTabPage.TabIndex = 0;
			this.dataTabPage.Text = "Data";
			// 
			// dataHeaderLabel
			// 
			this.dataHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataHeaderLabel.BackColor = System.Drawing.Color.Gray;
			this.dataHeaderLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dataHeaderLabel.ForeColor = System.Drawing.Color.White;
			this.dataHeaderLabel.Location = new System.Drawing.Point(0, 1);
			this.dataHeaderLabel.Name = "dataHeaderLabel";
			this.dataHeaderLabel.Size = new System.Drawing.Size(676, 17);
			this.dataHeaderLabel.TabIndex = 15;
			this.dataHeaderLabel.Text = "::: Data :::::::";
			// 
			// tabControlEX1
			// 
			this.tabControlEX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControlEX1.Appearance = Dotnetrix.Controls.TabAppearanceEX.FlatTab;
			this.tabControlEX1.BackColor = System.Drawing.Color.Silver;
			this.tabControlEX1.ItemSize = new System.Drawing.Size(54, 21);
			this.tabControlEX1.Location = new System.Drawing.Point(1, 21);
			this.tabControlEX1.Name = "tabControlEX1";
			this.tabControlEX1.SelectedTabColor = System.Drawing.Color.Silver;
			this.tabControlEX1.ShowToolTips = true;
			this.tabControlEX1.Size = new System.Drawing.Size(675, 384);
			this.tabControlEX1.TabColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.tabControlEX1.TabIndex = 0;
			this.tabControlEX1.UseVisualStyles = false;
			this.tabControlEX1.SelectedIndexChanged += new System.EventHandler(this.TabControlEX1_SelectedIndexChanged);
			// 
			// performanceCountersTabPage
			// 
			this.performanceCountersTabPage.Controls.Add(this.instanceNameComboBox);
			this.performanceCountersTabPage.Controls.Add(this.counterNameComboBox);
			this.performanceCountersTabPage.Controls.Add(this.objectNameComboBox);
			this.performanceCountersTabPage.Controls.Add(this.removeZeroDeltaCheckBox);
			this.performanceCountersTabPage.Controls.Add(this.removeAllZeroColumnsCheckBox);
			this.performanceCountersTabPage.Controls.Add(this.linkLabel1);
			this.performanceCountersTabPage.Controls.Add(this.shownTextBox);
			this.performanceCountersTabPage.Controls.Add(this.filterHeaderLabel);
			this.performanceCountersTabPage.Controls.Add(this.clearButton);
			this.performanceCountersTabPage.Controls.Add(this.applyFilterButton);
			this.performanceCountersTabPage.Controls.Add(this.label5);
			this.performanceCountersTabPage.Controls.Add(this.label4);
			this.performanceCountersTabPage.Controls.Add(this.label3);
			this.performanceCountersTabPage.Controls.Add(this.performanceCounterResultsHeaderLabel);
			this.performanceCountersTabPage.Controls.Add(this.performanceCounterListView);
			this.performanceCountersTabPage.Controls.Add(this.borderLabel5);
			this.performanceCountersTabPage.Controls.Add(this.borderLabel6);
			this.performanceCountersTabPage.Location = new System.Drawing.Point(4, 4);
			this.performanceCountersTabPage.Name = "performanceCountersTabPage";
			this.performanceCountersTabPage.Size = new System.Drawing.Size(676, 408);
			this.performanceCountersTabPage.TabIndex = 3;
			this.performanceCountersTabPage.Text = "Performance Counters";
			// 
			// removeZeroDeltaCheckBox
			// 
			this.removeZeroDeltaCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.removeZeroDeltaCheckBox.AutoSize = true;
			this.removeZeroDeltaCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.removeZeroDeltaCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.removeZeroDeltaCheckBox.Location = new System.Drawing.Point(511, 353);
			this.removeZeroDeltaCheckBox.Name = "removeZeroDeltaCheckBox";
			this.removeZeroDeltaCheckBox.Size = new System.Drawing.Size(157, 17);
			this.removeZeroDeltaCheckBox.TabIndex = 7;
			this.removeZeroDeltaCheckBox.Text = "Remove zero delta columns";
			this.removeZeroDeltaCheckBox.UseVisualStyleBackColor = false;
			// 
			// removeAllZeroColumnsCheckBox
			// 
			this.removeAllZeroColumnsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.removeAllZeroColumnsCheckBox.AutoSize = true;
			this.removeAllZeroColumnsCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.removeAllZeroColumnsCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.removeAllZeroColumnsCheckBox.Location = new System.Drawing.Point(511, 330);
			this.removeAllZeroColumnsCheckBox.Name = "removeAllZeroColumnsCheckBox";
			this.removeAllZeroColumnsCheckBox.Size = new System.Drawing.Size(160, 17);
			this.removeAllZeroColumnsCheckBox.TabIndex = 6;
			this.removeAllZeroColumnsCheckBox.Text = "Remove zero value columns";
			this.removeAllZeroColumnsCheckBox.UseVisualStyleBackColor = false;
			// 
			// linkLabel1
			// 
			this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.linkLabel1.Enabled = false;
			this.linkLabel1.Location = new System.Drawing.Point(286, 328);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(116, 52);
			this.linkLabel1.TabIndex = 30;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Use * as wildcard, e.g.:\r\nuser*\r\n*user\r\n*user*";
			// 
			// shownTextBox
			// 
			this.shownTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.shownTextBox.BackColor = System.Drawing.Color.Gray;
			this.shownTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.shownTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.shownTextBox.Font = new System.Drawing.Font("Trebuchet MS", 8.25F);
			this.shownTextBox.ForeColor = System.Drawing.Color.White;
			this.shownTextBox.Location = new System.Drawing.Point(572, 1);
			this.shownTextBox.Name = "shownTextBox";
			this.shownTextBox.ReadOnly = true;
			this.shownTextBox.ShortcutsEnabled = false;
			this.shownTextBox.Size = new System.Drawing.Size(100, 13);
			this.shownTextBox.TabIndex = 29;
			this.shownTextBox.TabStop = false;
			this.shownTextBox.Text = "Shown:";
			this.shownTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.shownTextBox.Enter += new System.EventHandler(this.ShownTextBox_Enter);
			// 
			// filterHeaderLabel
			// 
			this.filterHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.filterHeaderLabel.BackColor = System.Drawing.Color.Gray;
			this.filterHeaderLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.filterHeaderLabel.ForeColor = System.Drawing.Color.White;
			this.filterHeaderLabel.Location = new System.Drawing.Point(0, 302);
			this.filterHeaderLabel.Name = "filterHeaderLabel";
			this.filterHeaderLabel.Size = new System.Drawing.Size(684, 17);
			this.filterHeaderLabel.TabIndex = 27;
			this.filterHeaderLabel.Text = "::: Filter :::::::";
			// 
			// clearButton
			// 
			this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.clearButton.BackColor = System.Drawing.Color.Transparent;
			this.clearButton.Location = new System.Drawing.Point(596, 377);
			this.clearButton.Name = "clearButton";
			this.clearButton.Size = new System.Drawing.Size(75, 24);
			this.clearButton.TabIndex = 5;
			this.clearButton.Text = "Reset";
			this.clearButton.UseVisualStyleBackColor = false;
			this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
			// 
			// applyFilterButton
			// 
			this.applyFilterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.applyFilterButton.BackColor = System.Drawing.Color.Transparent;
			this.applyFilterButton.Location = new System.Drawing.Point(515, 377);
			this.applyFilterButton.Name = "applyFilterButton";
			this.applyFilterButton.Size = new System.Drawing.Size(75, 24);
			this.applyFilterButton.TabIndex = 4;
			this.applyFilterButton.Text = "Apply";
			this.applyFilterButton.UseVisualStyleBackColor = false;
			this.applyFilterButton.Click += new System.EventHandler(this.ApplyFilterButton_Click);
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.label5.Location = new System.Drawing.Point(6, 383);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(82, 13);
			this.label5.TabIndex = 26;
			this.label5.Text = "Instance Name:";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.label4.Location = new System.Drawing.Point(6, 357);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(78, 13);
			this.label4.TabIndex = 24;
			this.label4.Text = "Counter Name:";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.label3.Location = new System.Drawing.Point(6, 331);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 13);
			this.label3.TabIndex = 22;
			this.label3.Text = "Object Name:";
			// 
			// performanceCounterResultsHeaderLabel
			// 
			this.performanceCounterResultsHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.performanceCounterResultsHeaderLabel.BackColor = System.Drawing.Color.Gray;
			this.performanceCounterResultsHeaderLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.performanceCounterResultsHeaderLabel.ForeColor = System.Drawing.Color.White;
			this.performanceCounterResultsHeaderLabel.Location = new System.Drawing.Point(0, 1);
			this.performanceCounterResultsHeaderLabel.Name = "performanceCounterResultsHeaderLabel";
			this.performanceCounterResultsHeaderLabel.Size = new System.Drawing.Size(676, 17);
			this.performanceCounterResultsHeaderLabel.TabIndex = 20;
			this.performanceCounterResultsHeaderLabel.Text = "::: Performance Counter Results :::::::";
			// 
			// performanceCounterListView
			// 
			this.performanceCounterListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.performanceCounterListView.BackColor = System.Drawing.Color.WhiteSmoke;
			this.performanceCounterListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.performanceCounterListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.performanceCounterObjectNameColumnHeader,
            this.performanceCounterCounterNameColumnHeader,
            this.performanceCounterInstanceNameColumnHeader,
            this.performanceCounterMinimumColumnHeader,
            this.performanceCounterMaximumColumnHeader,
            this.performanceCounterAverageColumnHeader,
            this.performanceCounterDeltaColumnHeader});
			this.performanceCounterListView.FullRowSelect = true;
			this.performanceCounterListView.HideSelection = false;
			this.performanceCounterListView.Location = new System.Drawing.Point(1, 22);
			this.performanceCounterListView.Name = "performanceCounterListView";
			this.performanceCounterListView.Size = new System.Drawing.Size(674, 269);
			this.performanceCounterListView.TabIndex = 0;
			this.performanceCounterListView.UseCompatibleStateImageBehavior = false;
			this.performanceCounterListView.View = System.Windows.Forms.View.Details;
			this.performanceCounterListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.PerformanceCounterListView_ColumnClick);
			// 
			// performanceCounterObjectNameColumnHeader
			// 
			this.performanceCounterObjectNameColumnHeader.Text = "Object Name";
			this.performanceCounterObjectNameColumnHeader.Width = 117;
			// 
			// performanceCounterCounterNameColumnHeader
			// 
			this.performanceCounterCounterNameColumnHeader.Text = "Counter Name";
			this.performanceCounterCounterNameColumnHeader.Width = 118;
			// 
			// performanceCounterInstanceNameColumnHeader
			// 
			this.performanceCounterInstanceNameColumnHeader.Text = "Instance Name";
			this.performanceCounterInstanceNameColumnHeader.Width = 118;
			// 
			// performanceCounterMinimumColumnHeader
			// 
			this.performanceCounterMinimumColumnHeader.Text = "Minimum";
			this.performanceCounterMinimumColumnHeader.Width = 76;
			// 
			// performanceCounterMaximumColumnHeader
			// 
			this.performanceCounterMaximumColumnHeader.Text = "Maximum";
			this.performanceCounterMaximumColumnHeader.Width = 76;
			// 
			// performanceCounterAverageColumnHeader
			// 
			this.performanceCounterAverageColumnHeader.Text = "Average";
			this.performanceCounterAverageColumnHeader.Width = 76;
			// 
			// performanceCounterDeltaColumnHeader
			// 
			this.performanceCounterDeltaColumnHeader.Text = "Delta";
			this.performanceCounterDeltaColumnHeader.Width = 76;
			// 
			// xmlTabPage
			// 
			this.xmlTabPage.BackColor = System.Drawing.Color.Silver;
			this.xmlTabPage.Controls.Add(this.resultsXmlHeaderLabel);
			this.xmlTabPage.Controls.Add(this.xmlWebBrowser);
			this.xmlTabPage.Controls.Add(this.borderLabel3);
			this.xmlTabPage.Location = new System.Drawing.Point(4, 4);
			this.xmlTabPage.Name = "xmlTabPage";
			this.xmlTabPage.Size = new System.Drawing.Size(676, 408);
			this.xmlTabPage.TabIndex = 1;
			this.xmlTabPage.Text = "Xml";
			// 
			// htmlTabPage
			// 
			this.htmlTabPage.Controls.Add(this.stylesheetWebBrowser);
			this.htmlTabPage.Controls.Add(this.descriptionTextBox);
			this.htmlTabPage.Controls.Add(this.label2);
			this.htmlTabPage.Controls.Add(this.label1);
			this.htmlTabPage.Controls.Add(this.stylesheetHeaderLabel);
			this.htmlTabPage.Controls.Add(this.transformedStylesheetHeaderLabel);
			this.htmlTabPage.Controls.Add(this.stylesheetComboBox);
			this.htmlTabPage.Controls.Add(this.borderLabel2);
			this.htmlTabPage.Controls.Add(this.borderLabel4);
			this.htmlTabPage.Controls.Add(this.borderLabel1);
			this.htmlTabPage.Location = new System.Drawing.Point(4, 4);
			this.htmlTabPage.Name = "htmlTabPage";
			this.htmlTabPage.Size = new System.Drawing.Size(676, 408);
			this.htmlTabPage.TabIndex = 2;
			this.htmlTabPage.Text = "Stylesheet";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "xml";
			this.openFileDialog1.Filter = "Result Xml files|*.xml|All files|*.*";
			// 
			// instanceNameComboBox
			// 
			this.instanceNameComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.instanceNameComboBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.instanceNameComboBox.FormattingEnabled = true;
			this.instanceNameComboBox.Location = new System.Drawing.Point(94, 380);
			this.instanceNameComboBox.Name = "instanceNameComboBox";
			this.instanceNameComboBox.Size = new System.Drawing.Size(186, 21);
			this.instanceNameComboBox.TabIndex = 3;
			this.instanceNameComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InstanceNameComboBox_KeyDown);
			// 
			// counterNameComboBox
			// 
			this.counterNameComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.counterNameComboBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.counterNameComboBox.FormattingEnabled = true;
			this.counterNameComboBox.Location = new System.Drawing.Point(94, 354);
			this.counterNameComboBox.Name = "counterNameComboBox";
			this.counterNameComboBox.Size = new System.Drawing.Size(186, 21);
			this.counterNameComboBox.TabIndex = 2;
			this.counterNameComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CounterNameComboBox_KeyDown);
			// 
			// objectNameComboBox
			// 
			this.objectNameComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.objectNameComboBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.objectNameComboBox.FormattingEnabled = true;
			this.objectNameComboBox.Location = new System.Drawing.Point(94, 328);
			this.objectNameComboBox.Name = "objectNameComboBox";
			this.objectNameComboBox.Size = new System.Drawing.Size(186, 21);
			this.objectNameComboBox.TabIndex = 1;
			this.objectNameComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ObjectNameComboBox_KeyDown);
			// 
			// borderLabel5
			// 
			this.borderLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.borderLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.borderLabel5.Location = new System.Drawing.Point(0, 21);
			this.borderLabel5.Name = "borderLabel5";
			this.borderLabel5.Size = new System.Drawing.Size(676, 271);
			this.borderLabel5.TabIndex = 19;
			// 
			// borderLabel6
			// 
			this.borderLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.borderLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.borderLabel6.Location = new System.Drawing.Point(0, 322);
			this.borderLabel6.Name = "borderLabel6";
			this.borderLabel6.Size = new System.Drawing.Size(676, 84);
			this.borderLabel6.TabIndex = 28;
			// 
			// borderLabel3
			// 
			this.borderLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.borderLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.borderLabel3.Location = new System.Drawing.Point(0, 21);
			this.borderLabel3.Name = "borderLabel3";
			this.borderLabel3.Size = new System.Drawing.Size(676, 385);
			this.borderLabel3.TabIndex = 15;
			// 
			// stylesheetComboBox
			// 
			this.stylesheetComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.stylesheetComboBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.stylesheetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.stylesheetComboBox.FormattingEnabled = true;
			this.stylesheetComboBox.Location = new System.Drawing.Point(75, 28);
			this.stylesheetComboBox.Name = "stylesheetComboBox";
			this.stylesheetComboBox.Size = new System.Drawing.Size(595, 21);
			this.stylesheetComboBox.TabIndex = 1;
			this.stylesheetComboBox.SelectedIndexChanged += new System.EventHandler(this.StylesheetComboBox_SelectedIndexChanged);
			// 
			// borderLabel2
			// 
			this.borderLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.borderLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.borderLabel2.Location = new System.Drawing.Point(0, 128);
			this.borderLabel2.Name = "borderLabel2";
			this.borderLabel2.Size = new System.Drawing.Size(676, 278);
			this.borderLabel2.TabIndex = 17;
			// 
			// borderLabel4
			// 
			this.borderLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.borderLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.borderLabel4.Location = new System.Drawing.Point(75, 53);
			this.borderLabel4.Name = "borderLabel4";
			this.borderLabel4.Size = new System.Drawing.Size(594, 36);
			this.borderLabel4.TabIndex = 19;
			// 
			// borderLabel1
			// 
			this.borderLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.borderLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.borderLabel1.Location = new System.Drawing.Point(0, 21);
			this.borderLabel1.Name = "borderLabel1";
			this.borderLabel1.Size = new System.Drawing.Size(676, 77);
			this.borderLabel1.TabIndex = 16;
			// 
			// ResultsForm
			// 
			this.AllowDrop = true;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Silver;
			this.ClientSize = new System.Drawing.Size(684, 461);
			this.Controls.Add(this.tabControlEX2);
			this.Controls.Add(this.menuStrip1);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "ResultsForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Title";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResultsForm_FormClosing);
			this.Load += new System.EventHandler(this.ResultsForm_Load);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ResultsForm_DragDrop);
			this.DragOver += new System.Windows.Forms.DragEventHandler(this.ResultsForm_DragOver);
			this.Resize += new System.EventHandler(this.ResultsForm_Resize);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tabControlEX2.ResumeLayout(false);
			this.dataTabPage.ResumeLayout(false);
			this.performanceCountersTabPage.ResumeLayout(false);
			this.performanceCountersTabPage.PerformLayout();
			this.xmlTabPage.ResumeLayout(false);
			this.htmlTabPage.ResumeLayout(false);
			this.htmlTabPage.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

	}

	#endregion

	private System.Windows.Forms.MenuStrip menuStrip1;
	private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
	private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
	private System.Windows.Forms.SaveFileDialog saveFileDialog1;
	private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
	private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
	private System.Windows.Forms.ToolStripMenuItem pageSetupToolStripMenuItem;
	private System.Windows.Forms.WebBrowser stylesheetWebBrowser;
	private ComboBoxCustom stylesheetComboBox;
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.ToolStripMenuItem saveStylesheetAsToolStripMenuItem;
	private System.Windows.Forms.TextBox descriptionTextBox;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.WebBrowser xmlWebBrowser;
	private System.Windows.Forms.Label resultsXmlHeaderLabel;
	private BorderLabel borderLabel3;
	private System.Windows.Forms.Label stylesheetHeaderLabel;
	private BorderLabel borderLabel1;
	private System.Windows.Forms.Label transformedStylesheetHeaderLabel;
	private BorderLabel borderLabel4;
	private Dotnetrix.Controls.TabControlEX tabControlEX2;
	private Dotnetrix.Controls.TabPageEX dataTabPage;
	private Dotnetrix.Controls.TabPageEX xmlTabPage;
	private Dotnetrix.Controls.TabPageEX htmlTabPage;
	private Dotnetrix.Controls.TabControlEX tabControlEX1;
	private BorderLabel borderLabel2;
	private System.Windows.Forms.Label dataHeaderLabel;
	private System.Windows.Forms.ToolStripMenuItem openResultXmlToolStripMenuItem;
	private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
	private System.Windows.Forms.OpenFileDialog openFileDialog1;
	private Dotnetrix.Controls.TabPageEX performanceCountersTabPage;
	private System.Windows.Forms.Label performanceCounterResultsHeaderLabel;
	private System.Windows.Forms.ListView performanceCounterListView;
	private System.Windows.Forms.ColumnHeader performanceCounterObjectNameColumnHeader;
	private System.Windows.Forms.ColumnHeader performanceCounterCounterNameColumnHeader;
	private System.Windows.Forms.ColumnHeader performanceCounterInstanceNameColumnHeader;
	private System.Windows.Forms.ColumnHeader performanceCounterMinimumColumnHeader;
	private System.Windows.Forms.ColumnHeader performanceCounterMaximumColumnHeader;
	private System.Windows.Forms.ColumnHeader performanceCounterAverageColumnHeader;
	private BorderLabel borderLabel5;
	private System.Windows.Forms.Label label3;
	private System.Windows.Forms.Label label5;
	private System.Windows.Forms.Label label4;
	private System.Windows.Forms.Button clearButton;
	private System.Windows.Forms.Button applyFilterButton;
	private BorderLabel borderLabel6;
	private System.Windows.Forms.Label filterHeaderLabel;
	private System.Windows.Forms.TextBox shownTextBox;
	private System.Windows.Forms.LinkLabel linkLabel1;
	private System.Windows.Forms.ToolStripMenuItem recentFilesToolStripMenuItem;
	private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
	private System.Windows.Forms.CheckBox removeAllZeroColumnsCheckBox;
	private System.Windows.Forms.ColumnHeader performanceCounterDeltaColumnHeader;
	private System.Windows.Forms.CheckBox removeZeroDeltaCheckBox;
	private ComboBoxCustom objectNameComboBox;
	private ComboBoxCustom counterNameComboBox;
	private ComboBoxCustom instanceNameComboBox;
}
