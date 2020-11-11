using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace h18.SeleniumWithSpecFlow.UnitTests
{
    [TestClass]
    public class HookConfigurationBaseTests
    {
        private class FakeConfig : HookConfigurationBase<OpenQA.Selenium.Chrome.ChromeOptions>
        {

        }

        [TestMethod]
        public void HookConfigurationBase_ctor()
        {
            var fc = new FakeConfig();
            Assert.IsNotNull(fc);

            fc.BeforeStepScreenShotEnabled = !fc.AfterScenarioScreenShotEnabled;
            fc.AfterStepScreenShotEnabled = !fc.AfterStepScreenShotEnabled;
            fc.BeforeScenarioScreenShotEnabled = !fc.BeforeScenarioScreenShotEnabled;
            fc.AfterScenarioScreenShotEnabled = !fc.AfterScenarioScreenShotEnabled;

            fc.WindowsPosition = new System.Drawing.Point(100, 100);
            fc.WindowsSize = new System.Drawing.Size(500, 500);
            fc.WindowsState = WindowsState.FullScreen;
            var ts = TimeSpan.FromSeconds(2);
            fc.ImplicitWaitTimeout = ts;
            fc.AsynchronousJavaScriptTimeout = ts;
            fc.PageLoadTimeout = ts;
        }



    }
}
