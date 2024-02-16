using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowWithSelenium.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowWithSelenium.PageObjects
{
    public class LoginPage : MethodsCollection,ILoginPage
    {
        private IWebDriver driver = null;
      

        By _userNameInput = By.Id("user-name");
        By _passwordInput = By.Id("password");
        By _loginButton = By.Id("login-button");
        By _invalidMsgHeader = By.XPath("//*[@data-test='error']");
        

        public LoginPage(IWebDriver driver): base(driver) { this.driver = driver; }

        public void NavigateToUrl(string _url)=> driver.Navigate().GoToUrl(_url);

        public void EnterUserName(string _userName) => SendKeys(_userNameInput, _userName);


        public void EnterPassword(string _password) => SendKeys(_passwordInput, _password);

        public void ClickLoginButton() => Click(_loginButton);


        public string VerifyInventoryPage() => driver.Url;
        

        public string ErrorMessageText() => getTextFromElement(_invalidMsgHeader);
       


    }
}
