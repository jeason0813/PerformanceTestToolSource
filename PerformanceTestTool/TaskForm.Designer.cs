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

partial class TaskForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskForm));
			this.sqlLabel = new System.Windows.Forms.Label();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.nameLabel = new System.Windows.Forms.Label();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importSQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportSQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.selectionCommentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.selectionUncommentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.wordWrapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.placeholderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.totalconnectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tasktypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.insertMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.descriptionTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.enabledCheckBox = new System.Windows.Forms.CheckBox();
			this.sqlTextBox = new ICSharpCode.TextEditor.TextEditorControl();
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.selectionCommentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.selectionUncommentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripMenuItemUndo = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemRedo = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripMenuItemCut = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemPaste = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripMenuItemSelectAll = new System.Windows.Forms.ToolStripMenuItem();
			this.fontDialog1 = new System.Windows.Forms.FontDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.label4 = new System.Windows.Forms.Label();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.delayAfterCompletionTextBox = new System.Windows.Forms.TextBox();
			this.taskHeaderLabel = new System.Windows.Forms.Label();
			this.taskTypeComboBox = new ComboBoxCustom();
			this.label1 = new System.Windows.Forms.Label();
			this.includeInResultsCheckBox = new System.Windows.Forms.CheckBox();
			this.menuStrip1.SuspendLayout();
			this.contextMenuStrip.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// sqlLabel
			// 
			this.sqlLabel.AutoSize = true;
			this.sqlLabel.BackColor = System.Drawing.Color.Transparent;
			this.sqlLabel.Location = new System.Drawing.Point(12, 6);
			this.sqlLabel.Name = "sqlLabel";
			this.sqlLabel.Size = new System.Drawing.Size(31, 13);
			this.sqlLabel.TabIndex = 15;
			this.sqlLabel.Text = "SQL:";
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.BackColor = System.Drawing.Color.Transparent;
			this.okButton.Location = new System.Drawing.Point(516, 430);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 24);
			this.okButton.TabIndex = 6;
			this.okButton.Text = "Ok";
			this.okButton.UseVisualStyleBackColor = false;
			this.okButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.BackColor = System.Drawing.Color.Transparent;
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(597, 430);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 24);
			this.cancelButton.TabIndex = 7;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = false;
			// 
			// nameLabel
			// 
			this.nameLabel.AutoSize = true;
			this.nameLabel.BackColor = System.Drawing.Color.Transparent;
			this.nameLabel.Location = new System.Drawing.Point(12, 47);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(38, 13);
			this.nameLabel.TabIndex = 9;
			this.nameLabel.Text = "Name:";
			// 
			// nameTextBox
			// 
			this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nameTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.nameTextBox.Location = new System.Drawing.Point(81, 44);
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(591, 20);
			this.nameTextBox.TabIndex = 0;
			this.nameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.insertToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(684, 24);
			this.menuStrip1.TabIndex = 20;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importSQLToolStripMenuItem,
            this.exportSQLToolStripMenuItem,
            this.toolStripSeparator3,
            this.closeToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// importSQLToolStripMenuItem
			// 
			this.importSQLToolStripMenuItem.Image = global::PerformanceTestTool.Properties.Resources.folder;
			this.importSQLToolStripMenuItem.Name = "importSQLToolStripMenuItem";
			this.importSQLToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.importSQLToolStripMenuItem.Text = "&Open...";
			this.importSQLToolStripMenuItem.Click += new System.EventHandler(this.ImportSQLToolStripMenuItem_Click);
			// 
			// exportSQLToolStripMenuItem
			// 
			this.exportSQLToolStripMenuItem.Image = global::PerformanceTestTool.Properties.Resources.disk;
			this.exportSQLToolStripMenuItem.Name = "exportSQLToolStripMenuItem";
			this.exportSQLToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.exportSQLToolStripMenuItem.Text = "Save &As...";
			this.exportSQLToolStripMenuItem.Click += new System.EventHandler(this.ExportSQLToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(120, 6);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.closeToolStripMenuItem.Text = "&Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectionCommentToolStripMenuItem,
            this.selectionUncommentToolStripMenuItem,
            this.toolStripSeparator5,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator6,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator7,
            this.selectAllToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "&Edit";
			this.editToolStripMenuItem.DropDownOpening += new System.EventHandler(this.EditToolStripMenuItem_DropDownOpening);
			// 
			// findToolStripMenuItem
			// 
			this.findToolStripMenuItem.Image = global::PerformanceTestTool.Properties.Resources.find_small;
			this.findToolStripMenuItem.Name = "findToolStripMenuItem";
			this.findToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
			this.findToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
			this.findToolStripMenuItem.Text = "&Find...";
			this.findToolStripMenuItem.Click += new System.EventHandler(this.FindToolStripMenuItem_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(244, 6);
			// 
			// selectionCommentToolStripMenuItem
			// 
			this.selectionCommentToolStripMenuItem.Name = "selectionCommentToolStripMenuItem";
			this.selectionCommentToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+K, C";
			this.selectionCommentToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
			this.selectionCommentToolStripMenuItem.Text = "Selection &Comment";
			this.selectionCommentToolStripMenuItem.Click += new System.EventHandler(this.SelectionCommentToolStripMenuItem_Click);
			// 
			// selectionUncommentToolStripMenuItem
			// 
			this.selectionUncommentToolStripMenuItem.Name = "selectionUncommentToolStripMenuItem";
			this.selectionUncommentToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+K, U";
			this.selectionUncommentToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
			this.selectionUncommentToolStripMenuItem.Text = "Selection &Uncomment";
			this.selectionUncommentToolStripMenuItem.Click += new System.EventHandler(this.SelectionUncommentToolStripMenuItem_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(244, 6);
			// 
			// undoToolStripMenuItem
			// 
			this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
			this.undoToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Z";
			this.undoToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
			this.undoToolStripMenuItem.Text = "Undo";
			this.undoToolStripMenuItem.Click += new System.EventHandler(this.UndoToolStripMenuItem_Click);
			// 
			// redoToolStripMenuItem
			// 
			this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
			this.redoToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Y";
			this.redoToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
			this.redoToolStripMenuItem.Text = "Redo";
			this.redoToolStripMenuItem.Click += new System.EventHandler(this.RedoToolStripMenuItem_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(244, 6);
			// 
			// cutToolStripMenuItem
			// 
			this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
			this.cutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+X";
			this.cutToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
			this.cutToolStripMenuItem.Text = "Cut";
			this.cutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItem_Click);
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C";
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
			this.copyToolStripMenuItem.Text = "Copy";
			this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+V";
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
			this.pasteToolStripMenuItem.Text = "Paste";
			this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.ShortcutKeyDisplayString = "Del";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(244, 6);
			// 
			// selectAllToolStripMenuItem
			// 
			this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
			this.selectAllToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+A";
			this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
			this.selectAllToolStripMenuItem.Text = "Select All";
			this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItem_Click);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wordWrapToolStripMenuItem,
            this.fontToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
			this.viewToolStripMenuItem.Text = "F&ormat";
			// 
			// wordWrapToolStripMenuItem
			// 
			this.wordWrapToolStripMenuItem.CheckOnClick = true;
			this.wordWrapToolStripMenuItem.Name = "wordWrapToolStripMenuItem";
			this.wordWrapToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
			this.wordWrapToolStripMenuItem.Text = "&Word Wrap in Description";
			this.wordWrapToolStripMenuItem.Click += new System.EventHandler(this.WordWrapToolStripMenuItem_Click);
			// 
			// fontToolStripMenuItem
			// 
			this.fontToolStripMenuItem.Image = global::PerformanceTestTool.Properties.Resources.font;
			this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
			this.fontToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
			this.fontToolStripMenuItem.Text = "&Font...";
			this.fontToolStripMenuItem.Click += new System.EventHandler(this.FontToolStripMenuItem_Click);
			// 
			// insertToolStripMenuItem
			// 
			this.insertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.placeholderToolStripMenuItem,
            this.insertMessageToolStripMenuItem});
			this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
			this.insertToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.insertToolStripMenuItem.Text = "&Insert";
			// 
			// placeholderToolStripMenuItem
			// 
			this.placeholderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripMenuItem,
            this.totalconnectionsToolStripMenuItem,
            this.stepToolStripMenuItem,
            this.tasktypeToolStripMenuItem});
			this.placeholderToolStripMenuItem.Name = "placeholderToolStripMenuItem";
			this.placeholderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.placeholderToolStripMenuItem.Text = "&Placeholder";
			// 
			// connectionToolStripMenuItem
			// 
			this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
			this.connectionToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.connectionToolStripMenuItem.Text = "{&connection}";
			this.connectionToolStripMenuItem.Click += new System.EventHandler(this.ConnectionToolStripMenuItem_Click);
			// 
			// totalconnectionsToolStripMenuItem
			// 
			this.totalconnectionsToolStripMenuItem.Name = "totalconnectionsToolStripMenuItem";
			this.totalconnectionsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.totalconnectionsToolStripMenuItem.Text = "{&totalconnections}";
			this.totalconnectionsToolStripMenuItem.Click += new System.EventHandler(this.TotalconnectionsToolStripMenuItem_Click);
			// 
			// stepToolStripMenuItem
			// 
			this.stepToolStripMenuItem.Name = "stepToolStripMenuItem";
			this.stepToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.stepToolStripMenuItem.Text = "{&step}";
			this.stepToolStripMenuItem.Click += new System.EventHandler(this.StepToolStripMenuItem_Click);
			// 
			// tasktypeToolStripMenuItem
			// 
			this.tasktypeToolStripMenuItem.Name = "tasktypeToolStripMenuItem";
			this.tasktypeToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.tasktypeToolStripMenuItem.Text = "{taskt&ype}";
			this.tasktypeToolStripMenuItem.Click += new System.EventHandler(this.TasktypeToolStripMenuItem_Click);
			// 
			// insertMessageToolStripMenuItem
			// 
			this.insertMessageToolStripMenuItem.Name = "insertMessageToolStripMenuItem";
			this.insertMessageToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.insertMessageToolStripMenuItem.Text = "Insert &Message";
			this.insertMessageToolStripMenuItem.Click += new System.EventHandler(this.InsertMessageToolStripMenuItem_Click);
			// 
			// descriptionTextBox
			// 
			this.descriptionTextBox.AcceptsReturn = true;
			this.descriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.descriptionTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.descriptionTextBox.Location = new System.Drawing.Point(81, 2);
			this.descriptionTextBox.Multiline = true;
			this.descriptionTextBox.Name = "descriptionTextBox";
			this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.descriptionTextBox.Size = new System.Drawing.Size(591, 63);
			this.descriptionTextBox.TabIndex = 2;
			this.descriptionTextBox.WordWrap = false;
			this.descriptionTextBox.TextChanged += new System.EventHandler(this.DescriptionTextBox_TextChanged);
			this.descriptionTextBox.Enter += new System.EventHandler(this.DescriptionTextBox_Enter);
			this.descriptionTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DescriptionTextBox_KeyDown);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Location = new System.Drawing.Point(12, 5);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 13);
			this.label3.TabIndex = 27;
			this.label3.Text = "Description:";
			// 
			// enabledCheckBox
			// 
			this.enabledCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.enabledCheckBox.AutoSize = true;
			this.enabledCheckBox.BackColor = System.Drawing.Color.Transparent;
			this.enabledCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.enabledCheckBox.Location = new System.Drawing.Point(607, 3);
			this.enabledCheckBox.Name = "enabledCheckBox";
			this.enabledCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.enabledCheckBox.Size = new System.Drawing.Size(65, 17);
			this.enabledCheckBox.TabIndex = 8;
			this.enabledCheckBox.Text = "Enabled";
			this.enabledCheckBox.UseVisualStyleBackColor = false;
			this.enabledCheckBox.CheckedChanged += new System.EventHandler(this.EnabledCheckBox_CheckedChanged);
			// 
			// sqlTextBox
			// 
			this.sqlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.sqlTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.sqlTextBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.sqlTextBox.ContextMenuStrip = this.contextMenuStrip;
			this.sqlTextBox.IsReadOnly = false;
			this.sqlTextBox.Location = new System.Drawing.Point(81, 3);
			this.sqlTextBox.Name = "sqlTextBox";
			this.sqlTextBox.ShowVRuler = false;
			this.sqlTextBox.Size = new System.Drawing.Size(591, 242);
			this.sqlTextBox.TabIndex = 1;
			this.sqlTextBox.TextChanged += new System.EventHandler(this.SqlTextBox_TextChanged);
			// 
			// contextMenuStrip
			// 
			this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectionCommentToolStripMenuItem1,
            this.selectionUncommentToolStripMenuItem1,
            this.toolStripSeparator8,
            this.toolStripMenuItemUndo,
            this.toolStripMenuItemRedo,
            this.toolStripSeparator1,
            this.toolStripMenuItemCut,
            this.toolStripMenuItemCopy,
            this.toolStripMenuItemPaste,
            this.toolStripMenuItemDelete,
            this.toolStripSeparator2,
            this.toolStripMenuItemSelectAll});
			this.contextMenuStrip.Name = "contextMenuStrip1";
			this.contextMenuStrip.Size = new System.Drawing.Size(248, 220);
			this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip_Opening);
			// 
			// selectionCommentToolStripMenuItem1
			// 
			this.selectionCommentToolStripMenuItem1.Name = "selectionCommentToolStripMenuItem1";
			this.selectionCommentToolStripMenuItem1.ShortcutKeyDisplayString = "Ctrl+K, C";
			this.selectionCommentToolStripMenuItem1.Size = new System.Drawing.Size(247, 22);
			this.selectionCommentToolStripMenuItem1.Text = "Selection Comment";
			this.selectionCommentToolStripMenuItem1.Click += new System.EventHandler(this.SelectionCommentToolStripMenuItem1_Click);
			// 
			// selectionUncommentToolStripMenuItem1
			// 
			this.selectionUncommentToolStripMenuItem1.Name = "selectionUncommentToolStripMenuItem1";
			this.selectionUncommentToolStripMenuItem1.ShortcutKeyDisplayString = "Ctrl+K, U";
			this.selectionUncommentToolStripMenuItem1.Size = new System.Drawing.Size(247, 22);
			this.selectionUncommentToolStripMenuItem1.Text = "Selection Uncomment";
			this.selectionUncommentToolStripMenuItem1.Click += new System.EventHandler(this.SelectionUncommentToolStripMenuItem1_Click);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(244, 6);
			// 
			// toolStripMenuItemUndo
			// 
			this.toolStripMenuItemUndo.Name = "toolStripMenuItemUndo";
			this.toolStripMenuItemUndo.ShortcutKeyDisplayString = "Ctrl+Z";
			this.toolStripMenuItemUndo.Size = new System.Drawing.Size(247, 22);
			this.toolStripMenuItemUndo.Text = "Undo";
			this.toolStripMenuItemUndo.Click += new System.EventHandler(this.ToolStripMenuItemUndo_Click);
			// 
			// toolStripMenuItemRedo
			// 
			this.toolStripMenuItemRedo.Name = "toolStripMenuItemRedo";
			this.toolStripMenuItemRedo.ShortcutKeyDisplayString = "Ctrl+Y";
			this.toolStripMenuItemRedo.Size = new System.Drawing.Size(247, 22);
			this.toolStripMenuItemRedo.Text = "Redo";
			this.toolStripMenuItemRedo.Click += new System.EventHandler(this.ToolStripMenuItemRedo_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(244, 6);
			// 
			// toolStripMenuItemCut
			// 
			this.toolStripMenuItemCut.Name = "toolStripMenuItemCut";
			this.toolStripMenuItemCut.ShortcutKeyDisplayString = "Ctrl+X";
			this.toolStripMenuItemCut.Size = new System.Drawing.Size(247, 22);
			this.toolStripMenuItemCut.Text = "Cut";
			this.toolStripMenuItemCut.Click += new System.EventHandler(this.ToolStripMenuItemCut_Click);
			// 
			// toolStripMenuItemCopy
			// 
			this.toolStripMenuItemCopy.Name = "toolStripMenuItemCopy";
			this.toolStripMenuItemCopy.ShortcutKeyDisplayString = "Ctrl+C";
			this.toolStripMenuItemCopy.Size = new System.Drawing.Size(247, 22);
			this.toolStripMenuItemCopy.Text = "Copy";
			this.toolStripMenuItemCopy.Click += new System.EventHandler(this.ToolStripMenuItemCopy_Click);
			// 
			// toolStripMenuItemPaste
			// 
			this.toolStripMenuItemPaste.Name = "toolStripMenuItemPaste";
			this.toolStripMenuItemPaste.ShortcutKeyDisplayString = "Ctrl+V";
			this.toolStripMenuItemPaste.Size = new System.Drawing.Size(247, 22);
			this.toolStripMenuItemPaste.Text = "Paste";
			this.toolStripMenuItemPaste.Click += new System.EventHandler(this.ToolStripMenuItemPaste_Click);
			// 
			// toolStripMenuItemDelete
			// 
			this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
			this.toolStripMenuItemDelete.ShortcutKeyDisplayString = "Del";
			this.toolStripMenuItemDelete.Size = new System.Drawing.Size(247, 22);
			this.toolStripMenuItemDelete.Text = "Delete";
			this.toolStripMenuItemDelete.Click += new System.EventHandler(this.ToolStripMenuItemDelete_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(244, 6);
			// 
			// toolStripMenuItemSelectAll
			// 
			this.toolStripMenuItemSelectAll.Name = "toolStripMenuItemSelectAll";
			this.toolStripMenuItemSelectAll.ShortcutKeyDisplayString = "Ctrl+A";
			this.toolStripMenuItemSelectAll.Size = new System.Drawing.Size(247, 22);
			this.toolStripMenuItemSelectAll.Text = "Select All";
			this.toolStripMenuItemSelectAll.Click += new System.EventHandler(this.ToolStripMenuItemSelectAll_Click);
			// 
			// fontDialog1
			// 
			this.fontDialog1.AllowScriptChange = false;
			this.fontDialog1.AllowVerticalFonts = false;
			this.fontDialog1.Color = System.Drawing.SystemColors.ControlText;
			this.fontDialog1.FixedPitchOnly = true;
			this.fontDialog1.ShowEffects = false;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "sql";
			this.openFileDialog1.Filter = "SQL files|*.sql|All files|*.*";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.DefaultExt = "sql";
			this.saveFileDialog1.Filter = "SQL files|*.sql|All files|*.*";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label4.Location = new System.Drawing.Point(12, 418);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(660, 2);
			this.label4.TabIndex = 30;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer1.Location = new System.Drawing.Point(0, 67);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.sqlLabel);
			this.splitContainer1.Panel1.Controls.Add(this.sqlTextBox);
			this.splitContainer1.Panel1MinSize = 50;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.label3);
			this.splitContainer1.Panel2.Controls.Add(this.descriptionTextBox);
			this.splitContainer1.Panel2MinSize = 50;
			this.splitContainer1.Size = new System.Drawing.Size(684, 324);
			this.splitContainer1.SplitterDistance = 248;
			this.splitContainer1.TabIndex = 1;
			this.splitContainer1.TabStop = false;
			this.splitContainer1.Paint += new System.Windows.Forms.PaintEventHandler(this.SplitContainer1_Paint);
			this.splitContainer1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SplitContainer1_MouseUp);
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Location = new System.Drawing.Point(165, 394);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(115, 13);
			this.label5.TabIndex = 31;
			this.label5.Text = "Delay after completion:";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Location = new System.Drawing.Point(336, 394);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(20, 13);
			this.label6.TabIndex = 33;
			this.label6.Text = "ms";
			// 
			// delayAfterCompletionTextBox
			// 
			this.delayAfterCompletionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.delayAfterCompletionTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.delayAfterCompletionTextBox.Location = new System.Drawing.Point(282, 391);
			this.delayAfterCompletionTextBox.Name = "delayAfterCompletionTextBox";
			this.delayAfterCompletionTextBox.Size = new System.Drawing.Size(51, 20);
			this.delayAfterCompletionTextBox.TabIndex = 4;
			this.delayAfterCompletionTextBox.TextChanged += new System.EventHandler(this.DelayAfterCompletionTextBox_TextChanged);
			// 
			// taskHeaderLabel
			// 
			this.taskHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.taskHeaderLabel.BackColor = System.Drawing.Color.Gray;
			this.taskHeaderLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.taskHeaderLabel.ForeColor = System.Drawing.Color.White;
			this.taskHeaderLabel.Location = new System.Drawing.Point(12, 24);
			this.taskHeaderLabel.Name = "taskHeaderLabel";
			this.taskHeaderLabel.Size = new System.Drawing.Size(660, 17);
			this.taskHeaderLabel.TabIndex = 38;
			this.taskHeaderLabel.Text = "::: Task :::::::";
			// 
			// taskTypeComboBox
			// 
			this.taskTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.taskTypeComboBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.taskTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.taskTypeComboBox.FormattingEnabled = true;
			this.taskTypeComboBox.Location = new System.Drawing.Point(81, 391);
			this.taskTypeComboBox.Name = "taskTypeComboBox";
			this.taskTypeComboBox.Size = new System.Drawing.Size(76, 21);
			this.taskTypeComboBox.TabIndex = 3;
			this.taskTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.TaskTypeComboBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(12, 394);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 40;
			this.label1.Text = "Type:";
			// 
			// includeInResultsCheckBox
			// 
			this.includeInResultsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.includeInResultsCheckBox.AutoSize = true;
			this.includeInResultsCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.includeInResultsCheckBox.Location = new System.Drawing.Point(367, 393);
			this.includeInResultsCheckBox.Name = "includeInResultsCheckBox";
			this.includeInResultsCheckBox.Size = new System.Drawing.Size(105, 17);
			this.includeInResultsCheckBox.TabIndex = 5;
			this.includeInResultsCheckBox.Text = "Include in results";
			this.includeInResultsCheckBox.UseVisualStyleBackColor = true;
			this.includeInResultsCheckBox.CheckedChanged += new System.EventHandler(this.IncludeInResultsCheckBox_CheckedChanged);
			// 
			// TaskForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Silver;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(684, 461);
			this.Controls.Add(this.taskTypeComboBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.taskHeaderLabel);
			this.Controls.Add(this.includeInResultsCheckBox);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.enabledCheckBox);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.nameLabel);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.nameTextBox);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.delayAfterCompletionTextBox);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "TaskForm";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Title";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HandleForm_FormClosing);
			this.Resize += new System.EventHandler(this.Form_Resize);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.contextMenuStrip.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

	}

	#endregion

	private System.Windows.Forms.Label sqlLabel;
	private System.Windows.Forms.Button okButton;
	private System.Windows.Forms.Button cancelButton;
	private System.Windows.Forms.Label nameLabel;
	private System.Windows.Forms.TextBox nameTextBox;
	private System.Windows.Forms.MenuStrip menuStrip1;
	private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem wordWrapToolStripMenuItem;
	private System.Windows.Forms.TextBox descriptionTextBox;
	private System.Windows.Forms.Label label3;
	private ICSharpCode.TextEditor.TextEditorControl sqlTextBox;
	private System.Windows.Forms.CheckBox enabledCheckBox;
	private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem selectionCommentToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem selectionUncommentToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
	private System.Windows.Forms.FontDialog fontDialog1;
	private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem placeholderToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
	private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
	private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUndo;
	private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRedo;
	private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
	private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCut;
	private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopy;
	private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPaste;
	private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
	private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
	private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSelectAll;
	private System.Windows.Forms.ToolStripMenuItem importSQLToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem exportSQLToolStripMenuItem;
	private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
	private System.Windows.Forms.OpenFileDialog openFileDialog1;
	private System.Windows.Forms.SaveFileDialog saveFileDialog1;
	private System.Windows.Forms.Label label4;
	private System.Windows.Forms.SplitContainer splitContainer1;
	private System.Windows.Forms.Label label5;
	private System.Windows.Forms.Label label6;
	private System.Windows.Forms.TextBox delayAfterCompletionTextBox;
	private System.Windows.Forms.Label taskHeaderLabel;
	private System.Windows.Forms.ToolStripMenuItem totalconnectionsToolStripMenuItem;
	private ComboBoxCustom taskTypeComboBox;
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.ToolStripMenuItem insertMessageToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem stepToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem tasktypeToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
	private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
	private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
	private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
	private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
	private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
	private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
	private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem selectionCommentToolStripMenuItem1;
	private System.Windows.Forms.ToolStripMenuItem selectionUncommentToolStripMenuItem1;
	private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
	private System.Windows.Forms.CheckBox includeInResultsCheckBox;
}
