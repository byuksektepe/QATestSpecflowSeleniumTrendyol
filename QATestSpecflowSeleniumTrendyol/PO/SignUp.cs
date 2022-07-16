namespace QATestSpecflowSeleniumTrendyol.PO
{
    public class SignUp
    {
        private readonly IWebDriver Driver;
        private readonly Common common;
        private readonly SubMethods subMethods;

        private const string SignUpVerifyLocator = EmailInputLocator;
        private const string EmailInputLocator = "//input[@id='register-email']";
        private const string PasswordInputLocator = "//input[@id='register-password-input']";
        private const string SignUpButtonLocator = "//button[@class='q-primary q-fluid q-button-medium q-button submit']";

        private const string ExceptionMessageLocator = "//div[@id='error-box-wrapper']//span[@class='message']";
        private const string PasswordWarnerMessageLocator = "//div[@class='progress-bar-container']/span[contains(@class, 'pw-title')]";


        public SignUp(IWebDriver driver)
        {
            Driver = driver;
            common = new Common(driver);
            subMethods = new SubMethods(driver);
        }

        private IWebElement EmailInputElement => Driver.FindElement(By.XPath(EmailInputLocator));
        private IWebElement PasswordInputElement => Driver.FindElement(By.XPath(PasswordInputLocator));
        private IWebElement SignUpButtonElement => Driver.FindElement(By.XPath(SignUpButtonLocator));

        private IWebElement ExceptionMessageElement => Driver.FindElement(By.XPath(ExceptionMessageLocator));
        private IWebElement PasswordWarnerMessageElement => Driver.FindElement(By.XPath(PasswordWarnerMessageLocator));

        public void VerifyPageLoad()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            common.WaitForPageLoad();
            common.WaitUntilElement(By.XPath(SignUpVerifyLocator), "Visible");
        }

        public void SetEmailAndPassword(string Email, string Password)
        {
            EmailInputElement.SendKeys(Email);
            PasswordInputElement.SendKeys(Password);
        }

        public void ClickSignUpButtonForSubmit()
        {
            subMethods.AcceptCoockiesIfVisible();
            SignUpButtonElement.Click();
        }
    }
}
