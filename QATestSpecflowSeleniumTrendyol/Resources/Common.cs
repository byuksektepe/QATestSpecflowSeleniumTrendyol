using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
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
        private readonly Actions action;
        

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
            if (Exists(ModalClose)) {
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
            // its scrolls and ignore errors. For firefox's fucking scroll error.
            try
            {
                action.MoveToElement(elementLocator).Perform();
            }
            catch
            {
                Console.WriteLine("Info: Scroll error catched in: " + elementLocator + ". Error Ignored, used js.");
                js.ExecuteScript("arguments[0].scrollIntoView(true);", elementLocator);
            }

        }

        public void Sleep(int Time)
        {
            // Hand writed method, Sleep like in Robot Framework.
            int SecsToMs = Time * 1000;
            System.Threading.Thread.Sleep(SecsToMs);
        }

        public IWebElement WaitUntilElement(By elementLocator, string method="Visible", int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(timeout));
                if(method == "Clickable") 
                {
                    return wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
                }
                else if (method == "Exists")
                {
                    return wait.Until(ExpectedConditions.ElementExists(elementLocator));
                }
                else if (method == "Visible")
                {
                    return wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
                }
                else
                {
                    return wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
                }
                
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
