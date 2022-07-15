using OpenQA.Selenium;
using QATestSpecflowSeleniumTrendyol.Resources;

namespace QATestSpecflowSeleniumTrendyol.PO
{
    public class Navbar
    {
        private readonly IWebDriver Driver;
        private readonly Common common;
        private const string SearchInputLocator = "//div[@class='search-box-container']//input[@class='search-box']";
        private const string SearchButtonLocator = "//div[@class='search-box-container']//i[@class='search-icon']";
        private const string SignInLocator = "//div[@class='account-nav-item user-login-container']//div[@class='link account-user']";

        // Create new instances
        public Navbar(IWebDriver webDriver)
        {
            Driver = webDriver;
            common = new Common(webDriver);
        }

        private IWebElement SearchInput => Driver.FindElement(By.XPath(SearchInputLocator));
        private IWebElement SearchButton => Driver.FindElement(By.XPath(SearchButtonLocator));
        private IWebElement SignInButton => Driver.FindElement(By.XPath(SignInLocator));

        public void SearchItem(String SearchItem)
        {
            SearchInput.SendKeys(SearchItem);
            SearchInput.SendKeys(Keys.Enter);
        }

        public void ClickSignInButton()
        {
            SignInButton.Click();
        }
    }
}
