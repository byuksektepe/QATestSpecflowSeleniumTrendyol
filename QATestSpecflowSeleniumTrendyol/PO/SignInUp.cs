using OpenQA.Selenium;
using QATestSpecflowSeleniumTrendyol.Resources;

namespace QATestSpecflowSeleniumTrendyol.PO
{
    public class SignInUp
    {
        private readonly IWebDriver Driver;
        private readonly Common common;

        private const string SignInVerifyLocator = "//div[@id='login-register']";

        public SignInUp(IWebDriver driver)
        {
            Driver = driver;
            common = new Common(driver);
        }

        public void VerifyPageLoad()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            common.WaitUntilElement(By.XPath(SignInVerifyLocator), "Visible");
        }
    }
}
