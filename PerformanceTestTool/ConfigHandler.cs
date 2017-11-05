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
using System.IO;
using Microsoft.Win32;

public static class ConfigHandler
{
	public static string ConnectionString;
	public static string ConnectionStringToSave;
	public static string SaveConnectionString;
	public static string WordWrap;
	public static string TraceFileDirectory;
	public static string EditWindowSize;
	public static string EditorWindowSize;
	public static string CommandLineParametersWindowSize;
	public static string MainWindowSize;
	public static string ResultsWindowSize;
	public static string ValueSubstitutorWindowSize;
	public static string EditorFontFamily;
	public static string EditorFontSize;
	public static string DefaultStylesheet;
	public static string IgnoreErrors;
	public static string OfflineMode;
	public static string OfflineModeToSave;
	public static string UseExtendedEvents;
	public static string CheckForUpdatesOnStart;
	public static string UpdateServiceUrl;

	public static void SaveConnection()
	{
		RegistryHandler.SaveToRegistry("ConnectionString", ConnectionStringSecurity.Encode(ConnectionStringToSave, "ConnectionString"));
		RegistryHandler.SaveToRegistry("SaveConnectionString", SaveConnectionString);
		RegistryHandler.SaveToRegistry("OfflineMode", OfflineModeToSave);
	}

	public static void SaveConfig()
	{
		RegistryHandler.SaveToRegistry("WordWrap", WordWrap);
		RegistryHandler.SaveToRegistry("TraceFileDirectory", TraceFileDirectory);
		RegistryHandler.SaveToRegistry("EditWindowSize", EditWindowSize);
		RegistryHandler.SaveToRegistry("EditorWindowSize", EditorWindowSize);
		RegistryHandler.SaveToRegistry("CommandLineParametersWindowSize", CommandLineParametersWindowSize);
		RegistryHandler.SaveToRegistry("MainWindowSize", MainWindowSize);
		RegistryHandler.SaveToRegistry("ResultsWindowSize", ResultsWindowSize);
		RegistryHandler.SaveToRegistry("ValueSubstitutorWindowSize", ValueSubstitutorWindowSize);
		RegistryHandler.SaveToRegistry("EditorFontFamily", EditorFontFamily);
		RegistryHandler.SaveToRegistry("EditorFontSize", EditorFontSize);
		RegistryHandler.SaveToRegistry("DefaultStylesheet", DefaultStylesheet);
		RegistryHandler.SaveToRegistry("UseExtendedEvents", UseExtendedEvents);
		RegistryHandler.SaveToRegistry("IgnoreErrors", IgnoreErrors);
		RegistryHandler.SaveToRegistry("CheckForUpdatesOnStart", CheckForUpdatesOnStart);
	}

	public static void SetTraceFileDirectory()
	{
		TraceFileDirectory = RegistryHandler.ReadFromRegistry("TraceFileDirectory");

		if (TraceFileDirectory == "")
		{
			if (!Convert.ToBoolean(OfflineMode))
			{
				DatabaseOperation databaseOperation = new DatabaseOperation();
				databaseOperation.InitializeDal(ConnectionString);

				string traceFileDir = databaseOperation.GetSqlServerDataDir();
				databaseOperation.Dispose();

				if (!Directory.Exists(traceFileDir))
				{
					traceFileDir = GenericHelper.TempPath;
				}

				TraceFileDirectory = traceFileDir;
			}
			else
			{
				TraceFileDirectory = GenericHelper.TempPath;
			}
		}
	}

