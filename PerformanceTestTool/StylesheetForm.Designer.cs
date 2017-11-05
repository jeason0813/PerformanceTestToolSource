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

partial class StylesheetForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StylesheetForm));
			this.xslLabel = new System.Windows.Forms.Label();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.nameLabel = new System.Windows.Forms.Label();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importStylesheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportStylesheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.wordWrapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.descriptionTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.xslTextBox = new ICSharpCode.TextEditor.TextEditorControl();
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
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
			this.enabledCheckBox = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.outputFormatComboBox = new ComboBoxCustom();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.label2 = new System.Windows.Forms.Label();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.stylesheetHeaderLabel = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.contextMenuStrip.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// xslLabel
			// 
			this.xslLabel.AutoSize = true;
			this.xslLabel.BackColor = System.Drawing.Color.Transparent;
			this.xslLabel.Location = new System.Drawing.Point(12, 6);
			this.xslLabel.Name = "xslLabel";
			this.xslLabel.Size = new System.Drawing.Size(30, 13);
			this.xslLabel.TabIndex = 15;
			this.xslLabel.Text = "XSL:";
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.BackColor = System.Drawing.Color.Transparent;
			this.okButton.Location = new System.Drawing.Point(516, 430);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 24);
			this.okButton.TabIndex = 4;
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
			this.cancelButton.TabIndex = 5;
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
            this.viewToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(684, 24);
			this.menuStrip1.TabIndex = 20;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importStylesheetToolStripMenuItem,
            this.exportStylesheetToolStripMenuItem,
            this.toolStripSeparator3,
            this.closeToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// importStylesheetToolStripMenuItem
			// 
			this.importStylesheetToolStripMenuItem.Image = global::PerformanceTestTool.Properties.Resources.folder;
			this.importStylesheetToolStripMenuItem.Name = "importStylesheetToolStripMenuItem";
			this.importStylesheetToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.importStylesheetToolStripMenuItem.Text = "&Open...";
			this.importStylesheetToolStripMenuItem.Click += new System.EventHandler(this.ImportStylesheetToolStripMenuItem_Click);
			// 
			// exportStylesheetToolStripMenuItem
			// 
			this.exportStylesheetToolStripMenuItem.Image = global::PerformanceTestTool.Properties.Resources.disk;
			this.exportStylesheetToolStripMenuItem.Name = "exportStylesheetToolStripMenuItem";
			this.exportStylesheetToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.exportStylesheetToolStripMenuItem.Text = "Save &As...";
			this.exportStylesheetToolStripMenuItem.Click += new System.EventHandler(this.ExportStylesheetToolStripMenuItem_Click);
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
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator5,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator6,
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
			this.findToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.findToolStripMenuItem.Text = "&Find...";
			this.findToolStripMenuItem.Click += new System.EventHandler(this.FindToolStripMenuItem_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(161, 6);
			// 
			// undoToolStripMenuItem
			// 
			this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
			this.undoToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Z";
			this.undoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.undoToolStripMenuItem.Text = "Undo";
			this.undoToolStripMenuItem.Click += new System.EventHandler(this.UndoToolStripMenuItem_Click);
			// 
			// redoToolStripMenuItem
			// 
			this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
			this.redoToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Y";
			this.redoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.redoToolStripMenuItem.Text = "Redo";
			this.redoToolStripMenuItem.Click += new System.EventHandler(this.RedoToolStripMenuItem_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(161, 6);
			// 
			// cutToolStripMenuItem
			// 
			this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
			this.cutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+X";
			this.cutToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.cutToolStripMenuItem.Text = "Cut";
			this.cutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItem_Click);
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C";
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.copyToolStripMenuItem.Text = "Copy";
			this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+V";
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.pasteToolStripMenuItem.Text = "Paste";
			this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.ShortcutKeyDisplayString = "Del";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(161, 6);
			// 
			// selectAllToolStripMenuItem
			// 
			this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
			this.selectAllToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+A";
			this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
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
			// xslTextBox
			// 
			this.xslTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.xslTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xslTextBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.xslTextBox.ContextMenuStrip = this.contextMenuStrip;
			this.xslTextBox.IsReadOnly = false;
			this.xslTextBox.Location = new System.Drawing.Point(81, 3);
			this.xslTextBox.Name = "xslTextBox";
			this.xslTextBox.ShowVRuler = false;
			this.xslTextBox.Size = new System.Drawing.Size(591, 242);
			this.xslTextBox.TabIndex = 1;
			this.xslTextBox.TextChanged += new System.EventHandler(this.XslTextBox_TextChanged);
			// 
			// contextMenuStrip
			// 
			this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
			this.contextMenuStrip.Size = new System.Drawing.Size(165, 170);
			this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip_Opening);
			// 
			// toolStripMenuItemUndo
			// 
			this.toolStripMenuItemUndo.Name = "toolStripMenuItemUndo";
			this.toolStripMenuItemUndo.ShortcutKeyDisplayString = "Ctrl+Z";
			this.toolStripMenuItemUndo.Size = new System.Drawing.Size(164, 22);
			this.toolStripMenuItemUndo.Text = "Undo";
			this.toolStripMenuItemUndo.Click += new System.EventHandler(this.ToolStripMenuItemUndo_Click);
			// 
			// toolStripMenuItemRedo
			// 
			this.toolStripMenuItemRedo.Name = "toolStripMenuItemRedo";
			this.toolStripMenuItemRedo.ShortcutKeyDisplayString = "Ctrl+Y";
			this.toolStripMenuItemRedo.Size = new System.Drawing.Size(164, 22);
			this.toolStripMenuItemRedo.Text = "Redo";
			this.toolStripMenuItemRedo.Click += new System.EventHandler(this.ToolStripMenuItemRedo_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
			// 
			// toolStripMenuItemCut
			// 
			this.toolStripMenuItemCut.Name = "toolStripMenuItemCut";
			this.toolStripMenuItemCut.ShortcutKeyDisplayString = "Ctrl+X";
			this.toolStripMenuItemCut.Size = new System.Drawing.Size(164, 22);
			this.toolStripMenuItemCut.Text = "Cut";
			this.toolStripMenuItemCut.Click += new System.EventHandler(this.ToolStripMenuItemCut_Click);
			// 
			// toolStripMenuItemCopy
			// 
			this.toolStripMenuItemCopy.Name = "toolStripMenuItemCopy";
			this.toolStripMenuItemCopy.ShortcutKeyDisplayString = "Ctrl+C";
			this.toolStripMenuItemCopy.Size = new System.Drawing.Size(164, 22);
			this.toolStripMenuItemCopy.Text = "Copy";
			this.toolStripMenuItemCopy.Click += new System.EventHandler(this.ToolStripMenuItemCopy_Click);
			// 
			// toolStripMenuItemPaste
			// 
			this.toolStripMenuItemPaste.Name = "toolStripMenuItemPaste";
			this.toolStripMenuItemPaste.ShortcutKeyDisplayString = "Ctrl+V";
			this.toolStripMenuItemPaste.Size = new System.Drawing.Size(164, 22);
			this.toolStripMenuItemPaste.Text = "Paste";
			this.toolStripMenuItemPaste.Click += new System.EventHandler(this.ToolStripMenuItemPaste_Click);
			// 
			// toolStripMenuItemDelete
			// 
			this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
			this.toolStripMenuItemDelete.ShortcutKeyDisplayString = "Del";
			this.toolStripMenuItemDelete.Size = new System.Drawing.Size(164, 22);
			this.toolStripMenuItemDelete.Text = "Delete";
			this.toolStripMenuItemDelete.Click += new System.EventHandler(this.ToolStripMenuItemDelete_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(161, 6);
			// 
			// toolStripMenuItemSelectAll
			// 
			this.toolStripMenuItemSelectAll.Name = "toolStripMenuItemSelectAll";
			this.toolStripMenuItemSelectAll.ShortcutKeyDisplayString = "Ctrl+A";
			this.toolStripMenuItemSelectAll.Size = new System.Drawing.Size(164, 22);
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
			this.enabledCheckBox.TabIndex = 6;
			this.enabledCheckBox.Text = "Enabled";
			this.enabledCheckBox.UseVisualStyleBackColor = false;
			this.enabledCheckBox.CheckedChanged += new System.EventHandler(this.EnabledCheckBox_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(12, 394);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 13);
			this.label1.TabIndex = 28;
			this.label1.Text = "Output as:";
			// 
			// outputFormatComboBox
			// 
			this.outputFormatComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.outputFormatComboBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.outputFormatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.outputFormatComboBox.FormattingEnabled = true;
			this.outputFormatComboBox.Items.AddRange(new object[] {
            "Html",
            "Xml"});
			this.outputFormatComboBox.Location = new System.Drawing.Point(81, 391);
			this.outputFormatComboBox.Name = "outputFormatComboBox";
			this.outputFormatComboBox.Size = new System.Drawing.Size(76, 21);
			this.outputFormatComboBox.TabIndex = 3;
			this.outputFormatComboBox.SelectedIndexChanged += new System.EventHandler(this.OutputFormatComboBox_SelectedIndexChanged);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "xsl";
			this.openFileDialog1.Filter = "Stylesheet files|*.xsl|All files|*.*";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.DefaultExt = "xsl";
			this.saveFileDialog1.Filter = "Stylesheet files|*.xsl|All files|*.*";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Location = new System.Drawing.Point(12, 418);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(660, 2);
			this.label2.TabIndex = 29;
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
			this.splitContainer1.Panel1.Controls.Add(this.xslLabel);
			this.splitContainer1.Panel1.Controls.Add(this.xslTextBox);
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
			// stylesheetHeaderLabel
			// 
			this.stylesheetHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.stylesheetHeaderLabel.BackColor = System.Drawing.Color.Gray;
			this.stylesheetHeaderLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.stylesheetHeaderLabel.ForeColor = System.Drawing.Color.White;
			this.stylesheetHeaderLabel.Location = new System.Drawing.Point(12, 24);
			this.stylesheetHeaderLabel.Name = "stylesheetHeaderLabel";
			this.stylesheetHeaderLabel.Size = new System.Drawing.Size(660, 17);
			this.stylesheetHeaderLabel.TabIndex = 39;
			this.stylesheetHeaderLabel.Text = "::: Stylesheet :::::::";
			// 
			// StylesheetForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Silver;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(684, 461);
			this.Controls.Add(this.stylesheetHeaderLabel);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.outputFormatComboBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.enabledCheckBox);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.nameTextBox);
			this.Controls.Add(this.nameLabel);
			this.Controls.Add(this.menuStrip1);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "StylesheetForm";
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

	private System.Windows.Forms.Label xslLabel;
	private System.Windows.Forms.Button okButton;
	private System.Windows.Forms.Button cancelButton;
	private System.Windows.Forms.Label nameLabel;
	private System.Windows.Forms.TextBox nameTextBox;
	private System.Windows.Forms.MenuStrip menuStrip1;
	private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem wordWrapToolStripMenuItem;
	private System.Windows.Forms.TextBox descriptionTextBox;
	private System.Windows.Forms.Label label3;
	private ICSharpCode.TextEditor.TextEditorControl xslTextBox;
	private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
	private System.Windows.Forms.FontDialog fontDialog1;
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
	private System.Windows.Forms.CheckBox enabledCheckBox;
	private System.Windows.Forms.Label label1;
	private ComboBoxCustom outputFormatComboBox;
	private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
	private System.Windows.Forms.ToolStripMenuItem importStylesheetToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem exportStylesheetToolStripMenuItem;
	private System.Windows.Forms.OpenFileDialog openFileDialog1;
	private System.Windows.Forms.SaveFileDialog saveFileDialog1;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.SplitContainer splitContainer1;
	private System.Windows.Forms.Label stylesheetHeaderLabel;
	private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
	private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
	private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
	private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
	private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
	private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
	private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
}
