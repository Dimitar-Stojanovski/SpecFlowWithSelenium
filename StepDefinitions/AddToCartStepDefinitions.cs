using System;
using TechTalk.SpecFlow;

namespace SpecFlowWithSelenium.StepDefinitions
{
    [Binding]
    public class AddToCartStepDefinitions
    {

        [Given(@"I succesfullyLogin")]
        public void GivenISuccesfullyLogin()
        {
            throw new PendingStepException();
        }


        [When(@"I click add to cart\.")]
        public void WhenIClickAddToCart_()
        {
            throw new PendingStepException();
        }

        [Then(@"It should display that I have one product in shopping cart\.")]
        public void ThenItShouldDisplayThatIHaveOneProductInShoppingCart_()
        {
            throw new PendingStepException();
        }
    }
}
