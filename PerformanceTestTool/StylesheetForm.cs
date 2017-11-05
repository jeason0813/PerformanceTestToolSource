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
using System.IO;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

public partial class StylesheetForm : Form
{
	private bool _textChanged;
	private string _initialNameValue;
	private readonly SearchTextForm _searchForm;
	private bool _caretPositionChangeFromSearch;

	public StylesheetForm()
	{
		InitializeComponent();
		Initialize();

		_searchForm = new SearchTextForm();

		SetCreateValues();
		InitializeSearch();
	}

	public StylesheetForm(Stylesheet stylesheet)
	{
		InitializeComponent();
		Initialize();

		_searchForm = new SearchTextForm();

		SetEditValues(stylesheet);
		InitializeSearch();

		xslTextBox.Select();
	}

	public Stylesheet GetValue()
	{
		return new Stylesheet(nameTextBox.Text, descriptionTextBox.Text, xslTextBox.Text, enabledCheckBox.Checked, outputFormatComboBox.SelectedItem.ToString());
	}

	private void Initialize()
	{
		GenericHelper.SetSize(this, ConfigHandler.EditWindowSize);
		MinimumSize = new Size(700, 500);  // error in .NET

		wordWrapToolStripMenuItem.Checked = Convert.ToBoolean(ConfigHandler.WordWrap);
		descriptionTextBox.WordWrap = Convert.ToBoolean(ConfigHandler.WordWrap);

		IHighlightingStrategy highlightingStrategy = HighlightingManager.Manager.FindHighlighter("XML");

		HighlightColor highlightColor = new HighlightColor(Color.Black, Color.WhiteSmoke, false, false);
		((DefaultHighlightingStrategy)highlightingStrategy).SetColorFor("Default", highlightColor);
		((DefaultHighlightingStrategy)highlightingStrategy).SetColorFor("LineNumbers", highlightColor);

		xslTextBox.SetHighlighting("XML");
		xslTextBox.Document.HighlightingStrategy = highlightingStrategy;

		xslTextBox.TextEditorProperties.Font = new Font(ConfigHandler.EditorFontFamily, float.Parse(ConfigHandler.EditorFontSize));
		xslTextBox.Font = new Font(ConfigHandler.EditorFontFamily, float.Parse(ConfigHandler.EditorFontSize));
	}

	private void InitializeSearch()
	{
		xslTextBox.ActiveTextAreaControl.Caret.PositionChanged += Caret_PositionChanged;
		_searchForm.SearchEvent += SearchForm_SearchEvent;
	}

	private void Caret_PositionChanged(object sender, EventArgs e)
	{
		Caret caret = (Caret)sender;

		if (!_caretPositionChangeFromSearch)
		{
			_searchForm.Reset(caret.Offset);
		}
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		if (xslTextBox.ActiveTextAreaControl.TextArea.Focused)
		{
			if ((int)keyData == 131137) // Keys.Control && Keys.A
			{
				SelectAll();
				return true;
			}

			if (keyData == Keys.Escape)
			{
				Close();
			}
		}

		return base.ProcessCmdKey(ref msg, keyData);
	}

	private void SetCreateValues()
	{
		Text = string.Format("{0} - Create Stylesheet", GenericHelper.ApplicationName);
		outputFormatComboBox.SelectedItem = "Html";
		enabledCheckBox.Checked = true;

		_textChanged = false;
	}

	private void SetEditValues(Stylesheet stylesheet)
	{
		Text = string.Format("{0} - Edit Stylesheet", GenericHelper.ApplicationName);
		nameTextBox.Text = stylesheet.Name;
		descriptionTextBox.Text = stylesheet.Description;
		xslTextBox.Text = stylesheet.Xslt;
		enabledCheckBox.Checked = stylesheet.Enabled;

		nameTextBox.SelectionStart = nameTextBox.Text.Length;
		nameTextBox.SelectionLength = 0;

		outputFormatComboBox.SelectedItem = stylesheet.OutputFormat;

		_textChanged = false;
		_initialNameValue = stylesheet.Name.ToLower();
	}

	private void NameTextBox_TextChanged(object sender, EventArgs e)
	{
		_textChanged = true;
	}

	private void OkButton_Click(object sender, EventArgs e)
	{
		Save();
	}

	private bool Save()
	{
		if (StylesheetHelper.UniqueStylesheetName(nameTextBox.Text, _initialNameValue))
		{
			if (ValidXslt(xslTextBox.Text))
			{
				if (_textChanged)
				{
					DialogResult = DialogResult.OK;
				}
				else
				{
					DialogResult = DialogResult.Cancel;
				}

				_textChanged = false;
				return true;
			}
		}
		else
		{
			nameTextBox.Focus();
		}

		return false;
	}

