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

partial class ErrorForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorForm));
			this.okButton = new System.Windows.Forms.Button();
			this.copyButton = new System.Windows.Forms.Button();
			this.errorTextBox = new System.Windows.Forms.TextBox();
			this.errorMessageHeaderLabel = new System.Windows.Forms.Label();
			this.technicalInformationHeaderLabel = new System.Windows.Forms.Label();
			this.errorHeaderLocationLabel = new System.Windows.Forms.Label();
			this.locationTextBox = new System.Windows.Forms.TextBox();
			this.infoTextBox = new ICSharpCode.TextEditor.TextEditorControl();
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
			this.doNotShowAgainCheckBox = new System.Windows.Forms.CheckBox();
			this.borderLabel3 = new BorderLabel();
			this.borderLabel1 = new BorderLabel();
			this.borderLabel2 = new BorderLabel();
			this.contextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.BackColor = System.Drawing.Color.Transparent;
			this.okButton.Location = new System.Drawing.Point(297, 385);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 24);
			this.okButton.TabIndex = 1;
			this.okButton.Text = "Exit";
			this.okButton.UseVisualStyleBackColor = false;
			this.okButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// copyButton
			// 
			this.copyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.copyButton.BackColor = System.Drawing.Color.Transparent;
			this.copyButton.Location = new System.Drawing.Point(216, 385);
			this.copyButton.Name = "copyButton";
			this.copyButton.Size = new System.Drawing.Size(75, 24);
			this.copyButton.TabIndex = 5;
			this.copyButton.Text = "Copy";
			this.copyButton.UseVisualStyleBackColor = false;
			this.copyButton.Click += new System.EventHandler(this.CopyButton_Click);
			// 
			// errorTextBox
			// 
			this.errorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.errorTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.errorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.errorTextBox.Location = new System.Drawing.Point(13, 75);
			this.errorTextBox.Multiline = true;
			this.errorTextBox.Name = "errorTextBox";
			this.errorTextBox.ReadOnly = true;
			this.errorTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.errorTextBox.Size = new System.Drawing.Size(358, 84);
			this.errorTextBox.TabIndex = 2;
			this.errorTextBox.Enter += new System.EventHandler(this.ErrorTextBox_Enter);
			this.errorTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ErrorTextBox_KeyDown);
			// 
			// errorMessageHeaderLabel
			// 
			this.errorMessageHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.errorMessageHeaderLabel.BackColor = System.Drawing.Color.Gray;
			this.errorMessageHeaderLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.errorMessageHeaderLabel.ForeColor = System.Drawing.Color.White;
			this.errorMessageHeaderLabel.Location = new System.Drawing.Point(12, 54);
			this.errorMessageHeaderLabel.Name = "errorMessageHeaderLabel";
			this.errorMessageHeaderLabel.Size = new System.Drawing.Size(360, 17);
			this.errorMessageHeaderLabel.TabIndex = 15;
			this.errorMessageHeaderLabel.Text = "::: Error Message :::::::";
			// 
			// technicalInformationHeaderLabel
			// 
			this.technicalInformationHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.technicalInformationHeaderLabel.BackColor = System.Drawing.Color.Gray;
			this.technicalInformationHeaderLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.technicalInformationHeaderLabel.ForeColor = System.Drawing.Color.White;
			this.technicalInformationHeaderLabel.Location = new System.Drawing.Point(12, 170);
			this.technicalInformationHeaderLabel.Name = "technicalInformationHeaderLabel";
			this.technicalInformationHeaderLabel.Size = new System.Drawing.Size(360, 17);
			this.technicalInformationHeaderLabel.TabIndex = 16;
			this.technicalInformationHeaderLabel.Text = "::: Technical Information :::::::";
			// 
			// errorHeaderLocationLabel
			// 
			this.errorHeaderLocationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.errorHeaderLocationLabel.BackColor = System.Drawing.Color.Gray;
			this.errorHeaderLocationLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.errorHeaderLocationLabel.ForeColor = System.Drawing.Color.White;
			this.errorHeaderLocationLabel.Location = new System.Drawing.Point(12, 9);
			this.errorHeaderLocationLabel.Name = "errorHeaderLocationLabel";
			this.errorHeaderLocationLabel.Size = new System.Drawing.Size(360, 17);
			this.errorHeaderLocationLabel.TabIndex = 21;
			this.errorHeaderLocationLabel.Text = "::: Error Location :::::::";
			// 
			// locationTextBox
			// 
			this.locationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.locationTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.locationTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.locationTextBox.Location = new System.Drawing.Point(13, 30);
			this.locationTextBox.Name = "locationTextBox";
			this.locationTextBox.ReadOnly = true;
			this.locationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.locationTextBox.Size = new System.Drawing.Size(358, 13);
			this.locationTextBox.TabIndex = 22;
			this.locationTextBox.Enter += new System.EventHandler(this.LocationTextBox_Enter);
			this.locationTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LocationTextBox_KeyDown);
			// 
			// infoTextBox
			// 
			this.infoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.infoTextBox.ContextMenuStrip = this.contextMenuStrip;
			this.infoTextBox.IsReadOnly = false;
			this.infoTextBox.Location = new System.Drawing.Point(13, 191);
			this.infoTextBox.Name = "infoTextBox";
			this.infoTextBox.ShowVRuler = false;
			this.infoTextBox.Size = new System.Drawing.Size(358, 183);
			this.infoTextBox.TabIndex = 3;
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
			// doNotShowAgainCheckBox
			// 
			this.doNotShowAgainCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.doNotShowAgainCheckBox.AutoSize = true;
			this.doNotShowAgainCheckBox.Location = new System.Drawing.Point(12, 390);
			this.doNotShowAgainCheckBox.Name = "doNotShowAgainCheckBox";
			this.doNotShowAgainCheckBox.Size = new System.Drawing.Size(158, 17);
			this.doNotShowAgainCheckBox.TabIndex = 4;
			this.doNotShowAgainCheckBox.Text = "Do not show this error again";
			this.doNotShowAgainCheckBox.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.doNotShowAgainCheckBox.UseVisualStyleBackColor = true;
			this.doNotShowAgainCheckBox.Visible = false;
			// 
			// borderLabel3
			// 
			this.borderLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.borderLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.borderLabel3.Location = new System.Drawing.Point(12, 74);
			this.borderLabel3.Name = "borderLabel3";
			this.borderLabel3.Size = new System.Drawing.Size(360, 86);
			this.borderLabel3.TabIndex = 17;
			// 
			// borderLabel1
			// 
			this.borderLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.borderLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.borderLabel1.Location = new System.Drawing.Point(12, 190);
			this.borderLabel1.Name = "borderLabel1";
			this.borderLabel1.Size = new System.Drawing.Size(360, 185);
			this.borderLabel1.TabIndex = 18;
			// 
			// borderLabel2
			// 
			this.borderLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.borderLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.borderLabel2.Location = new System.Drawing.Point(12, 29);
			this.borderLabel2.Name = "borderLabel2";
			this.borderLabel2.Size = new System.Drawing.Size(360, 15);
			this.borderLabel2.TabIndex = 20;
			// 
			// ErrorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Silver;
			this.ClientSize = new System.Drawing.Size(384, 416);
			this.Controls.Add(this.doNotShowAgainCheckBox);
			this.Controls.Add(this.infoTextBox);
			this.Controls.Add(this.locationTextBox);
			this.Controls.Add(this.errorHeaderLocationLabel);
			this.Controls.Add(this.technicalInformationHeaderLabel);
			this.Controls.Add(this.errorTextBox);
			this.Controls.Add(this.errorMessageHeaderLabel);
			this.Controls.Add(this.copyButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.borderLabel3);
			this.Controls.Add(this.borderLabel1);
			this.Controls.Add(this.borderLabel2);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ErrorForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Title";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ErrorForm_FormClosing);
			this.Shown += new System.EventHandler(this.ErrorForm_Shown);
			this.contextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

	}

	#endregion

	private System.Windows.Forms.Button okButton;
	private System.Windows.Forms.Button copyButton;
	private System.Windows.Forms.TextBox errorTextBox;
	private System.Windows.Forms.Label errorMessageHeaderLabel;
	private System.Windows.Forms.Label technicalInformationHeaderLabel;
	private BorderLabel borderLabel3;
	private BorderLabel borderLabel1;
	private BorderLabel borderLabel2;
	private System.Windows.Forms.Label errorHeaderLocationLabel;
	private System.Windows.Forms.TextBox locationTextBox;
	private ICSharpCode.TextEditor.TextEditorControl infoTextBox;
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
	private System.Windows.Forms.CheckBox doNotShowAgainCheckBox;
}
