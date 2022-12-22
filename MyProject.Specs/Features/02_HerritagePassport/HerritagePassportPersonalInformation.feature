Feature: HerritagePassportPersonalInformation
	Test scenarios cover functionality related to "Personal Information" tab in Mange account section 

Background:
	Given I am signed in and on the main My Account page
	And I navigate to My Account section
	When I am on the "Personal Information" tab


@HP_PERINFO_24752
Scenario: Personal information page
	Then I am taken to a page titled "Personal Information"

@HP_PERINFO_24784
Scenario: Save first name
	Then the "Save changes" button is not clickable
	When make a change in the "First name" field
	Then the "Save changes" button is clickable
	When I select the "Save changes" button
	Then the page refreshes with the new change showing in "First name" field
	When I delete the text in the "First name" field
	And I select the "Save changes" button
	Then an error message shows "First name is a required field."

@HP_PERINFO_24785
Scenario: Delete my account page
	When I select the "I would like to delete my account" anchor
	Then I am taken to the delete account section

@HP_PERINFO_25014
Scenario: Incorrect password on account deletion
	When I select the "I would like to delete my account" anchor
	And I enter text "incorrectpw" into the "Password" field
	And I select the "Delete my account" button
	Then an error message shows "Password is not correct"

@HP_PERINFO_24786
Scenario: Delete my account extension
	When I select the "I would like to delete my account" anchor
	Then the "Delete my account" button is not clickable
	When I enter text "somepassword" into the "Password" field
	Then the "Delete my account" button is clickable
	When I select the "Cancel" anchor
	And I close an alert
	And I select the return to main site button
	#Then page returns to the personal information section
	#Then the page returns me to the About Us page
	Then the page returns me to the Home Page
	