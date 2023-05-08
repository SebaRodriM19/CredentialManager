using System;
namespace Application.Exceptions
{
	public class AccountAlreadyExistsException : Exception
	{
		public AccountAlreadyExistsException(string message) : base(message)
		{
		}
	}
}

