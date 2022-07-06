using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using QATestSpecflowSeleniumTrendyol.Drivers;
using QATestSpecflowSeleniumTrendyol.Resources;
using QATestSpecflowSeleniumTrendyol.PO;

namespace QATestSpecflowSeleniumTrendyol.StepDefinitions
{
    [Binding]
    public class TrendyolStepDefinitions
    {   
        //
        private readonly Common common;
        private readonly Navbar navbar;
        private readonly SearchResults searchResults;
        private readonly ProductDetail productDetail;
        //

        public TrendyolStepDefinitions(SeleniumDriver driver)
        {
            common = new Common(driver.Current);
            navbar = new Navbar(driver.Current);
            searchResults = new SearchResults(driver.Current);
            productDetail = new ProductDetail(driver.Current);
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

        [When(@"Click first product in results")]
        public void ThenClickFirstProductInResults()
        {
            searchResults.ClickFirstProduct();
        }

        [When(@"Verify product detail page opened")]
        public void WhenVerifyProductDetailPageOpened()
        {
            productDetail.VerifyPageLoad();
        }

        [When(@"Click add to cart button")]
        public void WhenClickAddToCartButton()
        {
            // pending
        }



    }

}
