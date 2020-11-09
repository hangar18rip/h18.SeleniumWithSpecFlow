using h18.SeleniumWithSpecFlow.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace h18.SeleniumWithSpecFlow.Chrome.UnitTests
{
    [Binding]
    public class ChromeHookTestsWithContextSteps
    {
        private readonly ScenarioContext context;

        public ChromeHookTestsWithContextSteps(ScenarioContext context)
        {
            this.context = context;
        }

        [BeforeScenario()]
        public void BeforeScenario()
        {
            context.Add("driverConfiguraiton", new ChromeHookConfiguration { WindowsState = WindowsState.Maximize });
        }

        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int p0)
        {
            var driver = context.Get<ChromeDriver>("currentDriver");
            driver.Manage().Window.Position = new System.Drawing.Point(200, 200);
            driver.Manage().Window.Size = new System.Drawing.Size(200, 200);
        }

        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int p0)
        {
            var driver = context.Get<ChromeDriver>("currentDriver");
            driver.Navigate().GoToUrl("https://www.bing.com");
        }

        [Given(@"the third number is (.*)")]
        public void GivenTheThirdNumberIs(int p0)
        {
            var driver = context.Get<ChromeDriver>("currentDriver");
            driver.Manage().Window.FullScreen();
            driver.Navigate().GoToUrl("https://www.microsoft.com");
        }

        [When(@"the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            // not used
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int p0)
        {
            Assert.IsTrue(true);
        }
    }
}
