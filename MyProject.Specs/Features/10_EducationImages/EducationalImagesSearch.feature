Feature: EducationalImagesSearch
	
Background:
#Navigation
	Given that I am on the Educational Images search page
	When I type "Sand" into the search box
	And click on the search icon
	Then I am taken to the "Educational Images" refined results page for "Sand"

@EdImgSrch_18129
@EdImgSrch_18130
Scenario:Checking the tag,period,county and place field is displayed
#Impicit timeout
	When I select the "Filter results" button
	Then the accordion opens
	When I select the "Hide filters" button
	Then the accordion closes

#Need to be rebuilded
#@ignore
@EdImgSrch_18133
Scenario:Checking the Tag filter displays correct results
	When I select the "Filter results" button
	And I select "leisure" from the "Tags" drop down list
	When I select the "Apply filters" button
	#And I am taken to the refined results page for "leisure" "Tags"
	And I scroll to the bottom of the page
	And I select "Goodrington Sands, Paignton, Torbay" from the results page
	Then the page contains the tag "leisure"


@EdImgSrch_18132
Scenario: Checking the Period filter displays correct results
	When I select the "Filter results" button
	And I select "Victorian (1837 - 1901)" from the "Period" drop down list
	And I select the "Apply filters" button
	Then I am taken to the refined results page for "Victorian (1837 - 1901)" "Period"

@EdImgSrch_18135
Scenario: Checking the Place filter to display correct results
	When I select the "Filter results" button
	And I select "Addingham" from the "Place" drop down list
	When I select the "Apply filters" button
	#Verification steps need to be verified (for some searching term there is no resutls ?)
	#https://stage.historic-england.org/services-skills/education/educational-images/
	#?searchType=Educational%20Images&search=sand&page=&filterOption=filterValue&facetValues=facet_ddl_place:Leeds:fplace%7C&pageId=32278
	And I am taken to the refined results page for "Addingham" "Place"

@EdImgSrch_18134
Scenario:Checking the County filter to display correct results
	When I select the "Filter results" button
	And I select "Merseyside" from the "County" drop down list
	When I select the "Apply filters" button
	And I am taken to the refined results page for "Merseyside" "County"

