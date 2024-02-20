using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowWithSelenium.PageObjects;
using SpecFlowWithSelenium.Utils.Models;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowWithSelenium.StepDefinitions
{
    [Binding]
    public class LogInStepDefinitions
    {
        
       private IWebDriver driver;
       LoginPage _loginPage;

        public LogInStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            _loginPage = new LoginPage(driver);
        }

        [Given(@"I navigate to the url page ""([^""]*)""")]
        public void GivenINavigateToTheUrlPage(string _url)
        {
           _loginPage.NavigateToUrl(_url);
        }

        [When(@"I type username ""([^""]*)""")]
        public void WhenITypeUsername(string userName)
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



        [When(@"I enter the following usernames")]
        public void WhenIEnterTheFollowingUsernames(Table table)
        {
            var data = table.CreateSet<LoginModel>();
            foreach (var item in data)
            {
                _loginPage.EnterUserName(item.Username);
            }
            
        }

        [When(@"I enter password")]
        public void WhenIEnterPassword(Table table)
        {
            var data = table.CreateSet<LoginModel>();
            foreach (var item in data)
            {
                _loginPage.EnterPassword(item.Password);
            }
        }

        [When(@"I enter the following (.*) and (.*)")]
        public void WhenIEnterTheFollowingStandard_UserAndSecret_Sauce(string username,string password)
        {
            _loginPage.EnterUserName(username);
            _loginPage.EnterPassword(password);
        }










    }
}
