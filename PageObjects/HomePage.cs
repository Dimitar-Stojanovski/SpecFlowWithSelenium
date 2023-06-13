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
        

        private By _backPackAddToCartBtn = By.Id("add-to-cart-sauce-labs-backpack");
        private By _shoppingCartBadgeName = By.ClassName("shopping_cart_badge");

        public HomePage(IWebDriver driver):base(driver)
        {
            this.driver = driver;
           
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
