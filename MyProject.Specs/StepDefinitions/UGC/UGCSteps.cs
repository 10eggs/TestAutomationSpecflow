using HistoricalEngland.Specs.Helpers;
using HistoricalEngland.Specs.POM;
using HistoricalEngland.Specs.StepDefinitions.BaseSteps;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.Threading;
using TechTalk.SpecFlow;

namespace HistoricalEngland.Specs.StepDefinitions.UGC
{
    [Binding]
    class UGCSteps
    {
        private readonly UGCPageObjects ugcpo;
        private readonly UGCMethods ugcm;
        private readonly IWebDriver driver;
        private readonly AssertionSteps assertStep;
        private readonly InteractionsSteps uiSteps;

        //Context var
        string randomString;
        string altForNewImageComment;
        string hrefForYouTubeVideo;
        string classForActiveOptionsModal;
        string classForInactiveOptionsModal;
        string lightboxGalleryImageNumber;
        string altForGalleryImage;

        public UGCSteps(IWebDriver driver, UGCPageObjects ugcpo, UGCMethods ugcm, AssertionSteps assertStep, InteractionsSteps uiSteps)
        {
            this.driver = driver;
            this.ugcpo = ugcpo;
            this.ugcm = ugcm;
            this.assertStep = assertStep;
            this.uiSteps = uiSteps;
        }

        [StepDefinition(@"I have signed in as an unmoderated user")]
        public void SignedInAsUnmoderatedUser()
        {
            try { uiSteps.SelectTheAnchor("Sign in"); }
            catch { SignOut();
                  uiSteps.SelectTheAnchor("Sign in"); }
            assertStep.ThenIAmRedirectToSignInPage();
            uiSteps.IEnterTextIntoTheField("DigitalAutomatedTesting@historicengland.org.uk", "Email");
            uiSteps.IEnterTextIntoTheField("password123456", "Password");
            uiSteps.SelectTheButton("Sign in");
            assertStep.ThenIAmLoggedIn();
        }

        [StepDefinition(@"I have signed in as a moderated user")]
        public void SignedInAsModeratedUser()
        {
            try { uiSteps.SelectTheAnchor("Sign in"); }
            catch { SignOut();
                  uiSteps.SelectTheAnchor("Sign in"); }
            assertStep.ThenIAmRedirectToSignInPage();
            uiSteps.IEnterTextIntoTheField("Daniel.Ellison@historicengland.org.uk", "Email");
            uiSteps.IEnterTextIntoTheField("password123456", "Password");
            uiSteps.SelectTheButton("Sign in");
            assertStep.ThenIAmLoggedIn();
        }

        [StepDefinition(@"I have signed in as an unmoderated social media user")]
        public void SignedInAsUnmoderatedSocialMediaUser()
        {
            try { uiSteps.SelectTheAnchor("Sign in"); }
            catch { SignOut();
                  uiSteps.SelectTheAnchor("Sign in"); }
            assertStep.ThenIAmRedirectToSignInPage();
            uiSteps.IEnterTextIntoTheField("he-testing@HistoricEngland.org.uk", "Email");
            uiSteps.IEnterTextIntoTheField("password123456", "Password");
            uiSteps.SelectTheButton("Sign in");
            assertStep.ThenIAmLoggedIn();
        }

        [StepDefinition(@"I sign out")]
        public void SignOut()
        {
            uiSteps.SelectTheAnchor("My account");
            assertStep.ThenIGetADropDownSayingOr("Manage my account", "Sign out");
            uiSteps.SelectTheAnchor("Sign out");
            //assertStep.ThenIAmLoggedOut();
        }

        [StepDefinition(@"I have typed out the comment ""(.*)""")]
        public void TypeOutAComment(string comment)
        {
            uiSteps.SelectTheButton("Add your comment");
            EnterTextAndStringIntoCommentBox(comment);
        }

