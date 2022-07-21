Feature: TrendyolMain
	
	Trendyol Complete Tests BDD, Test badge now TC-A
	All scenarios are in one feature file, optionally scenarios can be moved to separate feature files.

![tcu](https://raw.githubusercontent.com/Berkantyuks/QA-Project-Test-Classification-Mark/main/TCM-114x40/114x40-tc-a.png)



@Smoke @Favorites
Scenario: Visitor should be able click add to favorites button and redirect login page
	Given Navigate to trendyol website
	And Search for product "Watch" in search
	And Verify search executed
	When Click first product in results
	And Verify product detail page opened
	And Click add to favorites button
	Then Verify login page opened

@Smoke @Footer
Scenario: Visitor should be able to see footer
	Given Navigate to trendyol website
	When Scroll to footer
	Then Verify footer is visible

@Smoke @MoveToTop
Scenario: Move to top button should be work
	Given Navigate to trendyol website
	When Scroll to footer
	And Verify footer is visible
	And Click move to top button
	Then Verify top of the page is visible

@Smoke @ProductSeller
Scenario: Visitor should be able see product seller
	Given Navigate to trendyol website
	And Search for product "İpad Mini" in search
	And Verify search executed
	When Click first product in results
	And Verify product detail page opened
	And Get product seller name
	And Click product seller page link
	And Verify seller page opened
	Then Verify the product seller with received name


