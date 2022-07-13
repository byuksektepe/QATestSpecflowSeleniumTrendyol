using OpenQA.Selenium;
using QATestSpecflowSeleniumTrendyol.Resources;

namespace QATestSpecflowSeleniumTrendyol.Resources
{
    public class Filters
    {
        private readonly IWebDriver Driver;
        private readonly Common common;

        private const string PriceFilterFrameLocator = "//div[@class='aggrgtn-cntnr-wrppr']/div[@class='fltrs-wrppr hide-fltrs']/div[.='Fiyat']";
        private const string PriceFilterContentLocator = "//div[@class='aggrgtn-cntnr-wrppr']/div[@class='fltrs-wrppr hide-fltrs']";

        private const string BrandFilterFrameLocator = "//div[@class='aggrgtn-cntnr-wrppr']/div[@class='fltrs-wrppr hide-fltrs']/div[.='Marka']";


        public Filters(IWebDriver driver)
        {
            Driver = driver;
            common = new Common(driver);
        }

        IWebElement PriceFilterFrameElement => Driver.FindElement(By.XPath(PriceFilterFrameLocator));
        IWebElement BrandFilterFrameElement => Driver.FindElement(By.XPath(BrandFilterFrameLocator));

        IWebElement PriceFilterContentElement => Driver.FindElement(By.XPath(PriceFilterFrameLocator));

        public void CheckPriceFiter()
        {
            common.ScrollToElement(PriceFilterFrameElement);

        }

    }
}
