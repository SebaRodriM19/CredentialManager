using System;
namespace CredentialManager.FactoryMethod
{
	public class Account : IAccount
	{
        private User _user;
        private DateTime _dateOfCreation;
 
        public Account(User user)
        {
            _user = user;
            _dateOfCreation = DateTime.Now;
        }

        public User GetUser() => _user;

        public DateTime DateOfCreation() => _dateOfCreation;

        public string GetAccount() => $"User: {_user.GetUsername()} Date of creation: {DateOfCreation()}";
        
    }
}

