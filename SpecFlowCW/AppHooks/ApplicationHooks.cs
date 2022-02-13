using OpenQA.Selenium;
using SpecFlowCW.Drivers;

namespace SpecFlowCW.AppHooks
{
    [Binding]
    public sealed class ApplicationHooks
    {
        private readonly ScenarioContext _sContext;

        public ApplicationHooks(ScenarioContext sContext)
        {
            _sContext = sContext;
        }

        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            DriverFactory driver = new DriverFactory(_sContext);
            _sContext.Set(driver,"DriverFactory");

        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {

        }

        [AfterScenario]
        public void AfterScenario()
        {
            _sContext.Get<IWebDriver>("WebDriver").Quit();
        }
    }
}