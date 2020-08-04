<h1 align="center">
  <a href="http://developers.mercadolibre.com/es/">
    <img src="https://user-images.githubusercontent.com/1153516/29861072-689ec57e-8d3e-11e7-8368-dd923543258f.jpg" alt="Mercado Libre Developers" width="230"></a>
  </a>
  <br>
  MercadoLibre's .Net SDK
  <br>
</h1>

<h4 align="center">This is the official .Net SDK for MercadoLibre's Platform.<span>[Beta]</span></h4>

<a name="frameworks-supported"></a>
## Frameworks supported
- .NET Core >=1.0
- .NET Framework >=4.6
- Mono/Xamarin >=vNext

<a name="dependencies"></a>
## Dependencies

- [RestSharp](https://www.nuget.org/packages/RestSharp) - 106.10.1 or later
- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 12.0.1 or later
- [JsonSubTypes](https://www.nuget.org/packages/JsonSubTypes/) - 1.5.2 or later
- [System.ComponentModel.Annotations](https://www.nuget.org/packages/System.ComponentModel.Annotations) - 4.5.0 or later

The DLLs included in the package may not be the latest version. We recommend using [NuGet](https://docs.nuget.org/consume/installing-nuget) to obtain the latest version of the packages:
```
Install-Package RestSharp
Install-Package Newtonsoft.Json
Install-Package JsonSubTypes
Install-Package System.ComponentModel.Annotations
```

NOTE: RestSharp versions greater than 105.1.0 have a bug which causes file uploads to fail. See [RestSharp#742](https://github.com/restsharp/RestSharp/issues/742)

<a name="installation"></a>
## Installation
Generate the DLL using your preferred tool (e.g. `dotnet build`)

Then include the DLL (under the `bin` folder) in the C# project, and use the namespaces:
```csharp
using MeliLibTools.MeliLibApi;
using MeliLibTools.Client;
using MeliLibTools.Model;
```
<a name="getting-started"></a>
## Getting Started

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using MeliLibTools.MeliLibApi;
using MeliLibTools.Client;
using MeliLibTools.Model;

namespace Example
{
    public class Example
    {
        public static void Main()
        {

            Configuration config = new Configuration();
            config.BasePath = "https://api.mercadolibre.com";
            var apiInstance = new CategoriesApi(config);
            var categoryId = categoryId_example;  // string | 

            try
            {
                // Return by category.
                apiInstance.CategoriesCategoryIdGet(categoryId);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling CategoriesApi.CategoriesCategoryIdGet: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }

        }
    }
}
```

## Documentation & Important notes

##### The URIs are relative to https://api.mercadolibre.com

##### The Authorization URL: https://auth.mercadolibre.com.ar/authorization

#####  All docs for the library are located [here](https://github.com/mercadolibre/ruby-sdk/tree/master/docs)

#####  Check out our examples codes in the folder [examples](https://github.com/mercadolibre/ruby-sdk/tree/master/examples)

##### Don’t forget to check out our [developer site](https://developers.mercadolibre.com/)

