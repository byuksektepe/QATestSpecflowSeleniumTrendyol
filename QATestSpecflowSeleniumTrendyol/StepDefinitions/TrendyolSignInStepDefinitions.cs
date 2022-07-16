using QATestSpecflowSeleniumTrendyol.Drivers;
using QATestSpecflowSeleniumTrendyol.PO;

namespace QATestSpecflowSeleniumTrendyol.StepDefinitions
{
    [Binding]
    public class TrendyolSignInStepDefinitions
    {
        private readonly Navbar navbar;
        private readonly SignIn signIn;
        private readonly SubMethods subMethods;

        public TrendyolSignInStepDefinitions(SeleniumDriver driver)
        {
            navbar = new Navbar(driver.Current);
            signIn = new SignIn(driver.Current);
            subMethods = new SubMethods(driver.Current);
        }

        [Given(@"Click login button in navbar")]
        public void GivenClickLoginButtonInNavbar()
        {
            navbar.ClickSignInButton();
        }

        [Given(@"Verify login page opened")]
        [Then(@"Verify login page opened")]
        public void ThenVerifyLoginPageOpened()
        {
            signIn.VerifyPageLoad();
        }

        [When(@"Set email to ""([^""]*)"" and password to ""([^""]*)"" in signin form")]
        public void WhenSetEmailToAndPasswordTo(string Email, string Password)
        {
            signIn.SetEmailAndPassword(Email, Password);
        }

        [When(@"Click login button to submit form")]
        public void WhenClickLoginButtonToSubmitForm()
        {
            signIn.ClickSignInButtonForSubmit();
        }

        [Then(@"Check exception message ""([^""]*)"" in signin form")]
        public void ThenCheckExceptionMessage(string Message)
        {
            signIn.VerifyExceptionMessageByGiven(Message);
        }

    }
}
