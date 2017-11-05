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

public class Task
{
	public string Name;
	public string Description;
	public int DelayAfterCompletion;
	public string Sql;
	public TaskHelper.TaskType Type;
	public bool Enabled;
	public bool IncludeInResults;

	public Task(string name, string description, int delayAfterCompletion, string sql, TaskHelper.TaskType type, bool enabled, bool includeInResults)
	{
		Name = name;
		Description = description;
		DelayAfterCompletion = delayAfterCompletion;
		Sql = sql;
		Type = type;
		Enabled = enabled;
		IncludeInResults = includeInResults;
	}

	public override string ToString()
	{
		return Name;
	}
}
