using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowWithSelenium.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowWithSelenium.StepDefinitions
{
    [Binding]
    public class LoginWithInvalidUserNameStepDefinitions
    {

        LoginPage _loginPage;
        private readonly IWebDriver driver;

        public LoginWithInvalidUserNameStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            _loginPage=new LoginPage(driver);
        }

        [Given(@"I navigate to the url ""([^""]*)""")]
        public void GivenINavigateToTheUrl(string _url)
        {
           _loginPage.NavigateToUrl(_url);
        }

        [When(@"I enter username ""([^""]*)""")]
        public void WhenIEnterUsername(string _username)
        {
           _loginPage.EnterUserName(_username);
        }

        [When(@"Enter invalid password ""([^""]*)""")]
        public void WhenEnterInvalidPassword( string _password)
        {
            _loginPage.EnterPassword(_password);
        }

        [When(@"Click LoginButton")]
        public void WhenClickLoginButton()
        {
            _loginPage.ClickLoginButton();
        }

        [Then(@"Error Message ""([^""]*)"" should be displayed")]
        public void ThenErrorMessageShouldBeDisplayed(string errorMessage)
        {
            Assert.That(errorMessage, Is.EqualTo(_loginPage.ErrorMessageText()));
        }
    }
}
