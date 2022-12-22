using OpenQA.Selenium;

namespace HistoricalEngland.Specs.POM
{
    public class HeritageHighlightsSearchPageObjects : BasePageObjects
    {
        public readonly By WhatIsListingTab = By.XPath("//ul[@class='navigation-primary__level-2-list']/li/a[contains(text(),'What is Listing?')]");
        public readonly By HeritageHighlightsLink = By.XPath("//a[@href='/listing/what-is-designation/heritage-highlights/']");
        public readonly By ResultsFoundLabel = By.XPath("//p[@class='search-banner__filters--results-text']");
        public readonly By CategoryFieldInResultElement = By.XPath("((//li[@class='case-study__single-result'])[1]/p)[2]");
        //public readonly By CategoryFieldInResultElement = By.XPath("((//li[@data-he-at='case-study__single-result'])[1]/p)[2]");
        public readonly By InfosFieldInResultElement = By.XPath("((//div[@class='summary__content']))");
        //public readonly By InfosFieldInResultElement = By.XPath("(//div[@class='text-col content'])");
        public readonly By HeritageProtectionGuideTab = By.XPath("//ul[@class='navigation-primary__level-2-list']/li/a[contains(text(),'Heritage Protection Guide')]");
        public readonly By HeritagePlanningTab = By.XPath("//div[@class='callout-block__title-container']/span[contains(text(),'Heritage Planning Case Database')]");
        public readonly By PlanningFieldInResultElement = By.XPath("(//div[@class='text-col content'])[2]");

        //Drop down lists
        public readonly By TypeOfDesignationDDL = By.XPath("//select[@name='2280_TypeofDesignation']");
        public readonly By PeriodDDL = By.XPath("//select[@name='2280_Period']");
        public readonly By RegionDDL = By.XPath("//select[@name='2280_Region']");

    }
    public class HeritageHightlightsSearchMethdods : BaseMethods
    {
        IWebDriver _driver;
        public HeritageHightlightsSearchMethdods(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
        }
    }


}

