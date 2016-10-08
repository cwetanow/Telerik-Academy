using System;
using Moq;
using NUnit.Framework;
using SchoolSystem.Common.Contracts;
using SchoolSystem.Common.Enumerations;
using SchoolSystem.Common.Models;

namespace SchoolSystem.Tests.StudentTests
{
    [TestFixture]
    class AddMarkTests
    {
        [Test]
        public void TestAddMark_ShouldAddCorrectly()
        {
            var mockedMark = new Mock<IMark>();
            mockedMark.Setup(x => x.Subject).Returns(It.IsAny<Subject>());
            mockedMark.Setup(x => x.Value).Returns(It.IsAny<float>());

            var student = new Student("Gosho", "Peshev", Grade.Ninth);

            student.AddMark(mockedMark.Object);

            var result = student.Marks.Count;

            Assert.AreEqual(1, result);
        }

        [Test]
        public void TestAddMark_AddMoreThan20_ShouldThrowArgumentOutOfRangeException()
        {
            var mockedMark = new Mock<IMark>();
            mockedMark.Setup(x => x.Subject).Returns(It.IsAny<Subject>());
            mockedMark.Setup(x => x.Value).Returns(It.IsAny<float>());

            var student = new Student("Gosho", "Peshev", Grade.Ninth);
            
            student.AddMark(mockedMark.Object);
            student.AddMark(mockedMark.Object);
            student.AddMark(mockedMark.Object);
            student.AddMark(mockedMark.Object);
            student.AddMark(mockedMark.Object);
            student.AddMark(mockedMark.Object);
            student.AddMark(mockedMark.Object);
            student.AddMark(mockedMark.Object);
            student.AddMark(mockedMark.Object);
            student.AddMark(mockedMark.Object);
            student.AddMark(mockedMark.Object);
            student.AddMark(mockedMark.Object);
            student.AddMark(mockedMark.Object);
            student.AddMark(mockedMark.Object);
            student.AddMark(mockedMark.Object);
            student.AddMark(mockedMark.Object);
            student.AddMark(mockedMark.Object);
            student.AddMark(mockedMark.Object);
            student.AddMark(mockedMark.Object);
            student.AddMark(mockedMark.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => student.AddMark(mockedMark.Object));
        }
    }
}
