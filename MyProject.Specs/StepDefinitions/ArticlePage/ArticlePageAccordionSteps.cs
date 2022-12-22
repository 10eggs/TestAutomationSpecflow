using HistoricalEngland.Specs.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace HistoricalEngland.Specs.StepDefinitions.ArticlePage
{
    [Binding]
    public class ArticlePageAccordionSteps
    {

        private readonly ArticlePageObjects apo;
        private readonly ArticlePageMethods apm;

        public ArticlePageAccordionSteps(ArticlePageObjects apo, ArticlePageMethods apm)
        {
            this.apo = apo;
            this.apm = apm;
        }

        //ContextVariables
        public IList<IWebElement> AccordionHeaders;
        public IList<IWebElement> AccordionExpanded;
        public IList<string> AccordionHeadersChevronDownAtts;
        public IList<string> AccordionHeadersChevronUpAtts;


        [When(@"I click on accordion headings")]
        public void WhenIClickOnAccordionHeadings()
        {
            AccordionHeaders = apm.CaptureListOfElements(apo.AccordionHeaders);
            AccordionHeadersChevronDownAtts = apm.GetElementsAttribute(AccordionHeaders,"data-component");
            apm.ClickOnElements(AccordionHeaders);
        }


        [Then(@"the headings should expand to display the answer")]
        public void ThenTheHeadingsShouldExpandToDisplayTheAnswer()
        {
            AccordionExpanded = apm.CaptureListOfElements(apo.AccordionExpanded);
            Assert.IsTrue(apm.VerifyElementsExpanded(AccordionExpanded).Item1,
                "At least one element has not been expanded");
        }
        
        [Then(@"the accordion should close")]
        public void ThenTheAccordionShouldClose()
        {
            Assert.IsFalse(apm.VerifyElementsExpanded(AccordionExpanded).Item1,
                "At least one element has not been hidden");
        }
        
        [Then(@"I click on ""(.*)""")]
        public void ThenIClickOn(string accordionName)
        {
            By accordion = apm.DynamicWebElement(apo.AccordionBtn, accordionName);
            apm.JsClick(accordion);

        }
        
        [Then(@"just heritage online debate should close")]
        public void ThenJustHeritageOnlineDebateShouldClose()
        {
            Thread.Sleep(1000);
            Assert.IsTrue((apm.VerifyElementsExpanded(AccordionExpanded).Item2).Equals(2),
                "Expected number of expanded accordions are different than obtained number");
        }
        
        [Then(@"the chevron for that accordion should be pointing upwards")]
        public void ThenTheChevronForThatAccordionShouldBePointingUpwards()
        {
            AccordionHeadersChevronUpAtts= apm.GetElementsAttribute(AccordionHeaders, "data-component");
            Assert.IsFalse(AccordionHeadersChevronDownAtts.SequenceEqual(AccordionHeadersChevronUpAtts),
                "At least one chevron did not change direction");
        }
    }
}
