using HistoricalEngland.Specs.POM;
using HistoricalEngland.Specs.StepDefinitions.BaseSteps;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace HistoricalEngland.Specs.StepDefinitions.GapSearch
{
    [Binding]
    public class GapSearchSteps
    {
        private readonly GAPSearchPageMethods gapMethods;
        private readonly GapSearchPageObjects gapObj;
        private readonly InteractionsSteps ui;

        public GapSearchSteps(GAPSearchPageMethods gapMethods, GapSearchPageObjects gapObj,InteractionsSteps ui)
        {
            this.gapMethods = gapMethods;
            this.gapObj = gapObj;
            this.ui = ui;
        }


        [Given(@"that I am on the GAP Search Landing Page")]
        public void GivenThatIAmOnTheGAPSearchLandingPage()
        {
            gapMethods.JsClick(gapObj.ServicesTab);
            gapMethods.JsClick(gapObj.GrantsLink);
            gapMethods.JsClick(gapObj.VisitGapLink);

        }
        
        [Given(@"that I am on the GAP search results for ""(.*)""")]
        public void GivenThatIAmOnTheGAPSearchResultsFor(string text)
        {
            GivenThatIAmOnTheGAPSearchLandingPage();
            ui.TypeIntoTheSearchBox("rock");
            ui.ClickOnTheSearchIcon();
        }

        [Then(@"I am taken to the search results page for rock")]
        public void ThenIAmTakenToTheSearchResultsPageFor()
        {               
            Assert.IsTrue(gapMethods.FindElementIsPresent(gapObj.ResultsContainer),
                "Element has not been found");
            Assert.IsTrue(gapMethods.GetCurUrl().Contains("rock"),
                "Url query doesnt contain searching phrase");
        }
        
    }
}
