using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace QATestSpecflowSeleniumTrendyol.Resources
{
    public class Common
    {
        public const string SiteUrl = "https://trendyol.com";
        public const string ModalCloseElement = "//div[@class='modal-content']//div[@class='modal-close']";
        public const string PageLoadVerifyElement = "//div[@class='header']//a[@id='logo']";

        private readonly IWebDriver _webDriver;

        // its a default wait time for expicit waits
        public const int DefaultWaitInSeconds = 5;

        public Common(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void StartTest()
        {
            if (_webDriver.Url != SiteUrl)
            {
                _webDriver.Manage().Window.Maximize();
                _webDriver.Url = SiteUrl;
                CloseModalIfExists();

            }
        }

        public void EndTest()
        {
            _webDriver.Quit();
        }

        public void CloseModalIfExists()
        {
            IWebElement ModalClose = _webDriver.FindElement(By.XPath(ModalCloseElement));
            if (Exists(ModalClose)) {
                ModalClose.Click();
            }

        }

        public static bool Exists(IWebElement element)
        {
            if (element == null)
            { return false; }
            return true;
        }

        public void VerifyPageLoad()
        {

        }

        public void WaitForPageToLoad(Action doing)
        {
            IWebElement oldPage = _webDriver.FindElement(By.TagName("html"));
            doing();
            WebDriverWait wait = new WebDriverWait(_webDriver, new TimeSpan(0, 0, DefaultWaitInSeconds));
            try
            {
                wait.Until(driver => ExpectedConditions.StalenessOf(oldPage)(_webDriver) &&
                    ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            }
            catch (Exception pageLoadWaitError)
            {
                throw new TimeoutException("Timeout during page load", pageLoadWaitError);
            }
        }


        // taken from specflow website, WaitUntil method
        private T WaitUntil<T>(Func<T> getResult, Func<T, bool> isResultAccepted) where T : class
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(DefaultWaitInSeconds));
            #pragma warning disable CS8603 // Possible null reference return.
            return wait.Until(driver =>
            {

                var result = getResult();
                if (!isResultAccepted(result))
                    return default;
                return result;

            });
            #pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
