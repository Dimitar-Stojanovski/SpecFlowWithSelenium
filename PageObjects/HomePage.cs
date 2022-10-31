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
    public class HomePage:MethodsCollection
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        private By _backPackAddToCartBtn = By.Id("add-to-cart-sauce-labs-backpack");
        private By _shoppingCartBadgeName = By.ClassName("shopping_cart_badge");

        public HomePage(IWebDriver driver, WebDriverWait wait):base(driver, wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void ClickAddToCartBackBack()
        {
            Click(_backPackAddToCartBtn);
        }

        public string GetNumberOfItemsInCart()
        {
            return getTextFromElement(_shoppingCartBadgeName);
        }
    }
}
