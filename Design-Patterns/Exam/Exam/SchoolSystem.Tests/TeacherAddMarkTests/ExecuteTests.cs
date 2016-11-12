using Moq;
using NUnit.Framework;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Services;

namespace SchoolSystem.Tests.TeacherAddMarkTests
{
    [TestFixture]
    public class ExecuteTests
    {
        [Test]
        public void TestExecute_PassValidParameters_ShouldCallServiceGetStudentCorrectly()
        {
            var parameters = new string[] { "0", " 0", " 2" };

            var mockedTeacher = new Mock<ITeacher>();
            mockedTeacher.Setup(t => t.FirstName).Returns("pesho");
            mockedTeacher.Setup(t => t.LastName).Returns("pesho");
            mockedTeacher.Setup(m => m.Subject).Returns(It.IsAny<Subject>());

            var mockedStudent = new Mock<IStudent>();
            mockedStudent.Setup(t => t.FirstName).Returns("pesho");
            mockedStudent.Setup(t => t.LastName).Returns("pesho");

            var mockedMark = new Mock<IMark>();
            mockedMark.Setup(m => m.Value).Returns(float.Parse(parameters[2]));
            mockedMark.Setup(m => m.Subject).Returns(It.IsAny<Subject>());

            var mockedFactory = new Mock<IMarkFactory>();
            mockedFactory.Setup(f => f.CreateMark(It.IsAny<Subject>(), It.IsAny<float>())).Returns(mockedMark.Object);

            var mockedService = new Mock<ISchoolService>();
            mockedService.Setup(s => s.GetStudentById(It.IsAny<int>())).Returns(mockedStudent.Object);
            mockedService.Setup(s => s.GetTeacherById(It.IsAny<int>())).Returns(mockedTeacher.Object);

            var command = new TeacherAddMarkCommand(mockedFactory.Object, mockedService.Object);

            command.Execute(parameters);

            mockedService.Verify(s => s.GetStudentById(int.Parse(parameters[1])));
        }

        [Test]
        public void TestExecute_PassValidParameters_ShouldCallServiceGetTeacherCorrectly()
        {
            var parameters = new string[] { "0", " 0", " 2" };

            var mockedTeacher = new Mock<ITeacher>();
            mockedTeacher.Setup(t => t.FirstName).Returns("pesho");
            mockedTeacher.Setup(t => t.LastName).Returns("pesho");
            mockedTeacher.Setup(m => m.Subject).Returns(It.IsAny<Subject>());

            var mockedStudent = new Mock<IStudent>();
            mockedStudent.Setup(t => t.FirstName).Returns("pesho");
            mockedStudent.Setup(t => t.LastName).Returns("pesho");

            var mockedMark = new Mock<IMark>();
            mockedMark.Setup(m => m.Value).Returns(float.Parse(parameters[2]));
            mockedMark.Setup(m => m.Subject).Returns(It.IsAny<Subject>());

            var mockedFactory = new Mock<IMarkFactory>();
            mockedFactory.Setup(f => f.CreateMark(It.IsAny<Subject>(), It.IsAny<float>())).Returns(mockedMark.Object);

            var mockedService = new Mock<ISchoolService>();
            mockedService.Setup(s => s.GetStudentById(It.IsAny<int>())).Returns(mockedStudent.Object);
            mockedService.Setup(s => s.GetTeacherById(It.IsAny<int>())).Returns(mockedTeacher.Object);

            var command = new TeacherAddMarkCommand(mockedFactory.Object, mockedService.Object);

            command.Execute(parameters);

            mockedService.Verify(s => s.GetTeacherById(int.Parse(parameters[0])));
        }

        [Test]
        public void TestExecute_PassValidParameters_ShouldCallFactoryCreateMarkCorrectly()
        {
            var parameters = new string[] { "0", " 0", " 2" };

            var mockedTeacher = new Mock<ITeacher>();
            mockedTeacher.Setup(t => t.FirstName).Returns("pesho");
            mockedTeacher.Setup(t => t.LastName).Returns("pesho");
            mockedTeacher.Setup(m => m.Subject).Returns(It.IsAny<Subject>());

            var mockedStudent = new Mock<IStudent>();
            mockedStudent.Setup(t => t.FirstName).Returns("pesho");
            mockedStudent.Setup(t => t.LastName).Returns("pesho");

            var mockedMark = new Mock<IMark>();
            mockedMark.Setup(m => m.Value).Returns(float.Parse(parameters[2]));
            mockedMark.Setup(m => m.Subject).Returns(It.IsAny<Subject>());

            var mockedFactory = new Mock<IMarkFactory>();
            mockedFactory.Setup(f => f.CreateMark(It.IsAny<Subject>(), It.IsAny<float>())).Returns(mockedMark.Object);

            var mockedService = new Mock<ISchoolService>();
            mockedService.Setup(s => s.GetStudentById(It.IsAny<int>())).Returns(mockedStudent.Object);
            mockedService.Setup(s => s.GetTeacherById(It.IsAny<int>())).Returns(mockedTeacher.Object);

            var command = new TeacherAddMarkCommand(mockedFactory.Object, mockedService.Object);

            command.Execute(parameters);

            mockedFactory.Verify(s => s.CreateMark(mockedMark.Object.Subject, mockedMark.Object.Value));
        }
    }
}
