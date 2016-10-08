using System;
using NUnit.Framework;
using SchoolSystem.Common.Enumerations;
using SchoolSystem.Common.Models;

namespace SchoolSystem.Tests.TeacherTests
{
    [TestFixture]
    class ConstructorTests
    {
        [TestCase("Pesho", "Peshev", Subject.Math)]
        [TestCase("Gosho", "Georgiev", Subject.Programming)]
        public void TestConstructor_ShouldInitialiseCorrectly(string firstName, string lastName, Subject subject)
        {
            var teacher = new Teacher(firstName, lastName, subject);

            Assert.IsNotNull(teacher);
            Assert.IsInstanceOf<Teacher>(teacher);
        }

        [TestCase("Pesho", "Peshev", Subject.Math)]
        [TestCase("Gosho", "Georgiev", Subject.Bulgarian)]
        public void TestConstructor_PassValidValues_ShouldSetPropertiesCorrectly(string firstName, string lastName, Subject subject)
        {
            var teacher = new Teacher(firstName, lastName, subject);

            Assert.AreEqual(teacher.Subject, subject);
            Assert.AreEqual(teacher.FirstName, firstName);
            Assert.AreEqual(teacher.LastName, lastName);
        }

        [TestCase("a")]
        [TestCase("")]
        public void TestConstructor_PassInvalidFirstName_ShouldThrowArgumentException(string firstName)
        {
            var lastName = "Petrov";
            var subject = Subject.Math;

            Assert.Throws<ArgumentException>(() => new Teacher(firstName, lastName, subject));
        }

        [TestCase("a")]
        [TestCase("")]
        public void TestConstructor_PassInvalidLastName_ShouldThrowArgumentException(string lastName)
        {
            var firstName = "Petrov";
            var subject = Subject.Math;

            Assert.Throws<ArgumentException>(() => new Teacher(firstName, lastName, subject));
        }
    }
}
