# MercadoLibre's .NET SDK

This is the official .NET SDK for MercadoLibre's Platform.

## How do I install it?

You can download the latest build at: 
    http://github.com/mercadolibre/net-sdk/downloads

And that's it!

## How do I start using it?

The first thing to do is to instance a ```Meli``` class. You'll need to give a ```clientId``` and a ```clientSecret```. You can obtain both after creating your own application. For more information on this please read: [creating an application](http://developers.mercadolibre.com/creating-your-own-application/)

```csharp
Meli m = new Meli(1234, "a secret");
```
With this instance you can start working on MercadoLibre's APIs.

There are some design considerations worth to mention.
1. This SDK is just a thin layer on top of an http client to handle all the OAuth WebServer flow for you.
2. There is no JSON parsing. This is left to you. But this SDK uses [json.net](http://www.json.net/) library for internal usage.

## How do I redirect users to authorize my application?

This is a 2 step process.

First get the link to redirect the user. This is very easy! Just:

```csharp
string redirectUrl = m.GetAuthUrl("http://somecallbackurl");
```

This will give you the url to redirect the user. You need to specify a callback url which will be the one that the user will redirected after a successfull authrization process.

Once the user is redirected to your callback url, you'll receive in the query string, a parameter named ```code```. You'll need this for the second part of the process.

```csharp
m.Authorize("the received code", "http://somecallbackurl");
```

This will get an ```accessToken``` and a ```refreshToken``` (is case your application has the ```offline_access```) for your application and your user.

At this stage your are ready to make call to the API on behalf of the user.

## Making GET calls

```csharp
var p = new Parameter ();
p.Name = "access_token";
p.Value = m.AccessToken;

var ps = new List<Parameter> ();
ps.Add (p);
IRestResponse response = m.Get ("/users/me", ps);
```

## Making POST calls

```csharp
var p = new Parameter ();
p.Name = "access_token";
p.Value = m.AccessToken;

var ps = new List<Parameter> ();
ps.Add (p);
IRestResponse r = m.Post ("/items", ps, new {foo="bar"});
```
## Making PUT calls

```csharp
var p = new Parameter ();
p.Name = "access_token";
p.Value = m.AccessToken;

var ps = new List<Parameter> ();
ps.Add (p);
IRestResponse r = m.Put ("/items/123", ps, new {foo="bar"});
```
## Making DELETE calls

```csharp
var p = new Parameter ();
p.Name = "access_token";
p.Value = m.AccessToken;

var ps = new List<Parameter> ();
ps.Add (p);
IRestResponse r = m.Delete ("/items/123", ps);
```

## Do I always need to include the ```access_token``` as a parameter?
No. Actually most ```GET``` requests don't need an ```access_token``` and it is easier to avoid them and also it is better in terms of caching.
But this decision is left to you. You should decide when it is necessary to include it or not.

## Community

You can contact us if you have questions using the standard communication channels described in the [developer's site](http://developers.mercadolibre.com/discuss)

## I want to contribute!

That is great! Just fork the project in github. Create a topic branch, write some code, and add some tests for your new code.

To run the tests run ```make test```.

You'll need [nodejs](http://www.nodejs.org) in order to run the tests. We use it to mock the API.

Thanks for helping!
