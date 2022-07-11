using OpenQA.Selenium;
using QATestSpecflowSeleniumTrendyol.Resources;

namespace QATestSpecflowSeleniumTrendyol.PO
{
    public class ProductDetail
    {
        private readonly IWebDriver Driver;
        private readonly Common common;

        private const string ProductDetailVerifyLocator = "//main[@id='product-detail-app']";
        private const string AddToCartButtonLocator = "//div[@class='add-to-basket-button-text']";
        private const string AddToFavoritesButtonLocator = "//div[@class='favorite-button']";
        private const string SeeCartLocator = "//div[@class='account-nav-item basket-preview']";

        public ProductDetail(IWebDriver webDriver)
        {
            Driver = webDriver;
            common = new Common(webDriver);
        }
        //

        IWebElement ProductDetailVerifyElement => Driver.FindElement(By.XPath(ProductDetailVerifyLocator));
        IWebElement AddToCartButtonElement => Driver.FindElement(By.XPath(AddToCartButtonLocator));
        IWebElement SeeCartElement => Driver.FindElement(By.XPath(SeeCartLocator));
        IWebElement AddToFavoritesButtonElement => Driver.FindElement(By.XPath(AddToFavoritesButtonLocator));

        public void VerifyPageLoad()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            common.WaitUntilElement(By.XPath(ProductDetailVerifyLocator), "Visible");
        }

        public void ClickAddToCartButton()
        {
            AddToCartButtonElement.Click();
            common.Sleep(2);
        }

        public void ClickAddToFavoritesButton()
        {
            AddToFavoritesButtonElement.Click();
            common.Sleep(1);
        }

        public void ClickSeeCartElement()
        {
            SeeCartElement.Click();
        }
    }
}
