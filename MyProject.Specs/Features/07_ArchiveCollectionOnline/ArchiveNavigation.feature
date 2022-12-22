#@ignore
Feature: ArchiveNavigation
Searching using the Archive Photo Search

@SiteNav_12958
@SiteNav_12982
#Navigation is used here
Scenario: Search for a record using search bar
	Given Navigate to the "aco-search-page" page
	When I type "Leominster" into the search box
	And click on the search icon
	Then records should contain Image and ref number

@SiteNav_12988
@SiteNav_12964
#ImplicitWaitTimeOut should be checked again
#Navigation steps again
#'flag' variable has not been used
Scenario: Record contains required fields
	Given I am on the results page for "Marianne Majerus Slide Collection"
	And I click the first result 
	Then I view the record with Image and ref number
	
@SiteNav_12964
#Navigation
#IfElse block
#Console out ?
#
Scenario:Navigate to parent record
	Given I am on the results page for "fish"
	And I click the first result 
	When I click the "Series" link in the content section
	Then I should be redirected to the page displaying information about that "series" 

@SiteNav_13126
Scenario:Navigate to collection 
#'collection' variable is not in use (last step)
	Given I am on the results page for "fish"
	And I click the first result 
	When I click the "Collection" link in the content section
	Then I should be redirected to the page displaying information about that "collection" 

@SiteNav_13127
Scenario:Test down arrow to expand in the content field
	Given I am on the results page for "Series of miscellaneous photographs of unknown origin"
	And I click the first result 
	When I click the down arrow to expand the content
	Then a list should drop down displaying the content within the collection

@SiteNav_12960
Scenario:Navigate back to Historic England Archive
	Given I am on the results page for "fish"
	And I click the first result 
	When I click on try a new search at the top of the page
	Then I should be redirected back to the Archive Search page

#ignoring until NHLE deploy
@ignore
@SiteNav_12963
Scenario:Search for records with online images only
#Do we need implicit timeout here?
	Given Navigate to the "aco-search-page" page
	When I type "fish" into the search box
	And  click on the search icon
	Then I select the tick box for 'Only records with online images'
	Then search results should display only records with online images

@SiteNav_22552
Scenario:Check curated search in a series
	Given I am on the results page for "fish"
	And I click the first result
	When I click the "Series" link in the content section
	Then I select the Series divided into child volumes field in the content section
	Then I am taken to a curated search results