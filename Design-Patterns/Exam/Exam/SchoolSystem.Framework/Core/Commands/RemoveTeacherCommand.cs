using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Services;

namespace SchoolSystem.Framework.Core.Commands
{
    public class RemoveTeacherCommand : ICommand
    {
        private readonly ISchoolService schoolService;

        public RemoveTeacherCommand(ISchoolService service)
        {
            if (service == null)
            {
                throw new ArgumentNullException("service cannot be null");
            }

            this.schoolService = service;
        }

        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);

            this.schoolService.RemoveTeacher(teacherId);

            return $"Teacher with ID {teacherId} was sucessfully removed.";
        }
    }
}
