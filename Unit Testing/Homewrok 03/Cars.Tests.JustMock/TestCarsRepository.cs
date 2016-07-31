using Cars.Contracts;
using Cars.Data;
using Cars.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Tests.JustMock
{
    [TestFixture]
    public class TetCarsRepository
    {
        private static CarsRepository testCars;

        private void InitialiseAndPopulateTestCars()
        {
            var FakeCarCollection = new List<Car>
            {
                new Car { Id = 1, Make = "Audi", Model = "A5", Year = 2005 },
                new Car { Id = 2, Make = "BMW", Model = "325i", Year = 2008 },
                new Car { Id = 3, Make = "BMW", Model = "330d", Year = 2007 },
                new Car { Id = 4, Make = "Opel", Model = "Astra", Year = 2010 },
            };
            testCars = new CarsRepository();
            for (int i = 0; i < 4; i++)
            {
                testCars.Add(FakeCarCollection[i]);
            }
        }
        [Test]
        public void TestCarsRepository_CheckParameterlessConstructor_ShouldInitialiseCorrectly()
        {
            var carRepo = new CarsRepository();
            Assert.IsNotNull(carRepo);
        }

        [Test]
        public void TestCarsRepository_CheckConstructorWithMockedDB_ShouldInitialiseCorrectly()
        {
            var mockedDataBase = new Mock<Database>();
            var carRepo = new CarsRepository(mockedDataBase.Object);
            Assert.IsNotNull(carRepo);
        }

        [Test]
        public void TestCarsRepository_AddMethodWhenPassNull_ShouldThrowArgumentException()
        {
            var carRepo = new CarsRepository();
            Assert.Throws<ArgumentException>(() => carRepo.Add(null));
        }

        [Test]
        public void TestCarsRepository_AddMethodWhenPassCarr_ShouldAddCorrectly()
        {
            // Database did not initialise the list, solved it with a database constructor
            var carRepo = new CarsRepository();
            var mockedCar = new Mock<Car>();
            var initialCount = carRepo.TotalCars;
            carRepo.Add(mockedCar.Object);
            var finalCount = carRepo.TotalCars;
            Assert.AreEqual(initialCount + 1, finalCount);
        }

        [Test]
        public void TestCarsRepository_RemoveMethodWhenPassNull_ShouldThrowArgumentException()
        {
            var carRepo = new CarsRepository();
            Assert.Throws<ArgumentException>(() => carRepo.Remove(null));
        }

        [Test]
        public void TestCarsRepository_RemoveMethodWhenPassCarr_ShouldRemoveCorrectly()
        {
            // Database did not initialise the list, solved it with a database constructor
            var carRepo = new CarsRepository();
            var mockedCar = new Mock<Car>();
            var initialCount = carRepo.TotalCars;
            carRepo.Add(mockedCar.Object);
            carRepo.Remove(mockedCar.Object);
            var finalCount = carRepo.TotalCars;
            Assert.AreEqual(initialCount, finalCount);
        }

    }
}
