using System;
namespace Application.Exceptions
{
	public class InvalidPasswordAccountException : Exception
	{
		public InvalidPasswordAccountException(string message) : base(message)
		{
		}
	}
}

