using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowWithSelenium.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowWithSelenium.Support
{
    public  class LoginUser:MethodsCollection
    {
        By _userNameInput = By.Id("user-name");
        By _passwordInput = By.Id("password");
        By _loginButton = By.Id("login-button");

        private readonly IWebDriver driver;
        

        public  LoginUser(IWebDriver driver):base(driver)
        {
            this.driver = driver;
           
        }

        public void Login(string _userName, string _password)
        {
            SendKeys(_userNameInput, _userName);
            SendKeys(_passwordInput, _password);
            Click(_loginButton);
        }
    }
}
