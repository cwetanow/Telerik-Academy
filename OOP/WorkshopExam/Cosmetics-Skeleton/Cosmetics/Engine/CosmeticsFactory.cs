namespace Cosmetics.Engine
{
    using System.Collections.Generic;

    using Cosmetics.Common;
    using Cosmetics.Contracts;
    using Cosmetics.Products;
    using Cart;
	
    public class CosmeticsFactory : ICosmeticsFactory
    {
        public Category CreateCategory(string name)
        {
            // TODO: create category
            Category newCategory = new Category(name);
            return newCategory;
        }

        public Shampoo CreateShampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
        {
            // TODO: create shampoo
           Shampoo newShampoo= new Shampoo(name,brand,price,gender,milliliters,usage);
            return newShampoo;

        }

        public Toothpaste CreateToothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
        {
            // TODO: create toothpaste
            Toothpaste newToothpaste = new Toothpaste(name, brand, price, gender,ingredients);
            return newToothpaste;
        }

        public ShoppingCart ShoppingCart()
        {

            // TODO: create shopping cart
            ShoppingCart newCart = new ShoppingCart();
            return newCart;
        }
    }
}
