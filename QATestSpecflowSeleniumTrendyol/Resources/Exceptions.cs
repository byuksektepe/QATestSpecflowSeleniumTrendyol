namespace QATestSpecflowSeleniumTrendyol.Resources
{
    [Serializable]
    class BrandNotMatchByGivenException : Exception
    {
        public BrandNotMatchByGivenException() { }

        public BrandNotMatchByGivenException(string ReceivedBrand, string GivenBrand)
            : base(String.Format("Product brand '{0}' is not equals given '{1}' brand name.", ReceivedBrand, GivenBrand))
        { }
    }

    [Serializable]
    class ProductTitleNotContainsSearchQueryException : Exception
    {
        public ProductTitleNotContainsSearchQueryException() { }

        public ProductTitleNotContainsSearchQueryException(string ProductTitle, string SearchQuery)
            : base(String.Format("Product title '{0}' is not contains given '{1}' search query.", ProductTitle, SearchQuery))
        { }
    }

    [Serializable]
    class ExceptionMessageNotMatchByGivenException : Exception
    {
        public ExceptionMessageNotMatchByGivenException() { }
        public ExceptionMessageNotMatchByGivenException(string GivenException, string ReceivedException)
            : base(String.Format("Given exception message '{0}' is not equals received '{1}' message.", GivenException, ReceivedException))
        
        { }

    }

    [Serializable]
    class MessageNotMatchByGivenException : Exception
    {
        public MessageNotMatchByGivenException() { }
        public MessageNotMatchByGivenException(string GivenException, string ReceivedException)
            : base(String.Format("Given message '{0}' is not equals received '{1}' message.", GivenException, ReceivedException))

        { }

    }

    [Serializable]
    class SellerNameNotMatchByGivenException : Exception
    {
        public SellerNameNotMatchByGivenException() { }
        public SellerNameNotMatchByGivenException(string GivenSellerName, string ReceivedSellerName)
            : base(String.Format("Given seller name '{0}' is not equals received '{1}' seller name.", GivenSellerName, ReceivedSellerName))

        { }

    }

    [Serializable]
    class ProductNotFoundCalledPageException : Exception
    {
        public ProductNotFoundCalledPageException() { }
        public ProductNotFoundCalledPageException(string GivenUrl)
            : base(String.Format("Given product url '{0}' does not found in called page.", GivenUrl))

        { }

    }

}
