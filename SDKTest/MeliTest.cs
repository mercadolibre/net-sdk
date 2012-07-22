using System;
using NUnit.Framework;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using RestSharp;
using System.Collections.Generic;

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

			var response = m.get ("/sites");

			Assert.AreEqual (HttpStatusCode.OK, response.StatusCode);
			Assert.IsNotNullOrEmpty (response.Content);
		}

		[Test]
		public void getWithRefreshToken ()
		{
			Meli.ApiUrl = "http://localhost:3000";

			Meli m = new Meli (123456, "client secret", "expired token", "valid refresh token");

			var p = new Parameter ();
			p.Name = "access_token";
			p.Value = m.AccessToken;

			var ps = new List<Parameter> ();
			ps.Add (p);
			var response = m.get ("/users/me", ps);

			Assert.AreEqual (HttpStatusCode.OK, response.StatusCode);
			Assert.IsNotNullOrEmpty (response.Content);
		}

		[Test]
		public void handleErrors ()
		{
			Meli.ApiUrl = "http://localhost:3000";
			Meli m = new Meli (123456, "client secret", "invalid token");

			var p = new Parameter ();
			p.Name = "access_token";
			p.Value = m.AccessToken;
			var ps = new List<Parameter> ();
			ps.Add (p);
			var response = m.get ("/users/me", ps);
			Assert.AreEqual (HttpStatusCode.Forbidden, response.StatusCode);
		}

		[Test]
		public void post ()
		{
			Meli.ApiUrl = "http://localhost:3000";
			Meli m = new Meli (123456, "client secret", "valid token");

			var p = new Parameter ();
			p.Name = "access_token";
			p.Value = m.AccessToken;

			var ps = new List<Parameter> ();
			ps.Add (p);
			var r = m.post ("/items", ps, new {foo="bar"});

			Assert.AreEqual (HttpStatusCode.Created, r.StatusCode);
		}

		[Test]
		public void postWithRefreshToken ()
		{
			Meli.ApiUrl = "http://localhost:3000";
			Meli m = new Meli (123456, "client secret", "expired token", "valid refresh token");

			var p = new Parameter ();
			p.Name = "access_token";
			p.Value = m.AccessToken;

			var ps = new List<Parameter> ();
			ps.Add (p);
			var r = m.post ("/items", ps, new {foo="bar"});

			Assert.AreEqual (HttpStatusCode.Created, r.StatusCode);
		}

		[Test]
		public void put ()
		{
			Meli.ApiUrl = "http://localhost:3000";
			Meli m = new Meli (123456, "client secret", "valid token");

			var p = new Parameter ();
			p.Name = "access_token";
			p.Value = m.AccessToken;

			var ps = new List<Parameter> ();
			ps.Add (p);
			var r = m.put ("/items/123", ps, new {foo="bar"});

			Assert.AreEqual (HttpStatusCode.OK, r.StatusCode);
		}

		[Test]
		public void putWithRefreshToken ()
		{
			Meli.ApiUrl = "http://localhost:3000";
			Meli m = new Meli (123456, "client secret", "expired token", "valid refresh token");

			var p = new Parameter ();
			p.Name = "access_token";
			p.Value = m.AccessToken;

			var ps = new List<Parameter> ();
			ps.Add (p);
			var r = m.put ("/items/123", ps, new {foo="bar"});

			Assert.AreEqual (HttpStatusCode.OK, r.StatusCode);
		}

		[Test]
		public void delete ()
		{
			Meli.ApiUrl = "http://localhost:3000";
			Meli m = new Meli (123456, "client secret", "valid token");

			var p = new Parameter ();
			p.Name = "access_token";
			p.Value = m.AccessToken;

			var ps = new List<Parameter> ();
			ps.Add (p);
			var r = m.delete ("/items/123", ps);

			Assert.AreEqual (HttpStatusCode.OK, r.StatusCode);
		}

		[Test]
		public void deleteWithRefreshToken ()
		{
			Meli.ApiUrl = "http://localhost:3000";
			Meli m = new Meli (123456, "client secret", "expired token", "valid refresh token");

			var p = new Parameter ();
			p.Name = "access_token";
			p.Value = m.AccessToken;

			var ps = new List<Parameter> ();
			ps.Add (p);
			var r = m.delete ("/items/123", ps);

			Assert.AreEqual (HttpStatusCode.OK, r.StatusCode);
		}
	}
}