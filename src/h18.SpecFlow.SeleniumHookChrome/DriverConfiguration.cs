using OpenQA.Selenium;
using System;
using System.Drawing;

namespace h18.SpecFlow.SeleniumHookChrome
{
    public sealed class DriverConfiguration<T> where T : DriverOptions, new()
    {
        // Driver Optionss
        public T DriverOptions { get; } = new T();

        // Driver default configuration override
        public Point WindowsPosition { get; set; } = new Point(0, 0);
        public Size WindowsSize { get; set; } = new Size(1920, 1080);
        public WindowsState WindowsState { get; set; } = WindowsState.Default;
        public TimeSpan ImplicitWaitTimeout { get; set; } = TimeSpan.FromSeconds(10);
        public TimeSpan AsynchronousJavaScriptTimeout { get; set; } = TimeSpan.FromSeconds(10);
        public TimeSpan PageLoadTimeout { get; set; } = TimeSpan.FromSeconds(10);

        // Hook configuration
        public bool BeforeStepScreenShotEnabled { get; set; } = false;
        public bool AfterStepScreenShotEnabled { get; set; } = true;
        public bool BeforeScenarioScreenShotEnabled { get; set; } = false;
        public bool AfterScenarioScreenShotEnabled { get; set; } = true;
    }
}
