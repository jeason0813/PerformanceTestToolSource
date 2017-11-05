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
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

public static class Program
{
	[STAThread]
	public static int Main(string[] args)
	{
		DynamicAssembly.EnableDynamicLoadingForDlls(Assembly.GetExecutingAssembly(), "PerformanceTestTool.Resources.Assemblies");

		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(false);
		Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
		Application.ThreadException += ApplicationThreadException;
		AppDomain.CurrentDomain.UnhandledException += CurrentDomainUnhandledException;

		int returnCode = 0;

		if (args.Length == 0)
		{
			Application.Run(new MainForm());
		}
		else
		{
			returnCode = HandleCommandLineArgs(args);
		}

		Environment.ExitCode = returnCode;
		return returnCode;
	}

	private static void ProcessException(Exception ex)
	{
		ErrorForm form = new ErrorForm(-1, "Exit", ex.Message, ex.StackTrace, GenericHelper.ApplicationName);
		form.ShowDialog();
	}

	private static void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
	{
		ProcessException(e.Exception);
	}

	private static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
	{
		ProcessException(e.ExceptionObject as Exception);
	}

	private static int HandleCommandLineArgs(string[] args)
	{
		bool unattended = false;
		bool startNormal = false;
		string logDir = null;
		bool includeStylesheets = false;
		bool includeLog = false;
		bool compression = false;
		bool removeLogFiles = false;
		bool hiddenMode = false;
		string smtp = null;
		string emailTo = null;
		string subject = null;
		string tasksFileName = null;
		string stylesheetsFileName = null;
		string errorLogFileName = null;
		string connectionString = null;
		string traceFileDirectory = null;

		bool workloadMode = false;

		try
		{
			if (args.Length == 1) // -w
			{
				if (args[0].ToLower() == "-w")
				{
					workloadMode = true;
				}
			}

			if (!workloadMode)
			{
				if (args.Length >= 1 && args.Length <= 15) // -u -a -p -d -h -l -i -c -m -t -s -r -x -y -e
				{
					if (GenericHelper.UniqueElements(args))
					{
						int correctArgsCount = 0;
						int correctMailCount = 0; // -m -t -s
						int correctLogCount = 0; // -u
						int correctLogOptionsCount = 0; // -l -i -c -r
						int correctMandatoryLogOptions1Count = 0; // -d
						int correctOptionalLogOptions1Count = 0; // -h -e -a -p
						int correctImportFileCount = 0; // -x -y

						foreach (string arg in args)
						{
							if (arg.Length == 2)
							{
								if (arg.ToLower() == "-u")
								{
									correctArgsCount++;
									correctLogCount++;
								}

								if (arg.ToLower() == "-l")
								{
									includeLog = true;
									correctArgsCount++;
									correctLogOptionsCount++;
								}

								if (arg.ToLower() == "-i")
								{
									includeStylesheets = true;
									correctArgsCount++;
									correctLogOptionsCount++;
								}

								if (arg.ToLower() == "-c")
								{
									compression = true;
									correctArgsCount++;
									correctLogOptionsCount++;
								}

								if (arg.ToLower() == "-r")
								{
									removeLogFiles = true;
									correctArgsCount++;
									correctLogOptionsCount++;
								}

								if (arg.ToLower() == "-h")
								{
									hiddenMode = true;
									correctArgsCount++;
									correctOptionalLogOptions1Count++;
								}
							}
							else
							{
								if (arg.ToLower().Substring(0, 3) == "-a:")
								{
									connectionString = arg.Substring(3, arg.Length - 3);

									if (connectionString.Length > 0)
									{
										correctArgsCount++;
										correctOptionalLogOptions1Count++;
									}
								}

								if (arg.ToLower().Substring(0, 3) == "-p:")
								{
									traceFileDirectory = arg.Substring(3, arg.Length - 3);

									if (traceFileDirectory.Length > 0)
									{
										correctArgsCount++;
										correctOptionalLogOptions1Count++;
									}
								}

								if (arg.ToLower().Substring(0, 3) == "-d:")
								{
									logDir = arg.Substring(3, arg.Length - 3);

									if (logDir.Length > 0)
									{
										correctArgsCount++;
										correctMandatoryLogOptions1Count++;
									}
								}

								if (arg.ToLower().Substring(0, 3) == "-m:")
								{
									smtp = arg.Substring(3, arg.Length - 3);

									if (smtp.Length > 0)
									{
										correctArgsCount++;
										correctMailCount++;
									}
								}

								if (arg.ToLower().Substring(0, 3) == "-t:")
								{
									emailTo = arg.Substring(3, arg.Length - 3).Replace(";", ",");

									if (emailTo.Length > 0)
									{
										correctArgsCount++;
										correctMailCount++;
									}
								}

								if (arg.ToLower().Substring(0, 3) == "-s:")
								{
									subject = arg.Substring(3, arg.Length - 3);

									if (subject.Length > 0)
									{
										correctArgsCount++;
										correctMailCount++;
									}
								}

								if (arg.ToLower().Substring(0, 3) == "-x:")
								{
									tasksFileName = arg.Substring(3, arg.Length - 3);

									if (tasksFileName.Length > 0)
									{
										correctArgsCount++;
										correctImportFileCount++;
									}
								}

								if (arg.ToLower().Substring(0, 3) == "-y:")
								{
									stylesheetsFileName = arg.Substring(3, arg.Length - 3);

									if (stylesheetsFileName.Length > 0)
									{
										correctArgsCount++;
										correctImportFileCount++;
									}
								}

								if (arg.ToLower().Substring(0, 3) == "-e:")
								{
									errorLogFileName = arg.Substring(3, arg.Length - 3);

									if (errorLogFileName.Length > 0)
									{
										correctArgsCount++;
										correctOptionalLogOptions1Count++;
									}
								}
							}

							if
							(
								correctArgsCount == args.Length
								&& (correctImportFileCount >= 1 && correctImportFileCount <= 2) // -x -y
							)
							{
								if (tasksFileName != null)
								{
									LoadTasksFromFile(tasksFileName);
								}

								if (stylesheetsFileName != null)
								{
									LoadStylesheetsFromFile(stylesheetsFileName);
								}

								startNormal = true;
							}

							if
							(
								correctArgsCount == args.Length
								&&
								correctLogCount == 1 // -u
								&&
								correctLogOptionsCount == 0
								||
								(
									correctMandatoryLogOptions1Count == 1 // -d
									&&
									(correctLogOptionsCount >= 0 && correctLogOptionsCount <= 4) // -l -i -c -r
									&&
									(correctMailCount == 0 || correctMailCount == 3) // -m -t -s
								)
								&&
								(correctOptionalLogOptions1Count >= 0 && correctOptionalLogOptions1Count <= 4) // -h -e -a -p
							)
							{
								unattended = true;
							}
						}
					}
				}
			}

			if (!unattended && !startNormal && !workloadMode)
			{
				WriteCommandSyntax();
				return 1;
			}
		}
		catch
		{
			WriteCommandSyntax();
			return 1;
		}

		if (unattended)
		{
			return StartUnattended(includeLog, smtp, emailTo, subject, compression, includeStylesheets, logDir, removeLogFiles, hiddenMode, errorLogFileName, connectionString, traceFileDirectory);
		}
		else if (startNormal)
		{
			StartNormal();
		}
		else if (workloadMode)
		{
			WorkloadMode();
		}

		return 0;
	}

