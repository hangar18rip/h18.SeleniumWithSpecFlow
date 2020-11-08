using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;

namespace h18.SpecFlow.SeleniumHookChrome
{
    public sealed class DriverConfiguration<T> where T : DriverOptions, new()
    {
        public T DriverOptions { get; } = new T();
        public Point WindowsPosition { get; set; } = new Point(0, 0);
        public Size WindowsSize { get; set; } = new Size(1920, 1080);
        public WindowsState WindowsState { get; set; } = WindowsState.Default;
        public TimeSpan ImplicitWaitTimeout { get; set; } = TimeSpan.FromSeconds(10);
        public TimeSpan AsynchronousJavaScriptTimeout { get; set; } = TimeSpan.FromSeconds(10);
        public TimeSpan PageLoadTimeout { get; set; } = TimeSpan.FromSeconds(10);
    }
}
