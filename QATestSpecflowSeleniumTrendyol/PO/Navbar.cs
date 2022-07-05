using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QATestSpecflowSeleniumTrendyol.Resources;

namespace QATestSpecflowSeleniumTrendyol.PO
{
    public class Navbar
    {
        private readonly IWebDriver Driver;
        private readonly Common common;
        private const string SearchInputElement = "//div[@class='search-box-container']//input[@class='search-box']";
        private const string SearchButtonElement = "//div[@class='search-box-container']//i[@class='search-icon']";

        // Create new instances
        public Navbar(IWebDriver webDriver)
        {
            Driver = webDriver;
            common = new Common(webDriver);
        }

        private IWebElement SearchInput => Driver.FindElement(By.XPath(SearchInputElement));
        private IWebElement SearchButton => Driver.FindElement(By.XPath(SearchButtonElement));

        public void SearchItem(String SearchItem)
        {
            SearchInput.SendKeys(SearchItem);
            SearchInput.SendKeys(Keys.Enter);

            common.VerifyPageLoad();

        }
    }
}
