using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.IO;


namespace HistoricalEngland.Specs.POM

{
    public class NHLESearchPageObjects : BasePageObjects
    {
        public By ListingTab = By.XPath("//div[@class='navigation-primary__level-1']//a[contains(text(),'Listing')]");
        public By SearchTheSiteBtn = By.XPath("//a/span[contains(text(),'Search the site')]");
        public By SearchTheListLink = By.XPath("//a[contains(text(),'Search the List')]");
        public By SearchTheListHeader = By.XPath("//div[@id='page-title']/h1[contains(text(),'List')]");
        public By ZeroResultsReturned = By.XPath("//h1[contains(text(),'0 Search Results for')]");
        public By ResultsReturned = By.XPath("//section[@id='SearchResults']");

        // NHLE Filter Results
        public By CountyDistrictDropdown = By.XPath("//select[@id='facet_ddl_countyDistrict']");
        public By ParishDropDown = By.XPath("//select[@id='facet_ddl_parish']");
        public By FilteredResults = By.XPath("//div[contains(@class,'result')]/a/h3");
        public string FilteredResultsDescriptionField="(//div[@class='nhle-single-result']/ul/li[contains(text(),'{var}')])[1]";
        public By ApplyFilterBtn = By.CssSelector("#filter-submit");

        public By ExportResults = By.XPath("//a[@id='exportResults']");

        //Image of England
        public By ImageOfEnglandContainer = By.XPath("//div[@data-smart-frame='images-of-england']");

        //New NHLE design
        public By CommentsTab = By.XPath("//span[@id='comments-and-photos-link-text']");
        public By OfficalTab = By.XPath("//span[@id='official-listing-link-text']");
        public By OverviewTab = By.XPath("//span[@id='overview-link-text']");
        public By CommentsTitle = By.XPath("//h2[contains(text(),'Comments and photos')]/..");
        public By OverviewTitle = By.XPath("//h2[contains(text(),'Overview')]/..");
        public By OfficialTitle = By.XPath("//h2[contains(text(),'Official list entry')]/..");


        // NHLE Filter Options
        public By FilteredHeritageCategorys = By.XPath("//span[text()='Heritage Category:']/..");
        public By ResultsperPageDropDown = By.XPath("//select[@name='searchResultsPerPage']");
        public By AdvancedSearchBtn = By.XPath("//h2[contains(text(),'Advanced Search')]/..");

        // NHLE Select Result from Page
        public By GetEleWithTitle(string txt)
        {
            return By.XPath("//a//h3[contains(text(),'" + txt + "')]");
        }

        // NHLE Select Result from Page
        public By GetRecord(string txt)
            {
                return By.XPath("//h1[contains(text(),'" + txt + "')]");

            }

    }

    public class NHLESearchPageMethods : BaseMethods
    {
        readonly IWebDriver _driver;
        private readonly BaseMethods methods;
        //Line below was changed - list was initialized in class scope, now it's moved to ctror
        private readonly BasePageObjects baseObjects;
        readonly NHLESearchPageObjects obj;

        public NHLESearchPageMethods(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
            methods = new BaseMethods(driver);
            baseObjects= new BasePageObjects();
            obj= new NHLESearchPageObjects(); 
        }

        public bool FileDownload(String fileName)
        {
            string Path = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";

            if (File.Exists(Path + "\\" + fileName))
                File.Delete(Path + "\\" + fileName);
            String downloadedFile = (Path + "\\" + fileName);
            JsClick(obj.ExportResults);
            Thread.Sleep(5000);
            return File.Exists(downloadedFile);
        }

        public string ReturnNHLEFilteredSearch()
        {
           methods.ImplicitWaitTimeOut(20);
           string textFromHeader = methods.FindElementAndGetText(baseObjects.PageHeader);
           string numberOfResults = textFromHeader.Substring(0, textFromHeader.IndexOf(" "));
           Debug.WriteLine("Number of results from header after filter: " + numberOfResults);
           methods.ImplicitWaitTimeOut(10);
           return numberOfResults;
        }

        public bool AssertHeritageCategoryFilter(string category)
        {
            IList<IWebElement> heritageList = _driver.FindElements(obj.FilteredHeritageCategorys);

            if (heritageList.All(el => ((el.Text).Contains(category))))
            {
                Debug.WriteLine("Selected category is present on every element");
                return true;
            }
            else
                Debug.WriteLine("At least one element has different category than selected category");
                return false;
        }
  

        public int ResultsPerPage()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            int count = _driver.FindElements(obj.FilteredResults).Count;
            return count;
        }

        public void EnterInNewPageNum(String num)
        {
            _driver.FindElement(obj.PageNumber).SendKeys(num);
        }

    }
}
