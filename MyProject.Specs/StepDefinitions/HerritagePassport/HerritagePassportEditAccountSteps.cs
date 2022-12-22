using HistoricalEngland.Specs.Helpers;
using HistoricalEngland.Specs.POM;
using HistoricalEngland.Specs.StepDefinitions.ArticlePage;
using HistoricalEngland.Specs.StepDefinitions.BaseSteps;
using HistoricalEngland.Specs.StepDefinitions.NHLESearch;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Diagnostics;
using TechTalk.SpecFlow;
using System.Threading;

namespace HistoricalEngland.Specs.StepDefinitions.HerritagePassport
{
    [Binding]
    class HerritagePassportEditAccountSteps
    {
        private readonly IWebDriver driver;
        private readonly HerritagePassportPageObject hppo;
        private readonly HerritagePassportMethods hpm;
        private readonly HerritagePassportSignInSteps signInFeatureSteps;
        private readonly InteractionsSteps uiSteps;

        //Context var
        string randomString;
        string srcForGenericProfileImg;
        string altForGenericProfileImg;

        public HerritagePassportEditAccountSteps(IWebDriver driver,
            HerritagePassportPageObject hppo, HerritagePassportMethods hpm,
            HerritagePassportSignInSteps signInFeatureSteps,
            InteractionsSteps uiSteps)
        {
            this.driver = driver;
            this.hppo = hppo;
            this.hpm = hpm;
            this.signInFeatureSteps = signInFeatureSteps;
            this.uiSteps = uiSteps;
        }

        [Given(@"I am signed in and on the main My Account page")]
        public void GivenIAmSignedInAndOnTheMainMyAccountPage()
        {
            try
            {
                Thread.Sleep(2000);
                uiSteps.SelectTheAnchor("Sign in");
                uiSteps.IEnterTextIntoTheField("tomasz.pawlak@historicengland.org.uk", "Email");
                uiSteps.IEnterTextIntoTheField("password123456", "Password");
                uiSteps.SelectTheButton("Sign in");
            }
            catch(Exception e)
            {   
                Debug.WriteLine("User already logged");
            }


        }

        [Given(@"I navigate to My Account section")]
        public void GivenINavigateToMyAccountSection()
        {
            hpm.WaitAndJSClickElement(hpm.AnchorByText("My account"));
            //Thread.Sleep(2000);
            //uiSteps.SelectTheAnchor("My account");
            uiSteps.SelectTheAnchor("Manage my account");
        }


        [When(@"I select ""(.*)"" from the left navigation")]
        public void WhenISelectFromTheLeftNavigation(string navBar)
        {
            //hpm.JsClick(hpm.DynamicWebElement(hppo.LeftNavLabelForLoggedUser, navBar));
            hpm.WaitAndJSClickElement(hpm.DynamicWebElement(hppo.LeftNavLabelForLoggedUser, navBar));
        }

        [Then(@"I am taken to a page titled ""(.*)""")]
        public void ThenIAmTakenToAPageTitled(string title)
        {
            Assert.IsTrue(hpm.FindElementAndGetText(hppo.HpMyAccountMainTitleHeader).Equals(title));
            Assert.IsTrue(hpm.FindElementIsPresent(hpm.InputByText("First name")),
                "First name input field does not exist");
            Assert.IsTrue(hpm.FindElementIsPresent(hpm.InputByText("Last name")),
                "Last name input field does not exist");
            Assert.IsTrue(hpm.FindElementIsPresent(hpm.InputByText("Email address")),
                "Email address input field does not exist");
            Assert.IsTrue(hpm.FindElementIsPresent(hpm.ButtonByText("Save changes")),
                "Save changes button does not exist");
            Assert.IsTrue(hpm.FindElementIsPresent(hpm.AnchorByText("I would like to delete my account")),
                "Delete account button does not exist");

        }
        [Then(@"the ""(.*)"" button is not clickable")]
        public void ThenTheButtonIsNotClickable(string btnName)
        {
            Assert.IsFalse(driver.FindElement(hpm.ButtonByText(btnName)).Enabled,
                "Button is clickable");
        }

