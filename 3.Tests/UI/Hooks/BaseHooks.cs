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

        [AfterScenario]
        public void AfterScenario()
        {
            GenericWebDriver.Dispose();
        }
    }
}
