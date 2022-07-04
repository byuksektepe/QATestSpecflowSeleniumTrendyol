using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace QATestSpecflowSeleniumTrendyol.StepDefinitions
{
    [Binding]
    public class TrendyolOnChromeStepDefinitions
    {
        private ChromeDriver _driver;


        [Given(@"Navigate to trendyol website")]
        public void GivenNavigateToTrendyolWebsite()
        {
            _driver.Navigate().GoToUrl("https://www.trendyol.com/");
        }

    }

}
