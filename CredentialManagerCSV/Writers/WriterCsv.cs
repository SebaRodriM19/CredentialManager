using System;
using CredentialManagerDb;
using CredentialManagerDb.Repositories;
using SwiftExcel;
namespace CredentialManagerCSV.Writers
{

	public class WriterCsv : IWriter
	{

        private readonly ExcelWriter _writer;
        private readonly IAccountRepository _accounRepository;

        public WriterCsv(string filename, IAccountRepository accountRepository)
        {
            var sheet = new Sheet { Name = "Matricola" };
            var file = Path.Combine(filename, $"Martricola-{DateTime.Now:yyyy-mm-gg}.csv");
            _writer = new(file, sheet);
            _accounRepository = accountRepository;
        }

        public void Write()
        {
            _writer.Write("Id",1, 1);
            _writer.Write("Matricola", 2, 1);
            _writer.Write("Password", 3, 1);
            _writer.Write("Data", 4, 1);

            var listOfAccountToWrite = _accounRepository.GetListAccount();

            using var enumerator = listOfAccountToWrite.GetEnumerator();

            var rowNumber = 2;
            while (enumerator.MoveNext())
            {
                _writer.Write($"{enumerator.Current.Id}", 1, rowNumber);
                _writer.Write($"{enumerator.Current.Username}", 2, rowNumber);
                _writer.Write($"{enumerator.Current.Password}", 3, rowNumber);
                _writer.Write($"{enumerator.Current.DateOfCreation}", 4, rowNumber);
                rowNumber++;
            }
        }

        public void Dispose() => _writer.Dispose();

    }
}

