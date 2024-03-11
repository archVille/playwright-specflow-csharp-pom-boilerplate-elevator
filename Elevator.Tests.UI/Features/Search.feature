Feature: SearchForPlaywright
As a user
I want to search for a term
So that I will be able to find the results 

Scenario: Search for Playwright returns the results
	Given the user is on the Search homepage
	When the user searches for 'Playwright'
	Then the user gets the search results