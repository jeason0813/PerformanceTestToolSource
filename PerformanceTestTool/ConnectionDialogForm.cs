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

using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class ConnectionDialogForm : Form
{
	public bool ConnectionChanged;
	private bool _okButtonClicked;
	private DatabaseOperation _databaseOperation;
	private BackgroundWorker _worker;
	private bool _runWorkerActive;

	public ConnectionDialogForm(DatabaseOperation databaseOperation)
	{
		InitializeComponent();
		SetApplicationName();

		_databaseOperation = databaseOperation;

		authenticationComboBox.SelectedIndex = 0;

		SetDefaultValues();
		SearchHistoryHandler.LoadItems(serverNameComboBox, "RecentListServerName");

		if (ConfigHandler.SaveConnectionString == "True")
		{
			saveValuesCheckBox.Checked = true;
		}
		else
		{
			saveValuesCheckBox.Checked = false;
		}

		if (ConfigHandler.OfflineModeToSave == "True")
		{
			offlineCheckBox.Checked = true;
		}
		else
		{
			offlineCheckBox.Checked = false;
		}

		InitializeWorker();
	}

	public DatabaseOperation GetDatabaseOperation()
	{
		return _databaseOperation;
	}

	public bool GetOkButtonClicked()
	{
		return _okButtonClicked;
	}

	protected override void OnLoad(EventArgs e)
	{
		BeginInvoke(new MethodInvoker(SetFocus));
		base.OnLoad(e);
	}

	private void InitializeWorker()
	{
		_worker = new BackgroundWorker();
		_worker.DoWork += Worker_DoWork;
		_worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
	}

	private void Worker_DoWork(object sender, DoWorkEventArgs e)
	{
		RunWorkerArgument arg = (RunWorkerArgument)e.Argument;

		string connectionString = arg.ConnectionString;

		if (_databaseOperation == null) // new connection, no connection has been made
		{
			_databaseOperation = new DatabaseOperation();
			_databaseOperation.InitializeDal(connectionString);
		}
		else // a connection has already been made, but should be changed
		{
			ConnectionChanged = _databaseOperation.ChangeConnection(connectionString);
		}

		if (_databaseOperation.Connected)
		{
			ConnectionChanged = true;
		}
		else
		{
			ConnectionChanged = false;
		}

		if (ConnectionChanged)
		{
			ConfigHandler.ConnectionString = connectionString;
		}

		if (saveValuesCheckBox.Checked && ConnectionChanged)
		{
			ConfigHandler.ConnectionStringToSave = connectionString;
			ConfigHandler.SaveConnectionString = "True";
			ConfigHandler.SaveConnection();
		}
	}

	private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		_runWorkerActive = false;
		EndConnect();

		if (ConnectionChanged)
		{
			if (saveValuesCheckBox.Checked)
			{
				SearchHistoryHandler.AddItem(serverNameComboBox, serverNameComboBox.Text, "RecentListServerName");
			}

			Close();
		}
	}

	private void SetApplicationName()
	{
		Text = GenericHelper.ApplicationName;
	}

	private void SetDefaultValues()
	{
		SqlConnectionStringBuilder tempConnString;

		if (_databaseOperation == null) // new connection, no connection has been made
		{
			tempConnString = new SqlConnectionStringBuilder(ConfigHandler.ConnectionString);
		}
		else // a connection has already been made, but should be changed
		{
			if (ConfigHandler.SaveConnectionString != "True")
			{
				tempConnString = new SqlConnectionStringBuilder(ConfigHandler.ConnectionString);
			}
			else
			{
				tempConnString = new SqlConnectionStringBuilder(ConfigHandler.ConnectionStringToSave);
			}
		}

		serverNameComboBox.Text = tempConnString.DataSource;

		if (!tempConnString.IntegratedSecurity)
		{
			authenticationComboBox.SelectedIndex = 1;

			userNameTextBox.Text = tempConnString.UserID;
			passwordTextBox.Text = tempConnString.Password;
		}
	}

	private void SetFocus()
	{
		serverNameComboBox.Focus();
	}

	private void CancelButton_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void AuthenticationComboBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		SetUserNameAndPasswordBoxes();
	}

	private void SetUserNameAndPasswordBoxes()
	{
		if (authenticationComboBox.SelectedIndex == 1)
		{
			userNameTextBox.Enabled = true;
			passwordTextBox.Enabled = true;
			usernameLabel.Enabled = true;
			passwordLabel.Enabled = true;
			userNameTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
			passwordTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
		}
		else
		{
			userNameTextBox.Enabled = false;
			passwordTextBox.Enabled = false;
			usernameLabel.Enabled = false;
			passwordLabel.Enabled = false;
			userNameTextBox.BackColor = System.Drawing.Color.Gainsboro;
			passwordTextBox.BackColor = System.Drawing.Color.Gainsboro;
		}
	}

	private void BeginConnect()
	{
		serverNameComboBox.Enabled = false;
		authenticationComboBox.Enabled = false;
		userNameTextBox.Enabled = false;
		passwordTextBox.Enabled = false;
		cancelButton.Enabled = false;
		okButton.Enabled = false;
		saveValuesCheckBox.Enabled = false;
		offlineCheckBox.Enabled = false;

		Application.DoEvents();
	}

	private void EndConnect()
	{
		serverNameComboBox.Enabled = true;
		authenticationComboBox.Enabled = true;
		SetUserNameAndPasswordBoxes();
		cancelButton.Enabled = true;
		okButton.Enabled = true;
		saveValuesCheckBox.Enabled = true;
		offlineCheckBox.Enabled = true;
	}

	private bool VerifyFields()
	{
		if (serverNameComboBox.Text.Trim() == "")
		{
			MessageBox.Show("Please enter server name.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			serverNameComboBox.Focus();
			return false;
		}

		if (authenticationComboBox.SelectedIndex == 1)
		{
			if (userNameTextBox.Text.Trim() == "")
			{
				MessageBox.Show("Please enter user name.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				userNameTextBox.Focus();
				return false;
			}
		}

		return true;
	}

	private void OkButton_Click(object sender, EventArgs e)
	{
		_okButtonClicked = true;

		if (Convert.ToBoolean(ConfigHandler.OfflineMode) != offlineCheckBox.Checked)
		{
			ConnectionChanged = true;
		}

		if (offlineCheckBox.Checked)
		{
			ConfigHandler.OfflineMode = "True";
		}
		else
		{
			ConfigHandler.OfflineMode = "False";
		}

		if (saveValuesCheckBox.Checked)
		{
			ConfigHandler.OfflineModeToSave = ConfigHandler.OfflineMode;
			ConfigHandler.SaveConnection();
		}

		if (offlineCheckBox.Checked)
		{
			Close();
		}
		else
		{
			ConfigHandler.OfflineMode = "False";
			GenericHelper.ShowErrorMessageForm = true;

			if (!VerifyFields())
			{
				return;
			}

			BeginConnect();

			RunWorkerArgument arg = new RunWorkerArgument();
			arg.ConnectionString = GetConnectionString();

			_runWorkerActive = true;
			_worker.RunWorkerAsync(arg);
		}
	}

	private string GetConnectionString()
	{
		SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder();

		if (authenticationComboBox.SelectedIndex == 1)
		{
			connectionString.IntegratedSecurity = false;
			connectionString.UserID = userNameTextBox.Text;
			connectionString.Password = passwordTextBox.Text;
		}
		else
		{
			connectionString.IntegratedSecurity = true;
		}

		connectionString.DataSource = serverNameComboBox.Text;
		connectionString.ApplicationName = GenericHelper.ApplicationName;

		return connectionString.ToString();
	}

	private class RunWorkerArgument
	{
		public string ConnectionString;
	}

	private void ConnectionDialogForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (_runWorkerActive)
		{
			e.Cancel = true;
		}
	}

	private void OfflineCheckBox_CheckedChanged(object sender, EventArgs e)
	{
		if (offlineCheckBox.Checked)
		{
			serverNameComboBox.Enabled = false;
			authenticationComboBox.Enabled = false;
			userNameTextBox.Enabled = false;
			passwordTextBox.Enabled = false;
		}
		else
		{
			serverNameComboBox.Enabled = true;
			authenticationComboBox.Enabled = true;
			SetUserNameAndPasswordBoxes();
		}
	}
}
