using System.Collections.Generic;
using System.Text.Json;
using RestSharp;
using TechTalk.SpecFlow;
using Todoly.Tests.API.Steps.Commons;
using Todoly.Views.Models;

namespace Todoly.Tests.API.Steps.Item
{
    [Binding]
    [Scope(Feature = "Retrieve all items")]
    public class GetItemsStepDefinitions : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public GetItemsStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"the user submits a GET request to ""(.*)""")]
        public void WhentheusersubmitsaGETrequestto(string endpoint)
        {
            _scenarioContext["Response"] = Client.DoRequest(Method.Get, endpoint, null);
        }

        [Then(@"the API should return a ""(.*)"" response with the list of all the items")]
        public void ThentheAPIshouldreturnaresponsewiththelistofalltheitems(string response)
        {
            RestResponse res = (RestResponse)_scenarioContext["Response"];
            // System.Console.WriteLine(res.Content);
            Assert.True(res.IsSuccessful);
            Assert.Equal(response, res.StatusCode.ToString());
            var items = JsonSerializer.Deserialize<List<ItemModel>>(res.Content!);

            Assert.IsType<List<ItemModel>>(items);
            foreach (ItemModel item in items)
            {
                Assert.NotNull(item.Content);
                Assert.NotNull(item.Id);
            }
        }
    }
}
