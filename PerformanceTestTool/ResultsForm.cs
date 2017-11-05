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
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;

public partial class ResultsForm : Form
{
	public delegate void MessageToMainFormEventHandler(string message);
	public event MessageToMainFormEventHandler MessageToMainFormEvent;

	private int _splitterDistance;
	private string _xmlFileName;
	private string _xml;
	private string _fileNameInStylesheetWebBrowser;
	private bool _dontInitiateStylesheetBrowser;
	private string _stylesheetWebBrowserUrl;
	private ListViewColumnSorter _listViewColumnSorter;
	private List<CalculatedPerformanceCounter> _performanceCounters;

	public void SetData(List<ImportTraceDataValue> traceDataList, List<CalculatedPerformanceCounter> performanceCounters, List<RanTaskInfo> ranTaskInfo, ResultTaskCollection resultTaskCollection, ResultInfo resultInfo)
	{
		Hide();
		InitializeComponent();
		Initialize(traceDataList, performanceCounters, ranTaskInfo, resultTaskCollection, resultInfo);
		PostInitializeSteps();

		FireMessageToMainFormEvent("Status: Idle");
	}

	public void SetData(List<ImportTraceDataValue> traceDataList, List<CalculatedPerformanceCounter> performanceCounters, string unattendedTempDir, List<RanTaskInfo> ranTaskInfo, bool includeStylesheets, ResultTaskCollection resultTaskCollection, ResultInfo resultInfo)
	{
		Hide();
		InitializeComponent();
		Initialize(traceDataList, performanceCounters, ranTaskInfo, resultTaskCollection, resultInfo);

		if (includeStylesheets)
		{
			foreach (Stylesheet stylesheet in StylesheetHelper.StylesheetCollection.Stylesheets)
			{
				if (stylesheet.Enabled)
				{
					string transformedXmlFileName = string.Format(@"{0}\PerformanceTestToolResultTransformed_{1}.{2}", unattendedTempDir, stylesheet.Name, stylesheet.OutputFormat.ToLower());
					XslTransform(stylesheet.Xslt, _xmlFileName, transformedXmlFileName, stylesheet.OutputFormat);
				}
			}
		}

		string logDirAndFileName = string.Format(@"{0}\{1}", unattendedTempDir, GenericHelper.UnattendedLogFileName);
		XmlHelper.WriteXmlToFile(_xml, logDirAndFileName);
		Close();
	}

	public void Cleanup()
	{
		xmlWebBrowser.Dispose();
		stylesheetWebBrowser.Dispose();

		if (File.Exists(_xmlFileName))
		{
			File.Delete(_xmlFileName);
		}

		if (_fileNameInStylesheetWebBrowser != null)
		{
			if (File.Exists(_fileNameInStylesheetWebBrowser))
			{
				File.Delete(_fileNameInStylesheetWebBrowser);
			}
		}
	}

	private void PostInitializeSteps()
	{
		FireMessageToMainFormEvent("Status: Starting Results viewer...");

		InitializeXmlWebBrowser();
		FillStylesheets();
		LoadStylesheetInWebBrowser();

		tabControlEX1.Select();
		Application.DoEvents();
		Show();
	}

	private void FireMessageToMainFormEvent(string message)
	{
		if (MessageToMainFormEvent != null)
		{
			MessageToMainFormEvent(message);
		}
	}

	private void ShowPerformanceCounterResults(List<CalculatedPerformanceCounter> performanceCounterList, int samples, int interval)
	{
		foreach (CalculatedPerformanceCounter performanceCounter in performanceCounterList)
		{
			ListViewItem listViewItem = new ListViewItem();
			listViewItem.Text = performanceCounter.ObjectName;
			listViewItem.SubItems.Add(performanceCounter.CounterName);
			listViewItem.SubItems.Add(performanceCounter.InstanceName);
			listViewItem.SubItems.Add(performanceCounter.Minimum.ToString());
			listViewItem.SubItems.Add(performanceCounter.Maximum.ToString());
			listViewItem.SubItems.Add(performanceCounter.Average.ToString());
			listViewItem.SubItems.Add((performanceCounter.Maximum - performanceCounter.Minimum).ToString());
			performanceCounterListView.Items.Add(listViewItem);
		}

		if (interval > 0)
		{
			performanceCounterResultsHeaderLabel.Text = string.Format("::: Performance Counter Results (counters: {0}, samples: {1}, interval: {2} ms) :::::::", performanceCounterList.Count, samples, interval);
		}
		else
		{
			performanceCounterResultsHeaderLabel.Text = "::: Performance Counter Results (disabled) :::::::";
		}
	}

	private static void XslTransform(string inputXsltString, string inputXmlFileName, string outputFileName, string outputFormat)
	{
		StringReader xsltInput = new StringReader(inputXsltString);
		XmlTextReader xsltReader = new XmlTextReader(xsltInput);
		XsltSettings settings = new XsltSettings();
		settings.EnableScript = true;
		settings.EnableDocumentFunction = true;

		XslCompiledTransform xsltCompiledTransform = new XslCompiledTransform();
		xsltCompiledTransform.Load(xsltReader, settings, null);

		XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
		xmlWriterSettings.Encoding = new UTF8Encoding(false);
		xmlWriterSettings.Indent = true;
		xmlWriterSettings.ConformanceLevel = ConformanceLevel.Auto;
		xmlWriterSettings.OmitXmlDeclaration = true;

		MemoryStream memoryStream = new MemoryStream();
		XmlWriter writer = XmlWriter.Create(memoryStream, xmlWriterSettings);
		xsltCompiledTransform.Transform(inputXmlFileName, writer);
		writer.Close();

		string xmlString = Encoding.UTF8.GetString(memoryStream.ToArray());

		if (outputFormat == "Xml")
		{
			xmlString = string.Format("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n{0}", xmlString);
		}

		File.WriteAllText(outputFileName, xmlString, Encoding.UTF8);
	}

