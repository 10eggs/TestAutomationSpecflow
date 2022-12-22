Feature: Sign in
		Test scenarios cover functionality related to Sign In option available on home page

Background: 
	When I select the "Sign in" anchor

@HP_SIGNIN_24658
Scenario: AASign in and Sign out to account
	Then I am redirected to the Sign in page
	When I enter text "tomasz.pawlak@historicengland.org.uk" into the "Email" field
	And I enter text "password123456" into the "Password" field 
	And I select the "Sign in" button
	Then I am logged in
	When I select the "My account" anchor
	And I get a drop down saying "Manage my account" or "Sign out"
	When I select the "Sign out" anchor
	Then I am logged out

	
@HP_SIGNIN_24659
Scenario: Incorrect email
	Then I am redirected to the Sign in page
	When I enter text "incorrectemail" into the "Email" field
	And I select the "Sign in" button
	Then Warning prompt is present

@HP_SIGNIN_24661
Scenario: Icon to show or hide password
	When I enter text "password" into the "Password" field 
	#Then "Show password" button to show or hide password
	And I select the Show icon
	Then I can now see my text
   
@HP_SIGNIN_24660
Scenario: Forgotten password
	When I select the "Forgotten your password?" anchor
	Then I am redirect to "https://stage-sa.historic-england.org/forgot-password/"

@HP_SIGNIN_24750
Scenario: Sign in and Sign out via List Entry 
	#Given that I am on a historic england list entry
	Given Navigate to the "List Entry 1234567" page
	And I select the comments tab
	#When I select the "Sign in to add your comment" anchor
	When I select the List Entry Sign in link
	And I enter text "tomasz.pawlak@historicengland.org.uk" into the "Email" field
	And I enter text "password123456" into the "Password" field 
	And I select the "Sign in" button
	Then I am logged in
	And I am taken back to the list entry but I am signed in and a comment box is at the bottom of the list entry
	When I select the "My account" anchor
	And I get a drop down saying "Manage my account" or "Sign out"
	When I select the "Sign out" anchor
	Then the List Entry Sign in Link is present
	#Then in place of the comment box is the "Sign in to add your comment" button