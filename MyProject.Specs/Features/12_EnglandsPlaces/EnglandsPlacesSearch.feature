Feature: EnglandsPlacesSearch
	Test scenarios cover searching options available for ,,Englands places" category
	under https://stage.historic-england.org/images-books/photos path.

Background:
#Navigation
	#Given that I am on Englands places page
	Given Navigate to the "englands-places-seearch" page

@EP_18190
Scenario: Do a EP search for "Swindon" from the EP Search Landing page
	When I type "Swindon" into the search box
	And I click on the search icon
	And I scroll to the bottom of the page
	Then I am taken to the "England's Places" refined results page for "Swindon"
	And I scroll to the bottom of the page
	And I select "Swindon, Swindon" from the results page
	Then I am taken to a results page with the search box at the top

@EP_18193
Scenario: Select "Swindon, Wiltshire" from the list results
	Given that I am on the EP search results for "Swindon",Swindon"
	When I select the down-pointing chevron to the right of the "Swindon, Wiltshire" result
	Then accordion opens and there are more search results shown below

@EP_18195
Scenario: "Open a box" from the search results page
	Given that I am on the EP search results for "Swindon",Swindon"
	When I select the down-pointing chevron to the right of the "Swindon, Wiltshire" result
	And I select the down-pointing chevron to the right of the "Lydiard Park" result
	And "Wiltshire: Swindon Lydiard Park" element is present
	And "Lydiard Park" element is present
	Then I select the "Open box" anchor
	And I am taken a gallery page

@EP_18197
Scenario: Select an image in the EP gallery
	Given that I am on gallery page for Swindon - Lydiard Park
	And click on the image at the very bottom
	Then I am taken to the card detail page for that item


