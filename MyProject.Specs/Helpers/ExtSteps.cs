using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using HistoricalEngland.Specs.POM;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;

namespace HistoricalEngland.Specs.Helpers
{
    class ExtSteps
    {
        public static string screenShotPath, fileName;
      
        public static void getSteps(ScenarioContext sc, IWebDriver driver, ExtentTest test, TestContext tc)
        {
            var exception = sc?.TestError?.InnerException;
            var status = sc.ScenarioExecutionStatus.ToString();
            var title = sc.ScenarioInfo.Title.Trim();

            if (sc.TestError == null && status.Equals("OK"))
                test.CreateNode<Given>(sc.StepContext.StepInfo.Text);
            else if (sc.ScenarioExecutionStatus.ToString().Equals("StepDefinitionPending"))
            {
                test.CreateNode<Given>(sc.StepContext.StepInfo.Text)
                         .Error(sc.ScenarioExecutionStatus.ToString());
                test.CreateNode<Given>("Test not run").Skip("");
            }

            else if (sc.ScenarioExecutionStatus.ToString().Equals("Skipped"))
            {
                test.CreateNode<Given>(sc.StepContext.StepInfo.Text)
                         .Skip(sc.ScenarioExecutionStatus.ToString());
                test.CreateNode<Given>("Any following steps (if present) have been skipped").Skip("");

            }

            else if (sc.ScenarioExecutionStatus.ToString().Equals("TestError"))
            {
                test?.CreateNode<Given>(sc.StepContext.StepInfo.Text)
                       .Fail(sc.TestError.Message);
                test.CreateNode<Given>("Any following steps (if present) have been skipped").Skip("");

            }

            else if (exception == null)
            {
                test?.CreateNode<Given>(sc.StepContext.StepInfo.Text)
                       .Fail(sc.TestError.Message);
                test.CreateNode<Given>("Any following steps (if present) have been skipped").Skip("");
            }

            else
            {
                test.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text)
                           .Error(sc.TestError.InnerException);
            }

            if (!status.Equals("OK"))
            {
                ITakesScreenshot screen = (ITakesScreenshot)driver;
                CreateFileName(driver, title);
                var scrPath = "../" + ExtReport.day_dt + "/Screenshots/" + fileName;
                test.CreateNode<Given>(fileName)
                                  .Skip("ScreenShot Information", MediaEntityBuilder.CreateScreenCaptureFromPath(scrPath).Build());
            }
        }

        public static void CreateFileName(IWebDriver _driver, string title)
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;

            if (status.Equals(TestStatus.Failed) || status.Equals(TestStatus.Inconclusive))
            {
                DateTime time = DateTime.Now;
                fileName = title + time.ToString("hh_mm_ss") + ".png";
                screenShotPath = Capture(_driver, fileName);
            }

        }

        public static string Capture(IWebDriver driver, String screenShotName)
        {
            try
            {
                ITakesScreenshot ts = (ITakesScreenshot)driver;
                Screenshot screenshot = ts.GetScreenshot();
                string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                Directory.CreateDirectory(ProjectPath.getProjectPath() + "Reports\\" + ExtReport.day_dt + "\\Screenshots");
                screenShotName = screenShotName.Replace("\"", "").Replace(" ", "_");
                var finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Reports\\" + ExtReport.day_dt + "\\Screenshots\\" + screenShotName;
                var localpath = new Uri(finalpth).LocalPath;
                screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
                return localpath;
            }
            catch(Exception e)
            {
                Debug.WriteLine("Screenshot cannot be captured");
                return BaseMethods.RandomString(5);
            }
            //ITakesScreenshot ts = (ITakesScreenshot)driver;
            //Screenshot screenshot = ts.GetScreenshot();
            //string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            //Directory.CreateDirectory(ProjectPath.getProjectPath() + "Reports\\" + ExtReport.day_dt + "\\Screenshots");
            //screenShotName = screenShotName.Replace("\"", "").Replace(" ", "_");
            //var finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Reports\\" + ExtReport.day_dt + "\\Screenshots\\" + screenShotName;
            //var localpath = new Uri(finalpth).LocalPath;
            //screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            //return localpath;
        }

    }
}
