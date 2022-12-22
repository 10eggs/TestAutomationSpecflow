using HistoricalEngland.Specs.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace HistoricalEngland.Specs.StepDefinitions
{
    [Binding]
    class HARQuickSearchSteps
    {
        private HARSearchPageObjects harObj = new HARSearchPageObjects();
        private HARSearchPageMethods harMethods;

        //Context vars
        private IList<string> searchInputText = new List<string>();
        private String searchResultText;
        private String expectedHeading;
        private String resultHeading;
        private bool flag = false;


        public HARQuickSearchSteps(HARSearchPageMethods harMethods, HARSearchPageObjects harObj)
        {
            this.harMethods = harMethods;
            this.harObj = harObj;
        }

        [Given(@"that I am on the HAR search landing page")]
        public void GivenThatIAmOnTheHARSearchLandingPage()
        {
            harMethods.JsClick(harObj.AdviceTab);
            harMethods.JsClick(harObj.HARLink);
            harMethods.JsClick(harObj.SearchHARRegLink);
            Assert.IsTrue(harMethods.FindElementIsPresent(harObj.HARTitle),
                "Does not display the correct title");


        }

        [Then(@"I click on one of the search results images")]
        public void ThenIClickOnOneOfTheSearchResultsImages()
        {
            searchResultText = harMethods.FindElementAndGetText(harObj.SearchResultText);
            resultHeading = harMethods.FindElementAndGetText(harObj.PageHeader);
            harMethods.FindElementAndClick(harObj.SearchResult);
        }

        [Then(@"I am taken to that result page with expected header")]
        public void ThenIAmTakenToThatResultPage()
        {

            //remove sleep when back from holidau
            Thread.Sleep(2000);
            expectedHeading = harMethods.FindElementAndGetText(harObj.PageHeader);
            Assert.IsTrue(harMethods.GetCurUrl().Contains("/advice/heritage-at-risk/search-register/list-entry/"),
                         "Does not display the correct url");
            Assert.IsTrue(expectedHeading.Contains(searchResultText), expectedHeading 
                         + "does not contain  " + searchResultText);
        }
        

        [Then(@"I am taken to the results page with my search term results")]
        public void WhenIAmTakenToTheResultsPageWithMySearchTermResults()
        {
            Assert.IsTrue(harMethods.FindElementAndGetText(
                          harObj.HeadingResultPg).Contains(
                          resultHeading), "Does not contain the correct title");
        }

        [Then(@"I click download file ""([a-zA-Z]*\.[Cc][Ss][Vv])""")]
        public void ThenIClickDownloadFileTo(String fileName)
        {
            Assert.IsTrue(harMethods.FileDownload(fileName), "File not found");
        }

        [Then(@"search term ""(.*)"" is carried to the field a the top of the search")]
        public void ThenSearchTermIsCarriedToTheFieldATheTopOfTheSearch(string srchtext)
        {
            string inputTerm1 = harMethods.FindElementGetValue(harObj.InputSearchTxt);
            searchInputText.Add(inputTerm1);
            Assert.IsTrue(inputTerm1.Contains(srchtext), "Does not contain right search text");
        }

        [When(@"click on the search icon")]
        public void WhenClickOnTheSearchIcon()
        {
            harMethods.JsClick(harObj.QuickSearchBtn);
        }

        [Then(@"I am taken to the more search page")]
        public void ThenIAmTakenToTheMoreSearchPage()
        {
            Assert.IsTrue(harMethods.FindElementAndGetText(harObj.PageHeader)
                         .Contains("More Search Options"), "Does not display the right result");
        }

        [When(@"I am taken to the search results page with refined results")]
        public void WhenIAmTakenToTheSearchResultsPageWithRefinedResults()
        {
            Assert.IsTrue(harMethods.FindElementIsPresent(harObj.RefinedCriteriaLabel),
                "Search info is not present");
            flag = harMethods.CheckSearchInfo(searchInputText);
            Assert.IsTrue(flag, "Search term does not match");
        }


        [When(@"hit the enter key on my keyboard")]
        public void WhenHitTheEnterKeyOnMyKeyboard()
        {
            harMethods.PressKey(harObj.SearchInput, "Enter");
        }

        [Then(@"pictures are load")]
        public void ThenPicturesAreLoad()
        {
            Assert.IsTrue(harMethods.CheckImageLoadedByLazyLoading(harObj.ResultImg, 10),
                "Images has not been loaded");
        }

        [Then(@"result for HAR element is present")]
        public void ResultForHARElementIsPresent()
        {
            Assert.IsTrue(harMethods.FindElementIsPresent(harObj.HarResultElement),
            "Element not found");

        }


    }
}
