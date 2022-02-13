using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowCW.StepDefinitions
{
    [Binding]
    public class LoginPageFeatureStepDefinitions
    {
        [Given(@"user is on login page")]
        public void GivenUserIsOnLoginPage()
        {
            IWebDriver driver = new ChromeDriver("C:/Users/PramodChinthaka/Documents/Visual Studio 2022/SpecFlowCW/SpecFlowCW/Support/");
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            

            driver.Close();
            
        }

        [When(@"user gets the title of the page")]
        public void WhenUserGetsTheTitleOfThePage()
        {
        }

        [Then(@"page title should be ""([^""]*)""")]
        public void ThenPageTitleShouldBe(string loginPageTitle)
        {
        }
    }
}
