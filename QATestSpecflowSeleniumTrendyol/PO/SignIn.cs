namespace QATestSpecflowSeleniumTrendyol.PO
{
    public class SignIn
    {
        private readonly IWebDriver Driver;
        private readonly Common common;
        private readonly SubMethods subMethods;

        private const string SignInVerifyLocator = "//div[@id='login-register']";
        private const string EmailInputLocator = "//input[@id='login-email']";
        private const string PasswordInputLocator = "//input[@id='login-password-input']";
        private const string SignInButtonLocator = "//button[@class='q-primary q-fluid q-button-medium q-button submit']";

        private const string ExceptionMessageLocator = "//div[@id='error-box-wrapper']//span[@class='message']";

        public SignIn(IWebDriver driver)
        {
            Driver = driver;
            common = new Common(driver);
            subMethods = new SubMethods(driver);
        }

        private IWebElement EmailInputElement => Driver.FindElement(By.XPath(EmailInputLocator));
        private IWebElement PasswordInputElement => Driver.FindElement(By.XPath(PasswordInputLocator));
        private IWebElement SignInButtonElement => Driver.FindElement(By.XPath(SignInButtonLocator));
        private IWebElement ExceptionMessageElement => Driver.FindElement(By.XPath(ExceptionMessageLocator));

        public void VerifyPageLoad()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            common.WaitForPageLoad();
            common.WaitUntilElement(By.XPath(SignInVerifyLocator), "Visible");
        }

        public void SetEmailAndPassword(string email, string password)
        {
            EmailInputElement.SendKeys(email);
            PasswordInputElement.SendKeys(password);
        }

        public void VerifyExceptionMessageByGiven(string GivenException)
        {
            common.WaitUntilElement(By.XPath(ExceptionMessageLocator), "Visible");

            string ReceivedException = (ExceptionMessageElement.Text).ToLower();
            GivenException = GivenException.ToLower();

            if (!ReceivedException.Equals(GivenException))
            {

                throw new ExceptionMessageNotMatchByGivenException(GivenException, ReceivedException);
            }
        }

        public void ClickSignInButtonForSubmit()
        {
            subMethods.AcceptCoockiesIfVisible();
            SignInButtonElement.Click();
        }
    }
}
