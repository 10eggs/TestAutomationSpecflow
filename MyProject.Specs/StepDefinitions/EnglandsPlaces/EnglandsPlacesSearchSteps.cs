using HistoricalEngland.Specs.POM;
using HistoricalEngland.Specs.StepDefinitions.BaseSteps;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using TechTalk.SpecFlow;

namespace HistoricalEngland.Specs.StepDefinitions.EnglandsPlaces
{
    [Binding]
    public class EnglandsPlacesSearchSteps
    {
        private readonly IWebDriver driver;
        private readonly InteractionsSteps ui;
        private readonly EnglandsPlacesSearchObjects epso;
        private readonly EnglandsPlacesSearchObjectsMethods epsom;
        public EnglandsPlacesSearchSteps(IWebDriver driver, InteractionsSteps ui,
            EnglandsPlacesSearchObjects epso,EnglandsPlacesSearchObjectsMethods epsom)
        {
            this.driver = driver;
            this.ui = ui;
            this.epso = epso;
            this.epsom = epsom;
        }



        [Given(@"that I am on Englands places page")]
        public void GivenThatIamOnEnglandsPlacesPage()
        {
            epsom.JsClick(epso.ImagesTab);
            epsom.JavaScriptScroll(epso.EnglandsPlaces);
            epsom.JsClick(epso.EnglandsPlaces);
            Assert.IsTrue(epsom.FindElementIsPresent(epso.EnglandsPlacesHeader),
                "England's places header is not present.");
        }

        [Given(@"that I am on the Englands Places search Landing page")]
        public void GivenThatIAmOnTheEnglandsPlacesSearchLandingPage()
        {
            Assert.IsTrue(epsom.FindElementIsPresent(epso.EPTitle),
               "Does not display the correct title");

        }

        [Given(@"that I am on the EP search results for ""(.*)""")]
        public void GivenThatIAmOnTheEPSearchResultsFor(string searchingTerm)
        {
            ui.TypeIntoTheSearchBox("Swindon");
            ui.ClickOnTheSearchIcon();
            ui.SelectFromTheResultsPage("Swindon, Swindon");

        }

        [Given(@"that I am on gallery page for Swindon - Lydiard Park")]
        public void GivenThatIAmOnGalleryPageForSwindon_LydiardPark()
        {
            string galleryPath = "gallery/12448?place=Swindon%2c+Swindon+(Place)&terms=Swindon&searchtype=englandsplaces&i=2&wm=1&bc=2|8|9";
            string curUrl = epsom.GetCurUrl();
            driver.Navigate().GoToUrl(curUrl + galleryPath);
        }

        [When(@"I enter the term ""(.*)"" in to the search")]
        public void WhenIEnterTheTermInToTheSearch(string searchingTerm)
        {
            epsom.FindElementAndEnterKeys(epso.SearchBox, searchingTerm);
            epsom.JsClick(epso.SearchBtn);
        }

        [When(@"series of ""(.*)"" options generate below the search box")]
        public void WhenSeriesOfOptionsGenerateBelowTheSearchBox(string searchingTerm)
        {
            Assert.IsTrue(epsom.FindElementIsPresent(
                epsom.DynamicWebElement(epso.SearchingRecordSelector,searchingTerm)),searchingTerm+" dont exist in results");
        }

        [When(@"I select the down-pointing chevron to the right of the ""(.*)"" result")]
        public void SelectTheDownPointingChevron(string searchingTerm)
        {
           epsom.JsClick(epsom.DynamicWebElement(epso.DPArrBtn, searchingTerm));
       
        }

        [When(@"the drop-down shows ""(.*)"" with the ""(.*)"" button")]
        public void WhenTheDrop_DownShowsWithTheButton(string searchingTerm, string secSearchingTerm)
        {
            Assert.IsTrue(epsom.FindElementIsPresent(epsom.DynamicWebElement(epso.ResultsInnerLastLevelHeader, searchingTerm)),"No header found");
            Assert.IsTrue(epsom.FindElementIsPresent(epsom.DynamicWebElement(epso.OpenBoxBtnSelector, secSearchingTerm)),"No open box btn found");
        }


        [StepDefinition(@"click on the image at the very bottom")]
        public void WhenClickOnTheImageAtTheVeryBottom()
        {
            //Thread.Sleep(4000);
            epsom.FindElementAndClick(epso.LastGalleryObject);
        }

        [Then(@"select ""(.*)"" from the options presented")]
        public void ThenSelectFromTheOptionsPresented(string searchingTerm)
        {
            Assert.IsTrue(epsom.FindElementIsPresent(
                epsom.DynamicWebElement(epso.SearchingExactRecordSelector, searchingTerm)),
                searchingTerm + " dont exist in results");
            epsom.JsClick(epsom.DynamicWebElement(epso.SearchingExactRecordSelector, searchingTerm));
        }

        [Then(@"I am taken to a results page with the search box at the top")]
        public void ThenIAmTakenToAResultsPageWithTheSearchBoxAtTheTop()
        {
            Assert.IsTrue(epsom.FindElementIsPresent(epso.SearchBox),"SearchBox element not found");
            Assert.IsTrue(epsom.FindElementIsPresent(epso.ResultsRecords),"Result record element not found");
        }

        [Then(@"accordion opens and there are more search results shown below")]
        public void ThenAccordionOpensAndThereAreMoreSearchResultsShownBelow()
        {
            Assert.IsTrue(epsom.FindElementIsPresent(epso.ResultsInnerElements),"Results not found");
        }

        [Then(@"I am taken a gallery page")]
        public void ThenIAmTakenAGalleryPage()
        {
            Assert.IsTrue(epsom.FindElementIsPresent(epso.GalleryHeader),"Header not found");

        }

        [Then(@"I am taken to the card detail page for that item")]
        public void ThenIAmTakenToTheCardDetailPageForThatItem()
        {
            Assert.IsTrue(epsom.FindElementIsPresent(epso.CardDetailHeader),"Header not found");

        }
    }
}
