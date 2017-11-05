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

public class CalculatedPerformanceCounter
{
	public string ObjectName;
	public string CounterName;
	public string InstanceName;
	public long Minimum;
	public long Maximum;
	public long Average;

	public CalculatedPerformanceCounter(string objectName, string counterName, string instanceName, long minimum, long maximun, long average)
	{
		ObjectName = objectName;
		CounterName = counterName;
		InstanceName = instanceName;
		Minimum = minimum;
		Maximum = maximun;
		Average = average;
	}
}
