Feature: AddToCart

A short summary of the feature

@Test
Scenario: When I click add to cart button it displays value in the shopping cart.
	When I click add to cart.
	Then It should display that I have one product in shopping cart.
