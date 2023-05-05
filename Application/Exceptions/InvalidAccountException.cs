using System;
namespace Application.Exceptions
{
	public class InvalidAccountException :Exception
	{
		public InvalidAccountException(string message) : base(message)
		{
		}
	}
}

