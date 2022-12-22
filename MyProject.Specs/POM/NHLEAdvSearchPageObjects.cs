using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HistoricalEngland.Specs.POM
{
    public class NHLEAdvSearchPageObjects : BasePageObjects
    {
        
        public By AdvSearchLink = By.XPath("//a[@class='advanced-search-cta']");
        public By SrchResultArticle = By.XPath("//*[@id='SearchResults']/article");
        public By ClearBtn = By.XPath("//button[@type='reset']");
        public By HeritageCatLink = By.XPath("//div[@class='nhle-advanced-search-results__single-result--item'][2]");
        public By ListNameNhle = By.XPath("//input[@id='txtAssetName']");
        public By CountySelectNhle = By.XPath("//select[@id='ddlCounty']");

        public By ListedBuildNhle = By.XPath("//input[@id='HCListedBuilding']");
        public By DistrictSelectNhle = By.XPath("//select[@id='ddlDistrict']");
        public By GradeSelectNhle = By.XPath("//select[@id='ddlGrade']");
        public By SchedulingCheckNhle = By.XPath("//input[@id='HCScheduledMonument']");
        public By ParkGardenNhle = By.XPath("//input[@id='HCParkAndGarden']");
        public By ResultHeadingNhle = By.XPath("//h1");
        public By ResultsByTitle = By.XPath("//h1[contains(text(), 'The List - Advanced Search Results')]");

        //Filter By Parish
        public By ParishNhle = By.XPath("//input[@id='parish']");
        public By ParishFullListNhle = By.XPath("//div[@class='autocomplete-list']//div");
        public By ParishDropDownNhle = By.XPath("//div[@class='autocomplete-list__suggestion' and contains(text(),'East Allington')]");
        public By DropDownEastChinNhle = By.XPath("//div[@class='autocomplete-suggestion' and contains(text(),'East Chinnock')]");
        public By SelectedItem = By.XPath("//div[@class='autocomplete-suggestion']");

        //Filter By Date
        public By DateFromNhle = By.XPath("//input[@id='fromdaterange']");
        public By DateToNhle = By.XPath("//input[@id='todaterange']");

        //Filter By DesDate
        public By DesDateFromNhle = By.XPath("//input[@id='fromdate']");
        public By DesDateToNhle = By.XPath("//input[@id='todate']");


        // NHLE advance Page pagination
        public By PgNumber = By.XPath("//input[@id='srch_PageNumber']");
        public By PageInput = By.XPath("//input[@class='pagination__input']");
    }

    public class NHLEAdvSearchPageMethods : BaseMethods
    {
        readonly IWebDriver _driver;
        readonly NHLEAdvSearchPageObjects nhleAdvObj = new NHLEAdvSearchPageObjects();
        bool result;

        public NHLEAdvSearchPageMethods(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
        }

        public bool CheckString(By by, String txt)
        {
            IList<IWebElement> herList = _driver.FindElements(by);

            foreach (IWebElement item in herList)
            {
                Console.Out.WriteLine(item.Text);
                if (item.Text.Contains(txt))
                    result = true;
                else
                    result = false;
            }
            return result;
        }

        public void ElemtAssertValue(string value, By by)
        {
            FluentWaitCall(by);
            Assert.IsTrue(value
                        .Contains(FindElementGetValue(by)), "Does not contain the correct text");
        }

        public void CheckDisplayedTxt(IDictionary<string, string> fieldList)
        {
            ImplicitWaitTimeOut(10);
            var items = fieldList.Select(d => d.Key).ToList();
            foreach (KeyValuePair<string, string> item in fieldList)
            {
                Debug.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
                switch (item.Key)
                {
                    case "ListText":
                        Debug.WriteLine("ListText checked");
                        ElemtAssertValue(item.Value, nhleAdvObj.ListNameNhle);
                        break;
                    case "County":
                        Debug.WriteLine("County checked");
                        ElemtAssertValue(item.Value, nhleAdvObj.CountySelectNhle);
                        break;
                    case "Parish":
                        Debug.WriteLine("Parish checked");
                        ElemtAssertValue(item.Value, nhleAdvObj.DistrictSelectNhle);
                        break;
                    case "RangeFrom":
                        Debug.WriteLine("RangeFrom checked");
                        ElemtAssertValue(item.Value, nhleAdvObj.DateFromNhle);
                        break;
                    case "RangeTo":
                        Debug.WriteLine("RangeTo checked");
                        ElemtAssertValue(item.Value, nhleAdvObj.DateToNhle);
                        break;
                    case "DesignationFrom":
                        Debug.WriteLine("DesignationFrom checked");
                        ElemtAssertValue(item.Value, nhleAdvObj.DesDateFromNhle);
                        break;
                    case "DesignationTo":
                        Debug.WriteLine("DesignationTo checked");
                        ElemtAssertValue(item.Value, nhleAdvObj.DesDateToNhle);
                        break;
                    default:
                        Debug.WriteLine("No match");
                        break;
                }

            }
        }

       
    }
   
}


