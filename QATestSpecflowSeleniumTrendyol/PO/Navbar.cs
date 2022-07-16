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

        private const string D_SignUpLocator = "//div[@class='login-dropdown']//div[@class='signup-button']";
        private const string D_SignInLocator = "//div[@class='login-dropdown']//div[@class='login-button']";

        // Create new instances
        public Navbar(IWebDriver webDriver)
        {
            Driver = webDriver;
            common = new Common(webDriver);
        }

        private IWebElement SearchInput => Driver.FindElement(By.XPath(SearchInputLocator));
        private IWebElement SearchButton => Driver.FindElement(By.XPath(SearchButtonLocator));
        private IWebElement SignInButton => Driver.FindElement(By.XPath(SignInLocator));

        private IWebElement D_SignUpElement => Driver.FindElement(By.XPath(D_SignUpLocator));
        private IWebElement D_SignInElement => Driver.FindElement(By.XPath(D_SignInLocator));

        public void SearchItem(String SearchItem)
        {
            SearchInput.SendKeys(SearchItem);
            SearchInput.SendKeys(Keys.Enter);
        }

        public void ClickSignInButton()
        {
            SignInButton.Click();
        }

        public void ClickSignUpButtonInDropdown()
        {
            common.MouseOverToElement(SignInButton);
            D_SignUpElement.Click();
        }

        public void ClickSignInButtonInDropdown()
        {
            common.MouseOverToElement(SignInButton);
            D_SignInElement.Click();
        }
    }
}
