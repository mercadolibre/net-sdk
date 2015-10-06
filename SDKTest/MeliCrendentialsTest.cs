using System;
using System.Collections.Generic;
using MercadoLibre.SDK.Meta;
using MercadoLibre.SDK.Models;
using NUnit.Framework;

namespace MercadoLibre.SDK
{
    [TestFixture]
    public class MeliCrendentialsTest
    {
        readonly List<MeliTokenEventArgs> receivedEvents = new List<MeliTokenEventArgs>();

        [SetUp]
        public void Setup()
        {
            receivedEvents.Clear();
        }

        [Test]
        public void TestConstructor()
        {
            var credentials = new MeliCredentials(MeliSite.Panama, 123456, "secret", "access token", "refresh token");

            Assert.AreEqual(MeliSite.Panama, credentials.Site);
            Assert.AreEqual(123456, credentials.ClientId);
            Assert.AreEqual("secret", credentials.ClientSecret);
            Assert.AreEqual("access token", credentials.AccessToken);
            Assert.AreEqual("refresh token", credentials.RefreshToken);
        }

        [Test]
        public void TestSetTokens()
        {
            var credentials = new MeliCredentials(MeliSite.Panama, 123456, "secret");

            var model = new TokenResponse {AccessToken = "access", RefreshToken = "refresh"};

            credentials.SetTokens(model);

            Assert.AreEqual("access", credentials.AccessToken);
            Assert.AreEqual("refresh", credentials.RefreshToken);
        }

        [Test]
        public void TestSetTokensFiresEvent()
        {
            var credentials = new MeliCredentials(MeliSite.Panama, 123456, "secret");

            credentials.TokensChanged += (sender, args) => receivedEvents.Add(args);

            var model = new TokenResponse { AccessToken = "access", RefreshToken = "refresh" };

            credentials.SetTokens(model);

            Assert.AreEqual(1, receivedEvents.Count);
            Assert.AreSame(model, receivedEvents[0].Info);

            model.AccessToken = "new";
            model.RefreshToken = "value";

            credentials.SetTokens(model);

            Assert.AreEqual(2, receivedEvents.Count);
            Assert.AreSame(model, receivedEvents[0].Info);
        }
    }
}
