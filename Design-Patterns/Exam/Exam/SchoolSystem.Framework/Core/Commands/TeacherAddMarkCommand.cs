using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Services;

namespace SchoolSystem.Framework.Core.Commands
{
    public class TeacherAddMarkCommand : ICommand
    {
        private readonly IMarkFactory markFactory;
        private readonly ISchoolService schoolService;

        public TeacherAddMarkCommand(IMarkFactory factory, ISchoolService service)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory cannot be null");
            }

            if (service == null)
            {
                throw new ArgumentNullException("service cannot be null");
            }

            this.markFactory = factory;
            this.schoolService = service;
        }

        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);
            var studentId = int.Parse(parameters[1]);
            var markValue = float.Parse(parameters[2]);

            var student = this.schoolService.GetStudentById(studentId);
            var teacher = this.schoolService.GetTeacherById(teacherId);

            var mark = this.markFactory.CreateMark(teacher.Subject, markValue);
            teacher.AddMark(student, mark);

            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {mark.Value} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}
