 using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace HistoricalEngland.Specs.Helpers
{
    public class Navigation
    {
        private readonly IWebDriver _driver;
        private readonly ConfigBuild _config;
        public Navigation(IWebDriver driver, ConfigBuild config)
        {
            _driver = driver;
            _config = config;
        }

        public void Navigate(string area)
        {
            _driver.Navigate().GoToUrl(_config.configuration["appSettings:actual"] + _config.configuration[$"originPages:{area}"]);
        }
    }
}
