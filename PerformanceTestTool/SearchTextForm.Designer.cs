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

partial class SearchTextForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchTextForm));
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.searchHeaderLabel = new System.Windows.Forms.Label();
			this.optionsHeaderLabel = new System.Windows.Forms.Label();
			this.matchCaseCheckBox = new System.Windows.Forms.CheckBox();
			this.matchWholeWordCheckBox = new System.Windows.Forms.CheckBox();
			this.wrapAroundCheckBox = new System.Windows.Forms.CheckBox();
			this.showNoMoreMatchesMessageCheckBox = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.downRadioButton = new System.Windows.Forms.RadioButton();
			this.upRadioButton = new System.Windows.Forms.RadioButton();
			this.useRegExCheckBox = new System.Windows.Forms.CheckBox();
			this.searchTermComboBox = new System.Windows.Forms.ComboBox();
			this.borderLabel2 = new BorderLabel();
			this.borderLabel1 = new BorderLabel();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.BackColor = System.Drawing.Color.Transparent;
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(297, 225);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 24);
			this.cancelButton.TabIndex = 8;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = false;
			this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.BackColor = System.Drawing.Color.Transparent;
			this.okButton.Enabled = false;
			this.okButton.Location = new System.Drawing.Point(216, 225);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 24);
			this.okButton.TabIndex = 7;
			this.okButton.Text = "Find Next";
			this.okButton.UseVisualStyleBackColor = false;
			this.okButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.label4.Location = new System.Drawing.Point(20, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(59, 13);
			this.label4.TabIndex = 32;
			this.label4.Text = "Search for:";
			// 
			// searchHeaderLabel
			// 
			this.searchHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.searchHeaderLabel.BackColor = System.Drawing.Color.Gray;
			this.searchHeaderLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.searchHeaderLabel.ForeColor = System.Drawing.Color.White;
			this.searchHeaderLabel.Location = new System.Drawing.Point(12, 9);
			this.searchHeaderLabel.Name = "searchHeaderLabel";
			this.searchHeaderLabel.Size = new System.Drawing.Size(360, 17);
			this.searchHeaderLabel.TabIndex = 30;
			this.searchHeaderLabel.Text = "::: Search :::::::";
			// 
			// optionsHeaderLabel
			// 
			this.optionsHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.optionsHeaderLabel.BackColor = System.Drawing.Color.Gray;
			this.optionsHeaderLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.optionsHeaderLabel.ForeColor = System.Drawing.Color.White;
			this.optionsHeaderLabel.Location = new System.Drawing.Point(12, 75);
			this.optionsHeaderLabel.Name = "optionsHeaderLabel";
			this.optionsHeaderLabel.Size = new System.Drawing.Size(360, 17);
			this.optionsHeaderLabel.TabIndex = 33;
			this.optionsHeaderLabel.Text = "::: Options :::::::";
			// 
			// matchCaseCheckBox
			// 
			this.matchCaseCheckBox.AutoSize = true;
			this.matchCaseCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.matchCaseCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.matchCaseCheckBox.Location = new System.Drawing.Point(19, 123);
			this.matchCaseCheckBox.Name = "matchCaseCheckBox";
			this.matchCaseCheckBox.Size = new System.Drawing.Size(82, 17);
			this.matchCaseCheckBox.TabIndex = 2;
			this.matchCaseCheckBox.Text = "Match case";
			this.matchCaseCheckBox.UseVisualStyleBackColor = false;
			this.matchCaseCheckBox.CheckedChanged += new System.EventHandler(this.MatchCaseCheckBox_CheckedChanged);
			// 
			// matchWholeWordCheckBox
			// 
			this.matchWholeWordCheckBox.AutoSize = true;
			this.matchWholeWordCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.matchWholeWordCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.matchWholeWordCheckBox.Location = new System.Drawing.Point(19, 100);
			this.matchWholeWordCheckBox.Name = "matchWholeWordCheckBox";
			this.matchWholeWordCheckBox.Size = new System.Drawing.Size(113, 17);
			this.matchWholeWordCheckBox.TabIndex = 1;
			this.matchWholeWordCheckBox.Text = "Match whole word";
			this.matchWholeWordCheckBox.UseVisualStyleBackColor = false;
			this.matchWholeWordCheckBox.CheckedChanged += new System.EventHandler(this.MatchWholeWordCheckBox_CheckedChanged);
			// 
			// wrapAroundCheckBox
			// 
			this.wrapAroundCheckBox.AutoSize = true;
			this.wrapAroundCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.wrapAroundCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.wrapAroundCheckBox.Location = new System.Drawing.Point(19, 146);
			this.wrapAroundCheckBox.Name = "wrapAroundCheckBox";
			this.wrapAroundCheckBox.Size = new System.Drawing.Size(88, 17);
			this.wrapAroundCheckBox.TabIndex = 3;
			this.wrapAroundCheckBox.Text = "Wrap around";
			this.wrapAroundCheckBox.UseVisualStyleBackColor = false;
			this.wrapAroundCheckBox.CheckedChanged += new System.EventHandler(this.WrapAroundCheckBox_CheckedChanged);
			// 
			// showNoMoreMatchesMessageCheckBox
			// 
			this.showNoMoreMatchesMessageCheckBox.AutoSize = true;
			this.showNoMoreMatchesMessageCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.showNoMoreMatchesMessageCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.showNoMoreMatchesMessageCheckBox.Location = new System.Drawing.Point(19, 169);
			this.showNoMoreMatchesMessageCheckBox.Name = "showNoMoreMatchesMessageCheckBox";
			this.showNoMoreMatchesMessageCheckBox.Size = new System.Drawing.Size(152, 17);
			this.showNoMoreMatchesMessageCheckBox.TabIndex = 4;
			this.showNoMoreMatchesMessageCheckBox.Text = "Show \"No more matches.\"";
			this.showNoMoreMatchesMessageCheckBox.UseVisualStyleBackColor = false;
			this.showNoMoreMatchesMessageCheckBox.CheckedChanged += new System.EventHandler(this.ShowNoMoreMatchesMessageCheckBox_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.groupBox1.Controls.Add(this.downRadioButton);
			this.groupBox1.Controls.Add(this.upRadioButton);
			this.groupBox1.Location = new System.Drawing.Point(253, 100);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(112, 67);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Direction";
			// 
			// downRadioButton
			// 
			this.downRadioButton.AutoSize = true;
			this.downRadioButton.Location = new System.Drawing.Point(6, 42);
			this.downRadioButton.Name = "downRadioButton";
			this.downRadioButton.Size = new System.Drawing.Size(53, 17);
			this.downRadioButton.TabIndex = 1;
			this.downRadioButton.Text = "Down";
			this.downRadioButton.UseVisualStyleBackColor = true;
			this.downRadioButton.CheckedChanged += new System.EventHandler(this.DownRadioButton_CheckedChanged);
			// 
			// upRadioButton
			// 
			this.upRadioButton.AutoSize = true;
			this.upRadioButton.Location = new System.Drawing.Point(6, 19);
			this.upRadioButton.Name = "upRadioButton";
			this.upRadioButton.Size = new System.Drawing.Size(39, 17);
			this.upRadioButton.TabIndex = 0;
			this.upRadioButton.Text = "Up";
			this.upRadioButton.UseVisualStyleBackColor = true;
			this.upRadioButton.CheckedChanged += new System.EventHandler(this.UpRadioButton_CheckedChanged);
			// 
			// useRegExCheckBox
			// 
			this.useRegExCheckBox.AutoSize = true;
			this.useRegExCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.useRegExCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.useRegExCheckBox.Location = new System.Drawing.Point(19, 192);
			this.useRegExCheckBox.Name = "useRegExCheckBox";
			this.useRegExCheckBox.Size = new System.Drawing.Size(144, 17);
			this.useRegExCheckBox.TabIndex = 5;
			this.useRegExCheckBox.Text = "Use Regular Expressions";
			this.useRegExCheckBox.UseVisualStyleBackColor = false;
			this.useRegExCheckBox.CheckedChanged += new System.EventHandler(this.UseRegExCheckBox_CheckedChanged);
			// 
			// searchTermComboBox
			// 
			this.searchTermComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.searchTermComboBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.searchTermComboBox.FormattingEnabled = true;
			this.searchTermComboBox.Location = new System.Drawing.Point(85, 37);
			this.searchTermComboBox.Name = "searchTermComboBox";
			this.searchTermComboBox.Size = new System.Drawing.Size(280, 21);
			this.searchTermComboBox.TabIndex = 0;
			this.searchTermComboBox.TextChanged += new System.EventHandler(this.ComboBox1_TextChanged);
			// 
			// borderLabel2
			// 
			this.borderLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.borderLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.borderLabel2.Location = new System.Drawing.Point(12, 95);
			this.borderLabel2.Name = "borderLabel2";
			this.borderLabel2.Size = new System.Drawing.Size(360, 118);
			this.borderLabel2.TabIndex = 34;
			// 
			// borderLabel1
			// 
			this.borderLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.borderLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.borderLabel1.Location = new System.Drawing.Point(12, 29);
			this.borderLabel1.Name = "borderLabel1";
			this.borderLabel1.Size = new System.Drawing.Size(360, 36);
			this.borderLabel1.TabIndex = 31;
			// 
			// SearchTextForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Silver;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(384, 256);
			this.Controls.Add(this.searchTermComboBox);
			this.Controls.Add(this.useRegExCheckBox);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.showNoMoreMatchesMessageCheckBox);
			this.Controls.Add(this.wrapAroundCheckBox);
			this.Controls.Add(this.matchWholeWordCheckBox);
			this.Controls.Add(this.matchCaseCheckBox);
			this.Controls.Add(this.optionsHeaderLabel);
			this.Controls.Add(this.borderLabel2);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.searchHeaderLabel);
			this.Controls.Add(this.borderLabel1);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.cancelButton);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SearchTextForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Title";
			this.Activated += new System.EventHandler(this.SearchForm_Activated);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchForm_FormClosing);
			this.Load += new System.EventHandler(this.SearchForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

	}

	#endregion

	private System.Windows.Forms.Button cancelButton;
	private System.Windows.Forms.Button okButton;
	private System.Windows.Forms.Label label4;
	private System.Windows.Forms.Label searchHeaderLabel;
	private BorderLabel borderLabel1;
	private System.Windows.Forms.Label optionsHeaderLabel;
	private BorderLabel borderLabel2;
	private System.Windows.Forms.CheckBox matchCaseCheckBox;
	private System.Windows.Forms.CheckBox matchWholeWordCheckBox;
	private System.Windows.Forms.CheckBox wrapAroundCheckBox;
	private System.Windows.Forms.CheckBox showNoMoreMatchesMessageCheckBox;
	private System.Windows.Forms.GroupBox groupBox1;
	private System.Windows.Forms.RadioButton downRadioButton;
	private System.Windows.Forms.RadioButton upRadioButton;
	private System.Windows.Forms.CheckBox useRegExCheckBox;
	private System.Windows.Forms.ComboBox searchTermComboBox;
}
