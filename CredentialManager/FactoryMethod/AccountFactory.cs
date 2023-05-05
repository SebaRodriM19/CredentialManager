using System;
namespace CredentialManager.FactoryMethod
{
	public class AccountFactory
	{
		public Account CreateAccount(string username, string password)
		{
			return new Account(new User(username,password));
		}
	}
}

