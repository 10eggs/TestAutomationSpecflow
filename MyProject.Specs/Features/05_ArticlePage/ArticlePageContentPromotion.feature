Feature: ArticlePageContentPromotion
	Test scenarios cover functionality around Content promotion on
	https://stage.historic-england.org/admin-section/automation-test-area/automation-test-article/


Background: 
	#Given that I am on the test article page
	Given Navigate to the "article-test" page
	When I have clicked on the "This is a content promotion" contents link

@CONPROM_22329
Scenario: Is the call to action button working
#Hide url to step definition
	When I click on element with text "Dive Norman"
	Then I am redirect to "https://www.nauticalarchaeologysociety.org/content/normans-bay-protected-wreck-site"

@CONPROM_22331
Scenario: is the link working
#Hide url to step definition
	When I click on element with text "Find out why Normans Bay is protected"
	Then I am redirect to "https://historicengland.org.uk/listing/the-list/list-entry/1000084"

@CONPROM_22332
Scenario: Is there alt text
	Then it has has descriptive alt-text

