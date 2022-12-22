using HistoricalEngland.Specs.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System.Threading;
using HistoricalEngland.Specs.StepDefinitions.BaseSteps;

namespace HistoricalEngland.Specs.StepDefinitions.HerritagePassport
{
    [Binding]
    class HerritagePassportSignInSteps
    {
        private readonly IWebDriver driver;
        private readonly BaseMethods baseMethod;
        private readonly BasePageObjects baseObject;
        private readonly HerritagePassportPageObject hppo;
        private readonly HerritagePassportMethods hpm;
        private readonly AssertionSteps assertStep;

        public HerritagePassportSignInSteps(IWebDriver driver, HerritagePassportPageObject hppo, 
            HerritagePassportMethods hpm, AssertionSteps assertStep)
        {
            this.driver = driver;
            this.hppo = hppo;
            this.hpm = hpm;
            this.assertStep = assertStep;
        }

        [Then(@"Warning prompt is present")]
        public void ThenWarningPromptIsPresent()
        {
            string result = hpm.FindElementGetValueAtt(hpm.InputByText("Email"), "validationMessage");
            Assert.IsNotEmpty(result, "No validation message is present");

        }

        [Then(@"""(.*)"" button to show or hide password")]
        public void ThenButtonToShowOrHidePassword(string btnName)
        {
            try { hpm.PressAndHoldBtn(hppo.ShowHidePasswordBtn); }
            catch { hpm.PressAndHoldBtn(hppo.ShowHidePasswordBtn); }
            //hpm.PressAndHoldBtn(hppo.ShowHidePasswordBtn);
            hpm.CheckElementContent(hppo.ShowPasswordBtn, "Hide", "Button not held down");
            try { hpm.ReleaseBtn(hppo.ShowHidePasswordBtn); }
            catch { hpm.ReleaseBtn(hppo.ShowHidePasswordBtn); }
            //hpm.ReleaseBtn(hppo.ShowHidePasswordBtn);
            hpm.CheckElementContent(hppo.ShowPasswordBtn, "Show", "Button not released");

            //Delete below commented out code if above works in full suite run.
            //string passwordVisible = driver.FindElement(hppo.HidePasswordBtn).GetAttribute("data-password-visible");
            //Assert.IsTrue(passwordVisible.Equals("true"),
            //    "Password is not visible");

            //hpm.ReleaseBtn(hppo.ShowPasswordBtn);
            //passwordVisible = driver.FindElement(hppo.ShowPasswordBtn).GetAttribute("data-password-visible");
            //Assert.IsTrue(passwordVisible.Equals("false"),
            //    "Password is visible");
        }

        //[When(@"I get a drop down saying ""(.*)"" or ""(.*)""")]
        //public void ThenIGetADropDownSayingOr(string firstLabel, string secLabel)
        //{
        //    Assert.IsTrue(hpm.FindElementIsPresent(hpm.DynamicWebElement(hppo.MyAccountDropDownLabels, firstLabel)),
        //        firstLabel + " element is not present");

        //    Assert.IsTrue(hpm.FindElementIsPresent(hpm.DynamicWebElement(hppo.MyAccountDropDownLabels, secLabel)),
        //        secLabel + " element is not present");
        //}

        //[Then(@"I am logged out")]
        //public void ThenIAmLoggedOut()
        //{
        //    Assert.IsTrue(hpm.FindElementIsPresent(hpm.AnchorByText("Sign in")),
        //        "My account btn is not visible");
        //}

        [Given(@"that I am on a historic england list entry")]
        public void GivenThatIAmOnAHistoricEnglandListEntry()
        {
            driver.Navigate().GoToUrl("https://stage.historic-england.org/listing/the-list/list-entry/1234567");
        }

        [Then(@"I am taken back to the list entry but I am signed in and a comment box is at the bottom of the list entry")]
        public void ThenIAmTakenBackToTheListEntryButIAmSignedInAndACommentBoxIsAtTheBottomOfTheListEntry()
        {
           
            assertStep.ThenIAmLoggedIn();
            Thread.Sleep(2000);
            Assert.IsTrue(hpm.FindElementIsPresent(hppo.AddComment),
           "Element found");
            //Assert.IsTrue(hpm.GetCurUrl().Equals("https://stage.historic-england.org/listing/the-list/list-entry/1234567?section=comments-and-photos"));
            //Assert.IsTrue(baseMethod.FindElementIsPresent(baseObject.SignInTxt),
            //"Element found");


        }
        [Then(@"in place of the comment box is the ""(.*)"" button")]
        public void ThenInPlaceOfTheCommentBoxIsTheButton(string buttonName)
        {
            Assert.IsTrue(hpm.FindElementIsPresent(hpm.AnchorByText(buttonName)),
                "There is no button with this text");
            Assert.IsFalse(hpm.FindElementIsPresent(hppo.ContributeInput,15),
               "There is no contribute input field");

        }

        [StepDefinition(@"I enter text ""(.*)"" into the password field")]
        public void EnterTextIntoPasswordField(string text)
        {
            hpm.FindElementAndEnterKeys(hppo.PasswordField, text);
        }

        [StepDefinition(@"I select the Show icon")]
        public void ISelectTheShowIcon()
        {
            hpm.FindElementAndClick(hppo.PasswordIcon);
        }

        [StepDefinition(@"I can now see my text")]
        public void ICanNowSeeMyText()
        {
            //hpm.FindElementIsPresent(hppo.PasswordInputText);
            Assert.IsTrue(hpm.FindElementIsPresent(hppo.PasswordInputText),
               "I cannot see my text");
        }



    }
}
