using HistoricalEngland.Specs.POM;
using HistoricalEngland.Specs.StepDefinitions.BaseSteps;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace HistoricalEngland.Specs.StepDefinitions.CaseStudySearch
{
    [Binding]
    public class HeritagePlanningSteps
    {
        private readonly HeritageHighlightsSearchPageObjects hhspo;
        private readonly HeritageHightlightsSearchMethdods hhspm;

        //Following variables are members of ScenarioContext, and are using to Assertion steps between value from different steps

        public HeritagePlanningSteps(HeritageHighlightsSearchPageObjects hhspo, HeritageHightlightsSearchMethdods hhspm, AssertionSteps assertions)
        {
            this.hhspo = hhspo;
            this.hhspm = hhspm;

        }

        [Given(@"that I am on Heritage Planning Database search")]
        public void GivenThatIAmOnHeritagePlanningDatabasSearch()
        {
            hhspm.FindElementAndClick(hhspo.AdvicePage);
            hhspm.JsClick(hhspo.HeritageProtectionGuideTab);
            hhspm.FindElementAndClick(hhspo.HeritagePlanningTab);


        }

        [Then(@"I am taken to the correct article page with Decision, Address, and Applicant entry fields")]
        public void ThenIAmTakenToTheCorrectArticlePageWithListedDecisionAndAddressAndApplicantEntryFields()
        {
            string content = hhspm.FindElementAndGetText(hhspo.PlanningFieldInResultElement);
            Assert.IsTrue(content.Contains("Type of decision: "), "Decision field was not found");
            Assert.IsTrue(content.Contains("Address of the property: "), "Address field was not found");
            Assert.IsTrue(content.Contains("Applicant/appellant: "), "Applicant entry field was not found");
        }

        }
    }