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
using System.Text;
using System.Windows.Forms;
using System.Xml;

public static class StylesheetHelper
{
	public static string StylesheetCollectionFileName;

	private static StylesheetCollection _stylesheetCollection;

	public static string GetNewItemName(string name)
	{
		bool uniqueName;

		do
		{
			uniqueName = true;

			foreach (Stylesheet item in StylesheetCollection.Stylesheets)
			{
				if (item.Name == name)
				{
					uniqueName = false;
					break;
				}
			}

			if (!uniqueName)
			{
				name = string.Format("{0} (copy)", name);
			}
		} while (!uniqueName);

		return name;
	}

	public static void SaveStylesheetCollection(string fileName)
	{
		XmlHelper.WriteXmlToFile(StylesheetCollectionToXml(StylesheetCollection), fileName);
	}

	public static StylesheetCollection StylesheetCollection
	{
		get
		{
			if (_stylesheetCollection == null)
			{
				_stylesheetCollection = new StylesheetCollection();
			}

			return _stylesheetCollection;
		}
		set
		{
			_stylesheetCollection = value;
		}
	}

	public static string StylesheetCollectionToXml(StylesheetCollection stylesheetCollection)
	{
		if (stylesheetCollection.Stylesheets == null)
		{
			return "";
		}

		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
		stringBuilder.Append(string.Format("<stylesheets description=\"{0}\">", System.Security.SecurityElement.Escape(stylesheetCollection.Description)));

		foreach (Stylesheet stylesheet in stylesheetCollection.Stylesheets)
		{
			stringBuilder.Append(string.Format("<stylesheet name=\"{0}\" description=\"{1}\" xsl=\"{2}\" enabled=\"{3}\" outputFormat=\"{4}\" />", System.Security.SecurityElement.Escape(stylesheet.Name), System.Security.SecurityElement.Escape(stylesheet.Description), System.Security.SecurityElement.Escape(stylesheet.Xslt), stylesheet.Enabled, stylesheet.OutputFormat));
		}

		stringBuilder.Append("</stylesheets>");
		return stringBuilder.ToString();
	}

	public static StylesheetCollection XmlToStylesheetCollection(string xml)
	{
		if (string.IsNullOrEmpty(xml))
		{
			return null;
		}

		StylesheetCollection stylesheetCollection = new StylesheetCollection();

		try
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xml);

			XmlNode stylesheetsNode = xmlDocument.SelectSingleNode("/stylesheets");
			XmlNodeList stylesheetNodes = xmlDocument.SelectNodes("/stylesheets/stylesheet");

			foreach (XmlElement stylesheetNode in stylesheetNodes)
			{
				string name = stylesheetNode.Attributes["name"].Value;
				string description = stylesheetNode.Attributes["description"].Value;
				string xslt = stylesheetNode.Attributes["xsl"].Value;
				bool enabled = Convert.ToBoolean(stylesheetNode.Attributes["enabled"].Value);
				string outputFormat = stylesheetNode.Attributes["outputFormat"].Value;

				Stylesheet stylesheet = new Stylesheet(name, description, xslt, enabled, outputFormat);
				stylesheetCollection.Stylesheets.Add(stylesheet);
			}

			stylesheetCollection.Description = stylesheetsNode.Attributes["description"].Value;
		}
		catch (Exception ex)
		{
			if (ex.Message == "Object reference not set to an instance of an object.")
			{
				MessageBox.Show("Stylesheet Collection file is missing one or more elements.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				MessageBox.Show(string.Format("Error in converting Xml to stylesheets.\r\n\r\n{0}", ex.Message), GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

			return null;
		}

		if (!UniqueNames(stylesheetCollection))
		{
			MessageBox.Show("Stylesheet Names are not unique.,", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			return null;
		}

		return stylesheetCollection;
	}

	public static bool UniqueStylesheetName(string name, string initialNameValue)
	{
		if (name.Trim() == "")
		{
			MessageBox.Show("Name can't be empty.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			return false;
		}

		foreach (Stylesheet item in StylesheetCollection.Stylesheets)
		{
			if (name.Trim().ToLower() == item.Name.ToLower() && initialNameValue.ToLower() != name.Trim().ToLower())
			{
				MessageBox.Show("Another stylesheet with the same name already exists.\r\n\r\nStylesheet names must be unique.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
		}

		return true;
	}

	private static bool UniqueNames(StylesheetCollection stylesheetCollection)
	{
		string[] names = new string[stylesheetCollection.Stylesheets.Count];

		for (int i = 0; i < stylesheetCollection.Stylesheets.Count; i++)
		{
			names[i] = stylesheetCollection.Stylesheets[i].Name;
		}

		return GenericHelper.UniqueElements(names);
	}
}
