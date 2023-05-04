using System;
namespace CredentialManager.ChainOfResponsabilities
{
	public class LengthPasswordChecker : PasswordValidation
	{
		public LengthPasswordChecker()
		{
		}

        public override (bool,string) ProcessPassword(string password)
        {
            var resFalse = false;
            var message = string.Empty;

            if (password.Length < 7)
            {
                resFalse = false;
                message = $"Password must be at least seven cherachters.";
            }
            else if (_successorPasswordValidation != null)
            {
                return _successorPasswordValidation.ProcessPassword(password);
            }

            return (resFalse,message);
        }
    }
}

