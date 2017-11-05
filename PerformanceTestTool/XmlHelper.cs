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
using System.Text;
using System.Windows.Forms;
using System.Xml;

public static class XmlHelper
{
	public static string ReadXmlFromFile(string fileName)
	{
		try
		{
			if (File.Exists(fileName))
			{
				return File.ReadAllText(fileName, Encoding.UTF8);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(string.Format("Error reading Xml from file.\r\n\r\n{0}", ex.Message), GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		return null;
	}

	public static void WriteXmlToFile(string xml, string fileName)
	{
		try
		{
			if (File.Exists(fileName))
			{
				File.Delete(fileName);
			}

			XmlDocument xmlDocument = FormatXml(xml);
			xmlDocument.LoadXml(xml);

			XmlTextWriter xmlTextWriter = new XmlTextWriter(fileName, Encoding.UTF8);
			xmlTextWriter.IndentChar = '\t';
			xmlTextWriter.Indentation = 1;
			xmlTextWriter.Formatting = Formatting.Indented;
			xmlDocument.WriteContentTo(xmlTextWriter);

			xmlTextWriter.Flush();
			xmlTextWriter.Close();
		}
		catch (Exception ex)
		{
			MessageBox.Show(string.Format("Error writing Xml to file.\r\n\r\n{0}", ex.Message), GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
	}

	private static XmlDocument FormatXml(string xml)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(xml);

		XmlNodeList xmlNodeList = xmlDocument.SelectNodes("//*[. = '' and count(*) = 0]");

		if (xmlNodeList != null)
		{
			foreach (XmlElement xmlElement in xmlNodeList)
			{
				xmlElement.IsEmpty = true;
			}
		}

		return xmlDocument;
	}
}
