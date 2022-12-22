using OpenQA.Selenium;

namespace HistoricalEngland.Specs.POM
{
    class SiteSearchPageObjects : BasePageObjects
    {
        public By LastResult = By.XPath("(//article[@class='site-search-results__outer-container']/div/a)[last()]");
        public By ResultPageHeader = By.XPath("//h1");
        public By ResultImg = By.XPath("//div[contains(@class,'results')]/a/img");
        public By ResultHeader = By.XPath("//div[contains(@class,'results')]/a");
        //public By ResultHeader = By.XPath("//div[contains(@class,'results')]/a");
        public By SearchTxtFire = By.PartialLinkText("Fire");
        public By SearchTxtLittleLondon = By.PartialLinkText("Little London");
        public By ResultHeaderTxt = By.XPath("//div[contains(@class,'results')]/a/h3");
        public By ResultImgHyperLink = By.XPath("(//div[contains(@class,'results')]/a)[1]");
        public string ResultCategoryField = "(//p[contains(text(),'{var}')])[10]";
        //public string ResultCategoryField = "(//p[@class='green-text-bold']");

    }

    class SiteSearchMethods : BaseMethods
    {
        private IWebDriver _driver;

        public SiteSearchMethods(IWebDriver driver): base(driver)
        {
            this._driver = driver;

        }
    }
}
