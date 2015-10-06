using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MercadoLibre.SDK.Http
{
    [TestFixture]
    public class HttpClientProviderTest
    {
        [Test]
        public void TestHttpClientAlwaysReturnsNewInstance()
        {
            var provider = new HttpClientProvider();

            var client1 = provider.Create();
            var client2 = provider.Create();

            Assert.AreNotSame(client1, client2);
        }

        [Test]
        public void TestHttpClientWithCustomInitialisation()
        {
            var provider = new HttpClientProvider
                           {
                               InitialiseWith = (c) => c.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Test", "1.0"))
                           };

            var client = provider.Create();

            Assert.AreEqual("Test/1.0", client.DefaultRequestHeaders.UserAgent.ToString());
        }

        private class FakeHandler : HttpMessageHandler
        {
            public int RequestCount = 0;

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                RequestCount++;
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
            }
        }

        [Test]
        public void TestHttpClientWithRetryIntercept()
        {
            var interceptCount = 0;

            var innerHandler = new FakeHandler();

            var provider = new HttpClientProvider
                           {
                               RetryIntercept = async delegate
                                   {
                                       interceptCount++;
                                       return false;
                                   }
                           };

            var client = provider.Create(innerHandler);

            client.GetAsync("http://hello.world/boo");

            Assert.AreEqual(1, interceptCount);
            Assert.AreEqual(1, innerHandler.RequestCount);
        }

        [Test]
        public void TestHttpClientWithRetryInterceptWhenShouldRetry()
        {
            var interceptCount = 0;

            var innerHandler = new FakeHandler();

            var provider = new HttpClientProvider
                           {
                               RetryIntercept = async delegate
                                   {
                                       interceptCount++;
                                       return true;
                                   }
                           };

            var client = provider.Create(innerHandler);

            client.GetAsync("http://hello.world/boo");

            Assert.AreEqual(1, interceptCount);
            Assert.AreEqual(2, innerHandler.RequestCount);
        }

        [Test]
        public void TestHttpClientWithRetryInterceptWithRetryInterceptSetButShouldNotRetry()
        {
            var interceptCount = 0;

            var innerHandler = new FakeHandler();

            var provider = new HttpClientProvider
                           {
                               RetryIntercept = async delegate
                                   {
                                       interceptCount++;
                                       return true;
                                   }
                           };

            var client = provider.Create(innerHandler, false);

            client.GetAsync("http://hello.world/boo");

            Assert.AreEqual(0, interceptCount);
            Assert.AreEqual(1, innerHandler.RequestCount);
        }
    }
}
