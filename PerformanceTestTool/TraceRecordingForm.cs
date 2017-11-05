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
using System.IO;
using System.Windows.Forms;

public partial class TraceRecordingForm : Form
{
	private readonly DatabaseOperation _databaseOperation;
	private int _traceId;
	private bool _traceRunning;
	private bool _anythingRecorded;
	private BackgroundWorker _checkTraceFileDirWorker;
	private bool _checkingAccessRights;

	public TraceRecordingForm(DatabaseOperation databaseOperation)
	{
		InitializeComponent();
		Initialize();
		_databaseOperation = databaseOperation;
	}

	public bool AnythingRecorded()
	{
		return _anythingRecorded;
	}

	private void Initialize()
	{
		Text = string.Format("{0} - Record tasks", GenericHelper.ApplicationName);
	}

	private void CheckTraceFileDir()
	{
		_checkingAccessRights = true;

		startButton.Enabled = false;
		cancelButton.Enabled = false;

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
			string[] traceFiles = Directory.GetFiles(ConfigHandler.TraceFileDirectory, string.Format("{0}*.*", TaskHelper.TraceFileName));

			if (traceFiles.Length == 0 || !File.Exists(traceFiles[0]))
			{
				success = false;
				MessageBox.Show("Insufficient rights to Trace File Directory.\r\n\r\nIf you are connecting to a remote SQL Server, please use UNC path and make sure the server has write access to your network share.\r\n\r\nTrace File Directory can be set in the Preferences menu.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		_databaseOperation.StopDeleteTrace();
		TraceFileHandler.DeleteTraceFile(false, _databaseOperation);

		e.Result = success;
	}

	private void CheckTraceFileDirWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		_checkingAccessRights = false;
		statusLabel.Text = "Status: Idle";

		bool success = Convert.ToBoolean(e.Result);

		if (success)
		{
			DoStart();
		}
		else
		{
			startButton.Enabled = true;
			cancelButton.Enabled = true;
		}
	}

	private bool StartTracing()
	{
		bool success = _databaseOperation.StopDeleteTrace();

		if (!success)
		{
			return false;
		}

		success = TraceFileHandler.CheckTraceFileDirectoryRights();

		if (!success)
		{
			return false;
		}

		success = TraceFileHandler.DeleteTraceFile(true, _databaseOperation);

		if (!success)
		{
			return false;
		}

		success = BeginTracing();
		return success;
	}

	private bool BeginTracing()
	{
		_traceId = _databaseOperation.CreateTrace();

		if (_traceId == 0)
		{
			_databaseOperation.StopDeleteTrace();
			MessageBox.Show("Insufficient rights to Trace File Directory.\r\n\r\nIf you are connecting to a remote SQL Server, please use UNC path and make sure the server has write access to your network share.\r\n\r\nTrace File Directory can be set in the Preferences menu.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			return false;
		}
		else if (_traceId == -1)
		{
			_databaseOperation.StopDeleteTrace();
			MessageBox.Show("Out of memory.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			return false;
		}
		else
		{
			bool success = _databaseOperation.StartTraceRecording(_traceId);

			if (!success && ConfigHandler.UseExtendedEvents == "True")
			{
				MessageBox.Show("Insufficient rights to Trace File Directory.\r\n\r\nIf you are connecting to a remote SQL Server, please use UNC path and make sure the server has write access to your network share.\r\n\r\nTrace File Directory can be set in the Preferences menu.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

			return success;
		}
	}

	private void StartButton_Click(object sender, EventArgs e)
	{
		startButton.Enabled = false;
		cancelButton.Enabled = false;

		CheckTraceFileDir();
	}

	private void DoStart()
	{
		GenericHelper.ShowErrorMessageForm = true;

		bool success = StartTracing();

		if (success)
		{
			statusLabel.Text = "Status: Recording...";
			_traceRunning = true;
			pauseButton.Enabled = true;
			stopButton.Enabled = true;
			cancelButton.Enabled = true;
			progressBar1.Style = ProgressBarStyle.Marquee;
			recordingPictureBox.Visible = true;
			stopButton.Focus();
		}
		else
		{
			startButton.Enabled = true;
			cancelButton.Enabled = true;
		}
	}

	private void PauseButton_Click(object sender, EventArgs e)
	{
		if (pauseButton.Text == "Pause")
		{
			statusLabel.Text = "Status: Paused";
			progressBar1.MarqueeAnimationSpeed = 0;
			pauseButton.Text = "    Continue";
			recordingPictureBox.Visible = false;
			_databaseOperation.SetTraceStatus(_traceId, 0);
		}
		else
		{
			statusLabel.Text = "Status: Recording...";
			progressBar1.MarqueeAnimationSpeed = 100;
			pauseButton.Text = "Pause";
			recordingPictureBox.Visible = true;
			_databaseOperation.SetTraceStatus(_traceId, 1);
		}
	}

	private void StopButton_Click(object sender, EventArgs e)
	{
		bool success = _databaseOperation.StopDeleteTrace();
		_traceRunning = false;
		progressBar1.Style = ProgressBarStyle.Blocks;

		if (success)
		{
			TaskCollection taskCollection = TraceFileHandler.ImportTrace(_databaseOperation.GetTraceRecordingData());

			if (taskCollection.Tasks.Count > 0)
			{
				foreach (Task task in taskCollection.Tasks)
				{
					task.Name = TaskHelper.GetNewItemName(task.Name);
					TaskHelper.TaskCollection.Tasks.Add(task);
				}

				_anythingRecorded = true;
			}
			else
			{
				MessageBox.Show("No tasks recorded.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		TraceFileHandler.DeleteTraceFile(true, _databaseOperation);

		Close();
	}

	private void TraceRecordingForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (_checkingAccessRights)
		{
			e.Cancel = true;
			return;
		}

		if (_traceRunning)
		{
			DialogResult result = MessageBox.Show("Recording in progress.\r\n\r\nAbort operation?", GenericHelper.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

			if (result.ToString() == "Yes")
			{
				_databaseOperation.StopDeleteTrace();
				_anythingRecorded = false;

				TraceFileHandler.DeleteTraceFile(true, _databaseOperation);
			}
			else
			{
				e.Cancel = true;
			}
		}
	}
}
