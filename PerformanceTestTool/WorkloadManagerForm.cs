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
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

public partial class WorkloadManagerForm : Form
{
	private bool _running;
	private readonly Stopwatch _sw = new Stopwatch();
	private BackgroundWorker _backgroundWorker;

	public WorkloadManagerForm()
	{
		InitializeComponent();
		Initialize();
		InitializeWorker();
	}

	private void Initialize()
	{
		MinimumSize = new Size(700, 500);  // error in .NET

		WorkloadManagerConfigHandler.LoadConfig();
		Text = string.Format("{0} - Workload mode", GenericHelper.ApplicationName);

		runsTextBox.Text = WorkloadManagerConfigHandler.WorkloadManagerRuns;
		timeBetweenRunsTextBox.Text = WorkloadManagerConfigHandler.WorkloadManagerTimeBetweenRuns;

		customTaskCollectionCheckBox.Checked = Convert.ToBoolean(WorkloadManagerConfigHandler.WorkloadManagerCustomTaskCollection);
		customStylesheetCollectionCheckBox.Checked = Convert.ToBoolean(WorkloadManagerConfigHandler.WorkloadManagerCustomStylesheetCollection);
		includeLogCheckBox.Checked = Convert.ToBoolean(WorkloadManagerConfigHandler.WorkloadManagerIncludeResultXml);
		includeStylesheetsCheckBox.Checked = Convert.ToBoolean(WorkloadManagerConfigHandler.WorkloadManagerIncludeTransformedStylesheets);

		taskCollectionTextBox.Text = WorkloadManagerConfigHandler.WorkloadManagerTaskCollectionPath;
		stylesheetCollectionTextBox.Text = WorkloadManagerConfigHandler.WorkloadManagerStylesheetCollectionPath;
		logDirTextBox.Text = WorkloadManagerConfigHandler.WorkloadManagerLogDirectory;

		hiddenModeToolStripMenuItem.Checked = Convert.ToBoolean(WorkloadManagerConfigHandler.WorkloadManagerHiddenMode);

		runLabel.Text = "";
		runLabel.Visible = true;
	}

	private void InitializeWorker()
	{
		_backgroundWorker = new BackgroundWorker();
		_backgroundWorker.WorkerReportsProgress = true;
		_backgroundWorker.WorkerSupportsCancellation = true;
		_backgroundWorker.DoWork += BackgroundWorker_DoWork;
		_backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
		_backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
	}

	private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
	{
		RunWorkerArgument arg = (RunWorkerArgument)e.Argument;

		for (int run = 1; run <= arg.Runs; run++)
		{
			if (!_backgroundWorker.CancellationPending)
			{
				_backgroundWorker.ReportProgress(-1, run);
				RunTest(run);

				if (!_backgroundWorker.CancellationPending && run < arg.Runs && arg.Delay > 0)
				{
					GenericHelper.Sleep(arg.Delay);
				}
			}
		}

		if (_backgroundWorker.CancellationPending)
		{
			e.Cancel = true;
		}
	}