	private static void LoadTasksFromFile(string tasksFileName)
	{
		string xml = XmlHelper.ReadXmlFromFile(tasksFileName);
		TaskHelper.TaskCollection = TaskHelper.XmlToTaskCollection(xml);
		TaskHelper.TaskCollectionFileName = tasksFileName;
		SessionHelper.EnableLoadLastSessionTaskCollection = false;
	}

	private static void LoadStylesheetsFromFile(string stylesheetsFileName)
	{
		string xml = XmlHelper.ReadXmlFromFile(stylesheetsFileName);
		StylesheetHelper.StylesheetCollection = StylesheetHelper.XmlToStylesheetCollection(xml);
		StylesheetHelper.StylesheetCollectionFileName = stylesheetsFileName;
		SessionHelper.EnableLoadLastSessionStylesheetCollection = false;
	}

	private static int StartUnattended(bool includeLog, string smtp, string emailTo, string subject, bool compression, bool includeStylesheets, string logDir, bool removeFilesAfterSendEmail, bool hiddenMode, string errorLogFileName, string connectionString, string traceFileDirectory)
	{
		MainForm form = new MainForm(includeLog, smtp, emailTo, subject, compression, includeStylesheets, logDir, removeFilesAfterSendEmail, errorLogFileName, connectionString, traceFileDirectory);

		if (hiddenMode)
		{
			form.WindowState = FormWindowState.Minimized;
			form.ShowInTaskbar = false;
			form.Opacity = 0;
		}

		Application.Run(form);
		return form.GetReturnCode();
	}

	private static void StartNormal()
	{
		MainForm form = new MainForm();
		Application.Run(form);
	}

	private static void WorkloadMode()
	{
		WorkloadManagerForm form = new WorkloadManagerForm();
		Application.Run(form);
	}

	private static void WriteCommandSyntax()
	{
		ConfigHandler.LoadConfig();
		CommandLineParametersForm form = new CommandLineParametersForm();
		form.SetCommandSyntaxOptions();
		form.ShowDialog();
	}
}
