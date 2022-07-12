using OpenQA.Selenium;
using QATestSpecflowSeleniumTrendyol.Resources;

namespace QATestSpecflowSeleniumTrendyol.PO
{
    public class SearchResults
    {
        private readonly IWebDriver Driver;
        private readonly Common common;

        //
        private const string FirstProductLocator = "//div[@class='prdct-cntnr-wrppr']/div[2]//div[@class='image-overlay-body']";
        // Create new instances
        public SearchResults(IWebDriver webDriver)
        {
            Driver = webDriver;
            common = new Common(webDriver);
        }

        IWebElement FirstProductInResults => Driver.FindElement(By.XPath(FirstProductLocator));

        public void ClickFirstProduct()
        {
            common.WaitForPageLoad();
            common.WaitUntilElement(By.XPath(FirstProductLocator), "Exists");
            common.ScrollToElement(FirstProductInResults);
            common.ClosePopupIfExists();
            FirstProductInResults.Click();

        }
    }
}
