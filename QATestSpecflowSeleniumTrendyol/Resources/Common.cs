using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace QATestSpecflowSeleniumTrendyol.Resources
{
    public class Common
    {
        public const string SiteUrl = "https://trendyol.com";
        public const string ModalCloseElement = "//div[@class='modal-content']//div[@class='modal-close']";
        public const string PageLoadVerifyElement = "//div[@class='header']//a[@id='logo']";

        private readonly IWebDriver _webDriver;
        private readonly IJavaScriptExecutor js;
        public readonly Actions action;


        // its a default wait time for expicit waits
        public const int DefaultWaitInSeconds = 5;

        public Common(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            js = (IJavaScriptExecutor)webDriver;
            action = new Actions(webDriver);
        }

        public void StartTest()
        {
            if (_webDriver.Url != SiteUrl)
            {
                _webDriver.Manage().Window.Maximize();
                _webDriver.Url = SiteUrl;
                CloseModalIfExists();

            }
        }

        public void EndTest()
        {
            _webDriver.Quit();
        }

        public void CloseModalIfExists()
        {
            VerifyPageLoad();
            IWebElement ModalClose = _webDriver.FindElement(By.XPath(ModalCloseElement));
            if (Exists(ModalClose))
            {
                ModalClose.Click();
            }

        }

        public static bool Exists(IWebElement element)
        {
            if (element == null)
            { return false; }
            return true;
        }

        public void VerifyPageLoad()
        {
            WaitUntilElement(By.XPath(PageLoadVerifyElement));
            // This 3ms wait for prevent sync errors.
            System.Threading.Thread.Sleep(300);
        }

        public void ScrollToElement(IWebElement elementLocator)
        {
            try
            {
                action.MoveToElement(elementLocator).Perform();
            }
            catch (MoveTargetOutOfBoundsException e)
            {
                Console.WriteLine(e);
                js.ExecuteScript("arguments[0].scrollIntoView(true);", elementLocator);
            }
        }

        public void Sleep(int Time)
        {
            // Hand writed method, Sleep like in Robot Framework.
            int SecsToMs = Time * 1000;
            System.Threading.Thread.Sleep(SecsToMs);
        }

        public void WaitUntilElement(By elementLocator, string method = "Visible", int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(timeout));
                if (method == "Clickable")
                {
                    wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
                }
                else if (method == "Exists")
                {
                    wait.Until(ExpectedConditions.ElementExists(elementLocator));
                }
                else if (method == "Visible")
                {
                    wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
                }
                else
                {
                    wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
                }
                Console.WriteLine(method);

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found.");
                throw;
            }
        }

        // taken from specflow website, WaitUntil method
        private T WaitUntil<T>(Func<T> getResult, Func<T, bool> isResultAccepted) where T : class
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(DefaultWaitInSeconds));
#pragma warning disable CS8603 // Possible null reference return.
            return wait.Until(driver =>
            {

                var result = getResult();
                if (!isResultAccepted(result))
                    return default;
                return result;

            });
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
