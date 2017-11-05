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

partial class CommandLineParametersForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandLineParametersForm));
			this.okbutton = new System.Windows.Forms.Button();
			this.infoTextBox = new System.Windows.Forms.TextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.commandLineParametersHeaderLabel = new System.Windows.Forms.Label();
			this.borderLabel3 = new BorderLabel();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// okbutton
			// 
			this.okbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okbutton.BackColor = System.Drawing.Color.Transparent;
			this.okbutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.okbutton.Location = new System.Drawing.Point(597, 430);
			this.okbutton.Name = "okbutton";
			this.okbutton.Size = new System.Drawing.Size(75, 24);
			this.okbutton.TabIndex = 0;
			this.okbutton.Text = "Ok";
			this.okbutton.UseVisualStyleBackColor = false;
			// 
			// infoTextBox
			// 
			this.infoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.infoTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.infoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.infoTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.infoTextBox.Location = new System.Drawing.Point(13, 45);
			this.infoTextBox.Multiline = true;
			this.infoTextBox.Name = "infoTextBox";
			this.infoTextBox.ReadOnly = true;
			this.infoTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.infoTextBox.Size = new System.Drawing.Size(658, 374);
			this.infoTextBox.TabIndex = 1;
			this.infoTextBox.TabStop = false;
			this.infoTextBox.Text = resources.GetString("infoTextBox.Text");
			this.infoTextBox.WordWrap = false;
			this.infoTextBox.Enter += new System.EventHandler(this.InfoTextBox_Enter);
			this.infoTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InfoTextBox_KeyDown);
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(684, 24);
			this.menuStrip1.TabIndex = 12;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.closeToolStripMenuItem.Text = "&Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
			// 
			// commandLineParametersHeaderLabel
			// 
			this.commandLineParametersHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.commandLineParametersHeaderLabel.BackColor = System.Drawing.Color.Gray;
			this.commandLineParametersHeaderLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.commandLineParametersHeaderLabel.ForeColor = System.Drawing.Color.White;
			this.commandLineParametersHeaderLabel.Location = new System.Drawing.Point(12, 24);
			this.commandLineParametersHeaderLabel.Name = "commandLineParametersHeaderLabel";
			this.commandLineParametersHeaderLabel.Size = new System.Drawing.Size(660, 17);
			this.commandLineParametersHeaderLabel.TabIndex = 14;
			this.commandLineParametersHeaderLabel.Text = "::: Command Line Parameters :::::::";
			// 
			// borderLabel3
			// 
			this.borderLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.borderLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.borderLabel3.Location = new System.Drawing.Point(12, 44);
			this.borderLabel3.Name = "borderLabel3";
			this.borderLabel3.Size = new System.Drawing.Size(660, 376);
			this.borderLabel3.TabIndex = 15;
			// 
			// CommandLineParametersForm
			// 
			this.AcceptButton = this.okbutton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Silver;
			this.CancelButton = this.okbutton;
			this.ClientSize = new System.Drawing.Size(684, 461);
			this.Controls.Add(this.commandLineParametersHeaderLabel);
			this.Controls.Add(this.infoTextBox);
			this.Controls.Add(this.okbutton);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.borderLabel3);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "CommandLineParametersForm";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Title";
			this.Resize += new System.EventHandler(this.AboutForm_Resize);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

	}

	#endregion

	private System.Windows.Forms.Button okbutton;
	private System.Windows.Forms.TextBox infoTextBox;
	private System.Windows.Forms.MenuStrip menuStrip1;
	private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
	private System.Windows.Forms.Label commandLineParametersHeaderLabel;
	private BorderLabel borderLabel3;
	private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
}
