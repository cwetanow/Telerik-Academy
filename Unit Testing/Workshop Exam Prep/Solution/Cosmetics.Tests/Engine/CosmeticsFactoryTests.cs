using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmetics.Common;
using Cosmetics.Engine;
using NUnit.Framework;

namespace Cosmetics.Tests.Engine
{
    [TestFixture]
    class CosmeticsFactoryTests
    {
        [TestCase("")]
        [TestCase(null)]
        public void TestCreateShampoo_PassInvalidName_ShouldTHrowNullReferenceException(string name)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo(name, "example", 10.0M, GenderType.Men, 100, UsageType.EveryDay));
        }

        [TestCase("Too long name for shampoo,must be smaller")]
        public void TestCreateShampoo_PassLongerName_ShouldTHrowIndexOutOfRange(string name)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo(name, "example", 10.0M, GenderType.Men, 100, UsageType.EveryDay));
        }

        [TestCase("")]
        [TestCase(null)]
        public void TestCreateShampoo_PassInvalidBrand_ShouldTHrowNullReferenceException(string brand)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo("example", brand, 10.0M, GenderType.Men, 100, UsageType.EveryDay));
        }

        [TestCase("Too long name for shampoo,must be smaller")]
        public void TestCreateShampoo_PassLongerBrand_ShouldTHrowIndexOutOfRange(string brand)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo("example", brand, 10.0M, GenderType.Men, 100, UsageType.EveryDay));
        }

        [TestCase("name", "brand")]
        public void TestCreateShampoo_PassValidParameters_ShouldCreateShampoo(string name, string brand)
        {
            var factory = new CosmeticsFactory();
            var shampoo = factory.CreateShampoo(name, brand, 10.0M, GenderType.Men, 100, UsageType.EveryDay);

            Assert.IsNotNull(shampoo);
            Assert.IsTrue(shampoo.Name == name);
            Assert.IsTrue(shampoo.Brand == brand);
        }

        [TestCase("")]
        [TestCase(null)]
        public void TestCreateCategory_PassInvalidName_ShouldTHrowIndexOutOfRange(string name)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateCategory(name));
        }

        [TestCase("Too long name for shampoo,must be smaller")]
        public void TestCreateCategory_PassLongerName_ShouldTHrowIndexOutOfRange(string name)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateCategory(name));
        }

        [TestCase("name")]
        public void TestCreateCategory_PassValidParameters_ShouldCreateCategory(string name)
        {
            var factory = new CosmeticsFactory();
            var category = factory.CreateCategory(name);

            Assert.IsNotNull(category);
            Assert.IsTrue(category.Name == name);
            Assert.IsTrue(category.GetType().Name == "Category");
        }

        [TestCase("")]
        [TestCase(null)]
        public void TestCreateToothpaste_PassInvalidName_ShouldTHrowNullReferenceException(string name)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateToothpaste(name, "example", 10M, GenderType.Unisex, new List<string>() { "Zele", "Chesun" }));
        }

        [TestCase("Too long name for shampoo,must be smaller")]
        public void TestCreateToothpaste_PassLongerName_ShouldTHrowIndexOutOfRange(string name)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste(name, "example", 10M, GenderType.Unisex, new List<string>() { "Zele", "Chesun" }));
        }

        [TestCase("")]
        [TestCase(null)]
        public void TestCreateToothpaste_PassInvalidBrand_ShouldTHrowNullReferenceException(string brand)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateToothpaste("example", brand, 10M, GenderType.Unisex, new List<string>() { "Zele", "Chesun" }));
        }

        [TestCase("Too long name for Toothpaste,must be smaller")]
        public void TestCreateSToothpaste_PassLongerBrand_ShouldTHrowIndexOutOfRange(string brand)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste("example", brand, 10M, GenderType.Unisex, new List<string>() { "Zele", "Chesun" }));
        }

        [TestCase("name", "brand")]
        public void TestCreateToothpaste_PassValidParameters_ShouldCreateToothpaste(string name, string brand)
        {
            var factory = new CosmeticsFactory();
            var paste = factory.CreateToothpaste(name, brand, 10M, GenderType.Unisex, new List<string>() { "Zele", "Chesun" });

            Assert.IsNotNull(paste);
            Assert.IsTrue(paste.Name == name);
            Assert.IsTrue(paste.Brand == brand);
        }

        [TestCase("too long description for this sustavka")]
        public void TestCreateToothpaste_PassLongerCOmponents_ShouldThrowINdexOutOfRange(string description)
        {
            var factory = new CosmeticsFactory();
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste("name", "brand", 10M, GenderType.Unisex, new List<string>() { description, "Chesun" }));

        }

        [Test]
        public void TestCreateShoppingCart_ShouldInitialiseCorrectly()
        {
            var factory=new CosmeticsFactory();
            var cart = factory.CreateShoppingCart();

            Assert.IsNotNull(cart);
            Assert.IsTrue(cart.GetType().Name == "ShoppingCart");
        }
    }
}
