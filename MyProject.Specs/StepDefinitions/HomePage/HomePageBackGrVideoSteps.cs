using HistoricalEngland.Specs.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace HistoricalEngland.Specs.StepDefinitions.HomePage
{
    [Binding]
    class HomePageBackGrVideoSteps
    {
        private HomePgBackGrVideoPageObjects homePgObj;
        private HomePgBackGrVideoMethods homePgMethod;

        public HomePageBackGrVideoSteps(HomePgBackGrVideoPageObjects homePgObj, HomePgBackGrVideoMethods homePgMethod) 
        {
            this.homePgMethod = homePgMethod;
            this.homePgObj = homePgObj;
        }

        [Then(@"a youtube embedded video is playing in the background video test")]
        public void ThenAYoutubeEmbeddedVideoIsPlayingInTheBackgroundVideoTest()
        {
            String txt = homePgMethod.FindElementGetValueAtt(homePgObj.BackGrdVideo, "src");
            Assert.IsTrue(txt.Contains("https://www.youtube.com/embed/EP7jJu4lYrI?"),"URL does not contain searching url");
            //Assert.IsTrue(txt.Contains("https://www.youtube-nocookie.com/embed/EP7jJu4lYrI?modestbranding=1&autoplay=1&mute=1&loop=1controls=0"), "URL does not contain searching url");

        }

        [When(@"I click on the button called ""(.*)""")]
        public void WhenIClickOnTheButtonCalled(string text)
        {
            homePgMethod.JsClick(homePgMethod.AnchorByText(text));

        }

        [Then(@"I am taken to the advice HE page")]
        public void ThenIAmTakenToTheHEPage()
        {
            String Url = homePgMethod.GetCurUrl();
            Assert.IsTrue(Url.Contains("advice"),"Url does not contain searching phrase");
        }

        [When(@"I scroll down the page to where it says Video Test")]
        public void WhenIScrollDownThePageToWhereItSays()
        {
            homePgMethod.FindElementIsPresent(homePgObj.VideoTest);
        }

        [Then(@"I can see the play button")]
        public void ThenICanSeeThePlayButton()
        {
            homePgMethod.FindElementIsPresent(homePgObj.VideoPre);
            String val = homePgMethod.FindElementGetValueAttNoJs(homePgObj.VideoPre,"src");
            homePgMethod.FindElementIsPresent(homePgObj.PlayButton);
            Assert.IsTrue(val.Contains("https://www.youtube.com/embed/VitNe-AVBao?"), "Incorrect url");

        }
    }        
}
