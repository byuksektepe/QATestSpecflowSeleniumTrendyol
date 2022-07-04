using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace QATestSpecflowSeleniumTrendyol.PO
{
    public class Common
    {
        public const string url = "https://trendyol.com";

        private readonly IWebDriver _webDriver;

        // its a default wait time for expicit waits
        public const int DefaultWaitInSeconds = 5;

        public Common(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
    }
}
