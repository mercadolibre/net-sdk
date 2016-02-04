using System.Runtime.Serialization;

namespace MercadoLibre.SDK.Models
{
    /// <summary>
    /// Model returned by the API when requesting or refreshing a token.
    /// </summary>
    [DataContract]
    public class TokenResponse
    {
        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        /// <value>
        /// The access token.
        /// </value>
        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the previous access token.
        /// </summary>
        /// <value>
        /// The previous access token.
        /// </value>
        /// <remarks>
        /// Handy when dealing with access tokens from multiple users.
        /// </remarks>
        public string PreviousAccessToken { get; set; }
        
        /// <summary>
        /// Gets or sets the type of the token.
        /// </summary>
        /// <value>
        /// The type of the token.
        /// </value>
        [DataMember(Name = "token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// Gets or sets the number of seconds the tokens expires in (i.e. 6 hours or 21600 seconds).
        /// </summary>
        /// <value>
        /// The expires in.
        /// </value>
        [DataMember(Name = "expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>
        /// Gets or sets the scope.
        /// </summary>
        /// <value>
        /// The scope.
        /// </value>
        [DataMember(Name = "scope")]
        public TokenScope Scope { get; set; }

        /// <summary>
        /// Gets or sets the mercado libre user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        [DataMember(Name = "user_id")]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the refresh token.
        /// </summary>
        /// <value>
        /// The refresh token.
        /// </value>
        [DataMember(Name = "refresh_token")]
        public string RefreshToken { get; set; }
    }
}
