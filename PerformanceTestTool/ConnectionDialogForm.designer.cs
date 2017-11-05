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

partial class ConnectionDialogForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionDialogForm));
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.serverNameLabel = new System.Windows.Forms.Label();
			this.authenticationLabel = new System.Windows.Forms.Label();
			this.authenticationComboBox = new ComboBoxCustom();
			this.usernameLabel = new System.Windows.Forms.Label();
			this.passwordLabel = new System.Windows.Forms.Label();
			this.userNameTextBox = new System.Windows.Forms.TextBox();
			this.passwordTextBox = new System.Windows.Forms.TextBox();
			this.saveValuesCheckBox = new System.Windows.Forms.CheckBox();
			this.infoHeaderLabel = new System.Windows.Forms.Label();
			this.borderLabel3 = new BorderLabel();
			this.offlineCheckBox = new System.Windows.Forms.CheckBox();
			this.serverNameComboBox = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.BackColor = System.Drawing.Color.Transparent;
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(226, 156);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 24);
			this.okButton.TabIndex = 7;
			this.okButton.Text = "Ok";
			this.okButton.UseVisualStyleBackColor = false;
			this.okButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.BackColor = System.Drawing.Color.Transparent;
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(307, 156);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 24);
			this.cancelButton.TabIndex = 8;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = false;
			this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// serverNameLabel
			// 
			this.serverNameLabel.AutoSize = true;
			this.serverNameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.serverNameLabel.Location = new System.Drawing.Point(17, 41);
			this.serverNameLabel.Name = "serverNameLabel";
			this.serverNameLabel.Size = new System.Drawing.Size(70, 13);
			this.serverNameLabel.TabIndex = 11;
			this.serverNameLabel.Text = "Server name:";
			// 
			// authenticationLabel
			// 
			this.authenticationLabel.AutoSize = true;
			this.authenticationLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.authenticationLabel.Location = new System.Drawing.Point(17, 67);
			this.authenticationLabel.Name = "authenticationLabel";
			this.authenticationLabel.Size = new System.Drawing.Size(78, 13);
			this.authenticationLabel.TabIndex = 12;
			this.authenticationLabel.Text = "Authentication:";
			// 
			// authenticationComboBox
			// 
			this.authenticationComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.authenticationComboBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.authenticationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.authenticationComboBox.FormattingEnabled = true;
			this.authenticationComboBox.Items.AddRange(new object[] {
            "Windows Authentication",
            "SQL Server Authentication"});
			this.authenticationComboBox.Location = new System.Drawing.Point(111, 64);
			this.authenticationComboBox.MaxDropDownItems = 2;
			this.authenticationComboBox.Name = "authenticationComboBox";
			this.authenticationComboBox.Size = new System.Drawing.Size(263, 21);
			this.authenticationComboBox.TabIndex = 2;
			this.authenticationComboBox.SelectedIndexChanged += new System.EventHandler(this.AuthenticationComboBox_SelectedIndexChanged);
			// 
			// usernameLabel
			// 
			this.usernameLabel.AutoSize = true;
			this.usernameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.usernameLabel.Location = new System.Drawing.Point(32, 92);
			this.usernameLabel.Name = "usernameLabel";
			this.usernameLabel.Size = new System.Drawing.Size(61, 13);
			this.usernameLabel.TabIndex = 14;
			this.usernameLabel.Text = "User name:";
			// 
			// passwordLabel
			// 
			this.passwordLabel.AutoSize = true;
			this.passwordLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.passwordLabel.Location = new System.Drawing.Point(32, 120);
			this.passwordLabel.Name = "passwordLabel";
			this.passwordLabel.Size = new System.Drawing.Size(56, 13);
			this.passwordLabel.TabIndex = 15;
			this.passwordLabel.Text = "Password:";
			// 
			// userNameTextBox
			// 
			this.userNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.userNameTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.userNameTextBox.Location = new System.Drawing.Point(134, 91);
			this.userNameTextBox.Name = "userNameTextBox";
			this.userNameTextBox.Size = new System.Drawing.Size(240, 20);
			this.userNameTextBox.TabIndex = 3;
			// 
			// passwordTextBox
			// 
			this.passwordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.passwordTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.passwordTextBox.Location = new System.Drawing.Point(134, 117);
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.PasswordChar = '*';
			this.passwordTextBox.Size = new System.Drawing.Size(240, 20);
			this.passwordTextBox.TabIndex = 4;
			// 
			// saveValuesCheckBox
			// 
			this.saveValuesCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.saveValuesCheckBox.AutoSize = true;
			this.saveValuesCheckBox.BackColor = System.Drawing.Color.Transparent;
			this.saveValuesCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.saveValuesCheckBox.Location = new System.Drawing.Point(12, 160);
			this.saveValuesCheckBox.Name = "saveValuesCheckBox";
			this.saveValuesCheckBox.Size = new System.Drawing.Size(85, 17);
			this.saveValuesCheckBox.TabIndex = 5;
			this.saveValuesCheckBox.Text = "Save values";
			this.saveValuesCheckBox.UseVisualStyleBackColor = false;
			// 
			// infoHeaderLabel
			// 
			this.infoHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.infoHeaderLabel.BackColor = System.Drawing.Color.Gray;
			this.infoHeaderLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.infoHeaderLabel.ForeColor = System.Drawing.Color.White;
			this.infoHeaderLabel.Location = new System.Drawing.Point(12, 9);
			this.infoHeaderLabel.Name = "infoHeaderLabel";
			this.infoHeaderLabel.Size = new System.Drawing.Size(370, 17);
			this.infoHeaderLabel.TabIndex = 23;
			this.infoHeaderLabel.Text = "::: Connect to SQL Server :::::::";
			// 
			// borderLabel3
			// 
			this.borderLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.borderLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.borderLabel3.Location = new System.Drawing.Point(12, 29);
			this.borderLabel3.Name = "borderLabel3";
			this.borderLabel3.Size = new System.Drawing.Size(370, 117);
			this.borderLabel3.TabIndex = 24;
			// 
			// offlineCheckBox
			// 
			this.offlineCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.offlineCheckBox.AutoSize = true;
			this.offlineCheckBox.BackColor = System.Drawing.Color.Transparent;
			this.offlineCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.offlineCheckBox.Location = new System.Drawing.Point(103, 160);
			this.offlineCheckBox.Name = "offlineCheckBox";
			this.offlineCheckBox.Size = new System.Drawing.Size(85, 17);
			this.offlineCheckBox.TabIndex = 6;
			this.offlineCheckBox.Text = "Offline mode";
			this.offlineCheckBox.UseVisualStyleBackColor = false;
			this.offlineCheckBox.CheckedChanged += new System.EventHandler(this.OfflineCheckBox_CheckedChanged);
			// 
			// serverNameComboBox
			// 
			this.serverNameComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.serverNameComboBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.serverNameComboBox.FormattingEnabled = true;
			this.serverNameComboBox.Location = new System.Drawing.Point(111, 38);
			this.serverNameComboBox.Name = "serverNameComboBox";
			this.serverNameComboBox.Size = new System.Drawing.Size(263, 21);
			this.serverNameComboBox.TabIndex = 1;
			// 
			// ConnectionDialogForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Silver;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(394, 188);
			this.Controls.Add(this.serverNameComboBox);
			this.Controls.Add(this.offlineCheckBox);
			this.Controls.Add(this.serverNameLabel);
			this.Controls.Add(this.authenticationLabel);
			this.Controls.Add(this.infoHeaderLabel);
			this.Controls.Add(this.authenticationComboBox);
			this.Controls.Add(this.saveValuesCheckBox);
			this.Controls.Add(this.passwordTextBox);
			this.Controls.Add(this.usernameLabel);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.userNameTextBox);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.passwordLabel);
			this.Controls.Add(this.borderLabel3);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ConnectionDialogForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Title";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConnectionDialogForm_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

	}

	#endregion

	private System.Windows.Forms.Button okButton;
	private System.Windows.Forms.Button cancelButton;
	private System.Windows.Forms.Label serverNameLabel;
	private System.Windows.Forms.Label authenticationLabel;
	private ComboBoxCustom authenticationComboBox;
	private System.Windows.Forms.Label usernameLabel;
	private System.Windows.Forms.Label passwordLabel;
	private System.Windows.Forms.TextBox userNameTextBox;
	private System.Windows.Forms.TextBox passwordTextBox;
	private System.Windows.Forms.CheckBox saveValuesCheckBox;
	private System.Windows.Forms.Label infoHeaderLabel;
	private BorderLabel borderLabel3;
	private System.Windows.Forms.CheckBox offlineCheckBox;
	private System.Windows.Forms.ComboBox serverNameComboBox;
}
