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
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

public partial class StylesheetEditorForm : Form
{
	private Rectangle _dragBoxFromMouseDown;
	private int _rowIndexFromMouseDown;
	private int _rowIndexOfItemUnderMouseToDrop;
	private readonly List<Stylesheet> _copiedItems = new List<Stylesheet>();
	private bool _cutActivated;
	private bool _changesMade;
	private readonly StylesheetCollection _initialStylesheetCollection = new StylesheetCollection();
	private string _initialStylesheetCollectionFileName;
	private SearchListForm _searchForm;
	private List<string> _searchList;
	private bool _selectionChangeFromSearch;
	private bool _searchInName = true;
	private bool _searchInContent;
	private bool _searchInDescription;

	public StylesheetEditorForm()
	{
		InitializeComponent();
		Initialize();
	}

	private void Initialize()
	{
		SetTitle();
		GenericHelper.SetSize(this, ConfigHandler.EditorWindowSize);
		MinimumSize = new Size(700, 500);  // error in .NET
		FillRecentFilesMenu();

		_searchForm = new SearchListForm("XSL");

		FillList();
		SelectFirstItem();

		wordWrapToolStripMenuItem.Checked = Convert.ToBoolean(ConfigHandler.WordWrap);
		descriptionTextBox.WordWrap = Convert.ToBoolean(ConfigHandler.WordWrap);

		descriptionTextBox.Text = StylesheetHelper.StylesheetCollection.Description;
		SetChangesMade(false);

		CopyStylesheetCollectionToInitialStylesheetCollection();

		_searchForm.SearchEvent += SearchForm_SearchEvent;
		_searchForm.RequestUpdateListEvent += SearchForm_RequestUpdateListEvent;

		stylesheetsTextBox.GotFocus += StylesheetsTextBox_GotFocus;

		dataGridView1.Select();
	}

	private void CopyStylesheetCollectionToInitialStylesheetCollection()
	{
		_initialStylesheetCollection.Stylesheets.Clear();

		foreach (Stylesheet stylesheet in StylesheetHelper.StylesheetCollection.Stylesheets)
		{
			Stylesheet newStylesheet = new Stylesheet(stylesheet.Name, stylesheet.Description, stylesheet.Xslt, stylesheet.Enabled, stylesheet.OutputFormat);
			_initialStylesheetCollection.Stylesheets.Add(newStylesheet);
		}

		_initialStylesheetCollection.Description = StylesheetHelper.StylesheetCollection.Description;

		_initialStylesheetCollectionFileName = StylesheetHelper.StylesheetCollectionFileName;
	}

	private void SetChangesMade(bool value)
	{
		bool setTitle = false;

		if (value != _changesMade)
		{
			setTitle = true;
		}

		_changesMade = value;

		if (setTitle)
		{
			SetTitle();
		}
	}

	private void UnloadFileName()
	{
		StylesheetHelper.StylesheetCollectionFileName = null;
		SetTitle();
	}

	private void SetTitle()
	{
		string fileName = "";

		if (StylesheetHelper.StylesheetCollectionFileName != null && StylesheetHelper.StylesheetCollectionFileName != SessionHelper.GetSessionStylesheetCollectionFileName())
		{
			fileName = string.Format(" - {0}", Path.GetFileName(StylesheetHelper.StylesheetCollectionFileName));
		}

		string changesMade = "";

		if (_changesMade)
		{
			changesMade = " *";
		}

		Text = string.Format("{0} - Stylesheet Collection Editor{1}{2}", GenericHelper.ApplicationName, fileName, changesMade);
	}

	private string GetFileName()
	{
		if (StylesheetHelper.StylesheetCollectionFileName == null || StylesheetHelper.StylesheetCollectionFileName == SessionHelper.GetSessionStylesheetCollectionFileName())
		{
			DialogResult result = saveFileDialog1.ShowDialog();

			if (result.ToString() == "OK")
			{
				Application.DoEvents();
				SetFileName(saveFileDialog1.FileName);
			}
		}

		return StylesheetHelper.StylesheetCollectionFileName;
	}

	private void FillRecentFilesMenu()
	{
		RecentFilesHandler.LoadMenuItems(recentFilesToolStripMenuItem, "RecentStylesheetCollectionFiles");
		AddEventHandlersToRecentFiles();
	}

	private void SetFileName(string fileName)
	{
		StylesheetHelper.StylesheetCollectionFileName = fileName;
		RecentFilesHandler.AddFileName(recentFilesToolStripMenuItem, fileName, "RecentStylesheetCollectionFiles");
		AddEventHandlersToRecentFiles();
	}

	private void AddEventHandlersToRecentFiles()
	{
		foreach (ToolStripMenuItem existingFileName in recentFilesToolStripMenuItem.DropDownItems)
		{
			if (existingFileName.Text != "empty")
			{
				existingFileName.Click += ExistingFileNameMenuItem_Click;
			}
		}
	}

