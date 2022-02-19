using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace SpecFlowCW.Drivers
{
    public class DriverFactory
    {
        private IWebDriver driver;

        private readonly ScenarioContext _sContext;

        public DriverFactory(ScenarioContext sContext) => _sContext = sContext;

        [Obsolete]
        public IWebDriver setup()
        {
            ChromeOptions capability = new ChromeOptions();
            driver = new RemoteWebDriver(new Uri("https://" + Settings.Default.bsUsername + ":" + Settings.Default.bsAccessKey + "@hub.browserstack.com/wd/hub"), capability);

            _sContext.Set(driver, "WebDriver");
            return driver;
        }
    }
}
