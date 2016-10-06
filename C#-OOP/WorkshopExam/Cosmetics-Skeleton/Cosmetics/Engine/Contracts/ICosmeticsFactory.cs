namespace Cosmetics.Contracts
{
    using System.Collections.Generic;

    using Cosmetics.Common;
    using Cart;
    using Engine;
    using Products;
	
    public interface ICosmeticsFactory
    {
        Category CreateCategory(string name);

        Shampoo CreateShampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage);

        Toothpaste CreateToothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients);

        ShoppingCart ShoppingCart();
    }
}
