using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using SeleniumExtras.WaitHelpers;


namespace HistoricalEngland.Specs.POM
{
    public class ArticlePageObjects:BasePageObjects
    {
        //Images
        public By FirstPicture = By.XPath("(//div[@class='main-col'])[1]/div/figure/picture/img");
        public By SecondPicture = By.XPath("(//div[@class='main-col'])[2]/div/figure/picture/img");
        public By GalleryImagePic = By.XPath("//img[@title='TWO Caption = Test more puppies for testing landscape.with link to an UNPUBLISHED page']");
        public By GalleryFolderImagePic = By.XPath("//img[@title='Houses flooded after the River Severn burst its banks near Bewdley in Worcestershire']");
        public By GalleryImage = By.XPath("//div[contains(@class,'current')]/div/img[@class='fancybox-image']");
        //public By GalleryTitle = By.XPath("//h2[contains(text(),'This is a gallery')]"); 
        public By GalleryTitle = By.XPath("//h2 class[contains(text(),'This is a gallery')]");
        public By GalleryFolderTitle = By.PartialLinkText("Gallery folder");
        public By FacebookImg = By.XPath("//img[contains(@src,'facebook.com')]");
        public By NormansBayImg = By.XPath("//img[@alt='Diver recording cannon on Normans Bay. Credit Martin Davies']");
        public By FeatureImg = By.XPath("//div[@class='feature-image__image']/img");




        //Buttons
        public By ShowDetDesForFirstPic = By.XPath("//summary[@class='long-description__button']");
        public By AboutThisImgBtn = By.XPath("//span[contains(text(),'About this image')]/..");
        public string ChevronBtnSelector = "//button[@title='{var}']";
        public string AccordionBtn = "//button/h3[contains(text(),'{var}')]/..";
        public string AccordionHeaders = "//button[@class='accordion__link js-accordion__link']";
       
        // Social Share Buttons
        public By LinkedinBtn = By.XPath("//a[@class='socialButton container-for-icon btn-linkedin']");

        //TextFields
        public By DetDesTextField = By.XPath("//details/p[@class='long-description__text']");
        public By CaptionTextField = By.XPath("(//p[@class='nested-image__caption-text'])[1]");
        public By AboutImgBtnDesField = By.XPath("//div[contains(@class,'feature-image__description-text')]");
        public string AccordionExpanded = "//div[@class='accordion__item js-accordion-item']/div[@class='accordion__content']";


        //Embed
        public By YoutubeEmbed = By.XPath("//figure[@class='youtube-video__content']");
        public By TwitterEmbed = By.XPath("//iframe[@id='twitter-widget-0']");
        //public By InstagramEmbed = By.XPath("//iframe[@class='instagram-media instagram-media-rendered']");
        public By InstagramEmbed = By.XPath("//iframe[@id='instagram-embed-0']");
        public By FacebookEmbed = By.XPath("//iframe[contains(@src,'facebook.com')]");
        public By InfogramEmbed = By.XPath("//iframe[contains(@src,'infogram.com')]");
       

        //Menu
        public By MenuTabListing = By.XPath("//a[@data-test='main-menu-listing']");
        public By MenuLevel2Listing = By.XPath("//a[@data-test='navigation-level-2-item']");
        public By MenuCloseBtn = By.XPath("(//button[@class='navigation-primary__level-2-close-button'])[1]");
        //public By MenuBtn = By.XPath("//a[@data-test='main-menu-button']");
        public By MenuBtn = By.XPath("//a[@data-component='primaryNavClickedCtaButton']");






    }

    public class ArticlePageMethods : BaseMethods
    {
        IWebDriver _driver;
        public ArticlePageMethods(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
        }
        
        public int PictureSize(By pic)
        {
            int width=_driver.FindElement(pic).Size.Width;
            Debug.WriteLine("Width of searching element: "+width);

            return width;
        }

        public bool FindElementIsPresentWithoutScroll(By by)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
                wait.Until(ExpectedConditions.ElementExists(by));
                return true;
            }
            catch (Exception)
            {
                Debug.WriteLine("Element was not Found");
                return false;
            }
        }

        public List<IWebElement> CaptureListOfElements(string xpath)
        {
            return _driver.FindElements(By.XPath(xpath)).ToList();
        }
        public void ClickOnElements(IList<IWebElement> elements)
        {
            
            foreach (IWebElement el in elements)
            {

                el.Click();
            }
            
        }

        public (bool,int) VerifyElementsExpanded(IList<IWebElement> elements)
        {
            bool result = false;
            int displayedCount = 0;

            foreach (IWebElement el in elements)
            {
                if (el.Displayed)
                {
                    displayedCount++;
                    result = true;
                }
                else
                    result = false;
            }
            return (result,displayedCount);
        }

        public List<string> GetElementsAttribute(IList<IWebElement> elements,string att)
        {
            List<string> attributes = new List<string>();

            foreach (IWebElement el in elements)
            {
                attributes.Add(el.GetAttribute(att));
            }
            return attributes;
        }

	}
}
