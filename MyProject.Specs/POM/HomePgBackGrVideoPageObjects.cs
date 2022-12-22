using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace HistoricalEngland.Specs.POM
{
    class HomePgBackGrVideoPageObjects:BasePageObjects
    {
        //public By BackGrdVideo = By.XPath("//*[@id='widget2']");
        public By BackGrdVideo = By.XPath("//div[@class='youtube-video__iframe']");
        public By VideoTest = By.XPath("//*[@id='player_uid_857032130_1']/div[1]/video");
        public By VideoPre = By.XPath("//*[@id='widget4']");
        public By PlayButton = By.XPath("//div[@class='homepage-youtube__video-cover-image js-video-cover-image']");
    }

    class HomePgBackGrVideoMethods : BaseMethods
    {
        private IWebDriver driver;

        public HomePgBackGrVideoMethods(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
    }
}
