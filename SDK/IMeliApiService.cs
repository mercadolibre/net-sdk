using System.Net.Http;
using System.Threading.Tasks;
using HttpParamsUtility;
using MercadoLibre.SDK.Meta;

namespace MercadoLibre.SDK
{
    /// <summary>
    /// Interface for the service wrapping access to the Mercado Libre REST API.
    /// </summary>
    public interface IMeliApiService
    {
        /// <summary>
        /// Gets or sets the crendentials.
        /// </summary>
        /// <value>
        /// The crendentials.
        /// </value>
        /// <remarks>
        /// - Don't forget to set this before calling methods that require an API token.
        /// - You can subscribe to events on <see cref="MeliCredentials"/> to track when the tokens are refreshed.
        /// </remarks>
        MeliCredentials Credentials { get; set; }

        /// <summary>
        /// Generate an URL to get an access token for other users.
        /// </summary>
        /// <param name="clientId">The client identifier (meli app ID).</param>
        /// <param name="site">The site.</param>
        /// <param name="redirectUri">The call back URI redirect URL to (Mercado Libre with append ?code=YOUR_SECRET_CODE to this URL).</param>
        /// <returns>The authentication URL to redirect your user to.</returns>
        string GetAuthUrl(long clientId, MeliSite site, string redirectUri);

        /// <summary>
        /// Requests an access and refresh token from the code provided by the mercado libre callback.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="redirectUri">The redirect URI.</param>
        /// <returns>Return True when the operation is successful.</returns>
        Task<bool> AuthorizeAsync(string code, string redirectUri);

        /// <summary>
        /// Sends a GET request.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        Task<HttpResponseMessage> GetAsync(string resource, HttpParams parameters = null);

        /// <summary>
        /// Sends a GET request and deserialises the JSON response.
        /// </summary>
        /// <typeparam name="T">The class to use to deserialise the JSON response.</typeparam>
        /// <param name="resource">The resource.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        Task<T> GetAsync<T>(string resource, HttpParams parameters = null);

        /// <summary>
        /// Sends a POST request.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="content">The payload for the content of the HTTP request.</param>
        /// <returns></returns>
        Task<HttpResponseMessage> PostAsync(string resource, HttpParams parameters = null, object content = null);

        /// <summary>
        /// Sends a POST request and deserialises the JSON response.
        /// </summary>
        /// <typeparam name="T">The class to use to deserialise the JSON response.</typeparam>
        /// <param name="resource">The resource.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="content">The payload for the content of the HTTP request.</param>
        /// <returns></returns>
        Task<T> PostAsync<T>(string resource, HttpParams parameters = null, object content = null);

        /// <summary>
        /// Sends a PUT request.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        Task<HttpResponseMessage> PutAsync(string resource, HttpParams parameters = null, object content = null);

        /// <summary>
        /// Sends a PUT request and deserialises the JSON response.
        /// </summary>
        /// <typeparam name="T">The class to use to deserialise the JSON response.</typeparam>
        /// <param name="resource">The resource.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        Task<T> PutAsync<T>(string resource, HttpParams parameters = null, object content = null);

        /// <summary>
        /// Sends a DELETE request.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        Task<HttpResponseMessage> DeleteAsync(string resource, HttpParams parameters = null);

        /// <summary>
        /// Sends a DELETE request and deserialises the JSON response.
        /// </summary>
        /// <typeparam name="T">The class to use to deserialise the JSON response.</typeparam>
        /// <param name="resource">The resource.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        Task<T> DeleteAsync<T>(string resource, HttpParams parameters = null);
    }
}