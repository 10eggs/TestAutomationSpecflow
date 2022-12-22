Feature: ANHLE Advance Search 

Background:
	#Given that I am on the NHLE list search landing page
	Given Navigate to the "nhle-quick-search" page
	And I select the Advanced Search button
	
@NHLE_AS_17993
Scenario: To clear advanced search fields
	Given that I am on NHLE advanced search page
	And I have several fields filled within the advanced search form
	When I select the "Clear" button
	Then all filters are cleared

#@ignore
#Verify content of header (RecordsFound element)
@NHLE_AS_17995
Scenario:Check refined results after unticking Listed Building
	#Flaky step
	Given that I am on NHLE advanced search page
	And I click the "Listed Building" tick box
	When I select the "Search" button
	And I am taken to the results page with results for listed buildings omitted

@NHLE_AS_17983
Scenario:Refine results by List entry name
	#Given that I am on NHLE advanced search page
	When I enter the text "house" into the List Entry Name search field
	When I select the "Search" button
	Then I am taken to the advanced search results page
	When I use the browser function to back to the previous page
	And my entered variable "house" remains in the field 

@NHLE_AS_17985
Scenario:Refine results by county field
	#Given that I am on NHLE advanced search page
	When I enter the text "house" into the List Entry Name search field
	When I select "Staffordshire" from the "County" drop down list
	And I select the "Search" button
	Then I am taken to the advanced search results page
	When I use the browser function to back to the previous page
	And my entered variable "house,Staffordshire" remains in the field 


@NHLE_AS_17989
Scenario:Refine results by parish field
	#Given that I am on NHLE advanced search page
	When I enter the text "house" into the List Entry Name search field
	When I type in the letters "Eas" into the parish field
	Then a drop-down brings me the results
	And I select "East Allington (County=Devon, District=South Hams)" element
	And I select the "Search" button
	Then I am taken to the advanced search results page
	When I use the browser function to back to the previous page
	And my entered variable "house,Devon,South Hams" remains in the field

@NHLE_AS_19614
Scenario:Selecting a date range field
	#Given that I am on NHLE advanced search page
	When I enter the text "house" into the List Entry Name search field
	When I enter "1975" into the "From" "Date Range" field
	And I enter "2015" into the "To" "Date Range" field
	And I select the "Search" button
	Then I am taken to the advanced search results page
	When I use the browser function to back to the previous page
	And my entered variable "house,1975,2015" remains in the field

@NHLE_AS_19615
Scenario:Selecting a Designation Date field	
	#Given that I am on NHLE advanced search page
	When I enter the text "house" into the List Entry Name search field
	When I enter "01/01/1999" into the "From" "Designation Date" field
	And I enter "02/02/2015" into the "To" "Designation Date" field
	And I select the "Search" button
	Then I am taken to the advanced search results page
	When I use the browser function to back to the previous page
	And my entered variable "house,01/01/1999,02/02/2015" remains in the field

@NHLE_AS_22190
Scenario: Paginating between results pages
	#Given that I am on NHLE advanced search page
	When I enter the text "sand" into the List Entry Name search field
	When I select the "Search" button
	Then I click on the "Next" pagination arrow
	And I am taken to page "2" of the results
	Then I click on the "Previous" pagination arrow
	Then I am taken to page "1" of the results

@NHLE_AS_22192
Scenario: Paginating between results pages using the number box
	#Given that I am on NHLE advanced search page
	When I enter the text "fish" into the List Entry Name search field
	And I select the "Search" button
	When I enter the number "3" into the pagination box
	And I press "Enter" to accept page number
	Then I am taken to page "3" of the results

@NHLE_AS_31534
Scenario: Start a New Search
	#Given that I am on NHLE advanced search page
	When I select "Cumbria" from the "County" drop down list
	And I enter the text "house" into the List Entry Name search field
	And I click the "Listed Building" tick box
	And I select the "Search" button
	Then I am taken to the advanced search results page
	When I select the "New search" anchor
	Then I am taken to a search page with no filters selected
	And I select the "Search" button
	Then I am taken to the advanced search results page


@NHLE_AS_27426
Scenario: Modify Search
	When I select "Cumbria" from the "County" drop down list
	And I click the "Listed Building" tick box
	And I select the "Search" button
	Then I am taken to the advanced search results page
	When I select the "Modify search" anchor
	Then I am taken back to the Advanced Search Page with my previous selections still there
	When I select "NA" from the "County" drop down list
	And I select the "Search" button
	Then the results are different 