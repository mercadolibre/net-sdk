using System;
using System.Web;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;
using RestSharp;
using System.Collections.Generic;

namespace MercadoLibre.SDK
{
	public class Meli
	{

        private RestClient client = new RestClient (ApiUrl);
		static private string apiUrl = "https://api.mercadolibre.com";
		static private string sdkVersion = "MELI-NET-SDK-1.0.2";
		static public string ApiUrl {
			get {
				return apiUrl;
			}
			set {
				apiUrl = value;
			}
		}

        public static class AuthUrls
        {
            public static string MLA { get { return "https://auth.mercadolibre.com.ar"; } } //Argentina
            public static string MLB { get { return "https://auth.mercadolivre.com.br"; } } // Brasil
            public static string MCO { get { return "https://auth.mercadolibre.com.co"; } } // Colombia
            public static string MCR { get { return "https://auth.mercadolibre.com.cr"; } } // Costa Rica
            public static string MEC { get { return "https://auth.mercadolibre.com.ec"; } } // Ecuador
            public static string MLC { get { return "https://auth.mercadolibre.cl"; } } // Chile
            public static string MLM { get { return "https://auth.mercadolibre.com.mx"; } } // Mexico
            public static string MLU { get { return "https://auth.mercadolibre.com.uy"; } } // Uruguay
            public static string MLV { get { return "https://auth.mercadolibre.com.ve"; } } // Venezuela
            public static string MPA { get { return "https://auth.mercadolibre.com.pa"; } } // Panama
            public static string MPE { get { return "https://auth.mercadolibre.com.pe"; } } // Peru
            public static string MPT { get { return "https://auth.mercadolibre.com.pt"; } } // Portugal
            public static string MRD { get { return "https://auth.mercadolibre.com.do"; } } // Dominicana


        }

        public string ClientSecret { get; private set; }

		public long ClientId { get; private set; }

		public string AccessToken { get; private set; }

		public string RefreshToken { get; private set; }

        /** News **/

        public long ExperiIn { get; private set; }

        public string Scope { get; private set; }

        public string UserId { get; private set; }

        public string TokenType { get; private set; }


		public Meli (long clientId, string clientSecret)
		{
			this.ClientId = clientId;
			this.ClientSecret = clientSecret;
		}

		public Meli (long clientId, string clientSecret, string accessToken)
		{
			this.ClientId = clientId;
			this.ClientSecret = clientSecret;
			this.AccessToken = accessToken;
		}

      
        public Meli (long clientId, string clientSecret, string accessToken, string refreshToken)
		{
			this.ClientId = clientId;
			this.ClientSecret = clientSecret;
			this.AccessToken = accessToken;
			this.RefreshToken = refreshToken;
		}

		public string GetAuthUrl (string authUrl , string redirectUri)
		{

			return authUrl+"/authorization?response_type=code&client_id=" + ClientId + "&redirect_uri=" + HttpUtility.UrlEncode (redirectUri);
		}

		public void Authorize (string code, string redirectUri)
		{
			var request = new RestRequest ("/oauth/token?grant_type=authorization_code&client_id={client_id}&client_secret={client_secret}&code={code}&redirect_uri={redirect_uri}", Method.POST);

			request.AddParameter ("client_id", this.ClientId, ParameterType.UrlSegment);
			request.AddParameter ("client_secret", this.ClientSecret, ParameterType.UrlSegment);
			request.AddParameter ("code", code, ParameterType.UrlSegment);
			request.AddParameter ("redirect_uri", redirectUri, ParameterType.UrlSegment);

			request.AddHeader ("Accept", "application/json");

			var response = ExecuteRequest (request);

			if (response.StatusCode.Equals (HttpStatusCode.OK)) {
				var token = JsonConvert.DeserializeAnonymousType (response.Content, new {refresh_token="", access_token = "", expires_in = 0,
                user_id = "", scope = "", token_type = ""});
				this.AccessToken = token.access_token;
				this.RefreshToken = token.refresh_token;
                this.ExperiIn = Convert.ToInt64(token.expires_in);
                this.Scope = token.scope;
                this.UserId = token.user_id;
                this.TokenType = token.token_type;
            } else {
				throw new AuthorizationException (response.Content);
			}
		}

		public IRestResponse Get (string resource)
		{
			return Get (resource, new List<Parameter> ());
		}

