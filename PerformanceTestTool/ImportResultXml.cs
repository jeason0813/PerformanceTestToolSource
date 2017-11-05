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
using System.Windows.Forms;
using System.Xml;

public class ImportResultXml
{
	private readonly List<ImportTraceDataValue> _traceData;
	private readonly List<CalculatedPerformanceCounter> _calculatedPerformanceCounters;
	private readonly List<RanTaskInfo> _ranTaskInfo;
	private readonly ResultTaskCollection _resultTaskCollection;
	private readonly bool _success;
	private readonly ResultInfo _resultInfo;

	public ImportResultXml(string resultXmlFileName)
	{
		_traceData = new List<ImportTraceDataValue>();
		_calculatedPerformanceCounters = new List<CalculatedPerformanceCounter>();
		_ranTaskInfo = new List<RanTaskInfo>();
		_resultTaskCollection = new ResultTaskCollection();
		_resultInfo = new ResultInfo();

		try
		{
			ParseXml(resultXmlFileName);
			_success = true;
		}
		catch
		{
			MessageBox.Show("Not a valid Result Xml file.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			_success = false;
		}
	}

	public ResultInfo GetResultInfo()
	{
		return _resultInfo;
	}

	public bool GetSuccess()
	{
		return _success;
	}

	public ResultTaskCollection GetResultTaskCollection()
	{
		return _resultTaskCollection;
	}

	public List<ImportTraceDataValue> GetTraceData()
	{
		return _traceData;
	}

	public List<CalculatedPerformanceCounter> GetCalculatedPerformanceCounters()
	{
		return _calculatedPerformanceCounters;
	}

	public List<RanTaskInfo> GetRanTaskInfo()
	{
		return _ranTaskInfo;
	}

	private void ParseXml(string resultXmlFileName)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(resultXmlFileName);

		XmlNode resultNode = xmlDocument.SelectSingleNode("result");
		ParseResultNode(resultNode);
	}

	private void ParseResultNode(XmlNode node)
	{
		string runTime = node.Attributes["runTime"].Value;
		string version = node.Attributes["version"].Value;
		string totalExecutionTime = node.Attributes["executionTime"].Value;

		HandleResultNode(runTime, version, totalExecutionTime);

		XmlNode serverNode = node.SelectSingleNode("server");
		ParseServerNode(serverNode);

		XmlNode tasksNode = node.SelectSingleNode("tasks");
		ParseTasksNode(tasksNode);

		XmlNode performanceCountersNode = node.SelectSingleNode("performanceCounters");
		ParsePerformanceCountersNode(performanceCountersNode);
	}

	private void ParseServerNode(XmlNode node)
	{
		foreach (XmlElement infoNode in node.SelectNodes("info"))
		{
			ParseServerInfoNode(infoNode);
		}
	}

	private void ParseServerInfoNode(XmlNode node)
	{
		string name = node.Attributes["name"].Value;
		string value = node.Attributes["value"].Value;

		HandleServerInfoNode(name, value);
	}

	private void ParseTasksNode(XmlNode node)
	{
		string taskCollectionDescription = node.Attributes["description"].Value;
		int connections = Convert.ToInt32(node.Attributes["connections"].Value);
		int timeBetweenConnections = Convert.ToInt32(node.Attributes["timeBetweenConnections"].Value);
		string mode = node.Attributes["mode"].Value;
		bool usePooling = Convert.ToBoolean(node.Attributes["usePooling"].Value);
		int minPooling = Convert.ToInt32(node.Attributes["minPooling"].Value);
		int maxPooling = Convert.ToInt32(node.Attributes["maxPooling"].Value);

		HandleTasksNode(taskCollectionDescription, connections, timeBetweenConnections, mode, usePooling, minPooling, maxPooling);

		foreach (XmlElement taskNode in node.SelectNodes("task"))
		{
			ParseTaskNode(taskNode);
		}
	}

	private void ParseTaskNode(XmlNode node)
	{
		string taskName = node.Attributes["name"].Value;
		string description = node.Attributes["description"].Value;
		int delayAfterCompletion = Convert.ToInt32(node.Attributes["delayAfterCompletion"].Value);
		TaskHelper.TaskType type = TaskHelper.StringToTaskType(node.Attributes["type"].Value);
		DateTime firstConnectionStartTime = Convert.ToDateTime(node.Attributes["firstConnectionStartTime"].Value);

		HandleTaskNode(taskName, description, delayAfterCompletion, type, firstConnectionStartTime);

		XmlNode dataNode = node.SelectSingleNode("data");
		ParseDataNode(dataNode, taskName);
	}

	private void ParseDataNode(XmlNode node, string taskName)
	{
		XmlNode connectionValuesNode = node.SelectSingleNode("connectionValues");
		ParseConnectionValuesNode(connectionValuesNode, taskName);
	}

	private void ParseConnectionValuesNode(XmlNode node, string taskName)
	{
		foreach (XmlElement connectionValueNode in node.SelectNodes("value"))
		{
			ParseConnectionValueNode(connectionValueNode, taskName);
		}
	}

