Feature: ANHLE Quick Search Feature
	Test scenarios cover various elements  associated with the quick search feature
	https://stage.historic-england.org/listing/the-list


@NHLE_QS_17913
Scenario: Search term fish in NHLE search box
	Given that I am on the NHLE list search landing page
	When I type "fish" into the search box
	And click on the search icon
	Then I am taken to the NHLE search results for "fish"

@NHLE_QS_17970
Scenario: If incorrect value is used in text search
	Given that I am on the NHLE list search landing page
	When I type "dfgdgfdgdf" into the search box
	And click on the search icon
	Then Element with text "0 Search Results" is present

@NHLE_QS_17920
Scenario: Filter button on search results page
	Given that I have searched for "fish" on the NHLE listing search 
	And I am on the results page
	When I select the "Filter results" button
	Then a series of filters are shown

@NHLE_QS_17947
Scenario: Refine search results by drop down filters
	Given that I have searched for "fish" on the NHLE listing search 
	And I am on the results page
	When I select the "Filter results" button
	And I select "Birmingham" from the "County" drop down list
	When I select the "Apply filters" button
	Then I am the results page with the filtered results for "Birmingham"

@NHLE_QS_17958
Scenario: Refine search results by Heritage Category
	Given that I have searched for "fish" on the NHLE listing search
	And I am on the results page
	When I select the "Filter results" button
	And I click the "Park & garden: Grade II*" tick box
	When I select the "Apply filters" button
	Then I am the results page with the filtered results for "Park"

@NHLE_QS_17964
Scenario: Change the number of results per page
	Given that I have searched for "house" on the NHLE listing search
	And I am on the results page
	When I click on results per page drop down and I select "100"
	Then the page now shows "100" results

@NHLE_QS_17965
Scenario: Paginating between results pages
	Given that I have searched for "fish" on the NHLE listing search
	And I am on the results page
	Then I click on the "Next" pagination arrow
	And I am taken to page "2" of the results
	Then I click on the "Previous" pagination arrow
	And I am taken to page "1" of the results

@NHLE_QS_17968
Scenario: Using the search results pagination box
	Given that I have searched for "fish" on the NHLE listing search
	And I am on the results page
	When I enter the number "5" into the pagination box
	And I press "Enter" to accept page number
	Then I am taken to page "5" of the results

	@NHLE_QS_xxxxx
Scenario: Checking for Images of England
	Given Navigate to the "List Entry 1234567" page
	When I select the Overview Tab
	And I scroll to the bottom of the page
	Then the Image of England is showing on the page

@NHLE_QS_40765
Scenario: Downloading NHLE results
	Given that I have searched for "fish" on the NHLE listing search
	And I am on the results page
	#When I select the "Download search results" anchor
	Then I download file "NHLEExport.csv"
