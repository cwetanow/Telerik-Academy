using System.Collections.Generic;
using SchoolSystem.Common.Models;
using SchoolSystem.UI.Models.Contracts;

namespace SchoolSystem.UI.Models.Commands
{
    /// <summary>
    /// Class implements the ICommand interface with the functionality to add a mark to an existing student
    /// </summary>
    public class TeacherAddMarkCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);
            var studentId = int.Parse(parameters[1]);

            var markValue = float.Parse(parameters[2]);

            var student = Engine.GetStudentById(studentId);
            var teacher = Engine.GetTeacherById(teacherId);

            var mark = new Mark(teacher.Subject, markValue);

            teacher.AddMark(student, mark);

            var result = $"Teacher {teacher.GetNames()} added mark {markValue} to student {student.GetNames()} in {teacher.Subject}.";
            return result;
        }
    }
}
