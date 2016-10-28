using System;
using System.Data.Entity;
using EF_Northwind;
using EF_Northwind.Concrete;
using Moq;
using NUnit.Framework;

namespace Northwind.Tests.CustomerRepositoryTests
{
    [TestFixture]
    class RemoveCustomerTests
    {
        [Test]
        public void TestRemoveCustomer_PassNull_ShouldThrowArgumentNullException()
        {
            var dbSetMock = new Mock<DbSet<Customer>>();

            var mockedContext = new Mock<NorthwindEntities>();
            mockedContext.SetupGet(x => x.Customers).Returns(dbSetMock.Object);

            var repository = new CustomerRepository(mockedContext.Object);

            Assert.Throws<ArgumentNullException>(() => repository.RemoveCustomer(null));
        }
        [Test]
        public void TestRemoveCustomer_PassValidCustomer_ShouldCalllContextCustomers()
        {
            var dbSetMock = new Mock<DbSet<Customer>>();

            var mockedContext = new Mock<NorthwindEntities>();
            mockedContext.SetupGet(x => x.Customers).Returns(dbSetMock.Object);

            var repository = new CustomerRepository(mockedContext.Object);

            var customer = new Mock<Customer>().Object;
            repository.RemoveCustomer(customer);

            mockedContext.Verify(x => x.Customers, Times.Once);
        }
    }
}
