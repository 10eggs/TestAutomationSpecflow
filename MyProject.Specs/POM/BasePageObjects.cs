using HistoricalEngland.Specs.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
//using ExpectedConditions = OpenQA.Selenium.Support.UI.ExpectedConditions;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;

namespace HistoricalEngland.Specs.POM
{
    public class BasePageObjects
    {
        //test
        //Config object to read urls using in test scenarios
        public static readonly ConfigBuild config = new ConfigBuild();
        public static Random random = new Random();

        //Cookie Banner
        public By AcceptCookie = By.XPath("//button[@id='ccc-notify-accept']");

        //Alert Close

        //public By ReturnToMainSiteBtn = By.XPath("//a[@aria-label='Return to main site']");
        //public By ReturnToMainSiteBtn = By.XPath("//a[@title='Return to main site']");
        public By ReturnToMainSiteBtn = By.XPath("//a[@class='hp-header__return-link']");

        // Scroll page/Back to top functionality (can be used if JssCroll is required within longer pages)
        //public By BackToTop = By.XPath("//a[@id='back-to-top-button']");
        public By BackToTop = By.XPath("//button[@id='back-to-top-button']");

        // Search elements
        public By SearchBtn = By.XPath("//span[text()='Search the site']");
        public By SearchInput = By.XPath("//input[@type='search']");
        public By QuickSearchBtn = By.XPath("//button[@type='submit']");
        public By FirstRowResult = By.XPath("(//article)[1] //h3");
        public By ReadOurUpdate = By.XPath("//span[@class='editorPrimaryButton']");
        public By RecordsHeaderFound = By.XPath("//h2");
        //public By HiddenPageTitle = By.PartialLinkText(" page can’t be found");
        public By HiddenPageTitle = By.XPath("//div[@class='error-code']");
        //public By ProfilePageShowing = By.XPath("");
        public By PageHeader = By.XPath("//h1");
        public By SearchScopeBtn = By.XPath("//button[@id='btnQuickSearch']");
        //Image Alt Text
        public string AltTextObj = ("//img[@alt='{var}']");


        //Tabs
        public readonly By ImagesPage= By.XPath("(//a[@href='/images-books/'])[1]");
        public readonly By ImagesAndBooksTab = By.XPath("//div[@class='navigation-primary__level-1']//a[contains(text(),'Images & Books')]");
        public readonly By ListingTab = By.XPath("//div[@class='navigation-primary__level-1']//a[contains(text(),'Listing')]");
        public readonly By ListingPage = By.XPath("(//a[@href='/advice/'])[1]");
        public readonly By AdvicePage = By.XPath("(//a[@href='/advice/'])[1]");
        public readonly By AdviceTab = By.XPath("//div[@class='navigation-primary__level-1']//a[contains(text(),'Advice')]");

        //Elements
        public string ResultsElementTitle = "(//li[contains(@class,'result')]//*[contains(text(),'{var}')])[1]";
        public By ResultsElement = By.XPath("(//li[contains(@class,'result')])[1]");
        public string ResultsFilteredElement = "(//p[contains(text(),'{var}')])";
        //public string ResultsFilteredElement = "(//div[@class='case-study__single-result-property']//a[contains(text(),'{var}')]";

        //Selectors
        public string FilterOptionDDL = "//label[contains(text(),'{var}')]/../../div/div/select";
        public string PageNumberInputSelector = "//input[contains(@title,'Page number') and @placeholder='{var}']";
        public string ElementByText = "//*[(text()='{var}')]";
        public string ElementContainingText = "//*[contains(text(),'{var}')]";
        public string BlockElement = "//a//*[contains(text(),'{var}')]";
        public string TickBox = "//label[contains(text(),'{var}')]/../input[@type='checkbox']";
        public string ButtonByText = "//button[contains(text(),'{var}')]";
        public readonly By PageNumberSpan = By.XPath("//input[contains(@id,'ageNumber')]");
        public string MyAccountDropDownLabels = "//li[@class='header-bar__hp-link-account-links-list-item']/a[contains(text(),'{var}')]";

        //Genric Title Check
        public string GenPageTitle = "//h1[contains(text(),'{var}')]";

        //Span
        public By PageNumber = By.XPath("//input[@id='srch_PageNumber']");
        public By PageNumberInput = By.XPath("//input[contains(@title,'Page number')]");

