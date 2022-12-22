using AventStack.ExtentReports.Gherkin.Model;
using HistoricalEngland.Specs.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using TechTalk.SpecFlow;

namespace HistoricalEngland.Specs.StepDefinitions.EducationImagePage
{
    [Binding]
    class EducationalImagePageSteps
    {
        private EducationalImgPageObjects eduImgPgObj;
        private BaseMethods baseMethod;


        public EducationalImagePageSteps(EducationalImgPageObjects eduImgPgObj,
            BaseMethods baseMethod)
        {
           this.eduImgPgObj = eduImgPgObj;
            this.baseMethod = baseMethod;
        }

        [Given(@"that I am on the ""(.*)"" landing page")]
        public void IAmOnTheImagesByThemeLandingPage(string blockName)
        {
            baseMethod.JsClick(eduImgPgObj.ServiceSkillsLink);
            baseMethod.JsClick(eduImgPgObj.EductionLink);
            baseMethod.JsClick(baseMethod.DynamicWebElement(eduImgPgObj.BlockElement, blockName));

        }

        [Given(@"I am on the gallery page with just aerial photographs")]
        [Then(@"I am on the gallery page with just aerial photographs")]

        public void ThenIAmOnTheGalleryPageWithJustAerialPhotographs()
        {
            Assert.IsTrue(baseMethod.FindElementIsPresent(eduImgPgObj.GalleryPgResults),
                "Result has not been found");
            bool loaded =baseMethod.CheckImageLoaded(eduImgPgObj.CrimdonParkImg);
            Assert.IsTrue(loaded, "Image not loaded");
        }

        [Then(@"I am taken to the ""(.*)"" results")]
        public void ThenIAmTakenToAEducationItemPage(string searchingPhrase)
        {
            Thread.Sleep(3000);
            Assert.IsTrue(baseMethod.FindElementAndGetText(eduImgPgObj.PageHeader)
                  .Contains(searchingPhrase),
                  "Header does not contain searching phrase");
        }

    }
}
