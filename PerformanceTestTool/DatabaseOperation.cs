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
using System.IO;

public class DatabaseOperation : Dal
{
	public string GetSqlServerDataDir()
	{
		DataTable dataTable = ExecuteDataTable("select substring(f.physical_name, 1, charindex(N'master.mdf', lower(f.physical_name)) - 1) DataDir from master.sys.master_files f where f.database_id = 1 and f.file_id = 1");
		return dataTable.Rows[0]["DataDir"].ToString();
	}

	public DataTable GetSqlServerInfo()
	{
		string colName = "physical_memory_in_bytes / 1048576";

		if (GetSqlServerVersion() >= 11) // SQL Server 2012 and newer
		{
			colName = "physical_memory_kb / 1024";
		}

		DataTable dataTable = ExecuteDataTable(string.Format(PerformanceTestTool.Properties.Resources.SqlServerInfo, colName));
		return dataTable;
	}

	public int CreateTrace()
	{
		string traceFile = string.Format(@"{0}\{1}", ConfigHandler.TraceFileDirectory.Replace("'", "''"), TaskHelper.TraceFileName);

		if (ConfigHandler.UseExtendedEvents == "False" || GetSqlServerVersion() < 11)
		{
			string sql = string.Format(PerformanceTestTool.Properties.Resources.CreateTrace, traceFile);

			DataTable dataTable = ExecuteDataTable(sql);

			int traceId = Convert.ToInt32(dataTable.Rows[0]["TraceID"].ToString());
			int returnCode = Convert.ToInt32(dataTable.Rows[0]["ReturnCode"].ToString());

			if (returnCode == 13) // Out of memory
			{
				traceId = -1;
			}

			return traceId;
		}
		else
		{
			string sql = string.Format(PerformanceTestTool.Properties.Resources.CreateEventSession, TaskHelper.TraceFileName, traceFile);

			bool success = Execute(sql);

			return Convert.ToInt32(success);
		}
	}

	public bool SetTraceStatus(int traceId, int status)
	{
		if (ConfigHandler.UseExtendedEvents == "False" || GetSqlServerVersion() < 11)
		{
			string sql = string.Format("{2}\r\nexec sp_trace_setstatus {0}, {1}", traceId, status, TaskHelper.RecordingPrefix);
			return Execute(sql);
		}
		else
		{
			string state = "";

			if (status == 0)
			{
				state = "stop";
			}
			else if (status == 1)
			{
				state = "start";
			}

			string sql = string.Format("{2}\r\nalter event session [{0}] on server state = {1}", TaskHelper.TraceFileName, state, TaskHelper.RecordingPrefix);
			return Execute(sql);
		}
	}

	public bool StartTrace(int traceId)
	{
		if (ConfigHandler.UseExtendedEvents == "False" || GetSqlServerVersion() < 11)
		{
			string sql = string.Format(PerformanceTestTool.Properties.Resources.StartTrace, traceId);
			return Execute(sql);
		}
		else
		{
			string sql = string.Format(PerformanceTestTool.Properties.Resources.StartEventSession, TaskHelper.TraceFileName);
			return Execute(sql);
		}
	}

	public bool StartTraceRecording(int traceId)
	{
		if (ConfigHandler.UseExtendedEvents == "False" || GetSqlServerVersion() < 11)
		{
			string sql = string.Format(PerformanceTestTool.Properties.Resources.StartTraceRecording, traceId, TaskHelper.RecordingPrefix);
			return Execute(sql);
		}
		else
		{
			string sql = string.Format(PerformanceTestTool.Properties.Resources.StartEventSessionRecording, TaskHelper.TraceFileName, TaskHelper.RecordingPrefix);
			return Execute(sql);
		}
	}

	public bool StopDeleteTrace()
	{
		if (ConfigHandler.UseExtendedEvents == "False" || GetSqlServerVersion() < 11)
		{
			string traceFile = string.Format(@"{0}\{1}", ConfigHandler.TraceFileDirectory.Replace("'", "''"), TaskHelper.TraceFileName);
			string sql = string.Format(PerformanceTestTool.Properties.Resources.StopDeleteTrace, traceFile);
			return Execute(sql);
		}
		else
		{
			string sql = string.Format(PerformanceTestTool.Properties.Resources.StopEventSession, TaskHelper.TraceFileName);
			return Execute(sql);
		}
	}