	private void Initialize(List<ImportTraceDataValue> traceDataList, List<CalculatedPerformanceCounter> performanceCounters, List<RanTaskInfo> ranTaskInfo, ResultTaskCollection resultTaskCollection, ResultInfo resultInfo)
	{
		FireMessageToMainFormEvent("Status: Parsing Results...");

		Text = string.Format("{0} - Results", GenericHelper.ApplicationName);
		GenericHelper.SetSize(this, ConfigHandler.ResultsWindowSize);
		MinimumSize = new Size(700, 500);  // error in .NET
		FillRecentFilesMenu();

		SearchHistoryHandler.LoadItems(objectNameComboBox, "RecentListObjectName");
		SearchHistoryHandler.LoadItems(counterNameComboBox, "RecentListCounterName");
		SearchHistoryHandler.LoadItems(instanceNameComboBox, "RecentListInstanceName");

		descriptionTextBox.GotFocus += DescriptionTextBox_GotFocus;
		shownTextBox.GotFocus += ShownTextBox_GotFocus;

		ImageList imageList = new ImageList();
		imageList.Images.Add(PerformanceTestTool.Properties.Resources.cogtab);
		tabControlEX1.ImageList = imageList;

		tabControlEX1.TabPages.Clear();
		performanceCounterListView.Items.Clear();
		stylesheetComboBox.Items.Clear();

		_listViewColumnSorter = new ListViewColumnSorter();
		performanceCounterListView.ListViewItemSorter = _listViewColumnSorter;

		_performanceCounters = performanceCounters;

		ShowPerformanceCounterResults(performanceCounters, resultTaskCollection.PerformanceCountersSamples, resultTaskCollection.PerformanceCountersSamplingInterval);
		UpdateShownTextBox();

		List<TabPage> tabPages = GetTabPages(traceDataList, resultTaskCollection, ranTaskInfo);
		AddTabPages(tabPages);

		_splitterDistance = GetSplitterDistance();

		_xml = GetXml(resultTaskCollection, resultInfo);
		SetXmlFile();
		XmlHelper.WriteXmlToFile(_xml, _xmlFileName);
	}

	private static int GetSplitterDistance()
	{
		if (Application.RenderWithVisualStyles)
		{
			return 168;
		}
		else
		{
			return 161;
		}
	}

	private void FillRecentFilesMenu()
	{
		RecentFilesHandler.LoadMenuItems(recentFilesToolStripMenuItem, "RecentResultXmlFiles");
		AddEventHandlersToRecentFiles();
	}

