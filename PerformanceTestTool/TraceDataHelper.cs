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

public class TraceDataHelper
{
	private readonly List<FirstConnectionStartTimeObject> _firstConnectionStartTimes;

	public class FirstConnectionStartTimeObject
	{
		public DateTime FirstConnectionStartTime;
		public TaskHelper.TaskType TaskType;

		public FirstConnectionStartTimeObject(DateTime firstConnectionStartTime, TaskHelper.TaskType taskType)
		{
			FirstConnectionStartTime = firstConnectionStartTime;
			TaskType = taskType;
		}
	}

	public TraceDataHelper()
	{
		_firstConnectionStartTimes = new List<FirstConnectionStartTimeObject>();
	}

	public List<ImportTraceDataValue> GetTraceDataList(DataTable traceData)
	{
		SetFirstStartTime(traceData);

		List<ImportTraceDataValue> traceDataList = new List<ImportTraceDataValue>();

		foreach (DataRow dataRow in traceData.Rows)
		{
			string textData = dataRow["TextData"].ToString();

			if (textData.StartsWith(TaskHelper.TaskQueryPrefix))
			{
				textData = textData.Replace("\n", "\r\n");
				textData = textData.Replace("\r\r\n", "\r\n");

				string name = textData.Substring(TaskHelper.TaskQueryPrefix.Length, textData.IndexOf("\r\n") - TaskHelper.TaskQueryPrefix.Length);
				string infoLine = textData.Split('\n')[1];
				int connection = Convert.ToInt32(infoLine.Substring(15, infoLine.Length - (15 + 1))); // 15 = "-- Connection: ".Length
				DateTime startTime = DateTime.Parse(dataRow["StartTime"].ToString());
				int connectionStartTime = GetConnectionsStartTime(startTime, name);

				foreach (DataColumn dataColumn in traceData.Columns)
				{
					if (dataColumn.ColumnName != "TextData")
					{
						if (dataRow[dataColumn.ColumnName] != DBNull.Value)
						{
							string columnName;
							long value;

							if (dataColumn.ColumnName == "StartTime")
							{
								value = Convert.ToInt64(connectionStartTime);
								columnName = "Start Time";
							}
							else if (dataColumn.ColumnName == "RowCounts")
							{
								value = Convert.ToInt64(dataRow[dataColumn.ColumnName].ToString());
								columnName = "Row Counts";
							}
							else
							{
								value = Convert.ToInt64(dataRow[dataColumn.ColumnName].ToString());
								columnName = dataColumn.ColumnName;
							}

							traceDataList.Add(new ImportTraceDataValue(name, columnName, value, connection));
						}
					}
				}
			}
		}

		return traceDataList;
	}

	public List<FirstConnectionStartTimeObject> GetFirstConnectionStartTimes()
	{
		return _firstConnectionStartTimes;
	}

	private void SetFirstStartTime(DataTable traceData)
	{
		foreach (Task task in TaskHelper.TaskCollection.Tasks)
		{
			if (task.Enabled && task.IncludeInResults && !DoesFirstConnectionStartTimesAlreadyHaveThisTaskType(task.Type))
			{
				DateTime firstConnectionStartTime = DateTime.MaxValue;

				foreach (DataRow dataRow in traceData.Rows)
				{
					string textData = dataRow["TextData"].ToString();

					if (textData.StartsWith(TaskHelper.TaskQueryPrefix))
					{
						textData = textData.Replace("\n", "\r\n");
						textData = textData.Replace("\r\r\n", "\r\n");

						string name = textData.Substring(TaskHelper.TaskQueryPrefix.Length, textData.IndexOf("\r\n") - TaskHelper.TaskQueryPrefix.Length);

						if (task.Name == name)
						{
							DateTime startTime = DateTime.Parse(dataRow["StartTime"].ToString());

							if (startTime < firstConnectionStartTime)
							{
								firstConnectionStartTime = startTime;
							}
						}
					}
				}

				_firstConnectionStartTimes.Add(new FirstConnectionStartTimeObject(firstConnectionStartTime, task.Type));
			}
		}
	}

	private bool DoesFirstConnectionStartTimesAlreadyHaveThisTaskType(TaskHelper.TaskType taskType)
	{
		foreach (FirstConnectionStartTimeObject firstConnectionStartTime in _firstConnectionStartTimes)
		{
			if (firstConnectionStartTime.TaskType == taskType)
			{
				return true;
			}
		}

		return false;
	}

	private int GetConnectionsStartTime(DateTime startTime, string taskName)
	{
		TaskHelper.TaskType taskType = new TaskHelper.TaskType();

		foreach (Task task in TaskHelper.TaskCollection.Tasks)
		{
			if (task.Name == taskName)
			{
				taskType = task.Type;
			}
		}

		foreach (FirstConnectionStartTimeObject firstConnectionStartTime in _firstConnectionStartTimes)
		{
			if (firstConnectionStartTime.TaskType == taskType)
			{
				return Convert.ToInt32(startTime.Subtract(firstConnectionStartTime.FirstConnectionStartTime).TotalMilliseconds);
			}
		}

		return 0;
	}
}
