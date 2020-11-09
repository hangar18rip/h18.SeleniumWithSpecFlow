using h18.SeleniumWithSpecFlow.Core;
using Microsoft.Edge.SeleniumTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace h18.SeleniumWithSpecFlow.Edge.UnitTests
{
    [Binding]
    public class EdgeHookTestsWithContextSteps
    {
        private readonly ScenarioContext context;

        public EdgeHookTestsWithContextSteps(ScenarioContext context)
        {
            this.context = context;
        }

        [BeforeScenario()]
        public void BeforeScenario()
        {
            context.Add("driverConfiguraiton", new EdgeHookConfiguration { WindowsState = WindowsState.Maximize });
        }

        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int p0)
        {
            var driver = context.Get<EdgeDriver>("currentDriver");
            driver.Manage().Window.FullScreen();
            driver.Navigate().GoToUrl("https://www.microsoft.com");
        }

        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int p0)
        {
            // not used
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
