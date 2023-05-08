using System;
using CredentialManager.FactoryMethod;

namespace CredentialManagerDb.Repositories
{
	public interface IAccountRepository
	{
		public List<AccountModel> GetListAccount();
		public bool InsertAccount(Account aacount);
	}
}

