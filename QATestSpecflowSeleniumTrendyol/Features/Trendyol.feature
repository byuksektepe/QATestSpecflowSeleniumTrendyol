Feature: Trendyol
	
	Trendyol Complete Tests BDD, Test badge now TC-U

![tcu](https://raw.githubusercontent.com/Berkantyuks/QA-Project-Test-Classification-Mark/main/TCM-114x40/114x40-tc-u.png)


@Smoke @Common
Scenario: 01 Visitor should be able search product and add to cart
	Given Navigate to trendyol website
	And Search for product "Laptop" in search
	When Click first product in results
	And Verify product detail page opened
	And Click add to cart button
	And Click see cart button
	Then Verify product added to cart

@Smoke @Favorites
Scenario: 02 Visitor should be able click add to favorites button and redirect login page
	Given Navigate to trendyol website
	And Search for product "Watch" in search
	When Click first product in results
	And Verify product detail page opened
	And Click add to favorites button
	Then Verify login page opened

@Smoke @Comments
Scenario: 03 Visitor should be see product comments
	Given Navigate to trendyol website
	And Search for product "Iphone 12" in search
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
	And Search for product "<SearchItem>" in search
	And Set brand filter to "<Brand>"
	And Set price filter "<MinPrice>" and "<MaxPrice>"
	When Click first product in results
	And Verify product detail page opened
	And Verify product brand is "<Brand>"
	Then Verify product title contains "<SearchItem>"

Examples: 
	| SearchItem      | Brand   | MinPrice | MaxPrice |
	| Kamp Sandalyesi | Quechua | 200      | 350      |