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


        public TrendyolProductStepDefinitions(SeleniumDriver driver)
        {
            productSeller = new ProductSeller(driver.Current);
            subMethods = new SubMethods(driver.Current);
            productDetail = new ProductDetail(driver.Current);
        }

        private string ProductSellerName;

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
    }
}
