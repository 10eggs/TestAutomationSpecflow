Feature: EducationalImagePage
	Test scenarios cover various elements 
	associated with the Educational Image Page search feature.
	
Background:
#Navigation#
#Given that I am on the "Images by Theme" landing page
Given Navigate to the "education-images-by-theme" page
When I select the "Aerial Photographs" block
Then I am on the gallery page with just aerial photographs
	
@EdImgPg_18136 
@EdImgPg_18137
@EdImgPg_18138
Scenario: Checking Images by theme takes you to the correct section
When I select the "Campsite, Crimdon Park, Durham" block
Then I am taken to the "Campsite, Crimdon Park, Durham" results
And I select the "Durham" anchor
And I scroll to the bottom of the page
And I select the back-to-top button
Then I am taken to the "Educational Images" refined results page for "Durham"

@EdImgPg_18136 
@EdImgPg_18139
Scenario: Checking themes tag from a Educational item page 
Given I am on the gallery page with just aerial photographs
When I select the "Campsite, Crimdon Park, Durham" block
And I select the "Aerial Photographs" block
Then I am on the gallery page with just aerial photographs
