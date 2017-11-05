﻿/*
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

public class ImportTraceDataValue
{
	public string TaskName;
	public string ColumnName;
	public long Value;
	public int Connection;

	public ImportTraceDataValue(string taskName, string columnName, long value, int connection)
	{
		TaskName = taskName;
		ColumnName = columnName;
		Value = value;
		Connection = connection;
	}
}