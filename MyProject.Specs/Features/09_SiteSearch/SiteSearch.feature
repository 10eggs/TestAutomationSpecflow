Feature: SiteSearch
	Test scenarios cover searching options available for "SiteSearch" category
	under https://stage.historic-england.org/sitesearch path.

Background: 
	Given that I am on sitesearch search
	When I type "Little London" into the search box
	And click on the search icon

@SITE_SEA_18104
Scenario: Test search for "Little London" 
	Then I am taken to the Site search results page for "Little London"

@SITE_SEA_18105
Scenario: Select search result
	When I scroll to the bottom of the page
	And click on the last result
	Then I am taken to that page
	And I use the browser function to back to the previous page
	Then am taken back to my search results page with "Little London" search term and results intact 

@SITE_SEA_18106
Scenario: Opening and closing filters 
	When I select the "Filter results" button
	Then the accordion opens
	When I select the "Hide filters" button
	Then the accordion closes

@SITE_SEA_18107
Scenario: Refine search results by Heritage At Risk entry
	And I scroll to the bottom of the page
	And I select the back-to-top button
	When I select the "Filter results" button
	And I click the "News" tick box
	And I select the "Apply filters" button
	And I scroll to the bottom of the page
	And I select the back-to-top button
	Then only get the results for "News"

@SITE_SEA_22303
Scenario: Paginating site search results
	When I enter the number "5" into the pagination box
	And I press "Enter" to accept page number
	Then I am taken to page "5" of the results
	And I click on the "Next" pagination arrow
	Then I am taken to page "6" of the results

@SITE_SEA_22988
Scenario: Results per page 20 to 100
	When I click on results per page drop down and I select "100"
	Then the page now shows "100" results


#The images for results are loaded randomly (sometimes they are present, sometimes they are not)
#@ignore
@SITE_SEA_24341
Scenario: Site Search of an educational image
	When I select the "Filter results" button
	When I select the back-to-top button
	And I click the "Educational Images" tick box
	And I select the "Apply filters" button
	Then the search comes back with results that have images
	And I click those images
	Then the image has pulled in to the search

##Results doesnt contain searching phrase in headers
##CRAIG_S rewrite scenario
#@ignore
@SITE_SEA_24344
Scenario: Browser back to original search result
	When I type "fire" into the search box
	And click on the search icon
	#Then I am taken to the search results for "fire"
	Then I am taken to the site search results for fire
	And select the browser back button
	#Then I am taken to the search results for "little london"
	Then I am taken to the site search results for Little London