        [StepDefinition(@"I want to upload an image and have typed out the comment ""(.*)""")]
        public void TypeOutACommentAndUploadImage(string comment)
        {
            uiSteps.SelectTheButton("Add your comment");
            EnterTextAndStringIntoCommentBox(comment);
            uiSteps.SelectTheButton("Add your photos");
            uiSteps.SelectTheButton("Add a photo (1 of 4)");
        }

        [StepDefinition(@"I refresh and check the new comment is at the top of the page")]
        public void RefreshAndCheckTopComment()
        {
            uiSteps.IRefreshThePage();
            ThenTheNewCommentIsAtTheTopOfThePage();
            SignOut();
        }

        [StepDefinition(@"I refresh and check the new comment and image are at the top of the page")]
        public void RefreshAndCheckTopCommentAndImage()
        {
            uiSteps.IRefreshThePage();
            ThenTheNewCommentIsAtTheTopOfThePage();
            CheckImageAltText();
            SignOut();
        }

        [StepDefinition(@"I close the add contribution modal")]
        public void CloseTheAddContributionModal()
        {
            Thread.Sleep(1000);
            ugcm.FindElementAndClick(ugcpo.CloseModalBtn);
        }

        [StepDefinition(@"The oldest comment ""(.*)"" is at the top of the page")]
        public void ThenTheOldestCommentIsAtTheTopOfThePage(string oldComment)
        {
            ugcm.CheckElementContent(ugcpo.TopComment, oldComment, "Top comment does not contain expected text");
        }

        [StepDefinition(@"I enter text ""(.*)"" and string into the comment box")]
        public void EnterTextAndStringIntoCommentBox(string comment)
        {
            randomString = BaseMethods.RandomString(5);
            ugcm.WaitAndEnterKeys(ugcpo.CommentBox, comment + " " + randomString);
        }

        [StepDefinition(@"I submit my comment for approval")]
        public void SubmitCommentForApproval()
        {
            try { Thread.Sleep(1000);
                  ugcm.WaitAndJSClickElement(ugcpo.SubmitForApprovalBtn); }
            catch { Thread.Sleep(2000);
                    ugcm.WaitScrollAndClickElement(ugcpo.SubmitForApprovalBtn); }
            assertStep.ElementIsPresent("Thank you");
            try { ugcm.WaitAndClickElement(ugcpo.CloseThankYouWindowBtn); }
            catch { ugcm.FindElementAndClick(ugcpo.AcceptCookie);
                    ugcm.FindElementAndClick(ugcpo.CloseThankYouWindowBtn); }
        }

        [StepDefinition(@"The new comment is at the top of the page")]
        public void ThenTheNewCommentIsAtTheTopOfThePage()
        {
            Thread.Sleep(3000);
            ugcm.CheckElementContent(ugcpo.TopComment, randomString, "Top comment does not contain expected text");
        }

        [StepDefinition(@"The new comment is at the top of the page and pending approval after refreshing")]
        public void ThenTheNewCommentIsPendingApproval()
        {
            uiSteps.IRefreshThePage();
            ThenTheNewCommentIsAtTheTopOfThePage();
            ugcm.CheckElementContent(ugcpo.TopComment, "Pending Approval", "Top comment does not contain expected text");
        }

        [StepDefinition(@"The comment no longer shows after signing out")]
        public void ThenTheCommentNoLongerShowsAfterSignOut()
        {
            SignOut();
            Thread.Sleep(2000);
            ugcm.CheckElementContent(ugcpo.NumberOfComments, "There are 0 comments", "Unexpected number of comments");
            ugcm.CheckElementContent(ugcpo.NoCommentsLabel, "There aren't any comments", "Comments appear to be present");
        }

