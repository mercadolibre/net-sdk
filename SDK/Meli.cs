using System;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using MercadoLibre.SDK.Models;

namespace MercadoLibre.SDK
{
    public class Meli
    {

        private RestClient client = new RestClient(ApiUrl);
        static private string apiUrl = "https://api.mercadolibre.com";
        static private string sdkVersion = "MELI-NET-SDK-1.0.2";
        static public string ApiUrl
        {
            get
            {
                return apiUrl;
            }
            set
            {
                apiUrl = value;
            }
        }

        public static class AuthUrls
        {
            // MLA, MLB, MCO, MCR, MEC, MLC, MLM, MLU, MLV, MPA, MPE, MPT, MRD
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

        public Meli()
        {

        }
        public Meli(long clientId, string clientSecret)
        {
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
        }

        public Meli(long clientId, string clientSecret, string accessToken)
        {
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
            this.AccessToken = accessToken;
        }


        public Meli(long clientId, string clientSecret, string accessToken, string refreshToken)
        {
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
            this.AccessToken = accessToken;
            this.RefreshToken = refreshToken;
        }

        public string GetAuthUrl(string authUrl, string redirectUri)
        {

            return authUrl + "/authorization?response_type=code&client_id=" + ClientId + "&redirect_uri=" + HttpUtility.UrlEncode(redirectUri);
        }

        public void Authorize(string code, string redirectUri)
        {
            string URI = "/oauth/token?grant_type=authorization_code";
            URI += "&client_id=" + this.ClientId;
            URI += "&client_secret=" + this.ClientSecret;
            URI += "&code=" + code;
            URI += "&redirect_uri=" + redirectUri;
            var request = new RestRequest(URI, Method.POST);
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
                throw new AuthorizationException();
            }
        }


        public void refreshToken()
        {
            var request = new RestRequest("/oauth/token?grant_type=refresh_token&client_id={client_id}&client_secret={client_secret}&refresh_token={refresh_token}", Method.POST);
            request.AddParameter("client_id", this.ClientId, ParameterType.UrlSegment);
            request.AddParameter("client_secret", this.ClientSecret, ParameterType.UrlSegment);
            request.AddParameter("refresh_token", this.RefreshToken, ParameterType.UrlSegment);

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
                throw new AuthorizationException();
            }
        }


        public void refreshToken(string refresh_token)
        {

            string URI = "/oauth/token?grant_type=refresh_token";
            URI += "&client_id=" + this.ClientId;
            URI += "&client_secret=" + this.ClientSecret;
            URI += "&refresh_token=" + refresh_token;


            var request = new RestRequest(URI, Method.POST);
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
                throw new AuthorizationException();
            }
        }

        public string getThumbnailByItemID(string item_id, string access_token)
        {
            string URI = "/items?ids=" + item_id;
            URI += "&attributes=thumbnail";
            URI += "&access_token=" + access_token;
            var request = new RestRequest(URI, Method.GET);

            request.AddHeader("Accept", "application/json");

            var response = ExecuteRequest(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                var token = JsonConvert.DeserializeAnonymousType(response.Content, new[]
                { new
                    {
                        code = "",
                        body = new
                        {
                            thumbnail = ""
                        }

                    }
                });
                return token[0].body.thumbnail.ToString();
            }
            else
            {
                throw new AuthorizationException();
            }
        }

        public Order getOrder(string resource, string access_token)
        {
            string URI = resource;
            URI += "?access_token=" + access_token;

            var request = new RestRequest(URI, Method.GET);

            request.AddHeader("Accept", "application/json");

            var response = ExecuteRequest(request);
            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                var Order = JsonConvert.DeserializeAnonymousType(response.Content, new Order());
                return Order;
            }
            else
            {
                throw new AuthorizationException();
            }
        }

        public bool sendMessage(Order order, string message, string access_token)
        {
            try
            {
                string URI = "/messages/packs/";
                URI += order.PackId != null ? order.PackId : order.Id; ;
                URI += "/sellers/" + order.Seller.Id;
                URI += "?access_token=" + access_token;

                var request = new RestRequest(URI, Method.POST);
                var body = new
                {
                    from = new
                    {
                        user_id = order.Seller.Id,
                        email = order.Seller.Email,
                    },
                    to = new
                    {
                        user_id = order.Buyer.Id
                    },
                    text = message
                };

                request.AddBody(body);


                var response = ExecuteRequest(request);
                if (response.StatusCode.Equals(HttpStatusCode.Created))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (AuthorizationException e)
            {
                Console.WriteLine(e.Message);
                throw new AuthorizationException();
            }


        }

        public IRestResponse Get(string resource)
        {
            return Get(resource, new List<Parameter>());
        }
        public IRestResponse Get(string resource, List<Parameter> param)
        {
            bool containsAT = false;

            var request = new RestRequest(resource, Method.GET);
            List<string> names = new List<string>();
            foreach (Parameter p in param)
            {
                names.Add(p.Name + "={" + p.Name + "}");
                if (p.Name.Equals("access_token"))
                {
                    containsAT = true;
                }
                p.Type = ParameterType.UrlSegment;
                request.AddParameter(p);
            }

            request.Resource = resource + "?" + String.Join("&", names.ToArray());

            request.AddHeader("Accept", "application/json");

            var response = ExecuteRequest(request);


            return response;
        }

        public IRestResponse Post(string resource, List<Parameter> param, object body)
        {
            bool containsAT = false;

            var request = new RestRequest(resource, Method.POST);
            List<string> names = new List<string>();
            foreach (Parameter p in param)
            {
                names.Add(p.Name + "={" + p.Name + "}");
                if (p.Name.Equals("access_token"))
                {
                    containsAT = true;
                }
                p.Type = ParameterType.UrlSegment;
                request.AddParameter(p);
            }

            request.Resource = resource + "?" + String.Join("&", names.ToArray());

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;

            request.AddBody(body);

            var response = ExecuteRequest(request);



            return response;
        }

        public IRestResponse Put(string resource, List<Parameter> param, object body)
        {
            bool containsAT = false;

            var request = new RestRequest(resource, Method.PUT);
            List<string> names = new List<string>();
            foreach (Parameter p in param)
            {
                names.Add(p.Name + "={" + p.Name + "}");
                if (p.Name.Equals("access_token"))
                {
                    containsAT = true;
                }
                p.Type = ParameterType.UrlSegment;
                request.AddParameter(p);
            }

            request.Resource = resource + "?" + String.Join("&", names.ToArray());

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;

            request.AddBody(body);

            var response = ExecuteRequest(request);



            return response;
        }

        public IRestResponse Delete(string resource, List<Parameter> param)
        {
            bool containsAT = false;

            var request = new RestRequest(resource, Method.DELETE);
            List<string> names = new List<string>();
            foreach (Parameter p in param)
            {
                names.Add(p.Name + "={" + p.Name + "}");
                if (p.Name.Equals("access_token"))
                {
                    containsAT = true;
                }
                p.Type = ParameterType.UrlSegment;
                request.AddParameter(p);
            }

            request.Resource = resource + "?" + String.Join("&", names.ToArray());

            request.AddHeader("Accept", "application/json");

            var response = ExecuteRequest(request);


            return response;
        }

        public IRestResponse ExecuteRequest(RestRequest request)
        {
            client.UserAgent = sdkVersion;
            return client.Execute(request);
        }
    }
}