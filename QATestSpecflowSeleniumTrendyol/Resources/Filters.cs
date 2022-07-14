using OpenQA.Selenium;
using QATestSpecflowSeleniumTrendyol.Resources;

namespace QATestSpecflowSeleniumTrendyol.Resources
{
    public class Filters
    {
        private readonly IWebDriver Driver;
        private readonly Common common;
        private readonly SubMethods subMethods;

        private int MaxPrice;
        private int MinPrice;

        private const string PriceFilterFrameLocator = "//div[@class='aggrgtn-cntnr-wrppr']/div[@class='fltrs-wrppr hide-fltrs']/div[.='Fiyat']";
        private const string PriceFilterContentLocator = "//div[@class='aggrgtn-cntnr-wrppr']/div[@class='fltrs-wrppr hide-fltrs']//div[contains(text(), '0 TL')]";

        private const string BrandFilterFrameLocator = "//div[@class='aggrgtn-cntnr-wrppr']/div[@class='fltrs-wrppr hide-fltrs']/div[.='Marka']";


        public Filters(IWebDriver driver)
        {
            Driver = driver;
            common = new Common(driver);
            subMethods = new SubMethods(driver);
        }

        IWebElement PriceFilterFrameElement => Driver.FindElement(By.XPath(PriceFilterFrameLocator));
        IWebElement BrandFilterFrameElement => Driver.FindElement(By.XPath(BrandFilterFrameLocator));

        IWebElement PriceFilterContentElement => common.FindElementAndIgnoreErrors("XPath", PriceFilterContentLocator);

        public void CheckPriceFiter()
        {
            common.ScrollToElement(PriceFilterFrameElement);

            if (common.Exists(PriceFilterContentElement))
            {
                System.Console.WriteLine("Price Filter Startable");
            }
            else
            {
                common.Sleep(1);
                subMethods.AcceptCoockiesIfVisible();
                common.ClosePopupIfExists();
                
                PriceFilterFrameElement.Click();
                common.WaitUntilElement(By.XPath(PriceFilterContentLocator), "Visible");
            }
        }
    }
}
