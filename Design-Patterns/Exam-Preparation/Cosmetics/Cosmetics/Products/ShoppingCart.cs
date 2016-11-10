using System;

namespace Cosmetics.Products
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    internal class ShoppingCart : IShoppingCart
    {
        private const string ObjectCannotBeNull = "{0} cannot be null!";

        protected readonly IList<IProduct> products;

        public ShoppingCart()
        {
            this.products = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            if (product == null)
            {
                throw new NullReferenceException(string.Format(ObjectCannotBeNull, "Product to add to cart"));
            }

            this.products.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            if (product == null)
            {
                throw new NullReferenceException(string.Format(ObjectCannotBeNull, "Product to remove from cart"));
            }

            this.products.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            return this.products.Contains(product);
        }

        public decimal TotalPrice()
        {
            return this.products.Sum(pr => pr.Price);
        }
    }
}
