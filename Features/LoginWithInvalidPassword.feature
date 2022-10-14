Feature: LoginWithInvalidUserName

A short summary of the feature

@LoginTag
Scenario: When the user enters an invalid password an error should be thrown
	Given I navigate to the url "https://www.saucedemo.com/"
	When I type username "standard_user"
	And Enter invalid password "bla bla bla"
	And Click LoginButton
	Then Error Message "Epic sadface: Username and password do not match any user in this service" should be displayed
