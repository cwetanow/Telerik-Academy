using System;
using System.Collections.Generic;
using NUnit.Framework;
using SchoolSystem.Common.Contracts;
using SchoolSystem.Common.Enumerations;
using SchoolSystem.Common.Models;

namespace SchoolSystem.Tests.StudentTests
{
    [TestFixture]
    public class StudentConstructorTests
    {
        [TestCase("Pesho", "Peshev", Grade.Eighth)]
        [TestCase("Gosho", "Georgiev", Grade.Ninth)]
        public void TestConstructor_ShouldInitialiseCorrectly(string firstName, string lastName, Grade grade)
        {
            var student = new Student(firstName, lastName, grade);

            Assert.IsNotNull(student);
            Assert.IsInstanceOf<Student>(student);

            Assert.IsNotNull(student.Marks);
            Assert.IsInstanceOf<ICollection<IMark>>(student.Marks);
        }

        [TestCase("Pesho", "Peshev", Grade.Eighth)]
        [TestCase("Gosho", "Georgiev", Grade.Ninth)]
        public void TestConstructor_PassValidValues_ShouldSetPropertiesCorrectly(string firstName, string lastName, Grade grade)
        {
            var student = new Student(firstName, lastName, grade);

            Assert.AreEqual(student.Grade, grade);
            Assert.AreEqual(student.FirstName, firstName);
            Assert.AreEqual(student.LastName, lastName);
        }

        [TestCase("a")]
        [TestCase("")]
        public void TestConstructor_PassInvalidFirstName_ShouldThrowArgumentException(string firstName)
        {
            var lastName = "Petrov";
            var grade = Grade.Eighth;

            Assert.Throws<ArgumentException>(() => new Student(firstName, lastName, grade));
        }

        [TestCase("a")]
        [TestCase("")]
        public void TestConstructor_PassInvalidLastName_ShouldThrowArgumentException(string lastName)
        {
            var firstName = "Petrov";
            var grade = Grade.Eighth;

            Assert.Throws<ArgumentException>(() => new Student(firstName, lastName, grade));
        }
    }
}
