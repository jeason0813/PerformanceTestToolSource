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
using Microsoft.Win32;

public static class RegistryHandler
{
	public const string RegistryKey = @"SOFTWARE\Lars Hove Christiansen\PerformanceTestTool\";

	public static void SaveToRegistry(string keyName, string value)
	{
		RegistryKey rk = Registry.LocalMachine;
		RegistryKey sk = rk.CreateSubKey(RegistryKey);

		if (sk != null)
		{
			try
			{
				sk.SetValue(keyName, value);
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("Error saving value to registry.\r\n\r\n{0}", ex.Message), GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
	}

	public static string ReadFromRegistry(string keyName)
	{
		RegistryKey rk = Registry.LocalMachine;
		RegistryKey sk = rk.OpenSubKey(RegistryKey);

		string returnValue = "";

		if (sk != null)
		{
			if (sk.GetValue(keyName) != null)
			{
				returnValue = sk.GetValue(keyName).ToString();
			}
		}

		return returnValue;
	}

	public static void SaveToRegistry(string keyName, string value, RegistryKey rk)
	{
		RegistryKey sk = rk.CreateSubKey(RegistryKey);

		if (sk != null)
		{
			try
			{
				sk.SetValue(keyName, value);
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("Error saving value to registry.\r\n\r\n{0}", ex.Message), GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
	}

	public static string ReadFromRegistry(string keyName, RegistryKey rk)
	{
		RegistryKey sk = rk.OpenSubKey(RegistryKey);

		string returnValue = "";

		if (sk != null)
		{
			if (sk.GetValue(keyName) != null)
			{
				returnValue = sk.GetValue(keyName).ToString();
			}
		}

		return returnValue;
	}

	public static void Delete(string keyName)
	{
		RegistryKey rk = Registry.LocalMachine;
		RegistryKey sk = rk.OpenSubKey(RegistryKey, true);

		if (sk != null)
		{
			try
			{
				if (sk.GetValue(keyName) != null)
				{
					sk.DeleteValue(keyName);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("Error deleting value from registry.\r\n\r\n{0}", ex.Message), GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
	}

	public static void SaveByte(string keyName, byte[] value)
	{
		RegistryKey rk = Registry.LocalMachine;
		RegistryKey sk = rk.CreateSubKey(RegistryKey);

		if (sk != null)
		{
			try
			{
				sk.SetValue(keyName, value, RegistryValueKind.Binary);
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("Error saving value to registry.\r\n\r\n{0}", ex.Message), GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
	}

	public static byte[] ReadByte(string keyName)
	{
		RegistryKey rk = Registry.LocalMachine;
		RegistryKey sk = rk.OpenSubKey(RegistryKey);

		byte[] returnValue = null;

		if (sk != null)
		{
			if (sk.GetValue(keyName) != null)
			{
				returnValue = (byte[])sk.GetValue(keyName);
			}
		}

		return returnValue;
	}
}
