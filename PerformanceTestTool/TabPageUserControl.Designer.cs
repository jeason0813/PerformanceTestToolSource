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

partial class TabPageUserControl
{
	/// <summary> 
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary> 
	/// Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing && (components != null))
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Component Designer generated code

	/// <summary> 
	/// Required method for Designer support - do not modify 
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
		this.traceDataListView = new System.Windows.Forms.ListView();
		this.traceNameColumnHeader = new System.Windows.Forms.ColumnHeader();
		this.traceMinimumColumnHeader = new System.Windows.Forms.ColumnHeader();
		this.traceMaximumColumnHeader = new System.Windows.Forms.ColumnHeader();
		this.traceAverageColumnHeader = new System.Windows.Forms.ColumnHeader();
		this.traceSumColumnHeader = new System.Windows.Forms.ColumnHeader();
		this.splitContainer1 = new System.Windows.Forms.SplitContainer();
		this.resultSummaryHeaderLabel = new System.Windows.Forms.Label();
		this.firstConnectionStartTimeLabel = new System.Windows.Forms.Label();
		this.connectionResultsHeaderLabel = new System.Windows.Forms.Label();
		this.basedOnListView = new System.Windows.Forms.ListView();
		this.borderLabel3 = new BorderLabel();
		this.borderLabel1 = new BorderLabel();
		this.splitContainer1.Panel1.SuspendLayout();
		this.splitContainer1.Panel2.SuspendLayout();
		this.splitContainer1.SuspendLayout();
		this.SuspendLayout();
		// 
		// traceDataListView
		// 
		this.traceDataListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
					| System.Windows.Forms.AnchorStyles.Left)
					| System.Windows.Forms.AnchorStyles.Right)));
		this.traceDataListView.BackColor = System.Drawing.Color.WhiteSmoke;
		this.traceDataListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.traceDataListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.traceNameColumnHeader,
            this.traceMinimumColumnHeader,
            this.traceMaximumColumnHeader,
            this.traceAverageColumnHeader,
            this.traceSumColumnHeader});
		this.traceDataListView.FullRowSelect = true;
		this.traceDataListView.HideSelection = false;
		this.traceDataListView.Location = new System.Drawing.Point(1, 21);
		this.traceDataListView.Name = "traceDataListView";
		this.traceDataListView.Size = new System.Drawing.Size(448, 102);
		this.traceDataListView.TabIndex = 0;
		this.traceDataListView.UseCompatibleStateImageBehavior = false;
		this.traceDataListView.View = System.Windows.Forms.View.Details;
		this.traceDataListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.TraceDataListView_ColumnClick);
		// 
		// traceNameColumnHeader
		// 
		this.traceNameColumnHeader.Text = "Name";
		this.traceNameColumnHeader.Width = 146;
		// 
		// traceMinimumColumnHeader
		// 
		this.traceMinimumColumnHeader.Text = "Minimum";
		this.traceMinimumColumnHeader.Width = 76;
		// 
		// traceMaximumColumnHeader
		// 
		this.traceMaximumColumnHeader.Text = "Maximum";
		this.traceMaximumColumnHeader.Width = 76;
		// 
		// traceAverageColumnHeader
		// 
		this.traceAverageColumnHeader.Text = "Average";
		this.traceAverageColumnHeader.Width = 76;
		// 
		// traceSumColumnHeader
		// 
		this.traceSumColumnHeader.Text = "Sum";
		this.traceSumColumnHeader.Width = 76;
		// 
		// splitContainer1
		// 
		this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
					| System.Windows.Forms.AnchorStyles.Left)
					| System.Windows.Forms.AnchorStyles.Right)));
		this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
		this.splitContainer1.Location = new System.Drawing.Point(0, 3);
		this.splitContainer1.Name = "splitContainer1";
		this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
		// 
		// splitContainer1.Panel1
		// 
		this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Silver;
		this.splitContainer1.Panel1.Controls.Add(this.resultSummaryHeaderLabel);
		this.splitContainer1.Panel1.Controls.Add(this.traceDataListView);
		this.splitContainer1.Panel1.Controls.Add(this.borderLabel3);
		this.splitContainer1.Panel1MinSize = 70;
		// 
		// splitContainer1.Panel2
		// 
		this.splitContainer1.Panel2.Controls.Add(this.firstConnectionStartTimeLabel);
		this.splitContainer1.Panel2.Controls.Add(this.connectionResultsHeaderLabel);
		this.splitContainer1.Panel2.Controls.Add(this.basedOnListView);
		this.splitContainer1.Panel2.Controls.Add(this.borderLabel1);
		this.splitContainer1.Panel2MinSize = 70;
		this.splitContainer1.Size = new System.Drawing.Size(450, 250);
		this.splitContainer1.SplitterDistance = 127;
		this.splitContainer1.TabIndex = 0;
		this.splitContainer1.TabStop = false;
		this.splitContainer1.Paint += new System.Windows.Forms.PaintEventHandler(this.SplitContainer1_Paint);
		this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitContainer1_SplitterMoved);
		this.splitContainer1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SplitContainer1_MouseUp);
		// 
		// resultSummaryHeaderLabel
		// 
		this.resultSummaryHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
					| System.Windows.Forms.AnchorStyles.Right)));
		this.resultSummaryHeaderLabel.BackColor = System.Drawing.Color.Gray;
		this.resultSummaryHeaderLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		this.resultSummaryHeaderLabel.ForeColor = System.Drawing.Color.White;
		this.resultSummaryHeaderLabel.Location = new System.Drawing.Point(0, 0);
		this.resultSummaryHeaderLabel.Name = "resultSummaryHeaderLabel";
		this.resultSummaryHeaderLabel.Size = new System.Drawing.Size(450, 17);
		this.resultSummaryHeaderLabel.TabIndex = 16;
		this.resultSummaryHeaderLabel.Text = "::: Result Statistics :::::::";
		// 
		// firstConnectionStartTimeLabel
		// 
		this.firstConnectionStartTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
		this.firstConnectionStartTimeLabel.AutoSize = true;
		this.firstConnectionStartTimeLabel.BackColor = System.Drawing.Color.Gray;
		this.firstConnectionStartTimeLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		this.firstConnectionStartTimeLabel.ForeColor = System.Drawing.Color.White;
		this.firstConnectionStartTimeLabel.Location = new System.Drawing.Point(227, 3);
		this.firstConnectionStartTimeLabel.Name = "firstConnectionStartTimeLabel";
		this.firstConnectionStartTimeLabel.Size = new System.Drawing.Size(220, 16);
		this.firstConnectionStartTimeLabel.TabIndex = 19;
		this.firstConnectionStartTimeLabel.Text = "First Connection Start Time: 00:00:00:000";
		// 
		// connectionResultsHeaderLabel
		// 
		this.connectionResultsHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
					| System.Windows.Forms.AnchorStyles.Right)));
		this.connectionResultsHeaderLabel.BackColor = System.Drawing.Color.Gray;
		this.connectionResultsHeaderLabel.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		this.connectionResultsHeaderLabel.ForeColor = System.Drawing.Color.White;
		this.connectionResultsHeaderLabel.Location = new System.Drawing.Point(0, 3);
		this.connectionResultsHeaderLabel.Name = "connectionResultsHeaderLabel";
		this.connectionResultsHeaderLabel.Size = new System.Drawing.Size(450, 17);
		this.connectionResultsHeaderLabel.TabIndex = 17;
		this.connectionResultsHeaderLabel.Text = "::: Connection Results :::::::";
		// 
		// basedOnListView
		// 
		this.basedOnListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
					| System.Windows.Forms.AnchorStyles.Left)
					| System.Windows.Forms.AnchorStyles.Right)));
		this.basedOnListView.BackColor = System.Drawing.Color.WhiteSmoke;
		this.basedOnListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.basedOnListView.FullRowSelect = true;
		this.basedOnListView.HideSelection = false;
		this.basedOnListView.Location = new System.Drawing.Point(1, 24);
		this.basedOnListView.Name = "basedOnListView";
		this.basedOnListView.Size = new System.Drawing.Size(448, 94);
		this.basedOnListView.TabIndex = 16;
		this.basedOnListView.UseCompatibleStateImageBehavior = false;
		this.basedOnListView.View = System.Windows.Forms.View.Details;
		this.basedOnListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.BasedOnListView_ColumnClick);
		// 
		// borderLabel3
		// 
		this.borderLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
					| System.Windows.Forms.AnchorStyles.Left)
					| System.Windows.Forms.AnchorStyles.Right)));
		this.borderLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
		this.borderLabel3.Location = new System.Drawing.Point(0, 20);
		this.borderLabel3.Name = "borderLabel3";
		this.borderLabel3.Size = new System.Drawing.Size(450, 104);
		this.borderLabel3.TabIndex = 15;
		// 
		// borderLabel1
		// 
		this.borderLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
					| System.Windows.Forms.AnchorStyles.Left)
					| System.Windows.Forms.AnchorStyles.Right)));
		this.borderLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
		this.borderLabel1.Location = new System.Drawing.Point(0, 23);
		this.borderLabel1.Name = "borderLabel1";
		this.borderLabel1.Size = new System.Drawing.Size(450, 96);
		this.borderLabel1.TabIndex = 18;
		// 
		// TabPageUserControl
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		this.BackColor = System.Drawing.Color.Silver;
		this.Controls.Add(this.splitContainer1);
		this.DoubleBuffered = true;
		this.Name = "TabPageUserControl";
		this.Size = new System.Drawing.Size(450, 253);
		this.Resize += new System.EventHandler(this.TabPageUserControl_Resize);
		this.splitContainer1.Panel1.ResumeLayout(false);
		this.splitContainer1.Panel2.ResumeLayout(false);
		this.splitContainer1.Panel2.PerformLayout();
		this.splitContainer1.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#endregion

	private System.Windows.Forms.ListView traceDataListView;
	private System.Windows.Forms.ColumnHeader traceNameColumnHeader;
	private System.Windows.Forms.ColumnHeader traceMinimumColumnHeader;
	private System.Windows.Forms.ColumnHeader traceMaximumColumnHeader;
	private System.Windows.Forms.ColumnHeader traceAverageColumnHeader;
	private System.Windows.Forms.SplitContainer splitContainer1;
	private BorderLabel borderLabel3;
	private System.Windows.Forms.Label resultSummaryHeaderLabel;
	private System.Windows.Forms.ColumnHeader traceSumColumnHeader;
	private System.Windows.Forms.Label connectionResultsHeaderLabel;
	private System.Windows.Forms.ListView basedOnListView;
	private BorderLabel borderLabel1;
	private System.Windows.Forms.Label firstConnectionStartTimeLabel;
}
