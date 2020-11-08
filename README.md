# h18.SpecFlow.SeleniumHookChrome

This Specflow Hook handles Chrome setup and screenshot saving.

Works with MSTest and Google Chrome

Package version number matches the Google Chrome version it targets

## CI

![Build and Package](https://github.com/hangar18rip/h18.SpecFlow.SeleniumHookChrome/workflows/Build%20and%20Package/badge.svg) 
[![Build Status](https://dev.azure.com/hangar18github/hangar_18/_apis/build/status/hangar18rip.h18.SpecFlow.SeleniumHookChrome?branchName=main)](https://dev.azure.com/hangar18github/hangar_18/_build/latest?definitionId=13&branchName=main)

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=hangar18rip.h18.SpecFlow.SeleniumHookChrome&metric=alert_status)](https://sonarcloud.io/dashboard?id=hangar18rip.h18.SpecFlow.SeleniumHookChrome) 
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=hangar18rip.h18.SpecFlow.SeleniumHookChrome&metric=coverage)](https://sonarcloud.io/dashboard?id=hangar18rip.h18.SpecFlow.SeleniumHookChrome)



## Usage

Add a reference to the [nuget package](https://www.nuget.org/packages/h18.SpecFlow.SeleniumHookChrome/) in your SpecFlow test project.

Add a ```specflow.json``` file in your test project with this content :

```
{
  "stepAssemblies": [
    {
      "assembly": "h18.SpecFlow.SeleniumHookChrome"
    }
  ]
}
```