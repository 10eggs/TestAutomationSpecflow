Feature:HARQuickSearch
	Test scenarios cover various elements 
	associated with the quick search feature (https://stage.historic-england.org/advice/heritage-at-risk/search-register/).

Background: 
	Given that I am on the HAR search landing page
	#Given Navigate to the "har-quick-search" page
	

@HARQS_18121
@HARQS_18122
@HARQS_18124
Scenario: Check results for search term fish, browser back and download functionality
	When I type "fish" into the search box
	And click on the search icon
	Then result for HAR element is present
	And  I click on one of the search results images
	Then I am taken to that result page with expected header
	And I use the browser function to back to the previous page
	Then I am taken to the results page with my search term results
	And I click download file "HARExport.csv" 
	
@HARQS_18125
Scenario: Check search term is carried to next page search field
	When I type "house" into the search box
	And click on the search icon
	When I select the "Refine Search" button
	Then I am taken to the more search page
	And search term "house" is carried to the field a the top of the search
	
@HARQs_18126
Scenario: Check correct search options are displayed after refining further using heritage category
	When I type "house" into the search box
	And click on the search icon
	When I select the "Refine Search" button
	When I select "All Listed Buildings" from the "Heritage Category" drop down list
	When I select the "Search" button
	Then HAR results are refined by "Keyword/s: house"
	And HAR results are refined by "Heritage Category: All Listed Buildings"

@HARQS_18127
Scenario: Search for a term that does not exist
	When I type "fgdgdfgdfgdd" into the search box
	And hit the enter key on my keyboard
	Then "No records matched the search criteria." element is present

@HARQS_23003
Scenario: Paginating between results pages
	When I type "Building" into the search box
	And click on the search icon
	When I click on the "Next" pagination arrow
	And I scroll to the bottom of the page
	Then I am taken to the next page of results
	When I click on the "Previous" pagination arrow
	And I scroll to the bottom of the page
	Then I am taken back to the previous page of results

@HARQS_XXXX
Scenario: Verify images loaded for search result
	When I type "house" into the search box
	And click on the search icon
	Then pictures are load
