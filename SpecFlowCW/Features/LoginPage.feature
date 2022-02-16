@CBC-49
Feature: Login page feature

@CBC-42
Scenario: Login page title
	Given user is on login page
	When user gets the title of the page
	Then page title should be "Swag Labs"

#@CBC-43
#Scenario: Login page title2
#	Given user is on login page
#	When user gets the title of the page
#	Then page title should be "Swag Labss"