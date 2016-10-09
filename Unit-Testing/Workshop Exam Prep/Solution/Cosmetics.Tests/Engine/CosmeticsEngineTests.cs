using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using NUnit.Framework;
using Cosmetics.Contracts;
using Cosmetics.Engine;
using Cosmetics.Tests.Mocks;
using Moq;

namespace Cosmetics.Tests.Engine
{
    [TestFixture]
    public class CosmeticsEngineTests
    {
        [TestCase("ForMale")]
        public void TestStart_PassValidCreateCategory_ShouldCreateCategory(string categoryName)
        {
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedCommand = new Mock<ICommand>();
            var mockedCategory = new Mock<ICategory>();

            mockedCommand.SetupGet(x => x.Name).Returns("CreateCategory");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { categoryName });
            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            mockedCategory.SetupGet(x => x.Name).Returns(categoryName);
            mockedFactory.Setup(x => x.CreateCategory(categoryName)).Returns(mockedCategory.Object);

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);

            engine.Start();

            Assert.IsTrue(engine.Categories.ContainsKey(categoryName));
            Assert.AreSame(mockedCategory.Object, engine.Categories[categoryName]);
        }

        [TestCase("ForMale,", "White+")]
        public void TestStart_PassValidAddToCategory_ShouldAddToCategory(string categoryName, string productName)
        {
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedCommand = new Mock<ICommand>();
            var mockedShampoo = new Mock<IShampoo>();
            var mockedCategory = new Mock<ICategory>();

            mockedCommand.SetupGet(x => x.Name).Returns("AddToCategory");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { categoryName, productName });
            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);
            engine.Categories.Add(categoryName, mockedCategory.Object);
            engine.Products.Add(productName, mockedShampoo.Object);

            engine.Start();

            mockedCategory.Verify(x => x.AddProduct(mockedShampoo.Object), Times.Once);
        }

        [TestCase("ForMale,", "White+")]
        public void TestStart_PassValidRemoveFromCategory_ShouldRemoveFromCategory(string categoryName, string productName)
        {
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedCommand = new Mock<ICommand>();
            var mockedShampoo = new Mock<IShampoo>();
            var mockedCategory = new Mock<ICategory>();

            mockedCommand.SetupGet(x => x.Name).Returns("RemoveFromCategory");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { categoryName, productName });
            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);
            engine.Categories.Add(categoryName, mockedCategory.Object);
            engine.Products.Add(productName, mockedShampoo.Object);

            engine.Start();

            mockedCategory.Verify(x => x.RemoveProduct(mockedShampoo.Object), Times.Once);
        }

        [TestCase("ForMale,", "White+")]
        public void TestStart_PassValidShowCategory_ShouldCallPrint(string categoryName, string productName)
        {
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedCommand = new Mock<ICommand>();
            var mockedShampoo = new Mock<IShampoo>();
            var mockedCategory = new Mock<ICategory>();

            mockedCommand.SetupGet(x => x.Name).Returns("ShowCategory");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { categoryName, productName });
            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);
            engine.Categories.Add(categoryName, mockedCategory.Object);
            engine.Products.Add(productName, mockedShampoo.Object);

            engine.Start();

            mockedCategory.Verify(x => x.Print(), Times.Once);
        }

        [TestCase("Cool", "Nivea")]
        public void TestStart_PassValidCreateShampoo_ShouldCreateSHampoo(string name, string brand)
        {
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedCommand = new Mock<ICommand>();
            var mockedShampoo = new Mock<IShampoo>();

            mockedCommand.SetupGet(x => x.Name).Returns("CreateShampoo");
            mockedCommand
                .SetupGet(x => x.Parameters).Returns(new List<string>() { name, brand, "0.50", "men", "500", "everyday" });
            mockedCommandParser
                .Setup(x => x.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            mockedFactory
                .Setup(x => x.CreateShampoo(name, brand, 0.50M, GenderType.Men, 500, UsageType.EveryDay))
                .Returns(mockedShampoo.Object);

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);

            engine.Start();

            Assert.IsTrue(engine.Products.ContainsKey(name));
            Assert.AreSame(mockedShampoo.Object, engine.Products[name]);
        }

        [TestCase("White+", "Colgate")]
        public void TestStart_PassValidCreateToothpaste_ShouldCreateToothpaste(string name, string brand)
        {
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedCommand = new Mock<ICommand>();
            var mockedToothpaste = new Mock<IToothpaste>();

            mockedCommand.SetupGet(x => x.Name).Returns("CreateToothpaste");
            mockedCommand
                .SetupGet(x => x.Parameters).Returns(new List<string>() { name, brand, "15.50", "men", "fluor,bqla,golqma" });
            mockedCommandParser
                .Setup(x => x.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            mockedFactory
                .Setup(x => x.CreateToothpaste(name, brand, 15.50M, GenderType.Men, new List<string>() { "fluor", "bqla", "golqma" }))
                .Returns(mockedToothpaste.Object);

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);

            engine.Start();

            Assert.IsTrue(engine.Products.ContainsKey(name));
            Assert.AreSame(mockedToothpaste.Object, engine.Products[name]);
        }

        [TestCase("Colgate")]
        public void TestStart_PassValidAddToShoppingCart_ShouldAddToCart(string name)
        {
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedCommand = new Mock<ICommand>();
            var mockedProduct = new Mock<IProduct>();

            mockedCommand.SetupGet(x => x.Name).Returns("AddToShoppingCart");
            mockedCommand
                .SetupGet(x => x.Parameters).Returns(new List<string>() { name });
            mockedCommandParser
                .Setup(x => x.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);
            engine.Products.Add(name, mockedProduct.Object);

            engine.Start();

            mockedShoppingCart.Verify(x => x.AddProduct(mockedProduct.Object), Times.Once);
        }

        [TestCase("Colgate")]
        public void TestStart_PassValidRemoveFromShoppingCart_ShouldRemoveFromCart(string name)
        {
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedCommand = new Mock<ICommand>();
            var mockedProduct = new Mock<IProduct>();

            mockedCommand.SetupGet(x => x.Name).Returns("RemoveFromShoppingCart");
            mockedCommand
                .SetupGet(x => x.Parameters).Returns(new List<string>() { name });
            mockedCommandParser
                .Setup(x => x.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            mockedShoppingCart.Setup(x => x.ContainsProduct(mockedProduct.Object)).Returns(true);

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);
            engine.Products.Add(name, mockedProduct.Object);
            engine.Start();

            mockedShoppingCart.Verify(x => x.RemoveProduct(mockedProduct.Object), Times.Once);
        }
    }
}
