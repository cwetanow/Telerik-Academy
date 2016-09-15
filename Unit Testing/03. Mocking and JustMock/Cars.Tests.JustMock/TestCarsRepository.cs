using Cars.Contracts;
using Cars.Data;
using Cars.Models;
using Cars.Tests.JustMock.Mocks;
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
        private static IList<Car> cars = new List<Car>() {
                (new Mock<Car>()).Object,
                (new Mock<Car>()).Object,
                (new Mock<Car>()).Object,
                (new Mock<Car>()).Object
            };


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
            var carRepo = new CarsRepository();
            var mockedCar = new Mock<Car>();
            var initialCount = carRepo.TotalCars;

            carRepo.Add(mockedCar.Object);
            carRepo.Remove(mockedCar.Object);
            var finalCount = carRepo.TotalCars;

            Assert.AreEqual(initialCount, finalCount);
        }

        [Test]
        public void TestCarsRepository_GetByIdInvalidParameter_ShouldThrowArgumentException()
        {
            var carRepo = new CarsRepository();

            Assert.Throws<ArgumentException>(() => carRepo.GetById(5));
        }

        [Test]
        public void TestCarsRepository_GetByIdValidParameter_ShouldReturnCar()
        {
            var carRepo = new CarsRepository();
            var car = new Car { Id = 1, Make = "Audi", Model = "A5", Year = 2005 };

            carRepo.Add(car);

            Assert.AreEqual(car, carRepo.GetById(car.Id));
        }

        [Test]
        public void TestCarsRepository_AllMethod_ShouldWorkCorrectly()
        {
            var carRepo = new CarsRepository();

            foreach (var car in cars)
            {
                carRepo.Add(car);
            }

            Assert.AreEqual(cars, carRepo.All());
        }

        [Test]
        public void TestCarsRepository_SortedByMake_ShouldWorkCorrectly()
        {
            var carRepo = new CarsRepository();

            foreach (var car in cars)
            {
                carRepo.Add(car);
            }

            Assert.AreEqual(cars.OrderBy(c => c.Make).ToList(), carRepo.SortedByMake());
        }

        [Test]
        public void TestCarsRepository_SortedByYear_ShouldWorkCorrectly()
        {
            var carRepo = new CarsRepository();

            foreach (var car in cars)
            {
                carRepo.Add(car);
            }

            Assert.AreEqual(cars.OrderBy(c => c.Year).ToList(), carRepo.SortedByYear());
        }

        [Test]
        public void TestCarsRepository_SearchMethodPassNull_ShouldReturnAllCars()
        {
            var carRepo = new CarsRepository();

            foreach (var car in cars)
            {
                carRepo.Add(car);
            }

            Assert.AreEqual(cars, carRepo.Search(null));
        }

        [Test]
        public void TestCarsRepository_SearchMethodPassEmpty_ShouldReturnAllCars()
        {
            var carRepo = new CarsRepository();

            foreach (var car in cars)
            {
                carRepo.Add(car);
            }

            Assert.AreEqual(cars, carRepo.Search(string.Empty));
        }

        [Test]
        public void TestCarsRepository_SearchMethodPassValidCars_ShouldReturnAllCars()
        {
            var carRepo = new CarsRepository();
            var make = "Audi";
            List<Car> result;

            cars[0].Make = make;
            foreach (var car in cars)
            {
                carRepo.Add(car);
            }
            result = cars.Where(c => c.Make == make || c.Model == make).ToList();

            Assert.AreEqual(result, carRepo.Search(make));
        }
    }
}
