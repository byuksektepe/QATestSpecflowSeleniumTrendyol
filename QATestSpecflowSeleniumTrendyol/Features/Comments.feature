Feature: Comments

Trrendyol Comments Feature File

@Smoke @Comments
Scenario: Visitor should be see product comments
	Given Navigate to trendyol website
	And Search for product "Iphone 12" in search
	And Verify search executed
	When Click first product in results
	And Verify product detail page opened
	Then Verify visitor see product comments
