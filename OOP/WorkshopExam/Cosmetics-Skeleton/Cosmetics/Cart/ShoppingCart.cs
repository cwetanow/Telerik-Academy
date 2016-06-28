using Cosmetics.Contracts;
using Cosmetics.Engine.Contracts;
using Cosmetics.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Cart
{
    public class ShoppingCart:IShoppingCart
    {

        private ICollection<IProduct> productList;

        
        public ShoppingCart()
        {
            this.ProductList = new List<IProduct>();
        }

        public ICollection<IProduct> ProductList
        {
            get { return this.productList; }
            set { productList = value; }
        }

        public void AddProduct(IProduct product)
        {
            this.ProductList.Add(product);
           
        }

        public bool ContainsProduct(IProduct product)
        {
            return this.ProductList.Contains(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.ProductList.Remove(product);
        }

        public decimal TotalPrice()
        {
            return this.ProductList.Select(s => s.Price).Sum();
        }
    }
}
