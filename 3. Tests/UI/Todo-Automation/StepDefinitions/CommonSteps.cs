using SeleniumTest.Core.Drivers;
using SeleniumTest.Core.Interfaces;
using TechTalk.SpecFlow;

namespace SeleniumTest.Tests.Steps.Commons;

public class CommonSteps : IClassFixture<ChromeWebDriver>
{
    private readonly IGenericWebDriver _driver;
    private readonly ScenarioContext _scenarioContext;

    public CommonSteps(ScenarioContext scenarioContext, ChromeWebDriver driver)
    {
        _scenarioContext = scenarioContext;
        _driver = driver;
    }
}
