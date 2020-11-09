using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace h18.SeleniumWithSpecFlow.Chrome.UnitTests
{
    [TestClass]
    public class HookChromeTestsWithoutContext
    {
        [TestMethod]
        public void HookChrome_ctor()
        {
            var h = new ChromeHook(null);
            Assert.IsNotNull(h);
            h.Dispose();
        }

        [TestMethod]
        public void HookChrome_RunBeforeScenario_NoContext()
        {
            var h = new ChromeHook(null);
            Assert.IsNotNull(h);
            h.RunBeforeScenario();
            h.Dispose();
        }


        [TestMethod]
        public void HookChrome_RunAfterScenario_NoContext()
        {
            var h = new ChromeHook(null);
            Assert.IsNotNull(h);
            h.RunAfterScenario();
            h.Dispose();
        }

        [TestMethod]
        public void HookChrome_RunAfterStep_NoContext()
        {
            var h = new ChromeHook(null);
            Assert.IsNotNull(h);
            h.RunAfterStep();
            h.Dispose();
        }
    }
}
