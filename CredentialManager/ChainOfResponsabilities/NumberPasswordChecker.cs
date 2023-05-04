using System;
namespace CredentialManager.ChainOfResponsabilities
{
    public class NumberPasswordChecker : PasswordValidation
    {
        public NumberPasswordChecker()
        {
        }
        public override (bool, string) ProcessPassword(string password)
        {
            var resFalse = false;
            var message = string.Empty;

            if (!SearchNumber(password))
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

        private bool SearchNumber(string password)
        {
            var counter = 0;

            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsNumber(password[i]))
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

