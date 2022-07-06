Feature: Trendyol
	Trendyol Chrome Browser Tests

@Smoke
Scenario: Trendyol.com should be work on chrome browser
	Given Navigate to trendyol website
	And Search for product "Laptop" in search
	When Click first product in results
	And Verify product detail page opened
	And Click add to cart button
	And Click see cart button

