Feature: HeritagePlanning
	Test scenarios cover searching options available for ,,Heritage Highlights" category
	https://stage.historic-england.org/advice/hpg/planning-cases/

Background: 
#Navigation, change this
	Given Navigate to the "heritage-planning-search" page

@HPlan_25626
Scenario: Do a search for "demolition" in the Heritage Planning Database
	When I type "demolition" into the search box
	And I click on the search icon
	When I select "Spenbrook Mill" element
	Then I am taken to the correct article page with Decision, Address, and Applicant entry fields

#@ignore
@HPlan_25627
Scenario: Select a option from the dRop down filters
	Given I type "*" into the search box
	And I click on the search icon
	When I select the "Filter results" button
	And I select "Listed building" from the "Type of Asset" drop down list
	When I select the "Apply filters" button
	And I wait for "3" seconds
	Then I am taken to the "Heritage Planning" results filtered by "Listed building" category

@HPlan_25628
Scenario: Paginate to a different page
	When I type "demolition" into the search box
	And I click on the search icon
	And I scroll to the bottom of the page
	When I enter the number "3" into the pagination box
	And I press "Enter" to accept page number
	Then I am taken to page "3" of the results

