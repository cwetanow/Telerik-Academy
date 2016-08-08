using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Assert.AreSame(mockedCategory.Object,engine.Categories[categoryName]);
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
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() {categoryName,productName});
            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(() => new List<ICommand>() {mockedCommand.Object});

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);
            engine.Categories.Add(categoryName,mockedCategory.Object);
            engine.Products.Add(productName, mockedShampoo.Object);

            engine.Start();

            mockedCategory.Verify(x=>x.AddProduct(mockedShampoo.Object),Times.Once);
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
    }
}
