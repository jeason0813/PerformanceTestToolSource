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
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

public partial class TaskEditorForm : Form
{
	private Rectangle _dragBoxFromMouseDown;
	private int _rowIndexFromMouseDown;
	private int _rowIndexOfItemUnderMouseToDrop;
	private readonly List<Task> _copiedItems = new List<Task>();
	private bool _cutActivated;
	readonly DatabaseOperation _databaseOperation;
	private bool _changesMade;
	private readonly TaskCollection _initialTaskCollection = new TaskCollection();
	private string _initialTaskCollectionFileName;
	private SearchListForm _searchForm;
	private List<string> _searchList;
	private bool _selectionChangeFromSearch;
	private bool _searchInName = true;
	private bool _searchInContent = true;
	private bool _searchInDescription;

	public TaskEditorForm(DatabaseOperation databaseOperation)
	{
		InitializeComponent();
		Initialize();
		_databaseOperation = databaseOperation;

		if (ConfigHandler.OfflineMode == "False" && _databaseOperation.GetSqlServerVersion() < 11)
		{
			openFileDialog2.Filter = "SQL Server Profiler Trace files|*.trc|All files|*.*";
		}
	}

	private void Initialize()
	{
		SetTitle();
		GenericHelper.SetSize(this, ConfigHandler.EditorWindowSize);
		MinimumSize = new Size(700, 500);  // error in .NET
		FillRecentFilesMenu();

		_searchForm = new SearchListForm("SQL");

		FillList();
		SelectFirstItem();

		wordWrapToolStripMenuItem.Checked = Convert.ToBoolean(ConfigHandler.WordWrap);
		descriptionTextBox.WordWrap = Convert.ToBoolean(ConfigHandler.WordWrap);

		descriptionTextBox.Text = TaskHelper.TaskCollection.Description;
		connectionsTextBox.Text = TaskHelper.TaskCollection.Connections.ToString();
		timeBetweenConnectionsTextBox.Text = TaskHelper.TaskCollection.TimeBetweenConnections.ToString();
		samplingIntervalTextBox.Text = TaskHelper.TaskCollection.PerformanceCountersSamplingInterval.ToString();
		usePoolingCheckBox.Checked = TaskHelper.TaskCollection.UsePooling;
		minPoolingTextBox.Text = TaskHelper.TaskCollection.MinPooling.ToString();
		maxPoolingTextBox.Text = TaskHelper.TaskCollection.MaxPooling.ToString();

		if (TaskHelper.TaskCollection.Mode == "Parallel")
		{
			parallelRadioButton.Checked = true;
		}
		else
		{
			serialRadioButton.Checked = true;
		}

		SetChangesMade(false);

		CopyTaskCollectionToInitialTaskCollection();

		_searchForm.SearchEvent += SearchForm_SearchEvent;
		_searchForm.RequestUpdateListEvent += SearchForm_RequestUpdateListEvent;

		if (Convert.ToBoolean(ConfigHandler.OfflineMode))
		{
			importTraceFileToolStripMenuItem.Enabled = false;
			traceRecordingToolStripMenuItem.Enabled = false;

			importTraceFileToolStripMenuItem.Text = "&Import Trace File... (offline)";
			traceRecordingToolStripMenuItem.Text = "&Record tasks... (offline)";
		}

		tasksTextBox.GotFocus += TasksTextBox_GotFocus;

		dataGridView1.Select();
	}

	private void CopyTaskCollectionToInitialTaskCollection()
	{
		_initialTaskCollection.Tasks.Clear();

		foreach (Task task in TaskHelper.TaskCollection.Tasks)
		{
			Task newTask = new Task(task.Name, task.Description, task.DelayAfterCompletion, task.Sql, task.Type, task.Enabled, task.IncludeInResults);
			_initialTaskCollection.Tasks.Add(newTask);
		}

		_initialTaskCollection.Connections = TaskHelper.TaskCollection.Connections;
		_initialTaskCollection.Description = TaskHelper.TaskCollection.Description;
		_initialTaskCollection.PerformanceCountersSamplingInterval = TaskHelper.TaskCollection.PerformanceCountersSamplingInterval;
		_initialTaskCollection.TimeBetweenConnections = TaskHelper.TaskCollection.TimeBetweenConnections;
		_initialTaskCollection.Mode = TaskHelper.TaskCollection.Mode;
		_initialTaskCollection.UsePooling = TaskHelper.TaskCollection.UsePooling;
		_initialTaskCollection.MinPooling = TaskHelper.TaskCollection.MinPooling;
		_initialTaskCollection.MaxPooling = TaskHelper.TaskCollection.MaxPooling;

		_initialTaskCollectionFileName = TaskHelper.TaskCollectionFileName;
	}

	private void SetChangesMade(bool value)
	{
		bool setTitle = false;

		if (value != _changesMade)
		{
			setTitle = true;
		}

		_changesMade = value;

		if (setTitle)
		{
			SetTitle();
		}
	}

	private void UnloadFileName()
	{
		TaskHelper.TaskCollectionFileName = null;
		SetTitle();
	}

	private void SetTitle()
	{
		string fileName = "";

		if (TaskHelper.TaskCollectionFileName != null && TaskHelper.TaskCollectionFileName != SessionHelper.GetSessionTaskCollectionFileName())
		{
			fileName = string.Format(" - {0}", Path.GetFileName(TaskHelper.TaskCollectionFileName));
		}

		string changesMade = "";

		if (_changesMade)
		{
			changesMade = " *";
		}

		Text = string.Format("{0} - Task Collection Editor{1}{2}", GenericHelper.ApplicationName, fileName, changesMade);
	}

	private string GetFileName()
	{
		if (TaskHelper.TaskCollectionFileName == null || TaskHelper.TaskCollectionFileName == SessionHelper.GetSessionTaskCollectionFileName())
		{
			DialogResult result = saveFileDialog1.ShowDialog();

			if (result.ToString() == "OK")
			{
				Application.DoEvents();
				SetFileName(saveFileDialog1.FileName);
			}
		}

		return TaskHelper.TaskCollectionFileName;
	}

	private void FillRecentFilesMenu()
	{
		RecentFilesHandler.LoadMenuItems(recentFilesToolStripMenuItem, "RecentTaskCollectionFiles");
		AddEventHandlersToRecentFiles();
	}

	private void SetFileName(string fileName)
	{
		TaskHelper.TaskCollectionFileName = fileName;
		RecentFilesHandler.AddFileName(recentFilesToolStripMenuItem, fileName, "RecentTaskCollectionFiles");
		AddEventHandlersToRecentFiles();
	}

	private void AddEventHandlersToRecentFiles()
	{
		foreach (ToolStripMenuItem existingFileName in recentFilesToolStripMenuItem.DropDownItems)
		{
			if (existingFileName.Text != "empty")
			{
				existingFileName.Click += ExistingFileNameMenuItem_Click;
			}
		}
	}

