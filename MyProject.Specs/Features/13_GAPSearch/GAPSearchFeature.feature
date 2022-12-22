Feature: GapSearch
Tests located on page - https://stage.historic-england.org/services-skills/grants/visit/

	Background:
	#Given that I am on the GAP Search Landing Page
	Given Navigate to the "gap-search" page
	When I type "rock" into the search box
	And I click on the search icon
	Then I am taken to the search results page for rock


	@GAP_18204
	Scenario: Doing a search for a building from the GAP search page
	Given that I am on the GAP search results for "rock"
	And I click the "Buildings, Monuments & Landscapes" tick box
	And I click on the search icon
	Then Element with text "Cragside, Rothbury" is present
	When I click select the "Cragside, Rothbury" element
	Then I am taken to the correct URL "cragside-rothbury-ne65-7px" with the entry title "Cragside, Rothbury" showing 


    @GAP_22137
	Scenario: Doing a search for Places of Worship from the GAP search page
	Given that I am on the GAP search results for "rock"
	And I click the "Places of Worship" tick box
	And I click on the search icon
	Then Element with text "Emmanuel Church, Windsor Road" is present
	When I click select the "Emmanuel Church, Windsor Road" element
	Then I am taken to the correct URL "emmanuel-church-windsor-road-ts12-1be" with the entry title "Emmanuel Church, Windsor Road" showing 


