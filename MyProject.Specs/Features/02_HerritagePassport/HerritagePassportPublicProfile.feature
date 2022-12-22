Feature: HerritagePassportPublicProfile
		Test scenarios cover functionality related to "Public Profile" tab in Mange account section 

Background: 
	Given I am signed in and on the main My Account page
	And I navigate to My Account section
	When I am on the "My Public Profile" tab

@HP_PUBPROF_24753
Scenario: Navigate to Public Profile page
	Then I am taken to a page "My Public Profile"

@HP_PUBPROF_24864
Scenario: Save "About me" change
	Then the "Save changes" button is not clickable
	When I add text into "About me" input 
	Then the "Save changes" button is clickable
    When I select the "Save changes" button
	Then the page refreshes and can see my text in the "About me" input
	#And when I navigate to "https://stage.historic-england.org/listing/the-list/profile/5404"
	And Navigate to the "Pulic Profile Page" page
	Then the text added to "About me" matches the public profile

@HP_PUBPROF_24880
Scenario: Add avatar image
	When select photo to add
	And I select the "Save changes" button
	Then the photo preview changes in the window
	#And when I navigate to "https://stage.historic-england.org/listing/the-list/profile/5404"
	And Navigate to the "Pulic Profile Page" page
	Then the image shows on the profile page

    #Note: This test only works if test 24880 runs first, if re-run on error it will fail if 24880 is not ran
@HP_PUBPROF_24881
Scenario: Remove avatar image
	When I click the "Remove profile image" tick box
	And I select the "Save changes" button
	Then the avatar changes to generic one
	#And when I navigate to "https://stage.historic-england.org/listing/the-list/profile/5404"
	And Navigate to the "Pulic Profile Page" page
	Then the default image shows on the profile page


@HP_PUBPROF_24882
Scenario: Adding a Organisation Name
	When I add text into "Organisation" input 
	And I click the "show instead of your full name" tick box
	When I select the "Save changes" button
	Then the page refreshes and can see my text in the "Organisation" input

	#Then the "organisation name" replaces the user name on the public profile page https://stage.historic-england.org/listing/the-list/profile/3462
	#Note - this has to be moderated - we cannot actually test this but can test the button works etc
	#Profile page updated to new NHLE AT "PUBLIC PROFILE PAGE" origin page

# how to deactivate this test on stage as the developers need to run debig mode on stage and that error page cannot be tested inside selenium in eadless, will reactivate
# if debugger is tunred off later
@ignore
@HP_PUBPROF_24883
Scenario: Save Hide my information
	When I click the "If you do not want your public profile information shown on the Historic England website, please tick this box" tick box
	And I scroll to the bottom of the page
	And I select the "Save changes" button
	#Then when I navigate to "https://stage.historic-england.org/listing/the-list/profile/5404"
	Then Navigate to the "Pulic Profile Page" page
	And the information on "are not" present on Historic England website
	When I use the browser function to back to the previous page
	And I click the "If you do not want your public profile information shown on the Historic England website, please tick this box" tick box
	And I select the "Save changes" button
	#Then when I navigate to "https://stage.historic-england.org/listing/the-list/profile/5404"
	Then Navigate to the "Pulic Profile Page" page
	And the information on "are" present on Historic England website
