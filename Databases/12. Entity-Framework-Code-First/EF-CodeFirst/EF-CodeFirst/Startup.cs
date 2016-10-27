using System;
using EF_CodeFirst.Data;
using EF_CodeFirst.Models;

namespace EF_CodeFirst
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var context = new StudentSystemContext();

            var material = new Material
            {
                Content = "Material"
            };
            var course = new Course
            {
                Description = "We learn databases",
                Name = "DB"
            };

            course.Materials.Add(material);

            var homework = new Homework
            {
                Content = "Task",
                Course = course,
                Datesent = DateTime.Now
            };

            var student = new Student
            {
                Name = "Pesho",
                StudentNumber = "12345"
            };

            student.Courses.Add(course);
            student.Homeworks.Add(homework);

            context.Students.Add(student);

            context.SaveChanges();
        }
    }
}