	private bool ValidXslt(string xslt)
	{
		if (xslt.Trim() == "")
		{
			MessageBox.Show("XSL can't be empty.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			xslTextBox.Focus();
			return false;
		}

		return true;
	}

	private void WordWrapToolStripMenuItem_Click(object sender, EventArgs e)
	{
		descriptionTextBox.WordWrap = wordWrapToolStripMenuItem.Checked;
		ConfigHandler.WordWrap = wordWrapToolStripMenuItem.Checked.ToString();
		ConfigHandler.SaveConfig();
	}

	private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
	{
		_textChanged = true;
	}

	private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void DescriptionTextBox_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control)
		{
			descriptionTextBox.SelectAll();
		}
	}

	private void FontToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			fontDialog1.Font = xslTextBox.TextEditorProperties.Font;
			fontDialog1.ShowDialog();

			if (fontDialog1.Font.Bold || fontDialog1.Font.Italic)
			{
				MessageBox.Show("Bold and Italic fonts are not supported.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			xslTextBox.TextEditorProperties.Font = fontDialog1.Font;
			xslTextBox.Font = fontDialog1.Font;
			xslTextBox.ActiveTextAreaControl.TextArea.Refresh();

			string familyName = fontDialog1.Font.FontFamily.Name;
			string size = fontDialog1.Font.Size.ToString();

			ConfigHandler.EditorFontFamily = familyName;
			ConfigHandler.EditorFontSize = size;

			ConfigHandler.SaveConfig();
		}
		catch
		{
			MessageBox.Show("New fonts added to Windows while Performance Test Tool is running can't be added due to an error in Windows.\r\n\r\nTo add this font, restart Performance Test Tool.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}

	private void HandleForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (_textChanged)
		{
			DialogResult result = MessageBox.Show("Save changes?", GenericHelper.ApplicationName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

			if (result.ToString() == "Yes")
			{
				bool closeWindow = Save();

				if (!closeWindow)
				{
					e.Cancel = true;
				}
			}
			else if (result.ToString() == "Cancel")
			{
				e.Cancel = true;
			}
		}

		_searchForm.Close();
	}

	private void Form_Resize(object sender, EventArgs e)
	{
		if (Width < MinimumSize.Width || Width == 0)
		{
			return;
		}

		ConfigHandler.EditWindowSize = string.Format("{0}; {1}", Size.Width, Size.Height);
		ConfigHandler.SaveConfig();

		splitContainer1.SplitterDistance++;
		splitContainer1.SplitterDistance--;
		splitContainer1.Invalidate();
	}

	private void XslTextBox_TextChanged(object sender, EventArgs e)
	{
		_textChanged = true;
		_searchForm.SetSearchText(xslTextBox.Text);
		_searchForm.Reset(xslTextBox.ActiveTextAreaControl.Caret.Offset);
	}

	private void ToolStripMenuItemUndo_Click(object sender, EventArgs e)
	{
		xslTextBox.Undo();
	}

	private void ToolStripMenuItemRedo_Click(object sender, EventArgs e)
	{
		xslTextBox.Redo();
	}

	private void ToolStripMenuItemCut_Click(object sender, EventArgs e)
	{
		xslTextBox.ActiveTextAreaControl.TextArea.ClipboardHandler.Cut(sender, e);
	}

	private void ToolStripMenuItemCopy_Click(object sender, EventArgs e)
	{
		xslTextBox.ActiveTextAreaControl.TextArea.ClipboardHandler.Copy(sender, e);
	}

	private void ToolStripMenuItemPaste_Click(object sender, EventArgs e)
	{
		xslTextBox.ActiveTextAreaControl.TextArea.ClipboardHandler.Paste(sender, e);
	}

	private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
	{
		xslTextBox.ActiveTextAreaControl.TextArea.ClipboardHandler.Delete(sender, e);
	}

	private void ToolStripMenuItemSelectAll_Click(object sender, EventArgs e)
	{
		SelectAll();
	}

	private void ContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
	{
		if (xslTextBox.Document.UndoStack.CanUndo)
		{
			toolStripMenuItemUndo.Enabled = true;
		}
		else
		{
			toolStripMenuItemUndo.Enabled = false;
		}

		if (xslTextBox.Document.UndoStack.CanRedo)
		{
			toolStripMenuItemRedo.Enabled = true;
		}
		else
		{
			toolStripMenuItemRedo.Enabled = false;
		}
	}

	private void EnabledCheckBox_CheckedChanged(object sender, EventArgs e)
	{
		_textChanged = true;
	}

	private void OutputFormatComboBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		_textChanged = true;
	}

	private void ImportStylesheetToolStripMenuItem_Click(object sender, EventArgs e)
	{
		DialogResult result = openFileDialog1.ShowDialog();

		if (result.ToString() == "OK")
		{
			Application.DoEvents();
			xslTextBox.Text = XmlHelper.ReadXmlFromFile(openFileDialog1.FileName);
		}
	}

	private void ExportStylesheetToolStripMenuItem_Click(object sender, EventArgs e)
	{
		DialogResult result = saveFileDialog1.ShowDialog();

		if (result.ToString() == "OK")
		{
			Application.DoEvents();

			try
			{
				File.WriteAllText(saveFileDialog1.FileName, xslTextBox.Text, Encoding.UTF8);
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("Error writing Stylesheet to file.\r\n\r\n{0}", ex.Message), GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
	}

	private void DescriptionTextBox_Enter(object sender, EventArgs e)
	{
		descriptionTextBox.SelectionStart = 0;
		descriptionTextBox.SelectionLength = 0;
	}

	private void SplitContainer1_Paint(object sender, PaintEventArgs e)
	{
		SplitContainerGrip.PaintGrip(sender, e);
	}

	private void SplitContainer1_MouseUp(object sender, MouseEventArgs e)
	{
		if (splitContainer1.CanFocus)
		{
			ActiveControl = okButton;
		}
	}

	private void FindToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (_searchForm.IsShown())
		{
			_searchForm.Activate();
		}
		else
		{
			if (xslTextBox.ActiveTextAreaControl.SelectionManager.HasSomethingSelected)
			{
				if (!xslTextBox.ActiveTextAreaControl.SelectionManager.SelectedText.Contains("\r"))
				{
					_searchForm.SetSearchTerm(xslTextBox.ActiveTextAreaControl.SelectionManager.SelectedText);
				}
			}

			_searchForm.Hide();
			_searchForm.Show(this);
		}
	}

	private void SearchForm_SearchEvent(int foundIndex, string searchTerm)
	{
		_caretPositionChangeFromSearch = true;

		TextLocation startPosition = xslTextBox.Document.OffsetToPosition(foundIndex);
		TextLocation endPosition = xslTextBox.Document.OffsetToPosition(foundIndex + searchTerm.Length);

		xslTextBox.ActiveTextAreaControl.SelectionManager.SetSelection(startPosition, endPosition);
		xslTextBox.ActiveTextAreaControl.CenterViewOn(xslTextBox.Document.GetLineNumberForOffset(foundIndex), 0);

		xslTextBox.ActiveTextAreaControl.Caret.Line = endPosition.Line;
		xslTextBox.ActiveTextAreaControl.Caret.Column = endPosition.Column;

		_caretPositionChangeFromSearch = false;
	}

	private void SelectAll()
	{
		TextLocation startPosition = new TextLocation(0, 0);

		int textLength = xslTextBox.ActiveTextAreaControl.Document.TextLength;
		TextLocation endPosition = new TextLocation();
		endPosition.Column = xslTextBox.Document.OffsetToPosition(textLength).Column;
		endPosition.Line = xslTextBox.Document.OffsetToPosition(textLength).Line;

		xslTextBox.ActiveTextAreaControl.SelectionManager.SetSelection(startPosition, endPosition);
		xslTextBox.ActiveTextAreaControl.Caret.Position = endPosition;
	}

	private void EditToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
	{
		if (xslTextBox.Document.UndoStack.CanUndo)
		{
			undoToolStripMenuItem.Enabled = true;
		}
		else
		{
			undoToolStripMenuItem.Enabled = false;
		}

		if (xslTextBox.Document.UndoStack.CanRedo)
		{
			redoToolStripMenuItem.Enabled = true;
		}
		else
		{
			redoToolStripMenuItem.Enabled = false;
		}
	}

	private void CutToolStripMenuItem_Click(object sender, EventArgs e)
	{
		xslTextBox.ActiveTextAreaControl.TextArea.ClipboardHandler.Cut(sender, e);
	}

	private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
	{
		xslTextBox.ActiveTextAreaControl.TextArea.ClipboardHandler.Copy(sender, e);
	}

	private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
	{
		xslTextBox.ActiveTextAreaControl.TextArea.ClipboardHandler.Paste(sender, e);
	}

	private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
	{
		xslTextBox.ActiveTextAreaControl.TextArea.ClipboardHandler.Delete(sender, e);
	}

	private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
	{
		SelectAll();
	}

	private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
	{
		xslTextBox.Undo();
	}

	private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
	{
		xslTextBox.Redo();
	}
}
