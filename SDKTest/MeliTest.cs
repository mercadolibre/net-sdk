using System;
using NUnit.Framework;
using System.Net;
using System.IO;
using System.Collections.Specialized;

namespace com.mercadolibre.sdk.test
{
	[TestFixture]
	public class MeliTest
	{
		[Test]
		public void getAuthUrl ()
		{
			Meli m = new Meli (123456, "client secret");

			Assert.AreEqual ("https://auth.mercadolibre.com.ar/authorization?response_type=code&client_id=123456&redirect_uri=http%3a%2f%2fsomeurl.com", m.getAuthUrl ("http://someurl.com"));
		}

		[Test]
		public void authorizationSuccess ()
		{
			Meli.ApiUrl = "http://localhost:3000";

			Meli m = new Meli (123456, "secret client");
			m.authorize ("valid code with refresh token", "http://someurl.com");

			Assert.AreEqual ("valid token", m.AccessToken);
			Assert.AreEqual ("valid refresh token", m.RefreshToken);
		}

		[Test]
		[ExpectedException(typeof(AuthorizationException))]
		public void authorizationFailure ()
		{
			Meli.ApiUrl = "http://localhost:3000";

			Meli m = new Meli (123456, "secret client");
			m.authorize ("invalid code", "http://someurl.com");
		}

		[Test]
		public void get ()
		{
			Meli.ApiUrl = "http://localhost:3000";

			Meli m = new Meli (123456, "client secret", "valid token");

			HttpWebResponse response = m.get ("/sites");

			Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
			Assert.IsNotNullOrEmpty(new StreamReader(response.GetResponseStream()).ReadToEnd());
		}

		[Test]
		public void getWithRefreshToken ()
		{
			Meli.ApiUrl = "http://localhost:3000";

			Meli m = new Meli (123456, "client secret", "expired token", "valid refresh token");

			NameValueCollection param = new NameValueCollection();
			param.Add("access_token", m.AccessToken);
			HttpWebResponse response = m.get ("/users/me", param);

			Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
			Assert.IsNotNullOrEmpty(new StreamReader(response.GetResponseStream()).ReadToEnd());
		}

	}
}