using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace h18.SpecFlow.SeleniumHookChrome.UnitTests
{
    [Binding]
    public class HookChromeTestsWithContextSteps
    {
        private ScenarioContext context;

        public HookChromeTestsWithContextSteps(ScenarioContext context)
        {
            this.context = context;
        }

        [BeforeScenario()]
        public void BeforeScenario()
        {
            context.Add("driverConfiguraiton", new HookChromeConfiguration { WindowsState = WindowsState.Maximize });
        }

        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int p0)
        {
        }

        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int p0)
        {
            var driver = context.Get<ChromeDriver>("currentDriver");
            driver.Navigate().GoToUrl("https://www.bing.com");
        }

        [When(@"the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            var driver = context.Get<ChromeDriver>("currentDriver");
            driver.Manage().Window.Position = new System.Drawing.Point(200, 200);
            driver.Manage().Window.Size = new System.Drawing.Size(200, 200);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int p0)
        {
            Assert.IsTrue(true);
        }
    }
}
