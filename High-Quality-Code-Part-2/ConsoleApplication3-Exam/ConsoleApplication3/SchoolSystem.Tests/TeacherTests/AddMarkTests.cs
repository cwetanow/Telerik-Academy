using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SchoolSystem.Common.Contracts;
using SchoolSystem.Common.Enumerations;
using SchoolSystem.Common.Models;

namespace SchoolSystem.Tests.TeacherTests
{
    [TestFixture]
    public class AddMarkTests
    {
        [Test]
        public void TestAddMark_ShouldCallStudentMethodCorrectly()
        {
            var mockedMark = new Mock<IMark>();

            var mockedStudent = new Mock<IStudent>();
            mockedStudent.SetupGet(x => x.Marks).Returns(It.IsAny<ICollection<IMark>>());

            var teacher = new Teacher("First", "Last", Subject.Bulgarian);

            teacher.AddMark(mockedStudent.Object, mockedMark.Object);

            mockedStudent.Verify(x => x.AddMark(mockedMark.Object), Times.Once);
        }
    }
}
