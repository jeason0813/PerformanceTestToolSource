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
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

public class Dal
{
	public delegate void PrintEventHandler(int connectionNumber, string text, string taskName);
	public event PrintEventHandler PrintEvent;

	public delegate void InfoMessageEventHandler(string infoMessage);
	public event InfoMessageEventHandler InfoMessageEvent;

	public bool Connected;
	private SqlConnectionStringBuilder _connString;
	private SqlConnection _conn;
	private SqlCommand _cmd;
	private bool _throwError;
	private bool _exitOnError;
	private bool _success = true;
	private bool _onlyShowOneErrorMessageFormOnMultipleErrors;
	private int _connectionNumber;
	private string _taskName;

	public void InitializeDal(string connectionString)
	{
		Connected = OpenConnection(connectionString, false, true, 0, 100);
	}

	public void InitializeDal(string connectionString, bool usePooling, int minPooling, int maxPooling)
	{
		Connected = OpenConnection(connectionString, false, usePooling, minPooling, maxPooling);
	}

	public int GetSqlServerVersion()
	{
		if (_conn.ServerVersion != null)
		{
			return Convert.ToInt32(_conn.ServerVersion.Substring(0, _conn.ServerVersion.IndexOf(".")));
		}

		return -1;
	}

	public string GetDataSource()
	{
		return _connString.DataSource;
	}

