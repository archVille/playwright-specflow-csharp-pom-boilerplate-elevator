Feature: SearchForPlaywright
	Search for Playwright on DuckDuckGo and go to the Playwright website from the search results

Scenario: Search for Playwright on DuckDuckGo
	Given the user is on the Search homepage
	When the user searches for 'Playwright'
	Then the user gets the search results