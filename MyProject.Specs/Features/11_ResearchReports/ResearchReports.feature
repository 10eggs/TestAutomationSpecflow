@ignore
Feature: ResearchReports
	Simple calculator for adding two numbers

Background: 
	Given Navigate to the "RR-search" page
@mytag
Scenario: Add two numbers
	Given I type "fish" into the search box
	When I click on the search icon
	Then I am taken to the "Search All Publications" results filtered by "house" category