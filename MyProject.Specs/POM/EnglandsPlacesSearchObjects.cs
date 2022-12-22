using OpenQA.Selenium;

namespace HistoricalEngland.Specs.POM
{
    public class EnglandsPlacesSearchObjects : BasePageObjects
    {
        //public readonly By ImagesAndBooksTab = By.XPath("//div[@class='navigation-primary__level-1']//a[contains(text(),'Images & Books')]");
        public readonly By ImagesTab = By.XPath("(//a[@href='/images-books/'])[3]");
        public readonly By FindPhotosTab = By.XPath("//a[contains(text(),'Find Photos')]");
        public readonly By EnglandsPlaces = By.XPath("//a[@href='/images-books/photos/englands-places/']");
        public readonly By SearchBox = By.XPath("//input[@id='gazetteerSearch']");
        public readonly By SearchBtn = By.XPath("//button[@class='gazetteer-search-banner__button']");
        public readonly By ResultsRecords = By.XPath("//ul[@class='ep-results__inline-navigation__inner-container --visible']");
        public readonly By ResultsInnerElements = By.XPath("//ul[@class='ep-results__inline-navigation__inner-container --visible']/li[@class='menu-item-open']");
        public readonly By GalleryHeader = By.XPath("//h1[contains(text(),'Gallery')]");
        public readonly By LastGalleryObject = By.XPath("(//a[@class='ep-image-gallery__image-container js-lazy-loaded'])[last()]");
        public readonly By CardDetailHeader = By.XPath("//h1[contains(text(),'Card Detail')]");
        public readonly By EPTitle =  By.XPath("//h1[text()='England's Places']");
        public readonly By EnglandsPlacesHeader = By.XPath("//h1[contains(text(),'Places')]");


        
        public string SearchingExactRecordSelector = "//li[@class='ep-results-list__item']/a/h3[text()='{var}']";
        public string SearchingRecordSelector = "//li[@class='ep-results-list__item']/a/h3[contains(text(),'{var}')]";
        public string DPArrBtn = "//div[@class='ep-results__single-result-text']/h3/a[text()='{var}']/../../../span[@class='icon icon--chev-down']";
        public string ResultsInnerLastLevelHeader = "//h3[contains(text(),'{var}')]";
        public string OpenBoxBtnSelector = "//ul[@class='ep-results__inline-navigation__inner-container --visible']/li/div/a[contains(text(),'{var}')]";

    }

    public class EnglandsPlacesSearchObjectsMethods:BaseMethods
    {
        IWebDriver _driver;

        
        public EnglandsPlacesSearchObjectsMethods(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
        }

    }

}
