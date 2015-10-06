using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MercadoLibre.SDK.Http
{
    /// <summary>
    /// Helper class to easily get new instances of a <see cref="HttpClient"/> with default behaviour and a retry mechanism.
    /// </summary>
    /// <remarks>
    /// Most of the time only one instance of <see cref="HttpClient"/> should be used per request: 
    /// If you hang on to one instance of HTTP client and change its Timeout setting after a fist request was issued an exception will be thrown.
    /// </remarks>
    public class HttpClientProvider : IHttpClientProvider
    {
        /// <summary>
        /// Hook to intercept HTTP responses and react to them (e.g. automatically authenticate upon 401 Unauthorized responses).
        /// </summary>
        /// <value>
        /// The custom send asynchronous.
        /// </value>
        /// <returns>True when the original request should be retried.</returns>
        public Func<HttpResponseMessage, Task<bool>> RetryIntercept { get; set; }

        /// <summary>
        /// Hook to set default settings on the HTTP client that <see cref="Create(System.Net.Http.HttpMessageHandler, bool)"/> returns.
        /// </summary>
        /// <value>
        /// The initialise with.
        /// </value>
        public Action<HttpClient> InitialiseWith { get; set; }

        /// <summary>
        /// Gets a new instance of <see cref="HttpClient" />.
        /// </summary>
        /// <param name="configureRetryIntercept">if set to <c>true</c> [configure the retry intercept].</param>
        /// <returns></returns>
        public HttpClient Create(bool configureRetryIntercept = true)
        {
            return Create(null, configureRetryIntercept);
        }

        /// <summary>
        /// Gets a new instance of <see cref="HttpClient" />.
        /// </summary>
        /// <param name="innerMessageHandler">The inner message handler.</param>
        /// <param name="configureRetryIntercept">if set to <c>true</c> [configure the retry intercept].</param>
        /// <returns></returns>
        public HttpClient Create(HttpMessageHandler innerMessageHandler, bool configureRetryIntercept = true)
        {
            HttpClient client;

            if (innerMessageHandler == null)
            {
                var innerClientHandler = new HttpClientHandler
                                         {
                                             AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                                         };

                client = RetryIntercept == null || configureRetryIntercept == false
                    ? new HttpClient(innerClientHandler)
                    : new HttpClient(new RetryDelegatingHandler
                                     {
                                         InnerHandler = innerClientHandler,
                                         RetryIntercept = RetryIntercept
                                     });
            }
            else
            {
                client = RetryIntercept == null || configureRetryIntercept == false
                    ? new HttpClient(innerMessageHandler)
                    : new HttpClient(new RetryDelegatingHandler
                                     {
                                         RetryIntercept = RetryIntercept,
                                         InnerHandler = innerMessageHandler
                                     });
            }
                
            if (InitialiseWith != null)
            {
                InitialiseWith(client);
            }

            return client;
        }
    }
}