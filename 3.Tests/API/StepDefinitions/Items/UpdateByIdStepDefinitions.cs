using System.Text.Json;
using RestSharp;
using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Tests.API.Steps.Commons;
using Todoly.Views.Models;

namespace Todoly.Tests.API.Steps.Item
{
    [Binding]
    [Scope(Feature = "Update an existing item by ID")]
    public class UpdateByIdStepDefintions : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public UpdateByIdStepDefintions(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"the user submits a PUT request to ""(.*)"" with a valid JSON body")]
        public void WhentheusersubmitsaPUTrequesttowithavalidJSONbody(string endpoint, string body)
        {
            var newItem = _scenarioContext.Get<RestResponse>(ConfigBuilder.Instance.GetString("api", "CurrentItem"));
            string projectId = JsonSerializer.Deserialize<ItemModel>(newItem!.Content!)!.Id.ToString()!;
            endpoint = endpoint.Replace("[id]", projectId);
            _scenarioContext["Response"] = Client.DoRequest(Method.Put, endpoint, body);
        }

        [Then(@"the API should return a ""(.*)"" response with the updated item information")]
        public void ThentheAPIshouldreturnaresponsewiththeupdatediteminformation(string statusCode)
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];
            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());
            var item = JsonSerializer.Deserialize<ItemModel>(response.Content!);
            Assert.IsType<ItemModel>(item);
            Assert.True(item.Checked);
        }
    }
}
