using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using QATestSpecflowSeleniumTrendyol.Drivers;
using QATestSpecflowSeleniumTrendyol.Resources;

namespace QATestSpecflowSeleniumTrendyol.StepDefinitions
{
    [Binding]
    public class TrendyolOnChromeStepDefinitions
    {
        private readonly Common _common;

        public TrendyolOnChromeStepDefinitions(SeleniumDriver driver)
        {
            _common = new Common(driver.Current);
        }

        [Given(@"Navigate to trendyol website")]
        public void GivenNavigateToTrendyolWebsite()
        {

        }

    }

}
