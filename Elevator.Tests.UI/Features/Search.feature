Feature: SearchForPlaywright
	Search for Playwright on DuckDuckGo and go to the Playwright website from the search results

Scenario: Search for Playwright on DuckDuckGo
	Given the user is on the DuckDuckGo homepage
	When the user searches for 'Playwright'
