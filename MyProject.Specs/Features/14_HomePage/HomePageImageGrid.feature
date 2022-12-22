Feature: HomePageImageGrid
	Test scenarios cover various elements of Homepage

#@ignore
#@HP_ImgGrid21126
#	Given Navigate to the "home-page-test" page
#	#Given I have navigated to the Automation Testing Home Page
#	When I hover my mouse over one of the images on the image grid component
#	Then I am presented with a blue hover state and text

@ignore
@HP_ImgGrid21127
Scenario: Click on Image Grid item 
	Given Navigate to the "home-page-test" page
	When I click the bottom left of the image grid component with text "add your photos to the list"
	Then I am taken to an image takeover with a call-to-action button text "Enrich the list"
	When I click the "Enrich the list" 
	Then I am taken to  to the enrich the list page on the website 

@ignore
@HP_ImgsGrid21128
Scenario: Click on X icon to close the image grid takeover 
    Given Navigate to the "home-page-test" page
	When I click the bottom left of the image grid component with text "add your photos to the list"
	Then I am taken to an image takeover with a call-to-action button text "Enrich the list"
	Then I click the X button
	Then I am taken back to the Home page