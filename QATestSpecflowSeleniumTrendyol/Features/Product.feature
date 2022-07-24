Feature: Product

Trendyol Product Feature File

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

@Smoke @MultipleProduct
Scenario Outline: Visitor should be able add multiple products to cart
	Given Navigate to trendyol website
	And Search for product "<SearchQuery>" in search
	And Verify search executed
	When Click first product in results
	And Verify product detail page opened
	And Get Product base link
	And Click add to cart button
	And Click see cart button
	And Verify cart page opened
	And Verify Product added to cart by received base link
	And Click "<ButtonType>" Button for "<ClickTimes>" times
	Then verify that the number of products is increased correctly by "<ClickTimes>"


Examples: 
	| SearchQuery  | ButtonType | ClickTimes |
	| Kurşun Kalem | Up         | 4          |
	| Silgi        | Up         | 7          |