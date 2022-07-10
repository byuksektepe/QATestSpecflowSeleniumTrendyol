Feature: Trendyol
	Trendyol Complete Tests BDD

@Smoke @Common
Scenario: Visitor should be able search product and add to cart
	Given Navigate to trendyol website
	And Search for product "Laptop" in search
	When Click first product in results
	And Verify product detail page opened
	And Click add to cart button
	And Click see cart button
	Then Verify product added to cart


@Smoke @Favorites
Scenario: Visitor should be able click add to favorites button and redirect login page
	Given Navigate to trendyol website
	And Search for product "Watch" in search
	When Click first product in results
	And Verify product detail page opened
