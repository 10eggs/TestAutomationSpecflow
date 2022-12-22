using OpenQA.Selenium;

namespace HistoricalEngland.Specs.POM
{
	public class GapSearchPageObjects : BasePageObjects
	{
		// Navigation to GAP
		public By ServicesTab = By.XPath("(//a[@href='/services-skills/'])[1]");
		public By GrantsLink = By.XPath("//div[@class='navigation-primary__level-2-section']//a[contains(text(),'Grants')]");
		public By VisitGapLink = By.XPath("//a[@href='/services-skills/grants/visit/']");

		// Search GAP
		public By SearchBox = By.Id("solrSearch");
		public new By SearchBtn = By.Id("btnQuickSearch");
		public By BuildingCb = By.Id("cb_buildings-monuments-landscapes");
		public By WorshipCb = By.Id("cb_places-of-worship");
		public By CragsideText = By.XPath("//a[@href='cragside-rothbury-ne65-7px/']/h3");
		public By EmmanuelText = By.XPath("//a[@href='emmanuel-church-windsor-road-ts12-1be/']/h3");
		public By ResultsContainer = By.XPath("//div[@class='container']//li");
		
	}
	public class GAPSearchPageMethods : BaseMethods
	{
		readonly IWebDriver _driver;
		readonly GapSearchPageObjects gapObj = new GapSearchPageObjects();
		


		public GAPSearchPageMethods(IWebDriver driver) : base(driver)
		{
			this._driver = driver;
		}
		
	}
}



