using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Contracts;
using Cosmetics.Products;

namespace Cosmetics.Tests.Mocks
{
    class MockedCategory : Category
    {
        public MockedCategory() : base("Mocked category")
        {
        }

        public IList<IProduct> Products
        {
            get { return base.products; }
        }
    }
}
