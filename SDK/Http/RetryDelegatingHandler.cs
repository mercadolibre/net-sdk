using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MercadoLibre.SDK.Http
{
    /// <summary>
    /// HTTP Message handler that inspect status code in responses and automatically tries to refresh the token if a refresh token is set.
    /// </summary>
    public class RetryDelegatingHandler : DelegatingHandler
    {
        /// <summary>
        /// Gets or sets a hook to determinue (and optionaly take action (e.g. authenticate)) wether the request should be retried or not.
        /// </summary>
        /// <value>
        /// The retry intercept.
        /// </value>
        /// <returns>True when the original request should be retried.</returns>
        public Func<HttpResponseMessage, Task<bool>> RetryIntercept { get; set; }

        /// <summary>
        /// Sends an HTTP request to the inner handler to send to the server as an asynchronous operation.
        /// </summary>
        /// <param name="request">The HTTP request message to send to the server.</param>
        /// <param name="cancellationToken">A cancellation token to cancel operation.</param>
        /// <returns>
        /// Returns <see cref="T:System.Threading.Tasks.Task`1" />. The task object representing the asynchronous operation.
        /// </returns>
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (RetryIntercept != null)
            {
                // Hook to determine wether the request should be retried or not
                if (await RetryIntercept(response))
                {
                    // Retry
                    response = await base.SendAsync(request, cancellationToken);
                }
            }

            return response;
        }
    }
}