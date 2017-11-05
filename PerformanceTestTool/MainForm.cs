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
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;
using ThreadState = System.Threading.ThreadState;

public partial class MainForm : Form
{
	private DatabaseOperation _databaseOperation;
	private bool _running;
	private readonly Stopwatch _sw = new Stopwatch();
	private BackgroundWorker _performanceCountersSamplingWorker;
	private readonly List<PerformanceCounters> _performanceCounters = new List<PerformanceCounters>();
	private bool _stopTaskRun;
	private bool _unattended;
	private string _unattendedLogDir;
	private readonly bool _includeLog;
	private readonly string _unattendedSmtp;
	private readonly string _unattendedEmailTo;
	private readonly string _unattendedSubject;
	private readonly string _unattendedConnectionString;
	private readonly string _unattendedTraceFileDirectory;
	private readonly List<RunTaskInfo> _runTaskInfo = new List<RunTaskInfo>();
	private readonly bool _compression;
	private readonly bool _includeStylesheets;
	private readonly string _unattendedTempDir;
	private readonly bool _removeLogFiles;
	private int _connectionsCompleted;
	private int _connectionsStarted;
	private bool _traceStarted;
	private AutoResetEvent _connectionsFinishedEvent;
	private BackgroundWorker _worker;
	private int _returnCode;
	private readonly List<Thread> _threadList = new List<Thread>();
	private readonly ResultInfo _resultInfo = new ResultInfo();
	private bool _loaded;
	private CheckForUpdatesForm _checkForUpdatesForm;
	private BackgroundWorker _checkTraceFileDirWorker;

	public MainForm()
	{
		InitializeComponent();
		Initialize();
		_loaded = true;
	}

	public MainForm(bool includeLog, string smtp, string emailTo, string subject, bool compression, bool includeStylesheets, string logDir, bool removeLogFiles, string errorLogFileName, string connectionString, string traceFileDirectory)
	{
		_unattended = true;
		GenericHelper.UnattendedErrorLogFileName = errorLogFileName;

		_unattendedTempDir = string.Format(@"{0}\{1}", GenericHelper.TempPath, Guid.NewGuid());
		Directory.CreateDirectory(_unattendedTempDir);

		_unattendedLogDir = logDir;
		_includeLog = includeLog;
		_unattendedSmtp = smtp;
		_unattendedEmailTo = emailTo;
		_unattendedSubject = subject;
		_compression = compression;
		_includeStylesheets = includeStylesheets;
		_removeLogFiles = removeLogFiles;
		_unattendedConnectionString = connectionString;
		_unattendedTraceFileDirectory = traceFileDirectory;

		InitializeComponent();

		bool success = Initialize();

		if (success)
		{
			CheckTraceFileDir();
		}
	}

	public int GetReturnCode()
	{
		return _returnCode;
	}

	private bool Initialize()
	{
		ConfigHandler.LoadConfig();

		CheckForUpdates();

		SessionHelper.LoadLastSession();

		Process.GetCurrentProcess().ProcessorAffinity = (IntPtr)1;

		Text = GenericHelper.ApplicationName;
		startedLabel.Text = "";
		startedLabel.Visible = true;
		completedLabel.Text = "";
		completedLabel.Visible = true;
		GenericHelper.SetSize(this, ConfigHandler.MainWindowSize);
		MinimumSize = new Size(700, 500);  // error in .NET
		FillRecentFilesMenu();
		SetTaskCollectionDescription();

		if (!_unattended)
		{
			InitializeDatabaseOperation();
			ConfigHandler.SetTraceFileDirectory();
		}
		else
		{
			if (_unattendedConnectionString != null)
			{
				ConfigHandler.ConnectionString = _unattendedConnectionString;
			}

			_databaseOperation = new DatabaseOperation();
			_databaseOperation.InitializeDal(ConfigHandler.ConnectionString);

			if (_unattendedTraceFileDirectory != null)
			{
				ConfigHandler.TraceFileDirectory = _unattendedTraceFileDirectory;
			}
			else
			{
				ConfigHandler.SetTraceFileDirectory();
			}
		}

		ConfigHandler.SaveConfig();

		if (!Convert.ToBoolean(ConfigHandler.OfflineMode) && !_databaseOperation.Connected)
		{
			return false;
		}

		SetInfoLabels();
		SetConnectedToLabel();
		SetTracingFunctionality();
		SetRunButton();

		taskCollectionDescriptionTextBox.GotFocus += TaskCollectionDescriptionTextBox_GotFocus;
		tasksTextBox.GotFocus += TasksTextBox_GotFocus;

		return true;
	}

	private void CheckForUpdates()
	{
		if (!_unattended && Convert.ToBoolean(ConfigHandler.CheckForUpdatesOnStart))
		{
			_checkForUpdatesForm = new CheckForUpdatesForm();
			_checkForUpdatesForm.UpdateCheckCompleteEvent += UpdateCheckCompleteEvent;
			_checkForUpdatesForm.CheckForUpdates();
		}
	}