	private void ParseConnectionValueNode(XmlNode node, string taskName)
	{
		int connection = Convert.ToInt32(node.Attributes["connection"].Value);
		long reads = Convert.ToInt64(node.Attributes["reads"].Value);
		long writes = Convert.ToInt64(node.Attributes["writes"].Value);
		long cpu = Convert.ToInt64(node.Attributes["cpu"].Value);
		long rowcounts = Convert.ToInt64(node.Attributes["rowcounts"].Value);
		long duration = Convert.ToInt64(node.Attributes["duration"].Value);

		string startTime = null;

		if (node.Attributes["starttime"] != null)
		{
			startTime = node.Attributes["starttime"].Value;
		}

		string message = null;

		if (node.Attributes["message"] != null)
		{
			message = node.Attributes["message"].Value;
		}

		HandleConnectionValues(connection, reads, writes, cpu, rowcounts, duration, startTime, message, taskName);
	}

	private void ParsePerformanceCountersNode(XmlNode node)
	{
		int samples = Convert.ToInt32(node.Attributes["samples"].Value);
		int interval = Convert.ToInt32(node.Attributes["interval"].Value);

		HandlePerformanceCountersNode(samples, interval);
		ParsePerformanceCounterNodes(node);
	}

	private void ParsePerformanceCounterNodes(XmlNode node)
	{
		foreach (XmlElement objectNode in node.SelectNodes("object"))
		{
			string objectName = objectNode.Attributes["name"].Value;

			foreach (XmlElement counterNode in objectNode.SelectNodes("counter"))
			{
				string counterName = counterNode.Attributes["name"].Value;

				foreach (XmlElement instanceNode in counterNode.SelectNodes("value"))
				{
					string instanceName = instanceNode.Attributes["instanceName"].Value;

					long minimum = Convert.ToInt64(instanceNode.Attributes["minimum"].Value);
					long maximum = Convert.ToInt64(instanceNode.Attributes["maximum"].Value);
					long average = Convert.ToInt64(instanceNode.Attributes["average"].Value);

					HandlePerformanceCounterValues(objectName, counterName, instanceName, minimum, maximum, average);
				}
			}
		}
	}

	private void HandleResultNode(string runTime, string version, string totalExecutionTime)
	{
		_resultInfo.RunTime = Convert.ToDateTime(runTime);
		_resultInfo.TotalExecutionTime = totalExecutionTime;
		_resultInfo.Version = version;
	}

	private void HandleServerInfoNode(string name, string value)
	{
		switch (name)
		{
			case "SQL Server":
				_resultInfo.SqlServer = value;
				break;
			case "Operating System":
				_resultInfo.OsVersion = value;
				break;
			case "SQL Server Version":
				_resultInfo.SqlServerVersion = value;
				break;
			case "Logical CPU Count":
				_resultInfo.LogicalCpuCount = value;
				break;
			case "Physical CPU Count":
				_resultInfo.PhysicalCpuCount = value;
				break;
			case "Physical Memory":
				_resultInfo.PhysicalMemory = value;
				break;
			case "SQL Server Max Memory":
				_resultInfo.MaxMemory = value;
				break;
		}
	}

	private void HandleTasksNode(string description, int connections, int timeBetweenConnections, string mode, bool usePooling, int minPooling, int maxPooling)
	{
		_resultTaskCollection.Description = description;
		_resultTaskCollection.Connections = connections;
		_resultTaskCollection.TimeBetweenConnections = timeBetweenConnections;
		_resultTaskCollection.Mode = mode;
		_resultTaskCollection.UsePooling = usePooling;
		_resultTaskCollection.MinPooling = minPooling;
		_resultTaskCollection.MaxPooling = maxPooling;
	}

	private void HandleTaskNode(string taskName, string description, int delayAfterCompletion, TaskHelper.TaskType type, DateTime firstConnectionStartTime)
	{
		_resultTaskCollection.Tasks.Add(new ResultTask(taskName, description, delayAfterCompletion, type, firstConnectionStartTime));
	}

	private void HandleConnectionValues(int connection, long reads, long writes, long cpu, long rowcounts, long duration, string startTime, string message, string taskName)
	{
		_traceData.Add(new ImportTraceDataValue(taskName, "Reads", reads, connection));
		_traceData.Add(new ImportTraceDataValue(taskName, "Writes", writes, connection));
		_traceData.Add(new ImportTraceDataValue(taskName, "CPU", cpu, connection));
		_traceData.Add(new ImportTraceDataValue(taskName, "Row Counts", rowcounts, connection));
		_traceData.Add(new ImportTraceDataValue(taskName, "Duration", duration, connection));

		if (startTime != null)
		{
			_traceData.Add(new ImportTraceDataValue(taskName, "Start Time", Convert.ToInt64(TimeSpan.Parse(startTime).TotalMilliseconds), connection));
		}

		if (message != null)
		{
			RanTaskInfo ranTaskInfo = new RanTaskInfo();
			ranTaskInfo.TaskName = taskName;
			ranTaskInfo.ConnectionNumber = connection;
			ranTaskInfo.Message = message;
			_ranTaskInfo.Add(ranTaskInfo);
		}
	}

	private void HandlePerformanceCountersNode(int samples, int interval)
	{
		_resultTaskCollection.PerformanceCountersSamples = samples;
		_resultTaskCollection.PerformanceCountersSamplingInterval = interval;
	}

	private void HandlePerformanceCounterValues(string objectName, string counterName, string instanceName, long minimum, long maximum, long average)
	{
		_calculatedPerformanceCounters.Add(new CalculatedPerformanceCounter(objectName, counterName, instanceName, minimum, maximum, average));
	}
}
