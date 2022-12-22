using BoDi;
using AventStack.ExtentReports.Configuration;
using AventStack.ExtentReports.Utils;
using HistoricalEngland.Specs.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using TechTalk.SpecFlow;
using HistoricalEngland.Specs.Helpers;
using System.Diagnostics;
using HistoricalEngland.Specs.StepDefinitions.BaseSteps;
using System;

namespace HistoricalEngland.Specs.StepDefinitions.ArchiveCollectionOnline
{
    [Binding]
    class SearchAndFilterSteps
    {
        private IWebDriver driver;
        private SearchAndFilterPageObjects srchFilterPgObj;
        private SearchAndFilterMethods srchFilterMethods;
        private readonly NavigationSteps navigationSteps;
        private static readonly ConfigBuild config = new ConfigBuild();

        //Context variables
        private string dateFrom, dateTo, srchTxtBuild;
        private string archiveLandUrl;

        public SearchAndFilterSteps(IWebDriver driver, SearchAndFilterPageObjects srchFilterPgObj,
            SearchAndFilterMethods srchFilterMethod, NavigationSteps navigationSteps)
        {
            this.driver = driver;
            this.srchFilterMethods = srchFilterMethod;
            this.srchFilterPgObj = srchFilterPgObj;
            this.navigationSteps = navigationSteps;
        }

        [Given(@"I am on the ACO search page")]
        public void GivenIAmOnTheACOSearchPage()
        {
            srchFilterMethods.JsClick(srchFilterPgObj.ImageBookLink);
            srchFilterMethods.JsClick(srchFilterPgObj.FindPhotosLink);
        }

        [Then(@"I am presented with results for ""(.*)""")]
        public void ThenIAmPresentedWithResultsFor(string txt)
        {

            Assert.IsTrue(srchFilterMethods.FindElementIsPresent(srchFilterPgObj.LLonSearchRes),
                "Results not found");
            bool flag = srchFilterMethods.SearchInfoRequest(txt, srchFilterPgObj.LLonSearchRes);
            Assert.IsTrue(flag,
                "Please check if all elements from searching results contain searching phrase");

        }


        [Given(@"I am on the results page for ""(.*)""")]
        public void CheckTheResultsPageFor(string searchString)
        {

            navigationSteps.NavigateToThePage("aco-search-page");
            srchFilterMethods.FindElementAndEnterChars(srchFilterPgObj.SearchInput, searchString);
            srchFilterMethods.JsClick(srchFilterPgObj.QuickSearchBtn);
            //srchFilterMethods.ImplicitWaitTimeOut(20);

            
            By headerElement = srchFilterMethods.DynamicWebElement(srchFilterPgObj.ResultHeaderSelector, searchString);
			Assert.IsTrue(srchFilterMethods.FindElementIsPresent(headerElement),
				"No results found for this searching phrase");
			/**
             * 60 sec ?
             * **/

			//srchFilterMethods.ImplicitWaitTimeOut(60);
			//srchFilterMethods.JsScrollToPgBottom();


			/**Wait for what?
             * **/

			//srchFilterMethods.FluentWaitCall(srchFilterPgObj.ImageLink);
		}


        [Given(@"I enter ""(.*)"" in ""(.*)"" date field")]

        [Then(@"I enter ""(.*)"" in ""(.*)"" date field")]
        public void GivenIEnterInDateField(string srchDate, string dateTxt)
        { if (dateTxt.Equals("After"))
            {
                dateFrom = srchDate;
                srchFilterMethods.FindElementAndEnterKeys(srchFilterPgObj.InputDateFrom, srchDate);
            }
            else
            {
                dateTo = srchDate;
                srchFilterMethods.FindElementAndEnterKeys(srchFilterPgObj.InputDateTo, srchDate);
            }
        }


        [Then(@"I am taken to the refined results page for the specified dates")]
        public void ThenIAmTakenToTheRefinedResultsPageForTheSpecifiedDates()
        {
            bool result;
            try
            {
                result = srchFilterMethods.FindElementIsPresent(srchFilterPgObj.FindDate);
                if (!result)
                {
                    Thread.Sleep(3000);
                    Assert.IsTrue(srchFilterMethods.FindElementIsPresent(srchFilterPgObj.FindDate),
                        "No results found for this date");
                }
            }
            catch (Exception)
            {
                Thread.Sleep(3000);
                srchFilterMethods.JsScrollToPgBottom();
                Assert.IsTrue(srchFilterMethods.FindElementIsPresent(srchFilterPgObj.FindDate),
                    "No results found for this date");

            }
            //archiveLandUrl = config.configuration["appSettings:ArchiveLandingUrl"];
            //Debug.WriteLine("Archive url: "+archiveLandUrl);
            //Debug.WriteLine("Current url: "+srchFilterMethods.GetCurUrl());
            //driver.Navigate().Refresh();


            // below code implemented due to unstable environment - enviro issues now resolved 
            //Code added to address issues with Apply Filter button
            //When Apply Filter is clicked it takes back to the landing page



            //if (srchFilterMethods.GetCurUrl().Equals(archiveLandUrl))
            //{
            //    Debug.WriteLine("I am on Landing page");
            //    srchFilterMethods.ClickBrowserBack();
            //}

            //Assert.IsTrue(srchFilterMethods.FindElementIsPresent(srchFilterPgObj.ResultForDate),
            //    "0 datefields found");
            //bool flag = srchFilterMethods.CheckDateResults(srchFilterPgObj.ResultForDate, dateFrom, dateTo);
            //Assert.IsTrue(flag.Equals(true),"Not all Archives from"+
            //    "result list were created between "+dateFrom+" and "+dateTo);
        }

