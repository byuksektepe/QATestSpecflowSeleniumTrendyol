using QATestSpecflowSeleniumTrendyol.Drivers;
using QATestSpecflowSeleniumTrendyol.PO;

namespace QATestSpecflowSeleniumTrendyol.StepDefinitions
{
    [Binding]
    public class TrendyolSignUpStepDefinitions
    {
        private readonly Navbar navbar;
        private readonly SignUp signUp;
        private readonly SubMethods subMethods;

        public TrendyolSignUpStepDefinitions(SeleniumDriver driver)
        {
            navbar = new Navbar(driver.Current);
            signUp = new SignUp(driver.Current);
            subMethods = new SubMethods(driver.Current);
        }

        [Given(@"Click signup button in navbar")]
        public void GivenClickSignupButtonInNavbar()
        {
            navbar.ClickSignUpButtonInDropdown();
        }

        [Given(@"Verify signup page opened")]
        public void GivenVerifySignupPageOpened()
        {
            signUp.VerifyPageLoad();
        }

        [When(@"Set email to ""([^""]*)"" and password to ""([^""]*)"" in signup form")]
        public void WhenSetEmailToAndPasswordToInSignupForm(string Email, string Password)
        {
            signUp.SetEmailAndPassword(Email, Password);
        }

        [When(@"Click signup button to submit form")]
        public void WhenClickSignupButtonToSubmitForm()
        {
            signUp.ClickSignUpButtonForSubmit();
        }

        [When(@"Check password warner if required to ""([^""]*)""")]
        public void WhenCheckPasswordWarnerIfRequiredTo(string PasswordWarner)
        {
            if (!String.IsNullOrWhiteSpace(PasswordWarner))
            {
                signUp.VerifyPasswordWarnerMessageByGiven(PasswordWarner);
            }

        }

        [Then(@"Check exception message ""([^""]*)"" in signup form")]
        public void ThenCheckExceptionMessageInSignupForm(string Message)
        {
            if (!String.IsNullOrWhiteSpace(Message))
            {
                signUp.VerifyExceptionMessageByGiven(Message);
            }
        }
    }
}
