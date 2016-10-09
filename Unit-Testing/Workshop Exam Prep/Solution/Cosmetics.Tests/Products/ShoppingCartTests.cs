using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Contracts;
using Cosmetics.Tests.Mocks;
using Moq;
using NUnit.Framework;

namespace Cosmetics.Tests.Products
{
    [TestFixture]
    class ShoppingCartTests
    {
        [Test]
        public void TestAddProduct_ShouldAddCorrectly()
        {
            var mockedProduct = new Mock<IProduct>();
            var cart = new MockedShoppingCart();

            cart.AddProduct(mockedProduct.Object);

            Assert.IsTrue(cart.ContainsProduct(mockedProduct.Object));
        }

        [Test]
        public void TestRemoveProduct_ShouldRemoveCorrectly()
        {
            var mockedProduct = new Mock<IProduct>();
            var cart = new MockedShoppingCart();

            cart.AddProduct(mockedProduct.Object);
            cart.RemoveProduct(mockedProduct.Object);

            Assert.IsFalse(cart.ContainsProduct(mockedProduct.Object));
        }

        [Test]
        public void TestCointainsProduct_ShouldReturnTrue()
        {
            var mockedProduct = new Mock<IProduct>();
            var cart = new MockedShoppingCart();

            cart.AddProduct(mockedProduct.Object);

            Assert.IsTrue(cart.ContainsProduct(mockedProduct.Object));
        }

        [Test]
        public void TestTotalPrice_NoProductsInCart_ShouldReturnZero()
        {
            var cart = new MockedShoppingCart();
            decimal price = 0;
            Assert.AreEqual(cart.TotalPrice(), price);
        }

        [TestCase(5, 10)]
        [TestCase(14, 22)]
        public void TestTotalPrice_WithProductsInCart_ShouldCalculateCorrectly(decimal firstPrice, decimal secondPrice)
        {
            var cart = new MockedShoppingCart();
            var mockedProductOne=new Mock<IProduct>();
            var mockedProductTwo = new Mock<IProduct>();

            mockedProductOne.SetupGet(x => x.Price).Returns(firstPrice);
            mockedProductTwo.SetupGet(x => x.Price).Returns(secondPrice);

            cart.AddProduct(mockedProductOne.Object);
            cart.AddProduct(mockedProductTwo.Object);

            var result = firstPrice + secondPrice;

            Assert.AreEqual(cart.TotalPrice(), result);
        }
    }
}
