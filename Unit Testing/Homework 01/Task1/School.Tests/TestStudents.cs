using System;
using Task1;
using NUnit.Framework;

namespace School.Tests
{
    [TestFixture]
    public class TestStudents
    {
        [Test]
        public void Students_ConstructorTestEmptyName_ShouldThrow()
        {
            string name = "";
            TestDelegate a = () => new Student(name);
            Assert.Throws(typeof(ArgumentOutOfRangeException), a);
        }
    }
}
