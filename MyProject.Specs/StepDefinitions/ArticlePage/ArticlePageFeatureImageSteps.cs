using HistoricalEngland.Specs.POM;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace HistoricalEngland.Specs.StepDefinitions.ArticlePage
{
    [Binding]
    class ArticlePageFeatureImageSteps
    {
        private readonly ArticlePageObjects apo;
        private readonly ArticlePageMethods apm;

        public ArticlePageFeatureImageSteps(ArticlePageObjects apo, ArticlePageMethods apm)
        {
            this.apo = apo;
            this.apm = apm;
        }

        [When(@"I click About this image button")]
        public void WhenIClickAboutThisImageButton()
        {
            apm.JsClick(apo.AboutThisImgBtn);

        }

        [Then(@"the button opens and reveals the ""(.*)"" text")]
        public void ThenTheButtonOpensAndRevealsTheText(string text)
        {
            Assert.IsTrue(apm.FindElementIsPresentWithoutScroll(apo.AboutImgBtnDesField),
              "Description field is not visible");
            Assert.IsTrue(apm.FindElementAndGetText(apo.AboutImgBtnDesField).Contains(text),
                "Element does not contain expected text");
          

        }

        [Then(@"description closes")]
        public void ThenDescriptionCloses()
        {
            Assert.IsTrue(apm.FindElementGetValueAtt(apo.AboutThisImgBtn, "aria-expanded").Equals("false"));

        }

        [When(@"I inspect the feature image")]
        public void WhenIInspectTheFeatureImage()
        {
            Assert.IsTrue(apm.FindElementIsPresentWithoutScroll(apo.FeatureImg),
                "Feature image is not present");
        }

        [Then(@"I see that it has alt attribute with text ""(.*)""")]
        public void ThenISeeThatItHasAltAttributeWithText(string attValue)
        {
            string currentAltAttValue = apm.FindElementGetValueAtt(apo.FeatureImg, "alt");
            Assert.IsTrue(currentAltAttValue.Equals(attValue),
                "Expected value is different than captured value");
        }

        [Then(@"the image has an expected width of ""(.*)""")]
        public void ThenTheImageHasAnExpectedWidthOf(int size)
        {

            Assert.IsTrue(apm.PictureSize(apo.FeatureImg) >= size,
                "Picture size less than " + size);


        }


    }
}
