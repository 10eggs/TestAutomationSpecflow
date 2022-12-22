using BoDi;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using HistoricalEngland.Specs.POM;
using HistoricalEngland.Specs.StepDefinitions.BaseSteps;
using System.IO;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(8)]

namespace HistoricalEngland.Specs.Helpers
{
    [Binding]
    public class TestHooks
    {
        public static IObjectContainer objectContainer;
        private static readonly ConfigBuild config = new ConfigBuild();
        private BrowserSetting browserSet = new BrowserSetting();
        public static bool Stage_Status = true;
        private InteractionsSteps iSteps;

        private static ThreadLocal<ExtentTest> testLocal = new ThreadLocal<ExtentTest>();
        private static AventStack.ExtentReports.ExtentReports _Extent = new AventStack.ExtentReports.ExtentReports();
        private static ReplaceRptInfo rep_html = new ReplaceRptInfo();

        public ScenarioContext sc;
        public FeatureContext fc;
        //private static bool isFirst = true;


        public TestHooks(IObjectContainer objContainer, BrowserSetting brs,
                        ScenarioContext scenarioc)
        {
            objectContainer = objContainer;
            browserSet = brs;
            sc = scenarioc;
        }

        [BeforeTestRun]
        public static void OpenReport(ObjectContainer objectContainer, BrowserSetting browserSet)
        {
            //Stage_Status = CheckEnvironment.EnvironmentStatus(objectContainer);
            if (Stage_Status)
            {
                //To Archive old reports
                rep_html.ZipFileCreate();

                //htmlreporter attached to Extent report
                /**
                 *
                 *           COMMENT TO DISABLE REPORTER
                 * 
                 * 
                 */
                _Extent.AttachReporter(ExtReport.getReport());

            }
        }

        [BeforeFeature]
        public static void BeforeFeatureInitialize(ObjectContainer objectContainer, FeatureContext feature, BrowserSetting browserSet)
        {
            if (Stage_Status)
            {
                //Driver initialized for every feature so they can run in parallel
                IWebDriver webDriver = browserSet.InitDriver();
                objectContainer.RegisterInstanceAs<IWebDriver>(webDriver);


                feature["FirstScenario"] = true;
                //Adds test feature information to Extent Report
                ExtentTest test = _Extent.CreateTest<AventStack.ExtentReports.Gherkin.Model.Feature>(feature.FeatureInfo.Title);
                ExtTest.setTest(test);

                IWebDriver _driver = objectContainer.Resolve<IWebDriver>();

                // URL to go to before every sceanrio
                _driver.Navigate().GoToUrl(config.configuration["appSettings:actual"]);
                AcceptCookies.ClickAcceptCookie(_driver);

            }
        }

        [Before]
        public void NavigateToHomePage(ObjectContainer objectContainer, ScenarioContext sc)
        {
            if (Stage_Status)
            {
                IWebDriver _driver = objectContainer.Resolve<IWebDriver>();

                /**
                 * Try/catch block introduced due to problems with HTTP timeout issue
                 */
                try
                {
                    //Url to go to before every scenario
                    _driver.Navigate().GoToUrl(config.configuration["appSettings:actual"]);

                    //Adds test scenario information to the report
                    testLocal.Value = ExtTest.getTest().CreateNode<AventStack.ExtentReports.Gherkin.Model.Scenario>(sc.ScenarioInfo.Title);
                }

                catch (WebDriverException)
                {
                    _driver.Navigate().GoToUrl(config.configuration["appSettings:actual"]);
                    testLocal.Value = ExtTest.getTest().CreateNode<AventStack.ExtentReports.Gherkin.Model.Scenario>(sc.ScenarioInfo.Title);
                }
            }
        }


        [AfterStep]
        public void InsertReportingStep(ObjectContainer objectContainer, IWebDriver driver, ScenarioContext sc, TestContext tc)
        {
            //Adds Test steps in the report
            ExtSteps.getSteps(sc, driver, testLocal.Value, tc);

            if (sc.TestError != null)
            {
                string guid = System.Guid.NewGuid().ToString();
                string filename = ProjectPath.getProjectPath() + @"\Screenshots\" +
                    guid + ".png";

                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile(filename);
                TestContext.AddTestAttachment(filename);

                string browserLog = string.Join("\n", driver.Manage().Logs.GetLog(LogType.Browser));
                string browserLogPath = ProjectPath.getProjectPath() + @"\Screenshots\" + guid + ".txt";
                File.WriteAllText(browserLogPath, browserLog);
                TestContext.AddTestAttachment(browserLogPath);
            }
        }

        [AfterFeature]
        public static void  DisposeDriver(ObjectContainer objectContainer )
        {
            IWebDriver _driver = objectContainer.Resolve<IWebDriver>();
            _driver.Close();
            _driver.Quit();
            _driver.Dispose();

        }


        [AfterTestRun]
        public static void CloseReport(ObjectContainer objectContainer)
        {
            if (Stage_Status)
            {
                _Extent.Flush();
                rep_html.DeleteUnnecessaryInfo();

                //Dispose LocalThread 
                testLocal.Dispose();
                ExtTest.extentTestThreadSafe.Dispose();

            }
        }
    }
}
