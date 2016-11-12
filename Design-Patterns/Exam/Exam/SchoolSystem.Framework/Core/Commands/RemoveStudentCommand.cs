using System;
using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Services;

namespace SchoolSystem.Framework.Core.Commands
{
    public class RemoveStudentCommand : ICommand
    {
        private readonly ISchoolService schoolService;

        public RemoveStudentCommand(ISchoolService service)
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

            this.schoolService.RemoveStudent(studentId);

            return $"Student with ID {studentId} was sucessfully removed.";
        }
    }
}