	public bool DropEventSession()
	{
		if (ConfigHandler.UseExtendedEvents == "True" || GetSqlServerVersion() >= 11)
		{
			string sql = string.Format(PerformanceTestTool.Properties.Resources.DropEventSession, TaskHelper.TraceFileName);
			return Execute(sql);
		}

		return true;
	}

	public DataTable GetTraceData()
	{
		string traceFile = string.Format(@"{0}\{1}", ConfigHandler.TraceFileDirectory.Replace("'", "''"), TaskHelper.TraceFileName);

		if (ConfigHandler.UseExtendedEvents == "False" || GetSqlServerVersion() < 11)
		{
			return ExecuteDataTable(string.Format(PerformanceTestTool.Properties.Resources.GetTraceData, traceFile));
		}
		else
		{
			return ExecuteDataTable(string.Format(PerformanceTestTool.Properties.Resources.GetEventSessionData, traceFile));
		}
	}

	public DataTable GetTraceRecordingData()
	{
		string traceFile = string.Format(@"{0}\{1}", ConfigHandler.TraceFileDirectory.Replace("'", "''"), TaskHelper.TraceFileName);

		if (ConfigHandler.UseExtendedEvents == "False" || GetSqlServerVersion() < 11)
		{
			return ExecuteDataTable(string.Format(PerformanceTestTool.Properties.Resources.GetTraceRecordingData, traceFile));
		}
		else
		{
			return ExecuteDataTable(string.Format(PerformanceTestTool.Properties.Resources.GetEventSessionRecordingData, traceFile));
		}
	}

	public DataTable ImportTraceFile(string fileName)
	{
		string traceFile = string.Format(@"{0}\{1}", Path.GetDirectoryName(fileName).Replace("'", "''"), Path.GetFileNameWithoutExtension(fileName).Replace("'", "''"));

		if (Path.GetExtension(fileName).ToLower() == ".trc")
		{
			return ExecuteDataTable(string.Format(PerformanceTestTool.Properties.Resources.GetTraceRecordingData, traceFile));
		}
		else if (Path.GetExtension(fileName).ToLower() == ".xel" && GetSqlServerVersion() >= 11)
		{
			return ExecuteDataTable(string.Format(PerformanceTestTool.Properties.Resources.GetEventSessionRecordingData, traceFile));
		}

		return null;
	}

	public List<PerformanceCounter> GetPerformanceCounters()
	{
		DataTable dataTable = ExecuteDataTable(PerformanceTestTool.Properties.Resources.GetPerformanceCounters);

		List<PerformanceCounter> performanceCounterList = new List<PerformanceCounter>();

		foreach (DataRow dataRow in dataTable.Rows)
		{
			PerformanceCounter performanceCounter = new PerformanceCounter();
			performanceCounter.ObjectName = FormatObjectName(dataRow["ObjectName"].ToString().Replace("\0", "")).Trim();
			performanceCounter.CounterName = dataRow["CounterName"].ToString().Replace("\0", "").Trim();
			performanceCounter.InstanceName = dataRow["InstanceName"].ToString().Replace("\0", "").Trim();
			performanceCounter.Value = Convert.ToInt64(dataRow["Value"]);

			performanceCounterList.Add(performanceCounter);
		}

		performanceCounterList.Sort(delegate(PerformanceCounter p1, PerformanceCounter p2)
		{
			int r = p1.ObjectName.CompareTo(p2.ObjectName);

			if (r == 0)
			{
				r = p1.CounterName.CompareTo(p2.CounterName);
			}

			if (r == 0)
			{
				r = p1.InstanceName.CompareTo(p2.InstanceName);
			}

			return r;
		});

		return performanceCounterList;
	}

	private static string FormatObjectName(string objectName)
	{
		if (objectName.Contains(":"))
		{
			int pos = objectName.IndexOf(':') + 1;

			objectName = objectName.Substring(pos, objectName.Length - pos);
		}

		return objectName;
	}
}