        [StepDefinition(@"Select the ""(.*)"" image to upload")]
        public void SelectSpecificImageToUpload(string imageName)
        {
            ugcm.FindElementAndEnterKeys(ugcpo.ChooseFromDeviceUploadBtn, ProjectPath.getProjectPath() + @"\Helpers\Images\" + imageName + ".jpg");
            Thread.Sleep(3000);
            ugcm.CloseFileExplorer();
        }

        [When(@"I select the minus icon")]
        public void WhenISelectTheMinusIcon()
        {
            ugcm.JsClick(ugcpo.MinusIcon);
        }

        [Then(@"the icon changes to a plus and the box closes")]
        public void ThenTheIconChangesToAPlusAndTheBoxCloses()
        {
            //Thread.Sleep(1000);
            ugcm.FindElementIsPresent (ugcpo.PlusIcon);
        }


        [StepDefinition(@"I enter the text ""(.*)"" and string in the alt text box")]
        public void EnterTextIntoAltTextBox(string altText)
        {
            Thread.Sleep(3000);
            ugcm.FindElementAndEnterKeys(ugcpo.ImageAltTextBox, altText + " " + randomString);
            Thread.Sleep(3000);
        }

        [StepDefinition(@"I enter the text ""(.*)"" and number in the alt text box for image ""(.*)""")]
        public void EnterTextIntoSpecifiedAltTextBox(string altText, string imageNumber)
        {
            ugcm.FindElementAndEnterKeys((ugcm.DynamicWebElement(ugcpo.ImageAltTextBoxes, imageNumber)), altText + " Alt text for image " + imageNumber);
        }

        [StepDefinition(@"I add the selected image")]
        public void AddSelectedImage()
        {
            ugcm.WaitAndClickElement(ugcpo.AddImageBtn);
        }

        [StepDefinition(@"The new image contains the correct alt text")]
        public void CheckImageAltText()
        {
            altForNewImageComment = ugcm.FindElementGetValueAtt(ugcpo.TopCommentImage, "alt");
            Assert.IsTrue(altForNewImageComment.Contains(randomString), "Unexpected alt text");
        }

        [StepDefinition(@"Copy in the URL ""(.*)""")]
        public void CopyInYouTubeURL(string youtubeURL)
        {
            ugcm.FindElementAndEnterKeys(ugcpo.YouTubeURLBox, youtubeURL);
        }

        [StepDefinition(@"The video ""(.*)"" is at the top of the page")]
        public void CheckYouTubeVideoPosted(string youtubeURL)
        {
            hrefForYouTubeVideo = ugcm.FindElementGetValueAtt(ugcpo.YouTubeVideoLink, "href");
            Assert.AreEqual(hrefForYouTubeVideo, youtubeURL, "Top comment does not contain correct YouTube video");
        }

        [StepDefinition(@"I select the options icon")]
        public void SelectOptionsIcon()
        {
            ugcm.WaitAndClickElement(ugcpo.OptionsBtn);
            classForActiveOptionsModal = ugcm.FindElementGetValueAtt(ugcpo.OptionsDropdownMenu, "class");
        }
                   
        [StepDefinition(@"The options menu closes")]
        public void AssertOptionsMenuCloses()
        {
            classForInactiveOptionsModal = ugcm.FindElementGetValueAtt(ugcpo.OptionsDropdownMenu, "class");
            Assert.AreNotEqual(classForActiveOptionsModal, classForInactiveOptionsModal, "Options menu appears to still be open");
        }

        [StepDefinition(@"The edited comment is at the top of the page")]
        public void AssertEditedCommentAtTopOfPage()
        {
            Thread.Sleep(3000);
            ugcm.CheckElementContent(ugcpo.TopComment, "this is an edit", "Top comment does not contain edited text");
        }

        [StepDefinition(@"I submit my comment edit")]
        public void SubmitCommentEdit()
        {
            ugcm.JsClick(ugcpo.SubmitEditBtn);
            Thread.Sleep(2000);
        }


        [StepDefinition(@"Check image ""(.*)"" has successfully uploaded")]
        public void CheckMultiImageUploaded(string imageNumber)
        {
            altForNewImageComment = ugcm.FindElementGetValueAtt((ugcm.DynamicWebElement(ugcpo.TopCommentMultiImage, imageNumber)), "alt");
            Assert.IsTrue(altForNewImageComment.Contains(" Alt text for image " + imageNumber), 
                "Top comment does not contain expected alt text for image " + imageNumber);
        }

        [StepDefinition(@"I close the file explorer window")]
        public void CloseFileExplorerWindow()
        {
            ugcm.CloseFileExplorer();
        }

        [StepDefinition(@"I click the play button on the YouTube video in the top comment")]
        public void PlayYouTubeVideo()
        {
            ugcm.WaitAndClickElement(ugcpo.YouTubePlayBtn);
        }

        [StepDefinition(@"The YouTube video begins to play")]
        public void CheckYouTubeVideoPlaying()
        {
            //Add logs to describe what is happening with steps (i.e. here - waiting 3 seconds for video to load).
            Thread.Sleep(3000);
            Assert.IsTrue(ugcm.FindElementIsPresent(ugcpo.YouTubeVideoPlaying), "YouTube video does not appear to be playing");
        }

        [StepDefinition(@"I wait for page to load and click the ""(.*)"" anchor")]
        public void WaitAndClickSpecificAnchor(string anchor)
        {
            ugcm.WaitScrollAndClickElement(ugcm.AnchorByText(anchor));
        }

        [StepDefinition(@"I select the ""(.*)"" tab from the image upload menu")]
        public void SelectImageUploadMenuTab(string tab)
        {
            ugcm.WaitAndClickElement(ugcm.DynamicWebElement(ugcpo.ImageUploadMenuTab, tab));
        }

        [StepDefinition(@"I select the continue with ""(.*)"" button")]
        public void ContinueToSocialMedia(string socialMedia)
        {
            driver.SwitchTo().ParentFrame();
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src, '" + socialMedia + "')]")));
            ugcm.WaitAndClickElement(ugcm.DynamicWebElement(ugcpo.ContinueToSocialMediaBtn, socialMedia));
            driver.SwitchTo().DefaultContent();
        }

