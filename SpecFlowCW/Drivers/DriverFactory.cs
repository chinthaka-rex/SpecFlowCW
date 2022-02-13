using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace SpecFlowCW.Drivers
{
    public class DriverFactory
    {
        private IWebDriver driver;

        private readonly ScenarioContext _sContext;

        public DriverFactory(ScenarioContext sContext)
        {
            _sContext = sContext;
        }

        [Obsolete]
        public IWebDriver setup()
        {
            ChromeOptions capability = new ChromeOptions();
            capability.AddAdditionalCapability("os", "Windows", true);
            capability.AddAdditionalCapability("os_version", "10", true);
            capability.AddAdditionalCapability("browser", "Chrome", true);
            capability.AddAdditionalCapability("browser_version", "latest", true);
            driver = new RemoteWebDriver(new Uri("https://chinthakawithana_60fUmL:ps4PxvE4iqF59XRguDsx@hub.browserstack.com/wd/hub"),capability);

            _sContext.Set(driver,"WebDriver");
            return driver;
        }
    }
}
