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

partial class AboutForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
			this.okbutton = new System.Windows.Forms.Button();
			this.aboutHeaderLabel = new System.Windows.Forms.Label();
			this.infoTextBox = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.websiteLabel = new System.Windows.Forms.Label();
			this.mailLabel = new System.Windows.Forms.Label();
			this.mailLinkLabel = new System.Windows.Forms.LinkLabel();
			this.borderLabel3 = new BorderLabel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// okbutton
			// 
			this.okbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okbutton.BackColor = System.Drawing.Color.Transparent;
			this.okbutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.okbutton.Location = new System.Drawing.Point(307, 135);
			this.okbutton.Name = "okbutton";
			this.okbutton.Size = new System.Drawing.Size(75, 24);
			this.okbutton.TabIndex = 0;
			this.okbutton.Text = "Ok";
			this.okbutton.UseVisualStyleBackColor = false;
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
			this.aboutHeaderLabel.TabIndex = 14;
			this.aboutHeaderLabel.Text = "::: About :::::::";
			// 
			// infoTextBox
			// 
			this.infoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.infoTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.infoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.infoTextBox.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.infoTextBox.Location = new System.Drawing.Point(60, 30);
			this.infoTextBox.Multiline = true;
			this.infoTextBox.Name = "infoTextBox";
			this.infoTextBox.ReadOnly = true;
			this.infoTextBox.Size = new System.Drawing.Size(321, 94);
			this.infoTextBox.TabIndex = 16;
			this.infoTextBox.TabStop = false;
			this.infoTextBox.WordWrap = false;
			this.infoTextBox.Enter += new System.EventHandler(this.InfoTextBox_Enter);
			this.infoTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InfoTextBox_KeyDown);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::PerformanceTestTool.Properties.Resources.diagram_large;
			this.pictureBox1.Location = new System.Drawing.Point(18, 31);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 32);
			this.pictureBox1.TabIndex = 17;
			this.pictureBox1.TabStop = false;
			// 
			// linkLabel1
			// 
			this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Gray;
			this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.linkLabel1.Location = new System.Drawing.Point(99, 93);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(123, 13);
			this.linkLabel1.TabIndex = 1;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "http://virtcore.com";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
			// 
			// websiteLabel
			// 
			this.websiteLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.websiteLabel.AutoSize = true;
			this.websiteLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.websiteLabel.Location = new System.Drawing.Point(60, 93);
			this.websiteLabel.Name = "websiteLabel";
			this.websiteLabel.Size = new System.Drawing.Size(33, 13);
			this.websiteLabel.TabIndex = 20;
			this.websiteLabel.Text = "Web:";
			// 
			// mailLabel
			// 
			this.mailLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.mailLabel.AutoSize = true;
			this.mailLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.mailLabel.Location = new System.Drawing.Point(60, 106);
			this.mailLabel.Name = "mailLabel";
			this.mailLabel.Size = new System.Drawing.Size(35, 13);
			this.mailLabel.TabIndex = 22;
			this.mailLabel.Text = "Email:";
			// 
			// mailLinkLabel
			// 
			this.mailLinkLabel.ActiveLinkColor = System.Drawing.Color.Gray;
			this.mailLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.mailLinkLabel.AutoSize = true;
			this.mailLinkLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.mailLinkLabel.Location = new System.Drawing.Point(99, 106);
			this.mailLinkLabel.Name = "mailLinkLabel";
			this.mailLinkLabel.Size = new System.Drawing.Size(93, 13);
			this.mailLinkLabel.TabIndex = 2;
			this.mailLinkLabel.TabStop = true;
			this.mailLinkLabel.Text = "info@virtcore.com";
			this.mailLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.MailLinkLabel_LinkClicked);
			// 
			// borderLabel3
			// 
			this.borderLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.borderLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.borderLabel3.Location = new System.Drawing.Point(59, 29);
			this.borderLabel3.Name = "borderLabel3";
			this.borderLabel3.Size = new System.Drawing.Size(323, 96);
			this.borderLabel3.TabIndex = 15;
			// 
			// AboutForm
			// 
			this.AcceptButton = this.okbutton;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Silver;
			this.CancelButton = this.okbutton;
			this.ClientSize = new System.Drawing.Size(394, 166);
			this.Controls.Add(this.mailLabel);
			this.Controls.Add(this.mailLinkLabel);
			this.Controls.Add(this.websiteLabel);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.infoTextBox);
			this.Controls.Add(this.aboutHeaderLabel);
			this.Controls.Add(this.okbutton);
			this.Controls.Add(this.borderLabel3);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Title";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

	}

	#endregion

	private System.Windows.Forms.Button okbutton;
	private System.Windows.Forms.Label aboutHeaderLabel;
	private BorderLabel borderLabel3;
	private System.Windows.Forms.TextBox infoTextBox;
	private System.Windows.Forms.PictureBox pictureBox1;
	private System.Windows.Forms.LinkLabel linkLabel1;
	private System.Windows.Forms.Label websiteLabel;
	private System.Windows.Forms.Label mailLabel;
	private System.Windows.Forms.LinkLabel mailLinkLabel;
}
