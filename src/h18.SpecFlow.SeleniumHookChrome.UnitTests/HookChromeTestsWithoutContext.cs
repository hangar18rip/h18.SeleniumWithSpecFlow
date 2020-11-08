using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace h18.SpecFlow.SeleniumHookChrome.UnitTests
{
    [TestClass]
    public class HookChromeTestsWithoutContext
    {
        [TestMethod]
        public void HookChrome_ctor()
        {
            var h = new HookChrome(null);
            Assert.IsNotNull(h);
            h.Dispose();
        }

        [TestMethod]
        public void HookChrome_RunBeforeScenario_NoContext()
        {
            var h = new HookChrome(null);
            h.RunBeforeScenario();
            h.Dispose();
        }


        [TestMethod]
        public void HookChrome_RunAfterScenario_NoContext()
        {
            var h = new HookChrome(null);
            h.RunAfterScenario();
            h.Dispose();
        }

        [TestMethod]
        public void HookChrome_RunAfterStep_NoContext()
        {
            var h = new HookChrome(null);
            h.RunAfterStep();
            h.Dispose();
        }
    }
}
