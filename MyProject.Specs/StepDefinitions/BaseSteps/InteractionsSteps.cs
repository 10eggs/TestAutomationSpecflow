using HistoricalEngland.Specs.POM;
using OpenQA.Selenium;
using System.Threading;
using TechTalk.SpecFlow;
using SeleniumExtras.WaitHelpers;

namespace HistoricalEngland.Specs.StepDefinitions.BaseSteps
{
    [Binding]
    public class InteractionsSteps
    {


        private readonly IWebDriver driver;
        private readonly BaseMethods baseMethod;
        private readonly BasePageObjects baseObject;
        public InteractionsSteps(IWebDriver driver, BaseMethods baseMethod, BasePageObjects baseObject)
        {
            this.driver = driver;
            this.baseMethod = baseMethod;
            this.baseObject = baseObject;
        }

        [StepDefinition(@"I am on ""(.*)"" page")]
        public void GivenThanIAmOnPage(string landingPage)
        {
            string url = baseMethod.GetCurUrl();
            switch (landingPage)
            {
                case "Educational Image search":
                    url += BasePageObjects.config.configuration["originPages:educationalImgSearch"];
                    break;
                default:
                    break;
            }
            driver.Navigate().GoToUrl(url);
        }

        [Given(@"I have accepted the cookie banner")]
        public void AcceptCookies()
        {

            baseMethod.JsClick(baseObject.AcceptCookie);
        }


        [StepDefinition(@"I select the ""(.*)"" button")]
        public void SelectTheButton(string text)
        {
            baseMethod.FindElementAndClick(baseMethod.ButtonByText(text));
            baseMethod.ImplicitWaitTimeOut(10);
        }

        [StepDefinition(@"I select the ""(.*)"" anchor")]
        public void SelectTheAnchor(string text)
        {
            baseMethod.JsClick(baseMethod.AnchorByText(text));
        }

        [StepDefinition(@"I select ""(.*)"" element")]
        public void ThenISelectElement(string text)
        {
            //Js Click changed for FindElementANDclick
            //baseMethod.JsClick(baseMethod.DynamicWebElement(baseObject.ElementContainingText, text));
            By element = baseMethod.DynamicWebElement(baseObject.ElementContainingText, text);
            baseMethod.FindElementAndClick(element);
        }

        [StepDefinition(@"I type ""(.*)"" into the search box")]
        public void TypeIntoTheSearchBox(string searchString)
        {
            baseMethod.ImplicitWaitTimeOut(10);
            baseMethod.PressKey(baseObject.SearchInput, "Delete");
            baseMethod.FindElementAndEnterKeys(baseObject.SearchInput, searchString);
        }

        [StepDefinition(@"I select the ""(.*)"" block")]
        public void SelectTheBlock(string txt)
        {
            By element = baseMethod.DynamicWebElement(baseObject.BlockElement, txt);
            baseMethod.FindElementAndClick(element);
        }

        [StepDefinition(@"I click on the search icon")]
        public void ClickOnTheSearchIcon()
        {
            baseMethod.JsClick(baseObject.QuickSearchBtn);
        }

        [StepDefinition(@"I click on the ""(.*)"" pagination arrow")]
        public void ClickOnThePaginationArrow(string button)
        {
            baseMethod.PagePagination(button);

        }

        [StepDefinition(@"I enter the number ""(.*)"" into the pagination box")]
        public void WhenIEnterTheNumberIntoThePaginationBox(string num)
        {
            baseMethod.EnterInNewPageNum(num, baseObject.PageNumber);
            baseMethod.PressKey(baseObject.PageNumber, "Enter");
        }

        [StepDefinition(@"I select ""(.*)"" from the results page")]
        public void SelectFromTheResultsPage(string searchingTerm)
        {
            
            By element = baseMethod.DynamicWebElement(baseObject.ElementContainingText, searchingTerm);
            baseMethod.FindElementAndClick(element);
        }

        [StepDefinition(@"I select ""(.*)"" from the ""(.*)"" drop down list")]
        public void SelectFromTheDropDownList(string option, string category)
        {
            By ddl = baseMethod.DynamicWebElement(baseObject.FilterOptionDDL, category);
            try
            {
                baseMethod.FindDropdownAndSelectOption(ddl, option, "value");
            }
            catch (NoSuchElementException e)
            {
                baseMethod.FindDropdownAndSelectOption(ddl, option, "text");
            }
        }

        [StepDefinition(@"I click the ""(.*)"" tick box")]
        public void WhenIClickTheTickBox(string tickBoxName)
        {
            baseMethod.FindElementAndClick(baseMethod.DynamicWebElement(baseObject.TickBox, tickBoxName));
        }

        [StepDefinition(@"I use the browser function to back to the previous page")]
        public void UseTheBrowserFunctionToBackToThePreviousPage()
        {
            baseMethod.ClickBrowserBack();
        }

        [StepDefinition(@"I press ""(.*)"" to accept page number")]
        public void WhenIPressOnMyKeyboard(string key)
        {
            baseMethod.PressKey(baseObject.PageNumberInput, key);
        }

        [StepDefinition(@"I select the back-to-top button")]
        public void ISelectTheBack_To_TopButton()
        {
            //JsScroll commented out for now but if this step starts failing comment it back in
            baseMethod.JsScrollToPgBottom();
            baseMethod.JsClick(baseObject.BackToTop);
        }

        [StepDefinition(@"I scroll to the bottom of the page")]
        public void ScrollToTheBottomOfThePage()
        {
            baseMethod.JsScrollToPgBottom();
        }

        [StepDefinition(@"I refresh the page")]
        public void IRefreshThePage()
        {
            driver.Navigate().Refresh();
        }

        [StepDefinition(@"I close an alert")]
        public void ThenICloseAnAlert()
        {
            Thread.Sleep(2000);
            driver.SwitchTo().Alert().Accept();
        }

       [StepDefinition(@"I select the return to main site button")]
       public void ReturnToMainSite()
        {
            baseMethod.FindElementAndClick(baseObject.ReturnToMainSiteBtn);
        }

        //NHLE Sign In
        [StepDefinition(@"I select the List Entry Sign in link")]
        public void ISelectTheListEntrySignInLink()
        {
            Thread.Sleep(2000);
            baseMethod.JsClick(baseObject.SignInLink);
        }

        [StepDefinition(@"I enter text ""(.*)"" into the ""(.*)"" field")]
        public void IEnterTextIntoTheField(string text, string inputName)
        {
            baseMethod.FindElementAndEnterChars(baseMethod.InputByText(inputName), text);
        }

        [StepDefinition(@"I take a screenshot and save it as ""(.*)""")]
        public void TakeScreenshotAndSave(string screenshotName)
        {
            baseMethod.TakeScreenshot(screenshotName);
        }

        [StepDefinition(@"I click select the ""([^""]*)"" element")]
        public void WhenIClickSelectTheElement(string elemName)
        {
            By element = baseMethod.DynamicWebElement(baseObject.BlockElement, elemName);
            baseMethod.JsClick(element);
        }

    }
}
