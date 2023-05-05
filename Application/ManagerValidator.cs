using System;
using Application.Exceptions;
using CredentialManager.ChainOfResponsabilities;
using CredentialManager.FactoryMethod;
using CredentialManagerDb.Repositories;

namespace Application
{

	public class ManagerValidator
	{
		private readonly IAccountRepository _accountRepository;
		private readonly AccountFactory _accountFactory;
		private readonly SetUpChainPasswordValidation _setUpChainPasswordValidation;

        public ManagerValidator(IAccountRepository accountRepository, AccountFactory accountFactory, SetUpChainPasswordValidation setUpChainPasswordValidation)
        {
            _accountRepository = accountRepository;
            _accountFactory = accountFactory;
            _setUpChainPasswordValidation = setUpChainPasswordValidation;
        }

        public void SaveAccountInDb(string username, string password)
        {
            var account = MakeAccountAfterValidation(username,password);

            if (IsAccountInDb(account))
            {
                _accountRepository.InsertAccount(account);
                var listAccountFromDb = _accountRepository.GetListAccount();
                var res = listAccountFromDb.Where(x=> x.Username == account.GetUser().GetUsername()).Select(x => $"{x.Id} + {x.Username}");
            }
            else
            {
                throw new AccountAlreadyException("Username already exists.");
            }

            
        }

        public string PrintDataAccount(string username, string password)
        {
            var listOfAccount = _accountRepository.GetListAccount();
            var result = listOfAccount.Where(x=> x.Username == username && x.Password == password);

            if (result != null)
            {
                var credentias = result.First();
                return $"Id account: {credentias.Id}, Username: {credentias.Username}, Password: {credentias.Password}, Date of creation: {credentias.DateOfCreation}";
            }
            else
            {
                throw new InvalidAccountException("Invalid username.");
            }
        }

        private Account MakeAccountAfterValidation(string username, string password)
        {
            var result = IsValidPasswordForAccount(password);
            if (result.Item1)
            {
                return _accountFactory.CreateAccount(username,password);
            }
            else
            {
                throw new InvalidPasswordAccountException(result.Item2);
            }
        }

        private bool IsAccountInDb(Account account)
        {
            var listOfAccountFromDb = _accountRepository.GetListAccount();
            var result = listOfAccountFromDb.Where(x => x.Username == account.GetUser().GetUsername());

            if (result == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private (bool,string) IsValidPasswordForAccount(string password)
        {
            var validation = _setUpChainPasswordValidation.GetChainPasswordValidation();
            var res = validation.ProcessPassword(password);

            if (res.Item1)
            {
                return (true,res.Item2);
            }
            else
            {
                return (false,res.Item2);
            }
        }
    }
}

