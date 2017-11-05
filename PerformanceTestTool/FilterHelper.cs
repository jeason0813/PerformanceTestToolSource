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

using System.Collections.Generic;

public static class FilterHelper
{
	public static List<CalculatedPerformanceCounter> FilterPerformanceCounters(List<CalculatedPerformanceCounter> performanceCounters, string objectName, string counterName, string instanceName)
	{
		List<CalculatedPerformanceCounter> filteredPerformanceCounters = new List<CalculatedPerformanceCounter>();

		int objectNameWildcards = CountCharacters(objectName, '*');
		int counterNameWildcards = CountCharacters(counterName, '*');
		int instanceNameWildcards = CountCharacters(instanceName, '*');

		foreach (CalculatedPerformanceCounter performanceCounter in performanceCounters)
		{
			bool matchObjectName = CheckMatchName(objectNameWildcards, objectName, performanceCounter.ObjectName);
			bool matchCounterName = CheckMatchName(counterNameWildcards, counterName, performanceCounter.CounterName);
			bool matchInstanceName = CheckMatchName(instanceNameWildcards, instanceName, performanceCounter.InstanceName);

			if (matchObjectName && matchCounterName && matchInstanceName)
			{
				filteredPerformanceCounters.Add(performanceCounter);
			}
		}

		return filteredPerformanceCounters;
	}

	private static bool CheckMatchName(int countWildcards, string name, string columnName)
	{
		bool match = false;

		if (countWildcards == 2)
		{
			if (name.StartsWith("*") && name.EndsWith("*"))
			{
				if (columnName.ToLower().Contains(name.Replace("*", "")))
				{
					match = true;
				}
			}
		}
		else if (countWildcards == 1)
		{
			if (name.StartsWith("*"))
			{
				if (columnName.ToLower().EndsWith(name.Replace("*", "")))
				{
					match = true;
				}
			}
			else if (name.EndsWith("*"))
			{
				if (columnName.ToLower().StartsWith(name.Replace("*", "")))
				{
					match = true;
				}
			}
		}
		else if (countWildcards == 0)
		{
			if (columnName.ToLower() == name || name == "")
			{
				match = true;
			}
		}

		return match;
	}

	private static int CountCharacters(string text, char character)
	{
		int count = 0;

		foreach (char c in text)
		{
			if (c == character)
			{
				count++;
			}
		}

		return count;
	}
}
