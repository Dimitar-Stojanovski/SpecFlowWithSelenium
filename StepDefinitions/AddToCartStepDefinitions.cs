using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowWithSelenium.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowWithSelenium.StepDefinitions
{
    [Binding]
    public class AddToCartStepDefinitions
    {
        private readonly HomePage homePage;

        public AddToCartStepDefinitions(IWebDriver driver)
        {
            homePage = new HomePage(driver);
        }
        [When(@"I click add to cart\.")]
        public void WhenIClickAddToCart_()
        {
           homePage.ClickAddToCartBackBack();
        }

        [Then(@"It should display that I have one product in shopping cart\.")]
        public void ThenItShouldDisplayThatIHaveOneProductInShoppingCart_()
        {
            Assert.AreEqual(homePage.GetNumberOfItemsInCart(), Convert.ToString(1));
        }
    }
}
