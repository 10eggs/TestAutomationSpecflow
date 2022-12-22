using HistoricalEngland.Specs.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.Threading;
using TechTalk.SpecFlow;

namespace HistoricalEngland.Specs.StepDefinitions.BaseSteps
{
    [Binding]
    class NavigationMenuSteps
    {
        private readonly ArticlePageObjects apo;
        private readonly ArticlePageMethods apm;

        public NavigationMenuSteps(ArticlePageObjects apo, ArticlePageMethods apm)
        {
            this.apo = apo;
            this.apm = apm;
        }

        [StepDefinition(@"I click on the ""(.*)"" tab in the Main Menu")]
        public void IClickOnTheTabInTheMainMenu(string p0)
        {
            apm.JsClick(apo.MenuTabListing);
        }

        [StepDefinition(@"I select the ""(.*)"" link")]
        public void ISelectTheLink(string p0)
        {
            apm.JsClick(apo.MenuLevel2Listing);
        }

        [StepDefinition(@"I am taken to the ""(.*)"" page")]
        public void IAmTakenToThePage(string p0)
        {
            Thread.Sleep(1000);
            Assert.IsTrue(apm.GetCurUrl().Contains("/listing/"),
                             "Does not display the correct url");
          
        }

        [StepDefinition(@"I click on the ""(.*)"" button in the menu")]
        public void IClickOnTheButtonInTheMenu(string p0)
        {
            apm.FindElementAndClick(apo.MenuBtn);
        }

        [Then(@"I am taken to the list entry \((.*)\)")]
        public void ThenIAmTakenToTheListEntry(int p0)
        {
            Thread.Sleep(1000);
            Assert.IsTrue(apm.GetCurUrl().Contains("/listing/the-list/list-entry/1462183"),
                             "Does not display the correct url");
        }


        [StepDefinition(@"I click on the close menu button")]
        public void IClickOnTheButton()
        {
            apm.JsClick(apo.MenuCloseBtn);
            Thread.Sleep(2000);
        }

        [Then(@"the menu closes")]
        public void ThenTheMenuCloses()
        {
            Assert.IsFalse(apm._driver.FindElement(apo.MenuCloseBtn).Displayed,
                "Menu has not been closed");
        }
    }
}




