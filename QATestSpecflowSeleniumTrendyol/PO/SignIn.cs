using OpenQA.Selenium;
using QATestSpecflowSeleniumTrendyol.Resources;

namespace QATestSpecflowSeleniumTrendyol.PO
{
    public class SignIn
    {
        private readonly IWebDriver Driver;
        private readonly Common common;

        private const string SignInVerifyLocator = "//div[@id='login-register']";

        public SignIn(IWebDriver driver)
        {
            Driver = driver;
            common = new Common(driver);
        }

        public void VerifyPageLoad()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            common.WaitForPageLoad();
            common.WaitUntilElement(By.XPath(SignInVerifyLocator), "Visible");
        }
    }
}
