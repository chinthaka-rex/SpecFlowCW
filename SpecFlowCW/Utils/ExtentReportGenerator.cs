using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;

namespace SpecFlowCW.Utils
{
    internal class ExtentReportGenerator
    {
        private static ExtentReports? _extentReports;
        private static ExtentHtmlReporter? _extentHtmlReporter;
        private static ExtentTest? _feature;
        private static ExtentTest? _scenario;

        public ExtentReports extentReportLocator()
        {
            _extentHtmlReporter = new ExtentHtmlReporter(@"C:\Users\PramodChinthaka\Documents\Visual Studio 2022\SpecFlowCW\SpecFlowCW\Reports\TestResults.html");
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(_extentHtmlReporter);
            return _extentReports;
        }

        public ExtentTest setFeatureInfo(FeatureContext fContext, ExtentReports _extReports)
        {
            if (fContext != null)
            {
                _feature = _extReports.CreateTest<Feature>(fContext.FeatureInfo.Title, fContext.FeatureInfo.Description);
            }
            return _feature;
        }

        public ExtentTest setScenarioInfo(ScenarioContext sContext, ExtentTest _extFeature)
        {
            if (sContext != null)
            {
                _scenario = _extFeature.CreateNode<Scenario>(sContext.ScenarioInfo.Title, sContext.ScenarioInfo.Description);
            }
            return _scenario;
        }

        public ExtentTest setScenarioBlock(ScenarioContext scContext, ExtentTest _scenario)
        {
            ScenarioBlock scenarioBlock = scContext.CurrentScenarioBlock;

            switch (scenarioBlock)
            {
                case ScenarioBlock.Given:
                    if (scContext.TestError != null)
                    {
                        _scenario.CreateNode<Given>(scContext.TestError.Message).Fail("\n" + scContext.TestError.StackTrace);
                    }
                    else
                    {
                        _scenario.CreateNode<Given>(scContext.StepContext.StepInfo.Text);
                    }
                    break;
                case ScenarioBlock.When:
                    if (scContext.TestError != null)
                    {
                        _scenario.CreateNode<When>(scContext.TestError.Message).Fail("\n" + scContext.TestError.StackTrace);
                    }
                    else
                    {
                        _scenario.CreateNode<When>(scContext.StepContext.StepInfo.Text);
                    }
                    break;
                case ScenarioBlock.Then:
                    if (scContext.TestError != null)
                    {
                        _scenario.CreateNode<Then>(scContext.TestError.Message).Fail("\n" + scContext.TestError.StackTrace);
                    }
                    else
                    {
                        _scenario.CreateNode<Then>(scContext.StepContext.StepInfo.Text);
                    }
                    break;
                default:
                    if (scContext.TestError != null)
                    {
                        _scenario.CreateNode<And>(scContext.TestError.Message).Fail("\n" + scContext.TestError.StackTrace);
                    }
                    else
                    {
                        _scenario.CreateNode<And>(scContext.StepContext.StepInfo.Text);
                    }
                    break;
            }
            return _scenario;
        }

        public void generateExtentReport()
        {
            _extentReports.Flush();
        }
    }
}
