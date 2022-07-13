using OpenQA.Selenium;
using QATestSpecflowSeleniumTrendyol.Resources;

namespace QATestSpecflowSeleniumTrendyol.Resources
{
    public class Filters
    {
        private readonly IWebDriver Driver;
        private readonly Common common;

        private string MinPrice = "200";
        private string MaxPrice = "350";

        private const string PriceFilterFrameLocator = "//div[@class='aggrgtn-cntnr-wrppr']/div[@class='fltrs-wrppr hide-fltrs']/div[.='Fiyat']";
        private const string PriceFilterContentLocator = "//div[@class='aggrgtn-cntnr-wrppr']/div[@class='fltrs-wrppr hide-fltrs']//div[contains(text(), '0 TL')]";

        private const string BrandFilterFrameLocator = "//div[@class='aggrgtn-cntnr-wrppr']/div[@class='fltrs-wrppr hide-fltrs']/div[.='Marka']";


        public Filters(IWebDriver driver)
        {
            Driver = driver;
            common = new Common(driver);
        }

        IWebElement PriceFilterFrameElement => Driver.FindElement(By.XPath(PriceFilterFrameLocator));
        IWebElement BrandFilterFrameElement => Driver.FindElement(By.XPath(BrandFilterFrameLocator));

        IWebElement PriceFilterContentElement => common.FindElementAndIgnoreErrors("XPath", PriceFilterContentLocator);

        public void CheckPriceFiter()
        {
            common.ScrollToElement(PriceFilterFrameElement);
            common.FindElementAndIgnoreErrors("XPath", PriceFilterContentLocator);

            if (common.Exists(PriceFilterContentElement))
            {
                System.Console.WriteLine("Price Filter Startable");
            }
            else
            {
                PriceFilterFrameElement.Click();
                common.WaitUntilElement(By.XPath(PriceFilterContentLocator), "Visible");
            }

        }

    }
}
