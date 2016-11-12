using System;
using NUnit.Framework;
using SchoolSystem.Framework.Core.Commands;

namespace SchoolSystem.Tests.RemoveStudentTests
{
    [TestFixture]
    class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassNullAsService_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new RemoveStudentCommand(null));
        }
    }
}