	private void ExistingFileNameMenuItem_Click(object sender, EventArgs e)
	{
		bool success = SaveChanges();

		if (success)
		{
			string fileName = ((ToolStripMenuItem)sender).Text;

			if (File.Exists(fileName))
			{
				string xml = XmlHelper.ReadXmlFromFile(fileName);

				if (xml != null)
				{
					success = Import(xml);

					if (success)
					{
						SetFileName(fileName);
						SetTitle();
					}
				}
			}
			else
			{
				MessageBox.Show("File not found.", GenericHelper.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
	}

	private void FillList()
	{
		dataGridView1.Rows.Clear();

		for (int i = 0; i < StylesheetHelper.StylesheetCollection.Stylesheets.Count; i++)
		{
			int index = dataGridView1.Rows.Add();
			DataGridViewRow row = dataGridView1.Rows[index];
			row.Cells["StylesheetName"].Value = StylesheetHelper.StylesheetCollection.Stylesheets[i].Name;
			row.Cells["StylesheetName"].ToolTipText = StylesheetHelper.StylesheetCollection.Stylesheets[i].Description;
			row.Cells["OutputFormat"].Value = StylesheetHelper.StylesheetCollection.Stylesheets[i].OutputFormat;

			if (!StylesheetHelper.StylesheetCollection.Stylesheets[i].Enabled)
			{
				row.DefaultCellStyle.ForeColor = Color.Gray;
				row.DefaultCellStyle.SelectionForeColor = Color.Gray;
			}
			else
			{
				row.DefaultCellStyle.ForeColor = SystemColors.WindowText;
				row.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
			}
		}

		FillStepColumn();
		PopulateSearchList();
		UpdateStylesheetsTextBox();
		EnableItems();
	}

	private void SelectFirstItem()
	{
		if (dataGridView1.Rows.Count > 0)
		{
			dataGridView1.Rows[0].Selected = true;
			EnableItems();
		}
	}

	private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void ImportToolStripMenuItem_Click(object sender, EventArgs e)
	{
		bool success = SaveChanges();

		if (success)
		{
			DialogResult result = openFileDialog1.ShowDialog();

			if (result.ToString() == "OK")
			{
				Application.DoEvents();
				string xml = XmlHelper.ReadXmlFromFile(openFileDialog1.FileName);

				if (xml != null)
				{
					success = Import(xml);

					if (success)
					{
						SetFileName(openFileDialog1.FileName);
						SetTitle();
					}
				}
			}
		}
	}

	private bool Import(string xml)
	{
		StylesheetCollection temporaryStylesheetCollection = StylesheetHelper.XmlToStylesheetCollection(xml);

		if (temporaryStylesheetCollection != null)
		{
			StylesheetHelper.StylesheetCollection = temporaryStylesheetCollection;
			FillList();
			SelectFirstItem();

			descriptionTextBox.Text = StylesheetHelper.StylesheetCollection.Description;
			SetChangesMade(false);
			return true;
		}

		return false;
	}

	private void ExportToolStripMenuItem_Click(object sender, EventArgs e)
	{
		string currentFileName = StylesheetHelper.StylesheetCollectionFileName;
		StylesheetHelper.StylesheetCollectionFileName = null;

		bool success = SaveCollection();

		if (!success)
		{
			StylesheetHelper.StylesheetCollectionFileName = currentFileName;
		}
		else
		{
			SetTitle();
		}
	}

	private void CreateButton_Click(object sender, EventArgs e)
	{
		Create();
	}

	private void Create()
	{
		StylesheetForm form = new StylesheetForm();
		form.Icon = PerformanceTestTool.Properties.Resources.page_add;
		DialogResult result = form.ShowDialog();

		if (result.ToString() == "OK")
		{
			Application.DoEvents();
			Stylesheet newItem = form.GetValue();

			int insertNewRowAt = 0;

			if (dataGridView1.SelectedRows.Count > 0)
			{
				insertNewRowAt = dataGridView1.SelectedRows[0].Index;
				insertNewRowAt++;
			}

			CreateNewItem(newItem, insertNewRowAt);

			FillStepColumn();
			PopulateSearchList();
			UpdateStylesheetsTextBox();

			dataGridView1.FirstDisplayedScrollingRowIndex = insertNewRowAt;
			dataGridView1.CurrentCell = dataGridView1["StylesheetName", insertNewRowAt];
			dataGridView1.Rows[insertNewRowAt].Selected = true;

			SetChangesMade(true);
		}

		dataGridView1.Focus();
	}

	private void CreateNewItem(Stylesheet newItem, int insertNewRowAt)
	{
		StylesheetHelper.StylesheetCollection.Stylesheets.Insert(insertNewRowAt, newItem);

		int index = dataGridView1.Rows.Add();
		DataGridViewRow row = dataGridView1.Rows[index];
		row.Cells["StylesheetName"].Value = newItem.Name;
		row.Cells["StylesheetName"].ToolTipText = newItem.Description;
		row.Cells["OutputFormat"].Value = newItem.OutputFormat;

		if (!newItem.Enabled)
		{
			row.DefaultCellStyle.ForeColor = Color.Gray;
			row.DefaultCellStyle.SelectionForeColor = Color.Gray;
		}
		else
		{
			row.DefaultCellStyle.ForeColor = SystemColors.WindowText;
			row.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
		}

		dataGridView1.Rows.RemoveAt(index);
		dataGridView1.Rows.Insert(insertNewRowAt, row);
	}

	private void FillStepColumn()
	{
		for (int i = 0; i < StylesheetHelper.StylesheetCollection.Stylesheets.Count; i++)
		{
			dataGridView1.Rows[i].Cells["StepColumn"].Value = (i + 1).ToString();
		}
	}

	private void EditButton_Click(object sender, EventArgs e)
	{
		Edit();
	}

	private void Edit()
	{
		List<Stylesheet> newItems = StylesheetHelper.StylesheetCollection.Stylesheets;

		bool save = false;

		foreach (Stylesheet item in newItems)
		{
			if (dataGridView1.SelectedRows[0].Cells["StylesheetName"].Value.ToString() == item.Name)
			{
				StylesheetForm form = new StylesheetForm(item);
				form.Icon = PerformanceTestTool.Properties.Resources.page_edit;
				DialogResult result = form.ShowDialog();

				if (result.ToString() == "OK")
				{
					Application.DoEvents();

					Stylesheet newItem = form.GetValue();
					item.Name = newItem.Name;
					item.Description = newItem.Description;
					item.Xslt = newItem.Xslt;
					item.Enabled = newItem.Enabled;
					item.OutputFormat = newItem.OutputFormat;

					dataGridView1.SelectedRows[0].Cells["StylesheetName"].Value = newItem.Name;
					dataGridView1.SelectedRows[0].Cells["StylesheetName"].ToolTipText = newItem.Description;
					dataGridView1.SelectedRows[0].Cells["OutputFormat"].Value = newItem.OutputFormat;

					if (!newItem.Enabled)
					{
						dataGridView1.SelectedRows[0].DefaultCellStyle.ForeColor = Color.Gray;
						dataGridView1.SelectedRows[0].DefaultCellStyle.SelectionForeColor = Color.Gray;
					}
					else
					{
						dataGridView1.SelectedRows[0].DefaultCellStyle.ForeColor = SystemColors.WindowText;
						dataGridView1.SelectedRows[0].DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
					}

					save = true;
				}

				break;
			}
		}

		if (save)
		{
			StylesheetHelper.StylesheetCollection.Stylesheets = newItems;
			FillStepColumn();
			PopulateSearchList();
			UpdateStylesheetsTextBox();
			SetChangesMade(true);
		}

		dataGridView1.Focus();
	}

	private void ToggleEnabled()
	{
		foreach (DataGridViewRow row in dataGridView1.SelectedRows)
		{
			foreach (Stylesheet item in StylesheetHelper.StylesheetCollection.Stylesheets)
			{
				if (row.Cells["StylesheetName"].Value.ToString() == item.Name)
				{
					if (item.Enabled)
					{
						item.Enabled = false;

						row.DefaultCellStyle.ForeColor = Color.Gray;
						row.DefaultCellStyle.SelectionForeColor = Color.Gray;
					}
					else
					{
						item.Enabled = true;

						row.DefaultCellStyle.ForeColor = SystemColors.WindowText;
						row.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
					}
				}
			}
		}

		SetChangesMade(true);
		dataGridView1.Focus();
	}

	private int GetCorrectIndexOfSelectedRow(DataGridViewRow selectedRow)
	{
		foreach (DataGridViewRow row in dataGridView1.Rows)
		{
			if (row == selectedRow)
			{
				return row.Index;
			}
		}

		return -1;
	}

	private string FirstNameOfSelectedRows()
	{
		int firstIndex = dataGridView1.Rows.Count + 1;
		string firstName = null;

		foreach (Stylesheet item in StylesheetHelper.StylesheetCollection.Stylesheets)
		{
			foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
			{
				if (selectedRow.Cells["StylesheetName"].Value.ToString() == item.Name)
				{
					if (GetCorrectIndexOfSelectedRow(selectedRow) < firstIndex)
					{
						firstIndex = GetCorrectIndexOfSelectedRow(selectedRow);
						firstName = item.Name;
					}
				}
			}
		}

		return firstName;
	}

	private string LastNameOfSelectedRows()
	{
		int lastIndex = 0;
		string lastName = null;

		foreach (Stylesheet item in StylesheetHelper.StylesheetCollection.Stylesheets)
		{
			foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
			{
				if (selectedRow.Cells["StylesheetName"].Value.ToString() == item.Name)
				{
					if (GetCorrectIndexOfSelectedRow(selectedRow) >= lastIndex)
					{
						lastIndex = GetCorrectIndexOfSelectedRow(selectedRow);
						lastName = item.Name;
					}
				}
			}
		}

		return lastName;
	}

	private void Cut()
	{
		_cutActivated = true;
		DoCopy();
	}

	private void Copy()
	{
		_cutActivated = false;
		DoCopy();
	}

	private void DoCopy()
	{
		_copiedItems.Clear();

		for (int i = 0; i < StylesheetHelper.StylesheetCollection.Stylesheets.Count; i++)
		{
			for (int r = 0; r < dataGridView1.SelectedRows.Count; r++)
			{
				if (dataGridView1.SelectedRows[r].Cells["StylesheetName"].Value.ToString() == StylesheetHelper.StylesheetCollection.Stylesheets[i].Name)
				{
					_copiedItems.Add(StylesheetHelper.StylesheetCollection.Stylesheets[i]);
				}
			}
		}
	}

	private int GetIndexOfRowFromName(string name)
	{
		foreach (DataGridViewRow row in dataGridView1.Rows)
		{
			if (row.Cells["StylesheetName"].Value.ToString() == name)
			{
				return row.Index;
			}
		}

		return -1;
	}

	private void Paste()
	{
		int insertNewRowAt;

		if (_cutActivated)
		{
			string firstNameOfSelectedRows = FirstNameOfSelectedRows();
			insertNewRowAt = GetIndexOfRowFromName(firstNameOfSelectedRows);

			int totalRows = dataGridView1.Rows.Count;
			int spaceLeft = totalRows - insertNewRowAt;

			if (spaceLeft < _copiedItems.Count)
			{
				insertNewRowAt = totalRows - _copiedItems.Count;
			}

			if (insertNewRowAt < 0)
			{
				insertNewRowAt = 0;
			}
		}
		else
		{
			string lastNameOfSelectedRows = LastNameOfSelectedRows();
			insertNewRowAt = GetIndexOfRowFromName(lastNameOfSelectedRows) + 1;
		}

		int insertNewRowAtOriginal = insertNewRowAt;

		if (_cutActivated)
		{
			DoDelete(_copiedItems);
		}

		List<string> nameList = new List<string>();

		foreach (Stylesheet itemToBeCopied in _copiedItems)
		{
			string name = StylesheetHelper.GetNewItemName(itemToBeCopied.Name);

			Stylesheet newItem = new Stylesheet(name, itemToBeCopied.Description, itemToBeCopied.Xslt, itemToBeCopied.Enabled, itemToBeCopied.OutputFormat);
			CreateNewItem(newItem, insertNewRowAt);
			insertNewRowAt++;

			nameList.Add(name);
		}

		foreach (DataGridViewRow row in dataGridView1.Rows)
		{
			row.Selected = false;
		}

		dataGridView1.CurrentCell = dataGridView1["StylesheetName", insertNewRowAtOriginal];
		SelectRows(nameList);
		FillStepColumn();
		PopulateSearchList();
		UpdateStylesheetsTextBox();

		SetChangesMade(true);
		dataGridView1.Focus();
	}

	private void SelectRows(List<string> nameList)
	{
		foreach (DataGridViewRow row in dataGridView1.Rows)
		{
			foreach (string name in nameList)
			{
				if (row.Cells["StylesheetName"].Value.ToString() == name)
				{
					row.Selected = true;
				}
			}
		}
	}

	private void DeleteButton_Click(object sender, EventArgs e)
	{
		Delete();
	}

	private void Delete()
	{
		DialogResult result = MessageBox.Show("Delete selected stylesheets?", GenericHelper.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

		if (result.ToString() == "Yes")
		{
			List<Stylesheet> itemsToBeDeleted = new List<Stylesheet>();

			foreach (DataGridViewRow row in dataGridView1.SelectedRows)
			{
				foreach (Stylesheet item in StylesheetHelper.StylesheetCollection.Stylesheets)
				{
					if (row.Cells["StylesheetName"].Value.ToString() == item.Name)
					{
						itemsToBeDeleted.Add(item);
					}
				}
			}

			DoDelete(itemsToBeDeleted);

			FillStepColumn();
			PopulateSearchList();
			UpdateStylesheetsTextBox();
			EnableItems();
			dataGridView1.Focus();
		}
	}

	private void DoDelete(List<Stylesheet> itemsToBeDeleted)
	{
		List<int> indexesToBeRemoved = new List<int>();

		for (int r = 0; r < dataGridView1.Rows.Count; r++)
		{
			for (int i = 0; i < itemsToBeDeleted.Count; i++)
			{
				if (dataGridView1.Rows[r].Cells["StylesheetName"].Value.ToString() == itemsToBeDeleted[i].Name)
				{
					indexesToBeRemoved.Add(dataGridView1.Rows[r].Index);
				}
			}
		}

		indexesToBeRemoved.Sort(new SortIntDescending());

		for (int i = 0; i < indexesToBeRemoved.Count; i++)
		{
			dataGridView1.Rows.RemoveAt(indexesToBeRemoved[i]);
			StylesheetHelper.StylesheetCollection.Stylesheets.RemoveAt(indexesToBeRemoved[i]);
		}

		SetChangesMade(true);
	}

	private class SortIntDescending : IComparer<int>
	{
		int IComparer<int>.Compare(int a, int b)
		{
			if (a > b)
			{
				return -1;
			}
			if (a < b)
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}
	}

	private void MoveItem(int currentIndex, int newIndex)
	{
		DataGridViewRow row = dataGridView1.Rows[currentIndex];

		dataGridView1.Rows.RemoveAt(currentIndex);
		dataGridView1.Rows.Insert(newIndex, row);

		dataGridView1.CurrentCell = dataGridView1.Rows[newIndex].Cells["StylesheetName"];
		dataGridView1.Focus();

		SaveAfterMoveItem();

		FillStepColumn();
		PopulateSearchList();
		EnableItems();
	}

	private void MoveUpButton_Click(object sender, EventArgs e)
	{
		MoveUp();
	}

	private void MoveUp()
	{
		int currentIndex = dataGridView1.SelectedRows[0].Index;
		int newIndex = dataGridView1.SelectedRows[0].Index - 1;
		MoveItem(currentIndex, newIndex);
	}

	private void MoveDownButton_Click(object sender, EventArgs e)
	{
		MoveDown();
	}

	private void MoveDown()
	{
		int currentIndex = dataGridView1.SelectedRows[0].Index;
		int newIndex = dataGridView1.SelectedRows[0].Index + 1;
		MoveItem(currentIndex, newIndex);
	}

	private void SaveAfterMoveItem()
	{
		List<Stylesheet> newList = new List<Stylesheet>();

		foreach (DataGridViewRow row in dataGridView1.Rows)
		{
			foreach (Stylesheet item in StylesheetHelper.StylesheetCollection.Stylesheets)
			{
				if (row.Cells["StylesheetName"].Value.ToString() == item.Name)
				{
					newList.Add(item);
				}
			}
		}

		StylesheetHelper.StylesheetCollection.Stylesheets = newList;
		SetChangesMade(true);
	}

	private void OkButton_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void EnableItems()
	{
		if (dataGridView1.SelectedRows.Count == 0)
		{
			DisableItems();
		}
		else if (dataGridView1.SelectedRows.Count == 1)
		{
			createButton.Enabled = true;
			editButton.Enabled = true;
			deleteButton.Enabled = true;

			createMenuItem1.Enabled = true;
			editMenuItem1.Enabled = true;
			deleteMenuItem1.Enabled = true;
			renameMenuItem1.Enabled = true;
			cutMenuItem1.Enabled = true;
			copyMenuItem1.Enabled = true;
			toggleMenuItem1.Enabled = true;

			createMenuItem.Enabled = true;
			editMenuItem.Enabled = true;
			deleteMenuItem.Enabled = true;
			renameMenuItem.Enabled = true;
			cutMenuItem.Enabled = true;
			copyMenuItem.Enabled = true;
			toggleMenuItem.Enabled = true;
		}
		else if (dataGridView1.SelectedRows.Count > 1)
		{
			createButton.Enabled = true;
			editButton.Enabled = false;
			deleteButton.Enabled = true;

			createMenuItem1.Enabled = true;
			editMenuItem1.Enabled = false;
			deleteMenuItem1.Enabled = true;
			renameMenuItem1.Enabled = false;
			cutMenuItem1.Enabled = true;
			copyMenuItem1.Enabled = true;
			toggleMenuItem1.Enabled = true;

			createMenuItem.Enabled = true;
			editMenuItem.Enabled = false;
			deleteMenuItem.Enabled = true;
			renameMenuItem.Enabled = false;
			cutMenuItem.Enabled = true;
			copyMenuItem.Enabled = true;
			toggleMenuItem.Enabled = true;
		}

		if (dataGridView1.Rows.Count == 0)
		{
			selectAllMenuItem1.Enabled = false;
		}
		else
		{
			selectAllMenuItem1.Enabled = true;
		}

		if (dataGridView1.Rows.Count <= 1)
		{
			moveUpButton.Enabled = false;
			moveUpMenuItem1.Enabled = false;
			moveUpMenuItem.Enabled = false;
		}
		else
		{
			if (dataGridView1.Rows[0].Selected || dataGridView1.SelectedRows.Count == 0 || dataGridView1.SelectedRows.Count > 1)
			{
				moveUpButton.Enabled = false;
				moveUpMenuItem1.Enabled = false;
				moveUpMenuItem.Enabled = false;
			}
			else
			{
				moveUpButton.Enabled = true;
				moveUpMenuItem1.Enabled = true;
				moveUpMenuItem.Enabled = true;
			}
		}

		if (dataGridView1.Rows.Count <= 1)
		{
			moveDownButton.Enabled = false;
			moveDownMenuItem1.Enabled = false;
			moveDownMenuItem.Enabled = false;
		}
		else
		{
			if (dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected || dataGridView1.SelectedRows.Count == 0 || dataGridView1.SelectedRows.Count > 1)
			{
				moveDownButton.Enabled = false;
				moveDownMenuItem1.Enabled = false;
				moveDownMenuItem.Enabled = false;
			}
			else
			{
				moveDownButton.Enabled = true;
				moveDownMenuItem1.Enabled = true;
				moveDownMenuItem.Enabled = true;
			}
		}
	}

	private void DisableItems()
	{
		createButton.Enabled = true;
		editButton.Enabled = false;
		deleteButton.Enabled = false;

		createMenuItem1.Enabled = true;
		editMenuItem1.Enabled = false;
		deleteMenuItem1.Enabled = false;
		renameMenuItem1.Enabled = false;
		cutMenuItem1.Enabled = false;
		copyMenuItem1.Enabled = false;
		toggleMenuItem1.Enabled = false;

		createMenuItem.Enabled = true;
		editMenuItem.Enabled = false;
		deleteMenuItem.Enabled = false;
		renameMenuItem.Enabled = false;
		cutMenuItem.Enabled = false;
		copyMenuItem.Enabled = false;
		toggleMenuItem.Enabled = false;
	}

	private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex == -1)
		{
			return;
		}

		if (dataGridView1.SelectedRows.Count == 0)
		{
			DisableItems();
		}
		else if (dataGridView1.SelectedRows.Count == 1)
		{
			Edit();
		}
	}

	private void DataGridView1_SelectionChanged(object sender, EventArgs e)
	{
		EnableItems();

		if (!_selectionChangeFromSearch)
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				_searchForm.Reset(dataGridView1.SelectedRows[0].Index);
			}
		}
	}

