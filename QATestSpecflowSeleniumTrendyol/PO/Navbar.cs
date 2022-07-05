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

        public Navbar(IWebDriver webDriver)
        {
            Driver = webDriver;
            common = new Common(webDriver);
        }

        private IWebElement SearchInput => Driver.FindElement(By.XPath("//div[@class='search-box-container']//input[@class='search-box']"));
        private IWebElement SearchButton => Driver.FindElement(By.XPath("//div[@class='search-box-container']//i[@class='search-icon']"));

        public void SearchItem(String SearchItem)
        {
            SearchInput.SendKeys(SearchItem);
            SearchInput.SendKeys(Keys.Return);
            //System.Threading.Thread.Sleep(5000);
            common.VerifyPageLoad();

        }
    }
}
