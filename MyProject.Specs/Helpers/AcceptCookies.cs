using HistoricalEngland.Specs.POM;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;


namespace HistoricalEngland.Specs.Helpers
{
    public static class AcceptCookies
    {
        public static void ClickAcceptCookie(IWebDriver driver)
        {
            try
            {
                driver.FindElement(new BasePageObjects().AcceptCookie).Click();

            }
            catch (NoSuchElementException)
            {
                return;
            }
        }
    }
}

