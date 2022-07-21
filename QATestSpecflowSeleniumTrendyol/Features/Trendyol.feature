Feature: Trendyol
	
	Trendyol Complete Tests BDD, Test badge now TC-A
	All scenarios are in one feature file, optionally scenarios can be moved to separate feature files.

![tcu](https://raw.githubusercontent.com/Berkantyuks/QA-Project-Test-Classification-Mark/main/TCM-114x40/114x40-tc-a.png)


@Smoke @Common
Scenario: 01 Visitor should be able search product and add to cart
	Given Navigate to trendyol website
	And Search for product "Laptop" in search
	And Verify search executed
	When Click first product in results
	And Verify product detail page opened
	And Click add to cart button
	And Click see cart button
	Then Verify product added to cart

@Smoke @Favorites
Scenario: 02 Visitor should be able click add to favorites button and redirect login page
	Given Navigate to trendyol website
	And Search for product "Watch" in search
	And Verify search executed
	When Click first product in results
	And Verify product detail page opened
	And Click add to favorites button
	Then Verify login page opened

@Smoke @Comments
Scenario: 03 Visitor should be see product comments
	Given Navigate to trendyol website
	And Search for product "Iphone 12" in search
	And Verify search executed
	When Click first product in results
	And Verify product detail page opened
	Then Verify visitor see product comments

@Smoke @Footer
Scenario: 04 Visitor should be able to see footer
	Given Navigate to trendyol website
	When Scroll to footer
	Then Verify footer is visible

@Smoke @MoveToTop
Scenario: 05 Move to top button should be work
	Given Navigate to trendyol website
	When Scroll to footer
	And Verify footer is visible
	And Click move to top button
	Then Verify top of the page is visible

@Smoke @Filter
Scenario Outline: 06 Visitor should be able search product using filters
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

@Smoke @ProductSeller
Scenario: 09 Visitor should be able see product seller
	Given Navigate to trendyol website
	And Search for product "İpad Mini" in search
	And Verify search executed
	When Click first product in results
	And Verify product detail page opened
	And Get product seller name
	And Click product seller page link
	And Verify seller page opened
	Then Verify the product seller with received name


