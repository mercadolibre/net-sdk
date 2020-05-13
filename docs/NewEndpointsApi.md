# Org.OpenAPITools.Api.NewEndpointsApi

All URIs are relative to *https://api.mercadolibre.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ItemsIdCatalogForewarningDateGet**](NewEndpointsApi.md#itemsidcatalogforewarningdateget) | **GET** /items/{id}/catalog_forewarning/date | BuyBox moderation date
[**ItemsIdHealthActionGet**](NewEndpointsApi.md#itemsidhealthactionget) | **GET** /items/{id}/health/action | API Health Items
[**ItemsIdHealthGet**](NewEndpointsApi.md#itemsidhealthget) | **GET** /items/{id}/health | API Health Items
[**SitesSiteIdHealthLevelsGet**](NewEndpointsApi.md#sitessiteidhealthlevelsget) | **GET** /sites/{site_id}/health_levels | API Health Items


<a name="itemsidcatalogforewarningdateget"></a>
# **ItemsIdCatalogForewarningDateGet**
> void ItemsIdCatalogForewarningDateGet (string id, string version)

BuyBox moderation date

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ItemsIdCatalogForewarningDateGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.mercadolibre.com";
            var apiInstance = new NewEndpointsApi(config);
            var id = id_example;  // string | 
            var version = version_example;  // string | 

            try
            {
                // BuyBox moderation date
                apiInstance.ItemsIdCatalogForewarningDateGet(id, version);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling NewEndpointsApi.ItemsIdCatalogForewarningDateGet: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 
 **version** | **string**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="itemsidhealthactionget"></a>
# **ItemsIdHealthActionGet**
> void ItemsIdHealthActionGet (string id)

API Health Items

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ItemsIdHealthActionGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.mercadolibre.com";
            var apiInstance = new NewEndpointsApi(config);
            var id = id_example;  // string | 

            try
            {
                // API Health Items
                apiInstance.ItemsIdHealthActionGet(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling NewEndpointsApi.ItemsIdHealthActionGet: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="itemsidhealthget"></a>
# **ItemsIdHealthGet**
> void ItemsIdHealthGet (string id)

API Health Items

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ItemsIdHealthGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.mercadolibre.com";
            var apiInstance = new NewEndpointsApi(config);
            var id = id_example;  // string | 

            try
            {
                // API Health Items
                apiInstance.ItemsIdHealthGet(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling NewEndpointsApi.ItemsIdHealthGet: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="sitessiteidhealthlevelsget"></a>
# **SitesSiteIdHealthLevelsGet**
> void SitesSiteIdHealthLevelsGet (string siteId)

API Health Items

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class SitesSiteIdHealthLevelsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.mercadolibre.com";
            var apiInstance = new NewEndpointsApi(config);
            var siteId = siteId_example;  // string | 

            try
            {
                // API Health Items
                apiInstance.SitesSiteIdHealthLevelsGet(siteId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling NewEndpointsApi.SitesSiteIdHealthLevelsGet: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **siteId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

