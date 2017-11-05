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
using System.Text;
using System.Windows.Forms;
using System.Xml;

public static class TaskHelper
{
	private static Guid _uniqueTestGuid = Guid.NewGuid();

	public static string TaskCollectionFileName;
	public static string TaskQueryPrefix = string.Format("-- Task ({0}) (Measurable): ", _uniqueTestGuid);
	public static string NonTaskQueryPrefix = string.Format("-- Task ({0}) (Non-Measurable): ", _uniqueTestGuid);
	public static string RecordingPrefix = string.Format("-- Recording ({0})", _uniqueTestGuid);
	public static string TraceFileName = string.Format("PerformanceTestTool-{0}", _uniqueTestGuid);

	private static TaskCollection _taskCollection;

	public enum TaskType
	{
		Setup,
		Normal,
		Teardown
	}

	public static void CreateNewGuid()
	{
		_uniqueTestGuid = Guid.NewGuid();

		TaskQueryPrefix = string.Format("-- Task ({0}) (Measurable): ", _uniqueTestGuid);
		NonTaskQueryPrefix = string.Format("-- Task ({0}) (Non-Measurable): ", _uniqueTestGuid);
		RecordingPrefix = string.Format("-- Recording ({0})", _uniqueTestGuid);
		TraceFileName = string.Format("PerformanceTestTool-{0}", _uniqueTestGuid);
	}

	public static int GetStep(Task task)
	{
		int count = 0;

		for (int i = 0; i < TaskCollection.Tasks.Count; i++)
		{
			if (task.Type == TaskType.Setup && TaskCollection.Tasks[i].Type == TaskType.Setup)
			{
				count++;

				if (TaskCollection.Tasks[i].Name == task.Name)
				{
					break;
				}
			}

			if (task.Type == TaskType.Normal && TaskCollection.Tasks[i].Type == TaskType.Normal)
			{
				count++;

				if (TaskCollection.Tasks[i].Name == task.Name)
				{
					break;
				}
			}

			if (task.Type == TaskType.Teardown && TaskCollection.Tasks[i].Type == TaskType.Teardown)
			{
				count++;

				if (TaskCollection.Tasks[i].Name == task.Name)
				{
					break;
				}
			}
		}

		return count;
	}

	public static bool AnyTasksWithIncludeInResults()
	{
		foreach (Task task in TaskCollection.Tasks)
		{
			if (task.Enabled && task.IncludeInResults)
			{
				return true;
			}
		}

		return false;
	}

	public static List<Task> GetSetupTasks()
	{
		List<Task> enabledTasks = new List<Task>();

		foreach (Task task in TaskCollection.Tasks)
		{
			if (task.Enabled && task.Type == TaskType.Setup)
			{
				enabledTasks.Add(task);
			}
		}

		return enabledTasks;
	}

	public static List<Task> GetTeardownTasks()
	{
		List<Task> enabledTasks = new List<Task>();

		foreach (Task task in TaskCollection.Tasks)
		{
			if (task.Enabled && task.Type == TaskType.Teardown)
			{
				enabledTasks.Add(task);
			}
		}

		return enabledTasks;
	}

	public static List<Task> GetNormalTasks()
	{
		List<Task> enabledTasks = new List<Task>();

		foreach (Task task in TaskCollection.Tasks)
		{
			if (task.Enabled && task.Type == TaskType.Normal)
			{
				enabledTasks.Add(task);
			}
		}

		return enabledTasks;
	}

	public static int GetNumberOfNormalTasks()
	{
		int count = 0;

		foreach (Task task in TaskCollection.Tasks)
		{
			if (task.Enabled && task.Type == TaskType.Normal)
			{
				count++;
			}
		}

		return count;
	}

	public static string GetNewItemName(string name)
	{
		bool uniqueName;

		do
		{
			uniqueName = true;

			foreach (Task item in TaskCollection.Tasks)
			{
				if (item.Name == name)
				{
					uniqueName = false;
					break;
				}
			}

			if (!uniqueName)
			{
				name = string.Format("{0} (copy)", name);
			}
		} while (!uniqueName);

		return name;
	}

	public static void SaveTaskCollection(string fileName)
	{
		XmlHelper.WriteXmlToFile(TaskCollectionToXml(TaskCollection), fileName);
	}

