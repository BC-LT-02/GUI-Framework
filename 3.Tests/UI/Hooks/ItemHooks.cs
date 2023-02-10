using System;
using System.Text.Json;
using RestSharp;
using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Views.Models;

namespace SeleniumTest.Tests.Hooks;

[Binding]
public class ItemHooks
{
    private readonly ScenarioContext _scenarioContext;
    private readonly RestHelper _client;
    private readonly string _url;
    private readonly int? _projectId;
    private readonly string _itemName;

    public ItemHooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _client = new RestHelper(ConfigModel.ApiHostUrl);
        _url = ConfigModel.ItemUri;
        _itemName = IdHelper.GetNewId();

        if (_scenarioContext.TryGetValue("projectContent", out var projectContentData))
        {
            ProjectModel projectContent = (ProjectModel)projectContentData;
            _projectId = projectContent.Id;
        }
    }

    [BeforeScenario("create.item", Order = 1)]
    public void CreateAnItem()
    {
        string payload = $"{{ \"Content\": \"{_itemName}\", \"ProjectId\": {_projectId} }}";
        _client.AddAuthenticator(ConfigModel.TODO_LY_EMAIL, ConfigModel.TODO_LY_PASS);

        RestResponse response = _client.DoRequest(Method.Post,_url, payload);
        if (!response.IsSuccessful)
        {
            throw new Exception("Error: Bad Request");
        }

        ItemPayload? itemContent = JsonSerializer.Deserialize<ItemPayload>(
            response.Content!
        );

        if (itemContent!.Content != _itemName)
        {
            throw new Exception("Error: Response field 'Content' does not match input payload");
        }

        _scenarioContext.Add(ConfigModel.CurrentItem, _itemName);
        _scenarioContext.Add("itemContent", itemContent);
    }
}
