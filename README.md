# h18.SeleniumWithSpecFlow

This package offers basic implementation to use Selenium features with SpecFlow and MSTest framework

[![Build Status](https://dev.azure.com/hangar18github/hangar_18/_apis/build/status/hangar18rip.h18.SeleniumWithSpecFlow?repoName=hangar18rip%2Fh18.SeleniumWithSpecFlow&branchName=master)](https://dev.azure.com/hangar18github/hangar_18/_build/latest?definitionId=13&repoName=hangar18rip%2Fh18.SeleniumWithSpecFlow&branchName=master) [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=hangar18rip.h18.SeleniumWithSpecFlow&metric=alert_status)](https://sonarcloud.io/dashboard?id=hangar18rip.h18.SeleniumWithSpecFlow)

[Get on NuGet](https://www.nuget.org/packages/h18.SeleniumWithSpecFlow/)

# Implementation

This package provides the base implementation of a SpecFlow binding and a configuration for this binding

## Binding

The binding allows to automatically create a screenshot of the browser before and after each step. It also allows to create a screenshot before and after each scenario.

## Configuration

The configuration allows to control the behavior of the binding :
- Browser state initial
- Screenshot management
- ...

### Configure the binding

```csharp
[BeforeScenario]
public void BeforeScenario()
{
    var conf = new h18.SeleniumWithSpecFlow.Edge.EdgeHookConfiguration();
    // Set conf
    Context.Set(conf, "driverConfiguraiton");
}
```

### Get the configured Driver

```csharp
[Given(@"I go to the home page")]
public void GivenIGoToTheHomePage()
{
    // Get the driver
    _driver = Context.Get<IWebDriver>("currentDriver");
    // Use the driver
    _driver.Navigate().GoToUrl(ExecutionContext.Current.ApplicationUri);
}
```

