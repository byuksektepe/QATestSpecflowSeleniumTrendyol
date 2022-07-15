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
        {

        }
    }
}
