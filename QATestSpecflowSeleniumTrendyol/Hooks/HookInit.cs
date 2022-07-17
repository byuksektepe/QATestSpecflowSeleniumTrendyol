using QATestSpecflowSeleniumTrendyol.Drivers;

namespace QATestSpecflowSeleniumTrendyol.Hooks
{
    [Binding]
    public sealed class HookInit
    {
        private static Common common;

        [BeforeScenario]
        public static void BeforeScenario(SeleniumDriver driver)
        {
            common = new Common(driver.Current);
            common.StartTest();
        }

        [AfterScenario]
        public static void AfterScenario(SeleniumDriver driver)
        {
            common = new Common(driver.Current);
            common.EndTest();
        }
    }
}