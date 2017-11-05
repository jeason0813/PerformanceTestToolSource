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
public partial class AboutForm : Form
{
	public AboutForm()
	{
		InitializeComponent();
		Initialize();
	}

	private void Initialize()
	{
		Text = string.Format("{0} - About", GenericHelper.ApplicationName);
		infoTextBox.Text = string.Format("{0}\r\nCopyright © Lars Hove Christiansen 2017\r\nVersion {1}", GenericHelper.ApplicationName, GenericHelper.Version);
		infoTextBox.GotFocus += InfoTextBox_GotFocus;
	}

	private void InfoTextBox_Enter(object sender, EventArgs e)
	{
		infoTextBox.SelectionStart = 0;
		infoTextBox.SelectionLength = 0;
		GenericHelper.HideCaret(infoTextBox);
	}

	private void InfoTextBox_GotFocus(object sender, EventArgs e)
	{
		infoTextBox.SelectionStart = 0;
		infoTextBox.SelectionLength = 0;
		GenericHelper.HideCaret(infoTextBox);
	}

	private void InfoTextBox_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.Control && e.KeyCode == Keys.A)
		{
			infoTextBox.SelectAll();
		}
	}

	private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		System.Diagnostics.Process.Start("http://virtcore.com");
	}

	private void MailLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		System.Diagnostics.Process.Start("mailto:info@virtcore.com");
	}
}
