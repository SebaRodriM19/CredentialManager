using System;
using CredentialManagerCSV.Writers;

namespace Application
{
	public class ManagerWriterCSV
	{
		private readonly IWriter _writer;

		public ManagerWriterCSV(IWriter writer)
		{
			_writer = writer;
		}

		public void WriteCSV()
		{
			_writer.Write();
		}

	}
}

