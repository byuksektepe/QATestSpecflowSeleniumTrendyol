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
            throw new PendingStepException();
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
            throw new PendingStepException();
        }

        [When(@"Check password warner if required to ""([^""]*)""")]
        public void WhenCheckPasswordWarnerIfRequiredTo(string p0)
        {
            throw new PendingStepException();
        }

        [Then(@"Check exception message ""([^""]*)"" in signup form")]
        public void ThenCheckExceptionMessageInSignupForm(string p0)
        {
            throw new PendingStepException();
        }
    }
}
