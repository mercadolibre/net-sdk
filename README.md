# MercadoLibre's .NET SDK

This is the official .NET SDK for MercadoLibre's Platform.

## How do I install it?

You can download the latest build at: http://github.com/mercadolibre/net-sdk/downloads

And that's it!

## How do I start using it?

The first thing to do is to instanciate the `MeliApiService` class. At this point you can query any parts of the Mercado Libre API that do not require an _access token_.

You can obtain an access token after creating your own application. Read the [Getting Started](http://developers.mercadolibre.com/first-step/) guide for more information.

Once you have a _client id_ and _client secret_ for your application, instanciate `MeliCredentials` and assign it to the `MeliApiService.Credentials` property.


```csharp
var m = new MeliApiService 
        {
            Credentials = new MeliCredentials(MeliSite.Argentina, 1234, "a secret")
        };
```
With this instance you can start working on MercadoLibre's APIs.

There are some design considerations worth to mention:

1. This SDK is a thin layer on top of [HttpClient](https://msdn.microsoft.com/en-us/library/system.net.http.httpclient(v=vs.118).aspx) to handle the [OAuth](https://en.wikipedia.org/wiki/OAuth) WebServer flow for you.
2. [Json.NET](http://www.newtonsoft.com/json) is used to serialize and deserialising to and from JSON. It's up to you to call the relevant methods with classes that match the expected json format.
3. [http-params](https://github.com/bounav/http-params) library to generate URIs. The `HttpParams` class is a simple wrapper for `System.Collections.Specialized.NameValueCollection` with a fluent interface. Values are **URL encoded** _automatically_!

## How do I redirect users to authorize my application?

This is a 2-step process.

First get the link to redirect the user. This is very easy! Just:

```csharp
var redirectUrl = m.GetAuthUrl(1234, MeliSite.Argentina, "http://somecallbackurl");
```

This will give you the url to redirect the user. The callback url **must** match redirect URI that you specified for your mercado libre application.

Once the user is redirected to your callback url, you'll receive in the query string, a parameter named `code`. You'll need this for the second part of the process.

```csharp
m.AuthorizeAsync("the received code", "http://somecallbackurl");
```

This method will set the `AccessToken` and a `RefreshToken` property on the `MeliCredentials` instance. 

An access token authorizes your web application to act on behalf of a mercado libre user.

The `RefreshToken` is only set if your application has the `offline_access` scope enabled.

At this stage your are ready to make call to the API on behalf of the user.

## How do I refresh the access token?

Access tokens are only valid for 6 hours. As long as your app has the `offline_access` scope you will obtain a `refresh token` along with the `access token`. 

When the `refresh token` is set, `MeliApiService` will automatically renew the `access token` after the first `401` unauthorized answer it receives.

If you need to track access and refresh token changes (for example to store the tokens to use them later) you can subscribe to a `TokensChanged` event:

```csharp
var credentials = new MeliCredentials(MeliSite.Argentina, 123456, "secret");

credentials.TokensChanged += (sender, args) => { doSomethingWithNewTokenValues(args.Info); };

var success = await MercadoLibreApiService.AuthorizeAsync(credentials, code, callBackUrl);
```

## Making GET calls

```csharp
var p = new HttpParams().Add("access_token", m.Credentials.AccessToken)
                        .Add("another_param", "another value")
                        .Add("you can chain", "the method calls");

var response = await m.GetAsync("/users/me", p);

if (response.IsSuccessStatusCode)
{
    var json = await r.Content.ReadAsStringAsync();

    // You can then use Json.NET to deserialize the json
}
```

## Making POST calls

```csharp
var p = new HttpParams().Add("access_token", m.Credentials.AccessToken);

var r = await m.PostAsync("/items", p, new {foo="bar"});

if (response.IsSuccessStatusCode)
{
    var json = await r.Content.ReadAsStringAsync();

    // You can then use Json.NET to deserialize the json
}
```

## Making PUT calls

```csharp
var p = new HttpParams().Add("access_token", m.Credentials.AccessToken);

var r = await m.PutAsync("/items/123", p, new {foo="bar"});
```

## Making DELETE calls

```csharp
var p = new HttpParams().Add("access_token", m.Credentials.AccessToken);

var r = await m.DeleteAsync("/items/123", ps);
```

## Strongly typed calls

If you know what JSON you're expecting you can create your own classes decorated with the `System.Runtime.Serialization.DataContract` attribute.

```csharp
[DataContract]
public class Category
{
    [DataMember(Name = "id")]
    public string Id { get; set; }

    [DataMember(Name = "name")]
    public string Name { get; set; }
}

var categories = await m.GetAsync<Category[]>("/sites/MLB/categories");

```

## Deserializing with an anonymous type

If you just need a view values back Json.NET has a really cool deserialise method that you feed with an anonymous object.

```csharp
var json = @"{""refresh_token"":""refresh"",""access_token"":""access"",""user_id"":123456789}";

var token = JsonConvert.DeserializeAnonymousType (response.Content, new {refresh_token="", access_token = ""});

var refreshToken = token.refresh_token;
```

## Do I always need to include the ```access_token``` as a parameter?

No. Actually most `GET` requests don't need an `access_token` and it is easier to avoid them and also it is better in terms of caching.
But this decision is left to you. You should decide when it is necessary to include it or not.

## Community

You can contact us if you have questions using the standard communication channels described in the [developer's site](http://developers.mercadolibre.com/discuss)

## I want to contribute!

That is great! Just fork the project in github. Create a topic branch, write some code, and add some tests for your new code.

Thanks for helping!
