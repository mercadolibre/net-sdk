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
            var credentials = new MeliCredentials(MeliSite.Panama, 123456, "secret", "oldToken", "oldRefreshToken");

            var model = new TokenResponse {AccessToken = "newToken", RefreshToken = "newRefreshToken"};

            credentials.SetTokens(model);

            Assert.AreEqual("newToken", credentials.AccessToken);
            Assert.AreEqual("oldToken", model.PreviousAccessToken);
            Assert.AreEqual("newRefreshToken", credentials.RefreshToken);
        }

        [Test]
        public void TestSetTokensFiresEvent()
        {
            var credentials = new MeliCredentials(MeliSite.Panama, 123456, "secret", "oldToken");

            credentials.TokensChanged += (sender, args) => receivedEvents.Add(args);

            var model = new TokenResponse { AccessToken = "access", RefreshToken = "refresh" };

            credentials.SetTokens(model);

            Assert.AreEqual(1, receivedEvents.Count);
            Assert.AreSame(model, receivedEvents[0].Info);

            model.AccessToken = "new";
            model.RefreshToken = "value";

            Assert.AreEqual("oldToken", model.PreviousAccessToken);
            Assert.AreEqual("oldToken", receivedEvents[0].Info.PreviousAccessToken);

            credentials.SetTokens(model);

            Assert.AreEqual(2, receivedEvents.Count);
            Assert.AreSame(model, receivedEvents[0].Info);
            Assert.AreSame(receivedEvents[0].Info, receivedEvents[1].Info);
            Assert.AreEqual("access", model.PreviousAccessToken);
            Assert.AreEqual("access", receivedEvents[1].Info.PreviousAccessToken);
        }
    }
}
