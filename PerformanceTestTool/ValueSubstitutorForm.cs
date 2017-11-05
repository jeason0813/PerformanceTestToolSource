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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

public partial class ValueSubstitutorForm : Form
{
	private int _parametersDataGridViewMouseRowHit;
	private BackgroundWorker _worker;
	private bool _parameterSubstitutionChangesMade;
	private string _parameterSubstitutionFileName;
	private bool _inputChangesMade;
	private string _inputFileName;

	public ValueSubstitutorForm()
	{
		InitializeComponent();
		Initialize();
	}

	private void Initialize()
	{
		ConfigHandler.LoadConfig();
		GenericHelper.SetSize(this, ConfigHandler.ValueSubstitutorWindowSize);
		MinimumSize = new Size(700, 500);  // error in .NET

		InitializeWorker();

		SearchHistoryHandler.LoadItems(taskCollectionComboBox, "RecentListTaskCollection_ValueSubstitutor");
		SearchHistoryHandler.LoadItems(parameterFileComboBox, "RecentListParameterFile_ValueSubstitutor");
		SearchHistoryHandler.LoadItems(databaseComboBox, "RecentListDatabase_ValueSubstitutor");

		string valueSubstitutorNewFile = RegistryHandler.ReadFromRegistry("ValueSubstitutorNewFile");

		if (taskCollectionComboBox.Items.Count > 0)
		{
			taskCollectionComboBox.SelectedIndex = 0;
			LoadTaskCollection(taskCollectionComboBox.Text);
		}

		if (valueSubstitutorNewFile != "1")
		{
			if (parameterFileComboBox.Items.Count > 0)
			{
				parameterFileComboBox.SelectedIndex = 0;
				LoadParameterFile(parameterFileComboBox.Text);
			}
			else
			{
				SetDefaultParametersDataGridValues();
			}
		}
	}

	private void InitializeWorker()
	{
		_worker = new BackgroundWorker();
		_worker.WorkerReportsProgress = true;
		_worker.DoWork += Worker_DoWork;
		_worker.ProgressChanged += Worker_ProgressChanged;
		_worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
	}

	private void AddParameterGridEvents()
	{
		parametersDataGridView.CellValueChanged += ParametersDataGridView_CellValueChanged;
		parametersDataGridView.RowsAdded += ParametersDataGridView_RowsAdded;
		parametersDataGridView.RowsRemoved += ParametersDataGridView_RowsRemoved;
		databaseComboBox.TextChanged += DatabaseComboBox_TextChanged;
	}

	private void RemoveParameterGridEvents()
	{
		parametersDataGridView.CellValueChanged -= ParametersDataGridView_CellValueChanged;
		parametersDataGridView.RowsAdded -= ParametersDataGridView_RowsAdded;
		parametersDataGridView.RowsRemoved -= ParametersDataGridView_RowsRemoved;
		databaseComboBox.TextChanged -= DatabaseComboBox_TextChanged;
	}

	private void ParametersDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
	{
		SetChangesMadeParameterSubstitution(true);
	}

	private void ParametersDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
	{
		SetChangesMadeParameterSubstitution(true);
	}

