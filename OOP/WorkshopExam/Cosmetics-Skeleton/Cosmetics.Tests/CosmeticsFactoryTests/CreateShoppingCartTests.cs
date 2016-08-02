using Cosmetics.Engine;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Tests.CosmeticsFactoryTests
{
    [TestFixture]
    public class CreateShoppingCartTests
    {
        private static CosmeticsFactory factory = new CosmeticsFactory();

        [Test]
        public void CreateShoppingCart_ShouldInitialiseCorrectly()
        {
            var shoppingCart = factory.ShoppingCart();

            Assert.AreEqual("ShoppingCart", shoppingCart.GetType().Name);
        }
    }
}