        [Then(@"the values will clear from the date fields")]
        public void ThenTheValuesWillClearFromTheDateFields()
        {
            Assert.IsTrue(srchFilterMethods.FindElementGetValue(srchFilterPgObj.InputDateFrom).IsNullOrEmpty(),
                "Input \'After\' is not empty");
            Assert.IsTrue(srchFilterMethods.FindElementGetValue(srchFilterPgObj.InputDateTo).IsNullOrEmpty(),
                "Input \'Before\' is not empty");

        }
        [When(@"I type ""(.*)"" into the ""(.*)"" field")]
        public void TypeIntoTheField(string srchTxt, string field)
        {

            switch (field)
            {
                case "parish":
                    srchFilterMethods.FindElementAndEnterChars(srchFilterPgObj.ParishInput, srchTxt);
                    break;
                case "county":
                    srchFilterMethods.FindElementAndEnterChars(srchFilterPgObj.CountyInput, srchTxt);
                    break;
                case "building":
                    srchFilterMethods.FindElementAndEnterChars(srchFilterPgObj.BuildCathInput, srchTxt);
                    break;
                default:
                    break;

            }
            srchTxtBuild = srchTxt;
        }

        [Then(@"a drop down menu should appear with the search term")]
        public void DropDownMenuShouldAppearWithTheSearch()
        {
            By label = srchFilterMethods.DynamicWebElement(srchFilterPgObj.AutoSuggestionLabelSelector, srchTxtBuild);
            srchFilterMethods.FluentWaitCall(label);
            srchFilterMethods.JsClick(label);
            Thread.Sleep(5000);
           
        }

        [Then(@"I am taken to the refined results page for selected ""(.*)""")]
        public void ThenIAmTakenToTheRefinedResultsPageFor(string srchTxt)
        {
            archiveLandUrl = config.configuration["appSettings:ArchiveLandingUrl"];
            Debug.WriteLine("Archive url: " + archiveLandUrl);
            Debug.WriteLine("Current url: " + srchFilterMethods.GetCurUrl());
            //driver.Navigate().Refresh();

            //Code added to address issues with Apply Filter button
            //When Apply Filter is clicked it takes back to the landing page

            if (srchFilterMethods.GetCurUrl().Equals(archiveLandUrl))
            {
                Debug.WriteLine("I am on the landing page function");
                srchFilterMethods.ClickBrowserBack();
                Assert.IsTrue(srchFilterMethods.FindElementIsPresent(srchFilterPgObj.BuildCathResult),
                    "No results found for this searching phrase");

            }
            switch (srchTxt)
            {
                case "county":
                    Thread.Sleep(2000);
                    srchFilterMethods.FluentWaitCall(srchFilterPgObj.HampResult);
                    Assert.IsTrue(srchFilterMethods.FindElementAndGetText(srchFilterPgObj.HampResult).Contains("Hampshire"),
                        "No results found for this searching phrase");
                    break;
                case "building":
                    srchFilterMethods.FluentWaitCall(srchFilterPgObj.BuildCathResult);
                    srchFilterMethods.FindElementAndClick(srchFilterPgObj.BuildCathResult);
                    srchFilterMethods.FluentWaitCall(srchFilterPgObj.BuildCatFrstRes);
                    var buildTxt = srchFilterMethods.FindElementAndGetText(srchFilterPgObj.BuildCatFrstRes);
                    Debug.WriteLine("Searching phrase from building field: "+srchTxtBuild);
                    Debug.WriteLine("Result phrase from keyword field: "+buildTxt);
                    Assert.IsTrue(buildTxt.Contains("Cathedral"),"Keyword field does not contain searching phrase");
                    break;
                default:
                    break;
            }
           
        }

        [Then(@"the County and District fields should auto populate with the correct values")]
        public void ThenTheCountyAndDistrictFieldsShouldAutoPopulateWithTheCorrectValues()
        {
            srchFilterMethods.FluentWaitCall(srchFilterPgObj.AutoSelectFirstEle);
            srchFilterMethods.JsClick(srchFilterPgObj.AutoSuggestionLabelSelectorForParish);
            Assert.IsTrue(srchFilterMethods.FindElementGetValue(srchFilterPgObj.CountyInput).Equals("Devon"),
                "County input was not populate by expecting value");
            Assert.IsTrue(srchFilterMethods.FindElementGetValue(srchFilterPgObj.DistricInput).Equals("East Devon"),
                "District input was not populate by expecting value");
        }

        [When(@"I click on the District field")]
        public void WhenIClickOnTheDistrictField()
        {
            srchFilterMethods.JsClick(srchFilterPgObj.CountyInput);
            driver.FindElement(srchFilterPgObj.CountyInput).SendKeys(Keys.Escape);
            srchFilterMethods.FindElementAndClick(srchFilterPgObj.DistricInput);
            srchFilterMethods.FindElementAndEnterChars(srchFilterPgObj.DistricInput, "Eas");
            srchFilterMethods.FindElementAndClick(srchFilterPgObj.ParishInput);
            srchFilterMethods.ImplicitWaitTimeOut(20);
        }

        [Then(@"an error message is displayed")]
        public void ThenAnErrorMessageIsDisplayed()
        {
            Assert.IsTrue(srchFilterMethods.FindElementIsPresent(srchFilterPgObj.ErrorMsg),
                "Error message was not displayed");
            srchFilterMethods.FluentWaitCall(srchFilterPgObj.ErrorMsg);
            Assert.IsTrue(srchFilterMethods.FindElementAndGetText(srchFilterPgObj.ErrorMsg)
                .Equals("Please enter a valid county or unitary authority."),
                "Error message does not contain expected value");
        }
    }
}