        //NHLE Sign In
        //public By SignInLink = By.XPath("//a[@href='https://stage-sa.historic-england.org/sign-in//?u=&referrer=https://stage.historic-england.org/listing/the-list/list-entry/1234567?section=comments-and-photos']");

        public By SignInLink = By.XPath("//a[@id='signInLink']");
        public By SignInTxt = By.PartialLinkText("Add your comments, photos or videos now");
        public By AddComment = By.XPath("//button[@class='btn button-secondary mt-3']");
    }

    public class BaseMethods
    {
        public readonly IWebDriver _driver;
        public BaseMethods(IWebDriver driver)
        {
            _driver = driver;
        }

        public void FindElementAndClick(By by)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(45);

            try
            {
                JavaScriptScroll(by);

                FluentWaitCall(by);

                JsClick(by);

            }
            catch (Exception)
            {
                JsScrollToPgBottom();

                JavaScriptScroll(by);

                FluentWaitCall(by);

                JsClick(by);

            }
        }


        public void FindElementAndEnterKeys(By by, String key)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            FluentWaitCall(by);
            string txt = key;
            IWebElement input = _driver.FindElement(by);
            input.SendKeys(txt);

        }

        public void CallActionToPerform(By byEle1, By byEle2)
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(_driver.FindElement(byEle1)).MoveToElement(
                _driver.FindElement(byEle2)).Build().Perform();
        }

        public void FindElementAndEnterChars(By by, String val)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //JavaScriptScroll(by); //Uncomment after run
            FluentWaitCall(by);
            string s = "";
            for (int i = 0; i < val.Length; i++)
            {
                char c = val[i];
                s = new StringBuilder().Append(c).ToString();
                _driver.FindElement(by).SendKeys(s);
                if (i + 1 == val.Length)
                {
                    _driver.FindElement(by).SendKeys(Keys.Backspace);
                    Thread.Sleep(1000);
                    _driver.FindElement(by).SendKeys(s);
                    Thread.Sleep(1000);
                }
            }
        }

        public void PressKey(By by, string key)
        {
            JsScrollToPgBottom();
            //This line was replaced with JsScrollToBot
            //JavaScriptScroll(by);
            switch (key)
            {
                case "Enter":
                    _driver.FindElement(by).SendKeys(Keys.Enter);
                    break;
                case "Delete":
                    _driver.FindElement(by).SendKeys(Keys.Control + "a");
                    break;
                case "Back":
                    _driver.FindElement(by).SendKeys(Keys.Alt + Keys.ArrowLeft);
                    break;
                case "Tab":
                    _driver.FindElement(by).SendKeys(Keys.Tab);
                    break;
                default:
                    break;
            }
        }

        public void JavaScriptScroll(By by)
        {
            //JsScrollToPgBottom();
            //var ele = _driver.FindElement(by);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true); ", _driver.FindElement(by));

        }

        public void JsScrollByPixel(int pixNumber)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollBy(0," + pixNumber + ")", "");

        }

        public void JsScrollToPgBottom()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(3000);
        }

        public void JsScrollToPgTop()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0,0)");
            Thread.Sleep(2000);

        }

        public bool CheckImageLoadedByLazyLoading(string xpath, int number)
        {

            bool flag = true;
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));


            for (int i = 1; i <= number; i++)
            {
                By nextElemSelector = By.XPath("(" + xpath + ")[" + i + "]");
                try
                {
                    js.ExecuteScript("arguments[0].scrollIntoView(true); ", _driver.FindElement(nextElemSelector));
                    wait.Until(ExpectedConditions.ElementIsVisible(nextElemSelector));
                    wait.Until(ExpectedConditions.ElementExists(nextElemSelector));
                    Debug.WriteLine("Iteration no. " + i);

                }
                catch (Exception)
                {
                    Debug.WriteLine("Catch block has been executed");
                    flag = false;
                    break;
                }
            }
            return flag;

        }

        public bool CheckImageLoaded(By by)
        {

            FindElementIsPresent(by);
            Object result;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            do
            {
                try
                {
                    result = ((IJavaScriptExecutor)_driver).ExecuteScript(
                    "return arguments[0].complete && "
                    + "typeof arguments[0].naturalWidth != \"undefined\" && " +
                    "arguments[0].naturalWidth > 0", _driver.FindElement(by));
                    if (sw.Elapsed.Seconds > 60)
                    {
                        sw.Stop();
                        break;
                    }
                }
                catch (NoSuchElementException)
                {
                    JsScrollToPgBottom();
                    result = ((IJavaScriptExecutor)_driver).ExecuteScript(
                    "return arguments[0].complete && "
                    + "typeof arguments[0].naturalWidth != \"undefined\" && " +
                    "arguments[0].naturalWidth > 0", _driver.FindElement(by));
                }

            }
            while (!(Boolean)result);

            return (Boolean)result;
        }

        public void FluentWaitCall(By by)
        {

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(60);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(3000);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            fluentWait.Until(ExpectedConditions.ElementExists(by));
            fluentWait.Until(x => x.FindElement(by));
        }

        //Added
        public bool FindElementIsPresent(By by)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
            try
            {
                JavaScriptScroll(by);
                //JsScrollToPgBottom();
                wait.Until(ExpectedConditions.ElementIsVisible(by));
                wait.Until(ExpectedConditions.ElementExists(by));

                return true;
            }
            catch (StaleElementReferenceException e)
            {
                JsScrollToPgBottom();
                JavaScriptScroll(by);
                wait.Until(ExpectedConditions.ElementIsVisible(by));
                wait.Until(ExpectedConditions.ElementExists(by));
                return true;
            }

            catch(Exception e)
            {
                return false;
            }
        }
        public bool FindElementIsPresent(By by, int waitingTime)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitingTime));

            try
            {
                JsScrollToPgBottom();
                //JavaScriptScroll(by);
                wait.Until(ExpectedConditions.ElementIsVisible(by));
                wait.Until(ExpectedConditions.ElementExists(by));
                return true;
            }

            catch (StaleElementReferenceException)
            {
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

        public By ButtonByText(String val)
        {
            var element = By.XPath("//button[contains(text(), " + "'" + val + "'" + ")]");
            FluentWaitCall(element);
            return element;
        }
        public bool CheckElementIsDisplayed(By by)
        {
            FluentWaitCall(by);
            return _driver.FindElement(by).Displayed;
        }

        public By InputByText(String val)
        {
            return By.XPath("(//label[contains(text(), " + "'" + val + "'" + ")]/..//input)[1]");
        }


        public By AnchorByText(String val)
        {
            return By.XPath("(//a[contains(text(),'" + val + "')])");
        }

        public string GetCurUrl()
        {
            return _driver.Url;
        }

        public void FindDropdownAndSelectOption(By by, string keys, string type)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            JavaScriptScroll(by);
            SelectElement oSelect = new SelectElement(_driver.FindElement(by));
            switch (type)
            {
                case "value":
                    oSelect.SelectByValue(keys);
                    break;
                case "text":
                    oSelect.SelectByText(keys);
                    break;
                default:
                    Debug.WriteLine("Please verify if \"type\" parameter is correct");
                    break;
            }
            Thread.Sleep(1000);
        }

        public String FindElementAndGetText(By by)
        {
            FluentWaitCall(by);
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(by));

            string text;

            //This try-catch block was introduce as a solution agains Stale exception
            try
            {
                text=_driver.FindElement(by).Text;
            }
            catch (Exception)
            {
                text = _driver.FindElement(by).Text;

            }
            return text;
        }

        public String CheckElementAttValue(By by, string txt)
        {
            string newString = "";
            do
            {
                newString = _driver.FindElement(by).GetAttribute("placeholder");
            } while (!newString.Equals(txt) || !newString.Contains(txt));

            return newString;
        }

        public void ClickBrowserBack()
        {
            _driver.Navigate().Back();
        }

        public void ImplicitWaitTimeOut(int seconds)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public String FindElementGetValue(By by)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return _driver.FindElement(by).GetAttribute("value");
        }

        public String FindElementGetValueAtt(By by, string att)
        {
            //stale reference check should be implemented here?
            try
            {
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                JavaScriptScroll(by);
                string valueAtt = _driver.FindElement(by).GetAttribute(att);
                return valueAtt;
            }

            catch (StaleElementReferenceException)
            {
                Thread.Sleep(3000);
                JsScrollToPgBottom();
                JavaScriptScroll(by);
                string valueAtt = _driver.FindElement(by).GetAttribute(att);
                return valueAtt;
            }
        }

        public String FindElementGetValueAttNoJs(By by, string att)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string valueAtt = _driver.FindElement(by).GetAttribute(att);
            return valueAtt;
        }

        public void JsClick(By by)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement element = _driver.FindElement(by);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
            executor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            executor.ExecuteScript("arguments[0].click();", element);
        }

        public void NavigateToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public bool SearchInfoRequest(string searchInputText, By by)
        {
            Debug.WriteLine("Searching phrase: " + searchInputText);
            string searchText = searchInputText;

            FluentWaitCall(by);
            IList<IWebElement> searchConditionList = _driver.FindElements(by);
            List<IWebElement> ss = searchConditionList.ToList();

            Debug.WriteLine("Number of list elements: " + searchConditionList.Count);

            foreach (IWebElement webEl in ss)
            {
                Debug.WriteLine("TXT: " + webEl.Text);
            }

            if ((!(ss.Count == 0)) && (ss.Any(str => !str.Text.Contains(searchText, StringComparison.OrdinalIgnoreCase))))
            {
                Debug.WriteLine("Results has not contain searching phrase");
                return false;
            }
            else
            {
                Debug.WriteLine("All results element contain searching phrase");
                return true;

            }
        }

        public By SelectByContainsText(String val)
        {
            By link = By.XPath("(//p[contains(text()," + "'" + val + "'" + ")])[1]");
            FluentWaitCall(link);
            return link;
        }

        public By SelectAnchByText(String val)
        {
            var link = By.XPath("//a[contains(text()," + "'" + val + "'" + ")]");
            FluentWaitCall(link);
            return link;
        }


        public void PagePagination(string button)
        {
            By PaginationBtn = By.XPath("//*[contains(@title,'" + button + "')]");
            JsClick(PaginationBtn);
        }

        public By DynamicWebElement(string xpath, string var)
        {
            return By.XPath(xpath.Replace("{var}", var));

        }

        public bool IsAttributePresent(By element, string attribute)
        {
            bool result = false;
            IWebElement we = _driver.FindElement(element);
            try
            {
                string att = we.GetAttribute(attribute);
                Debug.WriteLine("Attribute: " + att);
                if (att != null)
                {
                    result = true;
                }
            }
            catch (StaleElementReferenceException e)
            {
                Debug.WriteLine("There is no \'" + attribute + "\' attribute for selected element");
            }
            return result;
        }

        public bool VerifyUrlChange(string url)
        {
            ImplicitWaitTimeOut(120);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (!url.Contains(GetCurUrl()))
            {

                if (sw.Elapsed.TotalMinutes > 1)
                {
                    Debug.WriteLine("Time out");
                    sw.Stop();
                    return false;
                }
            }
            sw.Stop();
            return true;

        }

        public bool VerifyElementChangeValue(By element, string att, string value)
        {
            ImplicitWaitTimeOut(120);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (!FindElementGetValueAtt(element, att).Contains(value, StringComparison.OrdinalIgnoreCase))
            {

                Debug.WriteLine("Element att: " + FindElementGetValueAtt(element, att));
                Debug.WriteLine("Elapsed seconds: " + sw.Elapsed.Seconds);

                if (sw.Elapsed.TotalMinutes > 1)
                {
                    Debug.WriteLine("Time out");
                    sw.Stop();
                    return false;
                }
            }
            sw.Stop();
            return true;
        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[BasePageObjects.random.Next(s.Length)]).ToArray());
        }

        public string RandomEmail(int length)
        {
            return RandomString(length) + "@historicengland.org.uk";

        }

        public void EnterInNewPageNum(String num,By span)
        {
            _driver.FindElement(span).SendKeys(num);
        }

        public void CheckElementContent(By element, String ExpectedText, String ErrorMessage)
        {
            Assert.IsTrue(FindElementAndGetText(element).Contains(ExpectedText), ErrorMessage);
        }

        public void WaitAndJSClickElement(By element)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(1));
            var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(element));
            FindElementAndClick(element);
        }

        public void WaitAndClickElement(By element)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(1));
            var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(element));
            clickableElement.Click();
        }

        public void WaitScrollAndClickElement(By element)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(1));
            var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(element));
            JavaScriptScroll(element);
            clickableElement.Click();
        }

        public void WaitAndEnterKeys(By element, String text)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(1));
            var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(element));
            clickableElement.SendKeys(text);
        }

        public void TakeScreenshot(string screenshotName)
        {
            string guid = System.Guid.NewGuid().ToString();
            string filename = ProjectPath.getProjectPath() + @"\Screenshots\" +
                screenshotName + "-" + guid + ".png";

            Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
            ss.SaveAsFile(filename);
            TestContext.AddTestAttachment(filename);
        }

    }
}
