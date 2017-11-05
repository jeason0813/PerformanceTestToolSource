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
using System.Threading;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

public partial class ErrorForm : Form
{
	private int _errorNumber;

	public ErrorForm(int errorNumber, string okButtonText, string message, string sql, string location)
	{
		InitializeComponent();
		Initialize(errorNumber, okButtonText, message, sql, location);
	}

	private void Initialize(int errorNumber, string okButtonText, string message, string sql, string location)
	{
		Text = string.Format("{0} - Error", GenericHelper.ApplicationName);

		MinimumSize = new Size(400, 455);  // error in .NET

		if (errorNumber != -1)
		{
			doNotShowAgainCheckBox.Visible = true;
			_errorNumber = errorNumber;
		}

		okButton.Text = okButtonText;

		infoTextBox.SetHighlighting("SQL");
		infoTextBox.Document.HighlightingStrategy = HighlightingManager.Manager.FindHighlighter("SQL");

		infoTextBox.TextEditorProperties.Font = new Font(ConfigHandler.EditorFontFamily, float.Parse(ConfigHandler.EditorFontSize));
		infoTextBox.Font = new Font(ConfigHandler.EditorFontFamily, float.Parse(ConfigHandler.EditorFontSize));

		locationTextBox.Text = location;
		errorTextBox.Text = message;
		infoTextBox.Text = sql;
	}

	private void OkButton_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void CopyButton_Click(object sender, EventArgs e)
	{
		Thread newThread = new Thread(ThreadMethod);
		newThread.SetApartmentState(ApartmentState.STA);

		string copy = string.Format("/*\r\n{2}\r\n\r\nError:\r\n\r\n{0}\r\n*/\r\n\r\n{1}", errorTextBox.Text, infoTextBox.Text, locationTextBox.Text);
		newThread.Start(copy);
	}

	private static void ThreadMethod(object text)
	{
		Clipboard.SetText(text.ToString());
	}

	private void ErrorTextBox_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.Control && e.KeyCode == Keys.A)
		{
			errorTextBox.SelectAll();
		}
	}

	private void ErrorTextBox_Enter(object sender, EventArgs e)
	{
		errorTextBox.SelectionStart = 0;
		errorTextBox.SelectionLength = 0;
	}

	private void LocationTextBox_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.Control && e.KeyCode == Keys.A)
		{
			locationTextBox.SelectAll();
		}
	}

	private void LocationTextBox_Enter(object sender, EventArgs e)
	{
		locationTextBox.SelectionStart = 0;
		locationTextBox.SelectionLength = 0;
	}

	private void ErrorForm_Shown(object sender, EventArgs e)
	{
		Activate();
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		if (infoTextBox.ActiveTextAreaControl.TextArea.Focused)
		{
			if ((int)keyData == 131137) // Keys.Control && Keys.A
			{
				SelectAll();
				return true;
			}
		}

		return base.ProcessCmdKey(ref msg, keyData);
	}

	private void ToolStripMenuItemUndo_Click(object sender, EventArgs e)
	{
		infoTextBox.Undo();
	}

	private void ToolStripMenuItemRedo_Click(object sender, EventArgs e)
	{
		infoTextBox.Redo();
	}

	private void ToolStripMenuItemCut_Click(object sender, EventArgs e)
	{
		infoTextBox.ActiveTextAreaControl.TextArea.ClipboardHandler.Cut(sender, e);
	}

	private void ToolStripMenuItemCopy_Click(object sender, EventArgs e)
	{
		infoTextBox.ActiveTextAreaControl.TextArea.ClipboardHandler.Copy(sender, e);
	}

	private void ToolStripMenuItemPaste_Click(object sender, EventArgs e)
	{
		infoTextBox.ActiveTextAreaControl.TextArea.ClipboardHandler.Paste(sender, e);
	}

	private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
	{
		infoTextBox.ActiveTextAreaControl.TextArea.ClipboardHandler.Delete(sender, e);
	}

	private void ToolStripMenuItemSelectAll_Click(object sender, EventArgs e)
	{
		SelectAll();
	}

	private void SelectAll()
	{
		TextLocation startPosition = new TextLocation(0, 0);

		int textLength = infoTextBox.ActiveTextAreaControl.Document.TextLength;
		TextLocation endPosition = new TextLocation();
		endPosition.Column = infoTextBox.Document.OffsetToPosition(textLength).Column;
		endPosition.Line = infoTextBox.Document.OffsetToPosition(textLength).Line;

		infoTextBox.ActiveTextAreaControl.SelectionManager.SetSelection(startPosition, endPosition);
		infoTextBox.ActiveTextAreaControl.Caret.Position = endPosition;
	}

	private void ContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
	{
		if (infoTextBox.Document.UndoStack.CanUndo)
		{
			toolStripMenuItemUndo.Enabled = true;
		}
		else
		{
			toolStripMenuItemUndo.Enabled = false;
		}

		if (infoTextBox.Document.UndoStack.CanRedo)
		{
			toolStripMenuItemRedo.Enabled = true;
		}
		else
		{
			toolStripMenuItemRedo.Enabled = false;
		}
	}

	private void ErrorForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (doNotShowAgainCheckBox.Checked)
		{
			ConfigHandler.IgnoreErrors = string.Format("{0};{1}", ConfigHandler.IgnoreErrors, _errorNumber);
			ConfigHandler.SaveConfig();
		}
	}
}
