using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Diagnostics;
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
        readonly DriverConfiguration<ChromeOptions> driverConfiguration;

        public HookChrome(ScenarioContext context)
        {
            scenarioContext = context;

            scenarioContext?.TryGetValue("driverConfiguraiton", out driverConfiguration);
            if (driverConfiguration == null)
            {
                driverConfiguration = new DriverConfiguration<ChromeOptions>();
            }
#if DEBUG
            else
            {
                Trace.TraceInformation("Using UserDefined configuration");
            }
#endif
        }

        [BeforeScenario]
        public void RunBeforeScenario()
        {
            stepCount = 0;
            testContext = scenarioContext?.ScenarioContainer.Resolve<TestContext>();


            var options = driverConfiguration.DriverOptions ?? new ChromeOptions();
            options.AddArgument("no-sandbox");
            driver = new ChromeDriver(options);
            ApplyConfiguration(driver);

            if (testContext != null && !Directory.Exists(testContext.TestResultsDirectory))
            {
                Trace.TraceInformation("Creating directory " + testContext.TestResultsDirectory);
                Directory.CreateDirectory(testContext.TestResultsDirectory);
            }

            scenarioContext?.Add("currentDriver", driver);
        }

        void ApplyConfiguration(ChromeDriver driver)
        {
            if (driver == null)
            {
                return;
            }

            var options = driver.Manage();


            options.Timeouts().AsynchronousJavaScript = driverConfiguration.AsynchronousJavaScriptTimeout;
            options.Timeouts().ImplicitWait = driverConfiguration.ImplicitWaitTimeout;
            options.Timeouts().PageLoad = driverConfiguration.PageLoadTimeout;

            options.Window.Position = driverConfiguration.WindowsPosition;
            options.Window.Size = driverConfiguration.WindowsSize;

            switch (driverConfiguration.WindowsState)
            {
                case WindowsState.FullScreen:
                    options.Window.FullScreen();
                    break;
                case WindowsState.Maximize:
                    options.Window.Maximize();
                    break;
                case WindowsState.Minimize:
                    options.Window.Minimize();
                    break;
                default:
                    break;
            }

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
