using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HistoricalEngland.Specs.Helpers
{
    class CheckEnvironment
    {
        private static BrowserSetting browser = new BrowserSetting();
        private static readonly ConfigBuild config = new ConfigBuild();
        static bool env_Status= false;

        public static  bool EnvironmentStatus(ObjectContainer objectContainer)
        {
            IWebDriver webDriver = browser.InitDriver();
            objectContainer.RegisterInstanceAs<IWebDriver>(webDriver);
            webDriver.Navigate().GoToUrl(config.configuration["appSettings:TestUrl"]);

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(webDriver);
            fluentWait.Timeout = TimeSpan.FromSeconds(60);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(3000);
            IWebElement searchResult = fluentWait.Until(x => x.FindElement(By.TagName("h1")));

            var heading = searchResult.Text;
            if (heading.Equals("LAND GATE THE PIPEWELL"))
                env_Status = true;

            webDriver.Quit();
            webDriver.Dispose();
            return env_Status;
        }
    }
}
