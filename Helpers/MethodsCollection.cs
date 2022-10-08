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

        public MethodsCollection(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }
        public IWebElement findElement(By _locator)
        {
            var _element= wait.Until(e => e.FindElement(_locator));
            if (_locator==null)
            {
                throw new WebDriverTimeoutException($"Exception in findElement(): element located by{_locator.ToString()} cannot be found");
            }

            return _element;

        }

        public IList<IWebElement> findElements(By _locator, int index)
        {
            var elements = (IList<IWebElement>)wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(_locator))[index];
            if (_locator == null)
            {
                throw new WebDriverTimeoutException($"Exception in findElements(): element located by{_locator.ToString()} cannot be found");
            }
            return elements;
        }

        public string getTextFromElement(By _locator)
        {
            var element = findElement(_locator).Text;
            if (_locator == null)
            {
                throw new WebDriverTimeoutException($"Exception in getTextFromElement(): element located by{_locator.ToString()} cannot be found");
            }

            return element;

        }

        public bool isElementDisplayed(By _locator)
        {
            var element = findElement(_locator).Displayed;
            if (_locator == null)
            {
                throw new WebDriverTimeoutException($"Exception in getTextFromElement(): element located by{_locator.ToString()} cannot be found");
            }

            return element;
        }
    }
}
