#@ignore
Feature: ArchiveSorting

# ignoring until Solr exporter re-ran for ACO stage
#@ignore	
@SortPg_22186
Scenario: Sorting results by reference number
#Navigation
	Given I am on the results page for "fish"
	When I select "Reference Number" from the Sort by dropdown
	Then the order of the results is changed

@SortPg_22188
Scenario:Paginating between results pages
	Given I am on the results page for "Sand"
	And I scroll to the bottom of the page
	And I select the back-to-top button
	Then I click on the "Next page" pagination arrow
	And I am taken to page "2" of the results
	Then I click on the "Previous page" pagination arrow
	Then I am taken to page "1" of the results

@SortPg_22189
Scenario:Paginating between results pages using the number box
	Given I am on the results page for "Sand"
	And I scroll to the bottom of the page
	And I select the back-to-top button
	When I enter the number "3" into the pagination box
	And I press "Enter" to accept page number
	Then I am taken to page "3" of the results
	
