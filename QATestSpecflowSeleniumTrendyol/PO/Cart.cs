using OpenQA.Selenium;
using QATestSpecflowSeleniumTrendyol.Resources;

namespace QATestSpecflowSeleniumTrendyol.PO
{
    public class Cart
    {
        private readonly IWebDriver Driver;
        private readonly Common common;

        private const string CartVerifyLocator = "//div[@id='basket-app-container']";
        private const string ProductVerifyLocator = "//div[@class='pb-merchant-group'][1]";

        public Cart(IWebDriver webDriver)
        {
            Driver = webDriver;
            common = new Common(webDriver);
        }

        IWebElement ProductVerifyElement => Driver.FindElement(By.XPath(ProductVerifyLocator));

        public void VerifyPageLoad()
        {
            common.WaitForPageLoad();
            common.WaitUntilElement(By.XPath(CartVerifyLocator));
        }

        public void VerifyCartPageOpened()
        {
            common.WaitUntilElement(By.XPath(CartVerifyLocator), Conditions.Exists);
        }

        public void VerifyProductAddedToCartByGivenLink(string GivenUrl)
        {
            GivenUrl = GivenUrl.Replace("https://www.trendyol.com", "");
            string ReceivedProductUrlLocator =  String.Format("//div[@class='pb-basket-item']//a[contains(@href, '{0}')]", GivenUrl);
            IWebElement ReceivedProductUrlElement = common.FindElementAndIgnoreErrors(Locators.XPath, ReceivedProductUrlLocator);

            if (!common.Exists(ReceivedProductUrlElement))
            {
                throw new ProductNotFoundCalledPageException(GivenUrl);
            }
        }

        public void ClickProductIncreaseButtonByGivenTimes(string ForTimes, string GivenUrl)
        {
            int forTimes;
            if(!int.TryParse(ForTimes, out forTimes))
            {
                throw new TryParseException();
            }

            GivenUrl = GivenUrl.Replace("https://www.trendyol.com", "");
            string ReceivedProductIncreaseButtonLocator = String.Format("//div[@class='pb-basket-item']//a[contains(@href, '{0}')]/..//div[@class='pb-basket-item-actions']//button[@class='ty-numeric-counter-button']", GivenUrl);
            IWebElement ReceivedProductIncreaseButtonElement = Driver.FindElement(By.XPath(ReceivedProductIncreaseButtonLocator));

            foreach (int i in Enumerable.Range(1, forTimes))
            {
                ReceivedProductIncreaseButtonElement.Click();
                common.WaitForPageLoad();
                common.WaitUntilElement(By.XPath(ReceivedProductIncreaseButtonLocator), Conditions.Clickable);
            }
        }

        public void VerifyProductNumberIncreaseByGiven(string ForTimes, string GivenUrl, int Calibration = 0)
        { // Kalibrasyon zaten sepette eklenmiş ürün varsa onu toplamak için kullanılır. Değer verilmediğinde 0 dır.
            common.WaitForPageLoad();
            int forTimes;
            if (!int.TryParse(ForTimes, out forTimes))
            {
                throw new TryParseException();
            }

            GivenUrl = GivenUrl.Replace("https://www.trendyol.com", "");
            string ReceivedProductNumberLocator = String.Format("//div[@class='pb-basket-item']//a[contains(@href, '{0}')]/..//div[@class='pb-basket-item-actions']//input[@class='counter-content']", GivenUrl);
            IWebElement ReceivedProductNumberElement = Driver.FindElement(By.XPath(ReceivedProductNumberLocator));

            string ProductPiece = ReceivedProductNumberElement.GetAttribute("value");
            if (Calibration != 0) { forTimes = forTimes + Calibration; }

            if (!ProductPiece.Equals(Convert.ToString(forTimes)))
            {
                throw new ProductNumberNotMatchException(forTimes, ProductPiece);
            }
        }

        public void ClickProductDeleteButtonByGiven(string GivenUrl)
        {
            GivenUrl = GivenUrl.Replace("https://www.trendyol.com", "");
            string ReceivedProductDeleteButtonLocator = String.Format("//div[@class='pb-basket-item']//a[contains(@href, '{0}')]/..//div[@class='pb-basket-item-actions']/button", GivenUrl);
            IWebElement ReceivedProductDeleteButtonElement = Driver.FindElement(By.XPath(ReceivedProductDeleteButtonLocator));

            ReceivedProductDeleteButtonElement.Click();
            common.WaitForPageLoad();
        }

        public void VerifyProductIsDeletedByGiven(string GivenUrl)
        {
            GivenUrl = GivenUrl.Replace("https://www.trendyol.com", "");
            string ReceivedProductUrlLocator = String.Format("//div[@class='pb-basket-item']//a[contains(@href, '{0}')]", GivenUrl);
            IWebElement ReceivedProductUrlElement = common.FindElementAndIgnoreErrors(Locators.XPath, ReceivedProductUrlLocator);

            if (common.Exists(ReceivedProductUrlElement))
            {
                throw new ProductNotFoundCalledPageException(GivenUrl);
            }
        }
    }
}
