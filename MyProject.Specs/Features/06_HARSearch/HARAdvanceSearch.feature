Feature: HARAdvanceSearch
tests located on the https://stage.historic-england.org/advice/heritage-at-risk/search-register/advanced-search

Background:	
	#Given that I am on the HAR search landing page
	Given Navigate to the "advice/heritage-at-risk/search-register/" page

	Given Navigate to the "har-quick-search" page
	#And I have selected the advanced search button
	When I type "fish" into the search box
	And click on the search icon
	Then result for HAR element is present
	When I select the "Refine Search" button
	And I type "sand" into the input search box

@HARAS_18178
Scenario: Check refined results for scheduled monument option for Heritage Category drop down
	Given that I am on the HAR advanced search form
	When I select "Scheduled Monuments" from the "Heritage Category" drop down list
	Then I select the "Search" button
	And HAR results are refined by "Keyword/s: sand"
	And HAR results are refined by "Heritage Category: Scheduled Monument"

@HARAS_18180
Scenario: Check refined results for Cambridge option for Local planning authority drop down	
	Given that I am on the HAR advanced search form
	When I select "Cambridge" from the "Local Planning Authority" drop down list
	Then I click on the "Search" button for refined results
	And HAR results are refined by "Keyword/s: sand"
	And HAR results are refined by "Local Planning Authority: Cambridge"
	
@HARAS_18181
Scenario: Check refined results for Barrier option for Site type
	Given that I am on the HAR advanced search form
	When I select "Barrier" from the "Site Type" drop down list
	Then I click on the "Search" button for refined results
	And HAR results are refined by "Keyword/s: sand"
	And HAR results are refined by "Site Type: Barrier"

@HARAS_18182	
Scenario: Check refined results for building or structure option for Assessment type with added conditon
	Given that I am on the HAR advanced search form
	When I select "Building or structure" from the "Assessment Type" drop down list
	Then the form generates "Condition,Priority Category,Occupancy,Owner Type"
	When I select "Very bad" from the "Condition" drop down list
	Then I click on the "Search" button for refined results
	And HAR results are refined by "Keyword/s: sand"
	And HAR results are refined by "Condition: Very bad"

@HARAS_18183
Scenario: Check refined results for Archaeology option for Assessment type with added conditon
	Given that I am on the HAR advanced search form
	When I select "Archaeology" from the "Assessment Type" drop down list
	Then the form generates "Condition,Principal Vulnerability,Trend,Owner Type"
	When I select "Extensive significant problems" from the "Condition" drop down list
	Then I click on the "Search" button for refined results
	And HAR results are refined by "Keyword/s: sand"
	And HAR results are refined by "Condition: Extensive significant problems"

@HARAS_18184
Scenario: Check refined results for Park and garden option for Assessment type with added conditon
	Given that I am on the HAR advanced search form
	When I select "Park and garden" from the "Assessment Type" drop down list
	Then the form generates "Condition,Vulnerability,Trend,Owner Type"
	When I select "Extensive significant problems" from the "Condition" drop down list
	Then I click on the "Search" button for refined results
	And HAR results are refined by "Assessment Type: Park and garden"
	And HAR results are refined by "Condition: Extensive significant problems"

@HARAS_18185
Scenario: Check refined results for Battlefield option for Assessment type with added conditon
	Given that I am on the HAR advanced search form
	When I select "Battlefield" from the "Assessment Type" drop down list
	Then the form generates "Condition,Vulnerability,Trend,Priority Category,Owner Type"
	When I select "High" from the "Vulnerability" drop down list
	Then I click on the "Search" button for refined results
	And HAR results are refined by "Assessment Type: Battlefield"
	And HAR results are refined by "Vulnerability: High"

@HARAS_18186
Scenario: Check refined results for Wrek Site option for Assessment type with added conditon
	Given that I am on the HAR advanced search form
	When I select "Wreck site" from the "Assessment Type" drop down list
	Then the form generates "Condition,Vulnerability,Trend,Priority Category,Owner Type"
	When I select "Declining" from the "Trend" drop down list
	Then I click on the "Search" button for refined results
	And HAR results are refined by "Assessment Type: Wreck site"
	And HAR results are refined by "Trend: Declining"

@HARAS_18187
	Scenario: Check refined results for Place of Worship option for
		  Assessment type with added conditon
	Given that I am on the HAR advanced search form
	When I select "Place of worship" from the "Assessment Type" drop down list
	Then the form generates "Condition,Priority Category,Owner Type"
	When I select "Good" from the "Condition" drop down list
	Then I click on the "Search" button for refined results
	And HAR results are refined by "Assessment Type: Place of worship"
	And HAR results are refined by "Condition: Good"

@HARAS_18188,HARAS_18189
Scenario: Check refined results for Cornwall option for Unitary Authority		
	Given that I am on the HAR advanced search form
	When I click on More Location Options button
	Then the form generates "County,Unitary Authority,etc"
	When I select "Cornwall (UA)" from the "Unitary Authority" drop down list
	Then I click on the "Search" button for refined results
	And HAR results are refined by "Unitary Authority: Cornwall (UA)"
	
