using OpenQA.Selenium;
using System;

namespace HistoricalEngland.Specs.POM
{
    public class PublicationSearchPageObjects:BasePageObjects
    {
        //Textfields
        public readonly By SearchAllPublicationsTab = By.XPath("//a[contains(text(),'Search All Publications')]");
        public readonly By SearchAllPublicationsHeader = By.XPath("//h1[text()='Search All Publications']");
        public readonly By ResultsFoundLabel = By.XPath("//p[@class='search-banner__filters--results-text']");
        public readonly By PdfContainer = By.XPath("//li[@class='pdf container-for-icon']");
        public readonly By DateOfPublication = By.XPath("(//time)[1]");
        public readonly By PageNumberSpan = By.XPath("//input[@id='srch_PageNumber']");
        public readonly By HeaderOnResultPage = By.XPath("//div[@id='page-title']/h1");
        public readonly By SearchContainer = By.XPath("//section[contains(@class,'filterContainer')]");
        public readonly By SeriesResult = By.XPath("//li[@class='publications-search-result']/div/span[@class='publications-search-result__series-text']");
        public readonly By PubPagination = By.XPath("//a[@data-pagination-action='next']");
        //public readonly By SeriesResult = By.XPath("//li[@data-he-at='publications-search-result']/div/span[@class='publications-search-result__series-text']");
        public string ResultHeader = "//a[contains(@class,'result')]/h3[contains(text(),'{var}')]/..";


        //Btns
        public readonly By SearchScopeBtn = By.XPath("//button[@id='btnQuickSearch']");
        public readonly By FilterResultsBtn = By.XPath("//button[contains(text(),'Filter results')]");
        //public readonly By FilterResultsBtn = By.XPath("//button[@title='Filter results']");
        public readonly By PubFilterBtn = By.XPath("//button[@data-component='filterResultsButtonClicked']");
        public readonly By ApplyFiltersBtn = By.XPath("//button[@id='filtersubmit']");

        

        //Checkboxes
        public readonly By DonwloadableContentBox = By.XPath("//label[@title='Downloadable content']");
        public readonly By NonHEPubBox = By.XPath("//label[@title='Non Historic England publications']");

        //DDLS
        public string FilterOptionsDDL="//div/label[text()='{var}']/../../div/div/select";
        public readonly By PublishedDDL = By.XPath("//select[@name='periodPublished']");
        public readonly By SeriesDDL = By.XPath("//select[@name='Series']");



    }

    public class PublicationSearchPageMethods : BaseMethods
    {
        IWebDriver _driver;
        
        public PublicationSearchPageMethods(IWebDriver driver): base (driver)
        {
            this._driver = driver;
        }

        public bool CheckDateNotOlderThan10yAgo(string date)
        {
            var dateTimeOtherFormat = DateTime.Parse(date);
            
            DateTime today = DateTime.Today;
            var tenYearsAgo = today.AddYears(-10);


            return tenYearsAgo < dateTimeOtherFormat;

        }

    }

}
