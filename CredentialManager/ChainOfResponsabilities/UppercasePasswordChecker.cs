using System;
namespace CredentialManager.ChainOfResponsabilities
{
	public class UppercasePasswordChecker : PasswordValidation
	{
		public UppercasePasswordChecker()
		{
		}

        public override (bool, string) ProcessPassword(string password)
        {
            var resFalse = false;
            var message = string.Empty;

            if (!SearchCharacterInUpperCase(password))
            {
                resFalse = false;
                message = $"Password must contain at least one character in lowercase.";
            }
            else if (_successorPasswordValidation != null)
            {
                return _successorPasswordValidation.ProcessPassword(password);
            }

            return (resFalse, message);
        }

        private bool SearchCharacterInUpperCase(string password)
        {
            var counter = 0;

            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsUpper(password[i]))
                {
                    counter++;
                }
            }

            if (counter == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

