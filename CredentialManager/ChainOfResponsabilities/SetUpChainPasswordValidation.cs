using System;
namespace CredentialManager.ChainOfResponsabilities
{
	public class SetUpChainPasswordValidation
	{
		private PasswordValidation _chainPasswordValidation;

		public SetUpChainPasswordValidation()
		{
			var checkEmptyPassword = new EmptyPasswordChecker();
			var checkLengthPassword = new LengthPasswordChecker();
			var checkCharacterInUppercasePassword = new UppercasePasswordChecker();
			var checkNumberInPassword = new NumberPasswordChecker();
			var checkSpecialCharacterInPassword = new SpecialCharacterPasswordChecker();

			checkEmptyPassword.SetChainSuccessor(checkLengthPassword);
			checkLengthPassword.SetChainSuccessor(checkCharacterInUppercasePassword);
			checkCharacterInUppercasePassword.SetChainSuccessor(checkNumberInPassword);
			checkNumberInPassword.SetChainSuccessor(checkSpecialCharacterInPassword);

			_chainPasswordValidation = checkEmptyPassword;
		}

		public PasswordValidation GetChainPasswordValidation() => _chainPasswordValidation;
	}
}

