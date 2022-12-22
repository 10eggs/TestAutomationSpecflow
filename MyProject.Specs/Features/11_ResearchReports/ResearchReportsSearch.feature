Feature: ResearchReportsSearch
	Test scenarios cover searching options available for Research Reports Search 
	under https://stage.historic-england.org/research/results/reports/ path

Background: 
	Given Navigate to the "RR-search" page
	When I type "fish" into the search box
	And I click on the search icon

@RR_28689
@RR_27277
	Scenario: Paginating between Research Results pages
	When  I scroll to the bottom of the page
	And I click on the "Next" pagination arrow
	Then I am taken to page "2" of the results
	And I click on the "Previous" pagination arrow
	Then I am taken to page "1" of the results

@RR_27278
Scenario: Change the number of results per page
	When I click on results per page drop down and I select "100"
	And  I scroll to the bottom of the page
	And I select the back-to-top button
	Then the results change to 100
	
@RR_39688
	Scenario: Paginating between pages using the number box
	When  I scroll to the bottom of the page
	And I select the back-to-top button
	And I enter the number "3" into the pagination box
	Then I am taken to page "3" of the results
	And I click on the "Previous" pagination arrow
	Then I am taken to page "2" of the results

@RR_39689
	Scenario: Sorting by Newest and Oldest and most relevant 
	#When I type "york" into the search box
	Then the results show "CANTERBURY: THE FISH REMAINS FROM MARLOWE SITES I - IV." first
	When I select "Newest" from the RR drop down
	Then the results show "Isles of Scilly IFCA Collaboration: Integrating archaeological objectives with marine ecological surveys" first
	When I select "Oldest" from the RR drop down
	Then the results show "FISH BONES FROM HYDE STREET, WINCHESTER" first

@RR_xxxxxxx
	Scenario: Browser back to original RR search result
	When I type "fire" into the search box
	And click on the search icon
	Then I am taken to the research results for fire
	And select the browser back button
	Then I am taken to the research results for fish
	
	
	
	
	
	


	