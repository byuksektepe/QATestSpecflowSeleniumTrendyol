using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QATestSpecflowSeleniumTrendyol.Resources;

namespace QATestSpecflowSeleniumTrendyol.PO
{
    public class SearchResults
    {
        private readonly IWebDriver Driver;
        private readonly Common common;

        public SearchResults(IWebDriver webDriver)
        {
            Driver = webDriver;
            common = new Common(webDriver);
        }
    }


}
