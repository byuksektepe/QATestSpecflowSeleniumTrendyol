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
- Specflow.NUnit
- Specflow.Plus.LivingDocPlugin

### Generate SpecFlow Living Documentation
Open terminal and type  ```livingdoc``` for start execution, then type  ```feature-folder``` to give the project file path and type ```-t``` to give TestExecution.json file. After typing all the necessary parameters hit enter then LivingDoc will be generated in project directory.

Example:
 ```
livingdoc feature-folder <your_path_to_project>\QATestSpecflowSeleniumTrendyol -t <your_path_to_project>\QATestSpecflowSeleniumTrendyol\bin\Debug\net6.0\TestExecution.json
 ```

![image](https://user-images.githubusercontent.com/61010367/179406154-11d4d498-f723-47a3-b93e-13282e45b7ca.png)
![image](https://user-images.githubusercontent.com/61010367/179406171-cd0a3cd3-aa0d-4845-9fc8-3601abad4381.png)




