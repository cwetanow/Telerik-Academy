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

            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo("example", brand,  10.0M, GenderType.Men, 100, UsageType.EveryDay));
        }

        [TestCase("Too long name for shampoo,must be smaller")]
        public void TestCreateShampoo_PassLongerBrand_ShouldTHrowIndexOutOfRange(string brand)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo("example", brand,  10.0M, GenderType.Men, 100, UsageType.EveryDay));
        }
    }
}
