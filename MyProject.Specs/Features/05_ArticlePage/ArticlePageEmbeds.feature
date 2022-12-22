Feature: ArticlePageEmbeds
	Test scenarios cover functionality around embeds from Social Media sites
	https://stage.historic-england.org/admin-section/automation-test-area/automation-test-article/

Background: 
	#Given that I am on the test article page
	Given Navigate to the "article-test" page

@EM_24153
Scenario: Facebook embed
	When I have clicked on the "This is a facebook post" contents link
	Then "facebook" message renders on the page

@EM_24154
Scenario: Twitter embed
	When I have clicked on the "This is a tweet" contents link
	Then "twitter" message renders on the page

@ignore
@EM_24158
Scenario: Instagram embed
	When I have clicked on the "This is a Instagram post" contents link
	Then "instagram" message renders on the page

@EM_24159
Scenario: Infogram embed
	When I have clicked on the "This is a infogram" contents link
	Then "infogram" message renders on the page

@EM_24160
Scenario: Youtube embed
	When I have clicked on the "this is a youtube video" contents link
	Then "youtube" message renders on the page