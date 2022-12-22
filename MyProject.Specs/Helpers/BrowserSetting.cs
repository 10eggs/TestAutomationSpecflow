using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace HistoricalEngland.Specs.Helpers
{
    public class BrowserSetting
    {
        private static readonly ConfigBuild config = new ConfigBuild();
        public IWebDriver InitDriver()
        {
            IWebDriver webDriver;
            switch (config.configuration["browserSettings:driver"])
            {
                case "ChromeDriver":
                default:
                    webDriver = GetChromeDriver();
                    break;
                case "FirefoxDriver":
                    webDriver = GetFirefoxDriver();
                    break;
            }
            return webDriver;
        }

        private static FirefoxDriver GetFirefoxDriver()
        {
            FirefoxProfile pro = new FirefoxProfile();
            pro.SetPreference("browser.download.folderList", 2);
            pro.SetPreference("browser.download.dir", "\\Downloads");
            pro.SetPreference("browser.download.useDownloadDir", true);
            pro.SetPreference("browser.helperApps.neverAsk.saveToDisk", "text/csv,application/octet-stream");
            var options = new FirefoxOptions()
            {
                Profile = pro
            };
            options.AddArguments("--headless");
            options.AddArgument("--window-size=1440, 900");
            options.AddArguments("--disable-web-security");
            CodePagesEncodingProvider.Instance.GetEncoding(437);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
            driver.Manage().Window.Maximize();
            return driver;
        }

        private static ChromeDriver GetChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArguments("--headless");
            options.AddArgument("--window-size=1440, 900");
            options.AddArguments("--start-maximized");
            options.AddArguments("--disable-web-security");
            options.AddArgument("no-sandbox");
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
            var param = new Dictionary<string, object>();
            param.Add("behavior", "allow");
            param.Add("downloadPath", $"C:\\Users\\{Environment.UserName}\\Downloads\\");

            driver.ExecuteCdpCommand("Page.setDownloadBehavior", param);
            return driver;

        }

    }
}
