using QATestSpecflowSeleniumTrendyol.Drivers;
using QATestSpecflowSeleniumTrendyol.PO;

namespace QATestSpecflowSeleniumTrendyol.StepDefinitions
{
    [Binding]
    public class TrendyolProductStepDefinitions
    {
        private readonly ProductSeller productSeller;
        private readonly SubMethods subMethods;
        private readonly ProductDetail productDetail;
        private readonly Cart cart;


        public TrendyolProductStepDefinitions(SeleniumDriver driver)
        {
            productSeller = new ProductSeller(driver.Current);
            subMethods = new SubMethods(driver.Current);
            productDetail = new ProductDetail(driver.Current);
            cart = new Cart(driver.Current);
        }

        private string ProductSellerName;
        private string ProductUrl;

        [When(@"Get product seller name")]
        public void WhenGetProductSellerName()
        {
            ProductSellerName = productDetail.GetProductSellerName();
        }

        [When(@"Click product seller page link")]
        public void WhenClickProductSellerPageLink()
        {
            productDetail.ClickProductSellerLink();
        }

        [When(@"Verify seller page opened")]
        public void WhenVerifySellerPageOpened()
        {
            productSeller.VerifyPageLoad();
        }

        [Then(@"Verify the product seller with received name")]
        public void ThenVerifyTheSellerReceived()
        {
            productSeller.CheckProductSellerNameByGiven(ProductSellerName);
        }

        [When(@"Get Product base link")]
        public void WhenGetProductBaseLink()
        {
            ProductUrl = productDetail.GetProductBaseUrl();
        }

        [When(@"Verify Product added to cart by received base link")]
        public void WhenVerifyProductAddedToCartByReceivedBaseLink()
        {
            cart.VerifyProductAddedToCartByGivenLink(ProductUrl);
        }

        [When(@"Click ""([^""]*)"" Button for ""([^""]*)"" times")]
        public void WhenClickButtonForTimes(string Button, string ForTimes)
        {

        }

        [Then(@"verify that the number of products is increased correctly")]
        public void ThenVerifyThatTheNumberOfProductsIsIncreasedCorrectly()
        {

        }
    }
}
