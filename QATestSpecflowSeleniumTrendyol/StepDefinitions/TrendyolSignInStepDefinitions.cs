using System;
using TechTalk.SpecFlow;
using QATestSpecflowSeleniumTrendyol.Drivers;
using QATestSpecflowSeleniumTrendyol.PO;
using QATestSpecflowSeleniumTrendyol.Resources;

namespace QATestSpecflowSeleniumTrendyol.StepDefinitions
{
    [Binding]
    public class TrendyolSignInStepDefinitions
    {
        private readonly Common common;
        private readonly Navbar navbar;
        private readonly SignIn signIn;
        private readonly SubMethods subMethods;

        public TrendyolSignInStepDefinitions(SeleniumDriver driver)
        {
            common = new Common(driver.Current);
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
        public void GivenVerifyLoginPageOpened()
        {
            signIn.VerifyPageLoad();
        }

        [When(@"Set email and password")]
        public void WhenSetEmailAndPassword()
        {
            throw new PendingStepException();
        }

        [When(@"Click login button to submit form")]
        public void WhenClickLoginButtonToSubmitForm()
        {
            throw new PendingStepException();
        }

        [Then(@"Check exception message")]
        public void ThenCheckExceptionMessage()
        {
            throw new PendingStepException();
        }
    }
}
