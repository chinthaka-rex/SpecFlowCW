using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using SpecFlowCW.Drivers;

namespace SpecFlowCW.AppHooks
{
    [Binding]
    public sealed class ApplicationHooks
    {
        private static ScenarioContext _sContext;
        private static ExtentReports _extentReports;
        private static ExtentHtmlReporter _extentHtmlReporter;
        private static ExtentTest _feature;
        private static ExtentTest _scenario;

        public ApplicationHooks(ScenarioContext sContext) => _sContext = sContext;

        [BeforeTestRun]
        public static void beforeTestRun()
        {
            _extentHtmlReporter = new ExtentHtmlReporter(@"C:\Users\PramodChinthaka\Documents\Visual Studio 2022\SpecFlowCW\SpecFlowCW\Reports\TestResults.html");
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(_extentHtmlReporter);
        }

        [BeforeFeature]
        public static void beforeFeatureStart(FeatureContext fContext)
        {
            if (fContext != null)
            {
                _feature = _extentReports.CreateTest<Feature>(fContext.FeatureInfo.Title, fContext.FeatureInfo.Description);
            }
        }

        [BeforeScenario]
        public void BeforeScenarioStart(ScenarioContext sContext)
        {
            if (sContext != null)
            {
                _scenario = _feature.CreateNode<Scenario>(sContext.ScenarioInfo.Title, sContext.ScenarioInfo.Description);
            }
        }

        [BeforeScenario(Order = 1)]
        public void BeforeScenarioWithTag()
        {
            DriverFactory driver = new DriverFactory(_sContext);
            _sContext.Set(driver, "DriverFactory");
        }

        [BeforeScenario(Order = 2)]
        public void FirstBeforeScenario()
        {

        }

        [AfterStep]
        public void AfterEachStep()
        {
            ScenarioBlock scenarioBlock = _sContext.CurrentScenarioBlock;

            switch (scenarioBlock)
            {
                case ScenarioBlock.Given:
                    if(_sContext.TestError != null)
                    {
                        _scenario.CreateNode<Given>(_sContext.TestError.Message).Fail("\n"+ _sContext.TestError.StackTrace);
                    }
                    else
                    {
                        _scenario.CreateNode<Given>(_sContext.StepContext.StepInfo.Text);
                    }
                    break;
                case ScenarioBlock.When:
                    if (_sContext.TestError != null)
                    {
                        _scenario.CreateNode<When>(_sContext.TestError.Message).Fail("\n" + _sContext.TestError.StackTrace);
                    }
                    else
                    {
                        _scenario.CreateNode<When>(_sContext.StepContext.StepInfo.Text);
                    }
                    break;
                case ScenarioBlock.Then:
                    if (_sContext.TestError != null)
                    {
                        _scenario.CreateNode<Then>(_sContext.TestError.Message).Fail("\n" + _sContext.TestError.StackTrace);
                    }
                    else
                    {
                        _scenario.CreateNode<Then>(_sContext.StepContext.StepInfo.Text);
                    }
                    break;
                default:
                    if (_sContext.TestError != null)
                    {
                        _scenario.CreateNode<And>(_sContext.TestError.Message).Fail("\n" + _sContext.TestError.StackTrace);
                    }
                    else
                    {
                        _scenario.CreateNode<And>(_sContext.StepContext.StepInfo.Text);
                    }
                    break;
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _sContext.Get<IWebDriver>("WebDriver").Quit();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _extentReports.Flush();
        }
    }
}