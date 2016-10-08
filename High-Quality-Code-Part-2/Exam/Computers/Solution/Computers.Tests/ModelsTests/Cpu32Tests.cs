using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Computers.Common.Contracts;
using Computers.Common.Models.Cpus;
using Computers.Common.Utils;
using Moq;
using NUnit.Framework;

namespace Computers.Tests.ModelsTests
{
    [TestFixture]
    class Cpu32Tests
    {
        [TestCase(-1)]
        [TestCase(-123)]
        [TestCase(-1432)]
        public void TestSquareNumber_PassLowerNumber_ShouldReturnCorrectString(int number)
        {
            var mockedMotherboard = new Mock<IMotherboard>();

            var cpu = new Cpu32(8);

            cpu.AttachToMotherboard(mockedMotherboard.Object);

            mockedMotherboard.Setup(x => x.LoadRamValue()).Returns(number);

            cpu.SquareNumber();

            mockedMotherboard.Verify(x => x.DrawOnVideoCard(GlobalConstants.NumberTooLowMessage), Times.Once);
        }

        [TestCase(1000)]
        [TestCase(6123)]
        [TestCase(1432)]
        public void TestSquareNumber_PassHigherNumber_ShouldReturnCorrectString(int number)
        {
            var mockedMotherboard = new Mock<IMotherboard>();

            var cpu = new Cpu32(8);

            cpu.AttachToMotherboard(mockedMotherboard.Object);

            mockedMotherboard.Setup(x => x.LoadRamValue()).Returns(number);

            cpu.SquareNumber();

            mockedMotherboard.Verify(x => x.DrawOnVideoCard(GlobalConstants.NumberTooHighMessage), Times.Once);
        }

        [TestCase(100)]
        [TestCase(212)]
        [TestCase(14)]
        public void TestSquareNumber_PassCorrectNumber_ShouldReturnCorrectString(int number)
        {
            var mockedMotherboard = new Mock<IMotherboard>();

            var cpu = new Cpu32(8);

            cpu.AttachToMotherboard(mockedMotherboard.Object);

            mockedMotherboard.Setup(x => x.LoadRamValue()).Returns(number);

            var expectedString = $"Square of {number} is {number * number}.";

            cpu.SquareNumber();

            mockedMotherboard.Verify(x => x.DrawOnVideoCard(expectedString), Times.Once);
        }

        [TestCase(100, 2022)]
        [TestCase(11, 212)]
        [TestCase(14, 15)]
        public void TestGenerateRandom_ShouldCallSaveToRam(int lower, int higher)
        {
            var mockedMotherboard = new Mock<IMotherboard>();

            var cpu = new Cpu32(8);

            cpu.AttachToMotherboard(mockedMotherboard.Object);

            cpu.GenerateRandom(lower, higher);

            mockedMotherboard.Verify(x => x.SaveRamValue(It.IsAny<int>()), Times.Once);
        }
    }
}
