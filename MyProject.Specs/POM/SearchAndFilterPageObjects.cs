using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HistoricalEngland.Specs.POM
{

    class SearchAndFilterPageObjects : BasePageObjects
    {   //Navigate to Archive Collection Online

        public string AutoSuggestionLabelSelector = "(//div[@class='autocomplete-list__suggestion' and @data-suggestion='{var}'])[1]";
        public string ResultHeaderSelector = "(//div[@class='archive-search-results-list__result-container']//h3[contains(text(),'{var}')])[1]";
        public By ResultRelevance = By.PartialLinkText("House");
        public By ImageBookLink = By.XPath("(//a[@href='/images-books/'])[1]");
        public By FindPhotosLink = By.XPath("//a[@href='/images-books/photos/']");
        public By LLonSearchRes = By.XPath("//div[@class='archive-search-results-list__result-container']//dd[contains(text(),'Little London')]");
        public By ImageLink = By.XPath("(//div[@class = 'archive-search-results-list__result-container']//img)[1]");
        public By AutoSuggestionLabelSelectorForParish = By.XPath("(//div[@class='autocomplete-list__suggestion' and @data-suggestion='Exmouth|Devon|East Devon'])[1]");




        //Date field Input
        public By InputDateFrom = By.XPath("//input[@id='facet_hid_dateFrom']");
        public By InputDateTo = By.XPath("//input[@id='facet_hid_dateTo']");
        public By ResultForDate = By.XPath("//div[@class='archive-search-results-list__result-container']//dl[1]/dd");
        public By ApplyFiltButton = By.XPath("//div[@class='archive-search-filters__filter-section']//button[@type='submit']");
        public By FindDate = By.PartialLinkText("3 Oct 1979");
        //public By FindDate = By.PartialLinkText("Little London Cottage");

        //County field Input
        public By CountyInput = By.XPath("//input[@id='facet_hid_county']");
        public By CountySelect = By.XPath("//div[@class='autocomplete-suggestion']");
        public By HampResult = By.XPath("(//div[@class='archive-search-results-list__result-container']//dl[2]/dd[contains(text(),'Hampshire')])[1]");

        //Building field Input
        public By BuildCathInput = By.XPath("//input[@name='facet_txt_buildingtype']");
        public By BuildCathResult = By.XPath("(//a[@class='archive-search-result__link']//h3[contains(text(),'Cathedral')])[1]");
        public By BuildCatFrstRes = By.XPath("//div[@class='archive-record__people-container']//p[2]");

        //Parish field Input
        public By ParishInput = By.XPath("//input[@id='facet_hid_parish']");
        public By AutoSelectFirstEle = By.XPath("//div[@class='autocomplete-list']");
        public By DistricInput = By.XPath("//input[@id='facet_hid_district']");

        //Error message
        public By ErrorMsg = By.XPath("//div[@id='facet_txt_county-error-msg']");

      
    }
    class SearchAndFilterMethods : BaseMethods
    {
        private IWebDriver _driver;
        private SearchAndFilterPageObjects obj = new SearchAndFilterPageObjects();
       
        public SearchAndFilterMethods(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
        }

        public bool CheckDateResults(By by, string dateFrom, string dateTo)
        {
            int fromDate =int.Parse(dateFrom);
            int ToDate = int.Parse(dateTo);
            IList<IWebElement> searchConditionList = _driver.FindElements(by);
            List<IWebElement> ss = searchConditionList.ToList();
            Debug.WriteLine("Number of result elements: "+searchConditionList.Count);
            IList<string> searchTextList = new List<string>();
            int srchcount = searchConditionList.Count;
            for (int i = 0; i < srchcount; i++)
            {
                string[] str = ss[i].Text.Split(" ");
                searchTextList.Add(str[2]);
            }
            if (searchTextList.Any(str => ((int.Parse(str) >= fromDate) && (int.Parse(str) < ToDate))))
                return true;
            else
                return false;

        }
        public By BuildLocatorUsingStartsWith(string srchString)
        {
            return By.XPath("//form//div[starts-with(text(),'"+srchString+"   (')]");
        }

        public void FindSearchText(string srchTxt)
        {
            bool flag = false;
            int attempts=0;
            while(flag == false && attempts<=3)
            {
               try
               {
                  var ele = BuildLocatorUsingStartsWith(srchTxt);
                  _driver.FindElement(ele).Click();
                  flag = true;
               }
                        catch (Exception e)
               {
                  _driver.FindElement(obj.BuildCathInput).Clear();
                   FindElementAndEnterKeys(obj.BuildCathInput, srchTxt);
                   attempts += 1;
                   flag = false;
               }
            }
        }
    }
}
