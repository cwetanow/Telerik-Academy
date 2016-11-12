using System;
using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Services;

namespace SchoolSystem.Framework.Core.Commands
{
    public class StudentListMarksCommand : ICommand
    {
        private readonly ISchoolService schoolService;

        public StudentListMarksCommand(ISchoolService service)
        {
            if (service == null)
            {
                throw new ArgumentNullException("service cannot be null");
            }

            this.schoolService = service;
        }

        public string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[0]);
            var student = this.schoolService.GetStudentById(studentId);

            return student.ListMarks();
        }
    }
}
