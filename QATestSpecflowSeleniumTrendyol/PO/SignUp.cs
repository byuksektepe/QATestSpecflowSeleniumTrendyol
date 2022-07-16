namespace QATestSpecflowSeleniumTrendyol.PO
{
    public class SignUp
    {
        private readonly IWebDriver Driver;
        private readonly Common common;
        private readonly SubMethods subMethods;

        public SignUp(IWebDriver driver)
        {
            Driver = driver;
            common = new Common(driver);
            subMethods = new SubMethods(driver);
        }
    }
}
