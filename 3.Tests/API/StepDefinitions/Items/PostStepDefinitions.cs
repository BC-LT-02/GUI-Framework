using System.Text.Json;
using RestSharp;
using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Tests.API.Steps.Commons;
using Todoly.Views.Models;

namespace Todoly.Tests.API.Steps.Item
{
    [Binding]
    [Scope(Feature = "Create a new item")]
    public class PostStepDefinitions : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public PostStepDefinitions(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"the user submits a POST request to ""(.*)"" with a valid JSON body")]
        public void WhentheusersubmitsaPOSTrequesttowithavalidJSONbody(string endpoint, string body)
        {
            _scenarioContext["Response"] = Client.DoRequest(Method.Post, endpoint, body);
        }

        [Then(@"the API should return a ""(.*)"" response with the new item information")]
        public void ThentheAPIshouldreturnaresponsewiththenewiteminformation(string statusCode)
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];
            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());
            var item = JsonSerializer.Deserialize<ItemModel>(response.Content!);
            Assert.IsType<ItemModel>(item);
            Assert.Equal("New Item", item.Content);
        }

        [AfterScenario]
        public void DeleteItem()
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];
            var item = JsonSerializer.Deserialize<ItemModel>(response.Content!);
            string itemId = item!.Id.ToString()!;
            Client.AddAuthenticator(ConfigBuilder.Instance.GetString("TODO-LY-EMAIL"), ConfigBuilder.Instance.GetString("TODO-LY-PASS"));
            Client.DoRequest(Method.Delete, $"items/{itemId}.json", null);
        }
    }
}