        [When(@"I click in the ""(.*)"" field")]
        public void WhenIClickInTheField(string inputName)
        {
            hpm.JsClick(hpm.InputByText(inputName));
        }

        [When(@"make a change in the ""(.*)"" field")]
        public void WhenMakeAChangeInTheField(string inputName)
        {
            randomString = BaseMethods.RandomString(5);
            driver.FindElement(hpm.InputByText(inputName)).Clear();
            hpm.FindElementAndEnterKeys(hpm.InputByText(inputName), randomString);
        }

        [Then(@"the ""(.*)"" button is clickable")]
        public void ThenTheButtonIsClickable(string btnName)
        {
            Assert.IsTrue(driver.FindElement(hpm.ButtonByText(btnName)).Enabled,
                "Button is disabled");

        }
        
        [Then(@"the page refreshes with the new change showing in ""(.*)"" field")]
        public void ThenThePageRefreshesWithTheNewChangeShowingInField(string inputName)
        {
            string textFromInput = hpm.FindElementGetValueAtt(hpm.InputByText(inputName), "value");
            Assert.IsTrue(randomString.Equals(textFromInput),
                "Text has not been changed or it's not equal to expected one");

        }

        [When(@"I delete the text in the ""(.*)"" field")]
        public void WhenIDeleteTheTextInTheField(string inputName)
        {
            driver.FindElement(hpm.InputByText(inputName)).Clear();
        }

        [Then(@"an error message shows ""(.*)""")]
        public void ThenAnErrorMessageShows(string errorMsg)
        {
            Thread.Sleep(3000);
            Assert.IsTrue(hpm.FindElementIsPresent(hpm.DynamicWebElement(hppo.MsgLabel, errorMsg)),
                "Error message is different than expected one");
        }
        [Given(@"that I am on the personal information page")]
        public void GivenThatIAmOnThePersonalInformationPage()
        {
            uiSteps.SelectTheAnchor("My account");
            uiSteps.SelectTheAnchor("Manage my account");
            hpm.JsClick(hpm.DynamicWebElement(hppo.LeftNavLabelForLoggedUser, "Personal Information"));

        }

        [Then(@"I am taken to the delete account section")]
        public void ThenIAmTakenToTheDeleteAccountSection()
        {
            Thread.Sleep(2000);
            Assert.IsTrue(hpm.GetCurUrl().Contains("delete-account"),
                "Redirected to wrong url");
            Assert.IsTrue(hpm.FindElementIsPresent(hpm.InputByText("Password")),
                "Element not present");
            Assert.IsTrue(hpm.FindElementIsPresent(hpm.ButtonByText("Delete my account")),
                "Delete my account btn is not present");
            Assert.IsTrue(hpm.FindElementIsPresent(hpm.AnchorByText("Cancel")),
                "Cancel btn is not present");
        }
        [Then(@"page returns to the personal information section")]
        public void ThenPageReturnsToThePersonalInformationSection()
        {
            Assert.IsTrue(hpm.GetCurUrl().Contains("personal-information"),
                "Redirected to wrong url");

        }

        [StepDefinition(@"the page returns me to the About Us page")]
        public void ThePageReturnsMeToTheAboutUsPage()
        {
            Thread.Sleep(2000);
            Assert.IsTrue(hpm.GetCurUrl().Contains("about"),
                 "Redirected to wrong url");
        }

        [StepDefinition(@"the page returns me to the Home Page")]
        public void ThePageReturnsMeToTheHomePage()
        {
            Thread.Sleep(2000);
            Assert.IsTrue(hpm.FindElementIsPresent(hppo.HomePageCon),
            "There is no Home Page Container");


        }


