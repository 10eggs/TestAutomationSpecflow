#@ignore
Feature: ArchiveSearchAndFilter
	
@Archive_12967
Scenario: Search for Little London in search bar
#Navigation
	Given Navigate to the "aco-search-page" page
	When I type "Little London" into the search box
	And click on the search icon
	Then I am presented with results for "Little London"

@Archive_12970
@Archive_12971
Scenario: Check Date values return correct results
#Verify commented lines 
	Given I am on the results page for "fish"
	And I enter "1978" in "After" date field
	Then I enter "1979" in "Before" date field
	And I scroll to the bottom of the page
	And I select the back-to-top button
	When I select the "Apply Filters" button
	
	Then I am taken to the refined results page for the specified dates

@Archive_12972
Scenario: Check clear filter button works
	Given I am on the results page for "Little London"
	And I enter "2000" in "After" date field
	Then I enter "2019" in "Before" date field
	When I select the "Clear Filters" button
	Then the values will clear from the date fields


@Archive_13111
@Archive_12980
Scenario: Check refined results for Hampshire option for County drop down
#Verify last step here, make sure that all Debug.Writeline are removed
	Given I am on the results page for "Little London"
	When I type "Hampshire" into the "county" field
	Then a drop down menu should appear with the search term
	When I select the "Apply Filters" button
	Then I am taken to the refined results page for selected "county"

@Archive_13247
Scenario: Check refined results for Cathedral as bulding type
	Given I am on the results page for "Durham"
	When I type "Cathedral" into the "building" field 
	Then a drop down menu should appear with the search term
	When I select the "Apply Filters" button
	Then I am taken to the refined results page for selected "Cathedral"


@Archive_13599
Scenario: Selecting a value from the parish drop down menu should auto populate district and county
	Given I am on the results page for "Little London"
	When I type "Exmouth" into the "parish" field
	Then the County and District fields should auto populate with the correct values

#Temporary skipped because of bug 13109 on live env.
#Problem with error msg ['.' mark at the end of asserion step]
#
@Archive_13616
Scenario: Validation message appears under facet when value spelled incorrectly  
	Given I am on the results page for "Little London"
	When I type "Hamipishire" into the "county" field
	And I click on the District field
	#This step
	Then an error message is displayed  