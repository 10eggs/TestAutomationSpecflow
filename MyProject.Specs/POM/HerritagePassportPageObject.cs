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

namespace HistoricalEngland.Specs.POM
{
    class HerritagePassportPageObject : BasePageObjects

    {
        //TextField
        public By EmailErrorMsg = By.XPath("//div[@id='username-error-msg']");
        public By HpMyAccountMainTitleHeader = By.XPath("//h2[@class='hp-my-account__main-title']");
        //public By AboutMePublicProfileField = By.XPath("//div[@class='userProfileContent']/p[@class='commentText']");
        public By AboutMePublicProfileField = By.XPath("(//p)[11]");
        //public By AboutMePublicProfileField = By.PartialLinkText("");
        public By SubHeaderField = By.XPath("(//h2)[1]");
        public By CurrentPasswordErrorMsg = By.XPath("//div[@class='validation-summary-errors hp-my-account__form-validation-msg hp-my-account__form-validation-msg--backend']");
        public string ConfirmPasswordErrorMsg = "//div[contains(@id,'error-msg') and contains(text(),'{var}')]";
        public string ErrorMsgField = "//*[contains(text(),'{var}')]";
        public string PassChangedField = "//span[contains(text(),'{var}')]";
        //public string AboutMeField = "//*[contains(text(),'{var}')]";
        public By PasswordField = By.XPath("//input[@id='registerModel_Password']");
        public By PasswordIcon = By.XPath("//span[@class='password-toggle__icon']");
        //public By PasswordInputText = By.XPath("//input=");
        //public By PasswordInputText = By.XPath("//input[@value='true']");
        public By PasswordInputText = By.XPath("//input[@type='text']");

        //Btn
        public By ShowHidePasswordBtn = By.XPath("//button[@id='show-password-button']");
        public By ShowPasswordBtn = By.XPath("//span[@id='show-password-label']");
        public By AddProfilePhotoBtn = By.XPath("//input[@id='publicProfileModel_ImageList']");
        public By SubscribeBtn = By.XPath("//button[@class='hp-my-account__form-button']");
        //public By SubText = By.PartialLinkText("Subscribe");
        public By UnSubText = By.PartialLinkText("Unsubscribe");
        public string SubText = "//button[contains(text(),'{var}')]";
        public By HomePageTitle = By.PartialLinkText("The Most Important Historic Places in England Are Listed");
        public By HomePageCon = By.XPath("//div[@class='homepage-section__container']");
        //Labels
        public string MsgLabel = "//*[contains(text(),'{var}')]";
        public string MyAccountDropDownLabels = "//li[@class='header-bar__hp-link-account-links-list-item']/a[contains(text(),'{var}')]";
        //public string LeftNavLabelForLoggedUser = "//nav[@class='hp-my-account__navigation-container']/ul/li/a[contains(text(),'{var}')]";
        public string LeftNavLabelForLoggedUser = "//a[contains(text(),'{var}')]";
        public By OrganizationLabel = By.XPath("//label[@for='publicProfileModel_UseOrganisation']");
        public By HidePublicProfilLabel = By.XPath("//label[@for='publicProfileModel_IsPublicProfileHidden']");
        public By AddProfilePhotoLabel = By.XPath("//label[@id='add-profile-photo-label']");
        //TickBox
        public string PublicProfileTickBox = "//div[contains(@class,'hp-my-account__form')]/label[contains(text(),'{var}')]/../input[@value='true']";
        public string CreateAccTickBox = "//div/label[contains(text(),'I would like to subscribe to the Historic England newsletter.')]/../input[@type='checkbox']";

        //Input
        public By ContributeInput = By.XPath("//div[@class='comment-box-editor-container']");
        public string PublicProfileInput = "(//label[contains(text(),'{var}')]/../*)[2]";
        public By AboutMeInput = By.XPath("//textarea[@data-validation-name='about-me']");

        //Sign In
        public By AddComment = By.XPath("//button[@class='btn button-secondary mt-3']");

        //Image
        public By AvatarImg = By.XPath("//img[@id='avatar-image']");
        //public By AvatarImgPublicPage = By.XPath("//div[@class='user-profile-box__avatar']/img");
        //public By AvatarImgPublicPage = By.XPath("//p[@class='d-md-none mt-1 mb-0']/img");
        public By DefaultProfileImage = By.XPath("//img[@src='https://stage-sa.historic-england.org/image/get/genericavatar']");
        //public By ElephantProfileImage = By.XPath("//img[@src='https://stage-sa.historic-england.org/media/pqflrgtx/random.jpg']");
        public By AvatarImgPublicPage = By.XPath("//div[@class='profile__details mt-8 my-lg-0 d-md-flex justify-content-center align-items-center align-items-md-start justify-content-md-start flex-lg-column align-items-lg-start']/img");

    }

    class HerritagePassportMethods: BaseMethods
    {
        private HerritagePassportPageObject hppo = new HerritagePassportPageObject();
        IWebDriver _driver;
        Actions action;

        public HerritagePassportMethods(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
            action=new Actions(_driver);
        }

        public By DynamicWebElement(string xpath, string var)
        {
            return By.XPath(xpath.Replace("{var}", var));

        }

        public void PressAndHoldBtn(By btn)
        {
            action.ClickAndHold(_driver.FindElement(btn));
            action.Perform();
        }

        public void ReleaseBtn(By btn)
        {
            action.Release(_driver.FindElement(btn));
            action.Perform();
        }

        public string CaptureValueFromPublicProfileInputs(string inputName)
        {
            if (inputName.Contains("About me"))
            {
                return FindElementAndGetText(DynamicWebElement(hppo.PublicProfileInput, inputName));
            }
            else if (inputName.Contains("Organisation"))
            {
                return FindElementGetValue(DynamicWebElement(hppo.PublicProfileInput, inputName));
            }
            else
            {
                throw new Exception("This input name does not exist");
            }
        }

        public bool VerifyColor(By elem, string expectedColor)
        {
            IWebElement element = _driver.FindElement(elem);
            string currentColor = element.GetCssValue("border");
            currentColor = currentColor.Substring(currentColor.IndexOf("("));
            Debug.WriteLine("Current color: " + currentColor);

            switch (expectedColor)
            {
                //Black in RGB scale = (128, 128, 128)
                case "Black":              
                   return currentColor.Equals("(128, 128, 128)");
                //Red in RGB scale = (182, 33, 38)
                case "Red":
                    return currentColor.Equals("(182, 33, 38)");
                default:
                    return false;
            }


        }
    }
        
}
