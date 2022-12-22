using HistoricalEngland.Specs.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using TechTalk.SpecFlow;

namespace HistoricalEngland.Specs.StepDefinitions.NHLESearch
{
    [Binding]
    public class NHLEAdvSearchSteps
    {

        private readonly NHLEAdvSearchPageMethods nhleAdvMethods;
        private readonly NHLEAdvSearchPageObjects nhleAdvObj;
        private readonly BasePageObjects basePageObjects;

        //Context variables
        public IDictionary<string, string> storeData = new Dictionary<string, string>();
        private string dropDownTxt;

        public NHLEAdvSearchSteps(NHLEAdvSearchPageObjects nhleAdvObj, NHLEAdvSearchPageMethods nhleAdvMethods, BasePageObjects basePageObjects)
        {
            this.nhleAdvObj = nhleAdvObj;
            this.nhleAdvMethods = nhleAdvMethods;
            this.basePageObjects = basePageObjects;

        }

        [Given(@"that I am on NHLE advanced search page")]
        public void GivenThatIAmOnNHLEAdvancedSearchPage()
        {
            nhleAdvMethods.JsScrollToPgBottom();
            Assert.IsTrue(nhleAdvMethods.FindElementAndGetText(nhleAdvObj.PageHeader)
                .Contains("Search the List - Advanced Search"), "Incorrect Text Displayed");

        }

        [Given(@"I have several fields filled within the advanced search form")]
        public void GivenIHaveSeveralFieldsFilledWithinTheAdvancedSearchForm()
        {
            nhleAdvMethods.FindElementAndEnterKeys(nhleAdvObj.ListNameNhle, "Manor house");
            nhleAdvMethods.FindDropdownAndSelectOption(nhleAdvObj.CountySelectNhle, "Staffordshire", "text");
            nhleAdvMethods.FindDropdownAndSelectOption(nhleAdvObj.DistrictSelectNhle, "Lichfield", "text");
            nhleAdvMethods.FindDropdownAndSelectOption(nhleAdvObj.GradeSelectNhle, "I", "text");
        }

        [Then(@"all filters are cleared")]
        public void ThenAllFiltersAreCleared()
        {
            nhleAdvMethods.ImplicitWaitTimeOut(10);
            Assert.IsTrue(nhleAdvMethods.FindElementAndGetText(nhleAdvObj.ListNameNhle).Contains(""), "Incorrect result");
            Assert.IsTrue(nhleAdvMethods.FindElementGetValue(nhleAdvObj.CountySelectNhle).Contains(""), "Incorrect result");
            Assert.IsTrue(nhleAdvMethods.FindElementGetValue(nhleAdvObj.DistrictSelectNhle).Contains(""), "Incorrect result");
            Assert.IsTrue(nhleAdvMethods.FindElementGetValue(nhleAdvObj.GradeSelectNhle).Contains(""), "Incorrect result");
        }

        [When(@"I am taken to the results page with results for listed buildings omitted")]
        public void WhenIAmTakenToTheResultsPageWithResultsForListedBuildingsOmitted()
        {
            Assert.IsTrue(nhleAdvMethods.SearchInfoRequest("Listing", nhleAdvObj.HeritageCatLink).Equals(false),
                "Wrong results detected, please verify results manually");
        }

        [When(@"I enter the text ""(.*)"" into the List Entry Name search field")]
        public void WhenIEnterTheTextIntoTheListEntryNameSearchField(string word)
        {
            Thread.Sleep(2000);
            nhleAdvMethods.FindElementAndEnterKeys(nhleAdvObj.ListNameNhle, word);
            storeData.Add("ListText", word);
        }

        [When(@"my entered variable ""(.*)"" remains in the field")]
        public void WhenMyEnteredVariableRemainsInTheField(string fieldList)
        {
            nhleAdvMethods.CheckDisplayedTxt(storeData);
        }

        [Then(@"I am taken to the advanced search results page")]
        public void ThenIAmTakenToTheAdvancedSearchResultsPage()
        {
            var txt = nhleAdvMethods.FindElementAndGetText(nhleAdvObj.ResultsByTitle);
            Assert.IsTrue(txt
                .Contains("The List - Advanced Search Results"), "Incorrect text displayed");
            Assert.IsTrue(nhleAdvMethods.FindElementIsPresent(nhleAdvObj.SrchResultArticle));
        }



