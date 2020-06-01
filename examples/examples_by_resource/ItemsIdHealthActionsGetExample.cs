using System;
using System.Collections.Generic;
using System.Diagnostics;
using MeliLibTools.MeliLibApi;
using MeliLibTools.Client;
using MeliLibTools.Model;

namespace Example
{
    public class ItemsIdHealthActionsGetExample
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
                // Return item health actions by id.
                apiInstance.ItemsIdHealthActionsGet(id, accessToken);
                // To see output in console
                // Console.Write("Resultado get:" + apiInstance.ItemsIdHealthActionsGetWithHttpInfo(id, accessToken).Data);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ItemsHealthApi.ItemsIdHealthActionsGet: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}