using System;
using System.Collections.Generic;
using System.Diagnostics;
using MeliLibTools.MeliLibApi;
using MeliLibTools.Client;
using MeliLibTools.Model;

namespace Example
{
    public class ItemsIdHealthGetExample
    {
        public static void Mainext()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.mercadolibre.com";
            var apiInstance = new ItemsHealthApi(config);
            var id = "id_example";  // string | 
            var accessToken = "accessToken_example";  // string | 

            try
            {
                // Return health by id.
                apiInstance.ItemsIdHealthGet(id, accessToken);
                // To see output in console
                // Console.Write("Resultado get:" + apiInstance.ItemsIdHealthGetWithHttpInfo(id, accessToken).Data);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ItemsHealthApi.SitesIdHealthGet: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}