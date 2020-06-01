using System;
using System.Diagnostics;
using Org.OpenAPITools.MeliLibApi;
using Org.OpenAPITools.Client;

namespace Example
{
    public class ItemsIdGetExample
    {
        public static void Mainext(){
            Configuration config = new Configuration();
            config.BasePath = "https://api.mercadolibre.com";
            var apiInstance = new ItemsApi(config);
            var id = "id_example";  // string | 
            try
            {
                // Return a Item.
                apiInstance.ItemsIdGet(id);
                //Console.Write("Resultado get:" + apiInstance.ItemsIdGetWithHttpInfo(id).Data);
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
