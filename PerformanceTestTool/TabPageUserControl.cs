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
using System.Windows.Forms;

public partial class TabPageUserControl : UserControl
{
	public delegate void SplitterMovedEventHandler(int splitterDistance);
	public event SplitterMovedEventHandler SplitterMovedEvent;
	public delegate void SwitchTabEventHandler(Keys key);
	public event SwitchTabEventHandler SwitchTabEvent;

	private readonly List<TraceDataResult> _traceDataResults;
	private readonly ListViewColumnSorter _listViewColumnSorter;
	private ListViewColumnSorter _basedOnListViewColumnSorter;

	public TabPageUserControl()
	{
		InitializeComponent();
		_listViewColumnSorter = new ListViewColumnSorter();
		traceDataListView.ListViewItemSorter = _listViewColumnSorter;
		_traceDataResults = new List<TraceDataResult>();

		splitContainer1.SplitterDistance = GetSplitterDistance();
	}

	public ListView GetTraceDataResults()
	{
		return traceDataListView;
	}

	public ListView GetBasedOnResultsFormListView()
	{
		return basedOnListView;
	}

	public void SetSplitterDistance(int splitterDistance)
	{
		splitContainer1.SplitterDistance = splitterDistance;
	}

	public void SetData(ResultTask resultTask, List<RanTaskInfo> ranTaskInfo, int connections)
	{
		bool summaryTab = false;

		if (resultTask.Name == "Summary")
		{
			summaryTab = true;
		}

		ShowTraceResults(summaryTab);
		SetBasedOnData(_traceDataResults, resultTask, ranTaskInfo);

		if (!summaryTab)
		{
			firstConnectionStartTimeLabel.Text = string.Format("First Connection Start Time: {0}", GenericHelper.FormatDateTime(resultTask.FirstConnectionStartTime, true));
		}
		else
		{
			firstConnectionStartTimeLabel.Visible = false;
		}

		resultSummaryHeaderLabel.Text = string.Format("::: Result Statistics ({0}) :::::::", GetBasedOnLabel(connections));
	}

	public void FillTraceDataResults(string traceName, long traceValue, int connection)
	{
		bool addNew = true;

		foreach (TraceDataResult traceDataResult in _traceDataResults)
		{
			if (traceDataResult.TraceName == traceName)
			{
				traceDataResult.Connections.Add(connection);
				traceDataResult.Values.Add(traceValue);
				addNew = false;
				break;
			}
		}

		if (addNew)
		{
			TraceDataResult newTraceDataResult = new TraceDataResult();
			newTraceDataResult.TraceName = traceName;
			newTraceDataResult.Connections.Add(connection);
			newTraceDataResult.Values.Add(traceValue);
			_traceDataResults.Add(newTraceDataResult);
		}
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		if (keyData == Keys.Left || keyData == Keys.Right)
		{
			FireSwitchTabEvent(keyData);
			return true;
		}

		return base.ProcessCmdKey(ref msg, keyData);
	}

	private static int GetSplitterDistance()
	{
		if (Application.RenderWithVisualStyles)
		{
			return 168;
		}
		else
		{
			return 161;
		}
	}

	private void SetBasedOnData(List<TraceDataResult> traceDataResults, ResultTask resultTask, List<RanTaskInfo> ranTaskInfo)
	{
		_basedOnListViewColumnSorter = new ListViewColumnSorter();
		basedOnListView.ListViewItemSorter = _basedOnListViewColumnSorter;

		bool summaryTab = false;

		if (ranTaskInfo == null)
		{
			summaryTab = true;
		}

		SetupBasedOnColumns(traceDataResults, summaryTab);
		FillBasedOnListView(traceDataResults, resultTask, ranTaskInfo);
	}

	private void FireSplitterMovedEvent(int splitterDistance)
	{
		if (SplitterMovedEvent != null)
		{
			SplitterMovedEvent(splitterDistance);
		}
	}

	private void FireSwitchTabEvent(Keys key)
	{
		if (SwitchTabEvent != null)
		{
			SwitchTabEvent(key);
		}
	}

	private void ShowTraceResults(bool summaryTab)
	{
		foreach (TraceDataResult traceDataResult in _traceDataResults)
		{
			if (summaryTab && traceDataResult.TraceName == "Start Time")
			{
				continue;
			}

			long totalValue = 0;
			long minimum = 9223372036854775807;
			long maximum = -9223372036854775808;

			foreach (long value in traceDataResult.Values)
			{
				totalValue += value;

				if (value < minimum)
				{
					minimum = value;
				}

				if (value > maximum)
				{
					maximum = value;
				}
			}

			decimal average = Math.Round(Convert.ToDecimal(totalValue) / Convert.ToDecimal(traceDataResult.Values.Count), 0);

			ListViewItem listViewItem = new ListViewItem();
			listViewItem.Text = traceDataResult.TraceName;
			listViewItem.SubItems.Add(minimum.ToString());
			listViewItem.SubItems.Add(maximum.ToString());
			listViewItem.SubItems.Add(average.ToString());
			listViewItem.SubItems.Add(totalValue.ToString());
			traceDataListView.Items.Add(listViewItem);
		}
	}

	private static string GetBasedOnLabel(int connections)
	{
		string text = "connections";

		if (connections == 1)
		{
			text = "connection";
		}

		return string.Format("based on {0} {1}", connections, text);
	}

	private void TraceDataListView_ColumnClick(object sender, ColumnClickEventArgs e)
	{
		SortTraceDataListView(e.Column);
	}

