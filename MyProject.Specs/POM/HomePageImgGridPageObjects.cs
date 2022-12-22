using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HistoricalEngland.Specs.POM
{
    class HomePageImgGridPageObjects : BasePageObjects
    {  
        //ImageGrid field links

        public By ImageGridImgTxt = By.XPath("(//h3[@class='card-item__title'])[2]");
        public By BlueCardDisplay = By.XPath("(//div[@class='card-item__title-wrapper'])[2]");
        public By ImageGridPic1= By.XPath("(//div[@class='container-fluid']//a[@class='card-item js-lazy-loaded'])[1]");
        public By ImageGridPic2 = By.XPath("(//div[@class='container-fluid']//a[@class='card-item js-lazy-loaded'])[2]");
        //public By ImageGridPic4 = By.XPath("//img[@title='Add Your Photos to the List']");
        public By ImageGridPic4 = By.XPath("(//h3[@class='card-item__title'])[4]");
        public By CloseButton = By.XPath("//button[@type='button']");
        public By BreadCrumbs = By.CssSelector("li.breadcrumb__item.breadcrumb__item--active");
    }

    public class HomePageImgGridMethods : BaseMethods
    {
        readonly IWebDriver _driver;
        public String winHandleBefore;
        private readonly BasePageObjects baseObjects = new BasePageObjects();
        readonly HomePageImgGridPageObjects hpImgGridObj = new HomePageImgGridPageObjects();

        public HomePageImgGridMethods(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
        }

        public void HoverCheck()
        {
            CheckElementIsDisplayed(hpImgGridObj.ImageGridImgTxt).Equals(false);
            CheckElementIsDisplayed(hpImgGridObj.BlueCardDisplay).Equals(false);
            CheckElementIsDisplayed(hpImgGridObj.ImageGridPic1).Equals(true);
            CallActionToPerform(hpImgGridObj.ImageGridPic1, hpImgGridObj.ImageGridPic2);
            CheckElementIsDisplayed(hpImgGridObj.BlueCardDisplay).Equals(true);
        }

        public void ChangeWindow()
        {
            winHandleBefore = _driver.CurrentWindowHandle;

            ReadOnlyCollection<string> windowHandle = _driver.WindowHandles;
            foreach (string winHandle in windowHandle)
            {
                _driver.SwitchTo().Window(winHandle);
            }
        }
        public void CloseNewWindow()
        {
            FindElementAndClick(hpImgGridObj.CloseButton);
            _driver.SwitchTo().Window(winHandleBefore);
        }
        public By AnchorByTxt(String val)
        {
            return By.XPath("//a[contains(text(),'" + val + "')]");
        }
    }

}