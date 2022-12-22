Feature: 03_ModeratedUGCPage
	Test scenarios cover interaction with UGC page as a moderated user
	https://stage.historic-england.org/admin-section/automation-test-area/ugc-automated-testing-moderated/

	Background:
	Given Navigate to the "moderated-UGC-page" page
	And I have signed in as a moderated user

#ignore until ugc Nick fix
#@ignore
@UGC_MOD_40213
Scenario: Adding a text comment as a moderated user
	When I select the "Add your comment" button
	And I enter text "This is an Automated Regression Test from a Moderated User" and string into the comment box
	And I wait for "1" seconds
	And I submit my comment for approval
	Then The new comment is at the top of the page and pending approval after refreshing
	Then The comment no longer shows after signing out
	
#ignore until ugc Nick fix
#@ignore
@UGC_MOD_40215
Scenario: Adding an image comment as a moderated user
	When I select the "Add your comment" button
	And I enter text "This is an Automated Regression Image Test from a Moderated User" and string into the comment box
	When I select the "Add your photos" button
	And I select the "Add a photo (1 of 4)" button
	When I select the "Choose a local file" button
	And Select the "Houses" image to upload
	When I add the selected image
	And I enter the text "this is alt text" and string in the alt text box
	And I submit my comment for approval
	Then The new comment is at the top of the page and pending approval after refreshing
	Then The new image contains the correct alt text
	Then The comment no longer shows after signing out


@UGC_MOD_40392
Scenario: Text comment appears in profile as a Pending comment
	Given I have typed out the comment "This is an Automated Regression Test from a Moderated User"
	And I submit my comment for approval
	When I select the "View your profile" anchor
	And I select "Pending" from the "Status" drop down list
	Then The new comment is at the top of the page
	When Navigate to the "moderated-UGC-page" page
	Then The comment no longer shows after signing out

@ignore
@UGC_MOD_40405
Scenario: Post a reply as a moderated user
	Given Navigate to the "replies-UGC-page" page
	When I wait for page to load and click the "Reply" anchor
	And I enter text "this is a reply from a moderated account" and string into the comment box
	And I select the "Submit reply" button
	And I close the add contribution modal
	Then The new comment is at the top of the page and pending approval after refreshing
	And I sign out

#ignore until ugc Nick fix
#@ignore
@UGC_MOD_40403
Scenario: Edit my comment as a moderated user
	When I select the "Add your comment" button
	And I enter text "This is an Automated Regression Test from a Moderated User" and string into the comment box
	And I submit my comment for approval
	When I refresh the page
	And I wait for "1" seconds
	When I select the options icon
	Then "View My Profile" element is present
	Then "Close" element is present
	And I select the "Edit" anchor
	And I enter text " this is an edit" and string into the comment box
	And I submit my comment edit
	And I close the add contribution modal
	When I refresh the page
	Then The edited comment is at the top of the page
	And I sign out
