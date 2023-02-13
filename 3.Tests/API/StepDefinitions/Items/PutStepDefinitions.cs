using RestSharp;
using TechTalk.SpecFlow;
using Todoly.Tests.API.Steps.Commons;
using Todoly.Views.Models;

namespace Todoly.Tests.API.Steps.Item
{
    [Binding]
    [Scope(Feature = "Update an existing item to be done")]
    public class PutStepDefinitions : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly string url = "items/11099581.json";

        public PutStepDefinitions(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(
            @"the user makes a PUT request to the API endpoint with a valid JSON or XML payload and ID project"
        )]
        public void WhentheusermakesaPUTrequesttotheAPIendpointwithavalidJSONorXMLpayloadandIDproject()
        {
            ItemsPayload body = new ItemsPayload(
                null,
                null,
                null,
                true,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null
            );
            _scenarioContext["Response"] = Client.Put<ItemsPayload>(url, body);
        }

        [Then(@"the API should return an (.*) status code and the item should be updated")]
        public void ThentheAPIshouldreturnanstatuscodeandtheitemshouldbeupdated(string statusCode)
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];
            Assert.True(response.IsSuccessful);
            Assert.Equal(statusCode, response.StatusCode.ToString());
        }
    }
}
