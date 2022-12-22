using TechTalk.SpecFlow;
using NUnit.Framework;
using HistoricalEngland.Specs.POM;
using OpenQA.Selenium;
using System.Threading;

namespace HistoricalEngland.Specs.StepDefinitions.NHLESearch
{
    [Binding]
    public class NHLEQuickSearchSteps
    {
        private readonly BasePageObjects obj;
        private readonly NHLESearchPageMethods nhleMethods;
        private readonly NHLESearchPageObjects nhleObj;

        //Context variables
        private string _numberOfRecords { get; set; }

        public NHLEQuickSearchSteps(BasePageObjects obj, NHLESearchPageMethods nhleMethods, NHLESearchPageObjects nhleObj)
        {
            this.obj = obj;
            this.nhleMethods = nhleMethods;
            this.nhleObj = nhleObj;
        }

        [StepDefinition(@"I am taken to the NHLE search results for ""(.*)""")]
        public void TakenToTheNHLESearchResultsFor(string searchingTerm)
        {
            Assert.IsTrue(nhleMethods.FindElementAndGetText(nhleObj.FilteredResults)
                .ToLower()
                .Contains(searchingTerm),
                "Result header does not contain searching term"); ;
        }

        
        [StepDefinition(@"I am taken to the search NHLE results page")]
        public void ThenIAmTakenToTheSearchNHLEResultsPage()
        {
            nhleMethods.JsClick(nhleObj.SearchTheSiteBtn);
        }


        [Given(@"I select the Advanced Search button")]
        public void GivenISelectTheAdvancedSearchButton()
        {
            nhleMethods.JsClick(nhleObj.AdvancedSearchBtn);
        }

        [Given(@"that I am on the NHLE list search landing page")]
        public void GivenThatIAmOnTheNHLEListSearchLandingPage()
        {
            nhleMethods.FindElementAndClick(nhleObj.ListingPage);
            nhleMethods.FindElementAndClick(nhleObj.SearchTheListLink);
            Assert.IsTrue(nhleMethods.FindElementIsPresent(nhleObj.SearchTheListHeader),"Search list header not found");
            Assert.IsTrue(nhleMethods.FindElementIsPresent(obj.SearchInput),"Search input not found");
        }

        [Given(@"that I have searched for ""(.*)"" on the NHLE listing search")]
        public void GivenThatIHaveSearchedForOnTheNHLEListingSearch(string val)
        {
            nhleMethods.FindElementAndClick(nhleObj.ListingPage);
            nhleMethods.FindElementAndClick(nhleObj.SearchTheListLink);
            nhleMethods.FindElementAndEnterKeys(obj.SearchInput, val);
            nhleMethods.FindElementAndClick(obj.QuickSearchBtn);
        }

        [Given(@"I am on the results page")]
        public void GivenIAmOnTheResultsPage()
        {
            Assert.IsTrue(nhleMethods.FindElementIsPresent(nhleObj.ResultsReturned),
                "No results found");
            string text = nhleMethods.FindElementAndGetText(obj.PageHeader);
            _numberOfRecords = text.Substring(0, text.IndexOf(" "));

        }

        [Then(@"a series of filters are shown")]
        public void ThenASeriesOfFiltersAreShown()
        {
            Thread.Sleep(2000);
            Assert.IsTrue(nhleMethods.FindElementIsPresent(nhleObj.CountyDistrictDropdown),
                "County district dropdown list is not present");
            Assert.IsTrue(nhleMethods.FindElementIsPresent(nhleObj.ParishDropDown),
                "Parish dropdown list is not present");
            Assert.IsTrue(nhleMethods.FindElementIsPresent(nhleMethods.ButtonByText("Apply filters")),
                "Apply filters btn is not present");
            Assert.IsTrue(nhleMethods.FindElementIsPresent(nhleMethods.ButtonByText("Clear filters")),
                "Clear filters btn is not present");
        }

