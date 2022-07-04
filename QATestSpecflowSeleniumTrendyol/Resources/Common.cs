using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace QATestSpecflowSeleniumTrendyol.Resources
{
    public class Common
    {
        public const string SiteUrl = "https://trendyol.com";

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
            }
        }

        public void EndTest()
        {
            _webDriver.Quit();
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
