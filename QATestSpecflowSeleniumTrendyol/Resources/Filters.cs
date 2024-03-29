﻿namespace QATestSpecflowSeleniumTrendyol.Resources
{
    public class Filters
    {
        private readonly IWebDriver Driver;
        private readonly Common common;
        private readonly SubMethods subMethods;

        private string? BrandName;

        private const string FilterFrameMainLocator = "//div[@class='aggrgtn-cntnr-wrppr']/div[@class='fltrs-wrppr hide-fltrs']";

        private const string PriceFilterFrameLocator = FilterFrameMainLocator + "/div[.='Fiyat']";
        private const string PriceFilterContentLocator = FilterFrameMainLocator + "//div[contains(text(), '0 TL')]";

        private const string BrandFilterFrameLocator = FilterFrameMainLocator + "/div[.='Marka']";
        private string BrandFilterContentLocator;

        private const string PriceFilterMinInput = FilterFrameMainLocator + "//input[@class='fltr-srch-prc-rng-input min']";
        private const string PriceFilterMaxInput = FilterFrameMainLocator + "//input[@class='fltr-srch-prc-rng-input max']";
        private const string PriceFilterSubmitButton = FilterFrameMainLocator + "//button[@class='fltr-srch-prc-rng-srch']";

        private const string BrandSearchInput = FilterFrameMainLocator + "//input[@class='fltr-srch-inpt']";

        private const string PhotoReviewLocator = FilterFrameMainLocator + "//div[@class='fltrs toggleFilter']//div[.='Fotoğraflı Yorumlar']";
        private const string FreeCargoLocator = FilterFrameMainLocator + "//div[@class='fltrs toggleFilter']//div[.='Kargo Bedava']";


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

        IWebElement PriceFilterMinInputElement => Driver.FindElement(By.XPath(PriceFilterMinInput));
        IWebElement PriceFilterMaxInputElement => Driver.FindElement(By.XPath(PriceFilterMaxInput));
        IWebElement PriceFilterSubmitButtonElement => Driver.FindElement(By.XPath(PriceFilterSubmitButton));

        IWebElement BrandFilterSearchInputElement => Driver.FindElement(By.XPath(BrandSearchInput));
        IWebElement PhotoReviewElement => Driver.FindElement(By.XPath(PhotoReviewLocator));
        IWebElement FreeCargoElement => Driver.FindElement(By.XPath(FreeCargoLocator));



        public void CheckAndSetPriceFiter(string MinPrice, string MaxPrice)
        {
            common.ScrollToElement(PriceFilterFrameElement);

            if (common.Exists(PriceFilterContentElement))
            {
                common.WaitUntilElement(By.XPath(PriceFilterContentLocator), Conditions.Visible);
                SetPriceFilter(MinPrice, MaxPrice);
            }
            else
            {
                PriceFilterFrameElement.Click();
                common.WaitUntilElement(By.XPath(PriceFilterContentLocator), Conditions.Visible);
                SetPriceFilter(MinPrice, MaxPrice);
            }
        }

        protected void SetPriceFilter(string MinPrice, string MaxPrice)
        {
            PriceFilterMinInputElement.SendKeys(MinPrice);
            PriceFilterMaxInputElement.SendKeys(MaxPrice);
            PriceFilterSubmitButtonElement.Click();
            common.WaitForPageLoad();

        }

        public void CheckAndSetBrandFilter(string Brand)
        {
            common.ScrollToElement(BrandFilterFrameElement);

            if (common.Exists(BrandFilterContentElement))
            {
                common.WaitUntilElement(By.XPath(BrandFilterContentLocator), Conditions.Visible);
                SetBrandFilter(Brand);
            }
            else
            {
                BrandFilterFrameElement.Click();
                common.WaitUntilElement(By.XPath(BrandFilterContentLocator), Conditions.Visible);
                SetBrandFilter(Brand);
            }
        }

        protected void SetBrandFilter(string Brand)
        {
            string BrandFilterCheckBoxLocator = "//div[@class='aggrgtn-cntnr-wrppr']/div[@class='fltrs-wrppr hide-fltrs']//div[.='" + Brand + "']";
            BrandFilterSearchInputElement.SendKeys(Brand);

            IWebElement BrandFilterCheckBoxElement = Driver.FindElement(By.XPath(BrandFilterCheckBoxLocator));
            Console.Write(BrandFilterContentLocator);
            BrandFilterCheckBoxElement.Click();
            common.WaitForPageLoad();
        }

        public void SetPhotoReviewFilter()
        {
            common.ScrollToElement(PhotoReviewElement);
            PhotoReviewElement.Click();
            common.WaitForPageLoad();
        }

        public void SetFreeCargoFilter()
        {
            common.ScrollToElement(FreeCargoElement);
            FreeCargoElement.Click();
            common.WaitForPageLoad();
        }
    }
}
