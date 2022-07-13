using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace QATestSpecflowSeleniumTrendyol.Resources
{
    public class SubMethods
    {
        private readonly IWebDriver Driver;
        private readonly Common common;

        private const string MoveToTopButtonLocator = "//div[@id='scrollToUp']//div[@class='scroll-to-up']";
        private const string PageTopVerifyLocator = "//div[@id='headerMain']//div[@class='header-top']//li[1]";

        private const string AcceptCoockiesButton = "//button[@id='onetrust-accept-btn-handler']";

        public SubMethods(IWebDriver driver)
        {
            Driver = driver;
            common = new Common(driver);
        }

        IWebElement MoveToTopButtonElement => Driver.FindElement(By.XPath(MoveToTopButtonLocator));
        IWebElement PageTopElement => Driver.FindElement(By.XPath(PageTopVerifyLocator));
        IWebElement AcceptCookiesElement => common.FindElementAndIgnoreErrors("XPath", AcceptCoockiesButton);

        public void AcceptCoockiesIfVisible()
        {
            if (common.Exists(AcceptCookiesElement))
            {
                AcceptCookiesElement.Click();
            }
        }

        public void ClickMoveToTopButton()
        {
            MoveToTopButtonElement.Click();
        }

        public void VerifyTopOfThePageIsVisible()
        {
            common.WaitUntilElement(By.XPath(PageTopVerifyLocator), "Visible");
            common.Sleep(1);
        }

    }
}
