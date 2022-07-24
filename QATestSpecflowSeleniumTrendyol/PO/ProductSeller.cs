namespace QATestSpecflowSeleniumTrendyol.PO
{
    public class ProductSeller
    {
        private readonly IWebDriver Driver;
        private readonly Common common;
        private readonly SubMethods subMethods;

        private const string ProductSellerVerifyLocator = "//div[@id='seller-store']";
        private const string ProductSellerNameLocator = "//div[@class='ss-header-inner__data__title']/h1[@class='seller-store__name seller-info__name']";

        public ProductSeller(IWebDriver driver)
        {
            Driver = driver;
            common = new Common(driver);
            subMethods = new SubMethods(driver);
        }

        private IWebElement ProductSellerNameElement => Driver.FindElement(By.XPath(ProductSellerNameLocator));

        public void VerifyPageLoad()
        {
            common.WaitForPageLoad();
            common.WaitUntilElement(By.XPath(ProductSellerVerifyLocator), Conditions.Visible);
        }

        public void CheckProductSellerNameByGiven(string GivenSellerName)
        {
            common.WaitUntilElement(By.XPath(ProductSellerNameLocator));

            string ReceivedSellerName = ProductSellerNameElement.Text;

            if (!ReceivedSellerName.Equals(GivenSellerName))
            {
                throw new SellerNameNotMatchByGivenException(GivenSellerName, ReceivedSellerName);
            }
        }
    }
}
