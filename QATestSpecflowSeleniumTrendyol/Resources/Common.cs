namespace QATestSpecflowSeleniumTrendyol.Resources
{
    public class Common
    {
        public const string SiteUrl = "https://trendyol.com";
        public const string ModalCloseElement = "//div[@class='modal-content']//div[@class='modal-close']";
        public const string PageLoadVerifyElement = "//div[@class='header']//a[@id='logo']";

        public const string PopupLocator = "//div[@class='popup']";
        public const string OverlayLocator = "//div[@class='overlay']";


        private IWebDriver _webDriver;
        private readonly IJavaScriptExecutor js;
        public readonly Actions action;
        public readonly WebDriverWait wait;

        // its a default wait time for expicit waits
        public const int DefaultWaitInSeconds = 10;
        public const int DefaultPageWaitInSeconds = 20;

        public Common(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            js = (IJavaScriptExecutor)webDriver;
            action = new Actions(webDriver);
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(DefaultWaitInSeconds));
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
            WaitForPageLoad();
            #pragma warning disable CS8600
            IWebElement ModalClose = FindElementAndIgnoreErrors("XPath", ModalCloseElement);

            #pragma warning disable CS8604
            if (Exists(ModalClose))
            {
                ModalClose.Click();
            }
            #pragma warning restore CS8604
            #pragma warning restore CS8600
        }

        public void ClosePopupIfExists()
        {
            WaitForPageLoad();
            #pragma warning disable CS8600
            IWebElement PopupElement = FindElementAndIgnoreErrors("XPath", PopupLocator);
            IWebElement OverlayElement = FindElementAndIgnoreErrors("XPath", OverlayLocator);

            #pragma warning disable CS8604
            if (Exists(OverlayElement) || Exists(PopupElement))
            {
            #pragma warning disable CS8602
                OverlayElement.Click();
            #pragma warning restore CS8602
            }
            #pragma warning restore CS8604
            #pragma warning restore CS8600
        }

        public IWebElement? FindElementAndIgnoreErrors(string method, string locator)
        { 
            method = method.ToLower();
            switch (method)
            {
                case Locators.XPath:
                    try 
                    { 
                        return _webDriver.FindElement(By.XPath(locator)); 
                    } 
                    catch(NoSuchElementException e) 
                    {
                        Console.WriteLine("Exception Ignored:  "+e);
                        return null; 
                    }
                case Locators.Id:
                    try
                    {
                        return _webDriver.FindElement(By.Id(locator));
                    }
                    catch (NoSuchElementException e)
                    {
                        Console.WriteLine("Exception Ignored:  " + e);
                        return null;
                    }
                case Locators.CSS:
                    try
                    {
                        return _webDriver.FindElement(By.CssSelector(locator));
                    }
                    catch (NoSuchElementException e)
                    {
                        Console.WriteLine("Exception Ignored:  " + e);
                        return null;
                    }
                default:
                    try
                    {
                        return _webDriver.FindElement(By.XPath(locator));
                    }
                    catch (NoSuchElementException e)
                    {
                        Console.WriteLine("Exception Ignored: "+e);
                        return null;
                    }
            }
        }


        public bool Exists(IWebElement element)
        {
            if (element == null)
            { return false; }
            return true;
        }

        public void WaitForPageLoad()
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(DefaultPageWaitInSeconds));
            wait.Until(driver => js.ExecuteScript("return document.readyState").Equals("complete"));
            // This 7ms wait for prevent sync errors.
            System.Threading.Thread.Sleep(700);
        }

        public void VerifyPageLoad()
        {
            WaitUntilElement(By.XPath(PageLoadVerifyElement));
            // This 3ms wait for prevent sync errors.
            System.Threading.Thread.Sleep(300);
        }

        public void ScrollToElement(IWebElement element)
        {
            // Aptal firefox için Scroll to el methodu.
            try
            {
                action.MoveToElement(element).Perform();
            }
            catch (MoveTargetOutOfBoundsException e)
            {
                Console.WriteLine(e);
                js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            }
        }

        public void MouseOverToElement(IWebElement element)
        {
            // it only works properly in chrome and chromium based browsers.
            action.MoveToElement(element).Perform();
            // This 5ms wait for prevent sync errors.
            System.Threading.Thread.Sleep(500);
        }

        public void Sleep(int Time)
        {
            // Hand writed method, Sleep like in Robot Framework.
            int SecsToMs = Time * 1000;
            System.Threading.Thread.Sleep(SecsToMs);
        }

        public void WaitUntilElement(By elementLocator, string method = "Visible")
        {
            try
            {
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

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found.");
                throw;
            }
        }
    }
}
