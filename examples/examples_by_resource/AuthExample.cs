using System;
using System.Diagnostics;
using MeliLibTools.MeliLibApi;
using MeliLibTools.Client;
using MeliLibTools.Model;

namespace Example
{
    class AuthExample
    {
        public static void Mainext(){
            Configuration config = new Configuration();
            config.BasePath = "https://auth.mercadolibre.com.ar";
            var apiInstance = new OAuth20Api(config);
            var responseType = "code"; 
            var clientId = "appId";  // string 
            var redirectUri = "urlRedirect";  // string 
            try
            {
                // Authentication Endpoint
                apiInstance.Auth(responseType, clientId, redirectUri);
                // To see output in console
                // var getCode = apiInstance.AuthWithHttpInfo(responseType, clientId, redirectUri);
                // Console.Write("Resultado get:" + getCode);
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
