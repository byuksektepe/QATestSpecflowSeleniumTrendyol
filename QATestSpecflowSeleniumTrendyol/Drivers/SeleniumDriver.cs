using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace QATestSpecflowSeleniumTrendyol.Drivers
{
    public class SeleniumDriver : IDisposable
    {
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;
        private bool _isDisposed;
        private const string browser = "chrome";

        public SeleniumDriver()
        {
            _currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver(browser));
        }

        public IWebDriver Current => _currentWebDriverLazy.Value;

        private IWebDriver CreateWebDriver(string browser)
        {
            return SetDriver(browser);
        }

        public IWebDriver SetDriver(string browser)
        {
            browser = browser.ToLower();

            if (browser == "chrome") { return ChromeWebDriver(); }

            else if (browser == "firefox") { return FirefoxWebDriver(); }

            else if (browser == "edge") { return EdgeWebDriver(); }

            else { return ChromeWebDriver(); }
        }

        private IWebDriver FirefoxWebDriver()
        {
            var firefoxDriverService = FirefoxDriverService.CreateDefaultService();

            var firefoxOptions = new FirefoxOptions();

            var firefoxDriver = new FirefoxDriver(firefoxDriverService, firefoxOptions);

            return firefoxDriver;
        }

        private IWebDriver ChromeWebDriver()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-notifications");

            var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);

            return chromeDriver;
        }

        private IWebDriver EdgeWebDriver()
        {
            var edgeDriverService = EdgeDriverService.CreateDefaultService();

            var edgeOptions = new EdgeOptions();

            var edgeDriver = new EdgeDriver(edgeDriverService, edgeOptions);

            return edgeDriver;
        }


        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            if (_currentWebDriverLazy.IsValueCreated)
            {
                Current.Quit();
            }

            _isDisposed = true;
        }
    }
}
