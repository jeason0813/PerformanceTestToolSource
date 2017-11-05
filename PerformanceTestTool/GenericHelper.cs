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
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Windows.Forms;

public static class GenericHelper
{
	public static string ExecPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
	public const string DefaultWindowSize = "700; 500";
	public const string MinimumDefaultWindowSize = "700; 500";
	public const string ApplicationName = "Performance Test Tool";
	public const int NumberOfRecentFiles = 10;
	public const int NumberOfSearchHistoryItems = 10;
	public static bool ShowErrorMessageForm = true;
	public static string ActiveRunningStepAndName;
	public static string UnattendedErrorLogFileName = null;

	[DllImport("user32")]
	private static extern bool HideCaret(IntPtr hWnd);
	public static void HideCaret(TextBox textBox)
	{
		HideCaret(textBox.Handle);
	}

	public const string UnattendedLogFileName = "PerformanceTestToolXmlResult.xml";
	public const string UnattendedZipFileName = "PerformanceTestToolResults.zip";

	public enum CheckValue
	{
		Integer,
		TaskName,
		StylesheetName
	}

	public static class WinApi
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Interoperability", "CA1401:PInvokesShouldNotBeVisible"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage"), SuppressUnmanagedCodeSecurity]
		[DllImport("winmm.dll", EntryPoint = "timeBeginPeriod", SetLastError = true)]

		public static extern uint TimeBeginPeriod(uint uMilliseconds);

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Interoperability", "CA1401:PInvokesShouldNotBeVisible"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage"), SuppressUnmanagedCodeSecurity]
		[DllImport("winmm.dll", EntryPoint = "timeEndPeriod", SetLastError = true)]

		public static extern uint TimeEndPeriod(uint uMilliseconds);
	}

	public static void Sleep(int milliSecondsToWait)
	{
		Thread.Sleep(milliSecondsToWait);
	}

	public static bool UniqueElements(string[] elements)
	{
		List<string> elementList = new List<string>();

		foreach (string element in elements)
		{
			if (!elementList.Contains(element))
			{
				elementList.Add(element);
			}
			else
			{
				return false;
			}
		}

		return true;
	}

	public static string Reverse(string s)
	{
		char[] charArray = s.ToCharArray();
		Array.Reverse(charArray);
		return new string(charArray);
	}

	public static string[] GetOsInformation(string[] rawVersion)
	{
		string[] versionInfo = new string[2];

		for (int i = 0; i < rawVersion.Length; i++)
		{
			if (i == 0)
			{
				versionInfo[0] = rawVersion[i].Trim();
			}
			else if (i == 3)
			{
				string osName = rawVersion[i].Trim();
				int onPos = osName.IndexOf(" on ");

				versionInfo[1] = osName.Substring(onPos + 4, osName.Length - (onPos + 4));
			}
		}

		return versionInfo;
	}

	public static string Version
	{
		get
		{
			Assembly asm = Assembly.GetExecutingAssembly();

			if (asm.GetName().Version.Revision > 0)
			{
				return string.Format("{0}.{1}.{2}.{3}", asm.GetName().Version.Major, asm.GetName().Version.Minor, asm.GetName().Version.Build, asm.GetName().Version.Revision);
			}
			else
			{
				return string.Format("{0}.{1}.{2}", asm.GetName().Version.Major, asm.GetName().Version.Minor, asm.GetName().Version.Build);
			}
		}
	}

	public static long TimeStringToTicks(string timeString)
	{
		return TimeSpan.Parse(timeString).Ticks;
	}

	public static void SetSize(Form form, string windowSize)
	{
		int x = Convert.ToInt32(windowSize.Split(';')[0]);
		int y = Convert.ToInt32(windowSize.Split(';')[1]);

		int defaultX = Convert.ToInt32(MinimumDefaultWindowSize.Split(';')[0]);
		int defaultY = Convert.ToInt32(MinimumDefaultWindowSize.Split(';')[1]);

		if (x > Screen.PrimaryScreen.Bounds.Width || y > Screen.PrimaryScreen.Bounds.Height)
		{
			form.WindowState = FormWindowState.Maximized;
			return;
		}

		if (x >= defaultX && y >= defaultY)
		{
			form.Size = new Size(x, y);
		}
	}

	public static string TempPath
	{
		get
		{
			string tempPath = @"C:\Temp";
			string envTempPath = Environment.GetEnvironmentVariable("TEMP");

			if (envTempPath != null)
			{
				tempPath = envTempPath;
			}

			if (!Directory.Exists(tempPath))
			{
				Directory.CreateDirectory(tempPath);
			}

			if (tempPath.Substring(tempPath.Length - 1, 1) == @"\")
			{
				tempPath = tempPath.Substring(0, tempPath.Length - 1);
			}

			return tempPath;
		}
	}

	public static string IntegerListToString(List<int> integerList)
	{
		if (integerList == null)
		{
			return "";
		}

		StringBuilder stringBuilder = new StringBuilder();

		for (int i = 0; i < integerList.Count; i++)
		{
			stringBuilder.Append(string.Format("{0}", integerList[i]));

			if (i != integerList.Count - 1)
			{
				stringBuilder.Append(",");
			}
		}

		return stringBuilder.ToString();
	}

	public static List<int> StringToIntegerList(string traceColumns)
	{
		if (traceColumns == "")
		{
			return null;
		}

		List<int> integerList = new List<int>();

		foreach (string traceColumn in traceColumns.Split(','))
		{
			integerList.Add(Convert.ToInt32(traceColumn));
		}

		return integerList;
	}

	public static string DateTimeToString(DateTime dateTime)
	{
		return dateTime.ToString("yyyy-MM-ddTHH:mm:ss.fff");
	}

	public static string FormatTimeSpan(TimeSpan timeSpan, bool includeMilliseconds)
	{
		string hours = timeSpan.Hours.ToString();
		string minutes = timeSpan.Minutes.ToString();
		string seconds = timeSpan.Seconds.ToString();
		string milliseconds = timeSpan.Milliseconds.ToString();

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

		if (milliseconds.Length == 1)
		{
			milliseconds = string.Format("00{0}", milliseconds);
		}
		else if (milliseconds.Length == 2)
		{
			milliseconds = string.Format("0{0}", milliseconds);
		}

		if (includeMilliseconds)
		{
			return string.Format("{0}:{1}:{2}.{3}", hours, minutes, seconds, milliseconds);
		}
		else
		{
			return string.Format("{0}:{1}:{2}", hours, minutes, seconds);
		}
	}

	public static string FormatDateTime(DateTime dateTime, bool includeMilliseconds)
	{
		string hours = dateTime.Hour.ToString();
		string minutes = dateTime.Minute.ToString();
		string seconds = dateTime.Second.ToString();
		string milliseconds = dateTime.Millisecond.ToString();

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

		if (milliseconds.Length == 1)
		{
			milliseconds = string.Format("00{0}", milliseconds);
		}
		else if (milliseconds.Length == 2)
		{
			milliseconds = string.Format("0{0}", milliseconds);
		}

		if (includeMilliseconds)
		{
			return string.Format("{0}:{1}:{2}.{3}", hours, minutes, seconds, milliseconds);
		}
		else
		{
			return string.Format("{0}:{1}:{2}", hours, minutes, seconds);
		}
	}
}