	private void UpdateCheckCompleteEvent(string errorMessage, Version version, bool anyUpdates, bool anyErrors)
	{
		if (!anyErrors && anyUpdates && !_running)
		{
			_checkForUpdatesForm.ShowDialog();

			if (_checkForUpdatesForm.GetForceQuit())
			{
				Environment.Exit(0);
			}
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

				ResultsForm form = new ResultsForm();
				form.MessageToMainFormEvent += Form_MessageToMainFormEvent;
				form.SetData(importResultXml.GetTraceData(), importResultXml.GetCalculatedPerformanceCounters(), importResultXml.GetRanTaskInfo(), importResultXml.GetResultTaskCollection(), importResultXml.GetResultInfo());
				form.Show();
			}
		}
		else
		{
			MessageBox.Show("File not found.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}

	private void SetTaskCollectionDescription()
	{
		taskCollectionDescriptionTextBox.Text = TaskHelper.TaskCollection.Description;
		UpdateTasksTextBox();
	}

	private void SetInfoLabels()
	{
		if (Convert.ToBoolean(ConfigHandler.OfflineMode))
		{
			logicalCPULabel.Text = "";
			physicalCPULabel.Text = "";
			ramLabel.Text = "";
			versionLabel.Text = "";
			osLabel.Text = "";
			maxMemoryLabel.Text = "";
		}
		else
		{
			DataTable dataTable = _databaseOperation.GetSqlServerInfo();

			if (dataTable != null)
			{
				logicalCPULabel.Text = dataTable.Rows[0]["Logical CPU Count"].ToString();
				physicalCPULabel.Text = dataTable.Rows[0]["Physical CPU Count"].ToString();
				ramLabel.Text = dataTable.Rows[0]["Physical Memory (MB)"].ToString();
				string[] osInformation = GenericHelper.GetOsInformation(dataTable.Rows[0]["version"].ToString().Split('\n'));
				versionLabel.Text = osInformation[0];
				osLabel.Text = osInformation[1];

				int maxMemory = Convert.ToInt32(dataTable.Rows[0]["ram"]);

				if (maxMemory != 2147483647)
				{
					maxMemoryLabel.Text = maxMemory.ToString();
				}
				else
				{
					maxMemoryLabel.Text = "Not set";
				}
			}
			else
			{
				logicalCPULabel.Text = "";
				physicalCPULabel.Text = "";
				ramLabel.Text = "";
				versionLabel.Text = "";
				osLabel.Text = "";
				maxMemoryLabel.Text = "";
			}

			_resultInfo.LogicalCpuCount = logicalCPULabel.Text;
			_resultInfo.PhysicalCpuCount = physicalCPULabel.Text;
			_resultInfo.PhysicalMemory = ramLabel.Text;
			_resultInfo.MaxMemory = maxMemoryLabel.Text;
			_resultInfo.SqlServerVersion = versionLabel.Text;
			_resultInfo.OsVersion = osLabel.Text;
		}
	}

	private void SetRunButton()
	{
		if (Convert.ToBoolean(ConfigHandler.OfflineMode))
		{
			runTasksButton.Enabled = false;
			startToolStripMenuItem.Enabled = false;

			startToolStripMenuItem.Text = "&Start (offline)";
		}
		else
		{
			startToolStripMenuItem.Text = "&Start";
			bool ready = false;

			if (TaskHelper.TaskCollection.Tasks.Count > 0)
			{
				foreach (Task task in TaskHelper.TaskCollection.Tasks)
				{
					if (task.Enabled)
					{
						ready = true;
						break;
					}
				}
			}

			runTasksButton.Enabled = ready;
			startToolStripMenuItem.Enabled = ready;
		}
	}

	private void SetTracingFunctionality()
	{
		if (ConfigHandler.OfflineMode == "True")
		{
			return;
		}

		if (ConfigHandler.UseExtendedEvents == "")
		{
			if (_databaseOperation.GetSqlServerVersion() >= 11)
			{
				ConfigHandler.UseExtendedEvents = "True";
			}
			else
			{
				ConfigHandler.UseExtendedEvents = "False";
			}
		}
		else
		{
			if (_databaseOperation.GetSqlServerVersion() < 11)
			{
				ConfigHandler.UseExtendedEvents = "False";
			}
		}
	}

	private void SetConnectedToLabel()
	{
		if (Convert.ToBoolean(ConfigHandler.OfflineMode))
		{
			sqlServerHeaderLabel.Text = "::: SQL Server (offline) :::::::";
		}
		else
		{
			string server = _databaseOperation.GetDataSource();
			sqlServerHeaderLabel.Text = string.Format("::: SQL Server ({0}) :::::::", server);
			_resultInfo.SqlServer = server;
		}
	}

	private void InitializeDatabaseOperation()
	{
		ConnectionDialogForm form = new ConnectionDialogForm(_databaseOperation);
		form.ShowDialog();

		Application.DoEvents();

		if (!form.GetOkButtonClicked())
		{
			Environment.Exit(-1);
		}

		if (!Convert.ToBoolean(ConfigHandler.OfflineMode))
		{
			bool success = form.ConnectionChanged;

			if (success)
			{
				_databaseOperation = form.GetDatabaseOperation();
			}
			else
			{
				if (_databaseOperation == null)
				{
					Environment.Exit(-1);
				}
			}
		}
	}

	private void ChangeConnectionToolStripMenuItem_Click(object sender, EventArgs e)
	{
		ConnectionDialogForm form = new ConnectionDialogForm(_databaseOperation);
		form.ShowInTaskbar = false;
		form.Text = string.Format("{0} - Change Connection", GenericHelper.ApplicationName);
		form.ShowDialog();

		Application.DoEvents();

		if (form.ConnectionChanged)
		{
			if (!Convert.ToBoolean(ConfigHandler.OfflineMode))
			{
				_databaseOperation = form.GetDatabaseOperation();
			}

			ResetLayout();
			SetInfoLabels();
			SetConnectedToLabel();
			SetTracingFunctionality();
			SetRunButton();
		}
	}

	private void Exit()
	{
		if (_databaseOperation != null)
		{
			_databaseOperation.Dispose();
		}
	}

	private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void PreferencesToolStripMenuItem_Click(object sender, EventArgs e)
	{
		PreferencesForm form = new PreferencesForm(_databaseOperation);
		form.ShowDialog();

		if (form.ResetLayout())
		{
			GenericHelper.SetSize(this, ConfigHandler.MainWindowSize);
			StartPosition = FormStartPosition.CenterScreen;
		}
	}

	private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
	{
		AboutForm form = new AboutForm();
		form.ShowDialog();
	}

	private void RunTasksButton_Click(object sender, EventArgs e)
	{
		Start();
	}

	private void Start()
	{
		_unattended = false;
		_loaded = true;

		if (runTasksButton.Text == "Start")
		{
			if (Dal.DBConnectionStillActive())
			{
				CheckTraceFileDir();
			}
		}
		else
		{
			DialogResult result = MessageBox.Show("Performance Test in progress.\r\n\r\nStop operation?", GenericHelper.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

			if (result.ToString() == "Yes")
			{
				DoStop();
			}
		}
	}

	private void DoStop()
	{
		runTasksButton.Enabled = false;
		_stopTaskRun = true;
		SetConnectionsFinishedEvent();

		foreach (Thread thread in _threadList)
		{
			if (thread != null && thread.ThreadState != ThreadState.AbortRequested)
			{
				thread.Abort();
			}
		}

		runTasksButton.Enabled = true;
	}

	private void ResetLayout()
	{
		startedProgressBar.Maximum = TaskHelper.TaskCollection.Connections;
		startedProgressBar.Value = 0;
		completedProgressBar.Maximum = TaskHelper.TaskCollection.Connections;
		completedProgressBar.Value = 0;
		startedLabel.Text = "";
		completedLabel.Text = "";
		timeElapsedLabel.Text = "00:00:00";
		statusLabel.Text = "Status: Idle";
	}

	private void CheckTraceFileDir()
	{
		runTasksButton.Enabled = false;
		DisableItems();
		statusLabel.Text = "Status: Checking access rights...";

		_checkTraceFileDirWorker = new BackgroundWorker();
		_checkTraceFileDirWorker.DoWork += CheckTraceFileDirWorker_DoWork;
		_checkTraceFileDirWorker.RunWorkerCompleted += CheckTraceFileDirWorker_RunWorkerCompleted;

		_checkTraceFileDirWorker.RunWorkerAsync();
	}

	private void CheckTraceFileDirWorker_DoWork(object sender, DoWorkEventArgs e)
	{
		GenericHelper.ShowErrorMessageForm = false;

		bool success = BeginTracing();

		if (success)
		{
			try
			{
				string[] traceFiles = Directory.GetFiles(ConfigHandler.TraceFileDirectory, string.Format("{0}*.*", TaskHelper.TraceFileName));

				if (traceFiles.Length == 0 || !File.Exists(traceFiles[0]))
				{
					success = false;
					MessageBox.Show("Insufficient rights to Trace File Directory.\r\n\r\nIf you are connecting to a remote SQL Server, please use UNC path and make sure the server has write access to your network share.\r\n\r\nTrace File Directory can be set in the Preferences menu.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			catch (IOException)
			{
				success = false;
				MessageBox.Show("Trace File Directory not found.\r\n\r\nTrace File Directory can be set in the Preferences menu.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		_databaseOperation.StopDeleteTrace();
		TraceFileHandler.DeleteTraceFile(false, _databaseOperation);

		e.Result = success;
	}

	private void CheckTraceFileDirWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		statusLabel.Text = "Status: Idle";
		runTasksButton.Enabled = true;

		bool success = Convert.ToBoolean(e.Result);

		if (success)
		{
			DoStart();
		}
		else
		{
			EnableItems();
		}
	}

	private void DoStart()
	{
		runTasksButton.Text = "Stop";
		TaskHelper.CreateNewGuid();
		_connectionsStarted = 0;
		_connectionsCompleted = 0;
		_running = true;
		_stopTaskRun = false;
		GenericHelper.ShowErrorMessageForm = true;
		ResetLayout();
		executionTimeTimer.Start();
		_sw.Reset();
		_sw.Start();

		_threadList.Clear();
		_performanceCounters.Clear();
		_runTaskInfo.Clear();
		_connectionsFinishedEvent = new AutoResetEvent(false);

		if (TaskHelper.TaskCollection.PerformanceCountersSamplingInterval > 0)
		{
			InitializePerformanceCountersSamplingWorker();
		}

		bool success = PrepareRunTasks();

		if (success)
		{
			_worker = new BackgroundWorker();
			_worker.WorkerReportsProgress = true;
			_worker.DoWork += Worker_DoWork;
			_worker.ProgressChanged += Worker_ProgressChanged;
			_worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

			_worker.RunWorkerAsync();
		}
		else
		{
			_running = false;
			EnableItems();

			executionTimeTimer.Stop();
			_sw.Stop();
		}
	}

	private void Worker_DoWork(object sender, DoWorkEventArgs e)
	{
		RunSetupTasks();

		if (TaskHelper.GetNumberOfNormalTasks() > 0)
		{
			if (TaskHelper.TaskCollection.PerformanceCountersSamplingInterval > 0)
			{
				_performanceCountersSamplingWorker.RunWorkerAsync();
			}

			RunNormalTasks();
		}

		if (!_stopTaskRun)
		{
			RunTeardownTasks();
		}

		if (TaskHelper.AnyTasksWithIncludeInResults())
		{
			_databaseOperation.StopDeleteTrace();
			_traceStarted = false;
		}
	}

	private void RunNormalTasks()
	{
		if (!_stopTaskRun)
		{
			if (_worker.IsBusy)
			{
				_worker.ReportProgress(-3, "Status: Running...");
			}

			for (int connection = 1; connection <= TaskHelper.TaskCollection.Connections; connection++)
			{
				if (_stopTaskRun)
				{
					break;
				}

				_connectionsStarted++;
				_worker.ReportProgress(-1, _connectionsStarted);

				int runTaskConnection = connection;

				if (TaskHelper.TaskCollection.Mode == "Parallel")
				{
					Thread connectionThread = new Thread(delegate ()
					{
						RunTasks(runTaskConnection, TaskHelper.GetNormalTasks());
					});

					lock (this)
					{
						if (!_stopTaskRun)
						{
							_threadList.Add(connectionThread);
						}
					}

					connectionThread.Start();
				}
				else
				{
					RunTasks(runTaskConnection, TaskHelper.GetNormalTasks());
				}

				if (TaskHelper.TaskCollection.TimeBetweenConnections > 0)
				{
					GenericHelper.Sleep(TaskHelper.TaskCollection.TimeBetweenConnections);
				}
			}

			if (!_stopTaskRun)
			{
				_connectionsFinishedEvent.WaitOne();
			}

			_connectionsFinishedEvent.Close();
		}
	}

	private void RunSetupTasks()
	{
		RunTasks(0, TaskHelper.GetSetupTasks());
	}

	private void RunTeardownTasks()
	{
		RunTasks(0, TaskHelper.GetTeardownTasks());
	}

	private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		if (e.ProgressPercentage == -1)
		{
			int value = Convert.ToInt32(e.UserState);

			startedProgressBar.Value = value;

			if (value > 0)
			{
				startedProgressBar.Value = value - 1;
				startedProgressBar.Value = value;
			}

			startedLabel.Text = string.Format("Connections started ({0}/{1})", value, TaskHelper.TaskCollection.Connections);
		}
		else if (e.ProgressPercentage == -2)
		{
			int value = Convert.ToInt32(e.UserState);

			completedProgressBar.Value = value;

			if (value > 0)
			{
				completedProgressBar.Value = value - 1;
				completedProgressBar.Value = value;
			}

			completedLabel.Text = string.Format("Connections completed ({0}/{1})", value, TaskHelper.TaskCollection.Connections);
		}
		else if (e.ProgressPercentage == -3)
		{
			string text = e.UserState.ToString();
			statusLabel.Text = text;
		}
	}

	private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		startedProgressBar.Maximum = startedProgressBar.Maximum + 1;
		startedProgressBar.Value = startedProgressBar.Value + 1;
		startedProgressBar.Value = startedProgressBar.Value - 1;
		startedProgressBar.Maximum = startedProgressBar.Maximum - 1;

		completedProgressBar.Maximum = completedProgressBar.Maximum + 1;
		completedProgressBar.Value = completedProgressBar.Value + 1;
		completedProgressBar.Value = completedProgressBar.Value - 1;
		completedProgressBar.Maximum = completedProgressBar.Maximum - 1;

		_running = false;
		EnableItems();

		executionTimeTimer.Stop();
		_sw.Stop();

		_resultInfo.TotalExecutionTime = timeElapsedLabel.Text;
		_resultInfo.RunTime = DateTime.Now;
		_resultInfo.Version = GenericHelper.Version;

		if (_stopTaskRun)
		{
			statusLabel.Text = "Status: Stopped";
			_returnCode = 1;
		}
		else
		{
			statusLabel.Text = "Status: Preparing Results...";
			Application.DoEvents();

			HandleResults();

			statusLabel.Text = "Status: Completed";
			_returnCode = 0;
		}

		if (TaskHelper.AnyTasksWithIncludeInResults())
		{
			TraceFileHandler.DeleteTraceFile(false, _databaseOperation);
		}

		if (_unattended)
		{
			HandleUnattendedCompleted();
			Close();
		}
	}

	private void InitializePerformanceCountersSamplingWorker()
	{
		_performanceCountersSamplingWorker = new BackgroundWorker();
		_performanceCountersSamplingWorker.DoWork += PerformanceCountersSamplingWorker_DoWork;
	}

	private void PerformanceCountersSamplingWorker_DoWork(object sender, DoWorkEventArgs e)
	{
		DatabaseOperation performanceCountersSamplingDatabaseOperation = new DatabaseOperation();
		performanceCountersSamplingDatabaseOperation.InitializeDal(ConfigHandler.ConnectionString);

		while (_running)
		{
			if (_stopTaskRun)
			{
				break;
			}

			List<PerformanceCounter> performanceCounters = performanceCountersSamplingDatabaseOperation.GetPerformanceCounters();

			if (_running)
			{
				_performanceCounters.Add(new PerformanceCounters(performanceCounters));
			}

			Stopwatch sw = new Stopwatch();
			sw.Reset();
			sw.Start();

			while (sw.ElapsedMilliseconds <= TaskHelper.TaskCollection.PerformanceCountersSamplingInterval)
			{
			}

			sw.Stop();
		}

		performanceCountersSamplingDatabaseOperation.Dispose();
	}

	private bool PrepareRunTasks()
	{
		bool success = true;

		if (TaskHelper.AnyTasksWithIncludeInResults())
		{
			success = BeginTracing();
			_traceStarted = success;
		}

		return success;
	}

	private bool BeginTracing()
	{
		if (_traceStarted)
		{
			_databaseOperation.StopDeleteTrace();
			bool success = TraceFileHandler.DeleteTraceFile(true, _databaseOperation);

			if (!success)
			{
				_stopTaskRun = true;
				return false;
			}
		}

		int traceId = _databaseOperation.CreateTrace();

		if (traceId == 0)
		{
			_databaseOperation.StopDeleteTrace();
			MessageBox.Show("Insufficient rights to Trace File Directory.\r\n\r\nIf you are connecting to a remote SQL Server, please use UNC path and make sure the server has write access to your network share.\r\n\r\nTrace File Directory can be set in the Preferences menu.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			_stopTaskRun = true;
			return false;
		}
		else if (traceId == -1)
		{
			_databaseOperation.StopDeleteTrace();
			MessageBox.Show("Out of memory.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			_stopTaskRun = true;
			return false;
		}
		else
		{
			bool success = _databaseOperation.StartTrace(traceId);
			return success;
		}
	}

	private void HandleUnattendedCompleted()
	{
		if (_unattendedLogDir != null)
		{
			if (_unattendedLogDir.Substring(_unattendedLogDir.Length - 1, 1) == @"\")
			{
				_unattendedLogDir = _unattendedLogDir.Substring(0, _unattendedLogDir.Length - 1);
			}

			if (!Directory.Exists(_unattendedLogDir))
			{
				Directory.CreateDirectory(_unattendedLogDir);
			}

			if (_includeStylesheets)
			{
				foreach (Stylesheet stylesheet in StylesheetHelper.StylesheetCollection.Stylesheets)
				{
					if (stylesheet.Enabled)
					{
						string transformedXmlFileName = string.Format("PerformanceTestToolResultTransformed_{0}.{1}", stylesheet.Name, stylesheet.OutputFormat.ToLower());
						string transformedXmltempDirAndFileName = string.Format(@"{0}\{1}", _unattendedTempDir, transformedXmlFileName);

						if (File.Exists(transformedXmltempDirAndFileName))
						{
							File.Copy(transformedXmltempDirAndFileName, string.Format(@"{0}\{1}", _unattendedLogDir, transformedXmlFileName), true);
						}
					}
				}
			}

			if (_includeLog)
			{
				string logDirAndFileName = string.Format(@"{0}\{1}", _unattendedTempDir, GenericHelper.UnattendedLogFileName);

				if (File.Exists(logDirAndFileName))
				{
					File.Copy(logDirAndFileName, string.Format(@"{0}\{1}", _unattendedLogDir, GenericHelper.UnattendedLogFileName), true);
				}
			}
			else
			{
				string logDirAndFileName = string.Format(@"{0}\{1}", _unattendedTempDir, GenericHelper.UnattendedLogFileName);

				if (File.Exists(logDirAndFileName))
				{
					File.Delete(logDirAndFileName);
				}
			}

			if (_compression)
			{
				string logDirAndZipFileName = string.Format(@"{0}\{1}", _unattendedLogDir, GenericHelper.UnattendedZipFileName);

				if (File.Exists(logDirAndZipFileName))
				{
					File.Delete(logDirAndZipFileName);
				}

				if (Directory.GetFiles(_unattendedTempDir).Length > 0)
				{
					Compression.CompressDirectory(_unattendedTempDir, logDirAndZipFileName);
				}

				CleanupUncompressedFilesInUnattendedLogDir();
			}

			if (!string.IsNullOrEmpty(_unattendedEmailTo))
			{
				SendLogToMail(_unattendedLogDir);
			}

			if (_removeLogFiles)
			{
				if (!_compression)
				{
					CleanupUncompressedFilesInUnattendedLogDir();
				}
				else
				{
					if (File.Exists(GenericHelper.UnattendedZipFileName))
					{
						File.Delete(GenericHelper.UnattendedZipFileName);
					}
				}
			}
		}
	}

	private void CleanUpAfterUnattended()
	{
		if (_unattendedTempDir == null)
		{
			return;
		}

		if (!Directory.Exists(_unattendedTempDir))
		{
			return;
		}

		foreach (string fileName in Directory.GetFiles(_unattendedTempDir))
		{
			if (File.Exists(fileName))
			{
				File.Delete(fileName);
			}
		}

		if (Directory.Exists(_unattendedTempDir))
		{
			Directory.Delete(_unattendedTempDir);
		}
	}

	private void CleanupUncompressedFilesInUnattendedLogDir()
	{
		if (_includeStylesheets)
		{
			foreach (Stylesheet stylesheet in StylesheetHelper.StylesheetCollection.Stylesheets)
			{
				if (stylesheet.Enabled)
				{
					string transformedXmlFileName = string.Format("PerformanceTestToolResultTransformed_{0}.{1}", stylesheet.Name, stylesheet.OutputFormat.ToLower());
					string fileName = string.Format(@"{0}\{1}", _unattendedLogDir, transformedXmlFileName);

					if (File.Exists(fileName))
					{
						File.Delete(fileName);
					}
				}
			}
		}

		if (_includeLog)
		{
			string fileName = string.Format(@"{0}\{1}", _unattendedLogDir, GenericHelper.UnattendedLogFileName);

			if (File.Exists(fileName))
			{
				File.Delete(fileName);
			}
		}
	}

	private void SendLogToMail(string directoryWithFilesToAttach)
	{
		MailMessage message = new MailMessage();
		message.To.Add(_unattendedEmailTo);
		message.From = new MailAddress("unattended@PerformanceTestTool");
		message.Subject = _unattendedSubject;
		message.Body = "Performance Test Tool Unattended Run Log.\r\n\r\nPlease see attached file(s).";

		Attachment attachment = null;

		foreach (string fileName in Directory.GetFiles(directoryWithFilesToAttach))
		{
			attachment = new Attachment(fileName);
			message.Attachments.Add(attachment);
		}

		SmtpClient smtp = new SmtpClient(_unattendedSmtp);
		smtp.Send(message);

		if (attachment != null)
		{
			attachment.Dispose();
		}

		message.Dispose();
	}

	private void HandleResults()
	{
		DataTable traceData = new DataTable();

		if (TaskHelper.AnyTasksWithIncludeInResults())
		{
			traceData = _databaseOperation.GetTraceData();
		}

		List<RanTaskInfo> ranTaskInfo = new List<RanTaskInfo>();

		foreach (RunTaskInfo runTaskInfo in _runTaskInfo)
		{
			RanTaskInfo item = new RanTaskInfo();
			item.TaskName = runTaskInfo.TaskName;
			item.ConnectionNumber = runTaskInfo.ConnectionNumber;
			item.Message = TaskHelper.PrintsToMessage(runTaskInfo.Prints);

			ranTaskInfo.Add(item);
		}

		ShowResults(traceData, _performanceCounters, ranTaskInfo);
	}

	private static DateTime GetFirstConnectionStartTime(List<TraceDataHelper.FirstConnectionStartTimeObject> firstConnectionStartTimes, TaskHelper.TaskType taskType)
	{
		foreach (TraceDataHelper.FirstConnectionStartTimeObject firstConnectionStartTime in firstConnectionStartTimes)
		{
			if (firstConnectionStartTime.TaskType == taskType)
			{
				return firstConnectionStartTime.FirstConnectionStartTime;
			}
		}

		return new DateTime();
	}

	private void ShowResults(DataTable traceData, List<PerformanceCounters> performanceCounters, List<RanTaskInfo> ranTaskInfo)
	{
		TraceDataHelper traceDataHelper = new TraceDataHelper();
		List<ImportTraceDataValue> traceDataList = traceDataHelper.GetTraceDataList(traceData);

		List<ResultTask> resultTasks = new List<ResultTask>();

		foreach (Task task in TaskHelper.TaskCollection.Tasks)
		{
			if (task.IncludeInResults && task.Enabled)
			{
				List<TraceDataHelper.FirstConnectionStartTimeObject> firstConnectionStartTimes = traceDataHelper.GetFirstConnectionStartTimes();
				DateTime firstConnectionStartTime = GetFirstConnectionStartTime(firstConnectionStartTimes, task.Type);

				foreach (ImportTraceDataValue traceDataValue in traceDataList)
				{
					if (traceDataValue.TaskName == task.Name && traceDataValue.ColumnName == "Start Time" && traceDataValue.Connection == 1)
					{
						firstConnectionStartTime = firstConnectionStartTime.AddMilliseconds(traceDataValue.Value);
					}
				}

				resultTasks.Add(new ResultTask(task.Name, task.Description, task.DelayAfterCompletion, task.Type, firstConnectionStartTime));
			}
		}

		ResultTaskCollection resultTaskCollection = new ResultTaskCollection();
		resultTaskCollection.Tasks = resultTasks;
		resultTaskCollection.Description = TaskHelper.TaskCollection.Description;
		resultTaskCollection.PerformanceCountersSamplingInterval = TaskHelper.TaskCollection.PerformanceCountersSamplingInterval;
		resultTaskCollection.Connections = TaskHelper.TaskCollection.Connections;
		resultTaskCollection.TimeBetweenConnections = TaskHelper.TaskCollection.TimeBetweenConnections;
		resultTaskCollection.PerformanceCountersSamples = performanceCounters.Count;
		resultTaskCollection.Mode = TaskHelper.TaskCollection.Mode;
		resultTaskCollection.UsePooling = TaskHelper.TaskCollection.UsePooling;
		resultTaskCollection.MinPooling = TaskHelper.TaskCollection.MinPooling;
		resultTaskCollection.MaxPooling = TaskHelper.TaskCollection.MaxPooling;

		if (_unattended)
		{
			ResultsForm form = new ResultsForm();
			form.SetData(traceDataList, PerformanceCounterHelper.GetCalculatedPerformanceCounters(performanceCounters), _unattendedTempDir, ranTaskInfo, _includeStylesheets, resultTaskCollection, _resultInfo);
			form.Cleanup();
		}
		else
		{
			if (TaskHelper.AnyTasksWithIncludeInResults() || TaskHelper.TaskCollection.PerformanceCountersSamplingInterval > 0)
			{
				ResultsForm form = new ResultsForm();
				form.MessageToMainFormEvent += Form_MessageToMainFormEvent;
				form.SetData(traceDataList, PerformanceCounterHelper.GetCalculatedPerformanceCounters(performanceCounters), ranTaskInfo, resultTaskCollection, _resultInfo);
				form.Show();
			}
		}
	}

	private void RunTask(Task task, int connection, string taskName, DatabaseOperation taskRunDatabaseOperation)
	{
		string sql = task.Sql;

		int stepNumber = TaskHelper.GetStep(task);

		sql = sql.Replace("{connection}", connection.ToString());
		sql = sql.Replace("{totalconnections}", TaskHelper.TaskCollection.Connections.ToString());
		sql = sql.Replace("{step}", stepNumber.ToString());
		sql = sql.Replace("{tasktype}", task.Type.ToString());

		string prefix;

		if (task.IncludeInResults)
		{
			prefix = TaskHelper.TaskQueryPrefix;
		}
		else
		{
			prefix = TaskHelper.NonTaskQueryPrefix;
		}

		string step = string.Format("-- Step: {0} (Task Type: {1})", stepNumber, task.Type);

		sql = string.Format("{0}{1}\r\n-- Connection: {3}\r\n{4}\r\n{2}", prefix, task.Name, sql, connection, step);

		RunTaskInfo runTaskInfo = new RunTaskInfo();
		runTaskInfo.TaskName = task.Name;
		runTaskInfo.ConnectionNumber = connection;

		lock (this)
		{
			_runTaskInfo.Add(runTaskInfo);
		}

		StartConnectionDatabaseCommunication(sql, connection, taskName, taskRunDatabaseOperation);
	}

	private void StartConnectionDatabaseCommunication(string sql, int connection, string taskName, DatabaseOperation taskRunDatabaseOperation)
	{
		bool success = true;

		if (!taskRunDatabaseOperation.Connected)
		{
			success = false;
		}

		if (success)
		{
			success = taskRunDatabaseOperation.Execute(sql, connection, taskName);
		}

		lock (this)
		{
			if (!success)
			{
				_stopTaskRun = true;
			}
		}
	}

	private void RunTasks(int connection, List<Task> enabledTasks)
	{
		DatabaseOperation taskRunDatabaseOperation = new DatabaseOperation();
		taskRunDatabaseOperation.PrintEvent += TaskRunDatabaseOperation_PrintEvent;
		taskRunDatabaseOperation.InitializeDal(ConfigHandler.ConnectionString, TaskHelper.TaskCollection.UsePooling, TaskHelper.TaskCollection.MinPooling, TaskHelper.TaskCollection.MaxPooling);

		for (int taskNumber = 0; taskNumber < enabledTasks.Count; taskNumber++)
		{
			lock (this)
			{
				if (_stopTaskRun)
				{
					break;
				}

				if (connection > 0)
				{
					GenericHelper.ActiveRunningStepAndName = string.Format("Task: {0} (Connection {1})", enabledTasks[taskNumber].Name, connection);
				}
				else
				{
					GenericHelper.ActiveRunningStepAndName = string.Format("Task: {0}", enabledTasks[taskNumber].Name);
				}
			}

			if (connection == 0) // TaskType = Setup or Teardown
			{
				SetSingleConnectionStatus(enabledTasks[taskNumber], taskNumber, enabledTasks.Count);
			}

			RunTask(enabledTasks[taskNumber], connection, enabledTasks[taskNumber].Name, taskRunDatabaseOperation);

			if (enabledTasks[taskNumber].DelayAfterCompletion > 0)
			{
				GenericHelper.Sleep(enabledTasks[taskNumber].DelayAfterCompletion);
			}

			lock (this)
			{
				GenericHelper.ActiveRunningStepAndName = null;
			}
		}

		if (connection != 0) // TaskType = Normal
		{
			HandleConnectionCompleted();
		}

		taskRunDatabaseOperation.Dispose();
	}

	private void HandleConnectionCompleted()
	{
		lock (this)
		{
			_connectionsCompleted++;

			if (_worker.IsBusy && !_stopTaskRun)
			{
				try
				{
					_worker.ReportProgress(-2, _connectionsCompleted);
				}
				catch (Exception ex)
				{
					if (ex.Message == "This operation has already had OperationCompleted called on it and further calls are illegal.") // error in .NET
					{
					}
				}
			}

			if (_connectionsCompleted == TaskHelper.TaskCollection.Connections || _stopTaskRun)
			{
				SetConnectionsFinishedEvent();
			}
		}
	}

	private void SetSingleConnectionStatus(Task task, int value, int maximum)
	{
		string operation = "";

		if (task.Type == TaskHelper.TaskType.Setup)
		{
			operation = "Setting up";
		}
		else if (task.Type == TaskHelper.TaskType.Teardown)
		{
			operation = "Tearing down";
		}

		string text = string.Format("Status: {0}... ({1}/{2})", operation, value + 1, maximum);

		if (_worker.IsBusy)
		{
			_worker.ReportProgress(-3, text);
		}
	}

	private void SetConnectionsFinishedEvent()
	{
		SafeWaitHandle safeWaitHandle = _connectionsFinishedEvent.SafeWaitHandle;

		if (!safeWaitHandle.IsClosed)
		{
			try
			{
				_connectionsFinishedEvent.Set();
			}
			catch (Exception ex)
			{
				if (ex.Message == "Safe handle has been closed") // error in .NET
				{
				}
			}
		}
	}

	private void TaskRunDatabaseOperation_PrintEvent(int connectionNumber, string text, string taskName)
	{
		lock (this)
		{
			foreach (RunTaskInfo runTaskInfo in _runTaskInfo)
			{
				if (runTaskInfo.TaskName == taskName && runTaskInfo.ConnectionNumber == connectionNumber)
				{
					runTaskInfo.Prints.Add(text);
				}
			}
		}
	}

	private void DisableItems()
	{
		changeConnectionToolStripMenuItem.Enabled = false;
		tasksEditorToolStripMenuItem.Enabled = false;
		stylesheetEditorToolStripMenuItem.Enabled = false;
		preferencesToolStripMenuItem.Enabled = false;
		startedProgressBar.ForeColor = Color.DimGray;
		completedProgressBar.ForeColor = Color.DimGray;
		startToolStripMenuItem.Enabled = false;
		checkForupdatesToolStripMenuItem.Enabled = false;
		valueSubstitutorToolStripMenuItem.Enabled = false;
	}

	private void EnableItems()
	{
		changeConnectionToolStripMenuItem.Enabled = true;
		tasksEditorToolStripMenuItem.Enabled = true;
		stylesheetEditorToolStripMenuItem.Enabled = true;
		preferencesToolStripMenuItem.Enabled = true;
		runTasksButton.Enabled = true;
		startedProgressBar.ForeColor = Color.LightGray;
		completedProgressBar.ForeColor = Color.LightGray;
		runTasksButton.Text = "Start";
		startToolStripMenuItem.Enabled = true;
		checkForupdatesToolStripMenuItem.Enabled = true;
		valueSubstitutorToolStripMenuItem.Enabled = true;
	}

	private void Timer1_Tick(object sender, EventArgs e)
	{
		string hours = _sw.Elapsed.Hours.ToString();
		string minutes = _sw.Elapsed.Minutes.ToString();
		string seconds = _sw.Elapsed.Seconds.ToString();

		if (hours.Length == 1)
		{
			hours = string.Format("0{0}", hours);
		}

		if (minutes.Length == 1)
		{
			minutes = string.Format("0{0}", minutes);
		}

		if (seconds.Length == 1)
		{
			seconds = string.Format("0{0}", seconds);
		}

		timeElapsedLabel.Text = string.Format("{0}:{1}:{2}", hours, minutes, seconds);
	}

	private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (_running)
		{
			DialogResult result = MessageBox.Show("Performance Test in progress.\r\n\r\nAbort operation and exit?", GenericHelper.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

			if (result.ToString() == "No")
			{
				e.Cancel = true;
				return;
			}
		}

		if (_traceStarted) // In case program is forcibly closed while trace is running.
		{
			if (TaskHelper.AnyTasksWithIncludeInResults())
			{
				_databaseOperation.StopDeleteTrace();
				TraceFileHandler.DeleteTraceFile(false, _databaseOperation);
				_traceStarted = false;
			}
		}

		Hide();
		Application.DoEvents();

		CleanUpAfterUnattended();

		if (!_unattended)
		{
			SessionHelper.SaveSession();
		}

		Exit();
	}

	private void TasksEditorToolStripMenuItem_Click(object sender, EventArgs e)
	{
		TaskEditorForm form = new TaskEditorForm(_databaseOperation);
		form.ShowDialog();
		SetTaskCollectionDescription();
		SetRunButton();
	}

	private void StylesheetEditorToolStripMenuItem_Click(object sender, EventArgs e)
	{
		StylesheetEditorForm form = new StylesheetEditorForm();
		form.ShowDialog();
	}

	private void MainForm_Resize(object sender, EventArgs e)
	{
		if (Width < MinimumSize.Width || Width == 0 || !_loaded)
		{
			return;
		}

		if (!_unattended)
		{
			ConfigHandler.MainWindowSize = string.Format("{0}; {1}", Size.Width, Size.Height);
			ConfigHandler.SaveConfig();
		}
	}

	private void TaskCollectionDescriptionTextBox_Enter(object sender, EventArgs e)
	{
		taskCollectionDescriptionTextBox.SelectionStart = 0;
		taskCollectionDescriptionTextBox.SelectionLength = 0;
		GenericHelper.HideCaret(taskCollectionDescriptionTextBox);
	}

	private void TaskCollectionDescriptionTextBox_GotFocus(object sender, EventArgs e)
	{
		taskCollectionDescriptionTextBox.SelectionStart = 0;
		taskCollectionDescriptionTextBox.SelectionLength = 0;
		GenericHelper.HideCaret(taskCollectionDescriptionTextBox);
	}

	private void SaveXsdToolStripMenuItem_Click(object sender, EventArgs e)
	{
		DialogResult result = saveFileDialog1.ShowDialog();

		if (result.ToString() == "OK")
		{
			Application.DoEvents();
			string xsdContent = PerformanceTestTool.Properties.Resources.PerformanceTestToolXmlResult;
			File.WriteAllText(saveFileDialog1.FileName, xsdContent, Encoding.UTF8);
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

				ResultsForm form = new ResultsForm();
				form.MessageToMainFormEvent += Form_MessageToMainFormEvent;
				form.SetData(importResultXml.GetTraceData(), importResultXml.GetCalculatedPerformanceCounters(), importResultXml.GetRanTaskInfo(), importResultXml.GetResultTaskCollection(), importResultXml.GetResultInfo());
				form.Show();
			}
		}
	}

	private void Form_MessageToMainFormEvent(string message)
	{
		statusLabel.Text = message;
		statusLabel.Update();
	}

	private void TaskCollectionDescriptionTextBox_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.Control && e.KeyCode == Keys.A)
		{
			taskCollectionDescriptionTextBox.SelectAll();
		}
	}

	private void CommandLineParametersToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		CommandLineParametersForm form = new CommandLineParametersForm();
		form.ShowDialog();
	}

	private void StartToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Start();
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

	private void RecentFilesToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
	{
		FillRecentFilesMenu();
	}

	private void CheckForupdatesToolStripMenuItem_Click(object sender, EventArgs e)
	{
		CheckForUpdatesForm form = new CheckForUpdatesForm();
		form.ShowDialog();
	}

	private void MainForm_DragDrop(object sender, DragEventArgs e)
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

					ResultsForm form = new ResultsForm();
					form.MessageToMainFormEvent += Form_MessageToMainFormEvent;
					form.SetData(importResultXml.GetTraceData(), importResultXml.GetCalculatedPerformanceCounters(), importResultXml.GetRanTaskInfo(), importResultXml.GetResultTaskCollection(), importResultXml.GetResultInfo());
					form.Show();
				}
			}
		}
	}

	private void MainForm_DragOver(object sender, DragEventArgs e)
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

	private void ValueSubstitutorToolStripMenuItem_Click(object sender, EventArgs e)
	{
		ValueSubstitutorForm form = new ValueSubstitutorForm();
		form.ShowDialog();
	}
}