	private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (dataGridView1.SelectedRows.Count == 0)
		{
			DisableItems();
		}

		if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
		{
			if (!dataGridView1.Rows[e.RowIndex].Selected)
			{
				dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
			}

			Rectangle r = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
			contextMenuStrip1.Show((Control)sender, r.Left + e.X, r.Top + e.Y);
		}
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		if (dataGridView1.Focused)
		{
			if (msg.WParam.ToInt32() == (int)Keys.Enter)
			{
				if (dataGridView1.SelectedRows.Count == 1)
				{
					Edit();
				}

				return true;
			}

			if ((int)keyData == 196644) // Keys.Shift && Keys.Control && Keys.Home
			{
				SendKeys.Send("+^{UP}");
				return true;
			}
		}

		return base.ProcessCmdKey(ref msg, keyData);
	}

	private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
	{
		if (dataGridView1.Rows.Count >= 1)
		{
			EnableItems();
		}

		if (e.KeyData == Keys.Delete)
		{
			if (dataGridView1.SelectedRows.Count >= 1)
			{
				Delete();
			}
		}
		else if (e.KeyCode == Keys.N && e.Modifiers == Keys.Control)
		{
			Create();
		}
		else if (e.KeyCode == Keys.E && e.Modifiers == Keys.Control)
		{
			if (dataGridView1.SelectedRows.Count >= 1)
			{
				ToggleEnabled();
			}
		}
		else if (e.KeyCode == Keys.X && e.Modifiers == Keys.Control)
		{
			if (dataGridView1.SelectedRows.Count >= 1)
			{
				Cut();
			}
		}
		else if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
		{
			if (dataGridView1.SelectedRows.Count >= 1)
			{
				Copy();
			}
		}
		else if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
		{
			if (_copiedItems.Count > 0)
			{
				Paste();
			}
		}
		else if (e.KeyCode == Keys.U && e.Modifiers == Keys.Control)
		{
			if (dataGridView1.SelectedRows.Count == 1)
			{
				if (dataGridView1.Rows[0].Selected || dataGridView1.SelectedRows.Count == 0)
				{
					return;
				}

				MoveUp();
			}
		}
		else if (e.KeyCode == Keys.D && e.Modifiers == Keys.Control)
		{
			if (dataGridView1.SelectedRows.Count == 1)
			{
				if (dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected || dataGridView1.SelectedRows.Count == 0)
				{
					return;
				}

				MoveDown();
			}
		}
		else if (e.KeyCode == Keys.F2)
		{
			if (dataGridView1.SelectedRows.Count == 1)
			{
				Rename();
			}
		}
	}

	private void DataGridView1_DragDrop(object sender, DragEventArgs e)
	{
		string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

		if (files != null)
		{
			if (files.Length == 1)
			{
				bool success = SaveChanges();

				if (success)
				{
					string xml = XmlHelper.ReadXmlFromFile(files[0]);

					if (xml != null)
					{
						success = Import(xml);

						if (success)
						{
							SetFileName(files[0]);
							SetTitle();
						}
					}
				}
			}
		}
		else
		{
			Point clientPoint = dataGridView1.PointToClient(new Point(e.X, e.Y));
			_rowIndexOfItemUnderMouseToDrop = dataGridView1.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

			if (e.Effect == DragDropEffects.Move)
			{
				if (_rowIndexOfItemUnderMouseToDrop != -1)
				{
					if (_rowIndexFromMouseDown != _rowIndexOfItemUnderMouseToDrop)
					{
						MoveItem(_rowIndexFromMouseDown, _rowIndexOfItemUnderMouseToDrop);
					}
				}
			}
		}
	}

	private void DataGridView1_MouseMove(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			if (_dragBoxFromMouseDown != Rectangle.Empty && !_dragBoxFromMouseDown.Contains(e.X, e.Y))
			{
				dataGridView1.DoDragDrop(dataGridView1.Rows[_rowIndexFromMouseDown], DragDropEffects.Move);
			}
		}
	}

	private void DataGridView1_MouseDown(object sender, MouseEventArgs e)
	{
		_rowIndexFromMouseDown = dataGridView1.HitTest(e.X, e.Y).RowIndex;

		if (_rowIndexFromMouseDown != -1)
		{
			Size dragSize = SystemInformation.DragSize;
			_dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
		}
		else
		{
			_dragBoxFromMouseDown = Rectangle.Empty;
		}
	}

	private void DataGridView1_DragOver(object sender, DragEventArgs e)
	{
		string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

		if (files != null)
		{
			if (files.Length == 1)
			{
				e.Effect = DragDropEffects.Move;
			}
		}
		else
		{
			e.Effect = DragDropEffects.Move;
		}
	}

	private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Create();
	}

	private void EditToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Edit();
	}

	private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Delete();
	}

	private void MoveDownToolStripMenuItem_Click(object sender, EventArgs e)
	{
		MoveDown();
	}

	private void MoveUpToolStripMenuItem_Click(object sender, EventArgs e)
	{
		MoveUp();
	}

	private void EditorForm_Resize(object sender, EventArgs e)
	{
		if (Width < MinimumSize.Width || Width == 0)
		{
			return;
		}

		ConfigHandler.EditorWindowSize = string.Format("{0}; {1}", Size.Width, Size.Height);
		ConfigHandler.SaveConfig();

		splitContainer1.SplitterDistance++;
		splitContainer1.SplitterDistance--;
		splitContainer1.Invalidate();
	}

	private void DeleteAll()
	{
		DialogResult overwrite = MessageBox.Show("Create new Stylesheet Collection?", GenericHelper.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

		if (overwrite.ToString() == "Yes")
		{
			bool success = SaveChanges();

			if (success)
			{
				StylesheetHelper.StylesheetCollection.Stylesheets.Clear();

				StylesheetHelper.StylesheetCollection.Description = "";
				descriptionTextBox.Text = "";

				UnloadFileName();

				SetChangesMade(false);
				FillList();
			}
		}
	}

	private void LoadExampleStylesheetToolStripMenuItem_Click(object sender, EventArgs e)
	{
		bool success = SaveChanges();

		if (success)
		{
			Import(PerformanceTestTool.Properties.Resources.DefaultStylesheets);
		}

		UnloadFileName();
	}

	private void CreateMenuItem_Click(object sender, EventArgs e)
	{
		Create();
	}

	private void EditMenuItem_Click(object sender, EventArgs e)
	{
		Edit();
	}

	private void DeleteMenuItem_Click(object sender, EventArgs e)
	{
		Delete();
	}

	private void MoveUpMenuItem_Click(object sender, EventArgs e)
	{
		MoveUp();
	}

	private void MoveDownMenuItem_Click(object sender, EventArgs e)
	{
		MoveDown();
	}

	private void WordWrapToolStripMenuItem_Click(object sender, EventArgs e)
	{
		descriptionTextBox.WordWrap = wordWrapToolStripMenuItem.Checked;
		ConfigHandler.WordWrap = wordWrapToolStripMenuItem.Checked.ToString();
		ConfigHandler.SaveConfig();
	}

	private void StylesheetEditorForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		bool success = SaveChanges();

		if (!success)
		{
			e.Cancel = true;
		}
		else
		{
			_searchForm.Close();
		}
	}

	private bool SaveChanges()
	{
		if (_changesMade)
		{
			DialogResult result = MessageBox.Show("Changes has been made in the Stylesheet Collection.\r\nSave changes?", GenericHelper.ApplicationName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

			if (result.ToString() == "Yes")
			{
				bool success = SaveCollection();

				if (!success)
				{
					return false;
				}
			}
			else if (result.ToString() == "No")
			{
				StylesheetHelper.StylesheetCollection = _initialStylesheetCollection;
				StylesheetHelper.StylesheetCollectionFileName = _initialStylesheetCollectionFileName;
			}
			else if (result.ToString() == "Cancel")
			{
				return false;
			}
		}

		return true;
	}

	private void DescriptionTextBox_Enter(object sender, EventArgs e)
	{
		descriptionTextBox.SelectionStart = 0;
		descriptionTextBox.SelectionLength = 0;
	}

	private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Copy();
	}

	private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Paste();
	}

	private void CopyToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		Copy();
	}

	private void PasteToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		Paste();
	}

	private void ContextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
	{
		HandleToolStripOpening();
	}

	private void OptionsToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
	{
		HandleToolStripOpening();
	}

	private void HandleToolStripOpening()
	{
		if (_copiedItems.Count > 0)
		{
			pasteMenuItem.Enabled = true;
			pasteMenuItem1.Enabled = true;
		}
		else
		{
			pasteMenuItem.Enabled = false;
			pasteMenuItem1.Enabled = false;
		}
	}

	private void CutToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Cut();
	}

	private void CutToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		Cut();
	}

	private void NewStylesheetCollectionToolStripMenuItem_Click(object sender, EventArgs e)
	{
		DeleteAll();
	}

	private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
	{
		dataGridView1.SelectAll();
	}

	private void SelectAllToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		dataGridView1.SelectAll();
	}

	private void SplitContainer1_Paint(object sender, PaintEventArgs e)
	{
		SplitContainerGrip.PaintGrip(sender, e);
	}

	private void SplitContainer1_MouseUp(object sender, MouseEventArgs e)
	{
		if (splitContainer1.CanFocus)
		{
			ActiveControl = dataGridView1;
		}
	}

	private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
	{
		SetChangesMade(true);
	}

	private void SaveCollectionToolStripMenuItem_Click(object sender, EventArgs e)
	{
		SaveCollection();
	}

	private bool SaveCollection()
	{
		StylesheetHelper.StylesheetCollection.Description = descriptionTextBox.Text;

		string fileName = GetFileName();

		if (fileName != null)
		{
			StylesheetHelper.SaveStylesheetCollection(fileName);
			CopyStylesheetCollectionToInitialStylesheetCollection();
			SetChangesMade(false);
			return true;
		}

		return false;
	}

	private void FileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
	{
		saveCollectionToolStripMenuItem.Enabled = _changesMade;
	}

	private void DescriptionTextBox_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.Control && e.KeyCode == Keys.A)
		{
			descriptionTextBox.SelectAll();
		}
	}

	private void FileToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
	{
		saveCollectionToolStripMenuItem.Enabled = true;
	}

	private void RenameMenuItem1_Click(object sender, EventArgs e)
	{
		Rename();
	}

	private void RenameMenuItem_Click(object sender, EventArgs e)
	{
		Rename();
	}

	private void Rename()
	{
		foreach (DataGridViewRow row in dataGridView1.SelectedRows)
		{
			foreach (Stylesheet item in StylesheetHelper.StylesheetCollection.Stylesheets)
			{
				if (row.Cells["StylesheetName"].Value.ToString() == item.Name)
				{
					ChangeValueForm form = new ChangeValueForm("Rename stylesheet", GenericHelper.CheckValue.StylesheetName, item.Name);
					form.ShowDialog();

					if (form.GetSuccess())
					{
						string newValue = form.GetNewStringValue();

						item.Name = newValue;
						row.Cells["StylesheetName"].Value = newValue;

						SetChangesMade(true);
						PopulateSearchList();
						dataGridView1.Focus();
					}
				}
			}
		}
	}

	private void SetEnabled(bool value)
	{
		foreach (DataGridViewRow row in dataGridView1.SelectedRows)
		{
			foreach (Stylesheet item in StylesheetHelper.StylesheetCollection.Stylesheets)
			{
				if (row.Cells["StylesheetName"].Value.ToString() == item.Name)
				{
					if (value)
					{
						item.Enabled = true;

						row.DefaultCellStyle.ForeColor = SystemColors.WindowText;
						row.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
					}
					else
					{
						item.Enabled = false;

						row.DefaultCellStyle.ForeColor = Color.Gray;
						row.DefaultCellStyle.SelectionForeColor = Color.Gray;
					}
				}
			}
		}

		SetChangesMade(true);
		dataGridView1.Focus();
	}

	private void ToggleEnabledMenuItem_Click(object sender, EventArgs e)
	{
		ToggleEnabled();
	}

	private void EnabledMenuItem_Click(object sender, EventArgs e)
	{
		SetEnabled(true);
	}

	private void DisabledMenuItem_Click(object sender, EventArgs e)
	{
		SetEnabled(false);
	}

	private void ToggleEnabledenuItem1_Click(object sender, EventArgs e)
	{
		ToggleEnabled();
	}

	private void EnabledMenuItem1_Click(object sender, EventArgs e)
	{
		SetEnabled(true);
	}

	private void DisabledMenuItem1_Click(object sender, EventArgs e)
	{
		SetEnabled(false);
	}

	private void PopulateSearchList()
	{
		_searchList = new List<string>();

		foreach (DataGridViewRow row in dataGridView1.Rows)
		{
			foreach (Stylesheet item in StylesheetHelper.StylesheetCollection.Stylesheets)
			{
				if (row.Cells["StylesheetName"].Value.ToString() == item.Name)
				{
					string searchText = "";

					if (_searchInName)
					{
						searchText = row.Cells["StylesheetName"].Value.ToString();
					}

					if (_searchInContent)
					{
						if (_searchInName)
						{
							searchText += "\r\n";
						}

						searchText += item.Xslt;
					}

					if (_searchInDescription)
					{
						if (_searchInContent || _searchInName)
						{
							searchText += "\r\n";
						}

						searchText += item.Description;
					}

					_searchList.Add(searchText);
				}
			}
		}

		_searchForm.SetSearchList(_searchList);

		if (dataGridView1.SelectedRows.Count > 0)
		{
			_searchForm.Reset(dataGridView1.SelectedRows[0].Index);
		}
	}

	private void SearchForm_SearchEvent(int foundIndex, string searchTerm)
	{
		_selectionChangeFromSearch = true;

		dataGridView1.FirstDisplayedScrollingRowIndex = foundIndex;
		dataGridView1.CurrentCell = dataGridView1["StylesheetName", foundIndex];
		dataGridView1.Rows[foundIndex].Selected = true;

		_selectionChangeFromSearch = false;
	}

	private void SearchForm_RequestUpdateListEvent(bool name, bool content, bool description)
	{
		_searchInName = name;
		_searchInContent = content;
		_searchInDescription = description;

		PopulateSearchList();
	}

	private void FindToolStripMenuItem_Click_1(object sender, EventArgs e)
	{
		if (_searchForm.IsShown())
		{
			_searchForm.Activate();
		}
		else
		{
			_searchForm.Hide();
			_searchForm.Show(this);
		}
	}

	private void StylesheetsTextBox_Enter(object sender, EventArgs e)
	{
		stylesheetsTextBox.SelectionStart = 0;
		stylesheetsTextBox.SelectionLength = 0;
		GenericHelper.HideCaret(stylesheetsTextBox);
	}

	private void StylesheetsTextBox_GotFocus(object sender, EventArgs e)
	{
		stylesheetsTextBox.SelectionStart = 0;
		stylesheetsTextBox.SelectionLength = 0;
		GenericHelper.HideCaret(stylesheetsTextBox);
	}

	private void UpdateStylesheetsTextBox()
	{
		stylesheetsTextBox.Text = string.Format("Stylesheets: {0}", StylesheetHelper.StylesheetCollection.Stylesheets.Count);
	}
}
