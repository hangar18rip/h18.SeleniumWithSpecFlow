
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
