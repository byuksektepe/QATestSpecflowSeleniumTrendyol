using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QATestSpecflowSeleniumTrendyol.Resources
{
    [Serializable]
    class BrandNotMatchByGivenException : Exception
    {
        public BrandNotMatchByGivenException() { }

        public BrandNotMatchByGivenException(string ReceivedBrand, string GivenBrand)
            : base(String.Format("Product brand '{0}' is not equals given '{1}' brand name.", ReceivedBrand, GivenBrand))
        {}
    }

    [Serializable]
    class ProductTitleNotContainsSearchQueryException : Exception
    {
        public ProductTitleNotContainsSearchQueryException() { }

        public ProductTitleNotContainsSearchQueryException(string ProductTitle, string SearchQuery)
            : base(String.Format("Product title '{0}' is not contains given '{1}' search query.", ProductTitle, SearchQuery))
        { }
    }
}
