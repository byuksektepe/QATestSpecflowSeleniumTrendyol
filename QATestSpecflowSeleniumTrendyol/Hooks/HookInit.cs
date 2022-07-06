using BoDi;
using QATestSpecflowSeleniumTrendyol.Drivers;
using QATestSpecflowSeleniumTrendyol.Resources;

namespace QATestSpecflowSeleniumTrendyol.Hooks
{
    [Binding]
    public sealed class HookInit
    {
        private static Common common;

        [BeforeTestRun]
        public static void BeforeTestRun(ObjectContainer testThreadContainer)
        {
            testThreadContainer.BaseContainer.Resolve<SeleniumDriver>();
        }

        [BeforeScenario]
        public static void BeforeScenario(SeleniumDriver driver)
        {
            common = new Common(driver.Current);
            common.StartTest();
        }
    }
}