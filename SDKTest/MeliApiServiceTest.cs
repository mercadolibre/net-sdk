using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using HttpParamsUtility;
using MercadoLibre.SDK.Http;
using MercadoLibre.SDK.Meta;
using MercadoLibre.SDK.Models;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using RichardSzalay.MockHttp;

namespace MercadoLibre.SDK
{
    [TestFixture]
    public class MeliApiServiceTest
    {
        private MeliApiService service;

        private Mock<IHttpClientProvider> providerMock;
        private MockHttpMessageHandler mockHttp;

        [SetUp]
        public void Setup()
        {
            providerMock = new Mock<IHttpClientProvider>();
            mockHttp = new MockHttpMessageHandler();

            var credentials = new MeliCredentials(MeliSite.Argentina, 123456, "secret");

            service = new MeliApiService
                      {
                          HttpClientProvider = providerMock.Object,
                          Credentials = credentials
                      };

            providerMock.Setup(call => call.Create(It.IsAny<bool>()))
                        .Returns(new HttpClient(mockHttp));
        }

        [Test]
        public void TestSdkUserAgent()
        {
            Assert.AreEqual("MELI-NET-SDK", MeliApiService.SdkUserAgent);

            MeliApiService.SdkUserAgent = "MY-MELI-NET-SDK";

            Assert.AreEqual("MY-MELI-NET-SDK", MeliApiService.SdkUserAgent);
        }

        [Test]
        public void TestHttpClientIsInitialisedWithDefaultSettings()
        {
            var realService = new MeliApiService();

            var client = realService.HttpClientProvider.Create();

            Assert.IsTrue(client.DefaultRequestHeaders.UserAgent.ToString().StartsWith("MELI-NET-SDK/"));
            Assert.AreEqual("application/json", client.DefaultRequestHeaders.Accept.ToString());
        }

        [Test]
        public void TestGetAuthUrl()
        {
            var url = service.GetAuthUrl(123456, MeliSite.Mexico, "http://someurl.com");

            Assert.AreEqual("https://auth.mercadolibre.com.mx/authorization?response_type=code&client_id=123456&redirect_uri=http%3a%2f%2fsomeurl.com", url);
        }

        [Test]
        public async void TestAuthorizeAsyncIsSuccessfull()
        {
            service.Credentials.Site = MeliSite.Mexico;

            var eventArgs = new List<MeliTokenEventArgs>();

            service.Credentials.TokensChanged += (sender, args) => eventArgs.Add(args);

            service.Credentials.Site = MeliSite.Mexico;

            var response = new TokenResponse
                           {
                               AccessToken = "valid token",
                               RefreshToken = "valid refresh token"
                           };

            mockHttp.Expect(HttpMethod.Post, "https://api.mercadolibre.com/oauth/token")
                    .WithQueryString("grant_type", "authorization_code")
                    .WithQueryString("client_id", "123456")
                    .WithQueryString("client_secret", "secret")
                    .WithQueryString("code", "valid code with refresh token")
                    .WithQueryString("redirect_uri", "https://someurl.com")
                    .Respond("application/json", JsonConvert.SerializeObject(response));

            var success = await service.AuthorizeAsync("valid code with refresh token", "https://someurl.com");

            Assert.IsTrue(success);

            Assert.AreEqual("valid token", service.Credentials.AccessToken);
            Assert.AreEqual("valid refresh token", service.Credentials.RefreshToken);

            Assert.AreEqual(1, eventArgs.Count);
            Assert.AreEqual("valid token", eventArgs[0].Info.AccessToken);
            Assert.AreEqual("valid refresh token", eventArgs[0].Info.RefreshToken);

            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Test]
        public async void TestAuthorizeAsyncIsNotSuccessfull()
        {
            service.Credentials.Site = MeliSite.Ecuador;

            mockHttp.Expect(HttpMethod.Post, "https://api.mercadolibre.com/oauth/token")
                    .WithQueryString("grant_type", "authorization_code")
                    .WithQueryString("code", "invalid code")
                    .WithQueryString("redirect_uri", "https://someurl.com")
                    .Respond(HttpStatusCode.Unauthorized);

            var success = await service.AuthorizeAsync("invalid code", "https://someurl.com");

            Assert.IsFalse(success);

            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Test]
        public async void TestGetAsyncToGetSites()
        {
            service.Credentials.Site = MeliSite.Peru;
            
            var responsePayload = new[] {new {id = "MLA", name = "Argentina"}, new {id = "MLB", name = "Brazil"}};

            mockHttp.Expect(HttpMethod.Get, "https://api.mercadolibre.com/sites")
                    .Respond("application/json", JsonConvert.SerializeObject(responsePayload));

            var response = await service.GetAsync("/sites");

            Assert.IsTrue(response.IsSuccessStatusCode);

            var json = await response.Content.ReadAsStringAsync();

            var sites = JsonConvert.DeserializeAnonymousType(json, new[] {new {id = "Mxx", name = "name"}});

            Assert.Less(0, sites.Length);
            Assert.AreEqual("MLA", sites[0].id);
            Assert.AreEqual("Argentina", sites[0].name);

            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Test]
        public async void TestGetAsyncHandleErrors()
        {
            mockHttp.Expect(HttpMethod.Get, "/users/me")
                    .Respond(HttpStatusCode.InternalServerError);

            var response = await service.GetAsync("/users/me");

            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);

            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Test]
        public async void TestPostAsync()
        {
            mockHttp.Expect(HttpMethod.Post, "/items")
                    .WithQueryString("hello", "boo boo")
                    .WithContent(@"{""foo"":""bar""}")
                    .Respond(HttpStatusCode.Created);

            var response = await service.PostAsync("/items", new HttpParams().Add("hello", "boo boo"), new {foo = "bar"});

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Test]
        public async void TestPutAsync()
        {
            mockHttp.Expect(HttpMethod.Put, "/items/123")
                    .WithContent(@"{""foo"":""bar""}")
                    .Respond(HttpStatusCode.OK);

            var response = await service.PutAsync("/items/123", null, new {foo = "bar"});

            Assert.IsTrue(response.IsSuccessStatusCode);

            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Test]
        public async void TestDeleteAsync()
        {
            mockHttp.Expect(HttpMethod.Delete, "/items/123")
                    .Respond(HttpStatusCode.OK);

            var response = await service.DeleteAsync("/items/123");

            Assert.IsTrue(response.IsSuccessStatusCode);

            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Test]
        public void TestReplaceAccessToken()
        {
            var url = "https://api.mercadolibre.com/moderations/denounces/MLB11378/ITM/options?first=value&access_token=APP_USR-5128891793554461-041805-e0dd11044b96a343fcb6b1361800bbb0__F_A__-191075056&another=one";

            var request = new HttpRequestMessage(HttpMethod.Post, new Uri(url));

            MeliApiService.ReplaceAccessToken(request, "new_token_value");

            Assert.AreEqual("https://api.mercadolibre.com/moderations/denounces/MLB11378/ITM/options?first=value&access_token=new_token_value&another=one", request.RequestUri.AbsoluteUri);
        }

        [Test]
        public void TestReplaceAccessTokenWhenNothingToReplace()
        {
            var url = "https://api.mercadolibre.com/moderations/denounces/MLB11378/ITM/options?first=value&another=one";

            var request = new HttpRequestMessage(HttpMethod.Post, new Uri(url));

            MeliApiService.ReplaceAccessToken(request, "new_token_value");

            Assert.AreEqual("https://api.mercadolibre.com/moderations/denounces/MLB11378/ITM/options?first=value&another=one", request.RequestUri.AbsoluteUri);
        }
    }
}