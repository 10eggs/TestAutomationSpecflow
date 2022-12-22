Feature: Main Menu Navigation
	Testing the main menu

Background:
	#Given that I am on the GAP Search Landing Page
	Given Navigate to the "home-page-test" page
	When I click on the "Listing" tab in the Main Menu

@Menu_19408
Scenario: Navigating to the Listing Pages
	When I select the "search the list" link 
	Then I am taken to the "search the list" page

@Menu_19409
Scenario: Click on the menu button
	When I click on the "find out about listing" button in the menu
	Then I am taken to the "listing" page 

@Menu_31675
Scenario: Closing the menu
	When I click on the close menu button
	Then the menu closes








	
