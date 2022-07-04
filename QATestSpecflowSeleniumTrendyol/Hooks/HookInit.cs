using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using QATestSpecflowSeleniumTrendyol.Drivers;
using QATestSpecflowSeleniumTrendyol.Resources;
using BoDi;

namespace QATestSpecflowSeleniumTrendyol.Hooks
{
    [Binding]
    public sealed class HookInit
    {
        private static Common _common;

        [BeforeTestRun]
        public static void BeforeTestRun(ObjectContainer testThreadContainer)
        {
            testThreadContainer.BaseContainer.Resolve<SeleniumDriver>();
        }

        [BeforeScenario]
        public static void BeforeScenario(SeleniumDriver driver)
        {
            _common = new Common(driver.Current);
            _common.StartTest();
        }
    }
}