using Moq;
using NUnit.Framework;
using SchoolSystem.Common.Contracts;
using SchoolSystem.Common.Enumerations;
using SchoolSystem.Common.Models;

namespace SchoolSystem.Tests.StudentTests
{
    [TestFixture]
    class ListMarksTests
    {
        [Test]
        public void TestListMarks_EmptyMarksList_ShouldReturnCorrectString()
        {
            var student = new Student("Gosho", "Peshev", Grade.Ninth);

            var actual = student.ListMarks();
            var expected = "The student has no marks.\r\n";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestListMarks_ShourdReturnCorrectString()
        {
            var mockedMark = new Mock<IMark>();
            mockedMark.Setup(x => x.Subject).Returns(It.IsAny<Subject>());
            mockedMark.Setup(x => x.Value).Returns(It.IsAny<float>());

            var student = new Student("Gosho", "Peshev", Grade.Ninth);

            student.AddMark(mockedMark.Object);

            var result = student.ListMarks();

            Assert.IsTrue(result.Contains("The student has these marks:"));
        }
    }
}
