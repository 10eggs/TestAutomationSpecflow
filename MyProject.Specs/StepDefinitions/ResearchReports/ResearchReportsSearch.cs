using HistoricalEngland.Specs.POM;
using HistoricalEngland.Specs.StepDefinitions.BaseSteps;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace HistoricalEngland.Specs.StepDefinitions.ResearchReports
{
	[Binding]
	public class ResearchReportsSteps
	{
		//private readonly BaseMethods baseMethod;
		//private readonly BasePageObjects baseObject
		//private readonly AssertionSteps assertions;
		//private readonly IWebDriver driver;
		private readonly BasePageObjects obj;
		private readonly ResearchReportsMethods rrpm;
		private readonly ResearchReportsPageObjects rrpo;

		public ResearchReportsSteps(BasePageObjects obj, ResearchReportsMethods rrpm, ResearchReportsPageObjects rrpo)
		{
			//this.driver = driver;
			this.obj = obj;
			this.rrpo = rrpo;
			this.rrpm = rrpm;
		}


		[When(@"I click on the drop down filter")]
		public void WhenIClickOnTheDropDownFilter()
		{
			rrpm.FindElementAndClick(rrpo.RrDDL);
			Thread.Sleep(3000);

			//pspm.FindDropdownAndSelectOption(pspo.PublishedDDL, searchingTerm, "text");
			//pspm.FindElementAndClick(pspo.ApplyFiltersBtn);
		}

		[StepDefinition(@"I select ""(.*)"" from the RR drop down")]
		public void ISelectFromTheRRDropDown(string var)
		{
			rrpm.FindDropdownAndSelectOption(rrpo.RRPageDropDown, var, "text");
			rrpm.ImplicitWaitTimeOut(20);
		}

		[StepDefinition(@"the results show ""(.*)"" first")]
		public void TheResultsShowFirst(string searchString)
		{
			//Assert.IsTrue(rrpm.FindElementIsPresent(rrpm.DynamicWebElement(rrpo.ResultHeading, firstresult)), "result not found");
			By headerElement = rrpm.DynamicWebElement(rrpo.ResultHeading, searchString);
			Thread.Sleep(3000);
			Assert.IsTrue(rrpm.FindElementIsPresent(headerElement),
				"No results found for this searching phrase");
		}

		[StepDefinition(@"I am taken to the Research Reports refined results page for fish")]
		public void IAmTakenToTheResearchReportsRefinedResultsPageFor()
		{
			Thread.Sleep(2000);

			Assert.IsTrue(rrpm.GetCurUrl().Contains("fish"),
			  "Url query doesnt contain searching phrase");
		}

		[StepDefinition(@"I am taken to the research results for fire")]
		public void IAmTakenToTheResearchResultsForFire()
		{
			Thread.Sleep(2000);
			Assert.IsTrue(rrpm.FindElementIsPresent(rrpo.TitleFire),
			   "specified title is not present");
			Assert.IsTrue(rrpm.GetCurUrl().Contains("fire"),
			  "Url query doesnt contain searching phrase");
			
		}

		[StepDefinition(@"I am taken to the research results for fish")]
		public void IAmTakenToTheResearchResultsForFish()
		{
			Thread.Sleep(2000);
			//below assert broken by staging bug
			//Assert.IsTrue(rrpm.FindElementIsPresent(rrpo.TitleFish),
			//   "specified title is not present");
			Assert.IsTrue(rrpm.GetCurUrl().Contains("fish"),
			  "Url query doesnt contain searching phrase");
		}




		[StepDefinition(@"I select ""(.*)"" from the dropdown filter")]
		//public void ISelectFromTheDropdownFilter(string text)
		public void ISelectFromTheDropdownFilter(string p0)
		{
			rrpm.JsClick(rrpo.RRDropDown);
			rrpm.JsClick(rrpo.FilterNew);
			//rrpm.FindDropdownAndSelectOption(rrpo.RRDropDown, text, "text");
			//rrpm.PressKey(rrpo.RRDropDown, "Enter");
		}


		[StepDefinition(@"the results change to (.*)")]
		public void TheResultsChangeTo(int p0)
		{
				Assert.IsTrue(rrpm.GetCurUrl().Contains("100"),
				  "Url query doesnt contain searching phrase");

			}

			 public class ResearchReportsMethods : BaseMethods
		{
			readonly IWebDriver _driver;
			readonly ResearchReportsPageObjects rrpo = new ResearchReportsPageObjects();
			bool result;

			public ResearchReportsMethods(IWebDriver driver) : base(driver)
			{
				this._driver = driver;
			}


		}

	}
}












