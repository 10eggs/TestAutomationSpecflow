using HistoricalEngland.Specs.POM;
using HistoricalEngland.Specs.StepDefinitions.BaseSteps;
using NUnit.Framework;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace HistoricalEngland.Specs.StepDefinitions.CaseStudySearch
{
    [Binding]
    public class HeritageHighlightsSteps
    {
        private readonly HeritageHighlightsSearchPageObjects hhspo;
        private readonly HeritageHightlightsSearchMethdods hhspm;
        private readonly AssertionSteps assertions;

        //Context variables
        private string numberOfResults;
        private string category;

        public HeritageHighlightsSteps(HeritageHighlightsSearchPageObjects hhspo,HeritageHightlightsSearchMethdods hhspm, AssertionSteps assertions)
        {
            this.hhspo = hhspo;
            this.hhspm = hhspm;
            this.assertions = assertions;

        }

        [Given(@"that I am on heritage-highlights search")]
        public void GivenThatIAmOnHeritage_HighlightsSearch()
        {
            hhspm.FindElementAndClick(hhspo.ListingPage);
            hhspm.JsClick(hhspo.WhatIsListingTab);
            hhspm.FindElementAndClick(hhspo.HeritageHighlightsLink);

        }
        
        [Given(@"number of results is shown")]
        public void GivenNumberOfResultsIsShown()
        {
            numberOfResults = hhspm.FindElementAndGetText(hhspo.ResultsFoundLabel);

        }

        [Then(@"number of results was changed")]
        public void ThenNumberOfResultsWasChanged()
        {
            string numberOfResultsChanged = hhspm.FindElementAndGetText(hhspo.ResultsFoundLabel);
            Debug.WriteLine("Previous number of elements: " + numberOfResults);
            Debug.WriteLine("Number of elemnets after changing searching categories: " + numberOfResultsChanged);
            Assert.IsFalse(numberOfResults.Equals(numberOfResultsChanged), "Number of results has not been changed");
        }


        [Then(@"I can see three drop down lists with additional searching options")]
        public void ThenICanSeeThreeDropDownListsWithAdditionalSearchingOptions()
        {
            Assert.IsTrue(hhspm.FindElementIsPresent(hhspo.TypeOfDesignationDDL), "Type of designation dll not found");
            Assert.IsTrue(hhspm.FindElementIsPresent(hhspo.PeriodDDL), "Period ddl not found");
            Assert.IsTrue(hhspm.FindElementIsPresent(hhspo.RegionDDL), "Region ddl not found");
        }

        [Then(@"results was filtered by categories")]
        public void ThenResultsWasFilteredByCategories()
        {
            assertions.ResultsFilteredByCategory("Heritage Highlights", "Listed Buildings");
            assertions.ResultsFilteredByCategory("Heritage Highlights", "20th Century");
            assertions.ResultsFilteredByCategory("Heritage Highlights", "London");
        }

        [Then(@"the ""(.*)"" filter remains selected")]
        public void ThenTheFilterRemainsSelected(string searchingTerm)
        {
            hhspm.JsScrollToPgBottom();
            category = hhspm.FindElementAndGetText(hhspo.CategoryFieldInResultElement);
            Assert.IsTrue(category.Contains(searchingTerm));
        }

        [Then(@"I am taken to the correct article page with Listed, Grade, and NHLE entry fields")]
        public void ThenIAmTakenToTheCorrectArticlePageWithListedGradeAndNHLEEntryFields()
        {
            string content = hhspm.FindElementAndGetText(hhspo.InfosFieldInResultElement);
            Assert.IsTrue(content.Contains("Listed"), "Listed field was not found");
            Assert.IsTrue(content.Contains("Grade"), "Grade field was not found");
            Assert.IsTrue(content.Contains("NHLE entry"), "NHLE entry field was not found");
        }

    }
}
