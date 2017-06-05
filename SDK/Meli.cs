using System;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace MercadoLibre.SDK
{
    public class Meli
    {

        private readonly RestClient _client = new RestClient(ApiUrl);
        private const string SdkVersion = "MELI-NET-SDK-1.0.2";

        public static string ApiUrl { get; set; } = "https://api.mercadolibre.com";

        public static class AuthUrls
        {
            public static string MLA => "https://auth.mercadolibre.com.ar"; //Argentina
            public static string MLB => "https://auth.mercadolivre.com.br"; // Brasil
            public static string MCO => "https://auth.mercadolibre.com.co"; // Colombia
            public static string MCR => "https://auth.mercadolibre.com.cr"; // Costa Rica
            public static string MEC => "https://auth.mercadolibre.com.ec"; // Ecuador
            public static string MLC => "https://auth.mercadolibre.cl"; // Chile
            public static string MLM => "https://auth.mercadolibre.com.mx"; // Mexico
            public static string MLU => "https://auth.mercadolibre.com.uy"; // Uruguay
            public static string MLV => "https://auth.mercadolibre.com.ve"; // Venezuela
            public static string MPA => "https://auth.mercadolibre.com.pa"; // Panama
            public static string MPE => "https://auth.mercadolibre.com.pe"; // Peru
            public static string MPT => "https://auth.mercadolibre.com.pt"; // Portugal
            public static string MRD => "https://auth.mercadolibre.com.do"; // Dominicana


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


        public Meli(long clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        public Meli(long clientId, string clientSecret, string accessToken)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            AccessToken = accessToken;
        }


        public Meli(long clientId, string clientSecret, string accessToken, string refreshToken)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        public string GetAuthUrl(string authUrl, string redirectUri)
        {

            return $"{authUrl}/authorization?response_type=code&client_id={ClientId}&redirect_uri={HttpUtility.UrlEncode(redirectUri)}";
        }

        public void Authorize(string code, string redirectUri)
        {
            var request = new RestRequest("/oauth/token?grant_type=authorization_code&client_id={client_id}&client_secret={client_secret}&code={code}&redirect_uri={redirect_uri}", Method.POST);

            request.AddParameter("client_id", ClientId, ParameterType.UrlSegment);
            request.AddParameter("client_secret", ClientSecret, ParameterType.UrlSegment);
            request.AddParameter("code", code, ParameterType.UrlSegment);
            request.AddParameter("redirect_uri", redirectUri, ParameterType.UrlSegment);

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

                AccessToken = token.access_token;
                RefreshToken = token.refresh_token;
                ExperiIn = Convert.ToInt64(token.expires_in);
                Scope = token.scope;
                UserId = token.user_id;
                TokenType = token.token_type;
            }
            else
            {
                throw new AuthorizationException();
            }
        }

        public IRestResponse Get(string resource)
        {
            return Get(resource, new List<Parameter>());
        }

        public void refreshToken()
        {
            var request = new RestRequest("/oauth/token?grant_type=refresh_token&client_id={client_id}&client_secret={client_secret}&refresh_token={refresh_token}", Method.POST);
            request.AddParameter("client_id", ClientId, ParameterType.UrlSegment);
            request.AddParameter("client_secret", ClientSecret, ParameterType.UrlSegment);
            request.AddParameter("refresh_token", RefreshToken, ParameterType.UrlSegment);

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

                AccessToken = token.access_token;
                RefreshToken = token.refresh_token;
                ExperiIn = Convert.ToInt64(token.expires_in);
                Scope = token.scope;
                UserId = token.user_id;
                TokenType = token.token_type;
            }
            else
            {
                throw new AuthorizationException();
            }
        }


        public void refreshToken(string refreshToken)
        {
            var request = new RestRequest("/oauth/token?grant_type=refresh_token&client_id={client_id}&client_secret={client_secret}&refresh_token={refresh_token}", Method.POST);
            request.AddParameter("client_id", ClientId, ParameterType.UrlSegment);
            request.AddParameter("client_secret", ClientSecret, ParameterType.UrlSegment);
            request.AddParameter("refresh_token", refreshToken, ParameterType.UrlSegment);

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

                AccessToken = token.access_token;
                RefreshToken = token.refresh_token;
                ExperiIn = Convert.ToInt64(token.expires_in);
                Scope = token.scope;
                UserId = token.user_id;
                TokenType = token.token_type;
            }
            else
            {
                throw new AuthorizationException();
            }
        }

        public IRestResponse Get(string resource, List<Parameter> param)
        {
            var containsAT = false;

            var request = new RestRequest(resource, Method.GET);
            var names = new List<string>();
            foreach (var p in param)
            {
                names.Add(p.Name + "={" + p.Name + "}");
                if (p.Name.Equals("access_token"))
                {
                    containsAT = true;
                }

                p.Type = ParameterType.UrlSegment;
                request.AddParameter(p);
            }

            request.Resource = $"{resource}?{string.Join("&", names.ToArray())}";
            request.AddHeader("Accept", "application/json");

            var response = ExecuteRequest(request);

            return response;
        }

        public IRestResponse Post(string resource, List<Parameter> param, object body)
        {
            var containsAT = false;

            var request = new RestRequest(resource, Method.POST);
            var names = new List<string>();
            foreach (var p in param)
            {
                names.Add(p.Name + "={" + p.Name + "}");
                if (p.Name.Equals("access_token"))
                {
                    containsAT = true;
                }

                p.Type = ParameterType.UrlSegment;
                request.AddParameter(p);
            }

            request.Resource = $"{resource}?{string.Join("&", names.ToArray())}";
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddBody(body);

            var response = ExecuteRequest(request);

            return response;
        }

        public IRestResponse Put(string resource, List<Parameter> param, object body)
        {
            var containsAT = false;

            var request = new RestRequest(resource, Method.PUT);
            var names = new List<string>();
            foreach (var p in param)
            {
                names.Add(p.Name + "={" + p.Name + "}");
                if (p.Name.Equals("access_token"))
                {
                    containsAT = true;
                }

                p.Type = ParameterType.UrlSegment;
                request.AddParameter(p);
            }

            request.Resource = $"{resource}?{string.Join("&", names.ToArray())}";
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddBody(body);

            var response = ExecuteRequest(request);

            return response;
        }

        public IRestResponse Delete(string resource, List<Parameter> param)
        {
            var containsAT = false;

            var request = new RestRequest(resource, Method.DELETE);
            var names = new List<string>();
            foreach (var p in param)
            {
                names.Add(p.Name + "={" + p.Name + "}");
                if (p.Name.Equals("access_token"))
                {
                    containsAT = true;
                }

                p.Type = ParameterType.UrlSegment;
                request.AddParameter(p);
            }

            request.Resource = $"{resource}?{string.Join("&", names.ToArray())}";
            request.AddHeader("Accept", "application/json");

            var response = ExecuteRequest(request);

            return response;
        }

        public IRestResponse ExecuteRequest(RestRequest request)
        {
            _client.UserAgent = SdkVersion;
            return _client.Execute(request);
        }
    }
}