        [Then(@"I am the results page with the filtered results for ""(.*)""")]
        public void ThenIAmTheResultsPageWithTheFilteredResultsFor(string filter)
        {
            Assert.IsTrue(nhleMethods.FindElementIsPresent(nhleMethods.DynamicWebElement(nhleObj.FilteredResultsDescriptionField, filter)),
                "Description for results is not related with filter type");
            Assert.AreNotEqual(_numberOfRecords, nhleMethods.ReturnNHLEFilteredSearch(),
                "Number of results has not been changed after filtered");

        }


        [When(@"I click on results per page drop down and I select ""(.*)""")]
        public void WhenIClickOnResultsPerPageDropDownAndISelect(string var)
        {
            nhleMethods.FindDropdownAndSelectOption(nhleObj.ResultsperPageDropDown, var, "text");
            nhleMethods.ImplicitWaitTimeOut(20);
        }

        [Then(@"the page now shows ""(.*)"" results")]
        public void ThenThePageNowShowsResultsInsteadOf(int newNum)
        {
            Assert.AreEqual(newNum, nhleMethods.ResultsPerPage(),
                "Amount of element present on page is different than expected amount");
        }


        [Given(@"that I have searched for the term ""(.*)""")]
        public void GivenThatIHaveSearchedForTheTerm(string val)
        {
            nhleMethods.FindElementAndClick(nhleObj.ListingTab);
            nhleMethods.FindElementAndClick(nhleObj.SearchTheListLink);
            nhleMethods.FindElementAndEnterKeys(obj.SearchInput, val);
            nhleMethods.FindElementAndClick(obj.QuickSearchBtn);
        }

        [When(@"I am taken to the results page")]
        public void WhenIAmTakenToTheResultsPage()
        {
            Assert.IsTrue(nhleMethods.FindElementIsPresent(nhleObj.ResultsReturned),
             "No results found");
        }

        [When(@"I click on the list entry ""(.*)""")]
        public void WhenIClickOnTheListEntry(string p0)
        {
            var ele = nhleObj.GetEleWithTitle("Durham Castle and Cathedral");
            nhleMethods.JsClick(ele);


        }


        [Then(@"the Image of England is showing on the page")]
        public void ThenTheImageOfEnglandIsShowingOnThePage()
        {
            Assert.IsTrue(nhleMethods.FindElementIsPresent(nhleObj.ImageOfEnglandContainer),
             "Image of England not found");
        }


        [Then(@"I am taken to the list entry ""(.*)""")]
        public void ThenIAmTakenToTheListEntry(string p0)
        {
            var ele = nhleObj.GetRecord("Durham Castle and Cathedral");
            Assert.IsTrue(nhleMethods.FindElementIsPresent(ele),
              "Element has not been found");
            
        }

        [StepDefinition(@"I download file ""(.*)""")]
        public void WhenIDownloadFile(string NHLEfileName)
        {
            Assert.IsTrue(nhleMethods.FileDownload(NHLEfileName), "File not found");
        }


        //NHLE Redesign Steps

        [StepDefinition(@"I select the comments tab")]
        public void ISelectTheCommentsTab()
        {
            nhleMethods.JsClick(nhleObj.CommentsTab);
            Assert.IsTrue(nhleMethods.FindElementIsPresent(nhleObj.CommentsTitle),
            "Tab title not found");
        }

        [StepDefinition(@"I select the Official Listing tab")]
        public void ISelectTheOfficialListingTab()
        {
            nhleMethods.JsClick(nhleObj.OfficalTab);
            Assert.IsTrue(nhleMethods.FindElementIsPresent(nhleObj.OfficialTitle),
            "Tab title not found");
        }

        [StepDefinition(@"I select the Overview Tab")]
        public void ISelectTheOverviewTab()
        {
            nhleMethods.JsClick(nhleObj.OverviewTab);
            Assert.IsTrue(nhleMethods.FindElementIsPresent(nhleObj.OverviewTitle),
            "Tab title not found");
        }


    }
}



