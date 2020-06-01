using System;
using System.Collections.Generic;
using System.Diagnostics;
using MeliLibTools.MeliLibApi;
using MeliLibTools.Client;
using MeliLibTools.Model;

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
                // To see output in console
                // Console.Write("Resultado get:" + apiInstance.SitesSiteIdHealthLevelsGetWithHttpInfo(siteId).Data);
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