	public static TaskCollection TaskCollection
	{
		get
		{
			if (_taskCollection == null)
			{
				_taskCollection = new TaskCollection();
				_taskCollection.Connections = 1;
				_taskCollection.PerformanceCountersSamplingInterval = 0;
				_taskCollection.TimeBetweenConnections = 0;
				_taskCollection.Mode = "Parallel";
				_taskCollection.UsePooling = true;
				_taskCollection.MinPooling = 0;
				_taskCollection.MaxPooling = 100;
			}

			return _taskCollection;
		}
		set
		{
			_taskCollection = value;
		}
	}

	public static TaskType StringToTaskType(string typeString)
	{
		return (TaskType)Enum.Parse(typeof(TaskType), typeString, true);
	}

	public static string TaskTypeToString(TaskType taskType)
	{
		switch (taskType)
		{
			case TaskType.Setup:
				return "Setup";
			case TaskType.Normal:
				return "Normal";
			case TaskType.Teardown:
				return "Teardown";
		}

		return null;
	}

	public static string TaskCollectionToXml(TaskCollection taskCollection)
	{
		if (taskCollection.Tasks == null)
		{
			return "";
		}

		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
		stringBuilder.Append(string.Format("<tasks description=\"{0}\" connections=\"{1}\" timeBetweenConnections=\"{2}\" performanceCountersSamplingInterval=\"{3}\" mode=\"{4}\" usePooling=\"{5}\" minPooling=\"{6}\" maxPooling=\"{7}\">", System.Security.SecurityElement.Escape(taskCollection.Description), taskCollection.Connections, taskCollection.TimeBetweenConnections, taskCollection.PerformanceCountersSamplingInterval, taskCollection.Mode, taskCollection.UsePooling, taskCollection.MinPooling, taskCollection.MaxPooling));

		foreach (Task task in taskCollection.Tasks)
		{
			stringBuilder.Append(string.Format("<task name=\"{0}\" sql=\"{1}\" type=\"{2}\" description=\"{3}\" enabled=\"{4}\" delayAfterCompletion=\"{5}\" includeInResults=\"{6}\" />", System.Security.SecurityElement.Escape(task.Name), System.Security.SecurityElement.Escape(task.Sql), task.Type, System.Security.SecurityElement.Escape(task.Description), task.Enabled, task.DelayAfterCompletion, task.IncludeInResults));
		}

		stringBuilder.Append("</tasks>");
		return stringBuilder.ToString();
	}

	public static TaskCollection XmlToTaskCollection(string xml)
	{
		if (string.IsNullOrEmpty(xml))
		{
			return null;
		}

		TaskCollection taskCollection = new TaskCollection();

		try
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xml);

			XmlNode tasksNode = xmlDocument.SelectSingleNode("/tasks");
			XmlNodeList taskNodes = xmlDocument.SelectNodes("/tasks/task");

			foreach (XmlElement taskNode in taskNodes)
			{
				string name = taskNode.Attributes["name"].Value;
				string description = taskNode.Attributes["description"].Value;
				int delayAfterCompletion = Convert.ToInt32(taskNode.Attributes["delayAfterCompletion"].Value);
				string sql = taskNode.Attributes["sql"].Value;
				string typeString = taskNode.Attributes["type"].Value;
				bool enabled = Convert.ToBoolean(taskNode.Attributes["enabled"].Value);
				bool includeInResults = Convert.ToBoolean(taskNode.Attributes["includeInResults"].Value);

				Task task = new Task(name, description, delayAfterCompletion, sql, StringToTaskType(typeString), enabled, includeInResults);
				taskCollection.Tasks.Add(task);
			}

