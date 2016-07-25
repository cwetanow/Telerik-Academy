using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace School.Tests
{
    [TestFixture]
    public class TestCourses
    {
       [TestCase]
       public void Courses_ConstructorInitialisesCorrectly()
        {
            var course = new Course();
            Assert.IsNotNull(course);
        }

        [TestCase]
        public void Courses_CanAddCorrectly()
        {
            var course = new Course();
            var initialStudents = course.Count;
            var studentToAdd = new Student("Pesho");
            course.StudentJoins(studentToAdd);
            Assert.AreEqual(initialStudents + 1, course.Count);
        }

        [TestCase]
        public void Courses_JoinMoreThan30Students_ShouldThrow()
        {
            var course = new Course();
            TestDelegate test = () =>
            {
                for (int i = 0; i < 31; i++)
                {
                    var studentToAdd = new Student("Pesho");
                    course.StudentJoins(studentToAdd);
                }
            };
            Assert.Throws(typeof(ArgumentException), test);
        }

        [TestCase]
        public void Courses_TryToRemoveWhenCourseEmpty_ShouldThrow()
        {
            var course = new Course();
            var student = new Student("Gosho");
            TestDelegate test = () =>
            {
                course.StudentLeaves(student);
            };
            Assert.Throws(typeof(ArgumentException), test);
        }

        [TestCase]
        public void Courses_CorrectlyStudentLeaves()
        {
            var course = new Course();
            var student = new Student("Gosho");
            course.StudentJoins(student);
            Assert.IsTrue(course.StudentLeaves(student));
        }
    }
}
