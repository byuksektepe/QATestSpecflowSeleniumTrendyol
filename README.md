## QA Trendyol Automated Tests With Specflow .NET

 ![C#](https://img.shields.io/badge/C%23-000000?style=for-the-badge&logo=c-sharp&logoColor=white)
 ![.NET](https://img.shields.io/badge/.NET-000000?style=for-the-badge&logo=dotnet&logoColor=white)
 ![Selenium](https://img.shields.io/badge/Selenium-000000?style=for-the-badge&logo=Selenium&logoColor=white)
 ![TeamCity](https://img.shields.io/badge/TeamCity-000000?style=for-the-badge&logo=TeamCity&logoColor=white)
 ![Git](https://img.shields.io/badge/GIT-000000?style=for-the-badge&logo=git&logoColor=white)
 ![TEST-002-A](https://img.shields.io/badge/TEST%20002%20A-000000?style=for-the-badge&logo=null&logoColor=white)
<a href="https://github.com/Berkantyuks/QA-Project-Test-Classification-Mark#test-class-a" rel="tc-a"><img width="79px" style="border-width: 0;" src="https://github.com/Berkantyuks/QA-Project-Test-Classification-Mark/blob/main/TCM-114x40/114x40-tc-a.png" alt="tc-a" /></a>

<p>Software All-Encompassing QA Test Project For Trendyol. Using Specflow .NET BDD with Selenium and NUnit Test Framework. TeamCity was used as CI/CD. Automated tests are Designed for be Easy-To-Read, Easy-To-Maintain and Easy-To-Understand. OOP used. Includes only smoke tests, regression and integration tests will be added later.
The tests will be perform 90% automation 10% manually. The tests are optimized for Chrome, Edge and Safari browsers.</p>

<p>All Feature files located in <a href="https://github.com/Berkantyuks/QATestSpecflowSeleniumTrendyol/tree/master/QATestSpecflowSeleniumTrendyol/Features">/Features</a></p>
<p>All Resorces located in <a href="https://github.com/Berkantyuks/QATestSpecflowSeleniumTrendyol/tree/master/QATestSpecflowSeleniumTrendyol/Resources">/Resorces</a></p>
<p>All Page Opjects located in <a href="https://github.com/Berkantyuks/QATestSpecflowSeleniumTrendyol/tree/master/QATestSpecflowSeleniumTrendyol/PO">/PO</a></p>
<p>All Step Definitions located in <a href="https://github.com/Berkantyuks/QATestSpecflowSeleniumTrendyol/tree/master/QATestSpecflowSeleniumTrendyol/StepDefinitions">/StepDefinitions</a></p>

### Test Environment Requirements
- .NET Desktop Development.
- Visual Studio or Jetbrains Rider as IDE.

### Test Runtime Requirements
- SpecFlow Extension for Visual Studio or Rider.
- NUnit Test Framework.

### NuGet Packages That Must be Installed
- NUnit
- NUnit3TestAdapter
- Microsoft.NET.Test.Sdk
- FluentAssertions
- Selenium.WebDriver
- Selenium.Support
- DotNetSeleniumExtras.WaitHelpers
- SpecFlow.Assist.Dynamic
- SpecFlow.NUnit
- SpecFlow.Plus.LivingDocPlugin

### Clone for TeamCity CI/CD
```
https://github.com/Berkantyuks/QATestSpecflowSeleniumTrendyol.git
```
### Generate SpecFlow Living Documentation
Open terminal and type  ```livingdoc``` for start execution, then type  ```feature-folder``` to give the project file path and type ```-t``` to give TestExecution.json file. After typing all the necessary parameters hit enter then LivingDoc will be generated in project directory.

Example:
 ```
livingdoc feature-folder <your_path_to_project>\QATestSpecflowSeleniumTrendyol -t <your_path_to_project>\QATestSpecflowSeleniumTrendyol\bin\Debug\net6.0\TestExecution.json
 ```
### Scenarios in Feature Files

In TrendyolMain.feature file. All of the basic features available in the application.

```gherkin
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
```

In Product.feature file

```gherkin
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

@Smoke @DeleteProductFromCart
Scenario: Visitor should be able delete products in cart
	Given Navigate to trendyol website
	And Search for product "Parfüm" in search
	And Verify search executed
	When Click first product in results
	And Verify product detail page opened
	And Get Product base link
	And Click add to cart button
	And Click see cart button
	And Verify cart page opened
	And Verify Product added to cart by received base link
	And Click delete button by received base link
	Then Verify the product is deleted
```


