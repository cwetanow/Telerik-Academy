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
    class CategoryTests
    {
        [Test]
        public void TestAddProduct_ShouldAddCorrectly()
        {
            var mockedProduct = new Mock<IProduct>();
            var category = new MockedCategory();

            category.AddProduct(mockedProduct.Object);

            Assert.IsTrue(category.Products.Contains(mockedProduct.Object));
        }

        [Test]
        public void TestAddProduct_ShouldRemoveCorrectly()
        {
            var mockedProduct = new Mock<IProduct>();
            var category = new MockedCategory();

            category.AddProduct(mockedProduct.Object);
            category.RemoveProduct(mockedProduct.Object);

            Assert.IsFalse(category.Products.Contains(mockedProduct.Object));
        }
    }
}
