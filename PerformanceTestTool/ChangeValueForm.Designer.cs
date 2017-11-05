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

partial class ChangeValueForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeValueForm));
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.changeValuesHeaderLabel = new System.Windows.Forms.Label();
			this.newValueTextBox = new System.Windows.Forms.TextBox();
			this.borderLabel1 = new BorderLabel();
			this.SuspendLayout();
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.BackColor = System.Drawing.Color.Transparent;
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(234, 77);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 24);
			this.cancelButton.TabIndex = 2;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = false;
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.BackColor = System.Drawing.Color.Transparent;
			this.okButton.Location = new System.Drawing.Point(153, 77);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 24);
			this.okButton.TabIndex = 1;
			this.okButton.Text = "Ok";
			this.okButton.UseVisualStyleBackColor = false;
			this.okButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.label4.Location = new System.Drawing.Point(20, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(61, 13);
			this.label4.TabIndex = 32;
			this.label4.Text = "New value:";
			// 
			// changeValuesHeaderLabel
			// 
			this.changeValuesHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.changeValuesHeaderLabel.BackColor = System.Drawing.Color.Gray;
			this.changeValuesHeaderLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.changeValuesHeaderLabel.ForeColor = System.Drawing.Color.White;
			this.changeValuesHeaderLabel.Location = new System.Drawing.Point(12, 9);
			this.changeValuesHeaderLabel.Name = "changeValuesHeaderLabel";
			this.changeValuesHeaderLabel.Size = new System.Drawing.Size(297, 17);
			this.changeValuesHeaderLabel.TabIndex = 30;
			this.changeValuesHeaderLabel.Text = "::: Title :::::::";
			// 
			// newValueTextBox
			// 
			this.newValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.newValueTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.newValueTextBox.Location = new System.Drawing.Point(87, 37);
			this.newValueTextBox.Name = "newValueTextBox";
			this.newValueTextBox.Size = new System.Drawing.Size(215, 20);
			this.newValueTextBox.TabIndex = 0;
			// 
			// borderLabel1
			// 
			this.borderLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.borderLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.borderLabel1.Location = new System.Drawing.Point(12, 29);
			this.borderLabel1.Name = "borderLabel1";
			this.borderLabel1.Size = new System.Drawing.Size(297, 36);
			this.borderLabel1.TabIndex = 31;
			// 
			// ChangeValueForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Silver;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(321, 108);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.changeValuesHeaderLabel);
			this.Controls.Add(this.newValueTextBox);
			this.Controls.Add(this.borderLabel1);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.cancelButton);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ChangeValueForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Title";
			this.ResumeLayout(false);
			this.PerformLayout();

	}

	#endregion

	private System.Windows.Forms.Button cancelButton;
	private System.Windows.Forms.Button okButton;
	private System.Windows.Forms.Label label4;
	private System.Windows.Forms.Label changeValuesHeaderLabel;
	private System.Windows.Forms.TextBox newValueTextBox;
	private BorderLabel borderLabel1;
}
