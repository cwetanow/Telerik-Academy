using Moq;
using NUnit.Framework;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Services;

namespace SchoolSystem.Tests.RemoveStudentTests
{
    [TestFixture]
    public class ExecuteTests
    {
        [TestCase(1)]
        [TestCase(12)]
        [TestCase(1123123)]
        public void TestExecute_PassValidId_ShouldCallServiceRemoveStudentCorrectly(int id)
        {
            var parameters = new string[] { id.ToString() };

            var mockedService = new Mock<ISchoolService>();

            var command = new RemoveStudentCommand(mockedService.Object);

            command.Execute(parameters);

            mockedService.Verify(s => s.RemoveStudent(id), Times.Once);
        }
    }
}
