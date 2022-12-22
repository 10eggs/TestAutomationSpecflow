using HistoricalEngland.Specs.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.Threading;
using TechTalk.SpecFlow;

namespace HistoricalEngland.Specs.StepDefinitions.SiteSearch
{
    [Binding]
    class SiteSearchSteps
    {
        private readonly SiteSearchPageObjects sspo;
        private readonly SiteSearchMethods ssm;


        //Context variables
        private string lastHeaderText;
        private string searchingInputText;
        private string headerTextEducationalImg;
        public SiteSearchSteps(SiteSearchPageObjects sspo, SiteSearchMethods ssm)
        {
            this.sspo = sspo;
            this.ssm = ssm;
        }

        [Given(@"that I am on sitesearch search")]
        public void GivenThatIAmOnSitesearchSearch()
        {
            ssm.JsClick(sspo.SearchBtn);
        }

        [Then(@"I am taken to the Site search results page for ""(.*)""")]
        public void ThenIAmTakenToTheSiteSearchResultsPageFor(string searchingTerm)
        {
            Assert.IsTrue(ssm.FindElementAndGetText(sspo.ResultHeaderTxt)
                .Contains(searchingTerm.ToUpper()),
                "Results does not contain searching term");
        }


        [When(@"click on the last result")]
        public void WhenClickOnTheLastResult()
        {
            lastHeaderText = ssm.FindElementAndGetText(sspo.LastResult);
            ssm.JsClick(sspo.LastResult);
        }

        [Then(@"I am taken to that page")]
        public void ThenIAmTakenToThatPage()
        {
            Assert.IsTrue(ssm.FindElementIsPresent(sspo.ResultPageHeader),
                "Header element is not present");

            string resultHeaderTxt = ssm.FindElementAndGetText(sspo.ResultPageHeader);
            Assert.IsTrue(lastHeaderText.Equals(resultHeaderTxt),
                $"Header texts are not equal. Required value is: {lastHeaderText}, actual value is: {resultHeaderTxt}");
        }

        [Then(@"select the browser back button")]
        public void ThenSelectTheBrowserBackButton()
        {
            ssm.ClickBrowserBack();
        }

        [Then(@"am taken back to my search results page with ""(.*)"" search term and results intact")]
        public void ThenAmTakenBackToMySearchResultsPageWithSearchTermAndResultsIntact(string searchingTerm)
        {
            string lastHeaderTxtAfterBackBrowser = ssm.FindElementAndGetText(sspo.LastResult);
            Assert.IsTrue(lastHeaderTxtAfterBackBrowser.Equals(lastHeaderText),
                "Header from last element has been changed");
            string searchingPhrase = ssm.FindElementGetValue(sspo.SearchInput);


            Debug.WriteLine("Searching phrase: " + searchingPhrase);
            Debug.WriteLine("Searching input text: " + searchingInputText);
            Assert.IsTrue(searchingPhrase.Equals(searchingTerm),
                "Text from input field has been changed");
        }

        [StepDefinition(@"only get the results for ""(.*)""")]
        public void OnlyGetTheResultsFor(string searchingPhrase)
        {
            Thread.Sleep(4000);
            //Assert.IsTrue(ssm.FindElementIsPresent(ssm.DynamicWebElement(sspo.ResultCategoryField, searchingPhrase)), "Wrong category");
            Assert.IsTrue(ssm.GetCurUrl().Contains("News"),
                         "Does not display the correct url");

        }

        [Then(@"the search comes back with results that have images")]
        public void ThenTheSearchComesBackWithResultsThatHaveImages()
        {
            ssm.JsScrollToPgTop();
            try
            {
                bool present=ssm.FindElementIsPresent(sspo.ResultImg);
                if (!present)
                {
                    Thread.Sleep(3000);
                    Assert.IsTrue(ssm.FindElementIsPresent(sspo.ResultImg), "Result has not been loaded");
                }

            }
            catch (Exception)
            {
                Thread.Sleep(5000);

                bool present = ssm.FindElementIsPresent(sspo.ResultImg);
                if (!present)
                {
                    Thread.Sleep(3000);
                    Assert.IsTrue(ssm.FindElementIsPresent(sspo.ResultImg), "Result has not been loaded");
                }
                Assert.IsTrue(ssm.FindElementIsPresent(sspo.ResultImg), "Result has not been loaded");
            }
        }

        [Then(@"I click those images")]
        public void ThenIClickThoseImages()
        {
            headerTextEducationalImg = ssm.FindElementGetValueAtt(sspo.ResultImgHyperLink, "aria-label");
            ssm.JsClick(sspo.ResultImgHyperLink);

        }

        [Then(@"the image has pulled in to the search")]
        public void ThenTheImageHasPulledInToTheSearch()
        {
            Thread.Sleep(2000);
            string headerTxt = ssm.FindElementAndGetText(sspo.ResultPageHeader);
            Assert.IsTrue(headerTxt.Equals(headerTextEducationalImg));
        }

		//[Then(@"I am taken to the search results for ""(.*)""")]
		//public void ThenIAmTakenToTheSearchResultsFor(string searchingPhrase)
		//{
		//	//ssm.VerifyElementChangeValue(sspo.ResultHeader, "text", searchingPhrase);
		//	ssm.VerifyElementChangeValue(sspo.ResultHeader, "text", searchingPhrase);
		//	Assert.IsTrue(ssm.SearchInfoRequest(searchingPhrase, sspo.ResultHeader),
		//		"At least one result element has wrong category");

		//}

		[StepDefinition(@"I am taken to the site search results for fire")]
        public void IAmTakenToTheSiteSearchResultsForFire()
        {
            //Assert.IsTrue(ssm.);
            Assert.IsTrue(ssm.FindElementIsPresent(sspo.SearchTxtFire),
      "No results present");


        }

        [StepDefinition(@"I am taken to the site search results for Little London")]
        public void IAmTakenToTheSiteSearchResultsForLittleLondon()
        {
            Assert.IsTrue(ssm.FindElementIsPresent(sspo.SearchTxtLittleLondon),
        "No results present");


        }

    }
}
