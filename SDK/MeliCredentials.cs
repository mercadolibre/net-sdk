using System;
using MercadoLibre.SDK.Meta;
using MercadoLibre.SDK.Models;

namespace MercadoLibre.SDK
{
    /// <summary>
    /// Convienience class to store the mercado libre crendentials in one place.
    /// </summary>
    public class MeliCredentials
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MeliCredentials"/> class.
        /// </summary>
        public MeliCredentials()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MeliCredentials" /> class.
        /// </summary>
        /// <param name="site">The site.</param>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="refreshToken">The refresh token.</param>
        public MeliCredentials(MeliSite site, long clientId, string clientSecret, string accessToken = null, string refreshToken = null)
        {
            Site = site;
            ClientId = clientId;
            ClientSecret = clientSecret;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        /// <summary>
        /// Gets or sets the Mercado Libre site.
        /// </summary>
        /// <value>
        /// The site.
        /// </value>
        public MeliSite Site { get; set; }

        /// <summary>
        /// Gets the client identifier.
        /// </summary>
        /// <value>
        /// The client identifier.
        /// </value>
        public long ClientId { get; set; }

        /// <summary>
        /// Gets the client secret.
        /// </summary>
        /// <value>
        /// The client secret.
        /// </value>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets the access token.
        /// </summary>
        /// <value>
        /// The access token.
        /// </value>
        public string AccessToken { get; private set; }
        
        /// <summary>
        /// Gets the refresh token (when set the access token will be renewed automatically).
        /// </summary>
        /// <value>
        /// The refresh token.
        /// </value>
        public string RefreshToken { get; private set; }

        /// <summary>
        /// Sets the tokens.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <remarks>
        /// Fires the 
        /// <see cref="OnTokensChanged" /> event if the token values have changed.
        /// Listen to this event if you need to persists the tokens.
        /// </remarks>
        public MeliCredentials SetTokens(TokenResponse model)
        {
            if (AccessToken != model.AccessToken || RefreshToken != model.RefreshToken)
            {
                model.PreviousAccessToken = AccessToken;
                OnTokensChanged(new MeliTokenEventArgs {Info = model});
            }

            AccessToken = model.AccessToken;
            RefreshToken = model.RefreshToken;

            return this;
        }

        /// <summary>
        /// Occurs when [tokens changed].
        /// </summary>
        public event TokensChangedEventHandler TokensChanged;

        /// <summary>
        /// Raises the <see cref="E:Changed" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnTokensChanged(MeliTokenEventArgs e)
        {
            if (TokensChanged != null)
            {
                TokensChanged(this, e);
            }
        }
    }

    /// <summary>
    /// Event data for the tokens changed event.
    /// </summary>
    public class MeliTokenEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the token information.
        /// </summary>
        /// <value>
        /// The information.
        /// </value>
        public TokenResponse Info { get; set; }
    }

    /// <summary>
    /// The tokens changed event handler.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    public delegate void TokensChangedEventHandler(object sender, MeliTokenEventArgs e);
}
