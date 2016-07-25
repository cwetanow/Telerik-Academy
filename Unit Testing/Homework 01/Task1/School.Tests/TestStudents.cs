using System;
using Task1;
using NUnit.Framework;

namespace School.Tests
{
    [TestFixture]
    public class TestStudents
    {
        [Test]
        public void Students_ConstructorIsWorking_EntityIsNOtNull()
        {
            var name = "Pesho";
            var student = new Student(name);
            Assert.IsNotNull(student);
        }

        [Test]
        public void Students_ConstructorInitialisesCorrectly_StudentName()
        {
            string name = "Pesho";
            var student = new Student(name);
            Assert.AreSame(name, student.Name);
        }

        [Test]
        public void Students_ConstructorTestEmptyName_ShouldThrow()
        {
            string name = "";
            TestDelegate test = () => new Student(name);
            Assert.Throws(typeof(ArgumentOutOfRangeException), test);
        }

        [Test]
        public void Students_UniqueNameIsInRange() {
            string name = "Pesho";
            var student = new Student(name);
            Assert.IsTrue(student.UN >= 10000 && student.UN <= 99999);
        }

        
    }
}