			taskCollection.Description = tasksNode.Attributes["description"].Value;
			taskCollection.Connections = Convert.ToInt32(tasksNode.Attributes["connections"].Value);
			taskCollection.TimeBetweenConnections = Convert.ToInt32(tasksNode.Attributes["timeBetweenConnections"].Value);
			taskCollection.PerformanceCountersSamplingInterval = Convert.ToInt32(tasksNode.Attributes["performanceCountersSamplingInterval"].Value);
			taskCollection.Mode = tasksNode.Attributes["mode"].Value;
			taskCollection.UsePooling = Convert.ToBoolean(tasksNode.Attributes["usePooling"].Value);
			taskCollection.MinPooling = Convert.ToInt32(tasksNode.Attributes["minPooling"].Value);
			taskCollection.MaxPooling = Convert.ToInt32(tasksNode.Attributes["maxPooling"].Value);
		}
		catch (Exception ex)
		{
			if (ex.Message == "Object reference not set to an instance of an object.")
			{
				MessageBox.Show("Task Collection file is missing one or more elements.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				MessageBox.Show(string.Format("Error in converting Xml to tasks.\r\n\r\n{0}", ex.Message), GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

			return null;
		}

		if (!UniqueNames(taskCollection))
		{
			MessageBox.Show("Task Names are not unique.,", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			return null;
		}

		return taskCollection;
	}

	public static bool UniqueTaskName(string name, string initialNameValue)
	{
		if (name.Trim() == "")
		{
			MessageBox.Show("Name can't be empty.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			return false;
		}

		if (name.Trim().ToLower() == "summary")
		{
			MessageBox.Show("\"Summary\" is a reserved name.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			return false;
		}

		foreach (Task item in TaskCollection.Tasks)
		{
			if (name.Trim().ToLower() == item.Name.ToLower() && initialNameValue.ToLower() != name.Trim().ToLower())
			{
				MessageBox.Show("Another task with the same name already exists.\r\n\r\nTask names must be unique.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
		}

		return true;
	}

	public static TaskCollection TraceFileDataListToTaskCollection(List<TraceFileData> traceFileDataList)
	{
		TaskCollection taskCollection = new TaskCollection();

		traceFileDataList.Sort
		(
			delegate(TraceFileData t1, TraceFileData t2)
			{
				return t1.StartTime.CompareTo(t2.StartTime);
			}
		);

		for (int i = 0; i < traceFileDataList.Count; i++)
		{
			const string taskDescription = "";
			const bool enabled = true;
			const bool includeInResults = true;
			int delayAfterCompletion = 0;

			if (i > 0)
			{
				DateTime currentStartTime = traceFileDataList[i].StartTime;
				DateTime previousStartTime = traceFileDataList[i - 1].StartTime;
				TimeSpan diff = currentStartTime.Subtract(previousStartTime);
				delayAfterCompletion = Convert.ToInt32(diff.TotalMilliseconds);
			}

			string name = string.Format("Task {0} ({1})", i + 1, GetPartOfTaskName(traceFileDataList[i].TextData));
			string sql = string.Format("use [{0}]\r\n\r\n{1}", traceFileDataList[i].DatabaseName, traceFileDataList[i].TextData);

			sql = sql.Replace("\n", "\r\n");
			sql = sql.Replace("\r\r\n", "\r\n");

			Task task = new Task(name, taskDescription, delayAfterCompletion, sql, TaskType.Normal, enabled, includeInResults);
			taskCollection.Tasks.Add(task);
		}

		return taskCollection;
	}

	public static string PrintsToMessage(List<string> prints)
	{
		StringBuilder stringBuilder = new StringBuilder();

		for (int i = 0; i < prints.Count; i++)
		{
			if (i < prints.Count - 1)
			{
				stringBuilder.Append(string.Format("{0}, ", prints[i]));
			}
			else
			{
				stringBuilder.Append(prints[i]);
			}
		}

		return stringBuilder.ToString();
	}

	private static bool UniqueNames(TaskCollection taskCollection)
	{
		string[] names = new string[taskCollection.Tasks.Count];

		for (int i = 0; i < taskCollection.Tasks.Count; i++)
		{
			names[i] = taskCollection.Tasks[i].Name;
		}

		return GenericHelper.UniqueElements(names);
	}

	private static string GetPartOfTaskName(string textData)
	{
		int maxLen = 20;

		if (textData.Length < maxLen)
		{
			maxLen = textData.Length;
		}

		string partOfTaskName = textData.Replace("\t", " ");
		partOfTaskName = partOfTaskName.Replace("\n", "\r\n");
		partOfTaskName = partOfTaskName.Replace("\r\r\n", "\r\n");
		partOfTaskName = partOfTaskName.Replace("\r\n", " ");

		while (partOfTaskName.Contains("  "))
		{
			partOfTaskName = partOfTaskName.Replace("  ", " ");
		}

		if (partOfTaskName.Length > maxLen)
		{
			partOfTaskName = string.Format("{0}...", partOfTaskName.Substring(0, maxLen));
		}
		else
		{
			partOfTaskName = partOfTaskName.Substring(0, partOfTaskName.Length);
		}

		return partOfTaskName;
	}
}