        [Then(@"I am taken to a page ""(.*)""")]
        public void ThenIAmTakenToAPage(string title)
        {
            Assert.IsTrue(hpm.FindElementAndGetText(hppo.HpMyAccountMainTitleHeader).Equals(title));
            Assert.IsTrue(hpm.FindElementIsPresent(hppo.AboutMeInput),
                @"There is no 'About me' input present");
            Assert.IsTrue(hpm.FindElementIsPresent(hppo.AvatarImg),
                "There is no avatar image present");
            Assert.IsTrue(hpm.FindElementIsPresent(hppo.AddProfilePhotoLabel),
                @"There is no 'Add profile photo' button present");
            Assert.IsTrue(hpm.FindElementIsPresent(hpm.InputByText("Organisation")),
                "There is no organisation input present");
            Assert.IsTrue(hpm.FindElementIsPresent(hppo.OrganizationLabel),
                "There is no organization tick box present");
            Assert.IsTrue(hpm.FindElementIsPresent(hppo.HidePublicProfilLabel),
                @"There is no 'Hide public profile label' present");
        }

        [When(@"I am on the ""(.*)"" tab")]
        public void WhenIAmOnTheTab(string tabName)
        {
            Thread.Sleep(2000);
            WhenISelectFromTheLeftNavigation(tabName);
        }


        [When(@"I add text into ""(.*)"" input")]
        public void WhenIAddTextIntoInput(string inputName)
        {
            driver.FindElement(hpm.DynamicWebElement(hppo.PublicProfileInput,inputName)).Clear();
            randomString = BaseMethods.RandomString(8);
            hpm.FindElementAndEnterKeys(hpm.DynamicWebElement(hppo.PublicProfileInput, inputName), randomString);
        }
        [Then(@"the page refreshes and can see my text in the ""(.*)"" input")]
        public void ThenThePageRefreshesAndCanSeeMyTextInTheInput(string inputName)
        {
            Thread.Sleep(2000);
            string inputValue = hpm.CaptureValueFromPublicProfileInputs(inputName);
            Thread.Sleep(2000);
            Assert.IsTrue(inputValue.Equals(randomString),
                "New input value has not been saved");
        }

        [Then(@"when I navigate to ""(.*)""")]
        public void ThenWhenINavigateTo(string url)
        {
            hpm.NavigateToUrl(url);
        }

        [Then(@"the text added to ""(.*)"" matches the public profile")]
        public void ThenTheTextAddedToMatchesThePublicProfile(string inputName)
        {
			Assert.IsTrue(hpm.FindElementAndGetText(hppo.AboutMePublicProfileField).Equals(randomString),
				@"Text saved in 'My account' section is not equal to text from public profile page");

			//Assert.IsTrue(hpm.FindElementAndGetText(hpm.DynamicWebElement(hppo.AboutMeField, inputName)),
   //           "Text saved in 'My account' section is not equal to text from public profile page");
        }

        [When(@"I click to add a photo")]
        public void WhenIClickToAddAPhoto()
        {
            hpm.FindElementAndClick(hppo.AddProfilePhotoBtn);

        }

        [When(@"select photo to add")]
        public void WhenSelectPhotoToAdd()
        {
            srcForGenericProfileImg = hpm.FindElementGetValueAtt(hppo.AvatarImg, "src");
            altForGenericProfileImg = hpm.FindElementGetValueAtt(hppo.AvatarImg, "alt");
            hpm.FindElementAndEnterKeys(hppo.AddProfilePhotoBtn,ProjectPath.getProjectPath()+@"\Helpers\Images\random.jpg");

        }
        [Then(@"the photo preview changes in the window")]
        public void ThenThePhotoPreviewChangesInTheWindow()
        {

            string srcForCustomizedProfileImg = hpm.FindElementGetValueAtt(hppo.AvatarImg, "src");
            string altForCustomizedProfileImg = hpm.FindElementGetValueAtt(hppo.AvatarImg, "alt");
            Assert.AreNotEqual(srcForGenericProfileImg, srcForCustomizedProfileImg,
                "Profile img has not been changed");
            Assert.AreNotEqual(altForCustomizedProfileImg,"Generic profile image",
                "Profile img has not been changed");
            
        }

