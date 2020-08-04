# MeliLibTools.MeliLibApi.OAuth20Api

All URIs are relative to *https://api.mercadolibre.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**Auth**](OAuth20Api.md#auth) | **GET** /authorization | Authentication Endpoint
[**GetToken**](OAuth20Api.md#gettoken) | **POST** /oauth/token | Request Access Token


<a name="auth"></a>
# **Auth**
> void Auth (string responseType, string clientId, string redirectUri)

Authentication Endpoint

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using MeliLibTools.MeliLibApi;
using MeliLibTools.Client;
using MeliLibTools.Model;

namespace Example
{
    public class AuthExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.mercadolibre.com";
            var apiInstance = new OAuth20Api(config);
            var responseType = responseType_example;  // string |  (default to code)
            var clientId = clientId_example;  // string | 
            var redirectUri = redirectUri_example;  // string | 

            try
            {
                // Authentication Endpoint
                apiInstance.Auth(responseType, clientId, redirectUri);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OAuth20Api.Auth: " + e.Message );
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
 **responseType** | **string**|  | [default to code]
 **clientId** | **string**|  | 
 **redirectUri** | **string**|  | 

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
| **302** | Redirect to OAuth provider |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="gettoken"></a>
# **GetToken**
> void GetToken (string grantType = null, string clientId = null, string clientSecret = null, string redirectUri = null, string code = null, string refreshToken = null)

Request Access Token

Partner makes a request to the token endpoint by adding the following parameters described below

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using MeliLibTools.MeliLibApi;
using MeliLibTools.Client;
using MeliLibTools.Model;

namespace Example
{
    public class GetTokenExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.mercadolibre.com";
            var apiInstance = new OAuth20Api(config);
            var grantType = grantType_example;  // string |  (optional) 
            var clientId = clientId_example;  // string |  (optional) 
            var clientSecret = clientSecret_example;  // string |  (optional) 
            var redirectUri = redirectUri_example;  // string |  (optional) 
            var code = code_example;  // string |  (optional) 
            var refreshToken = refreshToken_example;  // string |  (optional) 

            try
            {
                // Request Access Token
                apiInstance.GetToken(grantType, clientId, clientSecret, redirectUri, code, refreshToken);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OAuth20Api.GetToken: " + e.Message );
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
 **grantType** | **string**|  | [optional] 
 **clientId** | **string**|  | [optional] 
 **clientSecret** | **string**|  | [optional] 
 **redirectUri** | **string**|  | [optional] 
 **code** | **string**|  | [optional] 
 **refreshToken** | **string**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/x-www-form-urlencoded
 - **Accept**: Not defined

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

