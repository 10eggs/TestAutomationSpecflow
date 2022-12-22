using HistoricalEngland.Specs.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace HistoricalEngland.Specs.StepDefinitions.ArchiveCollectionOnline
{
    [Binding]
    class SiteNavigationSteps
    {
        private ArchiveSiteNavigationPageObjects archSNavPgObj;
        private ArchiveSiteNavigationPageMethods archSNavPgMethods;
        
        //Context variables
        string srchTxt,result;
        string heading;

        public SiteNavigationSteps(ArchiveSiteNavigationPageObjects archSNavPgObj,
            ArchiveSiteNavigationPageMethods archSNavPgMethods)
        {
            this.archSNavPgObj = archSNavPgObj;
            this.archSNavPgMethods = archSNavPgMethods;

        }

        [Then(@"records should contain Image and ref number")]
        public void ThenRecordsShouldContainImageAndRefNumber()
        {
            archSNavPgMethods.JsScrollToPgBottom();
            Assert.IsTrue(archSNavPgMethods.FindElementIsPresent(archSNavPgObj.Title),
                "No results found for this searching phrase");
            Assert.IsTrue(archSNavPgMethods.FindElementIsPresent(archSNavPgMethods.FindElementInArchive("Reference")),
                "Reference field not found");
            Assert.IsTrue(archSNavPgMethods.FindElementIsPresent(archSNavPgMethods.FindElementInArchive("Location")),
                "Location field not found");
            Assert.IsTrue(archSNavPgMethods.FindElementIsPresent(archSNavPgMethods.FindElementInArchive("Date")),
                "Date field not found");


            var loaded = archSNavPgMethods.CheckImageLoaded(archSNavPgObj.ImageLink);
            Assert.IsTrue(loaded, "Image Not Found");

            Assert.IsTrue(archSNavPgMethods.FindElementIsPresent(archSNavPgObj.ResultTitle),
                "Header does not contain searching phrase");

        }

        //Pretend to base step
        [Given(@"I click the first result")]
        public void ClickOnTheFirstResult()
        {
            archSNavPgMethods.FindElementAndClick(archSNavPgObj.TitleFrstRes);
        }

       

        [Then(@"I view the record with Image and ref number")]
        public void VerifyRecordWithImageAndRefNumberPresent()
        {
            /**
             * What this flag stand for?
             * **/

            //bool flag = false;
            archSNavPgMethods.FindElementIsPresent(archSNavPgMethods.FindElementInArchive("Reference"));
            archSNavPgMethods.FindElementIsPresent(archSNavPgMethods.FindElementInArchive("Type"));
            var placeHol = archSNavPgMethods.FindElementGetValueAtt(archSNavPgObj.PlaceHolder3, "alt");
            Assert.IsTrue(placeHol.Contains("Placeholder image for archive collection"));
        }

        [When(@"I click the ""(.*)"" link in the content section")]
        public void ClickTheLinkInTheContentSection(string txt)
        {
            srchTxt = archSNavPgMethods.FindElementAndGetText(archSNavPgObj.SeriesTxt);
            if (txt.Equals("Series"))
            {
                archSNavPgMethods.FindElementAndClick(archSNavPgObj.SeriesLink);
            }
            else
            {
                archSNavPgMethods.FindElementAndClick(archSNavPgObj.CollectionLink);
            }
        }

        [Then(@"I should be redirected to the page displaying information about that ""(.*)""")]
        public void ThenIShouldBeRedirectedToThePageDisplayingInformationAboutThat(string txt)
        {
            string title;
            title = archSNavPgMethods.FindElementAndGetText(archSNavPgObj.SeriColHed);
            if (txt.Equals("series"))
                Assert.IsTrue(title.Contains("Series"),"Header does not contains searching term");
            else
                Assert.IsTrue(title.Contains("Collection"), "Header does not contains searching term");
        }


        [When(@"I click the down arrow to expand the content")]
        public void ClickTheDownArrowToExpandTheContent()
        {
            archSNavPgMethods.FindElementAndClick(archSNavPgObj.ContentArrow);
        }

        [Then(@"a list should drop down displaying the content within the collection")]
        public void ListShouldDropDownDisplayingTheContentWithinTheCollection()
        {
            var txt = archSNavPgMethods.FindElementGetValueAtt(archSNavPgObj.ContentDetail, "data-open");
            Assert.IsTrue(txt.Contains("true"),"There is no content after click on down arrow");
        }

        [When(@"I click on try a new search at the top of the page")]
        public void ClickOnAtTheTopOfThePage()
        {
            archSNavPgMethods.FindElementAndClick(archSNavPgObj.NewSrchLink);
        }

        [Then(@"I should be redirected back to the Archive Search page")]
        public void RedirectedBackToTheArchiveSearchPage()
        {
            var result = archSNavPgMethods.GetCurUrl();
            Assert.IsTrue(result.Contains("images-books/photos/"),"Current url is different than expected");
        }

        [Then(@"I select the tick box for '(.*)'")]
        public void SelectTheTickBoxFor(string txt)
        {
            By tickBox = archSNavPgMethods.DynamicWebElement(archSNavPgObj.TickBoxSelector, txt);
            archSNavPgMethods.FindElementAndClick(tickBox);
            archSNavPgMethods.JsScrollToPgBottom();
        }

        [Then(@"search results should display only records with online images")]
        public void SearchResultsShouldDisplayOnlyRecordsWithOnlineImages()
        {
            Assert.IsFalse(archSNavPgMethods.FindElementIsPresent(archSNavPgObj.ImagePlaceHolder,10),
                "Result element has no image");
        }

        [Then(@"I select the Series divided into child volumes field in the content section")]
        public void SelectTheSeriesDividedIntoChildVolumesFieldInTheContentSection()
        {
            heading = archSNavPgMethods.FindElementAndGetText(archSNavPgObj.SeriColHed);
            result = archSNavPgMethods.FindElementAndGetText(archSNavPgObj.SeriesChildVol);
            archSNavPgMethods.FindElementAndClick(archSNavPgObj.SeriesChildVol);
        }

        [Then(@"I am taken to a curated search results")]
        public void TakenToACuratedSearchResults()
        {
           string newHeading = archSNavPgMethods.FindElementAndGetText(archSNavPgObj.Info);
            Assert.IsTrue(newHeading.Contains(result), "Incorrect number of results");
            Assert.IsTrue(newHeading.Contains(heading), "Header does not contain expected text");
        }

    }
}
