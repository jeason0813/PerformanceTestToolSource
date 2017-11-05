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

public static class PerformanceCounterHelper
{
	public static List<CalculatedPerformanceCounter> GetCalculatedPerformanceCounters(List<PerformanceCounters> performanceCounters)
	{
		List<PerformanceCounterResult> performanceCounterResults = HandlePerformanceCounterResults(performanceCounters);
		return CalculatePerformanceCounterResults(performanceCounterResults);
	}

	private static List<PerformanceCounterResult> HandlePerformanceCounterResults(List<PerformanceCounters> performanceCounterLists)
	{
		List<PerformanceCounterResult> performanceCounterResults = new List<PerformanceCounterResult>();

		foreach (PerformanceCounters performanceCounterList in performanceCounterLists)
		{
			foreach (PerformanceCounter performanceCounter in performanceCounterList.PerformanceCounterList)
			{
				FillPerformanceCounterResults(performanceCounter.ObjectName, performanceCounter.CounterName, performanceCounter.InstanceName, performanceCounter.Value, performanceCounterResults);
			}
		}

		return performanceCounterResults;
	}

	private static void FillPerformanceCounterResults(string objectName, string counterName, string instanceName, long value, List<PerformanceCounterResult> performanceCounterResults)
	{
		bool addNew = true;

		foreach (PerformanceCounterResult performanceCounterResult in performanceCounterResults)
		{
			if (performanceCounterResult.ObjectName == objectName && performanceCounterResult.CounterName == counterName && performanceCounterResult.InstanceName == instanceName)
			{
				performanceCounterResult.Values.Add(value);
				addNew = false;
				break;
			}
		}

		if (addNew)
		{
			PerformanceCounterResult newPerformanceCounterResult = new PerformanceCounterResult();
			newPerformanceCounterResult.ObjectName = objectName;
			newPerformanceCounterResult.CounterName = counterName;
			newPerformanceCounterResult.InstanceName = instanceName;
			newPerformanceCounterResult.Values.Add(value);
			performanceCounterResults.Add(newPerformanceCounterResult);
		}
	}

	private static List<CalculatedPerformanceCounter> CalculatePerformanceCounterResults(List<PerformanceCounterResult> performanceCounterResults)
	{
		List<CalculatedPerformanceCounter> calculatedPerformanceCounters = new List<CalculatedPerformanceCounter>();

		foreach (PerformanceCounterResult performanceCounterResult in performanceCounterResults)
		{
			long totalValue = 0;
			long minimum = 9223372036854775807;
			long maximum = -9223372036854775808;

			foreach (long value in performanceCounterResult.Values)
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

			int samples = performanceCounterResult.Values.Count;
			long average = Convert.ToInt64(Math.Round(Convert.ToDecimal(totalValue) / Convert.ToDecimal(samples), 0));

			calculatedPerformanceCounters.Add(new CalculatedPerformanceCounter(performanceCounterResult.ObjectName, performanceCounterResult.CounterName, performanceCounterResult.InstanceName, minimum, maximum, average));
		}

		return calculatedPerformanceCounters;
	}
}
