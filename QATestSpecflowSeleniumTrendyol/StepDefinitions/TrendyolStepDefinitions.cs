using QATestSpecflowSeleniumTrendyol.Drivers;
using QATestSpecflowSeleniumTrendyol.PO;
using QATestSpecflowSeleniumTrendyol.Resources;
using TechTalk.SpecFlow.Assist;

namespace QATestSpecflowSeleniumTrendyol.StepDefinitions
{
    [Binding]
    public class TrendyolStepDefinitions
    {
        private readonly Common common;
        private readonly Navbar navbar;
        private readonly SearchResults searchResults;
        private readonly ProductDetail productDetail;
        private readonly Cart cart;

        public TrendyolStepDefinitions(SeleniumDriver driver)
        {
            common = new Common(driver.Current);
            navbar = new Navbar(driver.Current);
            searchResults = new SearchResults(driver.Current);
            productDetail = new ProductDetail(driver.Current);
            cart = new Cart(driver.Current);
        }
        [Given(@"Navigate to trendyol website")]
        public void GivenNavigateToTrendyolWebsite(Table table)
        {
            dynamic datas = table.CreateDynamicSet();
            foreach (var item in datas)
            {
                Console.WriteLine($"The Browser is {item.Browser}");
            }
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
            productDetail.ClickAddToCartButton();
        }

        [When(@"Click see cart button")]
        public void WhenClickSeeCartButton()
        {
            productDetail.ClickSeeCartElement();
            cart.VerifyPageLoad();
        }

        [Then(@"Verify product added to cart")]
        public void ThenVerifyProductAddedToCart()
        {
            cart.VerifyProductAddedToCart();
        }

    }

}
