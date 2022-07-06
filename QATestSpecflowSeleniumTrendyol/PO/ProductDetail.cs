using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using QATestSpecflowSeleniumTrendyol.Resources;

namespace QATestSpecflowSeleniumTrendyol.PO
{
    public class ProductDetail
    {
        private readonly IWebDriver Driver;
        private readonly Common common;

        private const string ProductDetailVerifyLocator = "//main[@id='product-detail-app']";
        private const string AddToCartButtonLocator = "//div[@class='add-to-basket-button-text']";

        public ProductDetail(IWebDriver webDriver)
        {
            Driver = webDriver;
            common = new Common(webDriver);
        }
        //

        IWebElement ProductDetailVerifyElement => Driver.FindElement(By.XPath(ProductDetailVerifyLocator));
        IWebElement AddToChartButtonElement => Driver.FindElement(By.XPath(AddToCartButtonLocator));

        public void VerifyPageLoad()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            common.WaitUntilElement(By.XPath(ProductDetailVerifyLocator), "Visible");
        }

        public void ClickAddToCartButton()
        {
            AddToChartButtonElement.Click();
        }
    }
}