	private void ExistingFileNameMenuItem_Click(object sender, EventArgs e)
	{
		bool success = SaveChanges();

		if (success)
		{
			string fileName = ((ToolStripMenuItem)sender).Text;

			if (File.Exists(fileName))
			{
				string xml = XmlHelper.ReadXmlFromFile(fileName);

				if (xml != null)
				{
					success = Import(xml);

					if (success)
					{
						SetFileName(fileName);
						SetTitle();
					}
				}
			}
			else
			{
				MessageBox.Show("File not found.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
	}

	private bool CheckConnections()
	{
		int check;

		try
		{
			check = Convert.ToInt32(connectionsTextBox.Text);
		}
		catch
		{
			MessageBox.Show("Connections is not a valid number.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			connectionsTextBox.Focus();
			return false;
		}

		if (check <= 0)
		{
			MessageBox.Show("Connections must be greater than 0.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			connectionsTextBox.Focus();
			return false;
		}

		return true;
	}

	private bool CheckPerformanceCountersSamplingInterval()
	{
		int check;

		try
		{
			check = Convert.ToInt32(samplingIntervalTextBox.Text);
		}
		catch
		{
			MessageBox.Show("Sampling interval is not a valid number.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			samplingIntervalTextBox.Focus();
			return false;
		}

		if (check < 0)
		{
			MessageBox.Show("Sampling interval must be equal to or greater than 0.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			samplingIntervalTextBox.Focus();
			return false;
		}

		return true;
	}

	private bool CheckTimeBetweenConnections()
	{
		int check;

		try
		{
			check = Convert.ToInt32(timeBetweenConnectionsTextBox.Text);
		}
		catch
		{
			MessageBox.Show("Time bewteen Connections is not a valid number.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			timeBetweenConnectionsTextBox.Focus();
			return false;
		}

		if (check < 0)
		{
			MessageBox.Show("Time bewteen Connections must be equal to or greater than 0.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			timeBetweenConnectionsTextBox.Focus();
			return false;
		}

		return true;
	}

	private bool CheckMinPooling()
	{
		int check;

		try
		{
			check = Convert.ToInt32(minPoolingTextBox.Text);
		}
		catch
		{
			MessageBox.Show("Minimum Connection Pooling value is not a valid number.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			minPoolingTextBox.Focus();
			return false;
		}

		if (check < 0)
		{
			MessageBox.Show("Minimum Connection Pooling value must be equal to or greater than 0.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			minPoolingTextBox.Focus();
			return false;
		}

		return true;
	}

	private bool CheckMaxPooling()
	{
		int check;

		try
		{
			check = Convert.ToInt32(maxPoolingTextBox.Text);
		}
		catch
		{
			MessageBox.Show("Maximum Connection Pooling value is not a valid number.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			maxPoolingTextBox.Focus();
			return false;
		}

		if (check < 0)
		{
			MessageBox.Show("Maximum Connection Pooling value must be equal to or greater than 0.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			maxPoolingTextBox.Focus();
			return false;
		}

		return true;
	}

	private void FillList()
	{
		dataGridView1.Rows.Clear();

		for (int i = 0; i < TaskHelper.TaskCollection.Tasks.Count; i++)
		{
			int index = dataGridView1.Rows.Add();
			DataGridViewRow row = dataGridView1.Rows[index];
			row.Cells["TaskName"].Value = TaskHelper.TaskCollection.Tasks[i].Name;
			row.Cells["TaskName"].ToolTipText = TaskHelper.TaskCollection.Tasks[i].Description;
			row.Cells["TaskTypeColumn"].Value = TaskHelper.TaskTypeToString(TaskHelper.TaskCollection.Tasks[i].Type);
			row.Cells["DelayAfterCompletionColumn"].Value = TaskHelper.TaskCollection.Tasks[i].DelayAfterCompletion;

			if (TaskHelper.TaskCollection.Tasks[i].IncludeInResults)
			{
				row.Cells["IncludeInResultsColumn"].Value = "Yes";
			}
			else
			{
				row.Cells["IncludeInResultsColumn"].Value = "No";
			}

			if (!TaskHelper.TaskCollection.Tasks[i].Enabled)
			{
				row.DefaultCellStyle.ForeColor = Color.Gray;
				row.DefaultCellStyle.SelectionForeColor = Color.Gray;
			}
			else
			{
				row.DefaultCellStyle.ForeColor = SystemColors.WindowText;
				row.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
			}
		}

		FillStepColumn();
		PopulateSearchList();
		UpdateTasksTextBox();
		EnableItems();
	}

	private void SelectFirstItem()
	{
		if (dataGridView1.Rows.Count > 0)
		{
			dataGridView1.Rows[0].Selected = true;
			EnableItems();
		}
	}

	private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void ImportToolStripMenuItem_Click(object sender, EventArgs e)
	{
		bool success = SaveChanges();

		if (success)
		{
			DialogResult result = openFileDialog1.ShowDialog();

			if (result.ToString() == "OK")
			{
				Application.DoEvents();
				string xml = XmlHelper.ReadXmlFromFile(openFileDialog1.FileName);

				if (xml != null)
				{
					success = Import(xml);

					if (success)
					{
						SetFileName(openFileDialog1.FileName);
						SetTitle();
					}
				}
			}
		}
	}

	private bool Import(string xml)
	{
		TaskCollection temporaryTaskCollection = TaskHelper.XmlToTaskCollection(xml);

		if (temporaryTaskCollection != null)
		{
			TaskHelper.TaskCollection = temporaryTaskCollection;
			FillList();
			SelectFirstItem();

			descriptionTextBox.Text = TaskHelper.TaskCollection.Description;
			connectionsTextBox.Text = TaskHelper.TaskCollection.Connections.ToString();
			timeBetweenConnectionsTextBox.Text = TaskHelper.TaskCollection.TimeBetweenConnections.ToString();
			samplingIntervalTextBox.Text = TaskHelper.TaskCollection.PerformanceCountersSamplingInterval.ToString();
			usePoolingCheckBox.Checked = TaskHelper.TaskCollection.UsePooling;
			minPoolingTextBox.Text = TaskHelper.TaskCollection.MinPooling.ToString();
			maxPoolingTextBox.Text = TaskHelper.TaskCollection.MaxPooling.ToString();

			if (TaskHelper.TaskCollection.Mode == "Parallel")
			{
				parallelRadioButton.Checked = true;
			}
			else
			{
				serialRadioButton.Checked = true;
			}

			SetChangesMade(false);
			return true;
		}

		return false;
	}

	private void ExportToolStripMenuItem_Click(object sender, EventArgs e)
	{
		string currentFileName = TaskHelper.TaskCollectionFileName;
		TaskHelper.TaskCollectionFileName = null;

		bool success = SaveCollection();

		if (!success)
		{
			TaskHelper.TaskCollectionFileName = currentFileName;
		}
		else
		{
			SetTitle();
		}
	}

	private void CreateButton_Click(object sender, EventArgs e)
	{
		Create();
	}

	private void Create()
	{
		TaskForm form = new TaskForm();
		form.Icon = PerformanceTestTool.Properties.Resources.cog_add;
		DialogResult result = form.ShowDialog();

		if (result.ToString() == "OK")
		{
			Application.DoEvents();
			Task newItem = form.GetValue();

			int insertNewRowAt = 0;

			if (dataGridView1.SelectedRows.Count > 0)
			{
				insertNewRowAt = dataGridView1.SelectedRows[0].Index;
				insertNewRowAt++;
			}

			CreateNewItem(newItem, insertNewRowAt);

			FillStepColumn();
			PopulateSearchList();
			UpdateTasksTextBox();

			dataGridView1.FirstDisplayedScrollingRowIndex = insertNewRowAt;
			dataGridView1.CurrentCell = dataGridView1["TaskName", insertNewRowAt];
			dataGridView1.Rows[insertNewRowAt].Selected = true;

			SetChangesMade(true);
		}

		dataGridView1.Focus();
	}

	private void CreateNewItem(Task newItem, int insertNewRowAt)
	{
		TaskHelper.TaskCollection.Tasks.Insert(insertNewRowAt, newItem);

		int index = dataGridView1.Rows.Add();
		DataGridViewRow row = dataGridView1.Rows[index];
		row.Cells["TaskName"].Value = newItem.Name;
		row.Cells["TaskName"].ToolTipText = newItem.Description;
		row.Cells["TaskTypeColumn"].Value = TaskHelper.TaskTypeToString(newItem.Type);
		row.Cells["DelayAfterCompletionColumn"].Value = newItem.DelayAfterCompletion;

		if (newItem.IncludeInResults)
		{
			row.Cells["IncludeInResultsColumn"].Value = "Yes";
		}
		else
		{
			row.Cells["IncludeInResultsColumn"].Value = "No";
		}

		if (!newItem.Enabled)
		{
			row.DefaultCellStyle.ForeColor = Color.Gray;
			row.DefaultCellStyle.SelectionForeColor = Color.Gray;
		}
		else
		{
			row.DefaultCellStyle.ForeColor = SystemColors.WindowText;
			row.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
		}

		dataGridView1.Rows.RemoveAt(index);
		dataGridView1.Rows.Insert(insertNewRowAt, row);
	}

	private void FillStepColumn()
	{
		int setupCount = 0;
		int includeCount = 0;
		int teardownCount = 0;

		for (int i = 0; i < TaskHelper.TaskCollection.Tasks.Count; i++)
		{
			if (TaskHelper.TaskCollection.Tasks[i].Type == TaskHelper.TaskType.Setup)
			{
				dataGridView1.Rows[i].Cells["StepColumn"].Value = (++setupCount).ToString();
			}
		}

		for (int i = 0; i < TaskHelper.TaskCollection.Tasks.Count; i++)
		{
			if (TaskHelper.TaskCollection.Tasks[i].Type == TaskHelper.TaskType.Normal)
			{
				dataGridView1.Rows[i].Cells["StepColumn"].Value = (++includeCount).ToString();
			}
		}

		for (int i = 0; i < TaskHelper.TaskCollection.Tasks.Count; i++)
		{
			if (TaskHelper.TaskCollection.Tasks[i].Type == TaskHelper.TaskType.Teardown)
			{
				dataGridView1.Rows[i].Cells["StepColumn"].Value = (++teardownCount).ToString();
			}
		}
	}

	private void EditButton_Click(object sender, EventArgs e)
	{
		Edit();
	}

	private void Edit()
	{
		List<Task> newItems = TaskHelper.TaskCollection.Tasks;

		bool save = false;

		foreach (Task item in newItems)
		{
			if (dataGridView1.SelectedRows[0].Cells["TaskName"].Value.ToString() == item.Name)
			{
				TaskForm form = new TaskForm(item);
				form.Icon = PerformanceTestTool.Properties.Resources.cog_edit;
				DialogResult result = form.ShowDialog();

				if (result.ToString() == "OK")
				{
					Application.DoEvents();

					Task newItem = form.GetValue();
					item.Name = newItem.Name;
					item.Sql = newItem.Sql;
					item.Type = newItem.Type;
					item.Description = newItem.Description;
					item.Enabled = newItem.Enabled;
					item.DelayAfterCompletion = newItem.DelayAfterCompletion;
					item.IncludeInResults = newItem.IncludeInResults;

					dataGridView1.SelectedRows[0].Cells["TaskName"].Value = newItem.Name;
					dataGridView1.SelectedRows[0].Cells["TaskName"].ToolTipText = newItem.Description;
					dataGridView1.SelectedRows[0].Cells["TaskTypeColumn"].Value = TaskHelper.TaskTypeToString(newItem.Type);
					dataGridView1.SelectedRows[0].Cells["DelayAfterCompletionColumn"].Value = newItem.DelayAfterCompletion;

					if (newItem.IncludeInResults)
					{
						dataGridView1.SelectedRows[0].Cells["IncludeInResultsColumn"].Value = "Yes";
					}
					else
					{
						dataGridView1.SelectedRows[0].Cells["IncludeInResultsColumn"].Value = "No";
					}

					if (!newItem.Enabled)
					{
						dataGridView1.SelectedRows[0].DefaultCellStyle.ForeColor = Color.Gray;
						dataGridView1.SelectedRows[0].DefaultCellStyle.SelectionForeColor = Color.Gray;
					}
					else
					{
						dataGridView1.SelectedRows[0].DefaultCellStyle.ForeColor = SystemColors.WindowText;
						dataGridView1.SelectedRows[0].DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
					}

					save = true;
				}

				break;
			}
		}

		if (save)
		{
			TaskHelper.TaskCollection.Tasks = newItems;
			FillStepColumn();
			PopulateSearchList();
			UpdateTasksTextBox();
			SetChangesMade(true);
		}

		dataGridView1.Focus();
	}

	private void ToggleEnabled()
	{
		foreach (DataGridViewRow row in dataGridView1.SelectedRows)
		{
			foreach (Task item in TaskHelper.TaskCollection.Tasks)
			{
				if (row.Cells["TaskName"].Value.ToString() == item.Name)
				{
					if (item.Enabled)
					{
						item.Enabled = false;

						row.DefaultCellStyle.ForeColor = Color.Gray;
						row.DefaultCellStyle.SelectionForeColor = Color.Gray;
					}
					else
					{
						item.Enabled = true;

						row.DefaultCellStyle.ForeColor = SystemColors.WindowText;
						row.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
					}
				}
			}
		}

		SetChangesMade(true);
		dataGridView1.Focus();
	}

	private int GetCorrectIndexOfSelectedRow(DataGridViewRow selectedRow)
	{
		foreach (DataGridViewRow row in dataGridView1.Rows)
		{
			if (row == selectedRow)
			{
				return row.Index;
			}
		}

		return -1;
	}

	private string FirstNameOfSelectedRows()
	{
		int firstIndex = dataGridView1.Rows.Count + 1;
		string firstName = null;

		foreach (Task item in TaskHelper.TaskCollection.Tasks)
		{
			foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
			{
				if (selectedRow.Cells["TaskName"].Value.ToString() == item.Name)
				{
					if (GetCorrectIndexOfSelectedRow(selectedRow) < firstIndex)
					{
						firstIndex = GetCorrectIndexOfSelectedRow(selectedRow);
						firstName = item.Name;
					}
				}
			}
		}

		return firstName;
	}

	private string LastNameOfSelectedRows()
	{
		int lastIndex = 0;
		string lastName = null;

		foreach (Task item in TaskHelper.TaskCollection.Tasks)
		{
			foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
			{
				if (selectedRow.Cells["TaskName"].Value.ToString() == item.Name)
				{
					if (GetCorrectIndexOfSelectedRow(selectedRow) >= lastIndex)
					{
						lastIndex = GetCorrectIndexOfSelectedRow(selectedRow);
						lastName = item.Name;
					}
				}
			}
		}

		return lastName;
	}

	private void Cut()
	{
		_cutActivated = true;
		DoCopy();
	}

	private void Copy()
	{
		_cutActivated = false;
		DoCopy();
	}

	private void DoCopy()
	{
		_copiedItems.Clear();

		for (int i = 0; i < TaskHelper.TaskCollection.Tasks.Count; i++)
		{
			for (int r = 0; r < dataGridView1.SelectedRows.Count; r++)
			{
				if (dataGridView1.SelectedRows[r].Cells["TaskName"].Value.ToString() == TaskHelper.TaskCollection.Tasks[i].Name)
				{
					_copiedItems.Add(TaskHelper.TaskCollection.Tasks[i]);
				}
			}
		}
	}

	private int GetIndexOfRowFromName(string name)
	{
		foreach (DataGridViewRow row in dataGridView1.Rows)
		{
			if (row.Cells["TaskName"].Value.ToString() == name)
			{
				return row.Index;
			}
		}

		return -1;
	}

	private void Paste()
	{
		int insertNewRowAt;

		if (_cutActivated)
		{
			string firstNameOfSelectedRows = FirstNameOfSelectedRows();
			insertNewRowAt = GetIndexOfRowFromName(firstNameOfSelectedRows);

			int totalRows = dataGridView1.Rows.Count;
			int spaceLeft = totalRows - insertNewRowAt;

			if (spaceLeft < _copiedItems.Count)
			{
				insertNewRowAt = totalRows - _copiedItems.Count;
			}

			if (insertNewRowAt < 0)
			{
				insertNewRowAt = 0;
			}
		}
		else
		{
			string lastNameOfSelectedRows = LastNameOfSelectedRows();
			insertNewRowAt = GetIndexOfRowFromName(lastNameOfSelectedRows) + 1;
		}

		int insertNewRowAtOriginal = insertNewRowAt;

		if (_cutActivated)
		{
			DoDelete(_copiedItems);
		}

		List<string> nameList = new List<string>();

		foreach (Task itemToBeCopied in _copiedItems)
		{
			string name = TaskHelper.GetNewItemName(itemToBeCopied.Name);

			Task newItem = new Task(name, itemToBeCopied.Description, itemToBeCopied.DelayAfterCompletion, itemToBeCopied.Sql, itemToBeCopied.Type, itemToBeCopied.Enabled, itemToBeCopied.IncludeInResults);
			CreateNewItem(newItem, insertNewRowAt);
			insertNewRowAt++;

			nameList.Add(name);
		}

		foreach (DataGridViewRow row in dataGridView1.Rows)
		{
			row.Selected = false;
		}

		dataGridView1.CurrentCell = dataGridView1["TaskName", insertNewRowAtOriginal];
		SelectRows(nameList);
		FillStepColumn();
		PopulateSearchList();
		UpdateTasksTextBox();

		SetChangesMade(true);
		dataGridView1.Focus();
	}

	private void SelectRows(List<string> nameList)
	{
		foreach (DataGridViewRow row in dataGridView1.Rows)
		{
			foreach (string name in nameList)
			{
				if (row.Cells["TaskName"].Value.ToString() == name)
				{
					row.Selected = true;
				}
			}
		}
	}

	private void DeleteButton_Click(object sender, EventArgs e)
	{
		Delete();
	}

	private void Delete()
	{
		DialogResult result = MessageBox.Show("Delete selected tasks?", GenericHelper.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

		if (result.ToString() == "Yes")
		{
			List<Task> itemsToBeDeleted = new List<Task>();

			foreach (DataGridViewRow row in dataGridView1.SelectedRows)
			{
				foreach (Task item in TaskHelper.TaskCollection.Tasks)
				{
					if (row.Cells["TaskName"].Value.ToString() == item.Name)
					{
						itemsToBeDeleted.Add(item);
					}
				}
			}

			DoDelete(itemsToBeDeleted);

			FillStepColumn();
			PopulateSearchList();
			UpdateTasksTextBox();
			EnableItems();
			dataGridView1.Focus();
		}
	}

	private void DoDelete(List<Task> itemsToBeDeleted)
	{
		List<int> indexesToBeRemoved = new List<int>();

		for (int r = 0; r < dataGridView1.Rows.Count; r++)
		{
			for (int i = 0; i < itemsToBeDeleted.Count; i++)
			{
				if (dataGridView1.Rows[r].Cells["TaskName"].Value.ToString() == itemsToBeDeleted[i].Name)
				{
					indexesToBeRemoved.Add(dataGridView1.Rows[r].Index);
				}
			}
		}

		indexesToBeRemoved.Sort(new SortIntDescending());

		for (int i = 0; i < indexesToBeRemoved.Count; i++)
		{
			dataGridView1.Rows.RemoveAt(indexesToBeRemoved[i]);
			TaskHelper.TaskCollection.Tasks.RemoveAt(indexesToBeRemoved[i]);
		}

		SetChangesMade(true);
	}

	private class SortIntDescending : IComparer<int>
	{
		int IComparer<int>.Compare(int a, int b)
		{
			if (a > b)
			{
				return -1;
			}
			if (a < b)
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}
	}

	private void MoveItem(int currentIndex, int newIndex)
	{
		DataGridViewRow row = dataGridView1.Rows[currentIndex];

		dataGridView1.Rows.RemoveAt(currentIndex);
		dataGridView1.Rows.Insert(newIndex, row);

		dataGridView1.CurrentCell = dataGridView1.Rows[newIndex].Cells["TaskName"];
		dataGridView1.Focus();

		SaveAfterMoveItem();

		FillStepColumn();
		PopulateSearchList();
		EnableItems();
	}

	private void MoveUpButton_Click(object sender, EventArgs e)
	{
		MoveUp();
	}

	private void MoveUp()
	{
		int currentIndex = dataGridView1.SelectedRows[0].Index;
		int newIndex = dataGridView1.SelectedRows[0].Index - 1;
		MoveItem(currentIndex, newIndex);
	}

	private void MoveDownButton_Click(object sender, EventArgs e)
	{
		MoveDown();
	}

	private void MoveDown()
	{
		int currentIndex = dataGridView1.SelectedRows[0].Index;
		int newIndex = dataGridView1.SelectedRows[0].Index + 1;
		MoveItem(currentIndex, newIndex);
	}

	private void SaveAfterMoveItem()
	{
		List<Task> newList = new List<Task>();

		foreach (DataGridViewRow row in dataGridView1.Rows)
		{
			foreach (Task item in TaskHelper.TaskCollection.Tasks)
			{
				if (row.Cells["TaskName"].Value.ToString() == item.Name)
				{
					newList.Add(item);
				}
			}
		}

		TaskHelper.TaskCollection.Tasks = newList;
		SetChangesMade(true);
	}

	private void OkButton_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void EnableItems()
	{
		if (dataGridView1.SelectedRows.Count == 0)
		{
			DisableItems();
		}
		else if (dataGridView1.SelectedRows.Count == 1)
		{
			createButton.Enabled = true;
			editButton.Enabled = true;
			deleteButton.Enabled = true;

			createMenuItem1.Enabled = true;
			editMenuItem1.Enabled = true;
			deleteMenuItem1.Enabled = true;
			renameMenuItem1.Enabled = true;
			cutMenuItem1.Enabled = true;
			copyMenuItem1.Enabled = true;
			toggleMenuItem1.Enabled = true;

			createMenuItem.Enabled = true;
			editMenuItem.Enabled = true;
			deleteMenuItem.Enabled = true;
			renameMenuItem.Enabled = true;
			cutMenuItem.Enabled = true;
			copyMenuItem.Enabled = true;
			toggleMenuItem.Enabled = true;

			copySQLMenuItem.Enabled = true;
			copySQLMenuItem1.Enabled = true;
		}
		else if (dataGridView1.SelectedRows.Count > 1)
		{
			createButton.Enabled = true;
			editButton.Enabled = false;
			deleteButton.Enabled = true;

			createMenuItem1.Enabled = true;
			editMenuItem1.Enabled = false;
			deleteMenuItem1.Enabled = true;
			renameMenuItem1.Enabled = false;
			cutMenuItem1.Enabled = true;
			copyMenuItem1.Enabled = true;
			toggleMenuItem1.Enabled = true;

			createMenuItem.Enabled = true;
			editMenuItem.Enabled = false;
			deleteMenuItem.Enabled = true;
			renameMenuItem.Enabled = false;
			cutMenuItem.Enabled = true;
			copyMenuItem.Enabled = true;
			toggleMenuItem.Enabled = true;

			copySQLMenuItem.Enabled = true;
			copySQLMenuItem1.Enabled = true;
		}

		if (dataGridView1.Rows.Count == 0)
		{
			selectAllMenuItem1.Enabled = false;
		}
		else
		{
			selectAllMenuItem1.Enabled = true;
		}

		if (dataGridView1.Rows.Count <= 1)
		{
			moveUpButton.Enabled = false;
			moveUpMenuItem1.Enabled = false;
			moveUpMenuItem.Enabled = false;
		}
		else
		{
			if (dataGridView1.Rows[0].Selected || dataGridView1.SelectedRows.Count == 0 || dataGridView1.SelectedRows.Count > 1)
			{
				moveUpButton.Enabled = false;
				moveUpMenuItem1.Enabled = false;
				moveUpMenuItem.Enabled = false;
			}
			else
			{
				moveUpButton.Enabled = true;
				moveUpMenuItem1.Enabled = true;
				moveUpMenuItem.Enabled = true;
			}
		}

		if (dataGridView1.Rows.Count <= 1)
		{
			moveDownButton.Enabled = false;
			moveDownMenuItem1.Enabled = false;
			moveDownMenuItem.Enabled = false;
		}
		else
		{
			if (dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected || dataGridView1.SelectedRows.Count == 0 || dataGridView1.SelectedRows.Count > 1)
			{
				moveDownButton.Enabled = false;
				moveDownMenuItem1.Enabled = false;
				moveDownMenuItem.Enabled = false;
			}
			else
			{
				moveDownButton.Enabled = true;
				moveDownMenuItem1.Enabled = true;
				moveDownMenuItem.Enabled = true;
			}
		}
	}

	private void DisableItems()
	{
		createButton.Enabled = true;
		editButton.Enabled = false;
		deleteButton.Enabled = false;

		createMenuItem1.Enabled = true;
		editMenuItem1.Enabled = false;
		deleteMenuItem1.Enabled = false;
		renameMenuItem1.Enabled = false;
		cutMenuItem1.Enabled = false;
		copyMenuItem1.Enabled = false;
		toggleMenuItem1.Enabled = false;

		createMenuItem.Enabled = true;
		editMenuItem.Enabled = false;
		deleteMenuItem.Enabled = false;
		renameMenuItem.Enabled = false;
		cutMenuItem.Enabled = false;
		copyMenuItem.Enabled = false;
		toggleMenuItem.Enabled = false;

		copySQLMenuItem1.Enabled = false;
		copySQLMenuItem.Enabled = false;
	}

	private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex == -1)
		{
			return;
		}

		if (dataGridView1.SelectedRows.Count == 0)
		{
			DisableItems();
		}
		else if (dataGridView1.SelectedRows.Count == 1)
		{
			Edit();
		}
	}

	private void DataGridView1_SelectionChanged(object sender, EventArgs e)
	{
		EnableItems();

		if (!_selectionChangeFromSearch)
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				_searchForm.Reset(dataGridView1.SelectedRows[0].Index);
			}
		}
	}

	private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (dataGridView1.SelectedRows.Count == 0)
		{
			DisableItems();
		}

		if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
		{
			if (!dataGridView1.Rows[e.RowIndex].Selected)
			{
				dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
			}

			Rectangle r = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
			contextMenuStrip1.Show((Control)sender, r.Left + e.X, r.Top + e.Y);
		}
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		if (dataGridView1.Focused)
		{
			if (msg.WParam.ToInt32() == (int)Keys.Enter)
			{
				if (dataGridView1.SelectedRows.Count == 1)
				{
					Edit();
				}

				return true;
			}

			if ((int)keyData == 196644) // Keys.Shift && Keys.Control && Keys.Home
			{
				SendKeys.Send("+^{UP}");
				return true;
			}
		}

		return base.ProcessCmdKey(ref msg, keyData);
	}

	private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
	{
		if (dataGridView1.Rows.Count >= 1)
		{
			EnableItems();
		}

		if (e.KeyData == Keys.Delete)
		{
			if (dataGridView1.SelectedRows.Count >= 1)
			{
				Delete();
			}
		}
		else if (e.KeyCode == Keys.N && e.Modifiers == Keys.Control)
		{
			Create();
		}
		else if (e.KeyCode == Keys.E && e.Modifiers == Keys.Control)
		{
			if (dataGridView1.SelectedRows.Count >= 1)
			{
				ToggleEnabled();
			}
		}
		else if (e.KeyCode == Keys.X && e.Modifiers == Keys.Control)
		{
			if (dataGridView1.SelectedRows.Count >= 1)
			{
				Cut();
			}
		}
		else if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
		{
			if (dataGridView1.SelectedRows.Count >= 1)
			{
				Copy();
			}
		}
		else if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
		{
			if (_copiedItems.Count > 0)
			{
				Paste();
			}
		}
		else if (e.KeyCode == Keys.U && e.Modifiers == Keys.Control)
		{
			if (dataGridView1.SelectedRows.Count == 1)
			{
				if (dataGridView1.Rows[0].Selected || dataGridView1.SelectedRows.Count == 0)
				{
					return;
				}

				MoveUp();
			}
		}
		else if (e.KeyCode == Keys.D && e.Modifiers == Keys.Control)
		{
			if (dataGridView1.SelectedRows.Count == 1)
			{
				if (dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected || dataGridView1.SelectedRows.Count == 0)
				{
					return;
				}

				MoveDown();
			}
		}
		else if (e.KeyCode == Keys.F2)
		{
			if (dataGridView1.SelectedRows.Count == 1)
			{
				Rename();
			}
		}
	}

	private void DataGridView1_DragDrop(object sender, DragEventArgs e)
	{
		string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

		if (files != null)
		{
			if (files.Length == 1)
			{
				bool success = SaveChanges();

				if (success)
				{
					string xml = XmlHelper.ReadXmlFromFile(files[0]);

					if (xml != null)
					{
						success = Import(xml);

						if (success)
						{
							SetFileName(files[0]);
							SetTitle();
						}
					}
				}
			}
		}
		else
		{
			Point clientPoint = dataGridView1.PointToClient(new Point(e.X, e.Y));
			_rowIndexOfItemUnderMouseToDrop = dataGridView1.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

			if (e.Effect == DragDropEffects.Move)
			{
				if (_rowIndexOfItemUnderMouseToDrop != -1)
				{
					if (_rowIndexFromMouseDown != _rowIndexOfItemUnderMouseToDrop)
					{
						MoveItem(_rowIndexFromMouseDown, _rowIndexOfItemUnderMouseToDrop);
					}
				}
			}
		}
	}

	private void DataGridView1_MouseMove(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			if (_dragBoxFromMouseDown != Rectangle.Empty && !_dragBoxFromMouseDown.Contains(e.X, e.Y))
			{
				dataGridView1.DoDragDrop(dataGridView1.Rows[_rowIndexFromMouseDown], DragDropEffects.Move);
			}
		}
	}

	private void DataGridView1_MouseDown(object sender, MouseEventArgs e)
	{
		_rowIndexFromMouseDown = dataGridView1.HitTest(e.X, e.Y).RowIndex;

		if (_rowIndexFromMouseDown != -1)
		{
			Size dragSize = SystemInformation.DragSize;
			_dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
		}
		else
		{
			_dragBoxFromMouseDown = Rectangle.Empty;
		}
	}

	private void DataGridView1_DragOver(object sender, DragEventArgs e)
	{
		string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

		if (files != null)
		{
			if (files.Length == 1)
			{
				e.Effect = DragDropEffects.Move;
			}
		}
		else
		{
			e.Effect = DragDropEffects.Move;
		}
	}

	private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Create();
	}

	private void EditToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Edit();
	}

	private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Delete();
	}

	private void MoveDownToolStripMenuItem_Click(object sender, EventArgs e)
	{
		MoveDown();
	}

	private void MoveUpToolStripMenuItem_Click(object sender, EventArgs e)
	{
		MoveUp();
	}

	private void BasicPerformanceTestToolStripMenuItem_Click(object sender, EventArgs e)
	{
		bool success = SaveChanges();

		if (success)
		{
			Import(PerformanceTestTool.Properties.Resources.BasicPerformanceTest);
			UnloadFileName();
		}
	}

	private void MeasureConnectionsOverTimeToolStripMenuItem_Click(object sender, EventArgs e)
	{
		bool success = SaveChanges();

		if (success)
		{
			Import(PerformanceTestTool.Properties.Resources.MeasureConnectionsOverTime);
			UnloadFileName();
		}
	}

	private void EditorForm_Resize(object sender, EventArgs e)
	{
		if (Width < MinimumSize.Width || Width == 0)
		{
			return;
		}

		ConfigHandler.EditorWindowSize = string.Format("{0}; {1}", Size.Width, Size.Height);
		ConfigHandler.SaveConfig();

		splitContainer1.SplitterDistance++;
		splitContainer1.SplitterDistance--;
		splitContainer1.Invalidate();
	}

	private void DeleteAll()
	{
		DialogResult overwrite = MessageBox.Show("Create new Task Collection?", GenericHelper.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

		if (overwrite.ToString() == "Yes")
		{
			bool success = SaveChanges();

			if (success)
			{
				TaskHelper.TaskCollection.Tasks.Clear();

				TaskHelper.TaskCollection.Description = "";
				descriptionTextBox.Text = "";

				TaskHelper.TaskCollection.Connections = 1;
				connectionsTextBox.Text = "1";

				TaskHelper.TaskCollection.TimeBetweenConnections = 0;
				timeBetweenConnectionsTextBox.Text = "0";

				TaskHelper.TaskCollection.PerformanceCountersSamplingInterval = 0;
				samplingIntervalTextBox.Text = "0";

				TaskHelper.TaskCollection.Mode = "Parallel";
				parallelRadioButton.Checked = true;

				TaskHelper.TaskCollection.UsePooling = true;
				minPoolingTextBox.Text = "0";
				maxPoolingTextBox.Text = "100";

				UnloadFileName();

				SetChangesMade(false);
				FillList();
			}
		}
	}

	private void CreateMenuItem_Click(object sender, EventArgs e)
	{
		Create();
	}

	private void EditMenuItem_Click(object sender, EventArgs e)
	{
		Edit();
	}

	private void DeleteMenuItem_Click(object sender, EventArgs e)
	{
		Delete();
	}

	private void MoveUpMenuItem_Click(object sender, EventArgs e)
	{
		MoveUp();
	}

	private void MoveDownMenuItem_Click(object sender, EventArgs e)
	{
		MoveDown();
	}

	private void WordWrapToolStripMenuItem_Click(object sender, EventArgs e)
	{
		descriptionTextBox.WordWrap = wordWrapToolStripMenuItem.Checked;
		ConfigHandler.WordWrap = wordWrapToolStripMenuItem.Checked.ToString();
		ConfigHandler.SaveConfig();
	}

	private void TaskEditorForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		bool success = SaveChanges();

		if (!success)
		{
			e.Cancel = true;
		}
		else
		{
			_searchForm.Close();
		}
	}

	private bool SaveChanges()
	{
		if (_changesMade)
		{
			DialogResult result = MessageBox.Show("Changes has been made in the Task Collection.\r\nSave changes?", GenericHelper.ApplicationName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

			if (result.ToString() == "Yes")
			{
				bool success = SaveCollection();

				if (!success)
				{
					return false;
				}
			}
			else if (result.ToString() == "No")
			{
				TaskHelper.TaskCollection = _initialTaskCollection;
				TaskHelper.TaskCollectionFileName = _initialTaskCollectionFileName;
			}
			else if (result.ToString() == "Cancel")
			{
				return false;
			}
		}

		return true;
	}

	private bool SetTaskCollectionProperties()
	{
		if (CheckConnections() && CheckTimeBetweenConnections() && CheckPerformanceCountersSamplingInterval() && CheckMinPooling() && CheckMaxPooling())
		{
			TaskHelper.TaskCollection.Description = descriptionTextBox.Text;
			TaskHelper.TaskCollection.Connections = Convert.ToInt32(connectionsTextBox.Text);
			TaskHelper.TaskCollection.TimeBetweenConnections = Convert.ToInt32(timeBetweenConnectionsTextBox.Text);
			TaskHelper.TaskCollection.PerformanceCountersSamplingInterval = Convert.ToInt32(samplingIntervalTextBox.Text);
			TaskHelper.TaskCollection.UsePooling = usePoolingCheckBox.Checked;
			TaskHelper.TaskCollection.MinPooling = Convert.ToInt32(minPoolingTextBox.Text);
			TaskHelper.TaskCollection.MaxPooling = Convert.ToInt32(maxPoolingTextBox.Text);

			if (parallelRadioButton.Checked)
			{
				TaskHelper.TaskCollection.Mode = "Parallel";
			}
			else
			{
				TaskHelper.TaskCollection.Mode = "Serial";
			}

			return true;
		}

		return false;
	}

	private void ParameterExample1ToolStripMenuItem_Click(object sender, EventArgs e)
	{
		bool success = SaveChanges();

		if (success)
		{
			Import(PerformanceTestTool.Properties.Resources.ParametersExample1);
			UnloadFileName();
		}
	}

	private void DescriptionTextBox_Enter(object sender, EventArgs e)
	{
		descriptionTextBox.SelectionStart = 0;
		descriptionTextBox.SelectionLength = 0;
	}

	private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Copy();
	}

	private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Paste();
	}

	private void CopyToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		Copy();
	}

	private void PasteToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		Paste();
	}

	private void ContextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
	{
		HandleToolStripOpening();
	}

	private void OptionsToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
	{
		HandleToolStripOpening();
	}

	private void HandleToolStripOpening()
	{
		if (_copiedItems.Count > 0)
		{
			pasteMenuItem.Enabled = true;
			pasteMenuItem1.Enabled = true;
		}
		else
		{
			pasteMenuItem.Enabled = false;
			pasteMenuItem1.Enabled = false;
		}
	}

	private void CutToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Cut();
	}

	private void CutToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		Cut();
	}

