using HistoricalEngland.Specs.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace HistoricalEngland.Specs.StepDefinitions.HomePage
{
    [Binding]
    class HomePageImgGridSteps
    {
        private readonly IWebDriver driver;
        private readonly HomePageImgGridMethods hpGridMethods;
        private readonly HomePageImgGridPageObjects hpGridPageObj;
        private string HomePageUrl;


        public HomePageImgGridSteps(IWebDriver driver, HomePageImgGridMethods hpGridMethods, HomePageImgGridPageObjects hpGridPageObj)
        {
            this.driver = driver;
            this.hpGridPageObj = hpGridPageObj;
            this.hpGridMethods = hpGridMethods;
            HomePageUrl = BasePageObjects.config.configuration["appSettings:HomePageUrl"];
        }


        [Given(@"I have navigated to the Automation Testing Home Page")]
        public void GivenIHaveNavigatedToTheAutomationTestingHomePage()
        {
            driver.Navigate().GoToUrl(HomePageUrl);
            hpGridMethods.JsScrollByPixel(2500);
        }

        [When(@"I hover my mouse over one of the images on the image grid component")]
        public void WhenIHoverMyMouseOverOneOfTheImagesOnTheImageGridComponent()
        {
            hpGridMethods.HoverCheck();
        }

        [Then(@"I am presented with a blue hover state and text")]
        public void ThenIAmPresentedWithABlueHoverStateAndText()
        {
            Assert.IsTrue(hpGridMethods.FindElementIsPresent(hpGridPageObj.ImageGridImgTxt),"Expected element is not present");
            Assert.IsTrue(hpGridMethods.FindElementAndGetText(hpGridPageObj.ImageGridImgTxt)
                  .Contains("Explore the Listed Building Map"), "Expected element is not present");

            Assert.IsTrue(hpGridMethods.FindElementIsPresent(hpGridPageObj.BlueCardDisplay), "Expected element is not present");
        }

        [When(@"I click the bottom left of the image grid component with text ""(.*)""")]
        public void WhenIClickTheBottomLeftOfTheImageGridComponentWithText(string p0)
        {
			hpGridMethods.CheckImageLoaded(hpGridPageObj.ImageGridPic4);
			Assert.IsTrue(hpGridMethods.FindElementIsPresent(hpGridPageObj.ImageGridPic4),"Expected element is not present");
			hpGridMethods.JsClick(hpGridPageObj.ImageGridPic4);
			//hpGridMethods.CheckImageLoaded

		}

        [Then(@"I am taken to an image takeover with a call-to-action button text ""(.*)""")]
        public void ThenIAmTakenToAnImageTakeoverWithACall_To_ActionButtonText(string txt)
        {
            hpGridMethods.ChangeWindow();
            Assert.IsTrue(hpGridMethods.FindElementIsPresent(hpGridMethods.AnchorByTxt(txt)), "Expected element is not present");
        }


        [Then(@"I am taken to  to the enrich the list page on the website")]
        public void ThenIAmTakenToToTheEnrichTheListPageOnTheWebsite()
        {
            hpGridMethods.FindElementIsPresent(hpGridPageObj.BreadCrumbs);
            Assert.IsTrue(hpGridMethods.FindElementAndGetText(
                         hpGridPageObj.BreadCrumbs).Contains("Enrich the List"));
            Assert.IsTrue(hpGridMethods.GetCurUrl().Contains("enrich-the-list"), "URL does not contain expected phrase");
        }

        [Then(@"I am taken back to the Home page")]
        public void ThenIAmTakenBackToTheHomePage()
        {
            Assert.IsTrue(hpGridMethods.GetCurUrl().Contains(HomePageUrl),"URL does not contain expected phrase");
        }

        [When(@"I click the ""(.*)""")]
        public void WhenIClickThe(string txt)
        {
            hpGridMethods.JsClick(hpGridMethods.AnchorByTxt(txt));
        }

        [Then(@"I click the X button")]
        public void ThenIClickTheButton()
        {
            hpGridMethods.CloseNewWindow();
        }

    }
}
