using OpenQA.Selenium;
using QATestSpecflowSeleniumTrendyol.Resources;

namespace QATestSpecflowSeleniumTrendyol.PO
{
    public class Footer
    {
        private readonly IWebDriver Driver;
        private readonly Common common;

        private const string BrandCopyrightLocator = "//div[@id='footer-container']//div[@class='bandInfo']";
        private const string FooterVerifyLocator = "//div[@id='footer-container']//h4[.='Trendyol']";

        public Footer(IWebDriver driver)
        {
            Driver = driver;
            common = new Common(driver);
        }

        IWebElement BrandCopyrightElement => Driver.FindElement(By.XPath(BrandCopyrightLocator));

        public void ScrollBottomOfPage()
        {
            common.ScrollToElement(BrandCopyrightElement);
            common.Sleep(1);
        }

        public void VerifyFooterIsVisible()
        {
            common.WaitUntilElement(By.XPath(FooterVerifyLocator), Conditions.Visible);
        }
    }
}