	private void NewTaskCollectionToolStripMenuItem_Click(object sender, EventArgs e)
	{
		DeleteAll();
	}

	private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
	{
		dataGridView1.SelectAll();
	}

	private void SelectAllToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		dataGridView1.SelectAll();
	}

	private void SplitContainer1_Paint(object sender, PaintEventArgs e)
	{
		SplitContainerGrip.PaintGrip(sender, e);
	}

	private void SplitContainer1_MouseUp(object sender, MouseEventArgs e)
	{
		if (splitContainer1.CanFocus)
		{
			ActiveControl = dataGridView1;
		}
	}

	private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
	{
		SetChangesMade(true);
	}

	private void TraceRecordingToolStripMenuItem_Click(object sender, EventArgs e)
	{
		TraceRecordingForm form = new TraceRecordingForm(_databaseOperation);
		form.ShowDialog();

		if (form.AnythingRecorded())
		{
			SetChangesMade(true);

			FillList();
			SelectFirstItem();
			dataGridView1.Focus();
		}
	}

	private void ParameterExample2ToolStripMenuItem_Click(object sender, EventArgs e)
	{
		bool success = SaveChanges();

		if (success)
		{
			Import(PerformanceTestTool.Properties.Resources.ParametersExample2);
			UnloadFileName();
		}
	}

	private void SaveCollectionToolStripMenuItem_Click(object sender, EventArgs e)
	{
		SaveCollection();
	}

	private bool SaveCollection()
	{
		bool success = SetTaskCollectionProperties();

		if (success)
		{
			string fileName = GetFileName();

			if (fileName != null)
			{
				TaskHelper.SaveTaskCollection(fileName);
				CopyTaskCollectionToInitialTaskCollection();
				SetChangesMade(false);
				return true;
			}
		}

		return false;
	}

	private void FileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
	{
		saveCollectionToolStripMenuItem.Enabled = _changesMade;
	}

	private void CopySQLInSelectedTasksToolStripMenuItem_Click(object sender, EventArgs e)
	{
		CopySql();
	}

	private void CopySQLInSelectedTasksToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		CopySql();
	}

	private void CopySql()
	{
		string sql = "";
		int itemCount = 0;

		foreach (Task task in TaskHelper.TaskCollection.Tasks)
		{
			foreach (DataGridViewRow row in dataGridView1.SelectedRows)
			{
				if (row.Cells["TaskName"].Value.ToString() == task.Name)
				{
					itemCount++;
					string newLine = "";

					if (itemCount > 1)
					{
						newLine = "\r\n\r\n";
					}

					string itemSql = task.Sql;

					if (itemCount > 1)
					{
						int useLineIndex = -1;

						string[] useLines = itemSql.Split('\n');

						for (int i = 0; i < useLines.Length; i++)
						{
							if (useLines[i].Trim() != "")
							{
								if (useLines[i].Trim().ToLower().StartsWith("use "))
								{
									useLineIndex = i;
								}
							}
						}

						if (useLineIndex != -1)
						{
							string itemSqlWithoutUse = "";
							string[] lines = itemSql.Split('\n');

							for (int line = useLineIndex; line < lines.Length; line++)
							{
								if (line == useLineIndex || lines[line] == "\r")
								{
									continue;
								}

								itemSqlWithoutUse += lines[line];
							}

							itemSql = itemSqlWithoutUse;
						}
					}

					sql = string.Format("{0}{2}{1}", sql, itemSql, newLine);
				}
			}
		}

		Thread newThread = new Thread(ThreadMethod);
		newThread.SetApartmentState(ApartmentState.STA);
		newThread.Start(sql);

		dataGridView1.Focus();
	}

	private static void ThreadMethod(object text)
	{
		Clipboard.SetText(text.ToString());
	}

	private void SetEnabled(bool value)
	{
		foreach (DataGridViewRow row in dataGridView1.SelectedRows)
		{
			foreach (Task item in TaskHelper.TaskCollection.Tasks)
			{
				if (row.Cells["TaskName"].Value.ToString() == item.Name)
				{
					if (value)
					{
						item.Enabled = true;

						row.DefaultCellStyle.ForeColor = SystemColors.WindowText;
						row.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
					}
					else
					{
						item.Enabled = false;

						row.DefaultCellStyle.ForeColor = Color.Gray;
						row.DefaultCellStyle.SelectionForeColor = Color.Gray;
					}
				}
			}
		}

		SetChangesMade(true);
		dataGridView1.Focus();
	}

	private void ToggleEnabledToolStripMenuItem_Click(object sender, EventArgs e)
	{
		ToggleEnabled();
	}

	private void ToggleEnabledToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		ToggleEnabled();
	}

	private void DelayAfterCompletionMenuItem_Click(object sender, EventArgs e)
	{
		ChangeDelayAfterCompletion();
	}

	private void DelayAfterCompletionMenuItem1_Click(object sender, EventArgs e)
	{
		ChangeDelayAfterCompletion();
	}

	private void ChangeDelayAfterCompletion()
	{
		ChangeValueForm form = new ChangeValueForm("Delay after completion", true);
		form.ShowDialog();

		if (form.GetSuccess())
		{
			ToggleDelayAfterCompletion(form.GetNewIntegerValue());
		}
	}

	private void ToggleDelayAfterCompletion(int newValue)
	{
		foreach (DataGridViewRow row in dataGridView1.SelectedRows)
		{
			foreach (Task item in TaskHelper.TaskCollection.Tasks)
			{
				if (row.Cells["TaskName"].Value.ToString() == item.Name)
				{
					item.DelayAfterCompletion = newValue;
					row.Cells["DelayAfterCompletionColumn"].Value = newValue;
				}
			}
		}

		SetChangesMade(true);
		dataGridView1.Focus();
	}

	private void DescriptionTextBox_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.Control && e.KeyCode == Keys.A)
		{
			descriptionTextBox.SelectAll();
		}
	}

	private void ConnectionsTextBox_TextChanged(object sender, EventArgs e)
	{
		SetChangesMade(true);
	}

	private void TimeBetweenConnectionsTextBox_TextChanged(object sender, EventArgs e)
	{
		SetChangesMade(true);
	}

	private void SamplingIntervalTextBox_TextChanged(object sender, EventArgs e)
	{
		SetChangesMade(true);
	}

	private void FileToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
	{
		saveCollectionToolStripMenuItem.Enabled = true;
	}

	private void EnabledMenuItem_Click(object sender, EventArgs e)
	{
		SetEnabled(true);
	}

	private void DisabledMenuItem_Click(object sender, EventArgs e)
	{
		SetEnabled(false);
	}

	private void EnabledMenuItem1_Click(object sender, EventArgs e)
	{
		SetEnabled(true);
	}

	private void DisabledMenuItem1_Click(object sender, EventArgs e)
	{
		SetEnabled(false);
	}

	private void RenameMenuItem_Click(object sender, EventArgs e)
	{
		Rename();
	}

	private void RenameMenuItem1_Click(object sender, EventArgs e)
	{
		Rename();
	}

	private void Rename()
	{
		foreach (DataGridViewRow row in dataGridView1.SelectedRows)
		{
			foreach (Task item in TaskHelper.TaskCollection.Tasks)
			{
				if (row.Cells["TaskName"].Value.ToString() == item.Name)
				{
					ChangeValueForm form = new ChangeValueForm("Rename task", GenericHelper.CheckValue.TaskName, item.Name);
					form.ShowDialog();

					if (form.GetSuccess())
					{
						string newValue = form.GetNewStringValue();

						item.Name = newValue;
						row.Cells["TaskName"].Value = newValue;

						SetChangesMade(true);
						PopulateSearchList();
						dataGridView1.Focus();
					}
				}
			}
		}
	}

	private void SetupMenuItem1_Click(object sender, EventArgs e)
	{
		SetType(TaskHelper.TaskType.Setup);
	}

	private void TeardownMenuItem1_Click(object sender, EventArgs e)
	{
		SetType(TaskHelper.TaskType.Teardown);
	}

	private void SetupMenuItem_Click(object sender, EventArgs e)
	{
		SetType(TaskHelper.TaskType.Setup);
	}

	private void TeardownMenuItem_Click(object sender, EventArgs e)
	{
		SetType(TaskHelper.TaskType.Teardown);
	}

	private void SetType(TaskHelper.TaskType taskType)
	{
		foreach (DataGridViewRow row in dataGridView1.SelectedRows)
		{
			foreach (Task item in TaskHelper.TaskCollection.Tasks)
			{
				if (row.Cells["TaskName"].Value.ToString() == item.Name)
				{
					item.Type = taskType;
					row.Cells["TaskTypeColumn"].Value = TaskHelper.TaskTypeToString(taskType);
				}
			}
		}

		SetChangesMade(true);
		dataGridView1.Focus();
	}

	private void IOPerformanceTestToolStripMenuItem_Click(object sender, EventArgs e)
	{
		bool success = SaveChanges();

		if (success)
		{
			Import(PerformanceTestTool.Properties.Resources.IOPerformanceTest);
			UnloadFileName();
		}
	}

	private void PopulateSearchList()
	{
		_searchList = new List<string>();

		foreach (DataGridViewRow row in dataGridView1.Rows)
		{
			foreach (Task item in TaskHelper.TaskCollection.Tasks)
			{
				if (row.Cells["TaskName"].Value.ToString() == item.Name)
				{
					string searchText = "";

					if (_searchInName)
					{
						searchText += row.Cells["TaskName"].Value;
					}

					if (_searchInContent)
					{
						if (_searchInName)
						{
							searchText += "\r\n";
						}

						searchText += item.Sql;
					}

					if (_searchInDescription)
					{
						if (_searchInContent || _searchInName)
						{
							searchText += "\r\n";
						}

						searchText += item.Description;
					}

					_searchList.Add(searchText);
				}
			}
		}

		_searchForm.SetSearchList(_searchList);

		if (dataGridView1.SelectedRows.Count > 0)
		{
			_searchForm.Reset(dataGridView1.SelectedRows[0].Index);
		}
	}

	private void SearchForm_SearchEvent(int foundIndex, string searchTerm)
	{
		_selectionChangeFromSearch = true;

		dataGridView1.FirstDisplayedScrollingRowIndex = foundIndex;
		dataGridView1.CurrentCell = dataGridView1["TaskName", foundIndex];
		dataGridView1.Rows[foundIndex].Selected = true;

		_selectionChangeFromSearch = false;
	}

	private void SearchForm_RequestUpdateListEvent(bool name, bool content, bool description)
	{
		_searchInName = name;
		_searchInContent = content;
		_searchInDescription = description;

		PopulateSearchList();
	}

	private void FindToolStripMenuItem_Click_1(object sender, EventArgs e)
	{
		if (_searchForm.IsShown())
		{
			_searchForm.Activate();
		}
		else
		{
			_searchForm.Hide();
			_searchForm.Show(this);
		}
	}

	private void ImportTraceFileToolStripMenuItem_Click(object sender, EventArgs e)
	{
		bool success = SaveChanges();

		if (success)
		{
			DialogResult result = openFileDialog2.ShowDialog();

			if (result.ToString() == "OK")
			{
				Application.DoEvents();

				if (ImportTraceFile(openFileDialog2.FileName))
				{
					SetChangesMade(true);

					FillList();
					SelectFirstItem();
					descriptionTextBox.Text = TaskHelper.TaskCollection.Description;
					dataGridView1.Focus();
				}
			}
		}
	}

	private bool ImportTraceFile(string fileName)
	{
		DataTable traceData = _databaseOperation.ImportTraceFile(fileName);

		if (traceData != null)
		{
			TaskCollection taskCollection = TraceFileHandler.ImportTrace(traceData);

			if (taskCollection.Tasks.Count > 0)
			{
				foreach (Task task in taskCollection.Tasks)
				{
					task.Name = TaskHelper.GetNewItemName(task.Name);
					TaskHelper.TaskCollection.Tasks.Add(task);
				}

				return true;
			}
			else
			{
				MessageBox.Show("Error importing Trace File.\r\n\r\nThe Trace must contain all of the following columns with valid (not null) data:\r\nTextData, StartTime and DatabaseName", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		else
		{
			MessageBox.Show("Not a valid Trace File.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		return false;
	}

	private void ToggleIncludeInResultsMenuItem_Click(object sender, EventArgs e)
	{
		ToggleIncludeInResults();
	}

	private void ToggleIncludeInResultsMenuItem1_Click(object sender, EventArgs e)
	{
		ToggleIncludeInResults();
	}

	private void ToggleIncludeInResults()
	{
		foreach (DataGridViewRow row in dataGridView1.SelectedRows)
		{
			foreach (Task item in TaskHelper.TaskCollection.Tasks)
			{
				if (row.Cells["TaskName"].Value.ToString() == item.Name)
				{
					if (item.IncludeInResults)
					{
						item.IncludeInResults = false;
						row.Cells["IncludeInResultsColumn"].Value = "No";
					}
					else
					{
						item.IncludeInResults = true;
						row.Cells["IncludeInResultsColumn"].Value = "Yes";
					}
				}
			}
		}

		SetChangesMade(true);
		dataGridView1.Focus();
	}

	private void NormalMenuItem1_Click(object sender, EventArgs e)
	{
		SetType(TaskHelper.TaskType.Normal);
	}

	private void NormalMenuItem_Click(object sender, EventArgs e)
	{
		SetType(TaskHelper.TaskType.Normal);
	}

	private void ParallelRadioButton_CheckedChanged(object sender, EventArgs e)
	{
		SetChangesMade(true);
	}

	private void SerialRadioButton_CheckedChanged(object sender, EventArgs e)
	{
		SetChangesMade(true);
	}

	private void IncludeInResultsMenuItem_Click(object sender, EventArgs e)
	{
		SetIncludeInResults(true);
	}

	private void ExcludeFromResultsMenuItem_Click(object sender, EventArgs e)
	{
		SetIncludeInResults(false);
	}

	private void IncludeInResultsMenuItem1_Click(object sender, EventArgs e)
	{
		SetIncludeInResults(true);
	}

	private void ExcludeFromResultsMenuItem1_Click(object sender, EventArgs e)
	{
		SetIncludeInResults(false);
	}

	private void SetIncludeInResults(bool value)
	{
		foreach (DataGridViewRow row in dataGridView1.SelectedRows)
		{
			foreach (Task item in TaskHelper.TaskCollection.Tasks)
			{
				if (row.Cells["TaskName"].Value.ToString() == item.Name)
				{
					if (value)
					{
						item.IncludeInResults = true;
						row.Cells["IncludeInResultsColumn"].Value = "Yes";
					}
					else
					{
						item.IncludeInResults = false;
						row.Cells["IncludeInResultsColumn"].Value = "No";
					}
				}
			}
		}

		SetChangesMade(true);
		dataGridView1.Focus();
	}

	private void MinPoolingTextBox_TextChanged(object sender, EventArgs e)
	{
		SetChangesMade(true);
	}

	private void MaxPoolingTextBox_TextChanged(object sender, EventArgs e)
	{
		SetChangesMade(true);
	}

	private void UsePoolingCheckBox_CheckedChanged(object sender, EventArgs e)
	{
		SetChangesMade(true);

		if (usePoolingCheckBox.Checked)
		{
			minPoolingTextBox.Enabled = true;
			maxPoolingTextBox.Enabled = true;
			minPoolingTextBox.BackColor = Color.WhiteSmoke;
			maxPoolingTextBox.BackColor = Color.WhiteSmoke;
		}
		else
		{
			minPoolingTextBox.Enabled = false;
			maxPoolingTextBox.Enabled = false;
			minPoolingTextBox.BackColor = Color.Gainsboro;
			maxPoolingTextBox.BackColor = Color.Gainsboro;
		}
	}

	private void TasksTextBox_Enter(object sender, EventArgs e)
	{
		tasksTextBox.SelectionStart = 0;
		tasksTextBox.SelectionLength = 0;
		GenericHelper.HideCaret(tasksTextBox);
	}

	private void TasksTextBox_GotFocus(object sender, EventArgs e)
	{
		tasksTextBox.SelectionStart = 0;
		tasksTextBox.SelectionLength = 0;
		GenericHelper.HideCaret(tasksTextBox);
	}

	private void UpdateTasksTextBox()
	{
		tasksTextBox.Text = string.Format("Tasks: {0}", TaskHelper.TaskCollection.Tasks.Count);
	}
}
