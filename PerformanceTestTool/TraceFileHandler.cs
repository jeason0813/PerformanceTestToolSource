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
using System.Windows.Forms;

public static class TraceFileHandler
{
	public static TaskCollection ImportTrace(DataTable traceData)
	{
		List<TraceFileData> traceFileDataList = GetTraceData(traceData);
		return TaskHelper.TraceFileDataListToTaskCollection(traceFileDataList);
	}

	private static List<TraceFileData> GetTraceData(DataTable traceData)
	{
		List<TraceFileData> traceFileDataList = new List<TraceFileData>();

		foreach (DataRow row in traceData.Rows)
		{
			if (row["TextData"] != DBNull.Value && row["StartTime"] != DBNull.Value && row["DatabaseName"] != DBNull.Value)
			{
				if (!row["TextData"].ToString().StartsWith(TaskHelper.RecordingPrefix) && row["TextData"].ToString() != "exec sp_reset_connection ")
				{
					traceFileDataList.Add(new TraceFileData(row["TextData"].ToString(), Convert.ToDateTime(row["StartTime"]), row["DatabaseName"].ToString()));
				}
			}
		}

		return traceFileDataList;
	}

	public static bool DeleteTraceFile(bool showError, DatabaseOperation databaseOperation)
	{
		databaseOperation.DropEventSession();

		if (Directory.Exists(ConfigHandler.TraceFileDirectory))
		{
			foreach (string file in Directory.GetFiles(ConfigHandler.TraceFileDirectory, string.Format("{0}*.*", TaskHelper.TraceFileName)))
			{
				try
				{
					File.Delete(file);
				}
				catch (Exception ex)
				{
					if (showError)
					{
						MessageBox.Show(string.Format("Error deleting Trace File.\r\n\r\n{0}", ex.Message), GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}

					return false;
				}
			}
		}
		else
		{
			if (showError)
			{
				MessageBox.Show(string.Format("The Trace File Directory \"{0}\" does not exist.\r\n\r\nPlease create the directory manually.", ConfigHandler.TraceFileDirectory), GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			return false;
		}

		return true;
	}

	public static bool CheckTraceFileDirectoryRights()
	{
		try
		{
			if (Directory.Exists(ConfigHandler.TraceFileDirectory))
			{
				Directory.GetFiles(ConfigHandler.TraceFileDirectory, string.Format("{0}*.*", TaskHelper.TraceFileName));
			}

			return true;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			return false;
		}
	}
}
