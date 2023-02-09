using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Todoly.Core.UIElements.Drivers;

namespace Todo_Automation.Hooks
{
    [Binding]
    public sealed class BaseHooks
    {
        private readonly ScenarioContext _scenarioContext;

        public BaseHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [BeforeScenario("createAnItem", Order = 1)]
        public void CreateAnItem()
        {
            // string payload = $"{{ \"Content\": \"1st item\", \"ProjectId\": 4069096}}";

        }

        [AfterScenario]
        public void AfterScenario()
        {
            GenericWebDriver.Dispose();
        }
    }
}