	private void ParametersDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		SetChangesMadeParameterSubstitution(true);
	}

	private void SetDefaultParametersDataGridValues()
	{
		parametersDataGridView.Rows.Add("123", "Normal", "@param1", "int", true);
	}

	private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void DeleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
	{
		DialogResult result = MessageBox.Show("Delete selected rows?", GenericHelper.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

		if (result.ToString() == "Yes")
		{
			List<DataGridViewRow> rowCollection = new List<DataGridViewRow>();

			if (_parametersDataGridViewMouseRowHit >= 0)
			{
				rowCollection.Add(parametersDataGridView.Rows[_parametersDataGridViewMouseRowHit]);
			}

			foreach (DataGridViewCell cell in parametersDataGridView.SelectedCells)
			{
				DataGridViewRow row = cell.OwningRow;

				if (!row.IsNewRow && !rowCollection.Contains(row) && row.Selected)
				{
					rowCollection.Add(row);
				}
			}

			foreach (DataGridViewRow row in rowCollection)
			{
				if (!row.IsNewRow)
				{
					parametersDataGridView.Rows.Remove(row);
				}
			}
		}
	}

	private void ParametersDataGridView_MouseDown(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			DataGridView.HitTestInfo hit = parametersDataGridView.HitTest(e.X, e.Y);

			if (hit.Type == DataGridViewHitTestType.Cell || hit.Type == DataGridViewHitTestType.RowHeader)
			{
				_parametersDataGridViewMouseRowHit = hit.RowIndex;
			}
			else
			{
				_parametersDataGridViewMouseRowHit = -1;
			}
		}
	}

	private static bool Import(string xml)
	{
		TaskCollection temporaryTaskCollection = TaskHelper.XmlToTaskCollection(xml);

		if (temporaryTaskCollection != null)
		{
			TaskHelper.TaskCollection = temporaryTaskCollection;
			return true;
		}

		return false;
	}

	private void StartButton_Click(object sender, EventArgs e)
	{
		if (AnyParameters())
		{
			if (databaseComboBox.Text.Trim().Length > 0)
			{
				SearchHistoryHandler.AddItem(databaseComboBox, databaseComboBox.Text, "RecentListDatabase_ValueSubstitutor");
			}
			else
			{
				MessageBox.Show("Please enter a database name.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				databaseComboBox.Focus();
				return;
			}
		}

		RemoveParameterGridEvents();

		foreach (DataGridViewRow row in parametersDataGridView.Rows)
		{
			row.Cells["ReplacedValuesColumn"].Value = null;
		}

		AddParameterGridEvents();

		if (taskCollectionComboBox.Text == "")
		{
			MessageBox.Show("Please choose a Task Collection file.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			return;
		}
		else if (!File.Exists(taskCollectionComboBox.Text))
		{
			MessageBox.Show("Task Collection file does not exist.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			return;
		}

		string xml = XmlHelper.ReadXmlFromFile(taskCollectionComboBox.Text);

		if (xml != null)
		{
			bool success = Import(xml);

			if (success)
			{
				success = CheckForUniqueValues("ValueColumn");

				if (!success)
				{
					MessageBox.Show("Values must be unique.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}

			if (success)
			{
				success = CheckForUniqueParameters();

				if (!success)
				{
					MessageBox.Show("Parameters must be unique.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}

			if (success)
			{
				if (TaskHelper.TaskCollection.Tasks.Count > 0)
				{
					runProgressBar.Maximum = 100;
				}
				else
				{
					runProgressBar.Maximum = 0;
				}

				runProgressBar.Value = 0;

				startButton.Enabled = false;
				parametersDataGridView.Enabled = false;
				taskCollectionComboBox.Enabled = false;
				parameterFileComboBox.Enabled = false;
				fileToolStripMenuItem.Enabled = false;
				inputToolStrip.Enabled = false;
				parametersToolStrip.Enabled = false;
				databaseComboBox.Enabled = false;

				_worker.RunWorkerAsync();
			}
		}
	}

	private bool CheckForUniqueValues(string columnName)
	{
		List<string> elementList = new List<string>();

		for (int i = 0; i < parametersDataGridView.Rows.Count; i++)
		{
			if (parametersDataGridView.Rows[i].Cells[columnName].Value != null && parametersDataGridView.Rows[i].Cells[columnName].Value.ToString() != "")
			{
				if (!elementList.Contains(parametersDataGridView.Rows[i].Cells[columnName].Value.ToString()))
				{
					elementList.Add(parametersDataGridView.Rows[i].Cells[columnName].Value.ToString());
				}
				else
				{
					return false;
				}
			}
		}

		return true;
	}

	private bool CheckForUniqueParameters()
	{
		List<string> elementList = new List<string>();

		for (int i = 0; i < parametersDataGridView.Rows.Count; i++)
		{
			if (parametersDataGridView.Rows[i].Cells["ParameterColumn"].Value != null && parametersDataGridView.Rows[i].Cells["ParameterColumn"].Value.ToString() != "")
			{
				if (!elementList.Contains(parametersDataGridView.Rows[i].Cells["ParameterColumn"].Value.ToString()))
				{
					elementList.Add(parametersDataGridView.Rows[i].Cells["ParameterColumn"].Value.ToString());
				}
				else
				{
					return false;
				}
			}
		}

		return true;
	}

	private class WorkerProgressObject
	{
		public readonly int Task;
		public readonly int TotalTasks;

		public WorkerProgressObject(int task, int totalTasks)
		{
			Task = task;
			TotalTasks = totalTasks;
		}
	}

	private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		if (e.ProgressPercentage == -1)
		{
			WorkerProgressObject progressObject = (WorkerProgressObject)e.UserState;
			statusLabel.Text = string.Format("Status: Task {0}/{1}", progressObject.Task, progressObject.TotalTasks);
			statusLabel.Refresh();

			int pct = progressObject.Task * 100 / progressObject.TotalTasks;

			if (progressObject.Task == progressObject.TotalTasks)
			{
				pct = 100;
			}

			if (pct != runProgressBar.Value)
			{
				if (pct == runProgressBar.Maximum)
				{
					runProgressBar.Maximum = 101;
					runProgressBar.Value = 101;
					runProgressBar.Maximum = 100;
				}
				else
				{
					runProgressBar.Value = pct + 1;
				}

				runProgressBar.Value = pct;
			}
		}
	}

	private class ReplaceCounter
	{
		public readonly string Value;
		public int ReplaceCount;

		public ReplaceCounter(string value)
		{
			Value = value;
			ReplaceCount = 1;
		}
	}

	private static void SetReplaceCounter(IList<ReplaceCounter> replaceCounters, string value)
	{
		bool found = false;

		foreach (ReplaceCounter replaceCounter in replaceCounters)
		{
			if (replaceCounter.Value == value)
			{
				replaceCounter.ReplaceCount++;
				found = true;
				break;
			}
		}

		if (!found)
		{
			replaceCounters.Add(new ReplaceCounter(value));
		}
	}

	private void UpdateShownReplaceCounter(IList replaceCounters)
	{
		RemoveParameterGridEvents();

		foreach (DataGridViewRow row in parametersDataGridView.Rows)
		{
			string value = "";
			string parameter = "";
			string dataType = "";
			bool enabled = false;

			if (row.Cells["ValueColumn"].Value != null)
			{
				value = row.Cells["ValueColumn"].Value.ToString();
			}

			if (row.Cells["ParameterColumn"].Value != null)
			{
				parameter = row.Cells["ParameterColumn"].Value.ToString();
			}

			if (row.Cells["DataTypeColumn"].Value != null)
			{
				dataType = row.Cells["DataTypeColumn"].Value.ToString();
			}

			if (row.Cells["EnabledColumn"].Value != null)
			{
				enabled = Convert.ToBoolean(row.Cells["EnabledColumn"].Value);
			}

			if (!row.IsNewRow && value != "" && enabled && ((parameter.StartsWith("@") && dataType != "") || (!parameter.StartsWith("@") && dataType == "")))
			{
				bool found = false;

				foreach (ReplaceCounter replaceCounter in replaceCounters)
				{
					if (replaceCounter.Value == value)
					{
						row.Cells["ReplacedValuesColumn"].Value = replaceCounter.ReplaceCount;
						found = true;
						break;
					}
				}

				if (!found)
				{
					row.Cells["ReplacedValuesColumn"].Value = 0;
				}
			}
		}

		AddParameterGridEvents();
	}

	private class TaskNumberParameterAndSql
	{
		public readonly int TaskNumber;
		public readonly string Sql;
		public readonly List<Parameter> Parameters = new List<Parameter>();

		public TaskNumberParameterAndSql(int taskNumber, string sql, Parameter parameter)
		{
			TaskNumber = taskNumber;
			Sql = sql;
			Parameters.Add(parameter);
		}
	}

	private class Parameter
	{
		public readonly string ParameterName;
		public readonly string DataType;

		public Parameter(string parameterName, string dataType)
		{
			ParameterName = parameterName;
			DataType = dataType;
		}
	}

	private static void SetTaskNumberParameterAndSql(List<TaskNumberParameterAndSql> taskNumberParametersAndSql, int taskNumber, string sql, Parameter parameter)
	{
		bool found = false;

		foreach (TaskNumberParameterAndSql taskNumberParameterAndSql in taskNumberParametersAndSql)
		{
			if (taskNumberParameterAndSql.TaskNumber == taskNumber)
			{
				taskNumberParameterAndSql.Parameters.Add(parameter);
				found = true;
				break;
			}
		}

		if (!found)
		{
			taskNumberParametersAndSql.Add(new TaskNumberParameterAndSql(taskNumber, sql, parameter));
		}
	}

	private void Worker_DoWork(object sender, DoWorkEventArgs e)
	{
		int totalTasks = TaskHelper.TaskCollection.Tasks.Count;

		IList<ReplaceCounter> replaceCounters = new List<ReplaceCounter>();
		List<TaskNumberParameterAndSql> taskNumberParametersAndSql = new List<TaskNumberParameterAndSql>();

		for (int i = 0; i < totalTasks; i++)
		{
			foreach (DataGridViewRow row in parametersDataGridView.Rows)
			{
				if (row.IsNewRow || !Convert.ToBoolean(row.Cells["EnabledColumn"].Value))
				{
					continue;
				}

				string value = "";
				string valueType = "";
				string parameter = "";
				string dataType = "";

				if (row.Cells["ValueColumn"].Value != null)
				{
					value = row.Cells["ValueColumn"].Value.ToString();
				}

				if (row.Cells["ValueTypeColumn"].Value != null)
				{
					valueType = row.Cells["ValueTypeColumn"].Value.ToString();
				}

				if (row.Cells["ParameterColumn"].Value != null)
				{
					parameter = row.Cells["ParameterColumn"].Value.ToString();
				}

				if (row.Cells["DataTypeColumn"].Value != null)
				{
					dataType = row.Cells["DataTypeColumn"].Value.ToString();
				}

				Task task = TaskHelper.TaskCollection.Tasks[i];

				if (!row.IsNewRow && value != "" && ((parameter.StartsWith("@") && dataType != "") || (!parameter.StartsWith("@") && dataType == "")))
				{
					_worker.ReportProgress(-1, new WorkerProgressObject(i + 1, totalTasks));

					if (((valueType == "Normal" && task.Sql.IndexOf(value) >= 0) || (valueType == "RegEx" && Regex.IsMatch(task.Sql, value))))
					{
						SetReplaceCounter(replaceCounters, value);
						SetTaskNumberParameterAndSql(taskNumberParametersAndSql, i, task.Sql, new Parameter(parameter, dataType));
					}
				}
			}

			//System.Threading.Thread.Sleep(10);
		}

		ModifySql(taskNumberParametersAndSql);

		e.Result = replaceCounters;
	}

	private string ReplaceHandler(string sql, string parameter, string dataType)
	{
		string value = "";
		string valueType = "";

		foreach (DataGridViewRow row in parametersDataGridView.Rows)
		{
			if (!row.IsNewRow && row.Cells["ParameterColumn"].Value.ToString() == parameter && Convert.ToBoolean(row.Cells["EnabledColumn"].Value))
			{
				parameter = row.Cells["ParameterColumn"].Value.ToString();
				value = row.Cells["ValueColumn"].Value.ToString();
				valueType = row.Cells["ValueTypeColumn"].Value.ToString();
				break;
			}
		}

		if (dataType != "")
		{
			bool isNumericDataTypeOrGuid = IsNumericOrGuidDataType(dataType);

			if (isNumericDataTypeOrGuid)
			{
				sql = sql.Replace(string.Format("'{0}'", value), string.Format("{0}Char", parameter));
			}
		}

		if (valueType == "Normal")
		{
			sql = sql.Replace(value, parameter);
		}
		else if (valueType == "RegEx")
		{
			Regex regex = new Regex(value);
			sql = regex.Replace(sql, parameter);
		}

		return sql;
	}

	private static bool IsNumericOrGuidDataType(string dataType)
	{
		if (dataType.ToLower() == "bigint" || dataType.ToLower() == "bit" || dataType.ToLower() == "decimal" || dataType.ToLower() == "int" || dataType.ToLower() == "money" || dataType.ToLower() == "numeric" || dataType.ToLower() == "smallint" || dataType.ToLower() == "smallmoney" || dataType.ToLower() == "tinyint" || dataType.ToLower() == "float" || dataType.ToLower() == "real" || dataType.ToLower() == "uniqueidentifier")
		{
			return true;
		}

		return false;
	}

	private void ModifySql(List<TaskNumberParameterAndSql> taskNumberParametersAndSql)
	{
		foreach (TaskNumberParameterAndSql taskNumberParameterAndSql in taskNumberParametersAndSql)
		{
			StringBuilder declareStatement = new StringBuilder();
			StringBuilder selectStatement = new StringBuilder();
			StringBuilder numericCharConversion = new StringBuilder();

			string modifiedSql = HandleExistingParameters(taskNumberParameterAndSql);

			int insertLinePos = 0;

			if (taskNumberParameterAndSql.Sql.Substring(0, 4).ToLower() == "use ")
			{
				insertLinePos = taskNumberParameterAndSql.Sql.IndexOf("\r\n");
			}

			foreach (Parameter parameter in taskNumberParameterAndSql.Parameters)
			{
				if (parameter.ParameterName.StartsWith("@"))
				{
					if (declareStatement.Length > 0)
					{
						declareStatement.Append("\r\n");
					}

					declareStatement.Append(string.Format("declare {0} {1}", parameter.ParameterName, parameter.DataType));

					if (selectStatement.Length > "select ".Length)
					{
						selectStatement.Append(", ");
					}

					selectStatement.Append(string.Format("{0} = p.{1}", parameter.ParameterName, parameter.ParameterName.Substring(1)));

					bool isNumericDataType = IsNumericOrGuidDataType(parameter.DataType);

					if (isNumericDataType)
					{
						if (numericCharConversion.Length > 0)
						{
							numericCharConversion.Append("\r\n");
						}

						numericCharConversion.Append(string.Format("\r\ndeclare {0}Char varchar(50)\r\nset {0}Char = convert(varchar(50), {0})", parameter.ParameterName));
					}
				}

				modifiedSql = ReplaceHandler(modifiedSql, parameter.ParameterName, parameter.DataType);
			}

			string lineFeedsBegin = "";
			string lineFeedsEnd = "";

			if (insertLinePos > 0)
			{
				lineFeedsBegin = "\r\n\r\n";
			}
			else
			{
				lineFeedsEnd = "\r\n\r\n";
			}

			if (numericCharConversion.Length > 0)
			{
				numericCharConversion.Insert(0, "\r\n");
			}

			if (declareStatement.Length > 0)
			{
				modifiedSql = modifiedSql.Insert(insertLinePos, string.Format("{2}-- BEGIN: Parameter retrieval\r\n{0}\r\n\r\nselect {1}\r\nfrom dbo.ParameterTable p with (nolock)\r\nwhere p.Connection = {{connection}}{4}\r\n-- END: Parameter retrieval{3}", declareStatement, selectStatement, lineFeedsBegin, lineFeedsEnd, numericCharConversion));
			}

			for (int i = 0; i < TaskHelper.TaskCollection.Tasks.Count; i++)
			{
				if (i == taskNumberParameterAndSql.TaskNumber)
				{
					TaskHelper.TaskCollection.Tasks[i].Sql = modifiedSql;
				}
			}
		}
	}

	private static string HandleExistingParameters(TaskNumberParameterAndSql taskNumberParameterAndSql)
	{
		int removeExistingBeginLinePos = taskNumberParameterAndSql.Sql.IndexOf("\r\n-- BEGIN: Parameter retrieval");
		int removeExistingEndLinePos = taskNumberParameterAndSql.Sql.IndexOf("-- END: Parameter retrieval\r\n");

		int existingDeclarationsBeginLinePos = removeExistingBeginLinePos + "\r\n-- BEGIN: Parameter retrieval\r\n".Length;

		if (taskNumberParameterAndSql.Sql.Length > existingDeclarationsBeginLinePos + "declare ".Length)
		{
			while (taskNumberParameterAndSql.Sql.Substring(existingDeclarationsBeginLinePos, "declare ".Length) == "declare ")
			{
				int spacePos = taskNumberParameterAndSql.Sql.Substring(existingDeclarationsBeginLinePos + "declare ".Length).IndexOf(" ");
				string parameterName = taskNumberParameterAndSql.Sql.Substring(existingDeclarationsBeginLinePos + "declare ".Length, spacePos);

				int lineEndPos = taskNumberParameterAndSql.Sql.Substring(existingDeclarationsBeginLinePos + "declare ".Length + parameterName.Length + 1).IndexOf("\r\n");
				string dataType = taskNumberParameterAndSql.Sql.Substring(existingDeclarationsBeginLinePos + "declare ".Length + parameterName.Length + 1, lineEndPos);

				bool found = false;

				foreach (Parameter parameter in taskNumberParameterAndSql.Parameters)
				{
					if (parameter.ParameterName == parameterName)
					{
						found = true;
						break;
					}
				}

				if (!found)
				{
					taskNumberParameterAndSql.Parameters.Add(new Parameter(parameterName, dataType));
				}

				existingDeclarationsBeginLinePos = existingDeclarationsBeginLinePos + "declare ".Length + parameterName.Length + 1 + lineEndPos + "\r\n".Length;
			}
		}

		string modifiedSql;

		if (removeExistingBeginLinePos > -1 && removeExistingEndLinePos > -1)
		{
			string modifiedSqlBegin = taskNumberParameterAndSql.Sql.Substring(0, removeExistingBeginLinePos);
			string modifiedSqlEnd = taskNumberParameterAndSql.Sql.Substring(removeExistingEndLinePos + "-- END: Parameter retrieval\r\n".Length);

			modifiedSql = string.Format("{0}{1}", modifiedSqlBegin, modifiedSqlEnd);
		}
		else
		{
			modifiedSql = taskNumberParameterAndSql.Sql;
		}

		return modifiedSql;
	}

	private static void DeleteSetupAndTeardownTasks()
	{
		for (int i = TaskHelper.TaskCollection.Tasks.Count - 1; i >= 0; i--)
		{
			Task task = TaskHelper.TaskCollection.Tasks[i];

			if (task.Type == TaskHelper.TaskType.Setup || task.Type == TaskHelper.TaskType.Teardown)
			{
				if (task.Name == "Drop Parameter table" || task.Name == "Create Parameter table")
				{
					TaskHelper.TaskCollection.Tasks.RemoveAt(i);
				}
			}
		}
	}

	private void AddSetupAndTeardownTasks(string database)
	{
		StringBuilder parameters = new StringBuilder();

		foreach (DataGridViewRow row in parametersDataGridView.Rows)
		{
			string parameter = "";
			string dataType = "";
			bool enabled = false;

			if (row.Cells["ParameterColumn"].Value != null)
			{
				parameter = row.Cells["ParameterColumn"].Value.ToString();
			}

			if (row.Cells["DataTypeColumn"].Value != null)
			{
				dataType = row.Cells["DataTypeColumn"].Value.ToString();
			}

			if (row.Cells["EnabledColumn"].Value != null)
			{
				enabled = Convert.ToBoolean(row.Cells["EnabledColumn"].Value);
			}

			if (!row.IsNewRow && parameter != "" && dataType != "" && enabled)
			{
				if (parameter.StartsWith("@"))
				{
					parameters.Append(string.Format(",\r\n	{0} {1} null", parameter.Substring(1), dataType));
				}
			}
		}

		Task createParameterTable = new Task("Create Parameter table", "", 0, string.Format("use [{0}]\r\n\r\nif exists (select * from dbo.sysobjects where id = object_id(N'dbo.ParameterTable') and objectproperty(id, N'IsUserTable') = 1)\r\nbegin\r\n	drop table dbo.ParameterTable\r\nend\r\n\r\ncreate table dbo.ParameterTable\r\n(\r\n	Connection int not null{1}\r\n)\r\n\r\ncreate unique clustered index ix_ParameterTable_CL on dbo.ParameterTable (Connection)\r\n", database, parameters), TaskHelper.TaskType.Setup, true, false);
		Task dropParameterTable = new Task("Drop Parameter table", "", 0, string.Format("use [{0}]\r\n\r\nif exists (select * from dbo.sysobjects where id = object_id(N'dbo.ParameterTable') and objectproperty(id, N'IsUserTable') = 1)\r\nbegin\r\n	drop table dbo.ParameterTable\r\nend\r\n", database), TaskHelper.TaskType.Teardown, true, false);

		TaskHelper.TaskCollection.Tasks.Insert(0, createParameterTable);
		TaskHelper.TaskCollection.Tasks.Insert(TaskHelper.TaskCollection.Tasks.Count, dropParameterTable);
	}

	private bool AnyParameters()
	{
		foreach (DataGridViewRow row in parametersDataGridView.Rows)
		{
			string value = "";
			string parameter = "";
			string dataType = "";
			bool enabled = false;

			if (row.Cells["ValueColumn"].Value != null)
			{
				value = row.Cells["ValueColumn"].Value.ToString();
			}

			if (row.Cells["ParameterColumn"].Value != null)
			{
				parameter = row.Cells["ParameterColumn"].Value.ToString();
			}

			if (row.Cells["DataTypeColumn"].Value != null)
			{
				dataType = row.Cells["DataTypeColumn"].Value.ToString();
			}

			if (row.Cells["EnabledColumn"].Value != null)
			{
				enabled = Convert.ToBoolean(row.Cells["EnabledColumn"].Value);
			}

			if (!row.IsNewRow && value != "" && enabled && ((parameter.StartsWith("@") && dataType != "")))
			{
				if (parameter.StartsWith("@"))
				{
					return true;
				}
			}
		}

		return false;
	}

	private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		if (AnyParameters())
		{
			DeleteSetupAndTeardownTasks();
			AddSetupAndTeardownTasks(databaseComboBox.Text);
		}

		IList replaceCounters = (IList)e.Result;
		UpdateShownReplaceCounter(replaceCounters);

		saveToolStripButton1.Enabled = true;
		saveAsToolStripButton1.Enabled = true;

		SetChangesMadeInput(true);

		statusLabel.Text = "Status: Completed";
		startButton.Enabled = true;
		parametersDataGridView.Enabled = true;
		taskCollectionComboBox.Enabled = true;
		parameterFileComboBox.Enabled = true;
		fileToolStripMenuItem.Enabled = true;
		inputToolStrip.Enabled = true;
		parametersToolStrip.Enabled = true;
		databaseComboBox.Enabled = true;
	}

	private bool SaveChangesParameterSubstitution()
	{
		if (_parameterSubstitutionChangesMade)
		{
			string text;

			if (_parameterSubstitutionFileName == null)
			{
				text = "Save value substitution changes?";
			}
			else
			{
				text = string.Format("Save value substitution changes to \"{0}\"?", _parameterSubstitutionFileName);
			}

			DialogResult result = MessageBox.Show(text, GenericHelper.ApplicationName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

			if (result.ToString() == "Yes")
			{
				bool success = SaveParametersDataGrid();

				if (!success)
				{
					return false;
				}
			}
			else if (result.ToString() == "Cancel")
			{
				return false;
			}
		}

		return true;
	}

	private bool SaveChangesInput()
	{
		if (_inputChangesMade)
		{
			DialogResult result = MessageBox.Show(string.Format("Save Task Collection changes to \"{0}\"?", _inputFileName), GenericHelper.ApplicationName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

			if (result.ToString() == "Yes")
			{
				bool success = SaveInput();

				if (!success)
				{
					return false;
				}
			}
			else if (result.ToString() == "Cancel")
			{
				return false;
			}
		}

		return true;
	}

	private string GetFileNameParameterSubstitution()
	{
		if (_parameterSubstitutionFileName == null)
		{
			DialogResult result = saveFileDialog2.ShowDialog();
			Application.DoEvents();

			if (result.ToString() == "OK")
			{
				SetFileNameParameterSubstitution(saveFileDialog2.FileName);
			}
			else
			{
				return null;
			}
		}

		return _parameterSubstitutionFileName;
	}

	private string GetFileNameInput()
	{
		if (_inputFileName == null)
		{
			try
			{
				saveFileDialog1.InitialDirectory = Path.GetDirectoryName(taskCollectionComboBox.Text);
				saveFileDialog1.FileName = Path.GetFileName(taskCollectionComboBox.Text);
			}
			catch
			{
			}

			DialogResult result = saveFileDialog1.ShowDialog();
			Application.DoEvents();

			if (result.ToString() == "OK")
			{
				SetFileNameInput(saveFileDialog1.FileName);
			}
			else
			{
				return null;
			}
		}

		return _inputFileName;
	}

	private string ParametersDataGridToXml()
	{
		StringBuilder sb = new StringBuilder();
		sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?><root>");
		sb.Append(string.Format("<rows database=\"{0}\">", databaseComboBox.Text));

		foreach (DataGridViewRow row in parametersDataGridView.Rows)
		{
			string value = "";
			string valueType = "";
			string parameter = "";
			string dataType = "";
			bool enabled = false;

			if (row.Cells["ValueColumn"].Value != null)
			{
				value = row.Cells["ValueColumn"].Value.ToString();
			}

			if (row.Cells["ValueTypeColumn"].Value != null)
			{
				valueType = row.Cells["ValueTypeColumn"].Value.ToString();
			}

			if (row.Cells["ParameterColumn"].Value != null)
			{
				parameter = row.Cells["ParameterColumn"].Value.ToString();
			}

			if (row.Cells["DataTypeColumn"].Value != null)
			{
				dataType = row.Cells["DataTypeColumn"].Value.ToString();
			}

			if (row.Cells["EnabledColumn"].Value != null)
			{
				enabled = Convert.ToBoolean(row.Cells["EnabledColumn"].Value);
			}

			if (!row.IsNewRow)
			{
				sb.Append(string.Format("<row value=\"{0}\" valueType=\"{1}\" parameter=\"{2}\" dataType=\"{3}\" enabled=\"{4}\" />", System.Security.SecurityElement.Escape(value), System.Security.SecurityElement.Escape(valueType), System.Security.SecurityElement.Escape(parameter), System.Security.SecurityElement.Escape(dataType), enabled));
			}
		}

		sb.Append("</rows>");
		sb.Append("</root>");

		return sb.ToString();
	}

	private bool XmlToParametersDataGrid(string xml)
	{
		try
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xml);

			XmlNode rowsNode = xmlDocument.SelectSingleNode("root/rows");
			string database = rowsNode.Attributes["database"].Value;

			databaseComboBox.Text = database;

			XmlNodeList rowNodes = xmlDocument.SelectNodes("root/rows/row");

			foreach (XmlElement node in rowNodes)
			{
				parametersDataGridView.Rows.Add(node.GetAttribute("value"), node.GetAttribute("valueType"), node.GetAttribute("parameter"), node.GetAttribute("dataType"), node.GetAttribute("enabled"));
			}
		}
		catch (Exception ex)
		{
			if (ex.Message == "Object reference not set to an instance of an object.")
			{
				MessageBox.Show("Value substitution file is missing one or more elements.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				MessageBox.Show(ex.Message, GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

			return false;
		}

		return true;
	}

	private bool SaveParametersDataGrid()
	{
		parametersDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);

		string fileName = GetFileNameParameterSubstitution();

		if (fileName != null)
		{
			XmlHelper.WriteXmlToFile(ParametersDataGridToXml(), fileName);
			RegistryHandler.Delete("ValueSubstitutorNewFile");

			SetChangesMadeParameterSubstitution(false);

			return true;
		}

		return false;
	}

	private bool SaveInput()
	{
		string fileName = GetFileNameInput();

		if (fileName != null)
		{
			TaskHelper.SaveTaskCollection(fileName);

			SetChangesMadeInput(false);

			return true;
		}

		return false;
	}

	private bool LoadParametersDataGrid(string xml)
	{
		try
		{
			RemoveParameterGridEvents();
			parametersDataGridView.Rows.Clear();

			bool success = XmlToParametersDataGrid(xml);

			AddParameterGridEvents();
			SetChangesMadeParameterSubstitution(false);

			return success;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			return false;
		}
	}

	private void SetChangesMadeParameterSubstitution(bool value)
	{
		bool setTitle = false;

		if (value != _parameterSubstitutionChangesMade)
		{
			setTitle = true;
		}

		_parameterSubstitutionChangesMade = value;

		if (_parameterSubstitutionChangesMade)
		{
			saveToolStripButton.Enabled = true;
			saveAsToolStripButton.Enabled = true;
		}
		else
		{
			saveToolStripButton.Enabled = false;
			saveAsToolStripButton.Enabled = false;
		}

		if (setTitle)
		{
			SetTitleParameterSubstitution();
		}
	}

	private void SetChangesMadeInput(bool value)
	{
		bool setTitle = false;

		if (value != _inputChangesMade)
		{
			setTitle = true;
		}

		_inputChangesMade = value;

		if (_inputChangesMade)
		{
			saveToolStripButton1.Enabled = true;
			saveAsToolStripButton1.Enabled = true;
		}
		else
		{
			saveToolStripButton1.Enabled = false;
			saveAsToolStripButton1.Enabled = false;
		}

		if (setTitle)
		{
			SetTitleInput();
		}
	}

	private void SetTitleParameterSubstitution()
	{
		string fileName = "";

		if (_parameterSubstitutionFileName != null)
		{
			fileName = string.Format(" - {0}", Path.GetFileName(_parameterSubstitutionFileName));
		}

		string changesMade = "";

		if (_parameterSubstitutionChangesMade)
		{
			changesMade = " *";
		}

		parameterSubstitutionHeaderLabel.Text = string.Format("::: Value substitution{0}{1} :::::::", fileName, changesMade);
	}

	private void SetTitleInput()
	{
		string fileName = "";

		if (_inputFileName != null)
		{
			fileName = string.Format(" - {0}", Path.GetFileName(_inputFileName));
		}

		string changesMade = "";

		if (_inputChangesMade)
		{
			changesMade = " *";
		}

		inputHeaderLabel.Text = string.Format("::: Task Collection{0}{1} :::::::", fileName, changesMade);
	}

	private void SetFileNameParameterSubstitution(string fileName)
	{
		_parameterSubstitutionFileName = fileName;
	}

	private void SetFileNameInput(string fileName)
	{
		_inputFileName = fileName;
	}

	private void NewToolStripButton_Click(object sender, EventArgs e)
	{
		DialogResult overwrite = MessageBox.Show("Create new?", GenericHelper.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

		if (overwrite.ToString() == "Yes")
		{
			bool success = SaveChangesParameterSubstitution();

			if (success)
			{
				CreateNew();
			}
		}
	}

	private void CreateNew()
	{
		parametersDataGridView.Rows.Clear();

		_parameterSubstitutionFileName = null;

		databaseComboBox.Text = "";
		parameterFileComboBox.SelectedIndex = -1;

		RegistryHandler.SaveToRegistry("ValueSubstitutorNewFile", "1");

		SetChangesMadeParameterSubstitution(false);
	}

	private void OpenToolStripButton_Click(object sender, EventArgs e)
	{
		bool success = SaveChangesParameterSubstitution();

		if (success)
		{
			DialogResult result = openFileDialog2.ShowDialog();
			Application.DoEvents();

			if (result.ToString() == "OK")
			{
				LoadParameterFile(openFileDialog2.FileName);
			}
		}
	}

	private void ParameterFileComboBox_SelectionChangeCommitted(object sender, EventArgs e)
	{
		bool success = SaveChangesParameterSubstitution();

		if (success)
		{
			LoadParameterFile(parameterFileComboBox.Text);
		}
	}

	private void LoadParameterFile(string fileName)
	{
		if (!File.Exists(fileName))
		{
			MessageBox.Show("Value substitution file does not exist.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			CreateNew();
			return;
		}

		string xml = XmlHelper.ReadXmlFromFile(fileName);

		if (xml != null)
		{
			bool success = LoadParametersDataGrid(xml);

			if (success)
			{
				SearchHistoryHandler.AddItem(parameterFileComboBox, fileName, "RecentListParameterFile_ValueSubstitutor");

				parameterFileComboBox.SelectedIndex = 0;

				SetChangesMadeParameterSubstitution(false);
				SetFileNameParameterSubstitution(fileName);
				SetTitleParameterSubstitution();

				RegistryHandler.Delete("ValueSubstitutorNewFile");
			}
			else
			{
				CreateNew();
			}
		}
	}

	private void SaveToolStripButton_Click(object sender, EventArgs e)
	{
		bool success = SaveParametersDataGrid();

		if (success)
		{
			SearchHistoryHandler.AddItem(parameterFileComboBox, _parameterSubstitutionFileName, "RecentListParameterFile_ValueSubstitutor");

			parameterFileComboBox.SelectedIndex = 0;
		}
	}

	private void SaveAsToolStripButton_Click(object sender, EventArgs e)
	{
		string currentFileName = _parameterSubstitutionFileName;
		_parameterSubstitutionFileName = null;

		bool success = SaveParametersDataGrid();

		if (success)
		{
			SearchHistoryHandler.AddItem(parameterFileComboBox, _parameterSubstitutionFileName, "RecentListParameterFile_ValueSubstitutor");

			parameterFileComboBox.SelectedIndex = 0;
		}
		else
		{
			_parameterSubstitutionFileName = currentFileName;
		}
	}

	private void OpenToolStripButton1_Click(object sender, EventArgs e)
	{
		bool success = SaveChangesInput();

		if (success)
		{
			try
			{
				openFileDialog1.InitialDirectory = Path.GetDirectoryName(taskCollectionComboBox.Text);
			}
			catch
			{
			}

			DialogResult result = openFileDialog1.ShowDialog();
			Application.DoEvents();

			if (result.ToString() == "OK")
			{
				LoadTaskCollection(openFileDialog1.FileName);
			}
		}
	}

	private void TaskCollectionComboBox_SelectionChangeCommitted(object sender, EventArgs e)
	{
		bool success = SaveChangesInput();

		if (success)
		{
			LoadTaskCollection(taskCollectionComboBox.Text);
		}
		else
		{
			taskCollectionComboBox.Text = _inputFileName;
		}
	}

	private void LoadTaskCollection(string fileName)
	{
		TaskHelper.TaskCollectionFileName = fileName;
		SearchHistoryHandler.AddItem(taskCollectionComboBox, fileName, "RecentListTaskCollection_ValueSubstitutor");

		taskCollectionComboBox.SelectedIndex = 0;

		SetChangesMadeInput(false);
		SetFileNameInput(fileName);
		SetTitleInput();
	}

	private void SaveToolStripButton1_Click(object sender, EventArgs e)
	{
		SaveInput();
	}

	private void SaveAsToolStripButton1_Click(object sender, EventArgs e)
	{
		string currentFileName = _inputFileName;
		_inputFileName = null;

		bool success = SaveInput();

		if (success)
		{
			TaskHelper.TaskCollectionFileName = _inputFileName;
			SearchHistoryHandler.AddItem(taskCollectionComboBox, _inputFileName, "RecentListTaskCollection_ValueSubstitutor");

			taskCollectionComboBox.SelectedIndex = 0;
		}
		else
		{
			_inputFileName = currentFileName;
		}
	}

	private void ValueSubstitutorForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (_inputChangesMade)
		{
			bool success = SaveChangesInput();

			if (!success)
			{
				e.Cancel = true;
				return;
			}
		}

		if (_parameterSubstitutionChangesMade)
		{
			bool success = SaveChangesParameterSubstitution();

			if (!success)
			{
				e.Cancel = true;
			}
		}
	}

	private void DatabaseComboBox_TextChanged(object sender, EventArgs e)
	{
		SetChangesMadeParameterSubstitution(true);
	}

	private void ParametersDataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
	{
		RemoveParameterGridEvents();

		e.Row.Cells["ValueTypeColumn"].Value = "Normal";
		e.Row.Cells["EnabledColumn"].Value = "True";

		AddParameterGridEvents();
	}

	private void TaskCollectionDragDrop(DragEventArgs e)
	{
		string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

		if (files != null)
		{
			if (files.Length == 1)
			{
				bool success = SaveChangesInput();

				if (success)
				{
					LoadTaskCollection(files[0]);
				}
			}
		}
	}

	private static void TaskCollectionDragOver(DragEventArgs e)
	{
		string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

		if (files != null)
		{
			if (files.Length == 1)
			{
				e.Effect = DragDropEffects.Move;
			}
		}
	}

	private void TaskCollectionBorderLabel_DragDrop(object sender, DragEventArgs e)
	{
		TaskCollectionDragDrop(e);
	}

	private void TaskCollectionBorderLabel_DragOver(object sender, DragEventArgs e)
	{
		TaskCollectionDragOver(e);
	}

	private void TaskCollectionComboBox_DragDrop(object sender, DragEventArgs e)
	{
		TaskCollectionDragDrop(e);
	}

	private void TaskCollectionComboBox_DragOver(object sender, DragEventArgs e)
	{
		TaskCollectionDragOver(e);
	}

	private void InputToolStrip_DragDrop(object sender, DragEventArgs e)
	{
		TaskCollectionDragDrop(e);
	}

	private void InputToolStrip_DragOver(object sender, DragEventArgs e)
	{
		TaskCollectionDragOver(e);
	}

	private void ValueSubstitutionDragDrop(DragEventArgs e)
	{
		string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

		if (files != null)
		{
			if (files.Length == 1)
			{
				bool success = SaveChangesParameterSubstitution();

				if (success)
				{
					LoadParameterFile(files[0]);
				}
			}
		}
	}

	private static void ValueSubstitutionDragOver(DragEventArgs e)
	{
		string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

		if (files != null)
		{
			if (files.Length == 1)
			{
				e.Effect = DragDropEffects.Move;
			}
		}
	}

	private void ParametersToolStrip_DragDrop(object sender, DragEventArgs e)
	{
		ValueSubstitutionDragDrop(e);
	}

	private void ParametersToolStrip_DragOver(object sender, DragEventArgs e)
	{
		ValueSubstitutionDragOver(e);
	}

	private void ValueSubstitutionBorderLabel_DragDrop(object sender, DragEventArgs e)
	{
		ValueSubstitutionDragDrop(e);
	}

	private void ValueSubstitutionBorderLabel_DragOver(object sender, DragEventArgs e)
	{
		ValueSubstitutionDragOver(e);
	}

	private void DatabaseLabel_DragDrop(object sender, DragEventArgs e)
	{
		ValueSubstitutionDragDrop(e);
	}

	private void DatabaseLabel_DragOver(object sender, DragEventArgs e)
	{
		ValueSubstitutionDragOver(e);
	}

	private void DatabaseComboBox_DragDrop(object sender, DragEventArgs e)
	{
		ValueSubstitutionDragDrop(e);
	}

	private void DatabaseComboBox_DragOver(object sender, DragEventArgs e)
	{
		ValueSubstitutionDragOver(e);
	}

	private void ParametersDataGridView_DragDrop(object sender, DragEventArgs e)
	{
		ValueSubstitutionDragDrop(e);
	}

	private void ParametersDataGridView_DragOver(object sender, DragEventArgs e)
	{
		ValueSubstitutionDragOver(e);
	}

	private void ValueSubstitutorForm_Resize(object sender, EventArgs e)
	{
		if (Width < MinimumSize.Width || Width == 0)
		{
			return;
		}

		ConfigHandler.ValueSubstitutorWindowSize = string.Format("{0}; {1}", Size.Width, Size.Height);
		ConfigHandler.SaveConfig();
	}

	private void ParametersDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
	{
		MessageBox.Show(string.Format("Error adding value substitutor data:\r\n\r\n{0}", e.Exception.Message), GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
