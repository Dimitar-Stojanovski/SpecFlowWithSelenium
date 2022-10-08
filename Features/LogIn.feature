﻿Feature: LogIn

Login functionality testing

@LoginTag
Scenario: Login with valid user name and password on Sauce Demo page.
	Given I navigate to the url page "https://www.saucedemo.com/"
	When I enter username "standard_user"
	And  I enter password "secret_sauce"
	And  Click login button
	Then Verify that I am seeing the inventories with url "https://www.saucedemo.com/inventory.html".
