using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowWithSelenium.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowWithSelenium.StepDefinitions
{
    [Binding]
    public class LogInStepDefinitions
    {
        private readonly LoginPage _loginPage;

        public LogInStepDefinitions(IWebDriver driver, WebDriverWait wait)
        {
            _loginPage = new LoginPage(driver, wait);
        }

        [Given(@"I navigate to the url page ""([^""]*)""")]
        public void GivenINavigateToTheUrlPage(string _url)
        {
           _loginPage.NavigateToUrl(_url);
        }

        [When(@"I enter username ""([^""]*)""")]
        public void WhenIEnterUsername(string userName)
        {
            _loginPage.EnterUserName(userName);
        }

        [When(@"I enter password ""([^""]*)""")]
        public void WhenIEnterPassword(string password)
        {
            _loginPage.EnterPassword(password);
        }

        [When(@"Click login button")]
        public void WhenClickLoginButton()
        {
            _loginPage.ClickLoginButton();
        }

        [Then(@"Verify that I am seeing the inventories with url ""([^""]*)""\.")]
        public void ThenVerifyThatIAmSeeingTheInventoriesWithUrl_(string inventoryPage)
        {
            Assert.AreEqual(_loginPage.VerifyInventoryPage(), inventoryPage);
        }
    }
}
