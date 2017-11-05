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
using System.Windows.Forms;

public partial class PreferencesForm : Form
{
	private bool _textChanged;
	private bool _resetLayout;

	public PreferencesForm(DatabaseOperation databaseOperation)
	{
		InitializeComponent();
		Initialize(databaseOperation);
	}

	public bool ResetLayout()
	{
		return _resetLayout;
	}

	private void Initialize(DatabaseOperation databaseOperation)
	{
		Text = string.Format("{0} - Preferences", GenericHelper.ApplicationName);

		traceFilePathComboBox.Text = ConfigHandler.TraceFileDirectory;
		SearchHistoryHandler.LoadItems(traceFilePathComboBox, "RecentListTraceFileDir_Settings");
		FillDefaultStylesheet();
		FillTracingFunctionality(databaseOperation);

		_textChanged = false;
	}

	private void OkButton_Click(object sender, EventArgs e)
	{
		if (traceFilePathComboBox.Text.Trim() == "")
		{
			MessageBox.Show("Trace File Directory can't be empty.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			traceFilePathComboBox.Focus();
			return;
		}

		ConfigHandler.TraceFileDirectory = traceFilePathComboBox.Text.Trim();

		if (stylesheetComboBox.SelectedItem != null)
		{
			ConfigHandler.DefaultStylesheet = stylesheetComboBox.SelectedItem.ToString();
		}

		if (tracingFunctionalityComboBox.SelectedIndex == 0)
		{
			ConfigHandler.UseExtendedEvents = "False";
		}
		else if (tracingFunctionalityComboBox.SelectedIndex == 1)
		{
			ConfigHandler.UseExtendedEvents = "True";
		}

		ConfigHandler.SaveConfig();
		SearchHistoryHandler.AddItem(traceFilePathComboBox, traceFilePathComboBox.Text, "RecentListTraceFileDir_Settings");

		_textChanged = false;
		Close();
	}

	private void PreferencesForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (_textChanged)
		{
			DialogResult result = MessageBox.Show("Discard changes?", GenericHelper.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

			if (result.ToString() != "Yes")
			{
				e.Cancel = true;
			}
		}
	}

	private void ResetLayoutButton_Click(object sender, EventArgs e)
	{
		DialogResult result = MessageBox.Show("Reset all window sizes to default sizes?", GenericHelper.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

		if (result.ToString() == "Yes")
		{
			ConfigHandler.EditWindowSize = GenericHelper.DefaultWindowSize;
			ConfigHandler.EditorWindowSize = GenericHelper.DefaultWindowSize;
			ConfigHandler.ResultsWindowSize = GenericHelper.DefaultWindowSize;
			ConfigHandler.CommandLineParametersWindowSize = GenericHelper.DefaultWindowSize;
			ConfigHandler.MainWindowSize = GenericHelper.DefaultWindowSize;

			ConfigHandler.SaveConfig();

			_resetLayout = true;
		}
	}

	private void StylesheetComboBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		_textChanged = true;
	}

	private void FillDefaultStylesheet()
	{
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
	}

	private void FillTracingFunctionality(DatabaseOperation databaseOperation)
	{
		tracingFunctionalityComboBox.Items.Add("SQL Server Trace");
		tracingFunctionalityComboBox.SelectedIndex = 0;

		if (ConfigHandler.OfflineMode == "True")
		{
			tracingFunctionalityComboBox.Enabled = false;
		}
		else
		{
			tracingFunctionalityComboBox.Enabled = true;

			if (databaseOperation.GetSqlServerVersion() >= 11)
			{
				tracingFunctionalityComboBox.Items.Add("Extended Events");

				if (ConfigHandler.UseExtendedEvents == "True")
				{
					tracingFunctionalityComboBox.SelectedIndex = 1;
				}
			}
		}
	}

	private void TracingFunctionalityComboBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		_textChanged = true;
	}

	private void ChooseDirectoryButton_Click(object sender, EventArgs e)
	{
		folderBrowserDialog1.SelectedPath = traceFilePathComboBox.Text;

		DialogResult result = folderBrowserDialog1.ShowDialog();

		if (result == DialogResult.OK)
		{
			traceFilePathComboBox.Text = folderBrowserDialog1.SelectedPath;
		}
	}

	private void TraceFilePathComboBox_TextChanged(object sender, EventArgs e)
	{
		_textChanged = true;
	}
}
