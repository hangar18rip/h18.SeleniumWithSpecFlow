using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome.Fakes;
using OpenQA.Selenium.Remote.Fakes;
using TechTalk.SpecFlow;

namespace h18.SeleniumWithSpecFlow.UnitTests
{
    [TestClass]
    public class HookBaseTests
    {

        private class FakeConfig : HookConfigurationBase<OpenQA.Selenium.Chrome.ChromeOptions>
        {

        }

        private class FakeHook : HookBase<OpenQA.Selenium.Chrome.ChromeDriver, OpenQA.Selenium.Chrome.ChromeOptions, FakeConfig>
        {
            public FakeHook(ScenarioContext context) : base(context)
            {

            }

            protected override OpenQA.Selenium.Chrome.ChromeDriver GetDriver(OpenQA.Selenium.Chrome.ChromeOptions options)
            {
                return new OpenQA.Selenium.Chrome.ChromeDriver(options);
            }
        }

        [TestMethod]
        public void ctor_test()
        {
            var fh = new FakeHook(null);
            Assert.IsNotNull(fh);
        }

        [TestMethod]
        public void RunBeforeScenario_test()
        {
            using (ShimsContext.Create())
            {
                ShimChromeDriver.ConstructorChromeOptions = (@this, o) => { };
                ShimRemoteWebDriver.AllInstances.IsSpecificationCompliantGet = (o) => { return true; };
                ShimRemoteWebDriver.AllInstances.ExecuteStringDictionaryOfStringObject = (@this, s, d) => { return null; };
                var fh = new FakeHook(null);
                Assert.IsNotNull(fh);
                fh.RunBeforeScenario();
            }
        }

    }
}