	public static void LoadConfig()
	{
		ConnectionString = ConnectionStringSecurity.Decode(RegistryHandler.ReadFromRegistry("ConnectionString"), "ConnectionString");

		if (ConnectionString == "")
		{
			ConnectionString = @"Data Source=SQLServerName\SQLServerInstance;Initial Catalog=master;Integrated Security=True";
		}

		ConnectionStringToSave = ConnectionStringSecurity.Decode(RegistryHandler.ReadFromRegistry("ConnectionString"), "ConnectionString");

		if (ConnectionStringToSave == "")
		{
			ConnectionStringToSave = @"Data Source=SQLServerName\SQLServerInstance;Initial Catalog=master;Integrated Security=True";
		}

		SaveConnectionString = RegistryHandler.ReadFromRegistry("SaveConnectionString");

		if (SaveConnectionString == "")
		{
			SaveConnectionString = "True";
		}

		WordWrap = RegistryHandler.ReadFromRegistry("WordWrap");

		if (WordWrap == "")
		{
			WordWrap = "False";
		}

		if (TraceFileDirectory == null)
		{
			TraceFileDirectory = "";
		}

		EditWindowSize = RegistryHandler.ReadFromRegistry("EditWindowSize");

		if (EditWindowSize == "")
		{
			EditWindowSize = GenericHelper.DefaultWindowSize;
		}

		EditorWindowSize = RegistryHandler.ReadFromRegistry("EditorWindowSize");

		if (EditorWindowSize == "")
		{
			EditorWindowSize = GenericHelper.DefaultWindowSize;
		}

		CommandLineParametersWindowSize = RegistryHandler.ReadFromRegistry("CommandLineParametersWindowSize");

		if (CommandLineParametersWindowSize == "")
		{
			CommandLineParametersWindowSize = GenericHelper.DefaultWindowSize;
		}

		MainWindowSize = RegistryHandler.ReadFromRegistry("MainWindowSize");

		if (MainWindowSize == "")
		{
			MainWindowSize = GenericHelper.DefaultWindowSize;
		}

		ResultsWindowSize = RegistryHandler.ReadFromRegistry("ResultsWindowSize");

		if (ResultsWindowSize == "")
		{
			ResultsWindowSize = GenericHelper.DefaultWindowSize;
		}

		ValueSubstitutorWindowSize = RegistryHandler.ReadFromRegistry("ValueSubstitutorWindowSize");

		if (ValueSubstitutorWindowSize == "")
		{
			ValueSubstitutorWindowSize = GenericHelper.DefaultWindowSize;
		}

		EditorFontFamily = RegistryHandler.ReadFromRegistry("EditorFontFamily");

		if (EditorFontFamily == "")
		{
			EditorFontFamily = "Courier New";
		}

		EditorFontSize = RegistryHandler.ReadFromRegistry("EditorFontSize");

		if (EditorFontSize == "")
		{
			EditorFontSize = "10";
		}

		DefaultStylesheet = RegistryHandler.ReadFromRegistry("DefaultStylesheet");

		if (DefaultStylesheet == "")
		{
			DefaultStylesheet = "Graphs";
		}

		UseExtendedEvents = RegistryHandler.ReadFromRegistry("UseExtendedEvents");

		if (UseExtendedEvents == "")
		{
			UseExtendedEvents = "";
		}

		IgnoreErrors = RegistryHandler.ReadFromRegistry("IgnoreErrors");

		OfflineMode = RegistryHandler.ReadFromRegistry("OfflineMode");

		if (OfflineMode == "")
		{
			OfflineMode = "False";
		}

		OfflineModeToSave = RegistryHandler.ReadFromRegistry("OfflineModeToSave");

		if (OfflineModeToSave == "")
		{
			OfflineModeToSave = "False";
		}

		CheckForUpdatesOnStart = RegistryHandler.ReadFromRegistry("CheckForUpdatesOnStart");

		if (CheckForUpdatesOnStart == "")
		{
			CheckForUpdatesOnStart = "True";
		}

		string installed = RegistryHandler.ReadFromRegistry("Installed", Registry.CurrentUser);

		if (installed == "1")
		{
			SaveConfig(); // To set default values in registry

			if (TaskHelper.TaskCollection.Tasks.Count == 0)
			{
				TaskHelper.TaskCollection.Description = "No Task Collection loaded.\r\nTo load or create a Task Collection choose \"Options\", \"Task Collection Editor...\".";
				TaskHelper.TaskCollection.Connections = 1;
				TaskHelper.TaskCollection.PerformanceCountersSamplingInterval = 0;
				TaskHelper.TaskCollection.TimeBetweenConnections = 0;
			}

			if (StylesheetHelper.StylesheetCollection.Stylesheets.Count == 0)
			{
				StylesheetHelper.StylesheetCollection = StylesheetHelper.XmlToStylesheetCollection(PerformanceTestTool.Properties.Resources.DefaultStylesheets);
			}

			SessionHelper.SaveSession();
			RegistryHandler.SaveToRegistry("Installed", "2", Registry.CurrentUser);
		}

		UpdateServiceUrl = RegistryHandler.ReadFromRegistry("UpdateServiceUrl");

		if (UpdateServiceUrl == "")
		{
			UpdateServiceUrl = "http://virtcore.com/VirtcoreService.asmx";
			RegistryHandler.SaveToRegistry("UpdateServiceUrl", UpdateServiceUrl);
		}
	}
}
