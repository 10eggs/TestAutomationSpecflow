Feature: ArticlePageFeatureImage
	Test scenarios cover functionality around Feature Image on
	https://stage.historic-england.org/admin-section/automation-test-area/automation-test-article/

Background: 
	#Given that I am on the test article page
	Given Navigate to the "article-test" page


@FEAIMG_22296
Scenario: About this image opens and closes
	When I click About this image button
	Then the button opens and reveals the "this is a caption" text
	When I click About this image button
	Then description closes

@FEAIMG_22297
Scenario: Image has alt text
	When I inspect the feature image 
	Then I see that it has alt attribute with text "this is alt text" 

#Expected size need to be discussed
@FEAIMG_22298
Scenario: image size is correct
	When I inspect the feature image 
	Then the image has an expected width of "1"	