Feature: PSFilteredResults
	Test scenarios cover searching options available for ,,Publications" category
	under https://stage.historic-england.org/images-books/publications/ path.
	
Background: 
	#Given that I am on publications search
	Given Navigate to the "publication-search" page
	And I scroll to the bottom of the page
	And I select the back-to-top button

@PS_19619
	Scenario: 07_Searching the term "house" in the publication search
	Given I type "fish" into the search box
	And I scroll to the bottom of the page	
	And I select the back-to-top button
	When I click on the search icon
	Then I am taken to the "Search All Publications" results filtered by "fish" category

#@ignore
@PS_19621
	Scenario: 04_Select "filter results" button 
	Given that I am on the search results for "house"
	And I scroll to the bottom of the page
	And I select the back-to-top button
	When I select the filter results button
	Then I am presented with additional field to filter my results by two checkboxes and two dropdown fields


#Temporary skipped because of bug 23642 on staging env.
#Downloadable content filter not being applied
#@ignore
#@PS_19620
#	Scenario: Filter results to downloadable content 
#	Given that I am on the search results for "house" and the filters are open
#	When I click the Downloadable content check box
#	And I select the "Apply filters" button
#	Then the page refreshes I am presented with only results that can be downloaded

@ignore
@PS_19622
	Scenario: 05_Filter results to publish date
	Given that I am on the search results for "sand" and the filters are open
	And that I have selected the publications filter button
	When I select "Past 10 years" from the "Published" drop down list
	And I select the "Apply filters" button
	Then the page refreshes I am presented within the specified time frame

@PS_19623
	#flaky test step 1 
	Scenario: 01_Filter results to series
	Given that I am on the search results for "sand" and the filters are open
	And that I have selected the publications filter button
	And I scroll to the bottom of the page
	When I select "Guidance" from the "Series" drop down list
	And I select the "Apply filters" button
	Then the page refreshes I am presented with only "Guidance" options

#@ignore
@PS_19624
	Scenario: 02_Select "hide results" button
	Given that I am on the search results for "Sand" and the filters are open
	When I select the "Hide filters" button
	Then the fields disappear and i only see the "Filter results" button

@PS_19625
	Scenario: 03_Paginating between publication results pages
	Given that I have refined all my search for "House"
	Then I scroll to the bottom of the page
	#And I wait for "3" seconds
	And I click on the "Next" pagination arrow
	#And I select the Next pagination arrow
	Then I am taken to page "2" of the results
	And I click on the "Previous" pagination arrow
	Then I am taken to page "1" of the results
	
@PS_19623
	Scenario: 06_Selecting a result from the publications search page
	Given that I am on the search results for "Sand" and the filters are open
	When I select "Conservation Bulletin 28" from the results page
	Then I am taken to that publication page