Feature: ToDo
	In order to access the website
	As a user
	I want to be able to login to the website

Background: Given user has navigated to the app

Scenario: Adding a todo - E2E
	When user adds a new card 'test'
	Then the card should appear as active


Scenario: Removing a todo - E2E
	Given user adds a new card 'test'
	When user removes card 'test'
	Then the card 'test' should no longer appear as active