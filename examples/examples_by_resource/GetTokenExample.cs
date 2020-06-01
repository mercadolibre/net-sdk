using System;
using System.Diagnostics;
using MeliLibTools.MeliLibApi;
using MeliLibTools.Client;
using MeliLibTools.Model;

namespace Example
{
    class GetTokenExample
    {
        public static void Mainext(){
            Configuration config = new Configuration();
            config.BasePath = "https://api.mercadolibre.com";
            var apiInstance = new OAuth20Api(config);
            var grantType = "authorization_code"; 
            var clientId = "appId";  // string 
            var clientSecret = "appSecretKey";  // string 
            var redirectUri = "urlRedirect";  // string 
            var code = "code_example";
            try
            {
              // Request Access Token
               Token result = apiInstance.GetToken(grantType, clientId, clientSecret, redirectUri, code);
               Debug.WriteLine(result);
                // To see output in console
                // var console = apiInstance.GetTokenWithHttpInfo(grantType, clientId, clientSecret, redirectUri, code);
                // Console.Write("Resultado get:" + console.Data);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ItemsApi.ItemsIdGet: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
