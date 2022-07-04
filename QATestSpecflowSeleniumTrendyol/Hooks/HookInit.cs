using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;

namespace QATestSpecflowSeleniumTrendyol.Hooks
{
    [Binding]
    public sealed class HookInit
    {
        private ChromeDriver _driver;

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver.Navigate().GoToUrl("about:blank");

        }


        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
        }
    }
}