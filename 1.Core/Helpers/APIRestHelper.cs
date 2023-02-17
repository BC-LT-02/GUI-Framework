using System.Text.Json;
using RestSharp;
using RestSharp.Authenticators;
using Todoly.Views.Models;

namespace Todoly.Core.Helpers;
public class RestHelper
{
    private readonly RestClient client;
    public RestHelper(string uri)
    {
        client = new RestClient(uri);
    }

    public void AddDefaultHeader(string key, string value)
    {
        client.AddDefaultHeader(key, value);
    }
    public void AddAuthenticator(string username, string password)
    {
        client.Authenticator = new HttpBasicAuthenticator(username, password);
    }

    public RestResponse DoRequest(Method method, string endpoint, string? body)
    {
        RestRequest request = new RestRequest(endpoint, method);
        if (body != null)
        {
            request.AddParameter("application/json", body, ParameterType.RequestBody);
        }

        try
        {
            return client.Execute(request);
        }
        catch (HttpRequestException e)
        {
            throw new HttpRequestException("Request failed with the following error: " + e.Message);
        }
    }
}
