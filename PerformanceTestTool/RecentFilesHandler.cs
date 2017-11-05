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

using System.Collections.Generic;
using System.Windows.Forms;

public static class RecentFilesHandler
{
	public static void AddFileName(ToolStripMenuItem toolStripMenuItem, string fileName, string registryKeyName)
	{
		List<string> existingFilesExceptFromCurrent = new List<string>();

		foreach (ToolStripMenuItem existingFileName in toolStripMenuItem.DropDownItems)
		{
			if (existingFileName.Text != fileName && existingFileName.Text != "empty")
			{
				existingFilesExceptFromCurrent.Add(existingFileName.Text);
			}
		}

		toolStripMenuItem.DropDownItems.Clear();
		toolStripMenuItem.DropDownItems.Add(new ToolStripMenuItem(fileName));

		for (int i = 0; i < existingFilesExceptFromCurrent.Count; i++)
		{
			if (i < GenericHelper.NumberOfRecentFiles - 1 && existingFilesExceptFromCurrent[i] != fileName)
			{
				toolStripMenuItem.DropDownItems.Add(new ToolStripMenuItem(existingFilesExceptFromCurrent[i]));
			}
		}

		SaveValuesToRegistry(registryKeyName, toolStripMenuItem);
	}

	public static void LoadMenuItems(ToolStripMenuItem toolStripMenuItem, string registryKeyName)
	{
		toolStripMenuItem.DropDownItems.Clear();

		string[] fileNames = LoadValuesFromRegistry(registryKeyName);

		if (fileNames.Length > 0)
		{
			foreach (string fileName in fileNames)
			{
				toolStripMenuItem.DropDownItems.Add(new ToolStripMenuItem(fileName));
			}
		}
		else
		{
			ToolStripMenuItem emptyToolStripMenuItem = new ToolStripMenuItem("empty");
			emptyToolStripMenuItem.Enabled = false;
			toolStripMenuItem.DropDownItems.Add(emptyToolStripMenuItem);
		}
	}

	private static string[] LoadValuesFromRegistry(string registryKeyName)
	{
		string fileNames = RegistryHandler.ReadFromRegistry(registryKeyName);
		return fileNames.Split(new[] { ';' }, System.StringSplitOptions.RemoveEmptyEntries);
	}

	private static void SaveValuesToRegistry(string registryKeyName, ToolStripMenuItem toolStripMenuItem)
	{
		string fileNames = "";

		foreach (ToolStripMenuItem fileName in toolStripMenuItem.DropDownItems)
		{
			fileNames = string.Format("{0}{1};", fileNames, fileName);
		}

		fileNames = fileNames.Substring(0, fileNames.Length - 1);

		RegistryHandler.SaveToRegistry(registryKeyName, fileNames);
	}
}
