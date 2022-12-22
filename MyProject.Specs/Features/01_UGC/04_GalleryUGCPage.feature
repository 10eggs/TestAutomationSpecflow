Feature: 04_GalleryUGCPage
	Test scenarios cover Gallery function use of UGC Page
	https://stage.historic-england.org/admin-section/automation-test-area/ugc-automated-testing-galleries/

	Background: 
	Given Navigate to the "gallery-UGC-page" page
	And I wait for "1" seconds

@UGC_GAL_39428
Scenario:02_Open and close a gallery image
	When I select a gallery image
	Then I am taken to a lightbox gallery view
	When I select the cross at the top right of the lightbox
	Then The gallery closes and I am back on the page

	@UGC_GAL_40422
Scenario: 01_Scroll through a gallery
	When I select a gallery image
	Then I am taken to a lightbox gallery view
	When I select the next arrow on the right of the screen
	Then I am taken to the next image

	@UGC_GAL_39429
Scenario: 03_Check Image for Alt Text
	Then the image has the Alt Text "This is Alternative Text for Automated Testing"

	@UGC_GAL_43558
Scenario:04_ Using the image grid thumbnail
	When I select a gallery image
	And I am taken to a lightbox gallery view
	And I wait for "2" seconds
	When I select the grid icon at the top of the lightbox
	And I select a different image from the thumbnail options
	Then I am taken to that different image
	

		



