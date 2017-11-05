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

using System.IO;
using ICSharpCode.SharpZipLib.Zip;

public static class Compression
{
	public static void CompressFile(string inputFile, string outputFile)
	{
		ZipOutputStream stream = new ZipOutputStream(File.Create(outputFile));
		ZipEntry entry = new ZipEntry(Path.GetFileName(inputFile));

		using (FileStream fs = File.OpenRead(inputFile))
		{
			byte[] buffer = new byte[fs.Length];
			fs.Read(buffer, 0, buffer.Length);
			entry.Size = fs.Length;
			fs.Close();

			stream.PutNextEntry(entry);
			stream.Write(buffer, 0, buffer.Length);
		}

		stream.Finish();
		stream.Close();
	}

	public static void CompressDirectory(string inputDir, string outputFile)
	{
		string[] inputFiles = Directory.GetFiles(inputDir);
		ZipOutputStream stream = new ZipOutputStream(File.Create(outputFile));

		for (int i = 0; i < inputFiles.Length; i++)
		{
			ZipEntry entry = new ZipEntry(Path.GetFileName(inputFiles[i]));

			using (FileStream fs = File.OpenRead(inputFiles[i]))
			{
				byte[] buffer = new byte[fs.Length];
				fs.Read(buffer, 0, buffer.Length);
				entry.Size = fs.Length;
				fs.Close();

				stream.PutNextEntry(entry);
				stream.Write(buffer, 0, buffer.Length);
			}
		}

		stream.Finish();
		stream.Close();
	}
}
