using Cosmetics.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Contracts;
using Cosmetics.Engine.Contracts;

namespace Cosmetics.Tests.Mocks
{
    internal class MockedCosmeticsEngine : CosmeticsEngine
    {
        private readonly ICosmeticsFactory factory;
        private readonly IShoppingCart shoppingCart;
        private readonly IDictionary<string, ICategory> categories;
        private readonly IDictionary<string, IProduct> products;

        public MockedCosmeticsEngine(ICosmeticsFactory factory, IShoppingCart shopCart)
            : base(factory, shopCart)
        {

        }

        public IDictionary<string,ICategory> Categories {
            get { return this.categories; }
        }
        public IDictionary<string, IProduct> Products
        {
            get { return this.products; }
        }

    }
}
