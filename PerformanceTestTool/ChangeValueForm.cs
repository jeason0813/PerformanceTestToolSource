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

public partial class ChangeValueForm : Form
{
	private readonly string _name;
	private readonly bool _allowZero;
	private bool _success;
	private int _newIntegerValue;
	private string _newStringValue;
	private readonly GenericHelper.CheckValue _checkValue;
	private readonly string _initialNameValue;

	public ChangeValueForm(string name, bool allowZero)
	{
		InitializeComponent();
		_name = name;
		_checkValue = GenericHelper.CheckValue.Integer;
		_allowZero = allowZero;
		Initialize();
	}

	public ChangeValueForm(string name, GenericHelper.CheckValue checkValue, string initialNameValue)
	{
		InitializeComponent();
		_name = name;
		_checkValue = checkValue;
		_initialNameValue = initialNameValue;
		newValueTextBox.Text = initialNameValue;
		Initialize();
	}

	public bool GetSuccess()
	{
		return _success;
	}

	public int GetNewIntegerValue()
	{
		return _newIntegerValue;
	}

	public string GetNewStringValue()
	{
		return _newStringValue;
	}

	private void Initialize()
	{
		Text = string.Format("{0} - Change value(s)", GenericHelper.ApplicationName);
		changeValuesHeaderLabel.Text = string.Format("::: {0} :::::::", _name);
	}

	private void OkButton_Click(object sender, EventArgs e)
	{
		CheckValues();

		if (_success)
		{
			Close();
		}
		else
		{
			newValueTextBox.Focus();
		}
	}

	private void CheckValues()
	{
		if (_checkValue == GenericHelper.CheckValue.Integer)
		{
			_success = CheckIntegerValue();

			if (_success)
			{
				_newIntegerValue = Convert.ToInt32(newValueTextBox.Text);
			}
		}
		else if (_checkValue == GenericHelper.CheckValue.TaskName)
		{
			_success = TaskHelper.UniqueTaskName(newValueTextBox.Text, _initialNameValue);

			if (_success)
			{
				_newStringValue = newValueTextBox.Text;
			}
		}
		else if (_checkValue == GenericHelper.CheckValue.StylesheetName)
		{
			_success = StylesheetHelper.UniqueStylesheetName(newValueTextBox.Text, _initialNameValue);

			if (_success)
			{
				_newStringValue = newValueTextBox.Text;
			}
		}
	}

	private bool CheckIntegerValue()
	{
		try
		{
			int newValue = Convert.ToInt32(newValueTextBox.Text);

			if (_allowZero)
			{
				if (newValue < 0)
				{
					MessageBox.Show(string.Format("{0} must be equal to or greater than 0.", _name), GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}
			}
			else
			{
				if (newValue <= 0)
				{
					MessageBox.Show(string.Format("{0} must be greater than 0.", _name), GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}
			}
		}
		catch
		{
			MessageBox.Show(string.Format("{0} is not a valid number.", _name), GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			return false;
		}

		return true;
	}
}
