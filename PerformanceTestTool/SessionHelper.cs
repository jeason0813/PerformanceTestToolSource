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

public static class SessionHelper
{
	public static bool EnableLoadLastSessionTaskCollection = true;
	public static bool EnableLoadLastSessionStylesheetCollection = true;

	public static string GetSessionTaskCollectionFileName()
	{
		return string.Format(@"{0}\TaskCollection.xml", GenericHelper.ExecPath);
	}

	public static string GetSessionStylesheetCollectionFileName()
	{
		return string.Format(@"{0}\StylesheetCollection.xml", GenericHelper.ExecPath);
	}

	public static void SaveSession()
	{
		if (TaskHelper.TaskCollectionFileName == null || TaskHelper.TaskCollectionFileName == GetSessionTaskCollectionFileName())
		{
			TaskHelper.TaskCollectionFileName = GetSessionTaskCollectionFileName();
			TaskHelper.SaveTaskCollection(TaskHelper.TaskCollectionFileName);
		}

		RegistryHandler.SaveToRegistry("TaskCollectionFileName", TaskHelper.TaskCollectionFileName);

		if (StylesheetHelper.StylesheetCollectionFileName == null || StylesheetHelper.StylesheetCollectionFileName == GetSessionStylesheetCollectionFileName())
		{
			StylesheetHelper.StylesheetCollectionFileName = GetSessionStylesheetCollectionFileName();
			StylesheetHelper.SaveStylesheetCollection(StylesheetHelper.StylesheetCollectionFileName);
		}

		RegistryHandler.SaveToRegistry("StylesheetCollectionFileName", StylesheetHelper.StylesheetCollectionFileName);
	}

	public static void LoadLastSession()
	{
		if (EnableLoadLastSessionTaskCollection)
		{
			TaskHelper.TaskCollectionFileName = RegistryHandler.ReadFromRegistry("TaskCollectionFileName");

			if (TaskHelper.TaskCollectionFileName == "")
			{
				TaskHelper.TaskCollectionFileName = null;
			}
			else
			{
				TaskCollection temporaryTaskCollection = TaskHelper.XmlToTaskCollection(XmlHelper.ReadXmlFromFile(TaskHelper.TaskCollectionFileName));

				if (temporaryTaskCollection == null)
				{
					TaskHelper.TaskCollectionFileName = null;
				}
				else
				{
					TaskHelper.TaskCollection = temporaryTaskCollection;
				}
			}
		}

		if (EnableLoadLastSessionStylesheetCollection)
		{
			StylesheetHelper.StylesheetCollectionFileName = RegistryHandler.ReadFromRegistry("StylesheetCollectionFileName");

			if (StylesheetHelper.StylesheetCollectionFileName == "")
			{
				StylesheetHelper.StylesheetCollectionFileName = null;
			}
			else
			{
				StylesheetCollection temporaryStylesheetCollection = StylesheetHelper.XmlToStylesheetCollection(XmlHelper.ReadXmlFromFile(StylesheetHelper.StylesheetCollectionFileName));

				if (StylesheetHelper.StylesheetCollection == null)
				{
					StylesheetHelper.StylesheetCollectionFileName = null;
				}
				else
				{
					StylesheetHelper.StylesheetCollection = temporaryStylesheetCollection;
				}
			}
		}
	}
}
