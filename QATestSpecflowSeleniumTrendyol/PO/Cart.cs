using OpenQA.Selenium;
using QATestSpecflowSeleniumTrendyol.Resources;

namespace QATestSpecflowSeleniumTrendyol.PO
{
    public class Cart
    {
        private readonly IWebDriver Driver;
        private readonly Common common;

        private const string CartVerifyLocator = "//div[@id='basket-app-container']";

        public Cart(IWebDriver webDriver)
        {
            Driver = webDriver;
            common = new Common(webDriver);
        }

        public void VerifyPageLoad()
        {
            common.WaitUntilElement(By.XPath(CartVerifyLocator));
        }
    }
}