        [StepDefinition(@"I enter ""(.*)"" into the ""(.*)"" field to sign in")]
        public void SignInToSocialMedia(string field, string signIn)
        {
            ugcm.FindElementAndEnterChars((ugcm.DynamicWebElement(ugcpo.SocialMediaSignInFields, field)), signIn);
        }

        [StepDefinition(@"I sign in to Facebook")]
        public void SignInToFacebook()
        {
            //Switch to new tab
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            SignInToSocialMedia("email", "DigitalAutomatedTesting@HistoricEngland.org.uk");
            SignInToSocialMedia("pass", "Tester123456");
            uiSteps.SelectTheButton("Log In");
            //Switch back
            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }

        [StepDefinition(@"I sign in to Instagram")]
        public void SignInToInstagram()
        {
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            try { uiSteps.SelectTheButton("Allow essential and optional cookies"); }
            catch { uiSteps.SelectTheButton("Allow Essential and Optional Cookies"); }
            SignInToSocialMedia("username", "DigitalAutomatedTesting@HistoricEngland.org.uk");
            SignInToSocialMedia("password", "Tester123456");
            uiSteps.ThenISelectElement("Log In");
            try   { try { uiSteps.SelectTheButton("Save Info"); }
                  catch { ugcm.WaitScrollAndClickElement(ugcm.ButtonByText("Save Info")); } }
            catch { try { uiSteps.SelectTheButton("Save information"); }
                  catch { ugcm.WaitScrollAndClickElement(ugcm.ButtonByText("Save information")); } }
              //Thread.Sleep(1000);
            ugcm.WaitAndClickElement(ugcpo.InstagramAllowAccessBtn);
            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }

