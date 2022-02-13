using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowCW.Drivers;

namespace SpecFlowCW.StepDefinitions
{
    [Binding]
    public class LoginPageFeatureStepDefinitions
    {
        IWebDriver driver;
        private readonly ScenarioContext _sContext;
        String _title;

        public LoginPageFeatureStepDefinitions(ScenarioContext sContext)
        {
            _sContext = sContext;
        }

        [Given(@"user is on login page")]
        public void GivenUserIsOnLoginPage()
        {
            driver = _sContext.Get<DriverFactory>("DriverFactory").setup();
            driver.Url = "https://www.saucedemo.com/";
            Console.WriteLine(driver.Title);
        }

        [When(@"user gets the title of the page")]
        public void WhenUserGetsTheTitleOfThePage()
        {
            _title = driver.Title;
        }

        [Then(@"page title should be ""([^""]*)""")]
        public void ThenPageTitleShouldBe(string loginPageTitle)
        {
            StringAssert.Contains(loginPageTitle, _title);
        }
    }
}
