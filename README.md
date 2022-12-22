# HE Automation Test Framework

## Introduction
This .Net test framework uses the SpecFlow library to run regression and functional tests using selenium. Currently the framework is set up to run on Chrome and Firefox browsers (using chrome.exe and gecko.exe drivers).

There is scope to run these tests in a "headless" state, which would be suitable in the Azure build pipelines.

#### Test Execution
Can be done via Visual Studio and can be ran through your local machine. Browsers can be tested in headless mode as well.

In your windows cmd.exe or gitbash.exe run the following command:
`dotnet test MyProject.Specs/`

For Azure DevOps pipelines we will need to run it like so (we will need a binary file as well):
`dotnet vstest MyProject.Specs/bin/Debug/netcoreapp3.1/HistoricalEngland.Specs.dll`

#### Test Reporting
Currently the only "reporting" is done in mthe console log. For more useful test artefacts, reporting tools like Allure-Reporting would be useful for this project.

### SpecFlow
Specflow is a Behaviour Driven Development test framework which uses business stories at the blue print for automations scripts. Using the key phrases such as; *Given*, *When*, *And*, *Then*. In the exact same way as the Cucumber metodology.

#### POM (Page Object Model)
The overall design structure of the framework follows the "Page Object Model". This means that classes are arranged in such a way that objects and methods are found in the same .cs file which corresponds to a UI page. The purpose of this is to make the framework more readable for people.

#### NuGet - Solution pacjages
- coverlet.collector
- DotNetSeleniumExtras.WaitHelpers
- Microsoft.NET.Test.Sdk
- Selenium.Firefox.WebDriver
- Selenium.Support
- Selenium.WebDriver
- Selenium.WebDriver.ChromeDriver
- Selenium.WebDriver.IEDriver
- SpecFlow
- SpecFlow.NUnit
- SpecFlow.NUnit.Runners
- SpecFlow.Tools.MSBuild.Generation
- SpeccRun.Runner

#### Manage Extensions
In Visual Studio go to `Extensions` and click `Manage Extensions`.
Download the Specflow Extension

#### To generate mytest.trx report file

Go to command line where your MyProject.Specs and run the following command:

$ dotnet test "type_path\MyProject.Specs\bin\Debug\netcoreapp3.1\HistoricalEngland.Specs.dll"
--logger "trx;LogFileName=type_path\MyProject.Specs\mytest.trx"

Example:
dotnet test "C:\Users\source\review_repo\HE_Automation\MyProject.Specs\bin\Debug\netcoreapp3.1\HistoricalEngland.Specs.dll"
--logger "trx;LogFileName=C:\Users\source\review_repo\HE_Automation\MyProject.Specs\mytest.trx"

To run specific tests using tagname with reporting:

$ dotnet test "Replace_with_path\MyProject.Specs\bin\Debug\netcoreapp3.1\HistoricalEngland.Specs.dll"
--filter TestCategory="Replace_with_tag_name_from_script" --logger "trx;LogFileName=Replace_with_path\MyProject.Specs\mytest.trx"

Example:
dotnet test "C:\Users\source\review_repo\HE_Automation\MyProject.Specs\bin\Debug\netcoreapp3.1\HistoricalEngland.Specs.dll" 
--filter TestCategory="SiteNav_12958" --logger "trx;LogFileName=C:\Users\source\review_repo\HE_Automation\MyProject.Specs\mytest.trx"


To run specific tests using tagname without logging for reports:

$ dotnet test "Replace_with_path\MyProject.Specs\bin\Debug\netcoreapp3.1\HistoricalEngland.Specs.dll"
--filter TestCategory="Replace_with_tag_name_from_script" 

Example:
dotnet test "C:\Users\source\review_repo\HE_Automation\MyProject.Specs\bin\Debug\netcoreapp3.1\HistoricalEngland.Specs.dll" 
--filter TestCategory="SiteNav_12958" --logger


