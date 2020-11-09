using h18.SeleniumWithSpecFlow.Core;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace h18.SeleniumWithSpecFlow.Chrome
{
    public class ChromeHook : HookBase<ChromeDriver, ChromeOptions, ChromeHookConfiguration>
    {
        public ChromeHook(ScenarioContext context) : base(context)
        {

        }

        protected override ChromeDriver GetDriver(ChromeOptions options)
        {
            options.AddArgument("no-sandbox");
            return new ChromeDriver(options);
        }
    }
}
