using AventStack.ExtentReports.Gherkin.Model;
using HistoricalEngland.Specs.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace HistoricalEngland.Specs.StepDefinitions.HARSearch
{
    [Binding]
    public sealed class HARAdvanceSearchSteps
    {
        private HARSearchPageMethods harMethod;
        private HARSearchPageObjects harObj;
        private HARAdvSearchPageObjects harAdvObj;
        private HARAdvSearchPageMethods harAdvMethod;
        //private List<string> searchTextTerm = new List<string>();
        public HARAdvanceSearchSteps(HARSearchPageMethods harMethod, HARAdvSearchPageMethods harAdvMethod,
            HARSearchPageObjects harObj, HARAdvSearchPageObjects harAdvObj )
        {
            this.harMethod = harMethod;
            this.harAdvMethod = harAdvMethod;
            this.harObj = harObj;
            this.harAdvObj = harAdvObj;
        }


        [When(@"I type ""(.*)"" into the input search box")]
        public void WhenITypeIntoTheInputSearchBox(string searchString)
        {
            harAdvMethod.PressKey(harAdvObj.SearchInputHarAdv, "Delete");
            harAdvMethod.FindElementAndEnterKeys(harAdvObj.SearchInputHarAdv, searchString);
        }

        [Given(@"that I am on the HAR advanced search form")]
        public void GivenThatIAmOnTheHARAdvancedSearchForm()
        {
            Assert.IsTrue(harAdvMethod.FindElementAndGetText(harObj.PageHeader)
                  .Contains("More Search Options"), "Does not display the right result");
        }

        [Then(@"I click on the ""(.*)"" button for refined results")]
        public void WhenIClickOnTheButtonForRefinedResults(string text)
        {
            harAdvMethod.JsClick(harAdvMethod.ButtonByText(text));
        }

        [Then(@"HAR results are refined by ""(.*)""")]
        public void ThenHarResultsAreRefinedBy(string criteria)
        {
            Assert.IsTrue(harMethod.RefineCriteriaPresent(criteria),
                "Expected criteria are not present");
        }

        [Then(@"the form generates ""(.*)""")]
        public void ThenTheFormGenerates(string listOfField)
        {
            harAdvMethod.CheckExtraDropDownListsPresent(listOfField);
        }

        [When(@"I click on More Location Options button")]
        public void WhenIClickOnMoreLocationOptionsButton()
        {
            harAdvMethod.JsClick(harAdvObj.MoreLocButton);
        }
    }
}
