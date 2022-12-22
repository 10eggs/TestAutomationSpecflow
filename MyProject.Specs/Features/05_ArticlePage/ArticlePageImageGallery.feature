Feature: ArticlePageImageGallery
	Test scenarios cover functionality connected with Image gallery on
	https://stage.historic-england.org/admin-section/automation-test-area/automation-test-article/

Background:
	#Given that I am on the test article page
	Given Navigate to the "article-test" page

@IMGGAL_22317
Scenario: 01_User can paginate through gallery
	When I select the image
	When I click on the "Next" button inside lightbox view
	Then I am taken to the next image in the gallery
	When I click on the "Previous" button inside lightbox view
	Then I am taken back to the previous image

@IMGGAL_22316
Scenario: 02_User can select image in gallery
	When I have clicked on the "This is a gallery" contents link
	And I select the image
	Then the image takes you to a lightbox view of the image

@IMGGAL_22318
Scenario: 03_User can close the lightbox
	When I select the image
	Then the image takes you to a lightbox view of the image
	When I click on the "Close" button inside lightbox view
	Then the lightbox closes and i am taken back to the images

	
@IMGGAL_23959
Scenario: 04_User can select a link
	When I select the image
	Then the image takes you to a lightbox view of the image
	Then the "Test more puppies for testing landscape" link is present
	And I select the "Test more puppies for testing landscape" anchor
	Then I am taken to the linked page

	@IMGGAL_31741
Scenario: Image Gallery added by folder appears (examine indexes fix if not)
	When I have clicked on the "This is a gallery" contents link
	Then the "Gallery Folder" Gallery is on the page

	