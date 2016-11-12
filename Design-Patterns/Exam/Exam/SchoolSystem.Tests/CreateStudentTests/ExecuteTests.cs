using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Services;

namespace SchoolSystem.Tests.CreateStudentTests
{
    [TestFixture]
    class ExecuteTests
    {
        [Test]
        public void TestExecute_PassValidParameters_ShouldCallFactoryCreateStudentCorrectly()
        {
            var parameters = new string[] { "Pesho", " Peshev", "11" };

            var mockedStudent = new Mock<IStudent>();
            mockedStudent.Setup(t => t.FirstName).Returns(parameters[0]);
            mockedStudent.Setup(t => t.LastName).Returns(parameters[1]);
            mockedStudent.Setup(x => x.Grade).Returns((Grade)int.Parse(parameters[2]));

            var mockedFactory = new Mock<IStudentFactory>();
            mockedFactory.Setup(x => x.CreateStudent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Grade>()))
                .Returns(mockedStudent.Object);

            var mockedService = new Mock<ISchoolService>();
            mockedService.Setup(s => s.AddStudent(It.IsAny<IStudent>())).Returns(1);

            var command = new CreateStudentCommand(mockedFactory.Object, mockedService.Object);

            command.Execute(parameters);

            mockedFactory.Verify(x => x.CreateStudent(parameters[0], parameters[1], (Grade)int.Parse(parameters[2])),
                Times.Once);
        }

        [Test]
        public void TestExecute_PassValidParameters_ShouldCallServiceAddStudentCorrectly()
        {
            var parameters = new string[] { "Pesho", " Peshev", "11" };

            var mockedStudent = new Mock<IStudent>();
            mockedStudent.Setup(t => t.FirstName).Returns(parameters[0]);
            mockedStudent.Setup(t => t.LastName).Returns(parameters[1]);
            mockedStudent.Setup(x => x.Grade).Returns((Grade)int.Parse(parameters[2]));

            var mockedFactory = new Mock<IStudentFactory>();
            mockedFactory.Setup(x => x.CreateStudent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Grade>()))
                .Returns(mockedStudent.Object);

            var mockedService = new Mock<ISchoolService>();
            mockedService.Setup(s => s.AddStudent(It.IsAny<IStudent>())).Returns(1);

            var command = new CreateStudentCommand(mockedFactory.Object, mockedService.Object);

            command.Execute(parameters);

            mockedService.Verify(x => x.AddStudent(mockedStudent.Object),
                Times.Once);
        }
    }
}
