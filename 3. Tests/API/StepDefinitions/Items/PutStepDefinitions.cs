using System;
using System.Text.Json;
using Core;
using Features.GeneralSteps;
using Models;
using RestSharp;
using TechTalk.SpecFlow;

namespace Features.Items.Put
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
            ItemsPayloadModel body = new ItemsPayloadModel(
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
            _scenarioContext["Response"] = Client.Put<ItemsPayloadModel>(url, body);
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
