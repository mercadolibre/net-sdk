# MeliLibTools.MeliLibApi.CategoriesApi

All URIs are relative to *https://api.mercadolibre.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CategoriesCategoryIdGet**](CategoriesApi.md#categoriescategoryidget) | **GET** /categories/{category_id} | Return by category.
[**SitesSiteIdCategoriesGet**](CategoriesApi.md#sitessiteidcategoriesget) | **GET** /sites/{site_id}/categories | Return a categories by site.
[**SitesSiteIdDomainDiscoverySearchGet**](CategoriesApi.md#sitessiteiddomaindiscoverysearchget) | **GET** /sites/{site_id}/domain_discovery/search | Predictor


<a name="categoriescategoryidget"></a>
# **CategoriesCategoryIdGet**
> void CategoriesCategoryIdGet (string categoryId)

Return by category.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using MeliLibTools.MeliLibApi;
using MeliLibTools.Client;
using MeliLibTools.Model;

namespace Example
{
    public class CategoriesCategoryIdGetExample
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
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CategoriesApi.CategoriesCategoryIdGet: " + e.Message );
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
 **categoryId** | **string**|  | 

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

<a name="sitessiteidcategoriesget"></a>
# **SitesSiteIdCategoriesGet**
> void SitesSiteIdCategoriesGet (string siteId)

Return a categories by site.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using MeliLibTools.MeliLibApi;
using MeliLibTools.Client;
using MeliLibTools.Model;

namespace Example
{
    public class SitesSiteIdCategoriesGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.mercadolibre.com";
            var apiInstance = new CategoriesApi(config);
            var siteId = siteId_example;  // string | 

            try
            {
                // Return a categories by site.
                apiInstance.SitesSiteIdCategoriesGet(siteId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CategoriesApi.SitesSiteIdCategoriesGet: " + e.Message );
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

<a name="sitessiteiddomaindiscoverysearchget"></a>
# **SitesSiteIdDomainDiscoverySearchGet**
> void SitesSiteIdDomainDiscoverySearchGet (string siteId, string q, string limit)

Predictor

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using MeliLibTools.MeliLibApi;
using MeliLibTools.Client;
using MeliLibTools.Model;

namespace Example
{
    public class SitesSiteIdDomainDiscoverySearchGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.mercadolibre.com";
            var apiInstance = new CategoriesApi(config);
            var siteId = siteId_example;  // string | 
            var q = q_example;  // string | 
            var limit = limit_example;  // string | 

            try
            {
                // Predictor
                apiInstance.SitesSiteIdDomainDiscoverySearchGet(siteId, q, limit);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CategoriesApi.SitesSiteIdDomainDiscoverySearchGet: " + e.Message );
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
 **q** | **string**|  | 
 **limit** | **string**|  | 

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

