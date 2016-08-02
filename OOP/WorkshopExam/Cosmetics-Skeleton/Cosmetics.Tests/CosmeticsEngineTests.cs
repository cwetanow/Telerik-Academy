using Cosmetics.Cart;
using Cosmetics.Contracts;
using Cosmetics.Engine;
using Cosmetics.Engine.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Tests
{
    [TestFixture]
    public class CosmeticsEngineTests
    {
        [TestCase("Test   ")]
        public void TestStart_PassInvalidCommand_ShouldThrowArgumentNull(string commandText)
        {
            var factory = new Mock<CosmeticsFactory>();
            var cart = new Mock<ShoppingCart>();
            var cosmeticsEngine = new CosmeticsEngine(factory.Object, cart.Object);

            Console.SetIn(new StringReader(commandText));

            Assert.Throws<ArgumentNullException>(() => cosmeticsEngine.Start());
        }

        [Test]
        public void TestStart_CreateCategory_ShouldCallCreateCategoryFromFactory()
        {
            var factory = new Mock<ICosmeticsFactory>();
            var cart = new Mock<IShoppingCart>();
            var cosmeticsEngine = new CosmeticsEngine(factory.Object, cart.Object);

            Console.SetIn(new StringReader("CreateCategory Category"));
            factory.Setup(x => x.CreateCategory(It.IsAny<string>())).Returns(It.IsAny<Category>());
            cosmeticsEngine.Start();

            factory.Verify(x => x.CreateCategory(It.IsAny<string>()), Times.Once);
        }
    }
}
