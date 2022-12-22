using HistoricalEngland.Specs.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using SeleniumExtras.WaitHelpers;

namespace HistoricalEngland.Specs.StepDefinitions.BaseSteps
{
    [Binding]
    //AssertionStep 
    public class AssertionSteps
    {
        BasePageObjects baseObject;
        BaseMethods baseMethod;

        public AssertionSteps(BaseMethods baseMethod, BasePageObjects baseObject)
        {
            this.baseObject = baseObject;
            this.baseMethod = baseMethod;
        }



        [StepDefinition(@"I am taken to the ""(.*)"" refined results page for ""(.*)""")]
        public void ThenIAmTakenToTheRefinedResultsPage(string sectionName, string searchingPhrase)
        {
            var capturedText = baseMethod.FindElementAndGetText(baseObject.PageHeader);
            if (capturedText == "")
            {
                Thread.Sleep(3000);
                capturedText = baseMethod.FindElementAndGetText(baseObject.PageHeader);
            }
            try
            {
                Assert.IsTrue(capturedText.Contains(sectionName),
                    $"Header does not contain expected text. Expected name is: {sectionName}, actual text: {capturedText}");
            }
            catch (Exception)
            {
                baseMethod.JsScrollToPgBottom();
                Assert.IsTrue(capturedText.Contains(sectionName),
                    $"Header does not contain expected text. Expected name is: {sectionName}, actual text: {capturedText}");
            }

            try
            {
                Assert.IsTrue(baseMethod.FindElementIsPresent(baseMethod.DynamicWebElement(baseObject.ResultsElementTitle, searchingPhrase)),
                ("Element is not present."));
            }
            catch (Exception e)
            {
                Thread.Sleep(3000);
                Assert.IsTrue(baseMethod.FindElementIsPresent(baseMethod.DynamicWebElement(baseObject.ResultsElementTitle, searchingPhrase)),
                ("Element is not present."));
            }

        }

        [StepDefinition(@"I am taken to the ""(.*)"" results filtered by ""(.*)"" category")]
        public void ResultsFilteredByCategory(string sectionName, string filterCategory)
        {
            try
            {
                Assert.IsTrue(baseMethod.FindElementIsPresent(baseObject.ResultsElement),
                    "No results present");
            }
            catch (Exception)
            {
                Thread.Sleep(3000);
                Assert.IsTrue(baseMethod.FindElementIsPresent(baseObject.ResultsElement),
                    "No results present");
            }

            try
            {
                string expectedText = baseMethod.FindElementAndGetText(baseObject.PageHeader);

                if (expectedText == "" || !expectedText.Contains(sectionName))
                {
                    Thread.Sleep(3000);
                    expectedText = baseMethod.FindElementAndGetText(baseObject.PageHeader);
                }
                Assert.IsTrue(expectedText.Contains(sectionName),
                    "Header does not contain expected text");
            }
            catch (Exception)
            {
                Thread.Sleep(3000);
                Assert.IsTrue(baseMethod.FindElementAndGetText(baseObject.PageHeader)
                    .Contains(sectionName),
                    "Header does not contain expected text");
            }

            try
            {
                Assert.IsTrue(baseMethod.FindElementIsPresent(baseMethod.DynamicWebElement(baseObject.ResultsFilteredElement, filterCategory)),
                    "Element has not be filtered by category");
            }

            catch (Exception)
            {
                Thread.Sleep(3000);
                Assert.IsTrue(baseMethod.FindElementIsPresent(baseMethod.DynamicWebElement(baseObject.ResultsFilteredElement, filterCategory)),
                    "Element has not be filtered by category");
            }
        }

        [StepDefinition(@"I wait for ""(.*)"" seconds")]
        public void IWaitForSeconds(string seconds)
        {
            string milliseconds = seconds + "000";
            int sleep = int.Parse(milliseconds);
            Thread.Sleep(sleep);
        }


        [StepDefinition(@"I am taken to the next page of results")]
        public void TheNextPageOfResults()
        {
            string pageNumber = baseMethod.FindElementGetValueAtt(baseObject.PageNumberSpan, "placeholder");
            Assert.AreEqual(pageNumber, "2",
                "You've not been redirected to next page");
        }

        [StepDefinition(@"I am taken back to the previous page of results")]
        public void ThenIAmTakenBackToThePreviousPageOfResults()
        {
            string pageNumber = baseMethod.FindElementGetValueAtt(baseObject.PageNumberSpan, "placeholder");
            Assert.AreEqual(pageNumber, "1", "Wrong page number");
        }

