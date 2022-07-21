Feature: Search

Trendyol Search Feature File

@Smoke @Common
Scenario: Visitor should be able search product and add to cart
	Given Navigate to trendyol website
	And Search for product "Laptop" in search
	And Verify search executed
	When Click first product in results
	And Verify product detail page opened
	And Click add to cart button
	And Click see cart button
	Then Verify product added to cart

@Smoke @Filter
Scenario Outline: Visitor should be able search product using filters
	Given Navigate to trendyol website
	And Search for product "<SearchQuery>" in search
	And Verify search executed
	And Set brand filter to "<Brand>"
	And Set photo review filter if selected "<PhotoReview>"
	And Set free cargo filter if selected "<FreeCargo>"
	And Set price filter Min:"<MinPrice>" and Max:"<MaxPrice>"
	When Click first product in results
	And Verify product detail page opened
	And Verify product brand is "<Brand>"
	Then Verify product title contains "<SearchQuery>"

Examples: 
	| SearchQuery     | Brand   | MinPrice | MaxPrice | PhotoReview | FreeCargo |
	| Kamp Sandalyesi | Quechua | 200      | 350      | x           |           |
	| iphone 11       | Apple   | 10000    | 14000    |             | x         |
	| Alet Çantası    | Bosch   | 300      | 400      | x           |           |
