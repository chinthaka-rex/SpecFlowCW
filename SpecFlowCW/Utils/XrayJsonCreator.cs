using Newtonsoft.Json;

namespace SpecFlowCW.Utils
{
    public class XrayJsonCreator
    {
        public string? _title, _sTag, _fTag, _stepName, _stepKey, _exeStatus, status;

        public static List<Step> steps = new List<Step>();
        public static List<Element> elements = new List<Element>();

        public void getStepResults(ScenarioContext _sContext)
        {
            _stepName = _sContext.StepContext.StepInfo.Text;
            _stepKey = _sContext.StepContext.StepInfo.StepDefinitionType.ToString();
            _title = _sContext.ScenarioInfo.Title;
            _sTag = _sContext.ScenarioInfo.ScenarioAndFeatureTags.ElementAt<string>(0);
            _fTag = _sContext.ScenarioInfo.ScenarioAndFeatureTags.ElementAt<string>(1);

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

        public void jsonStepCreator()
        {
            Step step = new Step()
            {
                Result = new Result()
                {
                    Duration = 1,
                    Status = _exeStatus,
                },
                Name = _stepName,
                Keyword = _stepKey,
            };

            steps.Add(step);
        }

        public void jsonCreator()
        {
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
                Name = _title,
                Type = "scenario",
                Keyword = "Scenario",
                Steps = new List<Step>(steps),
                Tags = new List<Tag>() { exeTag, tcTag },
            };

            elements.Add(element);
            steps.Clear();

            Root root = new Root()
            {
                Elements = new List<Element>(elements),
            };

            string json = JsonConvert.SerializeObject(root);
            string updatedJson = "[" + json + "]";
            File.WriteAllText(@"~/../../../../Reports/json_report/results.json", updatedJson);
        }
    }

    public class Result
    {
        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }
    }

    public class Step
    {
        [JsonProperty("result")]
        public Result? Result { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("keyword")]
        public string? Keyword { get; set; }
    }

    public class Tag
    {
        [JsonProperty("name")]
        public string? Name { get; set; }
    }

    public class Element
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("keyword")]
        public string? Keyword { get; set; }

        [JsonProperty("steps")]
        public List<Step>? Steps { get; set; }

        [JsonProperty("tags")]
        public List<Tag>? Tags { get; set; }
    }

    public class Root
    {
        [JsonProperty("elements")]
        public List<Element>? Elements { get; set; }
    }
}
