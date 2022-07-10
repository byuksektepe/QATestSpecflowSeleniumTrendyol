Feature: Trendyol
	Trendyol Complete Tests BDD

@Smoke
Scenario: Trendyol.com should be work on selected browser
	Given Navigate to trendyol website
			| Browser | Options |
			| Firefox | Enabled |
	And Search for product "Laptop" in search
	When Click first product in results
	And Verify product detail page opened
	And Click add to cart button
	And Click see cart button
	Then Verify product added to cart

