using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace QATestSpecflowSeleniumTrendyol.PO
{
    public class Navbar
    {
        private readonly IWebDriver _webDriver;

        public Navbar(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        private IWebElement SearchInput => _webDriver.FindElement(By.XPath("//div[@class='search-box-container']//input[@class='search-box']"));
        private IWebElement SearchButton => _webDriver.FindElement(By.XPath("//div[@class='search-box-container']//i[@class='search-icon']"));

        public void SearchItem(String SearchItem)
        {
            SearchInput.SendKeys(SearchItem);
        }
    }
}
