@DA-7
Feature: Login page feature

@DA-1
Scenario: Login page title
	Given user is on login page
	When user gets the title of the page
	Then page title should be "Swag Labs"

@DA-2
Scenario: Login page title2
	Given user is on login page
	When user gets the title of the page
	Then page title should be "Swag Labss"

@DA-3
Scenario: Login page title3
	Given user is on login page
	When user gets the title of the page
	Then page title should be "Swag Labs"