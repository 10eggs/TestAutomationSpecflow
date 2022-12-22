using HistoricalEngland.Specs.POM;
using HistoricalEngland.Specs.StepDefinitions.ArticlePage;
using HistoricalEngland.Specs.StepDefinitions.BaseSteps;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using TechTalk.SpecFlow;

namespace HistoricalEngland.Specs.StepDefinitions.HerritagePassport
{

    [Binding]
    class HerritagePassportCreateAccSteps
    {
        private readonly IWebDriver driver;
        private readonly HerritagePassportPageObject hppo;
        private readonly HerritagePassportMethods hpm;
        private readonly HerritagePassportEditAccountSteps herrPassEditAccSteps;
        private readonly InteractionsSteps userInterfaceSteps;

        //Context variables
        private string RandomEmail;

        public HerritagePassportCreateAccSteps(IWebDriver driver, HerritagePassportPageObject hppo, HerritagePassportMethods hpm,
            HerritagePassportEditAccountSteps herrPassEditAccSteps, InteractionsSteps userInterfaceSteps)
        {
            this.driver = driver;
            this.hppo = hppo;
            this.hpm = hpm;
            this.herrPassEditAccSteps = herrPassEditAccSteps;
            this.userInterfaceSteps = userInterfaceSteps;
        }

        [Then(@"I am taken to the register page")]
        public void ThenIAmTakenToTheRegisterPage()
        {
            Thread.Sleep(2000);

            string currUrl = hpm.GetCurUrl();

            Assert.IsTrue(currUrl.Contains("/register/"),
                "User is not on register page");
            Assert.IsTrue(hpm.FindElementIsPresent(hpm.InputByText("First name")),
                "First name input is not visible");
            Assert.IsTrue(hpm.FindElementIsPresent(hpm.InputByText("Last name")),
                "Last name input is not visible");
            Assert.IsTrue(hpm.FindElementIsPresent(hpm.InputByText("Email address")),
                "Email address input is not visible");
            Assert.IsTrue(hpm.FindElementIsPresent(hpm.InputByText("Password")),
                "Password input is not visible");



            Assert.IsTrue(hpm.FindElementIsPresent(hpm.DynamicWebElement(hppo.MsgLabel,
                "I would like to receive a copy of the Historic England newsletter")),
                "Tick box is not present");
            Assert.IsTrue(hpm.FindElementIsPresent(hpm.DynamicWebElement(hppo.MsgLabel,
                "I agree to the website")),
                "Tick box is not present");

        }

        [Then(@"the page refreshes and error messages are present")]
        public void ThenThePageRefreshesAndErrorMessagesArePresent()
        {
            herrPassEditAccSteps.ThenAnErrorMessageShows("There were some errors with the form");

            herrPassEditAccSteps.ThenAnErrorMessageShows("Please enter your last name");
            herrPassEditAccSteps.ThenAnErrorMessageShows("Please enter your email address");
            herrPassEditAccSteps.ThenAnErrorMessageShows("Please enter a password. This must be at least 8 characters long");
            herrPassEditAccSteps.ThenAnErrorMessageShows("You must accept the T&C");

            Assert.IsTrue(hpm.VerifyColor(hpm.InputByText("Last name"),"Red"),
                "Element color is different than expected");

        }

        [Given(@"that I am on the register page")]
        public void GivenThatIAmOnTheRegisterPage()
        {
            userInterfaceSteps.SelectTheAnchor("Sign in");
            userInterfaceSteps.SelectTheAnchor("Create an account");
            

        }

        [When(@"I enter random email into the ""(.*)"" field")]
        public void WhenIEnterRandomEmailIntoTheField(string inputName)
        {
            RandomEmail = hpm.RandomEmail(5);
            hpm.FindElementAndEnterChars(hpm.InputByText(inputName), RandomEmail);
        }


        [Then(@"the page goes to the successful registration page")]
        public void ThenThePageGoesToTheSuccessfulRegistrationPage()
        {
            Assert.IsTrue(hpm.GetCurUrl().Contains("successful-registration/"),
                "User was not redirected to registration successful page");

            Assert.IsTrue(hpm.FindElementAndGetText(hppo.PageHeader).Contains("sent you an activation email"),
                "Header does not contain expected phrase");

        }

        [Then(@"Im back to homepage")]
        public void ThenIBackToHomepage()
        {
            driver.Navigate().GoToUrl((BasePageObjects.config.configuration["appSettings:stagingUrl"]));

        }

        [StepDefinition(@"I enter random email generated previously into the ""(.*)"" field")]
        public void WhenIEnterRandomEmailGeneratedPreviouslyIntoTheField(string inputName)
        {
            hpm.FindElementAndEnterChars(hpm.InputByText(inputName), RandomEmail);
        }



    }
}
