Feature: ArticlePageImage
	Test scenarios cover functionality connected with Images on
	https://stage.historic-england.org/admin-section/automation-test-area/automation-test-article/

Background:
	#Given that I am on the test article page
	Given Navigate to the "article-test" page

@IMG_22312
Scenario: Image is the correct dimensions
	When I have clicked on the "In-line image" contents link
	Then the images has a minimum width of "50"

@IMG_22313
Scenario: Image has alt text
	When I have clicked on the "In-line image" contents link
	And I inspect the black and white in-line image
	Then the in-line image has the correct alt text 

@IMG_22314
Scenario: Detailed/accessibility caption
	When I have clicked on the "In-line image" contents link
	And I wait for "2" seconds
	And I click on the "Show detailed description" text below the image    
	Then the image test opens up and reveals "this is a accessibility long description" text
	When I have clicked on the "In-line image" contents link
	And I click on the "Hide detailed description" text below the image
	Then the text is now hidden again with the link text changing back to "show detailed description" 

@IMG_22315
Scenario: Image has copywrite field
	When I have clicked on the "In-line image" contents link
	Then there is a @copyright text at the bottom of the image
