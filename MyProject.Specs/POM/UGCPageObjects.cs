using System;
using System.Text;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;
using System.Diagnostics;
using System.Threading;
using WindowsInput;
using WindowsInput.Native;

namespace HistoricalEngland.Specs.POM
{
    class UGCPageObjects : BasePageObjects
    {

        //Btn
        public By CloseModalBtn = By.XPath("//button[@id='closeModal']");
        public By CloseThankYouWindowBtn = By.XPath("//div//button[(text()='Close')]");
        public By ChooseFromDeviceUploadBtn = By.XPath("//input[@type='file']");
        public By AddImageBtn = By.XPath("//button[contains(@class,'uploadcare--preview__done')]");
        //public By AddImageBtn = By.XPath("(//button[contains(text(), 'Add')])[8]");
        //public By SubmitForApprovalBtn = By.XPath("//input[@value='Submit for approval']");
        public By SubmitForApprovalBtn = By.XPath("//button[@data-component='ugcAddContributionModalSubmitButton']");
        public By OptionsBtn = By.XPath("(//img[@alt='Options'])[1]");
        public By SubmitEditBtn = By.XPath("//input[@value='Submit my contribution']");
        public By YouTubePlayBtn = By.XPath("(//article)[1]//span[contains(@class, 'icon--play')]");
        public By InstagramAllowAccessBtn = By.XPath("//button[text()='Allow']");
        public string ContinueToSocialMediaBtn = "//a[contains(@href, '{var}') and @class='js-login welcome-button big-button']";
        public By CloseLightboxGalleryBtn = By.XPath("//div[@title='Close']");
        public By LightBoxNextArrowBtn = By.XPath("//div[@title='Next']");
        public By LightBoxGrid = By.XPath("//div[@title='Thumbnails']");
        public By ThumbnailList = By.XPath("(//img[@class='fslightbox-thumb'])[1]");
        public By StatusDrpDwn = By.XPath("//select[@name='status']");
        public By EditStatus = By.XPath("//option[@value='awaiting']");

        //Elements
        public By TopComment = By.XPath("(//article)[1]");
        public By TopCommentImage = By.XPath("(//article)[1]//img[@itemprop='image']");
        public string TopCommentMultiImage = "((//article)[1]//img[@itemprop='image'])[{var}]";
        public By NumberOfComments = By.XPath("//*[@id='root']/div/p");
        public By YouTubeVideoLink = By.XPath("(//article)[1]//a[@aria-label='Play YouTube video']");
        public By NoCommentsLabel = By.XPath("//div[@class='text-center']");
        public By OptionsDropdownMenu = By.XPath("//div[contains(@class, 'dropdown-menu')]");
        public string ImageUploadMenuTab = "//div[@title='{var}']";
        public string FacebookAlbum = "//a[@title='{var}']";
        public By GalleryImage = By.XPath("//img[@id='264899']");
        public By LightBoxGalleryImage = By.XPath("//img[contains(@class, 'fslightbox-source') and @alt='This is Alternative Text for Automated Testing']");
        public By LightBoxImageNumber = By.XPath("//div[@class='fslightbox-slide-number-container']");
        public By SignInToReplyAnchor = By.XPath("(//a[contains(text(),'Sign in to reply')])[1]");
        public By MinusIcon = By.XPath("(//span[@class='rounded-circle p-1 icon icon--minus'])[1]");
        public By PlusIcon = By.XPath("//span[@class='rounded-circle p-1 icon icon--plus']");
        //public By MinusIcon2 = By.XPath("//label[@for='description1']");
        public By AltTxtBox = By.XPath("(//div[@class='d-flex flex-column is-open'])[1]");


        //public By OptionsBtn = By.XPath("(//img[@alt='Options'])[1]");

        //iFrames
        public By YouTubeVideoPlaying = By.XPath("//div//iframe");

        //TextFields
        public By CommentBox = By.XPath("//textarea");
        //public By CommentBox = By.XPath("//textarea[@id='commentsField']");
        public By ImageAltTextBox = By.XPath("//textarea[@id='description1']");
        public string ImageAltTextBoxes = "//textarea[@id='description{var}']";
        public By YouTubeURLBox = By.XPath("//input[@name='YouTubeUrl']");
        public string SocialMediaSignInFields = "//input[@name='{var}']";




    }


    class UGCMethods: BaseMethods
    {
        private IWebDriver _driver;

        public UGCMethods(IWebDriver driver) : base(driver)
        {
            this._driver = driver;

        }

        public void CloseFileExplorer()
        {
            InputSimulator sim = new InputSimulator();
            sim.Keyboard.KeyPress(VirtualKeyCode.ESCAPE);
        }









    }



}
