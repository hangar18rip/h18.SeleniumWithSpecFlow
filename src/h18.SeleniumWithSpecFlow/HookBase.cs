using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Diagnostics;
using System.IO;
using TechTalk.SpecFlow;

namespace h18.SeleniumWithSpecFlow
{
    [Binding]
    public abstract class HookBase<T, U, V> : IDisposable
        where T : RemoteWebDriver //, new()
        where U : DriverOptions, new()
        where V : HookConfigurationBase<U>, new()
    {
        private bool disposedValue;
        T driver;
        readonly V driverConfiguration;
        readonly ScenarioContext scenarioContext;
        TestContext testContext;
        int stepCount = 0;

        protected abstract T GetDriver(U options);

        protected HookBase(ScenarioContext context)
        {
            scenarioContext = context;

            scenarioContext?.TryGetValue("driverConfiguraiton", out driverConfiguration);
            if (driverConfiguration == null)
            {
                driverConfiguration = new V();
            }
        }

        [BeforeScenario(Order = int.MaxValue)]
        public void RunBeforeScenario()
        {
            stepCount = 0;
            testContext = scenarioContext?.ScenarioContainer.Resolve<TestContext>();


            var options = driverConfiguration.DriverOptions ?? new U();
            driver = GetDriver(options);
            ApplyConfiguration(driver);

            if (testContext != null && !Directory.Exists(testContext.TestResultsDirectory))
            {
                Trace.TraceInformation("Creating directory " + testContext.TestResultsDirectory);
                Directory.CreateDirectory(testContext.TestResultsDirectory);
            }

            scenarioContext?.Add("currentDriver", driver);


            SaveScreen(driverConfiguration.BeforeScenarioScreenShotEnabled, $"{testContext?.TestName}_before.png");

        }

        internal void ApplyConfiguration(T driver)
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
            SaveScreen(driverConfiguration.AfterScenarioScreenShotEnabled, $"{testContext?.TestName}_after.png");

            driver?.Quit();
        }

        [BeforeStep]
        public void RunBeforeStep()
        {
            SaveScreen(driverConfiguration.BeforeStepScreenShotEnabled, $"{testContext?.TestName}_step_{stepCount}_before.png");
            stepCount++;
        }

        [AfterStep]
        public void RunAfterStep()
        {
            SaveScreen(driverConfiguration.AfterStepScreenShotEnabled, $"{testContext?.TestName}_step_{stepCount}_after.png");

            stepCount++;
        }

        private void SaveScreen(bool doIt, string fileName)
        {
            if (!doIt)
            {
                return;
            }
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

        #region IDisposable implem
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
        #endregion
    }
}
