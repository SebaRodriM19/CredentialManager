using System;
namespace CredentialManager.FactoryMethod
{
	public class AccountFactory
	{
		public static IAccount CreateAccount(string username, string password)
		{
			return new Account(new User(username,password));
		}
	}
}