        [When(@"I type in the letters ""(.*)"" into the parish field")]
        public void WhenITypeInTheLettersIntoTheParishField(string text)
        {
            nhleAdvMethods.FluentWaitCall(nhleAdvObj.ParishNhle);
            nhleAdvMethods.FindElementAndEnterChars(nhleAdvObj.ParishNhle, text);
            nhleAdvMethods.FindElementIsPresent(nhleAdvObj.DropDownEastChinNhle);
            dropDownTxt = text;
            Thread.Sleep(5000);
        }

        [Then(@"a drop-down brings me the results")]
        public void ThenADrop_DownBringsMeTheResults()
        {
            nhleAdvMethods.FindElementIsPresent(nhleAdvObj.DropDownEastChinNhle);
            nhleAdvMethods.FindElementIsPresent(nhleAdvObj.ParishDropDownNhle);
            bool result = nhleAdvMethods.SearchInfoRequest(dropDownTxt, nhleAdvObj.ParishFullListNhle);
            Assert.IsTrue(result, "String does not match");
        }

        [When(@"I enter ""(.*)"" into the ""(.*)"" ""(.*)"" field")]
        public void WhenIEnterIntoTheField(string num, string fromTo, string field)

        {
            switch (field)
            {
                case "Date Range":
                    if (fromTo.Equals("From"))
                    {
                        nhleAdvMethods.FindElementAndEnterKeys(nhleAdvObj.DateFromNhle, num);
                        storeData.Add("RangeFrom", num);
                    }
                    else
                    {
                        nhleAdvMethods.FindElementAndEnterKeys(nhleAdvObj.DateToNhle, num);
                        storeData.Add("RangeTo", num);
                    }
                    break;
                case "Designation Date":
                    if (fromTo.Equals("From"))
                    {
                        nhleAdvMethods.FindElementAndEnterKeys(nhleAdvObj.DesDateFromNhle, num);
                        storeData.Add("DesignationFrom", num);
                    }
                    else
                    {
                        nhleAdvMethods.FindElementAndEnterKeys(nhleAdvObj.DesDateToNhle, num);
                        storeData.Add("DesignationTo", num);
                    }
                    break;
                default:
                    Debug.WriteLine("No case match");
                    break;
            }
        }


        [Then(@"I am taken back to the Advanced Search Page with my previous selections still there")]
        public void IAmTakenBackToTheAdvancedSearchPageWithMyPreviousSelectionsStillThere()
        {
            Assert.IsFalse(
                nhleAdvMethods._driver.FindElement(nhleAdvMethods.DynamicWebElement(basePageObjects.TickBox, "Listed Building")).Selected,
                "Listed Building checkbox is ticked (should be unticked)");

            Assert.IsTrue(nhleAdvMethods.FindElementGetValue(nhleAdvMethods.DynamicWebElement(basePageObjects.FilterOptionDDL, "County"))
                .Equals("Cumbria"), "Selected option is not equal to the 'Cumbria'");

            //remove sleep on return from leave
            Thread.Sleep(2000);

        }

        [Then(@"the results are different")]
        public void TheResultsAreDifferent()
        {
            Assert.IsTrue(nhleAdvMethods.FindElementIsPresent(nhleAdvMethods
                .DynamicWebElement(basePageObjects.ElementContainingText, "No records matched the search criteria.")),
                "The results are different than expected (No results expected)");
        }


        [StepDefinition(@"I am taken to a search page with no filters selected")]
        public void ThenIAmTakenToASearchPageWithNoFiltersSelected()
        {
            Assert.IsTrue(
                nhleAdvMethods._driver.FindElement(nhleAdvMethods.DynamicWebElement(basePageObjects.TickBox, "Listed Building")).Selected,
                "Listed Building checkbox is unticked (should be ticked)");

            var value = nhleAdvMethods.FindElementGetValue(nhleAdvMethods.DynamicWebElement(basePageObjects.FilterOptionDDL, "County"));

            Assert.IsTrue(nhleAdvMethods.FindElementGetValue(nhleAdvMethods.DynamicWebElement(basePageObjects.FilterOptionDDL, "County"))
                .Equals(""), "Selected option is not equal to the 'Show all'");
        }

    }
}
