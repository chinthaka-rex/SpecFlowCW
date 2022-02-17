using Newtonsoft.Json;

namespace SpecFlowCW.Utils
{
    public class XrayJsonCreator
    {
        public string? _title, _sTag, _fTag, _stepName, _stepKey, _exeStatus, status;

        public void getStepResults(ScenarioContext _sContext)
        {
            _stepName = _sContext.StepContext.StepInfo.Text;
            _stepKey = _sContext.StepContext.StepInfo.StepDefinitionType.ToString();

            ScenarioBlock scenarioBlock = _sContext.CurrentScenarioBlock;

            switch (scenarioBlock)
            {
                case ScenarioBlock.Given:
                    if (_sContext.TestError != null)
                    {
                        _exeStatus = "failed";
                    }
                    else
                    {
                        _exeStatus = "passed";
                    }
                    break;
                case ScenarioBlock.When:
                    if (_sContext.TestError != null)
                    {
                        _exeStatus = "failed";
                    }
                    else
                    {
                        _exeStatus = "passed";
                    }
                    break;
                case ScenarioBlock.Then:
                    if (_sContext.TestError != null)
                    {
                        _exeStatus = "failed";
                    }
                    else
                    {
                        _exeStatus = "passed";
                    }
                    break;
                default:
                    if (_sContext.TestError != null)
                    {
                        _exeStatus = "failed";
                    }
                    else
                    {
                        _exeStatus = "passed";
                    }
                    break;
            }
        }

        public void getScenarioResults(ScenarioContext _sContext)
        {
            _title = _sContext.ScenarioInfo.Title;
            _sTag = _sContext.ScenarioInfo.ScenarioAndFeatureTags.ElementAt<string>(0);
            _fTag = _sContext.ScenarioInfo.ScenarioAndFeatureTags.ElementAt<string>(1);
        }

        public void displayResults()
        {
            Console.WriteLine("TTTTTTTTTT -------- " + _title);
            Console.WriteLine("STSTSTSTST -------- " + _stepName);
            Console.WriteLine("TAGTAGTAGT -------- " + _sTag);
            Console.WriteLine("FTFTFTFTFT -------- " + _fTag);
            Console.WriteLine("SKSKSKSKSK -------- " + _stepKey);
            Console.WriteLine("SSSSSSSSSS -------- " + _exeStatus);
        }

        public void jsonCreator()
        {
            Result result = new Result()
            {
                Duration = 1,
                Status = _exeStatus,
            };

            Step step = new Step()
            {
                Result = new Result()
                {
                    Duration = 1,
                    Status = _exeStatus,
                },
                Name = _title,
                Keyword = _stepKey,
            };

            Tag exeTag = new Tag()
            {
                Name = _fTag,
            };

            Tag tcTag = new Tag()
            {
                Name = _sTag,
            };

            Element element = new Element()
            {
                Name = _stepName,
                Type = "scenario",
                Keyword = "Scenario",
                Steps = new List<Step>() { step },
                Tags = new List<Tag>() { exeTag, tcTag },
            };

            Root root = new Root()
            {
                Elements = new List<Element>() { element },
            };

            string json = JsonConvert.SerializeObject(root);
            string updatedJson = "[" + json + "]";
            File.WriteAllText(@"C:\Users\PramodChinthaka\Documents\Visual Studio 2022\SpecFlowCW\SpecFlowCW\Reports\json_report\results.json", updatedJson);

        }
    }

    public class Result
    {
        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class Step
    {
        [JsonProperty("result")]
        public Result Result { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("keyword")]
        public string Keyword { get; set; }
    }

    public class Tag
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Element
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("keyword")]
        public string Keyword { get; set; }

        [JsonProperty("steps")]
        public List<Step> Steps { get; set; }

        [JsonProperty("tags")]
        public List<Tag> Tags { get; set; }
    }

    public class Root
    {
        [JsonProperty("elements")]
        public List<Element> Elements { get; set; }
    }
}
