Feature: Search

Trendyol Search Feature File

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
