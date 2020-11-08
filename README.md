# h18.SpecFlow.SeleniumHookChrome

This Specflow Hook handles Chrome setup and screenshot saving.

Works with MSTest and Google Chrome

## CI

![Build and Package](https://github.com/hangar18rip/h18.SpecFlow.SeleniumHookChrome/workflows/Build%20and%20Package/badge.svg)

[![Build Status](https://dev.azure.com/hangar18github/hangar_18/_apis/build/status/hangar18rip.h18.SpecFlow.SeleniumHookChrome?branchName=main)](https://dev.azure.com/hangar18github/hangar_18/_build/latest?definitionId=13&branchName=main)

## Usage

Add a ```specflow.json``` file in your test project in addition to the Package ref

```
{
  "stepAssemblies": [
    {
      "assembly": "h18.SpecFlow.SeleniumHookChrome"
    }
  ]
}
```