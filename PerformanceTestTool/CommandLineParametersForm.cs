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
using System.Drawing;
using System.Windows.Forms;

public partial class CommandLineParametersForm : Form
{
	public CommandLineParametersForm()
	{
		InitializeComponent();
		Initialize();
	}

	public void SetCommandSyntaxOptions()
	{
		StartPosition = FormStartPosition.CenterScreen;
		ShowInTaskbar = true;
		closeToolStripMenuItem.Text = "&Exit";
		CancelButton = null;
	}

	private void Initialize()
	{
		Text = string.Format("{0} - Command Line Parameters", GenericHelper.ApplicationName);
		GenericHelper.SetSize(this, ConfigHandler.CommandLineParametersWindowSize);
		MinimumSize = new Size(700, 500);  // error in .NET
		infoTextBox.GotFocus += InfoTextBox_GotFocus;
		infoTextBox.Select();
	}

	private void AboutForm_Resize(object sender, EventArgs e)
	{
		if (Width < MinimumSize.Width || Width == 0)
		{
			return;
		}

		ConfigHandler.CommandLineParametersWindowSize = string.Format("{0}; {1}", Size.Width, Size.Height);
		ConfigHandler.SaveConfig();
	}

	private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Close();
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
}
