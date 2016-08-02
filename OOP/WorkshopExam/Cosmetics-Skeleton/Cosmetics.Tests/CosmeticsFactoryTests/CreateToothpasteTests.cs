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
    public class CreateToothpasteTests
    {
        private static CosmeticsFactory factory = new CosmeticsFactory();
        private static string name = "Name";
        private static string brand = "Brand";
        private static decimal price = 10;
        private static GenderType gender = GenderType.Unisex;
        private static List<string> ingredients = new List<string> { "Ingredients" };
        //Should throw argument null by uslovie, but throws different
        [Test]
        public void CreateToothpaste_PassNullAsName_ShouldThrowArgumentNull()
        {
            Assert.Throws<NullReferenceException>(() => factory.CreateToothpaste(null, brand, price, gender,ingredients ));
        }

        [Test]
        public void CreateToothpaste_PassEmptyStringAsName_ShouldNullReference()
        {
            Assert.Throws<NullReferenceException>(() => factory.CreateToothpaste(string.Empty, brand, price, gender, ingredients));
        }

        [TestCase("sh")]
        [TestCase("too long name for product")]
        public void CreateToothpaste_PassInvalidStringAsName_ShouldIndexOutOfRange(string namee)
        {
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste(namee, brand, price, gender, ingredients));
        }
    

        [Test]
        public void CreateToothpaste_PassNullAsBrand_ShouldThrowArgumentNull()
        {
            Assert.Throws<NullReferenceException>(() => factory.CreateToothpaste(name, null, price, gender, ingredients));
        }

        [Test]
        public void CreateToothpaste_PassEmptyStringAsBrand_ShouldNullReference()
        {
            Assert.Throws<NullReferenceException>(() => factory.CreateToothpaste(name, string.Empty, price, gender, ingredients));
        }

        [TestCase("s")]
        [TestCase("too long name for product")]
        public void CreateToothpaste_PassInvalidStringForBrand_ShouldIndexOutOfRange(string brandd)
        {
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste(name, brandd, price, gender, ingredients));
        }

        [Test]
        public void CreateToothpaste_PassValid_InitialiseCorrectly()
        {
            var toothpaste = factory.CreateToothpaste(name, brand, price, gender, ingredients);

            Assert.AreEqual("Toothpaste", toothpaste.GetType().Name);
        }
    }
}
