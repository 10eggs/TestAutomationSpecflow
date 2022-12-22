Feature: ArticlePageAccordion
	Test scenarios cover functionality connected with Accordion on
	https://stage.historic-england.org/admin-section/automation-test-area/automation-test-article/


Background:
	#Given that I am on the test article page
	Given Navigate to the "article-test" page
	When I have clicked on the "This is an Accordion" contents link

@ACCOR_21546
Scenario: Site users can open the accordion headings to get further information
	When I click on accordion headings
	Then the headings should expand to display the answer
	And the chevron for that accordion should be pointing upwards
	When I click on accordion headings
	Then the accordion should close


@ACCOR_21548
Scenario: Multiple questions can be open simultaneously
	When I click on accordion headings
	Then the headings should expand to display the answer
	And I click on "Heritage Online Debate"
	Then just heritage online debate should close
