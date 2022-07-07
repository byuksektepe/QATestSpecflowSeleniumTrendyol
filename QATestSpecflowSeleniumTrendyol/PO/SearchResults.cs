using OpenQA.Selenium;
using QATestSpecflowSeleniumTrendyol.Resources;

namespace QATestSpecflowSeleniumTrendyol.PO
{
    public class SearchResults
    {
        private readonly IWebDriver Driver;
        private readonly Common common;

        //
        private const string FirstProductXPath = "//div[@class='prdct-cntnr-wrppr']/div[2]//div[@class='image-overlay-body']";
        // Create new instances
        public SearchResults(IWebDriver webDriver)
        {
            Driver = webDriver;
            common = new Common(webDriver);
        }

        IWebElement FirstProductInResults => Driver.FindElement(By.XPath(FirstProductXPath));

        public void ClickFirstProduct()
        {
            common.WaitUntilElement(By.XPath(FirstProductXPath), "Visible");
            common.ScrollToElement(FirstProductInResults);
            FirstProductInResults.Click();

        }
    }
}
