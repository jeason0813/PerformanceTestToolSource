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

partial class PreferencesForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreferencesForm));
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.label3 = new System.Windows.Forms.Label();
			this.resetLayoutButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.stylesheetHeaderLabel = new System.Windows.Forms.Label();
			this.traceHeaderLabel = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tracingFunctionalityComboBox = new ComboBoxCustom();
			this.borderLabel1 = new BorderLabel();
			this.stylesheetComboBox = new ComboBoxCustom();
			this.borderLabel3 = new BorderLabel();
			this.chooseDirectoryButton = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.traceFilePathComboBox = new ComboBoxCustom();
			this.SuspendLayout();
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.BackColor = System.Drawing.Color.Transparent;
			this.okButton.Location = new System.Drawing.Point(226, 212);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 24);
			this.okButton.TabIndex = 0;
			this.okButton.Text = "Ok";
			this.okButton.UseVisualStyleBackColor = false;
			this.okButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.BackColor = System.Drawing.Color.Transparent;
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(307, 212);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 24);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = false;
			// 
			// linkLabel1
			// 
			this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.linkLabel1.Enabled = false;
			this.linkLabel1.Location = new System.Drawing.Point(134, 126);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(241, 47);
			this.linkLabel1.TabIndex = 26;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "If you are connecting to a remote SQL Server, please use UNC path and make sure t" +
    "he server has write access to your network share.";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.label3.Location = new System.Drawing.Point(19, 106);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(102, 13);
			this.label3.TabIndex = 25;
			this.label3.Text = "Trace File Directory:";
			// 
			// resetLayoutButton
			// 
			this.resetLayoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.resetLayoutButton.BackColor = System.Drawing.Color.Transparent;
			this.resetLayoutButton.Location = new System.Drawing.Point(12, 213);
			this.resetLayoutButton.Name = "resetLayoutButton";
			this.resetLayoutButton.Size = new System.Drawing.Size(82, 24);
			this.resetLayoutButton.TabIndex = 6;
			this.resetLayoutButton.Text = "Reset Layout";
			this.resetLayoutButton.UseVisualStyleBackColor = false;
			this.resetLayoutButton.Click += new System.EventHandler(this.ResetLayoutButton_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.label2.Location = new System.Drawing.Point(17, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 13);
			this.label2.TabIndex = 11;
			this.label2.Text = "Default Stylesheet:";
			// 
			// stylesheetHeaderLabel
			// 
			this.stylesheetHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.stylesheetHeaderLabel.BackColor = System.Drawing.Color.Gray;
			this.stylesheetHeaderLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.stylesheetHeaderLabel.ForeColor = System.Drawing.Color.White;
			this.stylesheetHeaderLabel.Location = new System.Drawing.Point(12, 9);
			this.stylesheetHeaderLabel.Name = "stylesheetHeaderLabel";
			this.stylesheetHeaderLabel.Size = new System.Drawing.Size(370, 17);
			this.stylesheetHeaderLabel.TabIndex = 14;
			this.stylesheetHeaderLabel.Text = "::: Stylesheet :::::::";
			// 
			// traceHeaderLabel
			// 
			this.traceHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.traceHeaderLabel.BackColor = System.Drawing.Color.Gray;
			this.traceHeaderLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.traceHeaderLabel.ForeColor = System.Drawing.Color.White;
			this.traceHeaderLabel.Location = new System.Drawing.Point(12, 75);
			this.traceHeaderLabel.Name = "traceHeaderLabel";
			this.traceHeaderLabel.Size = new System.Drawing.Size(370, 17);
			this.traceHeaderLabel.TabIndex = 16;
			this.traceHeaderLabel.Text = "::: Tracing :::::::";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.label4.Location = new System.Drawing.Point(20, 179);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(108, 13);
			this.label4.TabIndex = 28;
			this.label4.Text = "Tracing Functionality:";
			// 
			// tracingFunctionalityComboBox
			// 
			this.tracingFunctionalityComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tracingFunctionalityComboBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tracingFunctionalityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tracingFunctionalityComboBox.FormattingEnabled = true;
			this.tracingFunctionalityComboBox.Location = new System.Drawing.Point(134, 176);
			this.tracingFunctionalityComboBox.Name = "tracingFunctionalityComboBox";
			this.tracingFunctionalityComboBox.Size = new System.Drawing.Size(241, 21);
			this.tracingFunctionalityComboBox.TabIndex = 5;
			this.tracingFunctionalityComboBox.SelectedIndexChanged += new System.EventHandler(this.TracingFunctionalityComboBox_SelectedIndexChanged);
			// 
			// borderLabel1
			// 
			this.borderLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.borderLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.borderLabel1.Location = new System.Drawing.Point(12, 95);
			this.borderLabel1.Name = "borderLabel1";
			this.borderLabel1.Size = new System.Drawing.Size(370, 109);
			this.borderLabel1.TabIndex = 17;
			// 
			// stylesheetComboBox
			// 
			this.stylesheetComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.stylesheetComboBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.stylesheetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.stylesheetComboBox.FormattingEnabled = true;
			this.stylesheetComboBox.Location = new System.Drawing.Point(134, 37);
			this.stylesheetComboBox.Name = "stylesheetComboBox";
			this.stylesheetComboBox.Size = new System.Drawing.Size(241, 21);
			this.stylesheetComboBox.TabIndex = 2;
			this.stylesheetComboBox.SelectedIndexChanged += new System.EventHandler(this.StylesheetComboBox_SelectedIndexChanged);
			// 
			// borderLabel3
			// 
			this.borderLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.borderLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.borderLabel3.Location = new System.Drawing.Point(12, 29);
			this.borderLabel3.Name = "borderLabel3";
			this.borderLabel3.Size = new System.Drawing.Size(370, 36);
			this.borderLabel3.TabIndex = 15;
			// 
			// chooseDirectoryButton
			// 
			this.chooseDirectoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chooseDirectoryButton.BackColor = System.Drawing.Color.Transparent;
			this.chooseDirectoryButton.Location = new System.Drawing.Point(340, 102);
			this.chooseDirectoryButton.Name = "chooseDirectoryButton";
			this.chooseDirectoryButton.Size = new System.Drawing.Size(35, 23);
			this.chooseDirectoryButton.TabIndex = 4;
			this.chooseDirectoryButton.Text = "...";
			this.chooseDirectoryButton.UseVisualStyleBackColor = false;
			this.chooseDirectoryButton.Click += new System.EventHandler(this.ChooseDirectoryButton_Click);
			// 
			// traceFilePathComboBox
			// 
			this.traceFilePathComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.traceFilePathComboBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.traceFilePathComboBox.FormattingEnabled = true;
			this.traceFilePathComboBox.Location = new System.Drawing.Point(134, 103);
			this.traceFilePathComboBox.Name = "traceFilePathComboBox";
			this.traceFilePathComboBox.Size = new System.Drawing.Size(200, 21);
			this.traceFilePathComboBox.TabIndex = 3;
			this.traceFilePathComboBox.TextChanged += new System.EventHandler(this.TraceFilePathComboBox_TextChanged);
			// 
			// PreferencesForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Silver;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(394, 244);
			this.Controls.Add(this.traceFilePathComboBox);
			this.Controls.Add(this.chooseDirectoryButton);
			this.Controls.Add(this.tracingFunctionalityComboBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.traceHeaderLabel);
			this.Controls.Add(this.borderLabel1);
			this.Controls.Add(this.stylesheetComboBox);
			this.Controls.Add(this.stylesheetHeaderLabel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.resetLayoutButton);
			this.Controls.Add(this.borderLabel3);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PreferencesForm";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Title";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PreferencesForm_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

	}

	#endregion

	private System.Windows.Forms.Button okButton;
	private System.Windows.Forms.Button cancelButton;
	private System.Windows.Forms.LinkLabel linkLabel1;
	private System.Windows.Forms.Label label3;
	private System.Windows.Forms.Button resetLayoutButton;
	private ComboBoxCustom stylesheetComboBox;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.Label stylesheetHeaderLabel;
	private BorderLabel borderLabel3;
	private System.Windows.Forms.Label traceHeaderLabel;
	private BorderLabel borderLabel1;
	private ComboBoxCustom tracingFunctionalityComboBox;
	private System.Windows.Forms.Label label4;
	private System.Windows.Forms.Button chooseDirectoryButton;
	private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
	private ComboBoxCustom traceFilePathComboBox;
}