	public void ConnInfoMessage(object sender, SqlInfoMessageEventArgs e)
	{
		if (_throwError)
		{
			if (e.Errors[0].Number == 5701) // "Changed database context to '...'."
			{
				return;
			}
			else if (e.Errors[0].Number == 5703) // "Changed language setting to '...'."
			{
				return;
			}
			else if (e.Errors[0].Number == 8153) // "Warning: Null value is eliminated by an aggregate or other SET operation."
			{
				return;
			}
			else if (e.Errors[0].Number == 4035) // "Processed ... pages for database ..." from Backup and Restore
			{
				return;
			}
			else if (e.Errors[0].Number == 3014) // "BACKUP DATABASE successfully processed" and "RESTORE DATABASE successfully processed"
			{
				return;
			}
			else if (e.Errors[0].Number == 5060) // "Nonqualified transactions are being rolled back. Estimated rollback completion: 100%."
			{
				return;
			}
			else if (e.Errors[0].Number == 2528) // "DBCC execution completed. If DBCC printed error messages, contact your system administrator."
			{
				return;
			}
			else if (e.Errors[0].Number == 7998) // "Checking identity information: current identity value '...', current column value '...'."
			{
				return;
			}
			else if (e.Errors[0].Number == 944) // "Converting database '...' from version ... to the current version ..."
			{
				return;
			}
			else if (e.Errors[0].Number == 951) // "Database '...' running the upgrade step from version ... to version ..."
			{
				return;
			}
			else if (e.Errors[0].Number == 9927) // "The full-text search condition contained noise word(s)."
			{
				return;
			}
			else if (e.Errors[0].Number == 15457) // "Configuration option 'show advanced options' changed from 1 to 1. Run the RECONFIGURE statement to install."
			{
				return;
			}
			else if (e.Errors[0].Number == 8152) // "String or binary data would be truncated."
			{
				return;
			}
			else if (e.Errors[0].Number == 7989) // "Checking identity information: current identity value 'NULL'."
			{
				return;
			}
			else if (IgnoreError(e.Errors[0].Number))
			{
				return;
			}
			else if (e.Errors[0].Number == 0)
			{
				FirePrintEvent(_connectionNumber, e.Message, _taskName);
				return;
			}
			else if (e.Errors[0].Number != 0 && e.Message == "Incorrect syntax near 'go'.")
			{
				_success = false;
				MessageBox.Show(string.Format("{0}\r\n\r\n'GO' is not a valid T-SQL statement. Create another task instead.", e.Message), GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			else if (e.Errors[0].Number == 50000 && e.Errors[0].State >= 1 && e.Errors[0].State <= 3 && e.Errors[0].Class <= 1)
			{
				MessageBoxIcon icon = MessageBoxIcon.Information;

				switch (e.Errors[0].State)
				{
					case 2:
						icon = MessageBoxIcon.Warning;
						break;
					case 3:
						icon = MessageBoxIcon.Error;
						break;
				}

				MessageBox.Show(e.Errors[0].Message, GenericHelper.ApplicationName, MessageBoxButtons.OK, icon);

				if (e.Errors[0].Class == 1)
				{
					_success = false;
				}

				return;
			}

			HandleError(e.Errors[0].Number, e.Message, _cmd.CommandText);
		}
		else
		{
			FireSendMessageEvent(e.Message);
		}
	}

	public string GetDatabaseName()
	{
		return _connString.InitialCatalog;
	}

	public string GetUserName()
	{
		return _connString.UserID;
	}

	public string GetPassword()
	{
		return _connString.Password;
	}

	public bool GetIntegratedSecurity()
	{
		return _connString.IntegratedSecurity;
	}

	// used for: ImportTraceFile, CreateTrace and DatabaseOperation.*
	public DataTable ExecuteDataTable(string sql)
	{
		_throwError = true;
		_exitOnError = false;

		DataSet ds = DoExecuteDataSet(sql, true);

		if (ds != null && ds.Tables.Count > 0)
		{
			return ds.Tables[0];
		}
		else
		{
			return null;
		}
	}

	// used for task run
	public bool Execute(string sql, int connectionNumber, string taskName)
	{
		_throwError = true;
		_exitOnError = false;
		_onlyShowOneErrorMessageFormOnMultipleErrors = true;
		_connectionNumber = connectionNumber;
		_taskName = taskName;

		DoExecuteDataSet(sql, false);

		return _success;
	}

	// used for: StopDeleteTrace, SetTraceStatus, StartTrace and StartTraceRecording
	public bool Execute(string sql)
	{
		_throwError = true;
		_exitOnError = false;
		_onlyShowOneErrorMessageFormOnMultipleErrors = false;

		DoExecuteDataSet(sql, false);

		return _success;
	}

	public static bool DBConnectionStillActive()
	{
		DatabaseOperation databaseOperation = new DatabaseOperation();
		databaseOperation.InitializeDal(ConfigHandler.ConnectionString);

		DataTable dataTable = databaseOperation.ExecuteDataTableStillAliveCheck("-- still alive?\r\nselect 'yes' alive");

		if (dataTable != null)
		{
			if (dataTable.Rows[0]["alive"].ToString() == "yes")
			{
				return true;
			}
		}

		return false;
	}

	public void Dispose()
	{
		if (_cmd != null)
		{
			_cmd.Cancel();
			_cmd.Dispose();
		}

		if (_conn != null)
		{
			_conn.Close();
			_conn.Dispose();
		}
	}

	public bool ChangeConnection(string connectionString)
	{
		Connected = OpenConnection(connectionString, false, true, 0, 100);
		return Connected;
	}

	private DataTable ExecuteDataTableStillAliveCheck(string sql)
	{
		_throwError = true;
		_exitOnError = false;
		DataSet ds = DoExecuteDataSet(sql, true);

		if (ds != null && ds.Tables.Count > 0)
		{
			return ds.Tables[0];
		}
		else
		{
			return null;
		}
	}

	private static bool IgnoreError(int errorNumber)
	{
		string[] ignoreErrors = ConfigHandler.IgnoreErrors.Split(';');

		foreach (string ignoreError in ignoreErrors)
		{
			if (ignoreError != "")
			{
				if (Convert.ToInt32(ignoreError) == errorNumber)
				{
					return true;
				}
			}
		}

		return false;
	}

	private static string SetConnectionPoolOptions(string connectionString, bool usePooling, int minPooling, int maxPooling)
	{
		SqlConnectionStringBuilder connString = new SqlConnectionStringBuilder(connectionString);
		connString.Pooling = usePooling;
		connString.MinPoolSize = minPooling;
		connString.MaxPoolSize = maxPooling;
		return connString.ToString();
	}

	private bool OpenConnection(string connectionString, bool exitOnError, bool usePooling, int minPooling, int maxPooling)
	{
		_exitOnError = exitOnError;
		_onlyShowOneErrorMessageFormOnMultipleErrors = true;

		connectionString = SetConnectionPoolOptions(connectionString, usePooling, minPooling, maxPooling);
		SqlConnection conn = new SqlConnection(connectionString);

		try
		{
			conn.Open();

			bool isSqlServerVersionSupported = IsSqlServerVersionSupported(conn.ServerVersion);

			if (!isSqlServerVersionSupported)
			{
				conn.Close();
				HandleError(-1, "SQL Server version not supported.", "");
			}
			else
			{
				if (_conn != null)
				{
					_conn.Close();
				}

				_conn = conn;
				_conn.InfoMessage += ConnInfoMessage;
				_conn.FireInfoMessageEventOnUserErrors = true;

				_connString = new SqlConnectionStringBuilder(connectionString);

				return true;
			}
		}
		catch (SqlException ex)
		{
			HandleError(-1, ex.Message, string.Format("Connection string:\r\n\r\n{0}", conn.ConnectionString));
		}
		catch (InvalidOperationException ex)
		{
			HandleError(-1, ex.Message, "Please check the connection settings.");
		}

		return false;
	}

	private static bool IsSqlServerVersionSupported(string serverVersion)
	{
		int version = Convert.ToInt32(serverVersion.Substring(0, serverVersion.IndexOf(".")));

		if (version < 9 || version > 13)
		{
			return false;
		}

		return true;
	}

	private void FirePrintEvent(int connectionNumber, string text, string taskName)
	{
		if (PrintEvent != null)
		{
			PrintEvent(connectionNumber, text, taskName);
		}
	}

	private void FireSendMessageEvent(string message)
	{
		if (InfoMessageEvent != null)
		{
			InfoMessageEvent(message);
		}
	}

	private DataSet DoExecuteDataSet(string sql, bool returnDataSet)
	{
		_success = true;

		DataSet dataSet = new DataSet();

		using (_cmd = new SqlCommand())
		{
			_cmd.CommandTimeout = 0;
			_cmd.CommandType = CommandType.Text;

			try
			{
				dataSet = ExecuteCommand(sql, returnDataSet);
			}
			catch (SqlException ex)
			{
				if (ex.Message == "The query processor could not start the necessary thread resources for parallel query execution.")
				{
					HandleError(-1, string.Format("{0}\r\n\r\nTry lowering the number of connections.", ex.Message), "");
				}
				else if (ex.Message.StartsWith("A transport-level error has occurred when sending the request to the server."))
				{
					dataSet = ExecuteCommand(sql, returnDataSet); // will be caught if connection is lost, but _conn.State has not noticed it yet. The execution will be retried once, so the connection can be opened again
				}
				else if (ex.Message == "Thread was being aborted.")
				{
				}
				else
				{
					HandleError(-1, string.Format("Error in database communication.\r\n\r\n{0}", ex.Message), "");
				}
			}
			catch (Exception ex)
			{
				if (ex.Message == "Thread was being aborted.")
				{
				}
				else
				{
					HandleError(-1, string.Format("Error in database communication.\r\n\r\n{0}", ex.Message), "");
				}
			}
		}

		return dataSet;
	}

	private DataSet ExecuteCommand(string sql, bool returnDataSet)
	{
		if (_conn == null)
		{
			return null;
		}

		DataSet dataSet = new DataSet();

		if (_conn.State == ConnectionState.Closed)
		{
			try
			{
				_conn.Open();
			}
			catch (Exception ex)
			{
				HandleError(-1, ex.Message, "");
				return null;
			}
		}

		_cmd.Connection = _conn;
		_cmd.CommandText = sql;

		if (returnDataSet)
		{
			using (SqlDataAdapter dataAdapter = new SqlDataAdapter(_cmd))
			{
				dataAdapter.Fill(dataSet);
			}
		}
		else
		{
			_cmd.ExecuteNonQuery();
		}

		return dataSet;
	}

	private void HandleError(int errorNumber, string message, string sql)
	{
		_success = false;

		if (GenericHelper.ShowErrorMessageForm)
		{
			if (_onlyShowOneErrorMessageFormOnMultipleErrors)
			{
				GenericHelper.ShowErrorMessageForm = false;
			}

			string okButtonText = "Close";

			if (_exitOnError)
			{
				okButtonText = "Exit";
			}

			if (GenericHelper.UnattendedErrorLogFileName != null)
			{
				string error;

				if (sql != "")
				{
					error = string.Format("Error: {0}\r\n\r\nSQL:\r\n{1}", message, sql);
				}
				else
				{
					error = string.Format("Error: {0}", message);
				}

				try
				{
					File.WriteAllText(GenericHelper.UnattendedErrorLogFileName, error);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			else
			{
				string location;

				lock (this)
				{
					if (GenericHelper.ActiveRunningStepAndName != null)
					{
						location = GenericHelper.ActiveRunningStepAndName;
					}
					else
					{
						location = GenericHelper.ApplicationName;
					}
				}

				ErrorFormHandler.ErrorOccuredEvent(errorNumber, okButtonText, message, sql, location);
			}
		}

		if (_exitOnError)
		{
			Dispose();
			Environment.Exit(-1);
		}
	}
}
