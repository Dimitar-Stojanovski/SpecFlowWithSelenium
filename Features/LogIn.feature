Feature: LogIn
	
Login functionality testing
Scenarios: login functionality for sauce demo

@LoginTag
Scenario: Login with valid user name and password on Sauce Demo page.
	Given I navigate to the url page "https://www.saucedemo.com/"
	When I enter username "standard_user"
	And  I enter password "secret_sauce"
	And  Click login button
	Then Verify that I am seeing the inventories with url "https://www.saucedemo.com/inventory.html".

	

	@LoginTag
	Scenario: Login using data driven tests
	Given I navigate to the url page "https://www.saucedemo.com/"
	When I enter the following usernames
	 | username        |
	 | standard_user   |
	 
	
	And  I enter password
	 | password     |
	 | secret_sauce |
	 
	And  Click login button
	Then Verify that I am seeing the inventories with url "https://www.saucedemo.com/inventory.html".
	
	@LoginTag
	Scenario: Login using keys
	Given I navigate to the url page "https://www.saucedemo.com/"
	When I enter the following <usernames> and <password>
	And  Click login button
	Then Verify that I am seeing the inventories with url "https://www.saucedemo.com/inventory.html".
	 
	 Examples: 
	 | usernames     | password     |
	 | standard_user | secret_sauce |
	 | standard_user | secret_sauce |
	 | standard_user | secret_sauce |
	


