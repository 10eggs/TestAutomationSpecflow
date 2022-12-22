using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using System.Linq;
using NUnit.Framework;
using System.Diagnostics;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;



namespace HistoricalEngland.Specs.POM
{
	public class ResearchReportsPageObjects : BasePageObjects
	{
		public By LastResult = By.XPath("(//article[@class='site-search-results__outer-container']/div/a)[last()]");
	

		public By RRDropDown = By.XPath("//div[@class='he-search-dropdown']");
		public By FilterNew = By.XPath("//select[@id='sort']/option[3]");
		public string FilterOptionsDDL = "//div/label[text()='{var}']/../../div/div/select";
		public By RrDDL = By.XPath("//select[@aria-label='Sort results by']");
		public By NewestDDL = By.XPath("//*[@id='sort']/option[3]");
		public By RRPageDropDown = By.XPath("//select[@name='sort']");
		public By TitleFire = By.XPath("//p[contains(text(),'fire')]");
		public By TitleFish = By.XPath("//h1[contains(text(),'fish')]");

		//Test  
		public By RRDropDown2 = By.XPath("//select[@aria-label='Sort results by']");


		public string ResultHeading = "(//li[@class='publications-search-result']//h3[contains(text(),'{var}')])[1]";
		// - //li[@class='publications-search-result']//h3[contains(text(),'AMPHORAE FROM YORK.')]

	}
}
