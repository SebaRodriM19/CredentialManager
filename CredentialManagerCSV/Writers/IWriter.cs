using System;
namespace CredentialManagerCSV.Writers
{
    public interface IWriter : IDisposable
    {
        void Write();
    }

}

