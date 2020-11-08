using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using TechTalk.SpecFlow;

namespace h18.SpecFlow.SeleniumHookChrome
{
    [Binding]
    public class HookChrome : IDisposable
    {
        ChromeDriver driver;
        TestContext testContext;
        int stepCount = 0;
        private bool disposedValue;
        readonly ScenarioContext scenarioContext;

        public HookChrome(ScenarioContext context)
        {
            scenarioContext = context;
        }

        [BeforeScenario]
        public void RunBeforeScenario()
        {
            stepCount = 0;
            testContext = scenarioContext?.ScenarioContainer.Resolve<TestContext>();
            var options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Size = new Size(1920, 1080);
            driver.Manage().Window.Position = new Point(0, 0);

            if (testContext != null && !Directory.Exists(testContext.TestResultsDirectory))
            {
                Trace.TraceInformation("Creating directory " + testContext.TestResultsDirectory);
                Directory.CreateDirectory(testContext.TestResultsDirectory);
            }

            scenarioContext?.Add("currentDriver", driver);
        }

        [AfterScenario]
        public void RunAfterScenario()
        {
            SaveScreen($"{testContext?.TestName}.png");
            driver?.Quit();
        }

        [AfterStep]
        public void RunAfterStep()
        {

            SaveScreen($"{testContext?.TestName}_step_{stepCount}.png");
            stepCount++;
        }

        private void SaveScreen(string fileName)
        {
            if (driver == null) { return; }
            try
            {
                var tempDir = Path.GetTempPath();
                var filePath = Path.Combine(tempDir, fileName);
                Trace.TraceInformation($"Saving screen shot to file '{filePath}'");
                driver.GetScreenshot().SaveAsFile(filePath, ScreenshotImageFormat.Png);
                testContext?.AddResultFile(filePath);
                Trace.TraceInformation(" ... done :)");
            }
            catch (Exception ex)
            {
                Trace.TraceError($"{ex}");
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // dispose managed state (managed objects)
                    driver?.Dispose();
                }

                // free unmanaged resources (unmanaged objects) and override finalizer
                // set large fields to null
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
