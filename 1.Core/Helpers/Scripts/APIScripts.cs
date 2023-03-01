using System.Text.Json;
using RestSharp;
using Todoly.Views.Models;

namespace Todoly.Core.Helpers;

public class APIScripts
{
    public static void RemoveAllProjects()
    {
        RestHelper client = new RestHelper(ConfigModel.ApiHostUrl);
        client.AddAuthenticator(ConfigModel.TODO_LY_EMAIL, ConfigModel.TODO_LY_PASS);
        RestResponse response = client.DoRequest(Method.Get, ConfigModel.ProjectUri, null);
        var projects = JsonSerializer.Deserialize<IEnumerable<ProjectModel>>(response.Content!);

        foreach (var x in projects!)
        {
            string url = $"projects/{x.Id}.json";
            RestResponse res = client.DoRequest(Method.Delete, url, null);
            if (!res.IsSuccessful)
            {
                throw new Exception("A problem occurred deleting the projects");
            }
        }
    }

    public static string[] RetrieveProjectNames()
    {
        RestHelper client = new RestHelper(ConfigModel.ApiHostUrl);
        client.AddAuthenticator(ConfigModel.TODO_LY_EMAIL, ConfigModel.TODO_LY_PASS);
        RestResponse response = client.DoRequest(Method.Get, ConfigModel.ProjectUri, null);
        ProjectModel[] projectNames = JsonSerializer.Deserialize<ProjectModel[]>(response.Content!)!;

        return projectNames.Select(each => each.Content).ToArray()!;
    }
}
