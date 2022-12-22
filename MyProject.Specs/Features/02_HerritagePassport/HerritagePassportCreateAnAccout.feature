Feature: HerritagePassportCreateAnAccout
	Test scenarios cover functionality related to Create Account option 

@25073-HerrPassCreAcc
Scenario: Navigate to register page
	When I select the "Sign in" anchor
	And I select the "Create an account" anchor
	Then I am taken to the register page


@25074-HerrPassCreAcc
Scenario: Leaving fields blank error message

	#Refactor
	When I select the "Sign in" anchor
	And I select the "Create an account" anchor
	And I enter text "Name" into the "First name" field
	And I select the "Create account" button
	Then the page refreshes and error messages are present

@25075-HerrPassCreAcc
Scenario: Show password
	Given that I am on the register page
	When I enter text "CanUSeeMe" into the password field
	And I select the Show icon
	Then I can now see my text
	#Then "Show password" button to show or hide password


@25077-HerrPassCreAcc
Scenario: Using existing account
	Given that I am on the register page
	When I enter text "John" into the "First name" field
	And I enter text "Smith" into the "Last name" field
	And I enter text "tomasz.pawlak@historicengland.org.uk" into the "Email address" field
	And I enter text "password12" into the "Password" field
	And I click the "I agree" tick box
	And I select the "Create account" button
	Then an error message shows "This email address is already being used by an existing an account."

@25078-HerrPassCreAcc
Scenario: Submitting the form
	Given that I am on the register page
	When I enter text "John" into the "First name" field
	And I enter text "Smith" into the "Last name" field
	And I enter text "password12" into the "Password" field
	And I enter random email into the "Email address" field
	And I click the "I agree" tick box
	And I select the "Create account" button
	Then the page goes to the successful registration page

@25175-HerrPassCreAcc
Scenario: Decline TC
	Given that I am on the register page
	When I enter text "John" into the "First name" field
	And I enter text "Smith" into the "Last name" field
	And I enter text "tomasz.pawlak@historicengland.org.uk" into the "Email address" field
	And I enter text "password" into the "Password" field
	And I select the "Create account" button
	Then an error message shows "You must accept the T&C"

@25176-HerrPassCreAcc
Scenario: Sign in with unverified account
	Given that I am on the register page
	When I enter text "John" into the "First name" field
	And I enter text "Smith" into the "Last name" field
	And I enter text "password12" into the "Password" field
	And I enter random email into the "Email address" field
	And I click the "I agree" tick box
	And I select the "Create account" button
	Then Im back to homepage
	When I select the "Sign in" anchor
	And I enter random email generated previously into the "Email address" field
	And I enter text "password12" into the "Password" field
	And I select the "Sign in" button
	Then I click the "I agree" tick box
	And I select the "Accept" button
	And I select the "Sign in" anchor
	And I enter random email generated previously into the "Email address" field
	When I enter text "password" into the "Password" field
	When I select the "Sign in" button
	Then an error message shows "Invalid email address or password."




