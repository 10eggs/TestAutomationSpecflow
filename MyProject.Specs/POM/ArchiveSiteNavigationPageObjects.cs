using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace HistoricalEngland.Specs.POM
{
    class ArchiveSiteNavigationPageObjects : BasePageObjects
    {   
        //ACO page
        public By Title = By.XPath("//h3");
        public By TitleFrstRes = By.XPath("(//h3[@class='archive-search-result__title'])[1]");
        public By ResultTitle = By.PartialLinkText("Leominster Station, Leominster");
        public By PlaceHolder2 = By.XPath("(//div[@class='archive-search-results-list__result-container']//img[1])[6]");
        public By PlaceHolder3 = By.XPath("//div[@class='archive-record__image--placeholder']//img");
        public By PlaceHolder1 = By.XPath("(//div[@class='archive-search-results-list__result-container']//img[1])[1]");
        //public string TickBoxSelector = "//div[@class = 'checkbox-container archive-search']/label[contains(text(), '{var}')]/../input";
        public string TickBoxSelector = "//div[@data-he-at= 'checkbox-container archive-search']/label[contains(text(), '{var}')]/../input";

        //Checking item,Series and Collection content
        public By SeriColHed = By.XPath("//h1[contains(text(),'Series')] | //h1[contains(text(),'Collection')]");
        public By Info = By.XPath("//h2");
        public By ImageLink = By.XPath("//div[@class = 'archive-search-results-list__result-container']//img");
        public By SeriesLink = By.XPath("//div[@class='archive-record__section']//a[1]");
        public By SeriesTxt = By.XPath("//div[@class='archive-record__section']/h2[contains(text(),'Content')]/../p");
        public By SeriesChildVol = By.XPath("//div[@class='archive-record__section-collection-children']//a");
        public By CollectionLink = By.XPath("//div[@class='archive-record__section']//a[2]");
        public By ContentArrow = By.XPath("//summary[@class='archive-record__accordion-title']");
        public By ContentDetail = By.XPath("//details");
        public By NewSrchLink = By.PartialLinkText("Try a new search");
        public By PlaceHolder = By.XPath("(//div[@class='archive-search-results-list__result-container']//img[1])[1]");
        public By ImagePlaceHolder = By.XPath("(//div[@class='archive-search-results-list__result-container']//img[@alt='Placeholder image for archive collection'])[1]");
    }
    class ArchiveSiteNavigationPageMethods : BaseMethods
        {
            private ArchiveSiteNavigationPageObjects archSNavPgObj = new ArchiveSiteNavigationPageObjects();
            IWebDriver _driver;
            public ArchiveSiteNavigationPageMethods(IWebDriver driver) : base(driver)
            {
                this._driver = driver;
            }

            public By FindElementInArchive(string txt)
            {
                return By.XPath("//dt[contains(text(),'" + txt + "')]");
            }
            
            public bool CheckHeadings(By by)
            {
            bool flag = false;
            IList<IWebElement> ele = _driver.FindElements(archSNavPgObj.Info);
            List<IWebElement> ss = ele.ToList();
            for (int i = 0; i < ss.Count; i++)
                if (ss[i].Text.Equals("Description") || ss[i].Text.Equals("Content") || ss[i].Text.Equals("Rights") || ss[i].Text.Equals("Keywords"))
                   flag = true;
                 else
                   flag = false;
            return flag;
            }
         

        }
    
}