	private void SetFileName(string fileName)
	{
		RecentFilesHandler.AddFileName(recentFilesToolStripMenuItem, fileName, "RecentResultXmlFiles");
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
		string fileName = ((ToolStripMenuItem)sender).Text;

		if (File.Exists(fileName))
		{
			ImportResultXml importResultXml = new ImportResultXml(fileName);

			if (importResultXml.GetSuccess())
			{
				SetFileName(fileName);

				Hide();
				Initialize(importResultXml.GetTraceData(), importResultXml.GetCalculatedPerformanceCounters(), importResultXml.GetRanTaskInfo(), importResultXml.GetResultTaskCollection(), importResultXml.GetResultInfo());
				PostInitializeSteps();
			}
		}
		else
		{
			MessageBox.Show("File not found.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}

	private void AddTabPages(List<TabPage> tabPages)
	{
		foreach (TabPage tabPage in tabPages)
		{
			foreach (TabPageUserControl tabPageUserControl in tabPage.Controls)
			{
				tabPageUserControl.SwitchTabEvent += TabControl_SwitchTabEvent;
				tabPageUserControl.SplitterMovedEvent += TabPageUserControl_SplitterMovedEvent;
			}

			tabControlEX1.TabPages.Add(tabPage);
		}
	}

	private static List<ImportTraceDataValue> GetLatencyValues(List<ImportTraceDataValue> traceDataList, ResultTaskCollection resultTaskCollection)
	{
		if (resultTaskCollection.Mode == "Serial")
		{
			return null;
		}

		string firstTaskName = null;

		foreach (ResultTask task in resultTaskCollection.Tasks)
		{
			if (task.Type == TaskHelper.TaskType.Normal)
			{
				firstTaskName = task.Name;
				break;
			}
		}

		List<ImportTraceDataValue> firstTaskLatencyValues = new List<ImportTraceDataValue>();

		long startTime = -1;

		for (int i = 0; i < traceDataList.Count; i++)
		{
			if (traceDataList[i].TaskName == firstTaskName)
			{
				if (traceDataList[i].ColumnName == "Start Time")
				{
					startTime = traceDataList[i].Value;
				}

				if (startTime != -1)
				{
					long totalDuration = startTime;
					totalDuration = totalDuration - ((traceDataList[i].Connection - 1) * resultTaskCollection.TimeBetweenConnections);

					firstTaskLatencyValues.Add(new ImportTraceDataValue(traceDataList[i].TaskName, "Total Duration", totalDuration, traceDataList[i].Connection));

					startTime = -1;
				}
			}
		}

		return firstTaskLatencyValues;
	}

	private static long GetLatencyValueForConnection(List<ImportTraceDataValue> latencyValues, int connection)
	{
		foreach (ImportTraceDataValue latencyValue in latencyValues)
		{
			if (latencyValue.Connection == connection)
			{
				return latencyValue.Value;
			}
		}

		return 0;
	}

	private static void AddTotalDuration(List<ImportTraceDataValue> traceDataList, List<ImportTraceDataValue> latencyValues)
	{
		List<ImportTraceDataValue> newValues = new List<ImportTraceDataValue>();

		long duration = -1;

		for (int i = 0; i < traceDataList.Count; i++)
		{
			if (traceDataList[i].ColumnName == "Duration")
			{
				duration = traceDataList[i].Value;
			}

			if (duration != -1)
			{
				int connection = traceDataList[i].Connection;

				long latency = 0;

				if (connection != 0)
				{
					latency = GetLatencyValueForConnection(latencyValues, connection);
				}

				long totalDuration = duration + latency;

				newValues.Add(new ImportTraceDataValue(traceDataList[i].TaskName, "Latency", latency, traceDataList[i].Connection));
				newValues.Add(new ImportTraceDataValue(traceDataList[i].TaskName, "Total Duration", totalDuration, traceDataList[i].Connection));

				duration = -1;
			}
		}

		for (int i = 0; i < newValues.Count; i++)
		{
			traceDataList.Add(newValues[i]);
		}
	}

	private static List<TabPage> GetTabPages(List<ImportTraceDataValue> traceDataList, ResultTaskCollection resultTaskCollection, List<RanTaskInfo> ranTaskInfo)
	{
		List<ImportTraceDataValue> latencyValues = GetLatencyValues(traceDataList, resultTaskCollection);

		List<TabPage> tabPages = new List<TabPage>();
		List<ImportTraceDataValue> summaryTraceDataList = GetSummaryOfTraceData(traceDataList);

		if (latencyValues != null)
		{
			AddTotalDuration(summaryTraceDataList, latencyValues);
		}

		TabPage summaryTabPage = GetSummaryTab(resultTaskCollection.Connections, summaryTraceDataList);
		tabPages.Add(summaryTabPage);

		for (int i = 0; i < resultTaskCollection.Tasks.Count; i++)
		{
			TabPage tabPage = GetTabPage(resultTaskCollection.Tasks[i], traceDataList, ranTaskInfo, resultTaskCollection.Connections);
			tabPages.Add(tabPage);
		}

		return tabPages;
	}

	private static TabPage GetSummaryTab(int connections, List<ImportTraceDataValue> summaryTraceDataList)
	{
		ResultTask summary = new ResultTask("Summary", "Summary");
		return GetTabPage(summary, summaryTraceDataList, null, connections);
	}

	private static List<ImportTraceDataValue> GetSummaryOfTraceData(List<ImportTraceDataValue> traceDataList)
	{
		List<ImportTraceDataValue> summaryTraceDataList = new List<ImportTraceDataValue>();

		for (int i = 0; i < traceDataList.Count; i++)
		{
			int connection = traceDataList[i].Connection;
			string columnName = traceDataList[i].ColumnName;
			long value = traceDataList[i].Value;

			bool found = false;

			if (connection != 0)
			{
				foreach (ImportTraceDataValue summaryTraceDataValue in summaryTraceDataList)
				{
					if (summaryTraceDataValue.Connection == connection && summaryTraceDataValue.ColumnName == columnName)
					{
						found = true;
						summaryTraceDataValue.Value += value;
						break;
					}
				}

				if (!found)
				{
					summaryTraceDataList.Add(new ImportTraceDataValue("Summary", columnName, value, connection));
				}
			}
		}

		return summaryTraceDataList;
	}

	private static TabPage GetTabPage(ResultTask resultTask, List<ImportTraceDataValue> traceDataList, List<RanTaskInfo> ranTaskInfo, int connections)
	{
		TabPage newTabPage = new TabPage();
		newTabPage.Name = resultTask.Name;
		newTabPage.Text = resultTask.Name;
		newTabPage.ToolTipText = resultTask.Description;
		newTabPage.ImageIndex = 0;

		TabPageUserControl tabPageUserControl = GetNewTabPageUserControl(resultTask, traceDataList, ranTaskInfo, connections);
		newTabPage.Controls.Add(tabPageUserControl);

		return newTabPage;
	}

	private static TabPageUserControl GetNewTabPageUserControl(ResultTask resultTask, List<ImportTraceDataValue> traceDataList, List<RanTaskInfo> ranTaskInfo, int connections)
	{
		TabPageUserControl tabPageUserControl = new TabPageUserControl();
		tabPageUserControl.Dock = DockStyle.Fill;

		for (int i = 0; i < traceDataList.Count; i++)
		{
			if (traceDataList[i].TaskName == resultTask.Name)
			{
				tabPageUserControl.FillTraceDataResults(traceDataList[i].ColumnName, traceDataList[i].Value, traceDataList[i].Connection);
			}
		}

		tabPageUserControl.SetData(resultTask, ranTaskInfo, connections);

		return tabPageUserControl;
	}

	private void DescriptionTextBox_GotFocus(object sender, EventArgs e)
	{
		descriptionTextBox.SelectionStart = 0;
		descriptionTextBox.SelectionLength = 0;
		GenericHelper.HideCaret(descriptionTextBox);
	}

	private void ShownTextBox_GotFocus(object sender, EventArgs e)
	{
		shownTextBox.SelectionStart = 0;
		shownTextBox.SelectionLength = 0;
		GenericHelper.HideCaret(shownTextBox);
	}

	private void SetXmlFile()
	{
		_xmlFileName = string.Format(@"{0}\PerformanceTestToolResult_{1}.xml", GenericHelper.TempPath, Guid.NewGuid());
	}

	private void InitializeXmlWebBrowser()
	{
		xmlWebBrowser.Url = new Uri(_xmlFileName);
	}

	private void LoadStylesheetInWebBrowser()
	{
		Stylesheet stylesheet = GetStylesheet();

		if (stylesheet == null)
		{
			return;
		}

		try
		{
			if (_fileNameInStylesheetWebBrowser != null)
			{
				if (File.Exists(_fileNameInStylesheetWebBrowser))
				{
					File.Delete(_fileNameInStylesheetWebBrowser);
				}
			}

			string transformedXmlFileName = string.Format(@"{0}\PerformanceTestToolResultTransformed_{1}.{2}", GenericHelper.TempPath, Guid.NewGuid(), stylesheet.OutputFormat.ToLower());
			XslTransform(stylesheet.Xslt, _xmlFileName, transformedXmlFileName, stylesheet.OutputFormat);
			_stylesheetWebBrowserUrl = transformedXmlFileName;
			saveStylesheetAsToolStripMenuItem.Enabled = true;
			_fileNameInStylesheetWebBrowser = transformedXmlFileName;
			descriptionTextBox.Text = stylesheet.Description;
		}
		catch (Exception ex)
		{
			MessageBox.Show(string.Format("Error loading stylesheet.\r\n\r\n{0}", ex.Message), GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			_stylesheetWebBrowserUrl = "about:blank";
			_fileNameInStylesheetWebBrowser = null;
			descriptionTextBox.Text = "";
		}

		stylesheetWebBrowser.Url = new Uri(_stylesheetWebBrowserUrl, UriKind.Absolute);
	}

	private Stylesheet GetStylesheet()
	{
		string loadStylesheet;

		if (stylesheetComboBox.SelectedItem == null)
		{
			loadStylesheet = ConfigHandler.DefaultStylesheet;
		}
		else
		{
			loadStylesheet = stylesheetComboBox.SelectedItem.ToString();
		}

		foreach (Stylesheet stylesheet in StylesheetHelper.StylesheetCollection.Stylesheets)
		{
			if (stylesheet.Enabled)
			{
				if (stylesheet.Name == loadStylesheet)
				{
					return stylesheet;
				}
			}
		}

		return null;
	}

	private void TabControl_SwitchTabEvent(Keys key)
	{
		int tabIndex = tabControlEX1.SelectedIndex;

		if (key == Keys.Left)
		{
			if (tabIndex > 0)
			{
				tabIndex--;
			}
		}
		else if (key == Keys.Right)
		{
			if (tabIndex < tabControlEX1.TabPages.Count - 1)
			{
				tabIndex++;
			}
		}

		tabControlEX1.SelectedTab = tabControlEX1.TabPages[tabIndex];
	}

	private void TabPageUserControl_SplitterMovedEvent(int splitterDistance)
	{
		_splitterDistance = splitterDistance;
	}

	private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void ResultsForm_Load(object sender, EventArgs e)
	{
		if (Owner != null)
		{
			Location = new Point(Owner.Location.X + (Owner.Width - Width) / 2, Owner.Location.Y + (Owner.Height - Height) / 2);
		}
	}

	private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
	{
		saveFileDialog1.Filter = "Result Xml files|*.xml|Zip files|*.zip|All files|*.*";
		saveFileDialog1.DefaultExt = "xml";
		saveFileDialog1.FileName = GenericHelper.UnattendedLogFileName;
		SaveFile(_xmlFileName, "xml");
	}

	private void SaveStylesheetAsToolStripMenuItem_Click(object sender, EventArgs e)
	{
		saveFileDialog1.FileName = "";

		if (Path.GetExtension(_fileNameInStylesheetWebBrowser) == ".html")
		{
			saveFileDialog1.Filter = "Html files|*.html|Zip files|*.zip|All files|*.*";
			saveFileDialog1.DefaultExt = "html";
			SaveFile(_fileNameInStylesheetWebBrowser, "html");
		}
		else if (Path.GetExtension(_fileNameInStylesheetWebBrowser) == ".xml")
		{
			saveFileDialog1.Filter = "Xml files|*.xml|Zip files|*.zip|All files|*.*";
			saveFileDialog1.DefaultExt = "xml";
			SaveFile(_fileNameInStylesheetWebBrowser, "xml");
		}
	}

	private void SaveFile(string fileToSave, string extension)
	{
		DialogResult result = saveFileDialog1.ShowDialog();

		if (result.ToString() == "OK")
		{
			Application.DoEvents();
			string e = Path.GetExtension(saveFileDialog1.FileName);

			if (e != null)
			{
				if (e.ToLower() == ".html" || e.ToLower() == ".xml")
				{
					File.Copy(fileToSave, saveFileDialog1.FileName, true);
				}
				else if (e.ToLower() == ".zip")
				{
					string tempFileName = string.Format("{0}.{1}", Path.GetFileNameWithoutExtension(saveFileDialog1.FileName), extension);
					string tempFileNameAndPath = string.Format(@"{0}\{1}", GenericHelper.TempPath, tempFileName);
					File.Copy(fileToSave, tempFileNameAndPath, true);
					Compression.CompressFile(tempFileNameAndPath, saveFileDialog1.FileName);
					File.Delete(tempFileNameAndPath);
				}
				else
				{
					MessageBox.Show("Please enter a valid file extension.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}
	}

	private static void AddServerInfoToXml(StringBuilder stringBuilder, ResultInfo resultInfo)
	{
		stringBuilder.Append("<server>");
		stringBuilder.Append(string.Format("<info name=\"SQL Server\" value=\"{0}\" />", System.Security.SecurityElement.Escape(resultInfo.SqlServer)));
		stringBuilder.Append(string.Format("<info name=\"Operating System\" value=\"{0}\" />", System.Security.SecurityElement.Escape(resultInfo.OsVersion)));
		stringBuilder.Append(string.Format("<info name=\"Logical CPU Count\" value=\"{0}\" />", resultInfo.LogicalCpuCount));
		stringBuilder.Append(string.Format("<info name=\"Physical CPU Count\" value=\"{0}\" />", resultInfo.PhysicalCpuCount));
		stringBuilder.Append(string.Format("<info name=\"Physical Memory\" value=\"{0}\" />", resultInfo.PhysicalMemory));
		stringBuilder.Append(string.Format("<info name=\"SQL Server Version\" value=\"{0}\" />", System.Security.SecurityElement.Escape(resultInfo.SqlServerVersion)));
		stringBuilder.Append(string.Format("<info name=\"SQL Server Max Memory\" value=\"{0}\" />", resultInfo.MaxMemory));
		stringBuilder.Append("</server>");
	}

	private void AddTraceToXml(StringBuilder stringBuilder, ResultTask resultTask)
	{
		stringBuilder.Append("<data>");

		ListView traceDataResultsListView = GetTraceDataResults(resultTask.Name);

		foreach (ListViewItem item in traceDataResultsListView.Items)
		{
			string name = item.SubItems[0].Text;
			string minimum = item.SubItems[1].Text;
			string maximum = item.SubItems[2].Text;
			string average = item.SubItems[3].Text;
			string sum = item.SubItems[4].Text;

			stringBuilder.Append(string.Format("<value name=\"{0}\" minimum=\"{1}\" maximum=\"{2}\" average=\"{3}\" sum=\"{4}\" />", System.Security.SecurityElement.Escape(name), minimum, maximum, average, sum));
		}

		AddBasedOnTraceToXml(stringBuilder, resultTask.Name);

		stringBuilder.Append("</data>");
	}

	private void AddBasedOnTraceToXml(StringBuilder stringBuilder, string taskName)
	{
		stringBuilder.Append("<connectionValues>");

		ListView basedOnTraceDataResultsListView = GetBasedOnTraceDataResults(taskName);

		foreach (ListViewItem item in basedOnTraceDataResultsListView.Items)
		{
			stringBuilder.Append("<value ");

			for (int i = 0; i < item.SubItems.Count; i++)
			{
				string name = basedOnTraceDataResultsListView.Columns[i].Text.Replace(" ", "").ToLower();
				string value = item.SubItems[i].Text;

				stringBuilder.Append(string.Format("{0}=\"{1}\" ", name, System.Security.SecurityElement.Escape(value)));
			}

			stringBuilder.Append("/>");
		}

		stringBuilder.Append("</connectionValues>");
	}

	private void AddPerformanceCountersToXml(StringBuilder stringBuilder, int performanceCounterSamples, int performanceCountersSamplingInterval)
	{
		stringBuilder.Append(string.Format("<performanceCounters samples=\"{0}\" interval=\"{1}\">", performanceCounterSamples, performanceCountersSamplingInterval));

		string previousObjectName = "";
		string previousCounterName = "";

		foreach (ListViewItem item in performanceCounterListView.Items)
		{
			string objectName = item.SubItems[0].Text;
			string counterName = item.SubItems[1].Text;
			string instanceName = item.SubItems[2].Text;
			string minimum = item.SubItems[3].Text;
			string maximum = item.SubItems[4].Text;
			string average = item.SubItems[5].Text;

			if (counterName != previousCounterName)
			{
				if (previousCounterName != "")
				{
					stringBuilder.Append("</counter>");
				}
			}

			if (objectName != previousObjectName)
			{
				if (previousObjectName != "")
				{
					stringBuilder.Append("</object>");
				}
			}

			if (objectName != previousObjectName)
			{
				stringBuilder.Append(string.Format("<object name=\"{0}\">", System.Security.SecurityElement.Escape(objectName)));
				previousObjectName = objectName;
			}

			if (counterName != previousCounterName)
			{
				stringBuilder.Append(string.Format("<counter name=\"{0}\">", System.Security.SecurityElement.Escape(counterName)));
				previousCounterName = counterName;
			}

			stringBuilder.Append(string.Format("<value instanceName=\"{0}\" minimum=\"{1}\" maximum=\"{2}\" average=\"{3}\" />", System.Security.SecurityElement.Escape(instanceName), minimum, maximum, average));
		}

		if (performanceCounterListView.Items.Count > 0)
		{
			stringBuilder.Append("</counter></object>");
		}

		stringBuilder.Append("</performanceCounters>");
	}

	private void AddTasksToXml(StringBuilder stringBuilder, ResultTaskCollection resultTaskCollection)
	{
		stringBuilder.Append(string.Format("<tasks description=\"{0}\" connections=\"{1}\" timeBetweenConnections=\"{2}\" mode=\"{3}\" usePooling=\"{4}\" minPooling=\"{5}\" maxPooling=\"{6}\">", System.Security.SecurityElement.Escape(resultTaskCollection.Description), resultTaskCollection.Connections, resultTaskCollection.TimeBetweenConnections, resultTaskCollection.Mode, resultTaskCollection.UsePooling, resultTaskCollection.MinPooling, resultTaskCollection.MaxPooling));

		AddSummaryToXml(stringBuilder);

		foreach (ResultTask resultTask in resultTaskCollection.Tasks)
		{
			stringBuilder.Append(string.Format("<task name=\"{0}\" type=\"{1}\" description=\"{2}\" delayAfterCompletion=\"{3}\" firstConnectionStartTime=\"{4}\">", System.Security.SecurityElement.Escape(resultTask.Name), resultTask.Type, System.Security.SecurityElement.Escape(resultTask.Description), resultTask.DelayAfterCompletion, GenericHelper.DateTimeToString(resultTask.FirstConnectionStartTime)));
			AddTraceToXml(stringBuilder, resultTask);
			stringBuilder.Append("</task>");
		}

		stringBuilder.Append("</tasks>");
	}

	private void AddSummaryToXml(StringBuilder stringBuilder)
	{
		stringBuilder.Append("<summary>");

		ListView traceDataResultsListView = GetTraceDataResults("Summary");

		foreach (ListViewItem item in traceDataResultsListView.Items)
		{
			string name = item.SubItems[0].Text;
			string minimum = item.SubItems[1].Text;
			string maximum = item.SubItems[2].Text;
			string average = item.SubItems[3].Text;
			string sum = item.SubItems[4].Text;

			stringBuilder.Append(string.Format("<value name=\"{0}\" minimum=\"{1}\" maximum=\"{2}\" average=\"{3}\" sum=\"{4}\" />", System.Security.SecurityElement.Escape(name), minimum, maximum, average, sum));
		}

		AddBasedOnTraceToXml(stringBuilder, "Summary");

		stringBuilder.Append("</summary>");
	}

	private string GetXml(ResultTaskCollection resultTaskCollection, ResultInfo resultInfo)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
		stringBuilder.Append(string.Format("<result runTime=\"{1}\" version=\"{0}\" executionTime=\"{2}\">", resultInfo.Version, GenericHelper.DateTimeToString(resultInfo.RunTime), resultInfo.TotalExecutionTime));

		AddServerInfoToXml(stringBuilder, resultInfo);
		AddTasksToXml(stringBuilder, resultTaskCollection);
		AddPerformanceCountersToXml(stringBuilder, resultTaskCollection.PerformanceCountersSamples, resultTaskCollection.PerformanceCountersSamplingInterval);

		stringBuilder.Append("</result>");
		return stringBuilder.ToString();
	}

	private ListView GetBasedOnTraceDataResults(string taskName)
	{
		foreach (TabPage tabPage in tabControlEX1.TabPages)
		{
			if (tabPage.Name == taskName)
			{
				foreach (TabPageUserControl control in tabPage.Controls)
				{
					return control.GetBasedOnResultsFormListView();
				}
			}
		}

		return null;
	}

	private ListView GetTraceDataResults(string taskName)
	{
		foreach (TabPage tabPage in tabControlEX1.TabPages)
		{
			if (tabPage.Name == taskName)
			{
				foreach (TabPageUserControl control in tabPage.Controls)
				{
					return control.GetTraceDataResults();
				}
			}
		}

		return null;
	}

	private void ResultsForm_Resize(object sender, EventArgs e)
	{
		if (Width < MinimumSize.Width || Width == 0)
		{
			return;
		}

		ConfigHandler.ResultsWindowSize = string.Format("{0}; {1}", Size.Width, Size.Height);
		ConfigHandler.SaveConfig();
	}

	private void ResultsForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		Hide();
		Application.DoEvents();
		Cleanup();
	}

	private void SearchToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (tabControlEX2.SelectedTab.Text == "Xml")
		{
			xmlWebBrowser.Focus();
		}
		else if (tabControlEX2.SelectedTab.Text == "Stylesheet")
		{
			stylesheetWebBrowser.Focus();
		}

		SendKeys.Send("^{f}");
	}

	private void EnableWebBrowserMenus()
	{
		bool anythingLoaded = false;

		if (tabControlEX2.SelectedTab.Text == "Xml")
		{
			anythingLoaded = true;
		}
		else if (tabControlEX2.SelectedTab.Text == "Stylesheet")
		{
			if (_stylesheetWebBrowserUrl != null && _stylesheetWebBrowserUrl != "about:blank")
			{
				anythingLoaded = true;
				saveStylesheetAsToolStripMenuItem.Enabled = true;
			}
			else
			{
				saveStylesheetAsToolStripMenuItem.Enabled = false;
			}
		}

		if (anythingLoaded)
		{
			searchToolStripMenuItem.Enabled = true;
			printToolStripMenuItem.Enabled = true;
			printPreviewToolStripMenuItem.Enabled = true;
			pageSetupToolStripMenuItem.Enabled = true;
		}
		else
		{
			searchToolStripMenuItem.Enabled = false;
			printToolStripMenuItem.Enabled = false;
			printPreviewToolStripMenuItem.Enabled = false;
			pageSetupToolStripMenuItem.Enabled = false;
		}
	}

	private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (tabControlEX2.SelectedTab.Text == "Xml")
		{
			xmlWebBrowser.ShowPrintDialog();
		}
		else if (tabControlEX2.SelectedTab.Text == "Stylesheet")
		{
			stylesheetWebBrowser.ShowPrintDialog();
		}
	}

	private void PrintPreviewToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (tabControlEX2.SelectedTab.Text == "Xml")
		{
			xmlWebBrowser.ShowPrintPreviewDialog();
		}
		else if (tabControlEX2.SelectedTab.Text == "Stylesheet")
		{
			stylesheetWebBrowser.ShowPrintPreviewDialog();
		}
	}

	private void PageSetupToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (tabControlEX2.SelectedTab.Text == "Xml")
		{
			xmlWebBrowser.ShowPageSetupDialog();
		}
		else if (tabControlEX2.SelectedTab.Text == "Stylesheet")
		{
			stylesheetWebBrowser.ShowPageSetupDialog();
		}
	}

	private void FillStylesheets()
	{
		_dontInitiateStylesheetBrowser = true;

		foreach (Stylesheet stylesheet in StylesheetHelper.StylesheetCollection.Stylesheets)
		{
			if (stylesheet.Enabled)
			{
				stylesheetComboBox.Items.Add(stylesheet.Name);

				if (stylesheet.Name == ConfigHandler.DefaultStylesheet)
				{
					stylesheetComboBox.SelectedItem = stylesheet.Name;
				}
			}
		}

		_dontInitiateStylesheetBrowser = false;
	}

	private void StylesheetComboBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!_dontInitiateStylesheetBrowser)
		{
			LoadStylesheetInWebBrowser();
			EnableWebBrowserMenus();
		}
	}

