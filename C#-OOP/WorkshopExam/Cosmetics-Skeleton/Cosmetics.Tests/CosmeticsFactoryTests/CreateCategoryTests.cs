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
    public class CreateCategoryTests
    {
        private static CosmeticsFactory factory = new CosmeticsFactory();

        [Test]
        public void TestCreateCategory_PassNullForName_ShouldThrowNullReference()
        {
            Assert.Throws<NullReferenceException>(()=>factory.CreateCategory(null));
        }

        [Test]
        public void TestCreateCategory_PassStringEmptyForName_ShouldThrowNullReference()
        {
            Assert.Throws<NullReferenceException>(() => factory.CreateCategory(string.Empty));
        }

        [TestCase("a")]
        [TestCase("a very much long name for category")]
        public void TestCreateCategory_PassStringEmptyForName_ShouldThrowIndexOutOfRange(string name)
        {
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateCategory(name));
        }


        [TestCase("First Name")]
        [TestCase("Second Name")]
        public void TestCreateCategory_PassValidName_ShouldInitialiseCorrectly(string name)
        {
            var category = factory.CreateCategory(name);

            Assert.AreEqual("Category", category.GetType().Name);
        }
    }
}