        [Then(@"the avatar changes to generic one")]
        public void ThenTheAvatarChangesToGenericOne()
        {

            Thread.Sleep(2000);
            srcForGenericProfileImg = hpm.FindElementGetValueAtt(hppo.AvatarImg, "src");
            altForGenericProfileImg = hpm.FindElementGetValueAtt(hppo.AvatarImg, "alt");
            Assert.IsTrue(srcForGenericProfileImg.Contains("genericavatar"),
                "Profile img is not generic one");
            Assert.IsTrue(altForGenericProfileImg.Equals("Generic profile image"),
                "Profile img is not generic one");
        }

        [Then(@"the image shows on the profile page")]
        public void ThenTheImageShowsOnTheProfilePage()
        {
			Assert.IsTrue(hpm.FindElementGetValueAtt(hppo.AvatarImgPublicPage, "src").Contains("random.jpg"),
				"User avatar has not been added");
			//Assert.IsTrue(hpm.FindElementIsPresent(hppo.ElephantProfileImage),
			//  "User avatar has not been added");

		}

        [Then(@"the default image shows on the profile page")]
        public void ThenTheDefaultImageShowsOnTheProfilePage()
        {
			Assert.IsTrue(hpm.FindElementGetValueAtt(hppo.AvatarImgPublicPage, "src").Contains("genericavatar"),
				"User avatar is not generic one");
			//Assert.IsTrue(hpm.FindElementIsPresent(hppo.DefaultProfileImage),
			//  "User avatar has not been added");
		}
        [When(@"I enter random text into the ""(.*)"" field")]
        public void WhenIEnterRandomTextIntoTheField(string inputName)
        {
            randomString = BaseMethods.RandomString(7);
            hpm.FindElementAndEnterChars(hpm.InputByText(inputName), randomString);

        }
        [Then(@"the information on ""(.*)"" present on Historic England website")]
        public void ThenInformationsPresentOnHistoricEnglandWebsite(string condition)
        {
            Thread.Sleep(4000);
            if (condition.Equals("are not")) 
            {
                // change to hppo.recordheaderfound and "Page not found" when debugger turned off
                Assert.IsTrue(hpm.FindElementAndGetText(hppo.HiddenPageTitle).Contains("HTTP ERROR 404"),
                "Informations are present on Historic England website");
            }
            else if(condition.Equals("are"))
            {
                // change to hppo.recordheaderfound and "Page not found" when debugger turned off
                Assert.IsTrue(hpm.FindElementAndGetText(hppo.RecordsHeaderFound).Contains("Comments and Photos"),
                                "Informations are present on Historic England website");
            }

            else
            {
                throw new ArgumentException("Check if argument passed in .feature file is correct");
            }
            
        }

        [When(@"I use the ""(.*)"" key on my keyboard to reach ""(.*)""")]
        public void WhenIUseTheKeyOnMyKeyboardToReach(string key, string elementName)
        {
            Thread.Sleep(1000);
            Actions act = new Actions(driver);
            act.SendKeys(Keys.Tab);


            IWebElement elem = null;

            do
            {
                act.Perform();
                elem = driver.SwitchTo().ActiveElement();
                Debug.WriteLine("Text from an element: " + elem.Text);

            }
            while (!elem.Text.Contains(elementName));

        }

        [When(@"I tab to the ""(.*)"" input")]
        public void WhenITabToTheInput(string inputId)
        {
            Actions act = new Actions(driver);
            act.SendKeys(Keys.Tab);


            IWebElement elem = null;

            do
            {
                act.Perform();
                elem = driver.SwitchTo().ActiveElement();
                Debug.WriteLine("Text from an element: " + elem.Text);

            }
            while (!elem.GetAttribute("id").Equals(inputId));

        }

        [When(@"I press ""(.*)""")]
        public void WhenIPress(string key)
        {
            Actions act = new Actions(driver);
            act.SendKeys(Keys.Enter);
            act.Perform();
        }

