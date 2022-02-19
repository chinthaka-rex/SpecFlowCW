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

        XrayJsonCreator xJson = new XrayJsonCreator();

        public ApplicationHooks(ScenarioContext sContext) => _sContext = sContext;

        [BeforeTestRun]
        public static void beforeTestRun()
        {
            OsWisePathFix osWisePathFix = new OsWisePathFix();
            osWisePathFix.setGlobalSetting();

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
            ExtentReportGenerator eReport = new ExtentReportGenerator();
            _scenario = eReport.setScenarioInfo(sContext, _feature);
        }

        [BeforeScenario(Order = 1)]
        public void BeforeScenarioWithTag()
        {
            DriverFactory driver = new DriverFactory(_sContext);
            _sContext.Set(driver, "DriverFactory");
        }

        [AfterStep]
        public void AfterEachStep(FeatureContext _fContext)
        {
            ExtentReportGenerator eReport = new ExtentReportGenerator();
            eReport.setScenarioBlock(_sContext, _scenario);

            xJson.getStepResults(_sContext);
            xJson.jsonStepCreator();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            xJson.jsonCreator();
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