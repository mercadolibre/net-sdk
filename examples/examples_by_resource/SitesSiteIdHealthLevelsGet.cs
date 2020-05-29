using System;
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.MeliLibApi;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class SitesSiteIdHealthLevelsGetExample
    {
        public static void Mainext()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.mercadolibre.com";
            var apiInstance = new ItemsHealthApi(config);
            var siteId = "siteId_example";  // string | 

            try
            {
                // Return health levels.
                apiInstance.SitesSiteIdHealthLevelsGet(siteId);
                // Console.Write("Resultado get:" + apiInstance.SitesSiteIdHealthLevelsGetWithHttpInfo("MLA").Data);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ItemsHealthApi.SitesSiteIdHealthLevelsGet: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}