	private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		int run = (int)e.UserState;
		runProgressBar.Value = run;
		runLabel.Text = string.Format("Run ({0}/{1})", run, runsTextBox.Text);
	}

	private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		executionTimeTimer.Stop();
		_sw.Stop();

		if (e.Cancelled)
		{
			statusLabel.Text = "Cancelled";
		}
		else
		{
			statusLabel.Text = "Completed";
		}

		_running = false;
		EnableItems();
	}

	private class RunWorkerArgument
	{
		public int Runs;
		public int Delay;
	}

	private void RunTest(int runNumber)
	{
		string hiddenSwitch = "";

		if (Convert.ToBoolean(WorkloadManagerConfigHandler.WorkloadManagerHiddenMode))
		{
			hiddenSwitch = " -h";
		}

		string taskCollectionSwitch = "";

		if (customTaskCollectionCheckBox.Checked)
		{
			taskCollectionSwitch = string.Format(" -x:\"{0}\"", WorkloadManagerConfigHandler.WorkloadManagerTaskCollectionPath);
		}

		string stylesheetCollectionSwitch = "";

		if (customStylesheetCollectionCheckBox.Checked)
		{
			stylesheetCollectionSwitch = string.Format(" -y:\"{0}\"", WorkloadManagerConfigHandler.WorkloadManagerStylesheetCollectionPath);
		}

		string includeResultXmlSwitch = "";

		if (includeLogCheckBox.Checked)
		{
			includeResultXmlSwitch = " -l";
		}

		string includeTransformedStylesheetsSwitch = "";

		if (includeStylesheetsCheckBox.Checked)
		{
			includeTransformedStylesheetsSwitch = " -i";
		}

		string logDirSwitch = "";

		if (includeLogCheckBox.Checked || includeStylesheetsCheckBox.Checked)
		{
			logDirSwitch = string.Format(" -d:\"{0}_{1}\"", WorkloadManagerConfigHandler.WorkloadManagerLogDirectory, runNumber);
		}

		string performanceTestToolArguments = string.Format("-u{0}{1}{2}{3}{4}{5}", taskCollectionSwitch, stylesheetCollectionSwitch, hiddenSwitch, includeResultXmlSwitch, includeTransformedStylesheetsSwitch, logDirSwitch);

		ProcessStartInfo startInfo = new ProcessStartInfo(Assembly.GetExecutingAssembly().Location, performanceTestToolArguments);
		Execute(startInfo);
	}

	private static void Execute(ProcessStartInfo startInfo)
	{
		Process process = new Process();
		process.StartInfo = startInfo;
		process.Start();
		process.WaitForExit();
	}

	private void EnableItems()
	{
		hiddenModeToolStripMenuItem.Enabled = true;
		runsTextBox.Enabled = true;
		timeBetweenRunsTextBox.Enabled = true;
		customTaskCollectionCheckBox.Enabled = true;
		customStylesheetCollectionCheckBox.Enabled = true;
		SetCustomTaskCollectionCheckBox();
		SetCustomStylesheetCollectionCheckBox();
		includeLogCheckBox.Enabled = true;
		includeStylesheetsCheckBox.Enabled = true;
		SetLogDirEnabled();
		runProgressBar.ForeColor = Color.LightGray;
		startToolStripMenuItem.Enabled = true;
		startButton.Enabled = true;
		startButton.Text = "Start";
	}

	private void DisableItems()
	{
		hiddenModeToolStripMenuItem.Enabled = false;
		runsTextBox.Enabled = false;
		timeBetweenRunsTextBox.Enabled = false;
		customTaskCollectionCheckBox.Enabled = false;
		customStylesheetCollectionCheckBox.Enabled = false;
		taskCollectionTextBox.Enabled = false;
		stylesheetCollectionTextBox.Enabled = false;
		findTaskCollectionButton.Enabled = false;
		findStylesheetCollectionButton.Enabled = false;
		includeLogCheckBox.Enabled = false;
		includeStylesheetsCheckBox.Enabled = false;
		logDirTextBox.Enabled = false;
		findLogDirButton.Enabled = false;
		runProgressBar.ForeColor = Color.DimGray;
		startToolStripMenuItem.Enabled = false;
	}

	private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
	{
		AboutForm form = new AboutForm();
		form.ShowDialog();
	}

	private void StartButton_Click(object sender, EventArgs e)
	{
		if (startButton.Text == "Start")
		{
			Start();
		}
		else
		{
			DialogResult result = MessageBox.Show("Cancel?", GenericHelper.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

			if (result.ToString() == "Yes")
			{
				startButton.Enabled = false;
				statusLabel.Text = "Cancelling...";
				Stop();
			}
		}
	}

	private void Start()
	{
		if (CheckAndSaveValues())
		{
			runProgressBar.Maximum = Convert.ToInt32(runsTextBox.Text);
			runProgressBar.Value = 0;
			timeElapsedLabel.Text = "00:00:00";

			_running = true;
			DisableItems();
			startButton.Text = "Stop";
			statusLabel.Text = "Running...";

			executionTimeTimer.Start();
			_sw.Reset();
			_sw.Start();

			RunWorkerArgument arg = new RunWorkerArgument();
			arg.Runs = Convert.ToInt32(runsTextBox.Text);
			arg.Delay = Convert.ToInt32(timeBetweenRunsTextBox.Text);
			_backgroundWorker.RunWorkerAsync(arg);
		}
	}

	private void Stop()
	{
		_backgroundWorker.CancelAsync();
		startButton.Text = "Start";
	}

	private bool CheckAndSaveValues()
	{
		if (CheckRuns() && CheckTimeBetweenRuns() && CheckTaskCollectionPath() && CheckStylesheetCollectionPath() && CheckLogDirPath())
		{
			WorkloadManagerConfigHandler.WorkloadManagerRuns = runsTextBox.Text;
			WorkloadManagerConfigHandler.WorkloadManagerTimeBetweenRuns = timeBetweenRunsTextBox.Text;
			WorkloadManagerConfigHandler.WorkloadManagerCustomTaskCollection = customTaskCollectionCheckBox.Checked.ToString();
			WorkloadManagerConfigHandler.WorkloadManagerCustomStylesheetCollection = customStylesheetCollectionCheckBox.Checked.ToString();
			WorkloadManagerConfigHandler.WorkloadManagerTaskCollectionPath = taskCollectionTextBox.Text;
			WorkloadManagerConfigHandler.WorkloadManagerStylesheetCollectionPath = stylesheetCollectionTextBox.Text;
			WorkloadManagerConfigHandler.WorkloadManagerIncludeResultXml = includeLogCheckBox.Checked.ToString();
			WorkloadManagerConfigHandler.WorkloadManagerIncludeTransformedStylesheets = includeStylesheetsCheckBox.Checked.ToString();
			WorkloadManagerConfigHandler.WorkloadManagerLogDirectory = logDirTextBox.Text;
			WorkloadManagerConfigHandler.WorkloadManagerHiddenMode = hiddenModeToolStripMenuItem.Checked.ToString();

			WorkloadManagerConfigHandler.SaveConfig();
			return true;
		}

		return false;
	}

	private bool CheckLogDirPath()
	{
		if (includeLogCheckBox.Checked || includeStylesheetsCheckBox.Checked)
		{
			if (logDirTextBox.Text.Trim().Length <= 3)
			{
				MessageBox.Show("Log directory is invalid.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				logDirTextBox.Focus();
				return false;
			}
		}

		return true;
	}

	private bool CheckRuns()
	{
		int check;

		try
		{
			check = Convert.ToInt32(runsTextBox.Text);
		}
		catch
		{
			MessageBox.Show("Runs is not a valid number.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			runsTextBox.Focus();
			return false;
		}

		if (check <= 0)
		{
			MessageBox.Show("Runs must be greater than 0.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			runsTextBox.Focus();
			return false;
		}

		return true;
	}

	private bool CheckTimeBetweenRuns()
	{
		int check;

		try
		{
			check = Convert.ToInt32(timeBetweenRunsTextBox.Text);
		}
		catch
		{
			MessageBox.Show("Time bewteen runs is not a valid number.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			timeBetweenRunsTextBox.Focus();
			return false;
		}

		if (check < 0)
		{
			MessageBox.Show("Time bewteen runs must be equal to or greater than 0.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			timeBetweenRunsTextBox.Focus();
			return false;
		}

		return true;
	}

	private bool CheckTaskCollectionPath()
	{
		if (customTaskCollectionCheckBox.Checked)
		{
			if (!File.Exists(taskCollectionTextBox.Text))
			{
				MessageBox.Show("Task Collection Path is invalid.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				taskCollectionTextBox.Focus();
				return false;
			}
		}

		return true;
	}

	private bool CheckStylesheetCollectionPath()
	{
		if (customStylesheetCollectionCheckBox.Checked)
		{
			if (!File.Exists(stylesheetCollectionTextBox.Text))
			{
				MessageBox.Show("Stylesheet Collection Path is invalid.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				stylesheetCollectionTextBox.Focus();
				return false;
			}
		}

		return true;
	}

	private void CustomTaskCollectionCheckBox_CheckedChanged(object sender, EventArgs e)
	{
		SetCustomTaskCollectionCheckBox();
	}

	private void SetCustomTaskCollectionCheckBox()
	{
		taskCollectionTextBox.Enabled = customTaskCollectionCheckBox.Checked;
		findTaskCollectionButton.Enabled = customTaskCollectionCheckBox.Checked;

		if (customTaskCollectionCheckBox.Checked)
		{
			taskCollectionTextBox.BackColor = Color.WhiteSmoke;
			taskCollectionTextBox.Focus();
			taskCollectionTextBox.SelectionStart = taskCollectionTextBox.Text.Length;
			taskCollectionTextBox.SelectionLength = 0;
		}
		else
		{
			taskCollectionTextBox.BackColor = Color.Gainsboro;
		}
	}

	private void CustomStylesheetCollectionCheckBox_CheckedChanged(object sender, EventArgs e)
	{
		SetCustomStylesheetCollectionCheckBox();
	}

	private void SetCustomStylesheetCollectionCheckBox()
	{
		stylesheetCollectionTextBox.Enabled = customStylesheetCollectionCheckBox.Checked;
		findStylesheetCollectionButton.Enabled = customStylesheetCollectionCheckBox.Checked;

		if (customStylesheetCollectionCheckBox.Checked)
		{
			stylesheetCollectionTextBox.BackColor = Color.WhiteSmoke;
			stylesheetCollectionTextBox.Focus();
			stylesheetCollectionTextBox.SelectionStart = stylesheetCollectionTextBox.Text.Length;
			stylesheetCollectionTextBox.SelectionLength = 0;
		}
		else
		{
			stylesheetCollectionTextBox.BackColor = Color.Gainsboro;
		}
	}

	private void FindTaskCollectionButton_Click(object sender, EventArgs e)
	{
		DialogResult result = openFileDialog1.ShowDialog();

		if (result.ToString() == "OK")
		{
			Application.DoEvents();
			taskCollectionTextBox.Text = openFileDialog1.FileName;
		}
	}

	private void FindStylesheetCollectionButton_Click(object sender, EventArgs e)
	{
		DialogResult result = openFileDialog2.ShowDialog();

		if (result.ToString() == "OK")
		{
			Application.DoEvents();
			stylesheetCollectionTextBox.Text = openFileDialog2.FileName;
		}
	}

	private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (_running)
		{
			DialogResult result = MessageBox.Show("Performance Test in progress.\r\n\r\nAbort operation and exit?", GenericHelper.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

			if (result.ToString() == "No")
			{
				e.Cancel = true;
			}
		}
	}

	private void FindLogDirButton_Click(object sender, EventArgs e)
	{
		DialogResult result = folderBrowserDialog1.ShowDialog();

		if (result.ToString() == "OK")
		{
			Application.DoEvents();
			logDirTextBox.Text = folderBrowserDialog1.SelectedPath;
		}
	}

	private void IncludeLogCheckBox_CheckedChanged(object sender, EventArgs e)
	{
		SetLogDirEnabled();
	}

	private void IncludeStylesheetsCheckBox_CheckedChanged(object sender, EventArgs e)
	{
		SetLogDirEnabled();
	}

	private void SetLogDirEnabled()
	{
		if (!includeLogCheckBox.Checked && !includeStylesheetsCheckBox.Checked)
		{
			logDirTextBox.Enabled = false;
			findLogDirButton.Enabled = false;
			logDirTextBox.BackColor = Color.Gainsboro;
		}
		else
		{
			logDirTextBox.Enabled = true;
			findLogDirButton.Enabled = true;
			logDirTextBox.BackColor = Color.WhiteSmoke;
		}
	}

	private void StartToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Start();
	}

	private void ExecutionTimer_Tick(object sender, EventArgs e)
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
}
