namespace QATestSpecflowSeleniumTrendyol.PO
{
    public class ProductDetail
    {
        private readonly IWebDriver Driver;
        private readonly Common common;

        private const string ProductDetailVerifyLocator = "//main[@id='product-detail-app']";
        private const string AddToCartButtonLocator = "//div[@class='add-to-basket-button-text']";
        private const string AddToFavoritesButtonLocator = "//div[@class='favorite-button']";
        private const string SeeCartLocator = "//div[@class='account-nav-item basket-preview']";

        private const string CommentsMainLocator = "//article[@data-drroot='product-reviews']";
        private const string ProductBrandLocator = "//div[@class='product-container']//h1[@class='pr-new-br']/a";
        private const string ProductTitleLocator = "//div[@class='product-container']//h1[@class='pr-new-br']";

        private const string ProductSellerLocator = "//section[@class='seller-widget widget']//div[@class='seller-container']/a";

        public ProductDetail(IWebDriver webDriver)
        {
            Driver = webDriver;
            common = new Common(webDriver);
        }
        //

        private IWebElement ProductDetailVerifyElement => Driver.FindElement(By.XPath(ProductDetailVerifyLocator));
        private IWebElement AddToCartButtonElement => Driver.FindElement(By.XPath(AddToCartButtonLocator));
        private IWebElement SeeCartElement => Driver.FindElement(By.XPath(SeeCartLocator));
        private IWebElement AddToFavoritesButtonElement => Driver.FindElement(By.XPath(AddToFavoritesButtonLocator));
        private IWebElement CommentsMainElement => Driver.FindElement(By.XPath(CommentsMainLocator));

        private IWebElement ProductBrandElement => Driver.FindElement(By.XPath(ProductBrandLocator));
        private IWebElement ProductTitleElement => Driver.FindElement(By.XPath(ProductTitleLocator));

        private IWebElement ProductSellerElement => Driver.FindElement(By.XPath(ProductSellerLocator));

        public void VerifyPageLoad()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            common.WaitForPageLoad();
            common.WaitUntilElement(By.XPath(ProductDetailVerifyLocator), "Visible");
        }

        public void ClickAddToCartButton()
        {
            AddToCartButtonElement.Click();
            common.Sleep(2);
        }

        public void ClickAddToFavoritesButton()
        {
            AddToFavoritesButtonElement.Click();
            common.Sleep(1);
        }

        public void VerifyCommentsAreVisible()
        {
            common.WaitUntilElement(By.XPath(CommentsMainLocator), "Exists");
            common.ScrollToElement(CommentsMainElement);
            common.WaitUntilElement(By.XPath(CommentsMainLocator), "Visible");
        }

        public void ClickSeeCartElement()
        {
            SeeCartElement.Click();
        }

        public void VerifyProductBrandByGivenBrand(string Brand)
        {
            string BrandText = (ProductBrandElement.Text).ToLower();
            Brand = Brand.ToLower();
            if (!BrandText.Equals(Brand))
            {
                throw new BrandNotMatchByGivenException(BrandText, Brand);
            }
        }

        public void VerifyProductTitleContainsSearchQuery(string SearchQuery)
        {
            string ProductTitle = (ProductTitleElement.Text).ToLower();
            SearchQuery = SearchQuery.ToLower();
            if (!ProductTitle.Contains(SearchQuery))
            {
                throw new ProductTitleNotContainsSearchQueryException(ProductTitle, SearchQuery);
            }
        }

        public string GetProductSellerName()
        {
            common.ScrollToElement(ProductSellerElement);
            return ProductSellerElement.Text;
        }

        public string GetProductBaseUrl()
        {
           return common.GetCurrentUrl();
        }

        public void VerifyProductLinkByGiven()
        {

        }

        public void ClickProductSellerLink()
        {
            ProductSellerElement.Click();
        }
    }
}
