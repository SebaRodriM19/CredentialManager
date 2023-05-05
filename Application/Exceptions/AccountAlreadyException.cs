using System;
namespace Application.Exceptions
{
	public class AccountAlreadyException : Exception
	{
		public AccountAlreadyException(string message) : base(message)
		{
		}
	}
}