        [StepDefinition(@"I am taken to page ""(.*)"" of the results")]
        public void ThenIAmTakenToPageOfTheResults(string pageNumber)
        {
            baseMethod.JsScrollToPgBottom();
            baseMethod.FluentWaitCall(baseMethod.DynamicWebElement(baseObject.PageNumberInputSelector, pageNumber));
            string pageNumberCaptured = baseMethod.FindElementGetValueAtt(baseObject.PageNumberInput, "placeholder");
            Assert.AreEqual(pageNumberCaptured, pageNumber, "Wrong page number");
        }


        [StepDefinition(@"""(.*)"" element is present")]
        public void ElementIsPresent(string elemName)
        {
            Assert.IsTrue(baseMethod.FindElementIsPresent(baseMethod.DynamicWebElement(baseObject.ElementByText, elemName)),
                "Element not found");
        }

        [StepDefinition(@"Element with text ""(.*)"" is present")]
        public void ElementWithTextIsPresent(string elemName)
        {
            Assert.IsTrue(baseMethod.FindElementIsPresent(baseMethod.DynamicWebElement(baseObject.ElementContainingText, elemName)),
                "Element not found");
        }


        [StepDefinition(@"I am taken to the correct page with the entry showing")]
        public void IAmTakenToTheCorrectPageWithTheEntryShowing()
        {
            Assert.IsTrue(baseMethod.GetCurUrl().Contains("cragside-rothbury-ne65-7px"),
               "Url query doesnt contain searching phrase");
        }

        [StepDefinition(@"I am taken to the correct URL ""([^""]*)"" with the entry title ""([^""]*)"" showing")]
        public void IAmTakenToTheCorrectURLWithTheEntryPageShowing(string URLtxt, string TitleTxt)
        {
            Assert.IsTrue(baseMethod.GetCurUrl().Contains(URLtxt),
               "Url query doesnt contain searching phrase");
            Assert.IsTrue(baseMethod.FindElementIsPresent(baseMethod.DynamicWebElement(baseObject.GenPageTitle, TitleTxt)),
                "Element not found");
        }

        //NHLE redesign Step
        [StepDefinition(@"the List Entry Sign in Link is present")]
        public void ThenTheListEntrySignInLinkIsPresent()
        {
            Thread.Sleep(2000);
            Assert.IsTrue(baseMethod.FindElementIsPresent(baseObject.SignInLink),
                    "Element not found");

        }

        //Moved from HerriftagePassportSignInSteps as used in UGC as well
        [StepDefinition(@"I am redirected to the Sign in page")]
        public void ThenIAmRedirectToSignInPage()
        {
            Assert.IsTrue(baseMethod.FindElementAndGetText(baseObject.PageHeader).Contains("Sign in / Register"),
                "Redirected to wrong page");
        }

        [StepDefinition(@"the image has the Alt Text ""(.*)""")]
        public void TheImageHasTheAltText(string AltText)
        {
            Assert.IsTrue(baseMethod.FindElementIsPresent(baseMethod.DynamicWebElement(baseObject.AltTextObj, AltText)),
          "Header does not contain expected text");
        }

        //Moved from HerriftagePassportSignInSteps as used in UGC as well
        [StepDefinition(@"I am logged in")]
        public void ThenIAmLoggedIn()
        {
            Thread.Sleep(2000);
            Assert.IsTrue(baseMethod.FindElementIsPresent(baseMethod.AnchorByText("My account")),
                "My account btn is not visible");
        }

        //Moved from HerriftagePassportSignInSteps as used in UGC as well
        [StepDefinition(@"I get a drop down saying ""(.*)"" or ""(.*)""")]
        public void ThenIGetADropDownSayingOr(string firstLabel, string secLabel)
        {
            Assert.IsTrue(baseMethod.FindElementIsPresent(baseMethod.DynamicWebElement(baseObject.MyAccountDropDownLabels, firstLabel)),
                firstLabel + " element is not present");

            Assert.IsTrue(baseMethod.FindElementIsPresent(baseMethod.DynamicWebElement(baseObject.MyAccountDropDownLabels, secLabel)),
                secLabel + " element is not present");
        }

        //Moved from HerriftagePassportSignInSteps as used in UGC as well
        [StepDefinition(@"I am logged out")]
        public void ThenIAmLoggedOut()
        {
            Thread.Sleep(2000);
            Assert.IsTrue(baseMethod.FindElementIsPresent(baseMethod.AnchorByText("Sign in")),
                "My account btn is not visible");
        }

    }
}

