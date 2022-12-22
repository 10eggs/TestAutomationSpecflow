using HistoricalEngland.Specs.POM;
using HistoricalEngland.Specs.StepDefinitions.BaseSteps;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System.Threading;

namespace HistoricalEngland.Specs.StepDefinitions.PublicationSearch
{
    [Binding]
    public class PSFilteredResultsSteps
    {
        private readonly IWebDriver driver;
        private readonly PublicationSearchPageObjects pspo;
        private readonly PublicationSearchPageMethods pspm;
        private readonly InteractionsSteps uiSteps;

        public PSFilteredResultsSteps(IWebDriver driver, PublicationSearchPageObjects pspo,
            PublicationSearchPageMethods pspm, InteractionsSteps uiSteps)
        {
            this.driver = driver;
            this.pspo = pspo;
            this.pspm = pspm;
            this.uiSteps = uiSteps;
        }

        [Given(@"that I am on publications search")]
        public void GivenThatIAmOnPublicationsSearch()
        {
            pspm.JsClick(pspo.ImagesPage);
            pspm.JsClick(pspo.SearchAllPublicationsTab);
            Assert.IsTrue(pspm.FindElementIsPresent(pspo.SearchAllPublicationsHeader),"Search all publications header not found");
        }
        
        
        [Given(@"that I am on the search results for ""(.*)""")]
        public void GivenThatIAmOnTheSearchResultsFor(string searchingTerm)
        {
            Thread.Sleep(3000);
            string url = pspm.GetCurUrl() + "?searchType=Publication&search=" + searchingTerm;
            driver.Navigate().GoToUrl(url);
        }


        [Then(@"I am presented with additional field to filter my results by two checkboxes and two dropdown fields")]
        public void ThenIAmResentedWithAdditionalFieldToFilterMyResultsByTwoCheckboxesAndTwoDropdownFields()
        {
            Thread.Sleep(2000);
            //removed filters - will fully remove when RR goes live
            //Assert.IsTrue(pspm.FindElementIsPresent(pspo.DonwloadableContentBox),"Downloadable content box not found");
            //Assert.IsTrue(pspm.FindElementIsPresent(pspo.NonHEPubBox),"Non HE pub box not found");
            Assert.IsTrue(pspm.FindElementIsPresent(pspo.PublishedDDL),"Published drop down list not found");
            Assert.IsTrue(pspm.FindElementIsPresent(pspo.SeriesDDL),"Series drop down list not found");
        }


        [Given(@"that I am on the search results for ""(.*)"" and the filters are open")]
        public void GivenThatIAmOnTheSearchResultsForAndTheFiltersAreOpen(string searchingTerm)
        {
            GivenThatIAmOnTheSearchResultsFor(searchingTerm);
            //Thread.Sleep(2000);
            //uiSteps.SelectTheButton("Filter results");
            //pspm.FindElementAndClick(pspo.FilterResultsBtn);
            Thread.Sleep(2000);
            try { pspm.JsClick(pspo.PubFilterBtn); }
            catch { pspm.FindElementAndClick(pspo.FilterResultsBtn); }

        }

        [StepDefinition(@"I select the Next pagination arrow")]
        public void ISelectTheNextPaginationArrow()
        {
            pspm.WaitAndClickElement(pspo.PubPagination);
        }


        [StepDefinition(@"that I have selected the publications filter button")]
        public void ThatIHaveSelectedThePublicationsFilterButton()
        {
            //pspm.FindElementAndClick(pspo.FilterResultsBtn);
            Thread.Sleep(4000);
            //pspm.JsClick(pspo.PubFilterBtn);
            pspm.FindElementAndClick(pspo.PubFilterBtn);

        }

        [When(@"I click the Downloadable content check box")]
        public void WhenIClickTheDownloadalbeContentCheckBox()
        {
            pspm.FindElementAndClick(pspo.DonwloadableContentBox);
        }

        [When(@"select Apply filters")]
        public void WhenSelectApplyFilters()
        {
            pspm.FindElementAndClick(pspo.ApplyFiltersBtn);
        }
  
        [Given(@"that I have refined all my search for ""(.*)""")]
        public void GivenThatIHaveRefinedAllMySearch(string searchingTerm)
        {
            GivenThatIAmOnTheSearchResultsFor(searchingTerm);
        }

        
        [When(@"select ""(.*)""")]
        public void WhenSelect(string searchingTerm)
        {
            pspm.FindDropdownAndSelectOption(pspo.PublishedDDL, searchingTerm, "text");
            pspm.FindElementAndClick(pspo.ApplyFiltersBtn);
        }
        
        
        [Then(@"the page refreshes I am presented with only results that can be downloaded")]
        public void ThenThePageRefreshesIAmPresentedWithOnlyResultsThatCanBeDownloaded()
        {
            pspm.FindElementAndClick(pspo.ResultsElement);
            Assert.IsTrue(pspm.FindElementIsPresent(pspo.PdfContainer),"Pdf container not found");
        }
        
        [Then(@"the page refreshes I am presented within the specified time frame")]
        public void ThePageRefreshesIAmPresentedWithinTheSpecifiedTimeFrame()
        {
            Assert.IsTrue(pspm.FindElementIsPresent(pspo.DateOfPublication),$"{pspo.DateOfPublication} is not present");
            string dateOfPublication=pspm.FindElementGetValueAtt(pspo.DateOfPublication, "datetime");
            Assert.IsTrue(pspm.CheckDateNotOlderThan10yAgo(dateOfPublication),"Date is older than 10 years");
        }
        
        [Then(@"the page refreshes I am presented with only ""(.*)"" options")]
        public void ThenThePageRefreshesIAmPresentedWithOnlyOptions(string searchingTerm)
        {
            pspm.JsScrollToPgBottom();
            string result = pspm.FindElementAndGetText(pspo.SeriesResult);
            Assert.AreEqual(searchingTerm, result,"Category has not been changed");
        }
        
        [Then(@"the fields disappear and i only see the ""(.*)"" button")]
        public void ThenTheFieldsDisappearAndIOnlySeeTheButton(string searchingTerm)
        { 
            Assert.IsTrue(pspm.FindElementIsPresent(pspm.ButtonByText(searchingTerm)),"Button not found");
            //Assert.IsFalse(pspm.FindElementIsPresent(pspo.SearchContainer),"Search container has been found");
        }
        
        [Then(@"I am taken to that publication page")]
        public void ThenIAmTakenToThatPublicationPage()
        {
            Assert.IsTrue(pspm.FindElementIsPresent(pspo.HeaderOnResultPage),"Header on result page not found");
        }

        [StepDefinition(@"I select the filter results button")]
        public void SelectFilterResults()
        {
            Thread.Sleep(1000);
            pspm.JavaScriptScroll(pspo.FilterResultsBtn);
            pspm.WaitAndClickElement(pspo.FilterResultsBtn);
        }
    }
}
