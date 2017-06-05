using NUnit.Framework;
using System.Net;
using RestSharp;
using System.Collections.Generic;

namespace MercadoLibre.SDK.Test
{
    [TestFixture]
    public class MeliTest
    {
        [Test]
        public void GetAuthUrl()
        {
            var m = new Meli(123456, "client secret");
            Assert.AreEqual(Meli.AuthUrls.MLA + "/authorization?response_type=code&client_id=123456&redirect_uri=http%3a%2f%2fsomeurl.com", m.GetAuthUrl(Meli.AuthUrls.MLA, "http://someurl.com"));
        }

        [Test]
        public void AuthorizationSuccess()
        {
            Meli.ApiUrl = "http://localhost:3000";

            var m = new Meli(123456, "secret client");
            m.Authorize("valid code with refresh token", "http://someurl.com");

            Assert.AreEqual("valid token", m.AccessToken);
            Assert.AreEqual("valid refresh token", m.RefreshToken);
        }

        [Test]
        [ExpectedException(typeof(AuthorizationException))]
        public void AuthorizationFailure()
        {
            Meli.ApiUrl = "http://localhost:3000";

            var m = new Meli(123456, "secret client");
            m.Authorize("invalid code", "http://someurl.com");
        }

        [Test]
        public void Get()
        {
            Meli.ApiUrl = "http://localhost:3000";

            var m = new Meli(123456, "client secret", "valid token");

            var response = m.Get("/sites");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNullOrEmpty(response.Content);
        }

        [Test]
        public void GetWithRefreshToken()
        {
            Meli.ApiUrl = "http://localhost:3000";

            var m = new Meli(123456, "client secret", "expired token", "valid refresh token");

            var p = new Parameter
            {
                Name = "access_token",
                Value = m.AccessToken
            };

            var ps = new List<Parameter> { p };
            var response = m.Get("/users/me", ps);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNullOrEmpty(response.Content);
        }

        [Test]
        public void HandleErrors()
        {
            Meli.ApiUrl = "http://localhost:3000";
            var m = new Meli(123456, "client secret", "invalid token");

            var p = new Parameter
            {
                Name = "access_token",
                Value = m.AccessToken
            };

            var ps = new List<Parameter> { p };

            var response = m.Get("/users/me", ps);
            Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
        }

        [Test]
        public void Post()
        {
            Meli.ApiUrl = "http://localhost:3000";
            var m = new Meli(123456, "client secret", "valid token");

            var p = new Parameter
            {
                Name = "access_token",
                Value = m.AccessToken
            };

            var ps = new List<Parameter> { p };
            var r = m.Post("/items", ps, new { foo = "bar" });

            Assert.AreEqual(HttpStatusCode.Created, r.StatusCode);
        }

        [Test]
        public void PostWithRefreshToken()
        {
            Meli.ApiUrl = "http://localhost:3000";
            var m = new Meli(123456, "client secret", "expired token", "valid refresh token");

            var p = new Parameter
            {
                Name = "access_token",
                Value = m.AccessToken
            };

            var ps = new List<Parameter> { p };
            var r = m.Post("/items", ps, new { foo = "bar" });

            Assert.AreEqual(HttpStatusCode.Created, r.StatusCode);
        }

        [Test]
        public void Put()
        {
            Meli.ApiUrl = "http://localhost:3000";
            var m = new Meli(123456, "client secret", "valid token");

            var p = new Parameter
            {
                Name = "access_token",
                Value = m.AccessToken
            };

            var ps = new List<Parameter> { p };
            var r = m.Put("/items/123", ps, new { foo = "bar" });

            Assert.AreEqual(HttpStatusCode.OK, r.StatusCode);
        }

        [Test]
        public void PutWithRefreshToken()
        {
            Meli.ApiUrl = "http://localhost:3000";
            var m = new Meli(123456, "client secret", "expired token", "valid refresh token");

            var p = new Parameter
            {
                Name = "access_token",
                Value = m.AccessToken
            };

            var ps = new List<Parameter> { p };
            var r = m.Put("/items/123", ps, new { foo = "bar" });

            Assert.AreEqual(HttpStatusCode.OK, r.StatusCode);
        }

        [Test]
        public void Delete()
        {
            Meli.ApiUrl = "http://localhost:3000";
            var m = new Meli(123456, "client secret", "valid token");

            var p = new Parameter
            {
                Name = "access_token",
                Value = m.AccessToken
            };

            var ps = new List<Parameter> { p };
            var r = m.Delete("/items/123", ps);

            Assert.AreEqual(HttpStatusCode.OK, r.StatusCode);
        }

        [Test]
        public void DeleteWithRefreshToken()
        {
            Meli.ApiUrl = "http://localhost:3000";
            var m = new Meli(123456, "client secret", "expired token", "valid refresh token");

            var p = new Parameter
            {
                Name = "access_token",
                Value = m.AccessToken
            };

            var ps = new List<Parameter> { p };
            var r = m.Delete("/items/123", ps);

            Assert.AreEqual(HttpStatusCode.OK, r.StatusCode);
        }

        [Test]
        public void TestUserAgent()
        {
            Meli.ApiUrl = "http://localhost:3000";
            var m = new Meli(123456, "client secret", "expired token", "valid refresh token");

            var response = m.Get("/echo/user_agent");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
