using System;

namespace com.mercadolibre.sdk
{
	public class AuthorizationException : Exception
	{
		public AuthorizationException ()
		{
		}

		public AuthorizationException(string msg, Exception ex) : base(msg, ex) {
		}
	}
}

