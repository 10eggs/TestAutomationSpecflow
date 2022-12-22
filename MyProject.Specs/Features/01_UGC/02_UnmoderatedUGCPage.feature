Feature: 02_UnmoderatedUGCPage
	Test scenarios cover interaction with UGC page as an unmoderated user
	https://stage.historic-england.org/admin-section/automation-test-area/ugc-automated-testing-unmoderated/

	Background:
	Given Navigate to the "unmoderated-UGC-page" page
	And I have signed in as an unmoderated user

@UGC_UNM_40396
Scenario: Adding a text comment as an unmoderated user
	When I select the "Add your comment" button
	And I enter text "This is an Automated Regression Test from an Unmoderated User" and string into the comment box
	And I submit my comment for approval
	When I refresh the page
	Then The new comment is at the top of the page
	And I sign out

	
@UGC_UNM_40404
Scenario: Adding an image comment as an unmoderated user
	Given I have typed out the comment "This is an Automated Regression Image Test from an Unmoderated User"
	When I select the "Add your photos" button
	And I select the "Add a photo (1 of 4)" button
	When I select the "Choose a local file" button
	And Select the "Houses" image to upload
	When I add the selected image
	And I enter the text "this is alt text" and string in the alt text box
	And I submit my comment for approval
	When I refresh the page
	Then The new comment is at the top of the page
	Then The new image contains the correct alt text
	And I sign out	

	@UGC_UNM_45004
Scenario: Opening and Closing the Alt Text Button 
	Given I have typed out the comment "This is an Automated Regression Image Test from an Unmoderated User"
	When I select the "Add your photos" button
	And I select the "Add a photo (1 of 4)" button
	When I select the "Choose a local file" button
	And Select the "Houses" image to upload
	When I add the selected image
	And I select the minus icon
	Then the icon changes to a plus and the box closes
	And I close the add contribution modal
	And I select the "Yes, discard comments" button
	And I sign out	
	

	@UGC_UNM_40408
Scenario: Adding multiple Images to a comment as an unmoderated user
	Given I want to upload an image and have typed out the comment "This is an Automated Regression Image Test from an Unmoderated User"
	When I select the "Choose a local file" button
	And Select the "Houses" image to upload
	When I add the selected image
	And I enter the text "this is alt text" and number in the alt text box for image "1"
	And I select the "Add a photo (2 of 4)" button
	#TODO The below button might get renamed to "Choose from device" as a bug fix.
	When I select the "Choose a local file" button
	And Select the "Sea" image to upload
	When I add the selected image
	And I enter the text "this is alt text" and number in the alt text box for image "2"
	And I submit my comment for approval
	When I refresh the page
	Then The new comment is at the top of the page
	Then Check image "1" has successfully uploaded
	Then Check image "2" has successfully uploaded
	And I sign out	


@UGC_UNM_40414
Scenario: Adding a YouTube video comment as an unmoderated user
	Given I have typed out the comment "this is an Automated Regression Image Test from a YouTube video"
	When I select the "Add a YouTube Video" button
	And Copy in the URL "https://www.youtube.com/watch?v=Gr-WWq6UJzY"
	And I submit my comment for approval
	When I refresh the page
	Then The new comment is at the top of the page
	Then The video "https://www.youtube.com/watch?v=Gr-WWq6UJzY" is at the top of the page
	When I click the play button on the YouTube video in the top comment
	Then The YouTube video begins to play
	And I sign out


@UGC_UNM_40406
Scenario: Text comment appears in profile as an Approved comment
	When I select the "Add your comment" button
	And I enter text "This is an Automated Regression Test from an Unmoderated User" and string into the comment box
	And I submit my comment for approval
	When I select the "View your profile" anchor
	And I select "Approved" from the "Status" drop down list
	Then The new comment is at the top of the page
	And I sign out


@UGC_UNM_40409
Scenario: Closing the comment box via "X"
	When I select the "Add your comment" button
	Then "Add Comment" element is present
	And I close the add contribution modal
	And I select the "Yes, discard comments" button
	Then Element with text "Add your comment" is present
	And I sign out


@UGC_UNM_40411
Scenario: Closing the comment box via "Cancel"
	When I select the "Add your comment" button
	Then "Add Comment" element is present
	And I select the "Cancel" button
	Then Element with text "Add your comment" is present
	And I sign out


@UGC_UNM_40421
Scenario: Sorting comments by oldest to newest
	When I select "Oldest to newest" from the "Sort by" drop down list
	Then The oldest comment "This is the oldest comment on this page" is at the top of the page
	And I sign out


@UGC_UNM_40423
Scenario: Check my profile using options navigation as an unmoderated user
	When I select the options icon
	And I select the "View My Profile" anchor
	Then I select "Approved" from the "Status" drop down list
	When I use the browser function to back to the previous page
	And I select the options icon
	When I select the "Close" anchor
	Then The options menu closes
	And I sign out


@ignore
@UGC_UNM_40405
Scenario: Post a reply as an unmoderated user
	Given Navigate to the "replies-UGC-page" page
	When I select the "Reply" anchor
	And I enter text "this is a reply from an unmoderated account" and string into the comment box
	And I select the "Submit reply" button
	And I close the add contribution modal
	Then I refresh and check the new comment is at the top of the page

#@ignore
@UGC_UNM_43617
Scenario: Change Status of My Profile
	Given Navigate to the "UGC Profile Page" page
	When I select "pending" from the "Status" drop down list
	Then the comment "This is pend?" is present
	When I select "awaiting edit" from the status drop down
	Then the comment "This is awaiting an edit" is present
