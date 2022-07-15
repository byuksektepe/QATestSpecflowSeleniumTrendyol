using QATestSpecflowSeleniumTrendyol.Drivers;
using QATestSpecflowSeleniumTrendyol.PO;
using QATestSpecflowSeleniumTrendyol.Resources;
using TechTalk.SpecFlow.Assist;

namespace QATestSpecflowSeleniumTrendyol.StepDefinitions
{
    [Binding]
    public class TrendyolStepDefinitions
    {
        private readonly Navbar navbar;
        private readonly SearchResults searchResults;
        private readonly ProductDetail productDetail;
        private readonly Cart cart;
        private readonly SignIn signIn;
        private readonly Footer footer;
        private readonly SubMethods subMethods;
        private readonly Filters filters;

        public TrendyolStepDefinitions(SeleniumDriver driver)
        {
            navbar = new Navbar(driver.Current);
            searchResults = new SearchResults(driver.Current);
            productDetail = new ProductDetail(driver.Current);
            cart = new Cart(driver.Current);
            signIn = new SignIn(driver.Current);
            footer = new Footer(driver.Current);
            subMethods = new SubMethods(driver.Current);
            filters = new Filters(driver.Current);
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

        [Given(@"Verify search executed")]
        public void GivenVerifySearchExecuted()
        {
            searchResults.VerifyPageLoad();
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

        [Given(@"Verify login page opened")]
        [Then(@"Verify login page opened")]
        public void ThenVerifyLoginPageOpened()
        {
            signIn.VerifyPageLoad();
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

        //

        [Given(@"Set brand filter to ""([^""]*)""")]
        public void GivenSetBrandFilterTo(string Brand)
        {
            filters.CheckAndSetBrandFilter(Brand);
        }

        [Given(@"Set price filter Min:""([^""]*)"" and Max:""([^""]*)""")]
        public void GivenSetPriceFilterAnd(string MinPrice, string MaxPrice)
        {
            filters.CheckAndSetPriceFiter(MinPrice, MaxPrice);
        }

        [When(@"Verify product brand is ""([^""]*)""")]
        public void WhenVerifyProductBrandIs(string Brand)
        {
            productDetail.VerifyProductBrandByGivenBrand(Brand);
        }

        [Then(@"Verify product title contains ""([^""]*)""")]
        public void ThenVerifyProductTitleContains(string SearchQuery)
        {
            productDetail.VerifyProductTitleContainsSearchQuery(SearchQuery);
        }

        [Given(@"Set photo review filter if selected ""([^""]*)""")]
        public void GivenSetPhotoReviewFilterIfSelected(string PhotoReview)
        {
            if(!String.IsNullOrWhiteSpace(PhotoReview))
            {
                filters.SetPhotoReviewFilter();
            }
        }

        [Given(@"Set free cargo filter if selected ""([^""]*)""")]
        public void GivenSetFreeCargoFilterIfSelected(string FreeCargo)
        {
            if(!String.IsNullOrWhiteSpace(FreeCargo))
            {
                filters.SetFreeCargoFilter();
            }
        }
    }
}
