﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowWithSelenium.Helpers
{
    public class MethodsCollection : IMethodsCollection
    {
        protected IWebDriver Driver { get; set; }
        private WebDriverWait wait;

        public MethodsCollection(IWebDriver driver)
        {
            Driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        

        public void Click(By _locator) => findElement(_locator).Click();
       

        public IWebElement findElement(By _locator)
        {
         
            try
            {
                var _element = wait.Until<IWebElement>(x =>
                {
                    var tempElement = x.FindElement(_locator);
                    return tempElement.Displayed && tempElement.Enabled ? tempElement:null;
                });
                return _element;
            }
            catch (Exception ex) when(ex is WebDriverTimeoutException||ex is NoSuchElementException)
            {

                Assert.Fail($"Exception in findElement(): element located by{_locator.ToString()} cannot be found or timeout expired");
            }

           return null;

        }

        public IList<IWebElement> findElements(By _locator, int index)
        {


            try
            {
                var elements = (IList<IWebElement>)wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(_locator))[index];
                return elements;
            }
            catch (Exception ex) when (ex is WebDriverTimeoutException || ex is NoSuchElementException)
            {

                Assert.Fail($"Exception in findElements(): element located by{_locator.ToString()} cannot be found or timeout expired");
            }

            return null;
          
        }

        public string getTextFromElement(By _locator)
        {
            try
            {
                var element = findElement(_locator).Text;


                return element;
            }
            catch (Exception ex) when (ex is WebDriverTimeoutException || ex is NoSuchElementException)
            {

                Assert.Fail($"Exception in getTextFromElement(): element located by{_locator.ToString()} cannot be found or timeout expired");
            }
            
            return string.Empty;

        }

        public bool isElementDisplayed(By _locator)
        {
            try
            {
                var element = findElement(_locator).Displayed;


                return element;
            }
            catch (Exception ex) when (ex is WebDriverTimeoutException || ex is NoSuchElementException)
            {

                Assert.Fail($"Exception in isElementDisplayed(): element located by{_locator.ToString()} cannot be found or timeout expired");
            }

            return false;
        }

        public void SendKeys(By _locator, string _text)
        {
            try
            {
                findElement(_locator).Clear();
               
                findElement(_locator).SendKeys(_text);
            }
            catch (Exception ex) when(ex is NoSuchElementException||ex is WebDriverTimeoutException)
            {

                Assert.Fail($"Exception in SendKeys(): element located by{_locator.ToString()} cannot be found or timeout expired");
            }
        }
    }
}