        [When(@"I am taken to the Change Password page")]
        public void WhenIAmTakenToTheChangePasswordPage()
        {
            Thread.Sleep(3000);
            Assert.IsTrue(hpm.FindElementIsPresent(hpm.InputByText("Current password")),
                "Current password field is not present");
            Assert.IsTrue(hpm.FindElementIsPresent(hpm.InputByText("New password")),
                "New password field is not present");
            Assert.IsTrue(hpm.FindElementIsPresent(hpm.InputByText("Confirm password")),
                "Confirm password field is not present");
            Assert.IsTrue(hpm.FindElementIsPresent(hpm.ButtonByText("Change password")),
                "Change password button is not present");
            Assert.IsTrue(hpm.GetCurUrl().Contains("change-password"),
                "Url has not been changed");

        }

        [Then(@"the page refreshes and text appears below the title saying ""(.*)""")]
        public void ThenThePageRefreshesAndTextAppearsBelowTheTitleSaying(string labelText)
        {
            Assert.IsTrue(hpm.FindElementIsPresent(hpm.DynamicWebElement(hppo.PassChangedField,labelText)),
                "There is no information about password change");
        }

        [When(@"all expected fields are present")]
        public void WhenAllExpectedFieldsArePresent()
        {
            Thread.Sleep(2000);
            Assert.IsTrue(hpm.FindElementAndGetText(hppo.SubHeaderField).Contains("Newsletter Subscription"),
                "Header does not contain expected text");

        }

        [Then(@"the page refreshes and the button text changes to ""(.*)""")]
        public void ThenThePageRefreshesAndTheButtonTextChangesTo(string buttonName)
        {
            Assert.IsTrue(hpm.FindElementIsPresent(hpm.ButtonByText(buttonName)),
               "There is no button with expected text");

        }

        [StepDefinition(@"I select the HP ""(.*)"" button")]
        public void ISelectTheHPButton(string p0)
        {
            hpm.FindElementAndClick(hppo.SubscribeBtn);

    }

        [StepDefinition(@"the page refreshes and the HP Unsubscribe button changes to ""(.*)""")]
        public void ThePageRefreshesAndTheHPButtonChangesTo(string BtnTxt)
        //public void ThePageRefreshesAndTheHPButtonChangesTo(string p0)
        {
            //Assert.IsTrue(hpm.FindElementIsPresent(hppo.SubText),
            //             "There is no button with expected text");

            Assert.IsTrue(hpm.FindElementIsPresent(hpm.DynamicWebElement(hppo.SubText, BtnTxt)),
            "There is no information about password change");
        }

        [StepDefinition(@"the page refreshes and the HP Subscribe button changes to ""(.*)""")]
        public void ThePageRefreshesAndTheHPSubscribeButtonChangesTo(string BtnTxt)
        {
            //Assert.IsTrue(hpm.FindElementIsPresent(hppo.UnSubText),
            //             "There is no button with expected text");

            Assert.IsTrue(hpm.FindElementIsPresent(hpm.DynamicWebElement(hppo.SubText, BtnTxt)),
           "There is no information about password change");

        }


        [Then(@"alert is dismissed")]
        public void ThenAlertIsDismissed()
        {
            Debug.WriteLine("Alert txt: " + driver.SwitchTo().Alert().Text);
            driver.SwitchTo().Alert().Accept();


        }

        [Then(@"the error message """"(.*)"" is now gone")]
        public void ThenTheErrorMessageIsNowGone(string errorMsg)
        {
            Thread.Sleep(4000);
            Assert.IsFalse(hpm.FindElementIsPresent(hpm.DynamicWebElement(hppo.MsgLabel, errorMsg)),
             "Error message is no longer showing");
        }

    [Then(@"I am checking that Newsletter is not subscribed already")]
        public void ThenIAmCheckingThatNewsletterIsNotSubscribedAlready()
        {
            string buttonName = "Unsubscribe!";

            try
            {
                hpm.JsClick(hpm.DynamicWebElement(hppo.ButtonByText, buttonName));
                
            }
            catch
            {
                return;
            }

        }
    }
}
