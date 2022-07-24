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
            common.WaitUntilElement(By.XPath(SignUpVerifyLocator), Conditions.Visible);
        }

        public void SetEmailAndPassword(string Email, string Password)
        {
            if (!String.IsNullOrWhiteSpace(Email))
            {
                EmailInputElement.SendKeys(Email);
            }
            
            if (!String.IsNullOrWhiteSpace(Password))
            {
                PasswordInputElement.SendKeys(Password);
            }
        }

        public void VerifyExceptionMessageByGiven(string GivenException)
        {
            common.WaitUntilElement(By.XPath(ExceptionMessageLocator), Conditions.Visible);

            string ReceivedException = (ExceptionMessageElement.Text).ToLower();
            GivenException = GivenException.ToLower();

            if (!ReceivedException.Equals(GivenException))
            {
                throw new ExceptionMessageNotMatchByGivenException(GivenException, ReceivedException);
            }
        }

        public void VerifyPasswordWarnerMessageByGiven(string GivenMessage)
        {
            common.WaitUntilElement(By.XPath(PasswordWarnerMessageLocator), Conditions.Visible);

            string ReceivedMessage = (PasswordWarnerMessageElement.Text).ToLower();
            GivenMessage = GivenMessage.ToLower();

            if (!ReceivedMessage.Equals(GivenMessage))
            {
                throw new MessageNotMatchByGivenException(GivenMessage, ReceivedMessage);
            }
        }

        public void ClickSignUpButtonForSubmit()
        {
            subMethods.AcceptCoockiesIfVisible();
            SignUpButtonElement.Click();
        }
    }
}
