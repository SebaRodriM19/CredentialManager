using System;
namespace CredentialManager.ChainOfResponsabilities
{
	public class EmptyPasswordChecker : PasswordValidation
	{
		public EmptyPasswordChecker()
		{
		}

        public override (bool, string) ProcessPassword(string password)
        {
            var resFalse = false;
            var message = string.Empty;

            if (password == string.Empty)
            {
                resFalse = false;
                message = $"Paasword can not be empty.";
            }
            else if (_successorPasswordValidation != null)
            {
                return _successorPasswordValidation.ProcessPassword(password);
            }

            return (resFalse, message);
        }
    }
}

