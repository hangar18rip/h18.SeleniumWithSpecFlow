
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace h18.SeleniumWithSpecFlow.UnitTests
{
    [TestClass]
    public class HookBaseTests
    {

        private class FakeConfig : HookConfigurationBase<OpenQA.Selenium.Chrome.ChromeOptions>
        {

        }

        private class FakeHook : HookBase<OpenQA.Selenium.Chrome.ChromeDriver, OpenQA.Selenium.Chrome.ChromeOptions>
        {
            public FakeHook(ScenarioContext context) : base(context)
            {

            }

            protected override OpenQA.Selenium.Chrome.ChromeDriver GetDriver(OpenQA.Selenium.Chrome.ChromeOptions options)
            {
                return new OpenQA.Selenium.Chrome.ChromeDriver(options);
            }

            protected override HookConfigurationBase<ChromeOptions> GetDefaultConfiguration()
            {
                return new FakeConfig();
            }
        }

        [TestMethod]
        public void HookBase_ctor()
        {
            using (var fh = new FakeHook(null))
            {
                Assert.IsNotNull(fh);
            }
        }

        [TestMethod]
        public void HookBase_RunBeforeScenario()
        {
            using (var fh = new FakeHook(null))
            {
                Assert.IsNotNull(fh);
                fh.RunBeforeScenario();
            }
        }


        [TestMethod]
        public void HookBase_RunAfterScenario()
        {
            var fh = new FakeHook(null);
            Assert.IsNotNull(fh);

            fh.RunAfterScenario();
        }

        [TestMethod]
        public void HookBase_RunAfterStep()
        {
            var fh = new FakeHook(null);
            Assert.IsNotNull(fh);

            fh.RunAfterStep();
        }

        [TestMethod]
        public void HookBase_RunBeforeStep()
        {
            var fh = new FakeHook(null);
            Assert.IsNotNull(fh);

            fh.RunBeforeStep();
        }

        [TestMethod]
        public void HookBase_ApplyConfiguration_NullDriver()
        {
            var fh = new FakeHook(null);
            Assert.IsNotNull(fh);

            fh.ApplyConfiguration(null);

        }
    }
}
