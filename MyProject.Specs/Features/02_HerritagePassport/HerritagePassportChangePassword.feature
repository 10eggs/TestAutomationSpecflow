Feature: HerritagePassportChangePassword
	Test scenarios cover functionality related to "Change Password" tab in Mange account section 

Background: 
	Given I am signed in and on the main My Account page
	And I navigate to My Account section
	When I am on the "My Public Profile" tab


@ignore
@HP_CHNGPW_24986
Scenario: Navigate to Password page via tabbing
	When I use the "Tab" key on my keyboard to reach "Change Password"
	And I press "Enter"
	And I am taken to the Change Password page

# Ignoring until new approach to password verification implemented
# Check if you can change password settings for stage env
@ignore
@HP_CHNGPW_24987
Scenario: Change your password
	When I am on the "Change Password" tab
	And I tab to the "CurrentPassword" input
	And I press "Enter"
	And I enter text "password" into the "Current password" field
	And I tab to the "NewPassword" input
	And I press "Enter"
	And I enter text "password" into the "New password" field
	And I tab to the "PasswordConfirmation" input
	And I enter text "password123" into the "Confirm password" field
	And I use the "Tab" key on my keyboard to reach "Change password"
	And I press "Enter"
	Then the page refreshes and text appears below the title saying "Your password has been successfully changed"
	When I enter text "password" into the "Current password" field
	And I enter text "password" into the "New password" field
	And I enter text "password" into the "Confirm password" field
	And I use the "Tab" key on my keyboard to reach "Change password"
	And I press "Enter"
	Then the page refreshes and text appears below the title saying "Your password has been successfully changed"


@HP_CHNGPW_24988
Scenario: New and Confirm password do not match
	When I am on the "Change Password" tab
	And I enter text "Password123456" into the "Current password" field
	And I enter text "password123" into the "New password" field
	And I enter text "password123123123" into the "Confirm password" field
	And I select the "Change password" button
	Then an error message shows "Passwords do not match."
	#No alert apears just from the passwords not matching. Alert only appears if navigating back to main site. Added in below.
	And I select the return to main site button
	And I close an alert

# Ignoring until new approach to password verification implemented
#@ignore
@HP_CHNGPW_25009
Scenario: New Password does not have enough characters
	When I am on the "Change Password" tab
	And I enter text "Password123456" into the "Current password" field
	And I enter text "pw1" into the "New password" field
	And I enter text "pw1" into the "Confirm password" field
	Then an error message shows "New password must be more than 10 characters in length"
	And I enter text "Password123456" into the "New password" field
	And I select the return to main site button
	#And the error message ""New password must be more than 10 characters in length" is now gone
	Then I close an alert

# Ignoring until new approach to password verification implemented
#@ignore
@HP_CHNGPW_24989
Scenario: Newsletter: Subscribe to Newsletter
	When I am on the "Newsletter" tab
	And all expected fields are present
	Then I am checking that Newsletter is not subscribed already 
	#When I select the "Subscribe!" button
	When I select the HP "Subscribe" button
	#Then the page refreshes and the button text changes to "Unsubscribe" 
	Then the page refreshes and the HP Subscribe button changes to "Unsubscribe"
	#When I select the "Unsubscribe!" button
	#Then the page refreshes and the button text changes to "Subscribe" 
	When I select the HP "Unsubscribe" button
	Then the page refreshes and the HP Subscribe button changes to "Subscribe"

@HP_CHNGPW_25012
Scenario: Incorrect current password
	When I am on the "Change Password" tab
	And I enter text "incorrectpw" into the "Current password" field
	And I enter text "newpassword123" into the "New password" field
	And I enter text "newpassword123" into the "Confirm password" field
	When I select the "Change password" button
	Then an error message shows "You have entered your password incorrectly"
