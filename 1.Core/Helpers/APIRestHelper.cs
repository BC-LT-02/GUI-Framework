using System.Text.Json;
using RestSharp;
using RestSharp.Authenticators;

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
    public RestResponse Get(string url)
    {
        RestRequest request = new RestRequest(url, Method.Get);
        RestResponse res = client.Execute(request);
        return res!;
    }

    public RestResponse Post<T>(string url, T body)
    {
        RestRequest request = new RestRequest(url, Method.Post);

        string bodyString = JsonSerializer.Serialize<T>(body);
        request.AddParameter("application/json", bodyString, ParameterType.RequestBody);

        RestResponse res = client.Execute(request);
        return res;
    }

    public RestResponse Delete(string url)
    {
        RestRequest request = new RestRequest(url, Method.Delete);
        RestResponse res = client.Execute(request);
        return res!;
    }

    public RestResponse Put<T>(string url, T body)
    {
        RestRequest request = new RestRequest(url, Method.Put);

        string bodyString = JsonSerializer.Serialize<T>(body);
        request.AddParameter("application/json", bodyString, ParameterType.RequestBody);

        RestResponse res = client.Execute(request);
        return res;
    }

    public void Authenticate(string username, string password)
    {
        client.Authenticator = new HttpBasicAuthenticator(username, password);
    }
}
