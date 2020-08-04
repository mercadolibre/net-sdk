# MeliLibTools.MeliLibApi.RestClientApi

All URIs are relative to *https://api.mercadolibre.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ResourceGet**](RestClientApi.md#resourceget) | **GET** /{resource} | Resource path GET
[**ResourcePost**](RestClientApi.md#resourcepost) | **POST** /{resource} | Resourse path POST
[**ResourcePut**](RestClientApi.md#resourceput) | **PUT** /{resource} | Resourse path PUT


<a name="resourceget"></a>
# **ResourceGet**
> void ResourceGet (string resource, string accessToken)

Resource path GET

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using MeliLibTools.MeliLibApi;
using MeliLibTools.Client;
using MeliLibTools.Model;

namespace Example
{
    public class ResourceGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.mercadolibre.com";
            var apiInstance = new RestClientApi(config);
            var resource = resource_example;  // string | 
            var accessToken = accessToken_example;  // string | 

            try
            {
                // Resource path GET
                apiInstance.ResourceGet(resource, accessToken);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RestClientApi.ResourceGet: " + e.Message );
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
 **resource** | **string**|  | 
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

<a name="resourcepost"></a>
# **ResourcePost**
> void ResourcePost (string resource, string accessToken, Object body)

Resourse path POST

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using MeliLibTools.MeliLibApi;
using MeliLibTools.Client;
using MeliLibTools.Model;

namespace Example
{
    public class ResourcePostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.mercadolibre.com";
            var apiInstance = new RestClientApi(config);
            var resource = resource_example;  // string | 
            var accessToken = accessToken_example;  // string | 
            var body = ;  // Object | 

            try
            {
                // Resourse path POST
                apiInstance.ResourcePost(resource, accessToken, body);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RestClientApi.ResourcePost: " + e.Message );
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
 **resource** | **string**|  | 
 **accessToken** | **string**|  | 
 **body** | **Object**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="resourceput"></a>
# **ResourcePut**
> void ResourcePut (string resource, string accessToken, Object body)

Resourse path PUT

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using MeliLibTools.MeliLibApi;
using MeliLibTools.Client;
using MeliLibTools.Model;

namespace Example
{
    public class ResourcePutExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.mercadolibre.com";
            var apiInstance = new RestClientApi(config);
            var resource = resource_example;  // string | 
            var accessToken = accessToken_example;  // string | 
            var body = ;  // Object | 

            try
            {
                // Resourse path PUT
                apiInstance.ResourcePut(resource, accessToken, body);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RestClientApi.ResourcePut: " + e.Message );
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
 **resource** | **string**|  | 
 **accessToken** | **string**|  | 
 **body** | **Object**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

