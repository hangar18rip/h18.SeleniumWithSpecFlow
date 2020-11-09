using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace h18.SeleniumWithSpecFlow.Edge.UnitTests
{
    [TestClass]
    public class EdgeHookTestsWithoutContext
    {
        [TestMethod]
        public void EdgeHook_ctor()
        {
            var h = new EdgeHook(null);
            Assert.IsNotNull(h);
            h.Dispose();
        }

        [TestMethod]
        public void EdgeHook_RunBeforeScenario_NoContext()
        {
            var h = new EdgeHook(null);
            Assert.IsNotNull(h);
            h.RunBeforeScenario();
            h.Dispose();
        }


        [TestMethod]
        public void EdgeHook_RunAfterScenario_NoContext()
        {
            var h = new EdgeHook(null);
            Assert.IsNotNull(h);
            h.RunAfterScenario();
            h.Dispose();
        }

        [TestMethod]
        public void EdgeHook_RunAfterStep_NoContext()
        {
            var h = new EdgeHook(null);
            Assert.IsNotNull(h);
            h.RunAfterStep();
            h.Dispose();
        }
    }
}
