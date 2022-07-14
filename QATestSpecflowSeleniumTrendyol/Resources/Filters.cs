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
        private string? BrandName;
 
        private const string PriceFilterFrameLocator = "//div[@class='aggrgtn-cntnr-wrppr']/div[@class='fltrs-wrppr hide-fltrs']/div[.='Fiyat']";
        private const string PriceFilterContentLocator = "//div[@class='aggrgtn-cntnr-wrppr']/div[@class='fltrs-wrppr hide-fltrs']//div[contains(text(), '0 TL')]";

        private const string BrandFilterFrameLocator = "//div[@class='aggrgtn-cntnr-wrppr']/div[@class='fltrs-wrppr hide-fltrs']/div[.='Marka']";
        private string BrandFilterContentLocator;

        public Filters(IWebDriver driver)
        {
            Driver = driver;
            common = new Common(driver);
            subMethods = new SubMethods(driver);
            BrandFilterContentLocator = "//div[@class='aggrgtn-cntnr-wrppr']/div[@class='fltrs-wrppr hide-fltrs']/div[.='" + BrandName + "']";
        }

        IWebElement PriceFilterFrameElement => Driver.FindElement(By.XPath(PriceFilterFrameLocator));
        IWebElement BrandFilterFrameElement => Driver.FindElement(By.XPath(BrandFilterFrameLocator));

        IWebElement PriceFilterContentElement => common.FindElementAndIgnoreErrors("XPath", PriceFilterContentLocator);
        IWebElement BrandFilterContentElement => common.FindElementAndIgnoreErrors("XPath", BrandFilterContentLocator);

        public void CheckAndSetPriceFiter()
        {
            common.ScrollToElement(PriceFilterFrameElement);

            if (common.Exists(PriceFilterContentElement))
            {
                System.Console.WriteLine("Price Filter Startable");
            }
            else
            {
                subMethods.AcceptCoockiesIfVisible();
                common.ClosePopupIfExists();
                
                PriceFilterFrameElement.Click();
                common.WaitUntilElement(By.XPath(PriceFilterContentLocator), "Visible");
            }
        }

        public void SetPriceFilter()
        {

        }

        public void CheckAndSetBrandFilter()
        {
            common.ScrollToElement(BrandFilterFrameElement);
        }
    }
}
