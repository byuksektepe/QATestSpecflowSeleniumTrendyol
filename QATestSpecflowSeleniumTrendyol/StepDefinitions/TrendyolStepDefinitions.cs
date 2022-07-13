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
        private readonly SignInUp signInUp;
        private readonly Footer footer;
        private readonly SubMethods subMethods;

        public TrendyolStepDefinitions(SeleniumDriver driver)
        {
            common = new Common(driver.Current);
            navbar = new Navbar(driver.Current);
            searchResults = new SearchResults(driver.Current);
            productDetail = new ProductDetail(driver.Current);
            cart = new Cart(driver.Current);
            signInUp = new SignInUp(driver.Current);
            footer = new Footer(driver.Current);
            subMethods = new SubMethods(driver.Current);
        }

        [Given(@"Navigate to trendyol website")]
        public void GivenNavigateToTrendyolWebsite()
        {
            // Given in hooks just for BDD text
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

        [When(@"Click add to favorites button")]
        public void WhenClickAddToFavoritesButton()
        {
            productDetail.ClickAddToFavoritesButton();
        }

        [Then(@"Verify login page opened")]
        public void ThenVerifyLoginPageOpened()
        {
            signInUp.VerifyPageLoad();
        }


        [Then(@"Verify visitor see product comments")]
        public void ThenVerifyVisitorSeeProductComments()
        {
            productDetail.VerifyCommentsAreVisible();
        }

        [When(@"Scroll to footer")]
        public void WhenScrollToFooter()
        {
            footer.ScrollBottomOfPage();
        }

        [Then(@"Verify footer is visible")]
        [When(@"Verify footer is visible")]
        public void ThenVerifyFooterIsVisible()
        {
            footer.VerifyFooterIsVisible();
        }

        [When(@"Click move to top button")]
        public void WhenClickMoveToTopButton()
        {
            subMethods.AcceptCoockiesIfVisible();
            subMethods.ClickMoveToTopButton();
        }

        [Then(@"Verify top of the page is visible")]
        public void ThenVerifyTopOfThePageIsVisible()
        {
            subMethods.VerifyTopOfThePageIsVisible();
        }

    }

}
