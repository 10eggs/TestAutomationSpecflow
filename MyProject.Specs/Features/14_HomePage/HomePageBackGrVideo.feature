Feature: HomePageBackGrVideo
Tests located on page - /admin-section/automation-test-area/automation-testing-home-page/

@ignore
@HP_BGVideo_21380
@HP_BGVideo_21381
##Verify if btn is present
##Click on the btn
##Verify if user is redirected to the '/advice' area
Scenario: Check Background Video link is present
#Given I have navigated to the Automation Testing Home Page
Given Navigate to the "home-page-test" page
Then a youtube embedded video is playing in the background video test
When I click on the button called "test of a background video"
Then I am taken to the advice HE page

@ignore
##Check yt url and if button is visible
@HP_Video_21382
Scenario: Check video link and play button is present
	Given Navigate to the "home-page-test" page
	When I scroll down the page to where it says Video Test
	Then I can see the play button
