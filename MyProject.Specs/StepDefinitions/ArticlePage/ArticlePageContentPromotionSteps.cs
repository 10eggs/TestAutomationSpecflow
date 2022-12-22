using HistoricalEngland.Specs.POM;
using NUnit.Framework;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace HistoricalEngland.Specs.StepDefinitions.ArticlePage
{
    [Binding]
    class ArticlePageContentPromotionSteps
    {
        private readonly ArticlePageObjects apo;
        private readonly ArticlePageMethods apm;

        public ArticlePageContentPromotionSteps(ArticlePageObjects apo, ArticlePageMethods apm)
        {
            this.apo = apo;
            this.apm = apm;
        }

        [When(@"I click on element with text ""(.*)""")]
        public void WhenIClickOnElementWithText(string buttonTxt)
        {
            apm.JsClick(apm.AnchorByText(buttonTxt));
        }

        [Then(@"I am redirect to ""(.*)""")]
        public void ThenIAmRedirectTo(string expectedUrl)
        {
            
            Assert.IsTrue(apm.VerifyUrlChange(expectedUrl),
                "Current url is not equal to expected url");
        }

        [Then(@"it has has descriptive alt-text")]
        public void ThenItHasHasDescriptiveAlt_Text()
        {


            Thread.Sleep(2000);

            apm.JsClick(apm.SelectAnchByText("This is a content promotion"));
            try
            {
                Thread.Sleep(2000);
                Assert.IsTrue(apm.FindElementIsPresentWithoutScroll(apo.NormansBayImg),
                    "Expected img has not been found");
                Assert.IsTrue(apm.IsAttributePresent(apo.NormansBayImg, "alt"),
                    @"There is no 'alt' attribute");
            }
            catch (Exception)
            {
                Thread.Sleep(2000);
                Assert.IsTrue(apm.FindElementIsPresentWithoutScroll(apo.NormansBayImg),
                    "Expected img has not been found");
                Assert.IsTrue(apm.IsAttributePresent(apo.NormansBayImg, "alt"),
                    @"There is no 'alt' attribute");
            }
        }
    }
}
