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

partial class CheckForUpdatesForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckForUpdatesForm));
			this.closebutton = new System.Windows.Forms.Button();
			this.aboutHeaderLabel = new System.Windows.Forms.Label();
			this.infoTextBox = new System.Windows.Forms.TextBox();
			this.updateButton = new System.Windows.Forms.Button();
			this.checkOnStartCheckBox = new System.Windows.Forms.CheckBox();
			this.changelogTextBox = new System.Windows.Forms.TextBox();
			this.changelogLabel = new System.Windows.Forms.Label();
			this.changelogBorderLabel = new BorderLabel();
			this.borderLabel3 = new BorderLabel();
			this.SuspendLayout();
			// 
			// closebutton
			// 
			this.closebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.closebutton.BackColor = System.Drawing.Color.Transparent;
			this.closebutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.closebutton.Location = new System.Drawing.Point(307, 230);
			this.closebutton.Name = "closebutton";
			this.closebutton.Size = new System.Drawing.Size(75, 24);
			this.closebutton.TabIndex = 2;
			this.closebutton.Text = "Close";
			this.closebutton.UseVisualStyleBackColor = false;
			this.closebutton.Click += new System.EventHandler(this.Closebutton_Click);
			// 
			// aboutHeaderLabel
			// 
			this.aboutHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.aboutHeaderLabel.BackColor = System.Drawing.Color.Gray;
			this.aboutHeaderLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.aboutHeaderLabel.ForeColor = System.Drawing.Color.White;
			this.aboutHeaderLabel.Location = new System.Drawing.Point(12, 9);
			this.aboutHeaderLabel.Name = "aboutHeaderLabel";
			this.aboutHeaderLabel.Size = new System.Drawing.Size(370, 17);
			this.aboutHeaderLabel.TabIndex = 18;
			this.aboutHeaderLabel.Text = "::: Check for updates :::::::";
			// 
			// infoTextBox
			// 
			this.infoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.infoTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.infoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.infoTextBox.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.infoTextBox.Location = new System.Drawing.Point(13, 30);
			this.infoTextBox.Multiline = true;
			this.infoTextBox.Name = "infoTextBox";
			this.infoTextBox.ReadOnly = true;
			this.infoTextBox.Size = new System.Drawing.Size(368, 65);
			this.infoTextBox.TabIndex = 20;
			this.infoTextBox.TabStop = false;
			this.infoTextBox.WordWrap = false;
			// 
			// updateButton
			// 
			this.updateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.updateButton.BackColor = System.Drawing.Color.Transparent;
			this.updateButton.Location = new System.Drawing.Point(199, 230);
			this.updateButton.Name = "updateButton";
			this.updateButton.Size = new System.Drawing.Size(102, 24);
			this.updateButton.TabIndex = 1;
			this.updateButton.Text = "Check";
			this.updateButton.UseVisualStyleBackColor = false;
			this.updateButton.Click += new System.EventHandler(this.UpdateButton_Click);
			// 
			// checkOnStartCheckBox
			// 
			this.checkOnStartCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkOnStartCheckBox.AutoSize = true;
			this.checkOnStartCheckBox.BackColor = System.Drawing.Color.Silver;
			this.checkOnStartCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.checkOnStartCheckBox.Checked = true;
			this.checkOnStartCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkOnStartCheckBox.Location = new System.Drawing.Point(12, 235);
			this.checkOnStartCheckBox.Name = "checkOnStartCheckBox";
			this.checkOnStartCheckBox.Size = new System.Drawing.Size(151, 17);
			this.checkOnStartCheckBox.TabIndex = 3;
			this.checkOnStartCheckBox.Text = "Check for updates on start";
			this.checkOnStartCheckBox.UseVisualStyleBackColor = false;
			// 
			// changelogTextBox
			// 
			this.changelogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.changelogTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.changelogTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.changelogTextBox.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.changelogTextBox.Location = new System.Drawing.Point(14, 123);
			this.changelogTextBox.Multiline = true;
			this.changelogTextBox.Name = "changelogTextBox";
			this.changelogTextBox.ReadOnly = true;
			this.changelogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.changelogTextBox.Size = new System.Drawing.Size(368, 98);
			this.changelogTextBox.TabIndex = 21;
			this.changelogTextBox.TabStop = false;
			this.changelogTextBox.Visible = false;
			this.changelogTextBox.WordWrap = false;
			// 
			// changelogLabel
			// 
			this.changelogLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.changelogLabel.BackColor = System.Drawing.Color.Gray;
			this.changelogLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.changelogLabel.ForeColor = System.Drawing.Color.White;
			this.changelogLabel.Location = new System.Drawing.Point(12, 102);
			this.changelogLabel.Name = "changelogLabel";
			this.changelogLabel.Size = new System.Drawing.Size(370, 17);
			this.changelogLabel.TabIndex = 23;
			this.changelogLabel.Text = "::: Changelog :::::::";
			this.changelogLabel.Visible = false;
			// 
			// changelogBorderLabel
			// 
			this.changelogBorderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.changelogBorderLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.changelogBorderLabel.Location = new System.Drawing.Point(12, 122);
			this.changelogBorderLabel.Name = "changelogBorderLabel";
			this.changelogBorderLabel.Size = new System.Drawing.Size(370, 100);
			this.changelogBorderLabel.TabIndex = 22;
			this.changelogBorderLabel.Visible = false;
			// 
			// borderLabel3
			// 
			this.borderLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.borderLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.borderLabel3.Location = new System.Drawing.Point(12, 29);
			this.borderLabel3.Name = "borderLabel3";
			this.borderLabel3.Size = new System.Drawing.Size(370, 67);
			this.borderLabel3.TabIndex = 19;
			// 
			// CheckForUpdatesForm
			// 
			this.AcceptButton = this.updateButton;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Silver;
			this.CancelButton = this.closebutton;
			this.ClientSize = new System.Drawing.Size(394, 261);
			this.ControlBox = false;
			this.Controls.Add(this.changelogTextBox);
			this.Controls.Add(this.changelogBorderLabel);
			this.Controls.Add(this.checkOnStartCheckBox);
			this.Controls.Add(this.updateButton);
			this.Controls.Add(this.infoTextBox);
			this.Controls.Add(this.borderLabel3);
			this.Controls.Add(this.aboutHeaderLabel);
			this.Controls.Add(this.closebutton);
			this.Controls.Add(this.changelogLabel);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "CheckForUpdatesForm";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Title";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckForUpdatesForm_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

	}

	#endregion

	private System.Windows.Forms.Button closebutton;
	private System.Windows.Forms.Label aboutHeaderLabel;
	private System.Windows.Forms.TextBox infoTextBox;
	private BorderLabel borderLabel3;
	private System.Windows.Forms.Button updateButton;
	private System.Windows.Forms.CheckBox checkOnStartCheckBox;
	private System.Windows.Forms.TextBox changelogTextBox;
	private BorderLabel changelogBorderLabel;
	private System.Windows.Forms.Label changelogLabel;
}
