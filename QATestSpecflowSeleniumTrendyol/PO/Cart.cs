using OpenQA.Selenium;
using QATestSpecflowSeleniumTrendyol.Resources;

namespace QATestSpecflowSeleniumTrendyol.PO
{
    public class Cart
    {
        private readonly IWebDriver Driver;
        private readonly Common common;

        private const string CartVerifyLocator = "//div[@id='basket-app-container']";
        private const string ProductVerifyLocator = "//div[@class='pb-merchant-group'][1]";

        public Cart(IWebDriver webDriver)
        {
            Driver = webDriver;
            common = new Common(webDriver);
        }

        IWebElement ProductVerifyElement => Driver.FindElement(By.XPath(ProductVerifyLocator));

        public void VerifyPageLoad()
        {
            common.WaitForPageLoad();
            common.WaitUntilElement(By.XPath(CartVerifyLocator));
        }

        public void VerifyCartPageOpened()
        {
            common.WaitUntilElement(By.XPath(CartVerifyLocator), "Exists");
        }

        public void VerifyProductLinkByGiven(string GivenUrl)
        {
            string ReceivedProductUrlLocator =  String.Format("//div[@class='pb-basket-item']//a[contains(@href, '{0}')]", GivenUrl);
            IWebElement ReceivedProductUrlElement = common.FindElementAndIgnoreErrors("XPath", ReceivedProductUrlLocator);

            if (!common.Exists(ReceivedProductUrlElement))
            {

            }
        }
    }
}
