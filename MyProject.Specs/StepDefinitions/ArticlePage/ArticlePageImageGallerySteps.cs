using HistoricalEngland.Specs.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Diagnostics;
using System.Threading;
using TechTalk.SpecFlow;

namespace HistoricalEngland.Specs.StepDefinitions.ArticlePage
{
    [Binding]
    public class ArticlePageImageGallerySteps
    {
        private readonly ArticlePageObjects apo;
        private readonly ArticlePageMethods apm;

        //Context variables
        string srcForGalleryImg;
        public ArticlePageImageGallerySteps(ArticlePageObjects apo, ArticlePageMethods apm)
        {
            this.apo = apo;
            this.apm = apm;
        }

        [When(@"I select the image")]
        public void WhenISelectTheImage()
        {
            //New Line
            apm.JsScrollToPgBottom();
            apm.FindElementAndClick(apo.GalleryImagePic);
            srcForGalleryImg = apm.FindElementGetValueAtt(apo.GalleryImage, "src");

        }

        [Then(@"the image takes you to a lightbox view of the image")]
        public void ThenTheImageTakesYouToALightboxViewOfTheImage()
        {
            apm.FluentWaitCall(apo.GalleryImage);
            Assert.IsTrue(apm.FindElementIsPresent(apo.GalleryImage),
                "Picture lightbox view is not present");
        }


        [Then(@"I am taken to the linked page")]
        public void ThenIAmTakenToTheLinkedPage()
        {
            Assert.IsTrue(apm.GetCurUrl().Contains(BasePageObjects.config.configuration["originPages:adminSection"]),
                "User has not been redirected");
        }

        [When(@"I click on the ""(.*)"" button inside lightbox view")]
        public void WhenIClickOnTheChevron(string direction)
        {
            var closeBtn = apm.DynamicWebElement(apo.ChevronBtnSelector, direction);

            Thread.Sleep(2000);
            apm.FindElementIsPresent(closeBtn);
            apm.FindElementAndClick(apm.DynamicWebElement(apo.ChevronBtnSelector, direction));
        }


        [Then(@"I am taken back to the previous image")]
        public void ThenIAmTakenBackToThePreviousImage()
        {
            Thread.Sleep(2000);
            Assert.IsTrue(srcForGalleryImg.Equals(apm.FindElementGetValueAtt(apo.GalleryImage, "src")),
                "Image has not been changed");
        }

        [Then(@"I am taken to the next image in the gallery")]
        public void ThenIAmTakenToTheNextImageInTheGallery()
        {
            Thread.Sleep(5000);

            string val = apm.FindElementGetValueAtt(apo.GalleryImage, "src");
            if(val.Equals("") || val.Equals(srcForGalleryImg))
            {
                Thread.Sleep(4000);
                val = apm.FindElementGetValueAtt(apo.GalleryImage, "src");
            }

            Assert.IsFalse(srcForGalleryImg.Equals(val),
                "Image has not been changed or src attribute value is different than expected.");
        }

        [Then(@"the lightbox closes and i am taken back to the images")]
        public void ThenTheLightboxClosesAndIAmTakenBackToTheImages()
        {
            Thread.Sleep(3000);
            apm.JsScrollToPgBottom();
            Assert.IsFalse(apm.FindElementIsPresent(apo.GalleryImage),
                "Lightbox view is still present");
        }

        [Then(@"the ""(.*)"" link is present")]
        public void TheLinkIsPresent(string phrase)
        {
            Assert.IsTrue(apm.FindElementIsPresent(apm.AnchorByText(phrase)),
                "Link is not present on the page");
        }



    }
}
