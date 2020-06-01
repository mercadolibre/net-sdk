# MeliLibTools.MeliLibApi.ItemsHealthApi

All URIs are relative to *https://api.mercadolibre.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ItemsIdHealthActionsGet**](ItemsHealthApi.md#itemsidhealthactionsget) | **GET** /items/{id}/health/actions | Return item health actions by id.
[**ItemsIdHealthGet**](ItemsHealthApi.md#itemsidhealthget) | **GET** /items/{id}/health | Return health by id.
[**SitesSiteIdHealthLevelsGet**](ItemsHealthApi.md#sitessiteidhealthlevelsget) | **GET** /sites/{site_id}/health_levels | Return health levels.


<a name="itemsidhealthactionsget"></a>
# **ItemsIdHealthActionsGet**
> void ItemsIdHealthActionsGet (string id, string accessToken)

Return item health actions by id.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using MeliLibTools.MeliLibApi;
using MeliLibTools.Client;
using MeliLibTools.Model;

namespace Example
{
    public class ItemsIdHealthActionsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.mercadolibre.com";
            var apiInstance = new ItemsHealthApi(config);
            var id = id_example;  // string | 
            var accessToken = accessToken_example;  // string | 

            try
            {
                // Return item health actions by id.
                apiInstance.ItemsIdHealthActionsGet(id, accessToken);
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
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 
 **accessToken** | **string**|  | 

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
> void ItemsIdHealthGet (string id, string accessToken)

Return health by id.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using MeliLibTools.MeliLibApi;
using MeliLibTools.Client;
using MeliLibTools.Model;

namespace Example
{
    public class ItemsIdHealthGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.mercadolibre.com";
            var apiInstance = new ItemsHealthApi(config);
            var id = id_example;  // string | 
            var accessToken = accessToken_example;  // string | 

            try
            {
                // Return health by id.
                apiInstance.ItemsIdHealthGet(id, accessToken);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ItemsHealthApi.ItemsIdHealthGet: " + e.Message );
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
 **accessToken** | **string**|  | 

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

Return health levels.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using MeliLibTools.MeliLibApi;
using MeliLibTools.Client;
using MeliLibTools.Model;

namespace Example
{
    public class SitesSiteIdHealthLevelsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.mercadolibre.com";
            var apiInstance = new ItemsHealthApi(config);
            var siteId = siteId_example;  // string | 

            try
            {
                // Return health levels.
                apiInstance.SitesSiteIdHealthLevelsGet(siteId);
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

