using OpenQA.Selenium;
using QATestSpecflowSeleniumTrendyol.Resources;

namespace QATestSpecflowSeleniumTrendyol.PO
{
    public class SearchResults
    {
        private readonly IWebDriver Driver;
        private readonly Common common;
        private readonly SubMethods subMethods;

        //
        private const string FirstProductLocator = "//div[@class='prdct-cntnr-wrppr']/div[2]//div[@class='image-overlay-body']";

        public SearchResults(IWebDriver webDriver)
        {
            Driver = webDriver;
            common = new Common(webDriver);
            subMethods = new SubMethods(webDriver);
        }

        IWebElement FirstProductInResults => Driver.FindElement(By.XPath(FirstProductLocator));

        public void VerifyPageLoad()
        {
            common.WaitForPageLoad();
            common.WaitUntilElement(By.XPath(FirstProductLocator), "Visible");
            subMethods.AcceptCoockiesIfVisible();
            common.ClosePopupIfExists();
        }

        public void ClickFirstProduct()
        {
            common.WaitForPageLoad();
            common.WaitUntilElement(By.XPath(FirstProductLocator), "Visible");
            common.ScrollToElement(FirstProductInResults);
            common.ClosePopupIfExists();
            FirstProductInResults.Click();

        }
    }
}