	private void SortTraceDataListView(int columnIndex)
	{
		if (columnIndex == _listViewColumnSorter.SortColumn)
		{
			if (_listViewColumnSorter.Order == SortOrder.Ascending)
			{
				_listViewColumnSorter.Order = SortOrder.Descending;
			}
			else
			{
				_listViewColumnSorter.Order = SortOrder.Ascending;
			}
		}
		else
		{
			_listViewColumnSorter.SortColumn = columnIndex;
			_listViewColumnSorter.Order = SortOrder.Ascending;
		}

		if (columnIndex == 0)
		{
			_listViewColumnSorter.SortByDecimalValue = false;
		}
		else
		{
			_listViewColumnSorter.SortByDecimalValue = true;
		}

		traceDataListView.Sort();
	}

	private void SplitContainer1_Paint(object sender, PaintEventArgs e)
	{
		SplitContainerGrip.PaintGrip(sender, e);
	}

	private void SplitContainer1_MouseUp(object sender, MouseEventArgs e)
	{
		if (splitContainer1.CanFocus)
		{
			ActiveControl = traceDataListView;
		}
	}

	private void SplitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
	{
		if (e.SplitY != GetSplitterDistance() && e.SplitY != GetSplitterDistance() + 1)
		{
			FireSplitterMovedEvent(splitContainer1.SplitterDistance);
		}
	}

	private void TabPageUserControl_Resize(object sender, EventArgs e)
	{
		if (Height != 100 && Height != 0) // Initial form height = form not yet initialized
		{
			int newSplitterDistance = Height - (splitContainer1.Panel1MinSize + 4);

			if (splitContainer1.SplitterDistance > newSplitterDistance)
			{
				splitContainer1.SplitterDistance = newSplitterDistance;
			}

			splitContainer1.SplitterDistance++;
			splitContainer1.SplitterDistance--;
			splitContainer1.Invalidate();
		}
	}

	private void BasedOnListView_ColumnClick(object sender, ColumnClickEventArgs e)
	{
		SortBasedOnListView(e.Column);
	}

	private void SortBasedOnListView(int columnIndex)
	{
		if (columnIndex == _basedOnListViewColumnSorter.SortColumn)
		{
			if (_basedOnListViewColumnSorter.Order == SortOrder.Ascending)
			{
				_basedOnListViewColumnSorter.Order = SortOrder.Descending;
			}
			else
			{
				_basedOnListViewColumnSorter.Order = SortOrder.Ascending;
			}
		}
		else
		{
			_basedOnListViewColumnSorter.SortColumn = columnIndex;
			_basedOnListViewColumnSorter.Order = SortOrder.Ascending;
		}

		_basedOnListViewColumnSorter.SortByDecimalValue = true;

		string columnName = basedOnListView.Columns[columnIndex].Text;

		if (columnName == "Start Time" || columnName == "Message")
		{
			_basedOnListViewColumnSorter.SortByDecimalValue = false;
		}

		basedOnListView.Sort();
	}

	private void SetupBasedOnColumns(List<TraceDataResult> traceDataResults, bool summaryTab)
	{
		ColumnHeader columnHeader = new ColumnHeader();
		columnHeader.Width = 80;
		columnHeader.Text = "Connection";
		basedOnListView.Columns.Add(columnHeader);

		for (int i = 0; i < traceDataResults.Count; i++)
		{
			if (summaryTab)
			{
				if (traceDataResults[i].TraceName == "Start Time")
				{
					continue;
				}
			}

			columnHeader = new ColumnHeader();
			columnHeader.Width = 80;
			columnHeader.Text = traceDataResults[i].TraceName;
			basedOnListView.Columns.Add(columnHeader);
		}

		if (!summaryTab)
		{
			columnHeader = new ColumnHeader();
			columnHeader.Text = "Message";
			columnHeader.Width = 88;
			basedOnListView.Columns.Add(columnHeader);
		}
	}

	private void FillBasedOnListView(List<TraceDataResult> traceDataResults, ResultTask resultTask, List<RanTaskInfo> ranTaskInfo)
	{
		if (traceDataResults.Count == 0)
		{
			return;
		}

		bool summaryTab = false;

		if (ranTaskInfo == null)
		{
			summaryTab = true;
		}

		int numberOfRows = traceDataResults[0].Values.Count;

		for (int row = 0; row < numberOfRows; row++)
		{
			ListViewItem listViewItem = new ListViewItem();
			List<int> connections = traceDataResults[0].Connections;
			listViewItem.Text = connections[row].ToString();

			int columns = traceDataResults.Count;

			for (int column = 0; column < columns; column++)
			{
				List<long> values = traceDataResults[column].Values;

				if (traceDataResults[column].TraceName == "Start Time")
				{
					if (!summaryTab)
					{
						TimeSpan timeValue = TimeSpan.FromMilliseconds(values[row]);
						listViewItem.SubItems.Add(GenericHelper.FormatTimeSpan(timeValue, true));
					}
				}
				else
				{
					listViewItem.SubItems.Add(values[row].ToString());
				}
			}

			if (!summaryTab)
			{
				foreach (RanTaskInfo ranTask in ranTaskInfo)
				{
					if (ranTask.TaskName == resultTask.Name)
					{
						if (ranTask.ConnectionNumber == connections[row])
						{
							listViewItem.SubItems.Add(ranTask.Message);
						}
					}
				}
			}

			basedOnListView.Items.Add(listViewItem);
		}
	}
}
