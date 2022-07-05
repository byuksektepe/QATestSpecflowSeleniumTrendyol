Feature: Trendyol
	Trendyol Chrome Browser Tests

@Smoke
Scenario: Trendyol.com should be work on chrome browser
	Given Navigate to trendyol website
	And Search for product "Laptop" in search
	Then Click first product in results

