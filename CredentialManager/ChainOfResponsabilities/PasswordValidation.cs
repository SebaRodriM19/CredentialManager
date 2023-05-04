using System;
namespace CredentialManager.ChainOfResponsabilities
{
	public abstract class PasswordValidation
	{
		protected PasswordValidation _successorPasswordValidation;

		public PasswordValidation()
		{
		}

		public void SetChainSuccessor(PasswordValidation passwordValidation)
		{
			_successorPasswordValidation = passwordValidation;
		}

		public abstract (bool,string) ProcessPassword(string password);
	}
}

