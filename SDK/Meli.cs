using System;
using System.Web;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;

namespace com.mercadolibre.sdk
{
	public class Meli
	{
		static private string apiUrl = "https://api.mercadolibre.com";

		static public string ApiUrl {
			get {
				return apiUrl;
			}
			set {
				apiUrl = value;
			}
		}

		public string ClientSecret { get; private set; }

		public int ClientId { get; private set; }

		public string AccessToken { get; private set; }

		public string RefreshToken { get; private set; }

		public Meli (int clientId, string clientSecret)
		{
			this.ClientId = clientId;
			this.ClientSecret = clientSecret;
		}

		public Meli (int clientId, string clientSecret, string accessToken)
		{
			this.ClientId = clientId;
			this.ClientSecret = clientSecret;
			this.AccessToken = accessToken;
		}

		public Meli (int clientId, string clientSecret, string accessToken, string refreshToken)
		{
			this.ClientId = clientId;
			this.ClientSecret = clientSecret;
			this.AccessToken = accessToken;
			this.RefreshToken = refreshToken;
		}

		public string getAuthUrl (string redirectUri)
		{
			return "https://auth.mercadolibre.com.ar/authorization?response_type=code&client_id=" + ClientId + "&redirect_uri=" + HttpUtility.UrlEncode (redirectUri);
		}

		public void authorize (string code, string redirectUri)
		{
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (ApiUrl + "/oauth/token?grant_type=authorization_code&client_id=" + this.ClientId + "&client_secret=" + this.ClientSecret + "&code=" + code + "&redirect_uri=" + redirectUri);
			request.Accept = "application/json";
			request.Method = "POST";

			try {
				HttpWebResponse response = (HttpWebResponse)request.GetResponse ();
				if (response.StatusCode.Equals (HttpStatusCode.OK)) {
					using (var rs = response.GetResponseStream()) {
						using (var sr = new StreamReader(rs)) {
							var token = JsonConvert.DeserializeAnonymousType (sr.ReadToEnd (), new {refresh_token="", access_token = ""});
							this.AccessToken = token.access_token;
							this.RefreshToken = token.refresh_token;
						}
					}
				} else {
					throw new AuthorizationException ();
				}
			} catch (WebException ex) {
				throw new AuthorizationException ("Couldn't authorize.", ex);
			}
		}

		public HttpWebResponse get (string resource)
		{
			return get (resource, new NameValueCollection ());
		}

		public HttpWebResponse get (string resource, StringDictionary parameters)
		{
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (ApiUrl + resource + "?" + ToQueryString (parameters));
			request.Accept = "application/json";
			request.Method = "GET";

			try {
				HttpWebResponse response = (HttpWebResponse)request.GetResponse ();
				return response;
			} catch (WebException ex) {
				if(parameters.get ex.Status==
			}
			return response;
		}

		private string ToQueryString (StringDictionary nvc)
		{
			return "?" + string.Join ("&", Array.ConvertAll (nvc.AllKeys, key => string.Format ("{0}={1}", HttpUtility.UrlEncode (key), HttpUtility.UrlEncode (nvc [key]))));
		}
	}
}