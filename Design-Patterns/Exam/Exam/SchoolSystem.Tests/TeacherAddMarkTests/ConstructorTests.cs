using System;
using Moq;
using NUnit.Framework;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Services;

namespace SchoolSystem.Tests.TeacherAddMarkTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassNullAsFactory_ShouldThrowArgumentNullException()
        {
            var mockedService = new Mock<ISchoolService>();

            Assert.Throws<ArgumentNullException>(() => new TeacherAddMarkCommand(null, mockedService.Object));
        }

        [Test]
        public void TestConstructor_PassNullAsService_ShouldThrowArgumentNullException()
        {
            var mockedFactory = new Mock<IMarkFactory>();

            Assert.Throws<ArgumentNullException>(() => new TeacherAddMarkCommand(mockedFactory.Object, null));
        }
    }
}
