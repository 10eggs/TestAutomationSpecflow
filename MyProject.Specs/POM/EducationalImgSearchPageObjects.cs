using OpenQA.Selenium;
using System;

namespace HistoricalEngland.Specs.POM
{
    class EducationalImgSearchPageObjects:BasePageObjects
    {

        public string EduTag = "//a[@class='images-by-theme__single-item' and text()='{var}']";

        public By EduImageLink = By.XPath("//a[@aria-label='Educational Images']");
        //Filter Results
        public By AccordionLink = By.XPath("//div//section[@id='search-filters-container']/section");
        public By TagDropDown = By.XPath("//select[@id='facet_ddl_tag']");
        public By PeriodDropDown = By.XPath("//select[@id='facet_ddl_period']");
        public By CountyDropDown = By.XPath("//select[@id='facet_ddl_county']");
        //public By CountyResult = By.XPath("(//li[@class='education-image__single-result'])[2]//p[1]");
        public By CountyResult = By.XPath("(//li[@data-he-at='education-image__single-result'])[2]//p[1]");
        public By PlaceDropDown = By.XPath("//select[@id='facet_ddl_place']");
        public By PlaceNoResult = By.XPath("//button/following-sibling::p[1]");
        public By FilterTagResult = By.CssSelector("#HEX_10084 > span");
        public By ImageSrc = By.XPath("(//div[@class='container CaseStudyList']//ul//img)[5]");
        public readonly By LeisureTag = By.XPath("//a[@class='images-by-theme__single-item' and text']/div/a[contains(text(), 'leisure')]");
    }

    class EducationalImgSearchMethods : BaseMethods
    {
        readonly IWebDriver _driver;
        private EducationalImgSearchPageObjects eduImgSrchObj = new EducationalImgSearchPageObjects();
        public EducationalImgSearchMethods(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
        }
        public String FindElementGetAccordAtt(By by, string att)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return _driver.FindElement(by).GetAttribute(att);

        }

        public bool ExpectedResult(string searchTxt, string field)
        {
            bool result;


            switch (field)
            {
                case "Period":
                    result = FindElementIsPresent(SelectByContainsText(searchTxt));
                    break;
                case "Tags":
                    result = FindElementIsPresent(eduImgSrchObj.FilterTagResult);
                    JsClick(eduImgSrchObj.FilterTagResult);
                    result = FindElementIsPresent(SelectAnchByText(searchTxt.ToLower()));
                    break;
                case "County":
                    result = FindElementIsPresent(SelectByContainsText(searchTxt));
                    break;
                case "Place":
                    result = FindElementAndGetText(eduImgSrchObj.PlaceNoResult).Contains("Sorry no results found");
                    break;
                default:
                    result = false;
                    break;
            }
            return result;
        }
    }
		
}
