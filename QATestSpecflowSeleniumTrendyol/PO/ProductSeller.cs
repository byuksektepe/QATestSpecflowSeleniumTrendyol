namespace QATestSpecflowSeleniumTrendyol.PO
{
    public class ProductSeller
    {
        private readonly IWebDriver Driver;
        private readonly Common common;
        private readonly SubMethods subMethods;

        private const string ProductSellerVerifyLocator = "";
        private const string ProductSellerNameLocator = "";

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
            common.WaitUntilElement(By.XPath(ProductSellerVerifyLocator), "Visible");
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
