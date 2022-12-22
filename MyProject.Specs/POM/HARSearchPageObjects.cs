using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace HistoricalEngland.Specs.POM
{
    public class HARSearchPageObjects : BasePageObjects
    {

        public By AdviceTab = By.XPath("(//a[@href='/advice/'])[1]");
        public By HARLink = By.XPath("//li//a[@href='/advice/heritage-at-risk/']");
        public By SearchHARRegLink = By.XPath("//a[@href='/advice/heritage-at-risk/search-register/']");
        public By SearchHARImage = By.XPath("//a[@class='har-search-results__link' and @aria-labelledby='har-search-result-title-0']");
        public By SearchResult = By.XPath("(//a[@class='har-search-results__link'])[2]");
        public By SearchResultText = By.XPath("(//a[@class='har-search-results__link'])[2]//following-sibling:: h3");
        public By HeadingResultPg = By.XPath("//h1[@aria-live='assertive']");
        public By HeadingSearchResultPg = By.XPath("//h1[@class='h1']");
        public By SiteDetailsHead = By.XPath("//h2[text()='Site Details']");
        public By ExportResults = By.XPath("//a[@id='exportResults']");
        public By InputSearchTxt = By.XPath("//input[@id='txtkeyword']");
        public By SearchButton = By.XPath("//input[@id='q']//following::button[@type='submit']");
        public By HeritageCategory = By.XPath("//*[@id='ddlheritagecategory']");
        public By RefinedCriteriaLabel = By.XPath("//ul[@class='har-search-results__filters-summary']//following-sibling::li");
        public By NoResult = By.XPath("//p[contains(text(),'No records matched')]");
        public By ResultImgSrc = By.XPath("//article/div/picture/source");
        public By HARTitle = By.XPath("//h1[text()='Search the Heritage at Risk Register']");

        public By HarResultElement = By.XPath("//div[@class='har-search-results__image-float-right']");


        public String ListEntryUrl = "/advice/heritage-at-risk/search-register/list-entry/";
        public String ResultImg = "//img[@class='img-fluid']";

        public string DynamicDDLSelector = "//label[contains(text(),'{var}')]/../../div/div/select";
        public string SrcForNoImage = "https://stage.historic-england.org/har/smar_180.jpg?w=200&h=200&mode=crop&quality=90&upscale=false";

        // HAR Page pagination
        public By PageNumber = By.XPath("//input[@class='pagination__input']");
        public By NextArrrow = By.XPath("//a[@title='Next']");
        public By PreviousArrrow = By.XPath("//a[@title='Previous page']");

    }

    public class HARSearchPageMethods : BaseMethods
    {
        readonly IWebDriver _driver;
        readonly HARSearchPageObjects harObj = new HARSearchPageObjects();
        public HARSearchPageMethods(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
        }

        public bool RefineCriteriaPresent(string criteria)
        {
            IList<IWebElement> searchConditionList = _driver.FindElements(harObj.RefinedCriteriaLabel);
            return searchConditionList.Any(el => 
                el.Text.Contains(criteria));

        }
        public bool FileDownload(String fileName)
        {
            string Path = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";

            if (File.Exists(Path + "\\" + fileName))
                File.Delete(Path + "\\" + fileName);
            String downloadedFile = (Path + "\\" + fileName);
            JsClick(harObj.ExportResults);
            Thread.Sleep(5000);
            return File.Exists(downloadedFile);
        }

        public IList<string> SearchInfoRequested()
        {
            IList<string> searchLst = new List<string>();
            try
            {
                IList<IWebElement> searchConditionList = _driver.FindElements(harObj.RefinedCriteriaLabel);
                foreach (IWebElement element in searchConditionList)
                {
                    string txt = element.Text;
                    txt = txt.Substring(txt.IndexOf(":"));
                    searchLst.Add(txt.Substring(txt.IndexOf(" ")+1));
                }
                return searchLst;
            }
            catch (FormatException)
            {
                Debug.WriteLine("No results present for searching term");
                return searchLst;
            }
        }


        public bool CheckSearchInfo(IList<string> searchInputText)
        {
            bool flag = false;
            IList<string> srchList;
            srchList = SearchInfoRequested();
            Debug.WriteLine("Number of elements from input: " + searchInputText.Count);
            Debug.WriteLine("Number of elements captured from page: " + srchList.Count);

            for (int i = 0; i < searchInputText.Count; i++)
            {
                Debug.WriteLine("Search input: " + searchInputText[i]);
            }

            for (int i = 0; i < srchList.Count; i++)
            {
                Debug.WriteLine("Text captured from website: " + srchList[i]);
                Debug.WriteLine("Text captured from input: " + searchInputText[i]);
                if (searchInputText[i].Contains(srchList[i]))
                {
                    Debug.WriteLine("Pair fit");

                    flag = true;
                }
                else
                {
                    Debug.WriteLine("Pair not fit");
                    flag = false;
                }
            }
            return flag;
        }

        public bool CheckPicturesLoaded(string selector, int elementsCount)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));

            bool flag = true;
            for (int i=1;i<=elementsCount;i++)
            {
                try
                {
                    _driver.FindElement(By.XPath("(" + selector + ")[" + i + "]"));
                }
                catch (NoSuchElementException)
                {
                    flag = false;
                }
            }
            return flag;

        }
    }
}
