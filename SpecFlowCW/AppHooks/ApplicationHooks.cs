using AventStack.ExtentReports;
using OpenQA.Selenium;
using SpecFlowCW.Drivers;
using SpecFlowCW.Utils;

namespace SpecFlowCW.AppHooks
{
    [Binding]
    public sealed class ApplicationHooks
    {
        private static ScenarioContext? _sContext;
        private static ExtentReports? _extentReports;
        private static ExtentTest? _feature;
        private static ExtentTest? _scenario;

        public ApplicationHooks(ScenarioContext sContext) => _sContext = sContext;

        [BeforeTestRun]
        public static void beforeTestRun()
        {
            ExtentReportGenerator eReport = new ExtentReportGenerator();
            _extentReports = eReport.extentReportLocator();
        }

        [BeforeFeature]
        public static void beforeFeatureStart(FeatureContext fContext)
        {
            ExtentReportGenerator eReport = new ExtentReportGenerator();
            _feature = eReport.setFeatureInfo(fContext, _extentReports);
        }

        [BeforeScenario]
        public void BeforeScenarioStart(ScenarioContext sContext)
        {
            //Console.WriteLine("asdasdasdasdasdasda   ----   "+sContext.StepContext.StepInfo.MultilineText.ToString());
            
            ExtentReportGenerator eReport = new ExtentReportGenerator();
            _scenario = eReport.setScenarioInfo(sContext, _feature);
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
            ExtentReportGenerator eReport = new ExtentReportGenerator();
            eReport.setScenarioBlock(_sContext, _scenario);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _sContext.Get<IWebDriver>("WebDriver").Quit();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReportGenerator eReport = new ExtentReportGenerator();
            eReport.generateExtentReport();
        }
    }
}