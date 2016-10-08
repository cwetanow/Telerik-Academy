using System;
using NUnit.Framework;
using SchoolSystem.Common.Enumerations;
using SchoolSystem.Common.Models;

namespace SchoolSystem.Tests.MarkTests
{
    [TestFixture]
    public class MarkConstructorTests
    {
        [TestCase(2f, Subject.Bulgarian)]
        [TestCase(3.1f, Subject.Math)]
        [TestCase(6f, Subject.Programming)]
        public void TestConstructor_PassValidValues_ShouldInitialiseCorrectly(float value, Subject subject)
        {
            var mark = new Mark(subject, value);

            Assert.IsNotNull(mark);
            Assert.IsInstanceOf<Mark>(mark);
        }

        [TestCase(2f, Subject.Bulgarian)]
        [TestCase(3.1f, Subject.Math)]
        [TestCase(6f, Subject.Programming)]
        public void TestConstructor_PassValidValues_ShouldSetValueAndSubjectCorrectly(float value, Subject subject)
        {
            var mark = new Mark(subject, value);

            Assert.AreEqual(mark.Subject, subject);
            Assert.AreEqual(mark.Value, value);
        }

        [TestCase(12f, Subject.Bulgarian)]
        [TestCase(35.1f, Subject.Math)]
        [TestCase(-14f, Subject.Programming)]
        public void TestConstructor_PassInvalidValue_ShouldThrowArgumentOutOfRangeException(float value, Subject subject)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Mark(subject, value));
        }
    }
}
