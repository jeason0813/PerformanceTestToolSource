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

using System.Threading;
using System.Windows.Forms;

public static class ErrorFormHandler
{
	public static void ErrorOccuredEvent(int errorNumber, string okButtonText, string message, string sql, string location)
	{
		Thread t = new Thread(ShowErrorForm);
		t.SetApartmentState(ApartmentState.STA);
		t.Start(new ErrorFormParams(errorNumber, okButtonText, message, sql, location));
	}

	private class ErrorFormParams
	{
		public readonly int ErrorNumber;
		public readonly string OkButtonText;
		public readonly string Message;
		public readonly string Sql;
		public readonly string Location;

		public ErrorFormParams(int errorNumber, string okButtonText, string message, string sql, string location)
		{
			ErrorNumber = errorNumber;
			OkButtonText = okButtonText;
			Message = message;
			Sql = sql;
			Location = location;
		}
	}

	private static void ShowErrorForm(object arg)
	{
		ErrorFormParams errorFormParams = (ErrorFormParams)arg;
		ErrorForm form = new ErrorForm(errorFormParams.ErrorNumber, errorFormParams.OkButtonText, errorFormParams.Message, errorFormParams.Sql, errorFormParams.Location);
		form.ShowDialog();
		Application.DoEvents();
	}
}
