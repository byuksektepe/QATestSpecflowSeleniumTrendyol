using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using QATestSpecflowSeleniumTrendyol.Drivers;
using QATestSpecflowSeleniumTrendyol.Resources;
using QATestSpecflowSeleniumTrendyol.PO;

namespace QATestSpecflowSeleniumTrendyol.StepDefinitions
{
    [Binding]
    public class TrendyolOnChromeStepDefinitions
    {
        private readonly Common _driver;
        private readonly Navbar navbar;

        public TrendyolOnChromeStepDefinitions(SeleniumDriver driver)
        {
            _driver = new Common(driver.Current);
            navbar = new Navbar(driver.Current);
        }

        [Given(@"Navigate to trendyol website")]
        public void GivenNavigateToTrendyolWebsite()
        {
            // Given in hooks, its just for define BDD
        }

        [Given(@"Search for product ""([^""]*)"" in search")]
        public void GivenSearchForProductInSearch(string product)
        {
            navbar.SearchItem(product);
        }

        [Then(@"Click first product in results")]
        public void ThenClickFirstProductInResults()
        {
            throw new PendingStepException();
        }

    }

}
