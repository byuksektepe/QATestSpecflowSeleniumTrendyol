using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace QATestSpecflowSeleniumTrendyol.Drivers
{
    public class SeleniumDriver : IDisposable
    {
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;
        private bool _isDisposed;

        public SeleniumDriver()
        {
            _currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver);
        }


        public IWebDriver Current => _currentWebDriverLazy.Value;


        private IWebDriver CreateWebDriver()
        {
            return ChromeWebDriver();
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
