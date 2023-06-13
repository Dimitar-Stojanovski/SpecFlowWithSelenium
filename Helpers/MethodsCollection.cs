using NUnit.Framework;
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
        private IWebDriver driver;
        private WebDriverWait wait;

        public MethodsCollection(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        public void Click(By _locator)
        {
            try
            {
                findElement(_locator).Click();
            }
            catch (Exception ex)when(ex is NoSuchElementException||ex is WebDriverTimeoutException)
            {

                Assert.Fail($"Exception in Click(): element located by{_locator.ToString()} cannot be found or timeout expired");
            }
        }

        public IWebElement findElement(By _locator)
        {
         
            try
            {
                var _element = wait.Until(e => e.FindElement(_locator));
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
            
            return null;

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

            return true;
        }

        public void SendKeys(By _locator, string _text)
        {
            try
            {
                findElement(_locator).Clear();
                Thread.Sleep(TimeSpan.FromSeconds(1));
                findElement(_locator).SendKeys(_text);
            }
            catch (Exception ex) when(ex is NoSuchElementException||ex is WebDriverTimeoutException)
            {

                Assert.Fail($"Exception in SendKeys(): element located by{_locator.ToString()} cannot be found or timeout expired");
            }
        }
    }
}