        [StepDefinition(@"I select an image from the ""(.*)"" album")]
        public void SelectFacebookAlbum(string albumName)
        {
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src, 'facebook')]")));
            ugcm.WaitAndClickElement(ugcm.DynamicWebElement(ugcpo.FacebookAlbum, albumName));
            ugcm.WaitAndClickElement(ugcm.DynamicWebElement(ugcpo.FacebookAlbum, ""));
            driver.SwitchTo().DefaultContent();
        }

        [StepDefinition(@"I select the ""(.*)"" image")]
        public void SelectInstagramImage(string imageTitle)
        {
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src, 'instagram')]")));
            ugcm.WaitAndClickElement(ugcm.DynamicWebElement(ugcpo.FacebookAlbum, imageTitle));
            driver.SwitchTo().DefaultContent();
        }

        [StepDefinition(@"I select a gallery image")]
        public void SelectGalleryImage()
        {
            ugcm.JsScrollToPgBottom();
            //uiSteps.ISelectTheBack_To_TopButton();
            ugcm.JavaScriptScroll(ugcpo.SignInToReplyAnchor);
            ugcm.FindElementAndClick(ugcpo.GalleryImage);
        }

        [StepDefinition(@"I am taken to a lightbox gallery view")]
        public void CheckInLightboxGalleryView()
        {
            ugcm.FluentWaitCall(ugcpo.LightBoxGalleryImage);
            Assert.IsTrue(ugcm.FindElementIsPresent(ugcpo.LightBoxGalleryImage), "Lightbox gallery view is not present");
        }

        [StepDefinition(@"I select the cross at the top right of the lightbox")]
        public void SelectLightboxGalleryClose()
        {
            ugcm.WaitAndClickElement(ugcpo.CloseLightboxGalleryBtn);
        }

        [StepDefinition(@"The gallery closes and I am back on the page")]
        public void CheckNotInLightboxGalleryView()
        {
            Thread.Sleep(3000);
            ugcm.JsScrollToPgBottom();
            Assert.IsFalse(ugcm.FindElementIsPresent(ugcpo.LightBoxGalleryImage), "Lightbox gallery view is still present");
        }

        [StepDefinition(@"I select the next arrow on the right of the screen")]
        public void SelectNextImageInLighboxGallery()
        {
            lightboxGalleryImageNumber = ugcm.FindElementAndGetText(ugcpo.LightBoxImageNumber);
            ugcm.FindElementAndClick(ugcpo.LightBoxNextArrowBtn);
        }

        [StepDefinition(@"I select the grid icon at the top of the lightbox")]
        public void ISelectTheGridIconAtTheTopOfTheLightbox()
        {
            ugcm.WaitAndClickElement(ugcpo.LightBoxGrid);
        }

        [StepDefinition(@"I select a different image from the thumbnail options")]
        public void ISelectADifferentImageFromTheThumbnailOptions()
        {
            
            ugcm.WaitAndClickElement(ugcpo.ThumbnailList);
        }

        [StepDefinition(@"I am taken to that different image")]
        public void IAmTakenToThatDifferentImage()
        {
            lightboxGalleryImageNumber = ugcm.FindElementAndGetText(ugcpo.LightBoxImageNumber);
        }


        [StepDefinition(@"I am taken to the next image")]
        public void CheckOnNextGalleryImage()
        {
            string imageNumber = ugcm.FindElementAndGetText(ugcpo.LightBoxImageNumber);
            Assert.IsFalse(lightboxGalleryImageNumber.Equals(imageNumber),
                "Image has not been changed or number label is different than expected.");
        }

        [StepDefinition(@"I select ""(.*)"" from the status drop down")]
        public void ISelectFromTheStatusDropDown(string drpDwnTxt)
        {
            ugcm.WaitAndClickElement(ugcpo.StatusDrpDwn);
            ugcm.WaitAndClickElement(ugcpo.EditStatus);
        }


        [StepDefinition(@"the comment ""(.*)"" is present")]
        public void TheCommentIsPresent(string commentText)
        {
            //Thread.Sleep(3000);
            ugcm.CheckElementContent(ugcpo.TopComment, commentText, "Top comment does not contain expected text");
        }


    }
}
