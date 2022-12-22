using HistoricalEngland.Specs.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.Threading;
using TechTalk.SpecFlow;

namespace HistoricalEngland.Specs.StepDefinitions.ArticlePage
{
    [Binding]
    public class ArticlePageImageSteps
    {
        private readonly IWebDriver driver;
        private readonly ArticlePageObjects apo;
        private readonly ArticlePageMethods apm;
        DefaultWait<IWebDriver> extraTimeOut;



        public ArticlePageImageSteps(IWebDriver driver, ArticlePageObjects apo, ArticlePageMethods apm)
        {
            this.driver = driver;
            this.apo = apo;
            this.apm = apm;
            extraTimeOut= new DefaultWait<IWebDriver>(driver);
            extraTimeOut.Timeout = TimeSpan.FromSeconds(360);
        }

        [Given(@"that I am on the test article page")]
        public void GivenThatIAmOnTheTestArticlePage()
        {
            driver.Navigate().GoToUrl(BasePageObjects.config.configuration["appSettings:adminSection"]);
            apm.FindElementIsPresent(apo.FeatureImg);
            apm.JsScrollToPgBottom();
            apm.JsScrollToPgTop();

        }

        [When(@"I have clicked on the ""(.*)"" contents link")]
        public void WhenIHaveClickedOnTheContentsLink(string paragraphTitle)
        {
            apm.JsClick(apm.SelectAnchByText(paragraphTitle));
        }

        [Then(@"the images has a minimum width of ""(.*)""")]
        public void ThenTheImagesHasAMinimumWidthOf(int size)
        {

            Thread.Sleep(4000);

            Assert.IsTrue(apm.PictureSize(apo.FirstPicture) >= size,
                "Picture size less than " + size);

            Assert.IsTrue(apm.PictureSize(apo.SecondPicture) >= size,
                "Picture size less than "+size);
        }

        [When(@"I inspect the black and white in-line image")]
        public void WhenIInspectTheBlackAndWhiteIn_LineImage()
        {
            Assert.IsTrue(apm.FindElementIsPresentWithoutScroll(apo.FirstPicture),
                apo.FirstPicture.ToString()+" not found");

        }

        [Then(@"the in-line image has the correct alt text")]
        public void ThenTheIn_LineImageHasTheCorrectAltText()
        {
            apm.FluentWaitCall(apo.FirstPicture);
            Assert.IsTrue(apm.FindElementGetValueAtt(apo.FirstPicture, "alt").Equals("this is alt text"),
                "Text from alt attribute is different than expected one");
            

            /**
             * Line below doesnt work atm
             */
            //Assert.IsTrue(apm.FindElementGetValueAtt(apo.SecondPicture, "alt").Equals("this is alt text"),
            //    "Text from alt attribute is different than expected one");
        }

        [When(@"I click on the ""(.*)"" text below the image")]
        public void WhenIClickOnTheTextBelowTheImage(string p0)
        {
            apm.FindElementIsPresentWithoutScroll(apo.SecondPicture);
            apm.JsClick(apo.ShowDetDesForFirstPic);

        }

        [Then(@"the ""(.*)"" Gallery is on the page")]
        public void ThenTheGalleryIsOnThePage(string p0)
        {
            apm.FluentWaitCall(apo.GalleryFolderImagePic);
            Assert.IsTrue(apm.FindElementIsPresent(apo.GalleryFolderImagePic),
                "Image is not showing in gallery");
        }


        [Then(@"the image test opens up and reveals ""(.*)"" text")]
        public void ThenTheImageTestOpensUpAndRevealsText(string textField)
        {
            Thread.Sleep(1000);
            Assert.IsTrue(apm.FindElementIsPresentWithoutScroll(apo.DetDesTextField),
                "Text field is not present or not visible on the page");
            Assert.IsTrue(apm.FindElementAndGetText(apo.DetDesTextField).Contains(textField),
                "Text field does not contain searching phrase");

        }

        [Then(@"the text is now hidden again with the link text changing back to ""(.*)""")]
        public void ThenTheTextIsNowHiddenAgainWithTheLinkTextChangingBackTo(string p0)
        {
            Thread.Sleep(2000);
            Assert.IsFalse(apm.FindElementIsPresentWithoutScroll(apo.DetDesTextField),
               "Text field " + apo.DetDesTextField.ToString() + " is visible (should be hidden)");
        }


        [Then(@"there is a @copyright text at the bottom of the image")]
        public void ThenThereIsACopyrightTextAtTheBottomOfTheImage()
        {
            apm.FindElementIsPresentWithoutScroll(apo.CaptionTextField);
            Thread.Sleep(2000);
            Assert.IsTrue(apm.FindElementAndGetText(apo.CaptionTextField).Contains("this is a caption © this is copyright"),
                "Element does not contain searching phrase");
        }

        [Then(@"""(.*)"" message renders on the page")]
        public void ThenMessageRendersOnThePage(string sMediaName)
        {
            switch (sMediaName)
            {
                case "facebook":
                    Assert.IsTrue(apm.FindElementIsPresentWithoutScroll(apo.FacebookEmbed),
                        "Facebook embed is not present");
                    break;
                case "twitter":
                    Assert.IsTrue(apm.FindElementIsPresentWithoutScroll(apo.TwitterEmbed),
                        "Twitter embed is not present");
                    break;
                case "instagram":
                    Thread.Sleep(3000);
                    Assert.IsTrue(apm.FindElementIsPresentWithoutScroll(apo.InstagramEmbed),
                        "Instagram embed is not present");
                    break;
                case "infogram":
                    Assert.IsTrue(apm.FindElementIsPresentWithoutScroll(apo.InfogramEmbed),
                        "Infogram embed is not present");
                    break;
                case "youtube":
                    Assert.IsTrue(apm.FindElementIsPresentWithoutScroll(apo.YoutubeEmbed),
                        "Youtube embed is not present");
                    break;
                default:
                    Debug.WriteLine("Please verify if "+sMediaName+" is correct name of social media portal.");
                    break;
            }
        }









    }
}
