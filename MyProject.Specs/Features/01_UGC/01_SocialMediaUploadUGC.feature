@ignore
Feature: 01_SocialMediaUploadUGC
	Test scenarios cover interaction with the social media upload function of the UGC page as an unmoderated user
	https://stage.historic-england.org/admin-section/automation-test-area/ugc-automated-testing-unmoderated/

		Background:
	Given Navigate to the "social-media-UGC-page" page
	And I have signed in as an unmoderated social media user

#Note: When using the step definition concerning continuing with "X" button, ensure you use lowercase for the social media platform name.
@UGC_UNM_41186
Scenario: Adding an Instagram Image comment as an unmoderated user
	Given I want to upload an image and have typed out the comment "This is a test image upload using an Instagram account"
	When I select the "Instagram" tab from the image upload menu
	And I select the continue with "instagram" button
	When I sign in to Instagram
	And I select the "This is a pretty dog" image
	When I add the selected image
	And I enter the text "this is alt text" and string in the alt text box
	And I submit my comment for approval
	Then I refresh and check the new comment and image are at the top of the page

#Note: When using the step definition concerning continuing with "X" button, ensure you use lowercase for the social media platform name.
@UGC_UNM_41185
Scenario: Adding a Facebook Image comment as an unmoderated user
	Given I want to upload an image and have typed out the comment "This is a test image upload using a Facebook account"
	When I select the "Facebook" tab from the image upload menu
	And I select the continue with "facebook" button
	When I sign in to Facebook
	And I select an image from the "Timeline photos" album
	When I add the selected image
	And I enter the text "this is alt text" and string in the alt text box
	And I submit my comment for approval
	Then I refresh and check the new comment and image are at the top of the page
