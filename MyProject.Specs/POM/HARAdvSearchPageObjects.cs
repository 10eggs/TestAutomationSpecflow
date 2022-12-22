using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace HistoricalEngland.Specs.POM
{
    //[Binding]
    public class HARAdvSearchPageObjects : BasePageObjects
    {
        public By ListEntryTxt = By.XPath("//input[@id='txtListEntryNumber']");
        public By LclPlanningSelect = By.XPath("//select[@id='ddllocalplanningauthority']");
        public By SiteTypeSelect = By.XPath("//select[@id='ddlbroadterm']");
        public By AssessmentTypeSelect = By.XPath("//*[@id='ddlAssessmentType']");
        public By SearchInputHarAdv = By.XPath("//input[@id='txtkeyword']");

        //HAR Assessment Type fields
        public By ConditionSelect = By.XPath("//select[@id='ddlCondition']");
        public By PriorityCatSelect = By.XPath("//select[@id='ddlPriorityCategory']");
        public By OccupancySelect= By.XPath("//select[@id='ddlOccupancy']");
        public By OwnerTypeSelect = By.XPath("//select[@id='ddlOwnerType']");
        public By PrinceVulSelect = By.XPath("//*[@id='ddlPrincipalVulnerability']");
        public By TrendSelect = By.XPath("//*[@id='ddlTrend']");
        public By VulnerabilitySelect = By.XPath("//*[@id='ddlVulnerability']");

        //HAR More Location Options fields
        public By MoreLocButton = By.XPath("//button[@title='More Location Options']");
        public By CountySelect = By.XPath("//*[@id='ddlCounty']");
        public By UnitaryAuthSelect = By.XPath("//*[@id='ddlunitaryauthority']");
       
    }

    public class HARAdvSearchPageMethods : BaseMethods
    {
        readonly IWebDriver _driver;
        readonly HARAdvSearchPageObjects harAdvObj = new HARAdvSearchPageObjects();

        public HARAdvSearchPageMethods(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
        }


        public void CheckExtraDropDownListsPresent(string ddlList)
        {
            ImplicitWaitTimeOut(10);
            List<string> fieldDisplayed = ddlList.Split(',').ToList<string>();
            foreach (var field in fieldDisplayed)
            {
                switch (field)
                {
                    case "Trend":
                        Assert.IsTrue(FindElementIsPresent(harAdvObj.TrendSelect), "Trend ddl not present");
                        break;
                    case "Priority Category":
                        Assert.IsTrue(FindElementIsPresent(harAdvObj.PriorityCatSelect), "Priority Category ddl not present");
                        break;
                    case "Occupancy":
                        Assert.IsTrue(FindElementIsPresent(harAdvObj.OccupancySelect), "Occupancy ddl not present");
                        break;
                    case "Principal Vulnerability":
                        Assert.IsTrue(FindElementIsPresent(harAdvObj.PrinceVulSelect), "Principal Vulnerability ddl not present");
                        break;
                    case "Vulnerability":
                        Assert.IsTrue(FindElementIsPresent(harAdvObj.VulnerabilitySelect), "Vulnerability ddl not present");
                        break;
                    case "Owner Type":
                        Assert.IsTrue(FindElementIsPresent(harAdvObj.OwnerTypeSelect), "Owner type ddl not present");
                        break;
                    case "Condition":
                        Assert.IsTrue(FindElementIsPresent(harAdvObj.ConditionSelect), "Condition ddl not present");
                        break;
                    case "County":
                        Assert.IsTrue(FindElementIsPresent(harAdvObj.CountySelect), "County ddl not present");
                        break;
                    case "Unitary Authority":
                        Assert.IsTrue(FindElementIsPresent(harAdvObj.UnitaryAuthSelect), "Unitary Authority ddl not present");
                        break;
                    default:
                        break;

                }
            }
        }

        public void SelectFromDropDownList(string selector,string ddlName,string fieldTxt)
        {
            try
            {
                By ddl = DynamicWebElement(selector, ddlName);
                FindElementIsPresent(ddl);
                FindDropdownAndSelectOption(ddl, fieldTxt, "text");
            }
            catch (Exception)
            {
                Debug.WriteLine("Verify if drop down list " + ddlName + " is present or if " + fieldTxt + " field has been selected");
            }
            Debug.WriteLine("Option " + fieldTxt + " has been selected from " + ddlName + " drop down list");

        }
    }
}
