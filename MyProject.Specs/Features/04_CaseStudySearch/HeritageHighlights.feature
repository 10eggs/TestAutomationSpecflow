Feature: HeritageHighlights
	Test scenarios cover searching options available for ,,Heritage Highlights" category
	under https://stage.historic-england.org/listing/what-is-designation/heritage-highlights/ path.

Background: 
#Navigation
	Given that I am on heritage-highlights search
	#Given Navigate to the "heritage-highlights-search" page


@HH_23324
#Scenario: Do a search for "stone" in the Heritage Highlights search
Scenario: Do a search for "stone" in the Heritage Highlights search
	Given I type "stone" into the search box
	And number of results is shown
	When I click on the search icon
	Then I am taken to the "Heritage Highlights" refined results page for "stone"
	And number of results was changed


@HH_23329
Scenario: Paginating between results pages
	Given I type "stone" into the search box
	And number of results is shown
	When I click on the search icon
	Then I scroll to the bottom of the page
	And I click on the "Next page" pagination arrow
	Then I am taken to page "2" of the results
	And I click on the "Previous page" pagination arrow
	Then I am taken to page "1" of the results


@HH_23325
Scenario: I can open and close the filter results button
#Implicit timeout should be removed here
	When I select the "Filter results" button
	Then I can see three drop down lists with additional searching options
	When I select the "Hide filters" button
	Then the fields disappear and i only see the "Filter results" button

#@ignore
@HH_23326
Scenario: Applying the "listed buildings" designation filter
#'Number of result' - should be specific, should be present, should not contain 0 ?
# ignoring final step until bug fixing drop down retention is fixed
	Given I type "stone" into the search box
	And number of results is shown
	When I click on the search icon
	And I select the "Filter results" button
	And I select "Listed Buildings" from the "Type of Designation" drop down list
	And I select the "Apply filters" button
	Then the "Listed Buildings" filter remains selected
	And I am taken to the "Heritage Highlights" results filtered by "Listed Buildings" category
	And number of results was changed

# ignoring final step until bug fixing drop down retention is fixed
@HH_23327
Scenario: Applying both  the period and region filters
	Given I type "stone" into the search box
	And number of results is shown
	When I click on the search icon
	And I select the "Filter results" button
	And I select "Listed Buildings" from the "Type of Designation" drop down list
	And I select "20th Century" from the "Period" drop down list
	And I select "London" from the "Region" drop down list
	And I select the "Apply filters" button
	Then number of results was changed
	#And results was filtered by categories

#Test covered in heritage planning - rewrite or remove test later
@ignore 
##Unexpected alert window
@HH_23328
Scenario: Selecting "Which building feels like an elephant" result
	Given I type "stone" into the search box
	When I click on the search icon
	#And I scroll to the bottom of the page
	#And I select the back-to-top button
	And I select the "Filter results" button
	#And I scroll to the bottom of the page
	#And I select the back-to-top button
	When I select "Listed Buildings" from the "Type of Designation" drop down list
	And I select "20th Century" from the "Period" drop down list
	And I select "London" from the "Region" drop down list
	#Slow here
	And I select the "Apply filters" button
	And I refresh the page
	When I select "Which Building Feels Like an Elephant" from the results page
	Then I am taken to the correct article page with Listed, Grade, and NHLE entry fields

