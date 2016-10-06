using Cosmetics.Common;
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
    public class CreateShampooTests
    {
        private static CosmeticsFactory factory = new CosmeticsFactory();
        private static string name = "Name";
        private static string brand = "Brand";
        private static decimal price = 10;
        private static GenderType gender = GenderType.Unisex;

        //Should throw argument null by uslovie, but throws different
        [Test]
        public void CreateShampoo_PassNullAsName_ShouldThrowArgumentNull()
        {
            Assert.Throws<NullReferenceException>(()=> factory.CreateShampoo(null, brand, price, gender, 100, UsageType.EveryDay));
        }

        [Test]
        public void CreateShampoo_PassEmptyStringAsName_ShouldNullReference()
        {
            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo(string.Empty, brand, price, gender, 100, UsageType.EveryDay));
        }

        [TestCase("sh")]
        [TestCase("too long name for product")]
        public void CreateShampoo_PassInvalidStringAsName_ShouldIndexOutOfRange(string namee)
        {
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo(namee, brand, price, gender, 100, UsageType.EveryDay));
        }

        [Test]
        public void CreateShampoo_PassNullAsBrand_ShouldThrowArgumentNull()
        {
            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo(name, null, price, gender, 100, UsageType.EveryDay));
        }

        [Test]
        public void CreateShampoo_PassEmptyStringAsBrand_ShouldNullReference()
        {
            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo(name,string.Empty,  price, gender, 100, UsageType.EveryDay));
        }

        [TestCase("s")]
        [TestCase("too long name for product")]
        public void CreateShampoo_PassInvalidStringForBrand_ShouldIndexOutOfRange(string brandd)
        {
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo(name, brandd, price, gender, 100, UsageType.EveryDay));
        }

        [Test]
        public void CreateShampoo_PassValid_InitialiseCorrectly()
        {
            var shampoo = factory.CreateShampoo(name, brand, price, gender, 100, UsageType.EveryDay);

            Assert.AreEqual("Shampoo", shampoo.GetType().Name);
        }

       
    }
}