		public void refreshToken ()
		{
			var request = new RestRequest ("/oauth/token?grant_type=refresh_token&client_id={client_id}&client_secret={client_secret}&refresh_token={refresh_token}", Method.POST);
			request.AddParameter ("client_id", this.ClientId, ParameterType.UrlSegment);
			request.AddParameter ("client_secret", this.ClientSecret, ParameterType.UrlSegment);
			request.AddParameter ("refresh_token", this.RefreshToken, ParameterType.UrlSegment);

			request.AddHeader ("Accept", "application/json");

			var response = ExecuteRequest (request);

			if (response.StatusCode.Equals (HttpStatusCode.OK)) {
				var token = JsonConvert.DeserializeAnonymousType (response.Content, new {refresh_token="", access_token = "", expires_in = 0,
                user_id = "", scope = "", token_type = ""});
                this.AccessToken = token.access_token;
                this.RefreshToken = token.refresh_token;
                this.ExperiIn = Convert.ToInt64(token.expires_in);
                this.Scope = token.scope;
                this.UserId = token.user_id;
                this.TokenType = token.token_type;
            } else {
					throw new AuthorizationException (response.Content);
			}
		}

     
        public void refreshToken(string refresh_token )
        {
            var request = new RestRequest("/oauth/token?grant_type=refresh_token&client_id={client_id}&client_secret={client_secret}&refresh_token={refresh_token}", Method.POST);
            request.AddParameter("client_id", this.ClientId, ParameterType.UrlSegment);
            request.AddParameter("client_secret", this.ClientSecret, ParameterType.UrlSegment);
            request.AddParameter("refresh_token", refresh_token, ParameterType.UrlSegment);

            request.AddHeader("Accept", "application/json");

            var response = ExecuteRequest(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                var token = JsonConvert.DeserializeAnonymousType(response.Content, new
                {
                    refresh_token = "",
                    access_token = "",
                    expires_in = 0,
                    user_id = "",
                    scope = "",
                    token_type = ""
                });
                this.AccessToken = token.access_token;
                this.RefreshToken = token.refresh_token;
                this.ExperiIn = Convert.ToInt64(token.expires_in);
                this.Scope = token.scope;
                this.UserId = token.user_id;
                this.TokenType = token.token_type;
            }
            else
            {
                	throw new AuthorizationException (response.Content);
            }
        }

        public IRestResponse Get (string resource, List<Parameter> param)
		{
			bool containsAT = false;

			var request = new RestRequest (resource, Method.GET);
			List<string> names = new List<string> ();
			foreach (Parameter p in param) {
				names.Add (p.Name + "={" + p.Name + "}");
				if (p.Name.Equals ("access_token")) {
					containsAT = true;
				}
				p.Type = ParameterType.UrlSegment;
				request.AddParameter (p);
			}

			request.Resource = resource + "?" + String.Join ("&", names.ToArray ());

			request.AddHeader ("Accept", "application/json");

			var response = ExecuteRequest (request);

			
			return response;
		}

		public IRestResponse Post (string resource, List<Parameter> param, object body)
		{
			bool containsAT = false;

			var request = new RestRequest (resource, Method.POST);
			List<string> names = new List<string> ();
			foreach (Parameter p in param) {
				names.Add (p.Name + "={" + p.Name + "}");
				if (p.Name.Equals ("access_token")) {
					containsAT = true;
				}
				p.Type = ParameterType.UrlSegment;
				request.AddParameter (p);
			}

			request.Resource = resource + "?" + String.Join ("&", names.ToArray ());

			request.AddHeader ("Accept", "application/json");
			request.AddHeader ("Content-Type", "application/json");
			request.RequestFormat = DataFormat.Json;

			request.AddParameter("application/json", body, ParameterType.RequestBody);

			var response = ExecuteRequest (request);

           

			return response;
		}

		public IRestResponse Put (string resource, List<Parameter> param, object body)
		{
			bool containsAT = false;

			var request = new RestRequest (resource, Method.PUT);
			List<string> names = new List<string> ();
			foreach (Parameter p in param) {
				names.Add (p.Name + "={" + p.Name + "}");
				if (p.Name.Equals ("access_token")) {
					containsAT = true;
				}
				p.Type = ParameterType.UrlSegment;
				request.AddParameter (p);
			}

			request.Resource = resource + "?" + String.Join ("&", names.ToArray ());

			request.AddHeader ("Accept", "application/json");
			request.AddHeader ("Content-Type", "application/json");
			request.RequestFormat = DataFormat.Json;

			request.AddParameter("application/json", body, ParameterType.RequestBody);

			var response = ExecuteRequest (request);

           

			return response;
		}

		public IRestResponse Delete (string resource, List<Parameter> param)
		{
			bool containsAT = false;

			var request = new RestRequest (resource, Method.DELETE);
			List<string> names = new List<string> ();
			foreach (Parameter p in param) {
				names.Add (p.Name + "={" + p.Name + "}");
				if (p.Name.Equals ("access_token")) {
					containsAT = true;
				}
				p.Type = ParameterType.UrlSegment;
				request.AddParameter (p);
			}

			request.Resource = resource + "?" + String.Join ("&", names.ToArray ());

			request.AddHeader ("Accept", "application/json");

			var response = ExecuteRequest (request);


			return response;
		}

		public IRestResponse ExecuteRequest(RestRequest request) {
			client.UserAgent = sdkVersion;
			return client.Execute(request);
		}
	}
}