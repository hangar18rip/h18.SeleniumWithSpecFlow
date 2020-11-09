# h18.SeleniumWithSpecFlow

This Specflow Hook handles browser setup and screenshot saving.

Works with MSTest and currently supports :
- Microsoft Edge Chromium
- Google Chrome

Package version number matches the Google Chrome version it targets

## CI

![Build and Package](https://github.com/hangar18rip/h18.SeleniumWithSpecFlow/workflows/Build%20and%20Package/badge.svg) 
[![Build Status](https://dev.azure.com/hangar18github/hangar_18/_apis/build/status/hangar18rip.h18.SeleniumWithSpecFlow?branchName=main)](https://dev.azure.com/hangar18github/hangar_18/_build/latest?definitionId=13&branchName=main)

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=hangar18rip.h18.SeleniumWithSpecFlow&metric=alert_status)](https://sonarcloud.io/dashboard?id=hangar18rip.h18.SeleniumWithSpecFlow) 
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=hangar18rip.h18.SeleniumWithSpecFlow&metric=coverage)](https://sonarcloud.io/dashboard?id=hangar18rip.h18.SeleniumWithSpecFlow)



## Usage

Add a reference to the [nuget package](https://www.nuget.org/packages/h18.SpecFlow.SeleniumHookChrome/) in your SpecFlow test project.

Add a ```specflow.json``` file in your test project, set its ```Copy to Output Directory``` property to ```copy if newer``` and add this section into it :

For Microsoft Edge Chromium :
```json
{
  "stepAssemblies": [
    {
      "assembly": "h18.SeleniumWithSpecFlow.Edge"
    }
  ]
}
```

For Chrome :
```json
{
  "stepAssemblies": [
    {
      "assembly": "h18.SeleniumWithSpecFlow.Chrome"
    }
  ]
}
```