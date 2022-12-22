using HistoricalEngland.Specs.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace HistoricalEngland.Specs.StepDefinitions.ArchiveCollectionOnline
{
    [Binding]
    class SortingAndPaginationPageSteps
    {

        private SortingAndPaginationPageObjects sortPgObj;
        private readonly BaseMethods _baseMethods;

        public SortingAndPaginationPageSteps(SortingAndPaginationPageObjects sortPgObj, BaseMethods baseMethods)
        {
            this.sortPgObj = sortPgObj;
            _baseMethods = baseMethods;
        }

        [When(@"I select ""(.*)"" from the Sort by dropdown")]
        public void WhenISelectFromTheDropdown(string text)
        {
            _baseMethods.JsClick(sortPgObj.SortByLink);
            _baseMethods.FindDropdownAndSelectOption(sortPgObj.SortByLink, text, "text");
            _baseMethods.PressKey(sortPgObj.SortByLink, "Enter");
        }

        [Then(@"the order of the results is changed")]
        public void ThenTheOrderOfTheResultsIsChanged()
        {
            Assert.IsTrue(_baseMethods.FindElementIsPresent(sortPgObj.FirstResultTitle),"No results found");
            //assert on hold until nhle deployment complete
            //Assert.IsTrue(_baseMethods.FindElementIsPresent(sortPgObj.ChangeResultTitle),"Results order has not been changed");
            var result = _baseMethods.FindElementAndGetText(sortPgObj.FirstResultTitle);
            Assert.IsFalse(result.Contains("Little London Cottage"),"Results order has not been changed");
        }

    }

}
