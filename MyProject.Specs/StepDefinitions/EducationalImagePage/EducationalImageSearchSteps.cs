using HistoricalEngland.Specs.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using TechTalk.SpecFlow;

namespace HistoricalEngland.Specs.StepDefinitions.EducationalImagePage
{
    [Binding]
    class EducationalImageSearchSteps
    {
        private EducationalImgPageObjects eduImgPgObj;
        private EducationalImgSearchPageObjects eduImgSrchObj;
        private EducationalImgSearchMethods eduImgSrchMethod;

        public EducationalImageSearchSteps(EducationalImgPageObjects eduImgPgObj,
            EducationalImgSearchPageObjects eduImgSrchObj, EducationalImgSearchMethods eduImgSrchMethod)
        {
            this.eduImgPgObj = eduImgPgObj;
            this.eduImgSrchObj = eduImgSrchObj;
            this.eduImgSrchMethod = eduImgSrchMethod;
        }


        [Given(@"that I am on the Educational Images search page")]
        public void GivenThatIAmOnTheEducationalImagesSearchPage()
        {
            eduImgSrchMethod.FindElementAndClick(eduImgPgObj.ServiceSkillsLink);
            eduImgSrchMethod.FindElementAndClick(eduImgPgObj.EductionLink);
            eduImgSrchMethod.FindElementAndClick(eduImgSrchObj.EduImageLink);

        }

        [Then(@"the accordion opens")]
        public void ThenTheAccordionOpens()
        {
            Assert.IsTrue(eduImgSrchMethod.FindElementIsPresent(eduImgSrchObj.AccordionLink),
                "Filters are not present");

        }

        [Then(@"the accordion closes")]
        public void ThenTheAccordionCloses()
        {
            Assert.IsFalse(eduImgSrchMethod.FindElementIsPresent(eduImgSrchObj.AccordionLink,10),
                "Filters are present");

        }

        [Given(@"I am on refined results page for ""(.*)""")]
        public void GivenIAmOnRefinedResultsPageFor(string p0)
        {
            eduImgSrchMethod.FindElementIsPresent(eduImgPgObj.ResultsListBlock);
        }

        [StepDefinition(@"I am taken to the refined results page for ""(.*)"" ""(.*)""")]
        public void WhenIAmTakenToTheRefinedResultsPageFor(string searchTxt, string field)
        {

            Assert.IsTrue(eduImgSrchMethod.ExpectedResult(searchTxt, field), "Results are not fill requirements");
           
        }

        [StepDefinition(@"the page contains the tag ""(.*)""")]
        public void ThePageContainsTheTag(string searchTxt)
        {
            eduImgSrchMethod.JsScrollToPgBottom();
            var elem = eduImgSrchMethod.DynamicWebElement(eduImgSrchObj.EduTag, searchTxt);
            //Assert.IsTrue(eduImgSrchMethod.FindElementIsPresent(elem), "Where is my tag?!");

        }

    }
}

