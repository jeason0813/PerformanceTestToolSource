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

public partial class TaskForm : Form
{
	private bool _textChanged;
	private string _initialNameValue;
	private bool _ctrlKPressed;
	private readonly SearchTextForm _searchForm;
	private bool _caretPositionChangeFromSearch;

	public TaskForm()
	{
		InitializeComponent();
		Initialize();

		_searchForm = new SearchTextForm();

		SetCreateValues();
		InitializeSearch();
	}

	public TaskForm(Task task)
	{
		InitializeComponent();
		Initialize();

		_searchForm = new SearchTextForm();

		SetEditValues(task);
		InitializeSearch();

		sqlTextBox.Select();
	}

	public Task GetValue()
	{
		return new Task(nameTextBox.Text, descriptionTextBox.Text, Convert.ToInt32(delayAfterCompletionTextBox.Text), sqlTextBox.Text, TaskHelper.StringToTaskType(((ComboBoxItem)taskTypeComboBox.SelectedItem).Value), enabledCheckBox.Checked, includeInResultsCheckBox.Checked);
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		if (sqlTextBox.ActiveTextAreaControl.TextArea.Focused)
		{
			if (_ctrlKPressed)
			{
				if ((int)keyData == 131139) // Keys.Control && Keys.C
				{
					CommentSelection();
					return true;
				}

				if ((int)keyData == 131157) //Keys.Control && Keys.U
				{
					UnCommentSelection();
					return true;
				}
			}

			if ((int)keyData == 131147) //Keys.Control && Keys.K
			{
				_ctrlKPressed = true;
			}
			else
			{
				_ctrlKPressed = false;
			}

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

	private void Initialize()
	{
		GenericHelper.SetSize(this, ConfigHandler.EditWindowSize);
		MinimumSize = new Size(700, 500);  // error in .NET

		wordWrapToolStripMenuItem.Checked = Convert.ToBoolean(ConfigHandler.WordWrap);
		descriptionTextBox.WordWrap = Convert.ToBoolean(ConfigHandler.WordWrap);

		IHighlightingStrategy highlightingStrategy = HighlightingManager.Manager.FindHighlighter("SQL");

		HighlightColor highlightColor = new HighlightColor(Color.Black, Color.WhiteSmoke, false, false);
		((DefaultHighlightingStrategy)highlightingStrategy).SetColorFor("Default", highlightColor);
		((DefaultHighlightingStrategy)highlightingStrategy).SetColorFor("LineNumbers", highlightColor);

		sqlTextBox.SetHighlighting("SQL");
		sqlTextBox.Document.HighlightingStrategy = highlightingStrategy;

		sqlTextBox.TextEditorProperties.Font = new Font(ConfigHandler.EditorFontFamily, float.Parse(ConfigHandler.EditorFontSize));
		sqlTextBox.Font = new Font(ConfigHandler.EditorFontFamily, float.Parse(ConfigHandler.EditorFontSize));

		TaskHelper.TaskType[] taskTypes = (TaskHelper.TaskType[])Enum.GetValues(typeof(TaskHelper.TaskType));

		foreach (TaskHelper.TaskType taskType in taskTypes)
		{
			taskTypeComboBox.Items.Add(new ComboBoxItem(TaskHelper.TaskTypeToString(taskType), taskType.ToString()));
		}
	}

	private void InitializeSearch()
	{
		sqlTextBox.ActiveTextAreaControl.Caret.PositionChanged += Caret_PositionChanged;
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

	private class ComboBoxItem
	{
		private readonly string Text;
		public readonly string Value;

		public ComboBoxItem(string text, string value)
		{
			Text = text;
			Value = value;
		}

		public override string ToString()
		{
			return Text;
		}
	}

	private void CommentSelection()
	{
		int startLine;
		int endLine;

		if (sqlTextBox.ActiveTextAreaControl.TextArea.SelectionManager.HasSomethingSelected)
		{
			ISelection selection = sqlTextBox.ActiveTextAreaControl.SelectionManager.SelectionCollection[0];
			startLine = selection.StartPosition.Line;
			endLine = selection.EndPosition.Line;

			if (selection.EndPosition.Column == 0 && selection.StartPosition.Line != selection.EndPosition.Line)
			{
				endLine--;
			}
		}
		else
		{
			startLine = sqlTextBox.ActiveTextAreaControl.TextArea.Caret.Line;
			endLine = startLine;
		}

		StringBuilder newLinesText = new StringBuilder();
		StringBuilder originalLinesText = new StringBuilder();

		for (int lineNumber = startLine; lineNumber <= endLine; lineNumber++)
		{
			LineSegment line = sqlTextBox.ActiveTextAreaControl.TextArea.Document.GetLineSegment(lineNumber);
			string originalLineText = sqlTextBox.ActiveTextAreaControl.TextArea.Document.GetText(line.Offset, line.Length);
			string newLineText = "";

			if (originalLineText.Length != 0)
			{
				newLineText = string.Format("--{0}", originalLineText);
			}

			if (lineNumber == endLine)
			{
				newLinesText.Append(newLineText);
				originalLinesText.Append(originalLineText);
			}
			else
			{
				newLinesText.AppendLine(newLineText);
				originalLinesText.AppendLine(originalLineText);
			}
		}

		int offset = sqlTextBox.ActiveTextAreaControl.TextArea.Document.GetLineSegment(startLine).Offset;
		sqlTextBox.ActiveTextAreaControl.TextArea.Document.Replace(offset, originalLinesText.Length, newLinesText.ToString());
		sqlTextBox.ActiveTextAreaControl.TextArea.Refresh();
		sqlTextBox.ActiveTextAreaControl.TextArea.Caret.UpdateCaretPosition();
	}

	private void UnCommentSelection()
	{
		int startLine;
		int endLine;

		if (sqlTextBox.ActiveTextAreaControl.TextArea.SelectionManager.HasSomethingSelected)
		{
			ISelection selection = sqlTextBox.ActiveTextAreaControl.SelectionManager.SelectionCollection[0];
			startLine = selection.StartPosition.Line;
			endLine = selection.EndPosition.Line;

			if (selection.EndPosition.Column == 0 && selection.StartPosition.Line != selection.EndPosition.Line)
			{
				endLine--;
			}
		}
		else
		{
			startLine = sqlTextBox.ActiveTextAreaControl.TextArea.Caret.Line;
			endLine = startLine;
		}

		StringBuilder newLinesText = new StringBuilder();
		StringBuilder originalLinesText = new StringBuilder();

		for (int lineNumber = startLine; lineNumber <= endLine; lineNumber++)
		{
			LineSegment line = sqlTextBox.ActiveTextAreaControl.TextArea.Document.GetLineSegment(lineNumber);
			string originalLineText = sqlTextBox.ActiveTextAreaControl.TextArea.Document.GetText(line.Offset, line.Length);
			string newLineText = originalLineText;

			if (originalLineText.Contains("--"))
			{
				int indexOfComment = originalLineText.IndexOf("--");

				string lineWithoutTabsOrSpaces = originalLineText.Replace(" ", "").Replace("\t", "");
				int indexOfCommentInLineWithoutTabsOrSpaces = lineWithoutTabsOrSpaces.IndexOf("--");

				if (lineWithoutTabsOrSpaces.Substring(0, indexOfCommentInLineWithoutTabsOrSpaces).Length == 0)
				{
					newLineText = originalLineText.Substring(0, indexOfComment) + originalLineText.Substring(indexOfComment + 2, originalLineText.Length - (indexOfComment + 2));
				}
			}

			if (lineNumber == endLine)
			{
				newLinesText.Append(newLineText);
				originalLinesText.Append(originalLineText);
			}
			else
			{
				newLinesText.AppendLine(newLineText);
				originalLinesText.AppendLine(originalLineText);
			}
		}

		sqlTextBox.ActiveTextAreaControl.TextArea.Document.Replace(sqlTextBox.ActiveTextAreaControl.TextArea.Document.GetLineSegment(startLine).Offset, originalLinesText.Length, newLinesText.ToString());
		sqlTextBox.ActiveTextAreaControl.TextArea.Refresh();
		sqlTextBox.ActiveTextAreaControl.TextArea.Caret.UpdateCaretPosition();
	}

	private void SetCreateValues()
	{
		Text = string.Format("{0} - Create Task", GenericHelper.ApplicationName);
		taskTypeComboBox.SelectedItem = GetComboBoxItemFromValue(taskTypeComboBox, TaskHelper.TaskType.Normal.ToString());
		enabledCheckBox.Checked = true;
		includeInResultsCheckBox.Checked = true;
		delayAfterCompletionTextBox.Text = "0";

		_textChanged = false;
	}

	private static string FormatText(string text)
	{
		text = text.Replace("\n", "\r\n");
		text = text.Replace("\r\r\n", "\r\n");

		return text;
	}

	private void SetEditValues(Task task)
	{
		Text = string.Format("{0} - Edit Task", GenericHelper.ApplicationName);
		nameTextBox.Text = task.Name;
		sqlTextBox.Text = FormatText(task.Sql);
		taskTypeComboBox.SelectedItem = GetComboBoxItemFromValue(taskTypeComboBox, task.Type.ToString());
		descriptionTextBox.Text = task.Description;
		enabledCheckBox.Checked = task.Enabled;
		includeInResultsCheckBox.Checked = task.IncludeInResults;
		delayAfterCompletionTextBox.Text = task.DelayAfterCompletion.ToString();

		nameTextBox.SelectionStart = nameTextBox.Text.Length;
		nameTextBox.SelectionLength = 0;

		_textChanged = false;
		_initialNameValue = task.Name.ToLower();
	}

	private static ComboBoxItem GetComboBoxItemFromValue(ComboBox comboBox, string value)
	{
		foreach (ComboBoxItem item in comboBox.Items)
		{
			if (item.Value == value)
			{
				return item;
			}
		}

		return null;
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
		if (TaskHelper.UniqueTaskName(nameTextBox.Text, _initialNameValue))
		{
			if (ValidSql(sqlTextBox.Text) && ValidNumberOfDelayAfterCompletion(delayAfterCompletionTextBox.Text))
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

	private bool ValidSql(string sql)
	{
		if (sql.Trim() == "")
		{
			MessageBox.Show("SQL can't be empty.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			sqlTextBox.Focus();
			return false;
		}

		return true;
	}

	private bool ValidNumberOfDelayAfterCompletion(string number)
	{
		int check;

		try
		{
			check = Convert.ToInt32(number);
		}
		catch
		{
			MessageBox.Show("Delay after completion is not a valid number.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			delayAfterCompletionTextBox.Focus();
			return false;
		}

		if (check < 0)
		{
			MessageBox.Show("Delay after completion must be equal to or greater than 0.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			delayAfterCompletionTextBox.Focus();
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

	private void SqlTextBox_TextChanged(object sender, EventArgs e)
	{
		_textChanged = true;
		_searchForm.SetSearchText(sqlTextBox.Text);
		_searchForm.Reset(sqlTextBox.ActiveTextAreaControl.Caret.Offset);
	}

	private void EnabledCheckBox_CheckedChanged(object sender, EventArgs e)
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

	private void SelectionCommentToolStripMenuItem_Click(object sender, EventArgs e)
	{
		CommentSelection();
	}

	private void SelectionUncommentToolStripMenuItem_Click(object sender, EventArgs e)
	{
		UnCommentSelection();
	}

	private void FontToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			fontDialog1.Font = sqlTextBox.TextEditorProperties.Font;
			fontDialog1.ShowDialog();

			if (fontDialog1.Font.Bold || fontDialog1.Font.Italic)
			{
				MessageBox.Show("Bold and Italic fonts are not supported.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			sqlTextBox.TextEditorProperties.Font = fontDialog1.Font;
			sqlTextBox.Font = fontDialog1.Font;
			sqlTextBox.ActiveTextAreaControl.TextArea.Refresh();

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

	private void ConnectionToolStripMenuItem_Click(object sender, EventArgs e)
	{
		InsertText("{connection}");
	}

	private void InsertText(string text)
	{
		string selectedText = sqlTextBox.ActiveTextAreaControl.TextArea.SelectionManager.SelectedText;

		if (sqlTextBox.ActiveTextAreaControl.TextArea.SelectionManager.HasSomethingSelected)
		{
			sqlTextBox.ActiveTextAreaControl.Caret.Position = sqlTextBox.ActiveTextAreaControl.SelectionManager.SelectionCollection[0].StartPosition;
		}

		sqlTextBox.Document.Replace(sqlTextBox.ActiveTextAreaControl.TextArea.Caret.Offset, selectedText.Length, text);
		sqlTextBox.ActiveTextAreaControl.TextArea.SelectionManager.ClearSelection();
		sqlTextBox.ActiveTextAreaControl.Caret.Position = sqlTextBox.Document.OffsetToPosition(sqlTextBox.ActiveTextAreaControl.TextArea.Caret.Offset + text.Length);
		sqlTextBox.ActiveTextAreaControl.TextArea.Refresh();
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
				return;
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

	private void ToolStripMenuItemUndo_Click(object sender, EventArgs e)
	{
		sqlTextBox.Undo();
	}

	private void ToolStripMenuItemRedo_Click(object sender, EventArgs e)
	{
		sqlTextBox.Redo();
	}

	private void ToolStripMenuItemCut_Click(object sender, EventArgs e)
	{
		sqlTextBox.ActiveTextAreaControl.TextArea.ClipboardHandler.Cut(sender, e);
	}

	private void ToolStripMenuItemCopy_Click(object sender, EventArgs e)
	{
		sqlTextBox.ActiveTextAreaControl.TextArea.ClipboardHandler.Copy(sender, e);
	}

	private void ToolStripMenuItemPaste_Click(object sender, EventArgs e)
	{
		sqlTextBox.ActiveTextAreaControl.TextArea.ClipboardHandler.Paste(sender, e);
	}

	private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
	{
		sqlTextBox.ActiveTextAreaControl.TextArea.ClipboardHandler.Delete(sender, e);
	}

	private void ToolStripMenuItemSelectAll_Click(object sender, EventArgs e)
	{
		SelectAll();
	}

	private void ContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
	{
		if (sqlTextBox.Document.UndoStack.CanUndo)
		{
			toolStripMenuItemUndo.Enabled = true;
		}
		else
		{
			toolStripMenuItemUndo.Enabled = false;
		}

		if (sqlTextBox.Document.UndoStack.CanRedo)
		{
			toolStripMenuItemRedo.Enabled = true;
		}
		else
		{
			toolStripMenuItemRedo.Enabled = false;
		}
	}

	private void ImportSQLToolStripMenuItem_Click(object sender, EventArgs e)
	{
		DialogResult result = openFileDialog1.ShowDialog();

		if (result.ToString() == "OK")
		{
			Application.DoEvents();
			sqlTextBox.Text = FormatText(XmlHelper.ReadXmlFromFile(openFileDialog1.FileName));
		}
	}

	private void ExportSQLToolStripMenuItem_Click(object sender, EventArgs e)
	{
		DialogResult result = saveFileDialog1.ShowDialog();

		if (result.ToString() == "OK")
		{
			Application.DoEvents();

			try
			{
				File.WriteAllText(saveFileDialog1.FileName, sqlTextBox.Text, Encoding.UTF8);
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("Error writing SQL to file.\r\n\r\n{0}", ex.Message), GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

	private void DelayAfterCompletionTextBox_TextChanged(object sender, EventArgs e)
	{
		_textChanged = true;
	}

	private void TotalconnectionsToolStripMenuItem_Click(object sender, EventArgs e)
	{
		InsertText("{totalconnections}");
	}

	private void TaskTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		_textChanged = true;
	}

	private void InsertMessageToolStripMenuItem_Click(object sender, EventArgs e)
	{
		InsertText("raiserror\r\n(\r\n\t'Hi there!',\r\n\t0,\t-- 0: Continue execution, 1: Stop execution\r\n\t1\t-- 1: Information, 2: Warning, 3: Error\r\n)");
	}

	private void StepToolStripMenuItem_Click(object sender, EventArgs e)
	{
		InsertText("{step}");
	}

	private void TasktypeToolStripMenuItem_Click(object sender, EventArgs e)
	{
		InsertText("{tasktype}");
	}

	private void FindToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (_searchForm.IsShown())
		{
			_searchForm.Activate();
		}
		else
		{
			if (sqlTextBox.ActiveTextAreaControl.SelectionManager.HasSomethingSelected)
			{
				if (!sqlTextBox.ActiveTextAreaControl.SelectionManager.SelectedText.Contains("\r"))
				{
					_searchForm.SetSearchTerm(sqlTextBox.ActiveTextAreaControl.SelectionManager.SelectedText);
				}
			}

			_searchForm.Hide();
			_searchForm.Show(this);
		}
	}

	private void SearchForm_SearchEvent(int foundIndex, string searchTerm)
	{
		_caretPositionChangeFromSearch = true;

		TextLocation startPosition = sqlTextBox.Document.OffsetToPosition(foundIndex);
		TextLocation endPosition = sqlTextBox.Document.OffsetToPosition(foundIndex + searchTerm.Length);

		sqlTextBox.ActiveTextAreaControl.SelectionManager.SetSelection(startPosition, endPosition);
		sqlTextBox.ActiveTextAreaControl.CenterViewOn(sqlTextBox.Document.GetLineNumberForOffset(foundIndex), 0);

		sqlTextBox.ActiveTextAreaControl.Caret.Line = endPosition.Line;
		sqlTextBox.ActiveTextAreaControl.Caret.Column = endPosition.Column;

		_caretPositionChangeFromSearch = false;
	}

	private void SelectAll()
	{
		TextLocation startPosition = new TextLocation(0, 0);

		int textLength = sqlTextBox.ActiveTextAreaControl.Document.TextLength;
		TextLocation endPosition = new TextLocation();
		endPosition.Column = sqlTextBox.Document.OffsetToPosition(textLength).Column;
		endPosition.Line = sqlTextBox.Document.OffsetToPosition(textLength).Line;

		sqlTextBox.ActiveTextAreaControl.SelectionManager.SetSelection(startPosition, endPosition);
		sqlTextBox.ActiveTextAreaControl.Caret.Position = endPosition;
	}

	private void SelectionCommentToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		CommentSelection();
	}

	private void SelectionUncommentToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		UnCommentSelection();
	}

	private void EditToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
	{
		if (sqlTextBox.Document.UndoStack.CanUndo)
		{
			undoToolStripMenuItem.Enabled = true;
		}
		else
		{
			undoToolStripMenuItem.Enabled = false;
		}

		if (sqlTextBox.Document.UndoStack.CanRedo)
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
		sqlTextBox.ActiveTextAreaControl.TextArea.ClipboardHandler.Cut(sender, e);
	}

	private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
	{
		sqlTextBox.ActiveTextAreaControl.TextArea.ClipboardHandler.Copy(sender, e);
	}

	private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
	{
		sqlTextBox.ActiveTextAreaControl.TextArea.ClipboardHandler.Paste(sender, e);
	}

	private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
	{
		sqlTextBox.ActiveTextAreaControl.TextArea.ClipboardHandler.Delete(sender, e);
	}

	private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
	{
		SelectAll();
	}

	private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
	{
		sqlTextBox.Undo();
	}

	private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
	{
		sqlTextBox.Redo();
	}

	private void IncludeInResultsCheckBox_CheckedChanged(object sender, EventArgs e)
	{
		_textChanged = true;
	}
}
