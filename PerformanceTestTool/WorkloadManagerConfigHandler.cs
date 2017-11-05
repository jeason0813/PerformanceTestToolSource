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

public static class WorkloadManagerConfigHandler
{
	public static string WorkloadManagerTaskCollectionPath;
	public static string WorkloadManagerStylesheetCollectionPath;
	public static string WorkloadManagerHiddenMode;
	public static string WorkloadManagerCustomTaskCollection;
	public static string WorkloadManagerCustomStylesheetCollection;
	public static string WorkloadManagerRuns;
	public static string WorkloadManagerTimeBetweenRuns;
	public static string WorkloadManagerIncludeResultXml;
	public static string WorkloadManagerIncludeTransformedStylesheets;
	public static string WorkloadManagerLogDirectory;

	public static void SaveConfig()
	{
		RegistryHandler.SaveToRegistry("WorkloadManagerTaskCollectionPath", WorkloadManagerTaskCollectionPath);
		RegistryHandler.SaveToRegistry("WorkloadManagerStylesheetCollectionPath", WorkloadManagerStylesheetCollectionPath);
		RegistryHandler.SaveToRegistry("WorkloadManagerHiddenMode", WorkloadManagerHiddenMode);
		RegistryHandler.SaveToRegistry("WorkloadManagerCustomTaskCollection", WorkloadManagerCustomTaskCollection);
		RegistryHandler.SaveToRegistry("WorkloadManagerCustomStylesheetCollection", WorkloadManagerCustomStylesheetCollection);
		RegistryHandler.SaveToRegistry("WorkloadManagerRuns", WorkloadManagerRuns);
		RegistryHandler.SaveToRegistry("WorkloadManagerTimeBetweenRuns", WorkloadManagerTimeBetweenRuns);
		RegistryHandler.SaveToRegistry("WorkloadManagerIncludeResultXml", WorkloadManagerIncludeResultXml);
		RegistryHandler.SaveToRegistry("WorkloadManagerIncludeTransformedStylesheets", WorkloadManagerIncludeTransformedStylesheets);
		RegistryHandler.SaveToRegistry("WorkloadManagerLogDirectory", WorkloadManagerLogDirectory);
	}

	public static void LoadConfig()
	{
		WorkloadManagerTaskCollectionPath = RegistryHandler.ReadFromRegistry("WorkloadManagerTaskCollectionPath");
		WorkloadManagerStylesheetCollectionPath = RegistryHandler.ReadFromRegistry("WorkloadManagerStylesheetCollectionPath");

		WorkloadManagerHiddenMode = RegistryHandler.ReadFromRegistry("WorkloadManagerHiddenMode");

		if (WorkloadManagerHiddenMode == "")
		{
			WorkloadManagerHiddenMode = "True";
		}

		WorkloadManagerCustomTaskCollection = RegistryHandler.ReadFromRegistry("WorkloadManagerCustomTaskCollection");

		if (WorkloadManagerCustomTaskCollection == "")
		{
			WorkloadManagerCustomTaskCollection = "False";
		}

		WorkloadManagerCustomStylesheetCollection = RegistryHandler.ReadFromRegistry("WorkloadManagerCustomStylesheetCollection");

		if (WorkloadManagerCustomStylesheetCollection == "")
		{
			WorkloadManagerCustomStylesheetCollection = "False";
		}

		WorkloadManagerRuns = RegistryHandler.ReadFromRegistry("WorkloadManagerRuns");

		if (WorkloadManagerRuns == "")
		{
			WorkloadManagerRuns = "1";
		}

		WorkloadManagerTimeBetweenRuns = RegistryHandler.ReadFromRegistry("WorkloadManagerTimeBetweenRuns");

		if (WorkloadManagerTimeBetweenRuns == "")
		{
			WorkloadManagerTimeBetweenRuns = "0";
		}

		WorkloadManagerIncludeResultXml = RegistryHandler.ReadFromRegistry("WorkloadManagerIncludeResultXml");

		if (WorkloadManagerIncludeResultXml == "")
		{
			WorkloadManagerIncludeResultXml = "False";
		}

		WorkloadManagerIncludeTransformedStylesheets = RegistryHandler.ReadFromRegistry("WorkloadManagerIncludeTransformedStylesheets");

		if (WorkloadManagerIncludeTransformedStylesheets == "")
		{
			WorkloadManagerIncludeTransformedStylesheets = "False";
		}

		WorkloadManagerLogDirectory = RegistryHandler.ReadFromRegistry("WorkloadManagerLogDirectory");

		if (WorkloadManagerLogDirectory == "")
		{
			WorkloadManagerLogDirectory = @"C:\MyLogDir";
		}
	}
}
