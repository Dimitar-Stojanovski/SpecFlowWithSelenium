using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowWithSelenium.Helpers
{
    public interface IMethodsCollection
    {
       
        IWebElement findElement(By _locator);
        IList<IWebElement> findElements(By _locator, int index);
        string getTextFromElement(By _locator);
        bool isElementDisplayed(By locator);

        void Click(By _locator);
        void SendKeys(By _locator, string _text);



    }
}
