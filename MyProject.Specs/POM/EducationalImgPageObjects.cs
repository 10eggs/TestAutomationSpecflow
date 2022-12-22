using OpenQA.Selenium;

namespace HistoricalEngland.Specs.POM
{
    class EducationalImgPageObjects:BasePageObjects
    {   
        //Links to get to EducationImage landing page
        public By ServiceSkillsLink = By.XPath("(//a[@href='/services-skills/'])[1]");
        public By EductionLink = By.XPath("//a[@href='/services-skills/education/']");

        //Gallery results Page
        public By GalleryPgResults = By.XPath("//div[@class ='main-col']//div//a");
        public By CrimdonParkImg = By.XPath("//a[contains(@href,'crimdon-park')]//img");
        public By RefinedResults = By.XPath("(//li[@class='education-image__single-result'])[1]//span");
        public By ThemesLink = By.XPath("//a[@class='images-by-theme__theme']");
        public By ResultsListBlock = By.XPath("//div[@class='container CaseStudyList']//ul");
    }

    class EducationalImgPageMethods :BaseMethods
    {
        private IWebDriver _driver;

        public EducationalImgPageMethods(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
        }

    }
}