	private void DescriptionTextBox_Enter(object sender, EventArgs e)
	{
		descriptionTextBox.SelectionStart = 0;
		descriptionTextBox.SelectionLength = 0;
		GenericHelper.HideCaret(descriptionTextBox);
	}

	private void TabControlEX2_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (tabControlEX2.SelectedTab.Text == "Data" || tabControlEX2.SelectedTab.Text == "Performance Counters")
		{
			searchToolStripMenuItem.Enabled = false;
			printToolStripMenuItem.Enabled = false;
			printPreviewToolStripMenuItem.Enabled = false;
			pageSetupToolStripMenuItem.Enabled = false;
		}
		else if (tabControlEX2.SelectedTab.Text == "Xml")
		{
			EnableWebBrowserMenus();
		}
		else if (tabControlEX2.SelectedTab.Text == "Stylesheet")
		{
			EnableWebBrowserMenus();
		}

		tabControlEX2.Select();
	}

	private void TabControlEX1_SelectedIndexChanged(object sender, EventArgs e)
	{
		Dotnetrix.Controls.TabControlEX tabControl = (Dotnetrix.Controls.TabControlEX)sender;

		if (tabControl.TabPages.Count > 0)
		{
			TabPage tabPage = ((TabControl)sender).SelectedTab;

			foreach (TabPageUserControl control in tabPage.Controls)
			{
				control.SetSplitterDistance(_splitterDistance);
			}
		}
	}

	private void OpenResultXmlToolStripMenuItem_Click(object sender, EventArgs e)
	{
		DialogResult result = openFileDialog1.ShowDialog();

		if (result.ToString() == "OK")
		{
			Application.DoEvents();
			ImportResultXml importResultXml = new ImportResultXml(openFileDialog1.FileName);

			if (importResultXml.GetSuccess())
			{
				SetFileName(openFileDialog1.FileName);

				Hide();
				Initialize(importResultXml.GetTraceData(), importResultXml.GetCalculatedPerformanceCounters(), importResultXml.GetRanTaskInfo(), importResultXml.GetResultTaskCollection(), importResultXml.GetResultInfo());
				PostInitializeSteps();
			}
		}
	}

	private void DescriptionTextBox_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.Control && e.KeyCode == Keys.A)
		{
			descriptionTextBox.SelectAll();
		}
	}

	private void PerformanceCounterListView_ColumnClick(object sender, ColumnClickEventArgs e)
	{
		SortPerformanceCounterListView(e.Column);
	}

	private void SortPerformanceCounterListView(int columnIndex)
	{
		if (columnIndex == _listViewColumnSorter.SortColumn)
		{
			if (_listViewColumnSorter.Order == SortOrder.Ascending)
			{
				_listViewColumnSorter.Order = SortOrder.Descending;
			}
			else
			{
				_listViewColumnSorter.Order = SortOrder.Ascending;
			}
		}
		else
		{
			_listViewColumnSorter.SortColumn = columnIndex;
			_listViewColumnSorter.Order = SortOrder.Ascending;
		}

		if (columnIndex <= 2)
		{
			_listViewColumnSorter.SortByDecimalValue = false;
		}
		else
		{
			_listViewColumnSorter.SortByDecimalValue = true;
		}

		performanceCounterListView.Sort();
	}

	private void ApplyFilterButton_Click(object sender, EventArgs e)
	{
		ApplyFilter(false);
	}

	private void ClearButton_Click(object sender, EventArgs e)
	{
		ApplyFilter(true);
	}

	private void ApplyFilter(bool reset)
	{
		Control activeControl = ActiveControl;

		applyFilterButton.Enabled = false;
		clearButton.Enabled = false;
		removeAllZeroColumnsCheckBox.Enabled = false;
		removeZeroDeltaCheckBox.Enabled = false;
		objectNameComboBox.BackColor = Color.Gainsboro;
		counterNameComboBox.BackColor = Color.Gainsboro;
		instanceNameComboBox.BackColor = Color.Gainsboro;
		objectNameComboBox.Enabled = false;
		counterNameComboBox.Enabled = false;
		instanceNameComboBox.Enabled = false;
		Application.DoEvents();

		string objectName = objectNameComboBox.Text.Trim().ToLower();
		string counterName = counterNameComboBox.Text.Trim().ToLower();
		string instanceName = instanceNameComboBox.Text.Trim().ToLower();

		SearchHistoryHandler.AddItem(objectNameComboBox, objectNameComboBox.Text, "RecentListObjectName");
		SearchHistoryHandler.AddItem(counterNameComboBox, counterNameComboBox.Text, "RecentListCounterName");
		SearchHistoryHandler.AddItem(instanceNameComboBox, instanceNameComboBox.Text, "RecentListInstanceName");

		if (reset)
		{
			objectName = "";
			counterName = "";
			instanceName = "";
			objectNameComboBox.Text = "";
			counterNameComboBox.Text = "";
			instanceNameComboBox.Text = "";
			removeAllZeroColumnsCheckBox.Checked = false;
			removeZeroDeltaCheckBox.Checked = false;
		}

		List<CalculatedPerformanceCounter> filteredPerformanceCounters = FilterHelper.FilterPerformanceCounters(_performanceCounters, objectName, counterName, instanceName);

		performanceCounterListView.Items.Clear();

		foreach (CalculatedPerformanceCounter performanceCounter in filteredPerformanceCounters)
		{
			ListViewItem listViewItem = new ListViewItem();
			listViewItem.Text = performanceCounter.ObjectName;
			listViewItem.SubItems.Add(performanceCounter.CounterName);
			listViewItem.SubItems.Add(performanceCounter.InstanceName);
			listViewItem.SubItems.Add(performanceCounter.Minimum.ToString());
			listViewItem.SubItems.Add(performanceCounter.Maximum.ToString());
			listViewItem.SubItems.Add(performanceCounter.Average.ToString());
			listViewItem.SubItems.Add((performanceCounter.Maximum - performanceCounter.Minimum).ToString());

			bool add = true;

			if (removeAllZeroColumnsCheckBox.Checked)
			{
				if (performanceCounter.Minimum == 0 && performanceCounter.Maximum == 0 && performanceCounter.Average == 0)
				{
					add = false;
				}
			}

			if (removeZeroDeltaCheckBox.Checked)
			{
				if (performanceCounter.Maximum - performanceCounter.Minimum == 0)
				{
					add = false;
				}
			}

			if (add)
			{
				performanceCounterListView.Items.Add(listViewItem);
			}
		}

		UpdateShownTextBox();

		applyFilterButton.Enabled = true;
		clearButton.Enabled = true;
		removeAllZeroColumnsCheckBox.Enabled = true;
		removeZeroDeltaCheckBox.Enabled = true;
		objectNameComboBox.BackColor = Color.WhiteSmoke;
		counterNameComboBox.BackColor = Color.WhiteSmoke;
		instanceNameComboBox.BackColor = Color.WhiteSmoke;
		objectNameComboBox.Enabled = true;
		counterNameComboBox.Enabled = true;
		instanceNameComboBox.Enabled = true;

		activeControl.Focus();
	}

	private void UpdateShownTextBox()
	{
		shownTextBox.Text = string.Format("Shown: {0}", performanceCounterListView.Items.Count);
	}

	private void ShownTextBox_Enter(object sender, EventArgs e)
	{
		shownTextBox.SelectionStart = 0;
		shownTextBox.SelectionLength = 0;
		GenericHelper.HideCaret(shownTextBox);
	}

	private void RecentFilesToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
	{
		FillRecentFilesMenu();
	}

	private void ObjectNameComboBox_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Enter)
		{
			ApplyFilter(false);
		}
	}

	private void CounterNameComboBox_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Enter)
		{
			ApplyFilter(false);
		}
	}

	private void InstanceNameComboBox_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Enter)
		{
			ApplyFilter(false);
		}
	}

	private void ResultsForm_DragDrop(object sender, DragEventArgs e)
	{
		string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

		if (files != null)
		{
			if (files.Length == 1)
			{
				ImportResultXml importResultXml = new ImportResultXml(files[0]);

				if (importResultXml.GetSuccess())
				{
					SetFileName(files[0]);

					Hide();
					Initialize(importResultXml.GetTraceData(), importResultXml.GetCalculatedPerformanceCounters(), importResultXml.GetRanTaskInfo(), importResultXml.GetResultTaskCollection(), importResultXml.GetResultInfo());
					PostInitializeSteps();
				}
			}
		}
	}

	private void ResultsForm_DragOver(object sender, DragEventArgs e)
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
}
