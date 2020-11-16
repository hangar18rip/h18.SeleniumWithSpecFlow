# h18.SeleniumWithSpecFlow

This package offers basic implementation to use Selenium features with SpecFlow and MSTest framework

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

