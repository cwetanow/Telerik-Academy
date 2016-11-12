using System;
using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Services;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateStudentCommand : ICommand
    {
        private readonly IStudentFactory factory;
        private readonly ISchoolService schoolService;

        public CreateStudentCommand(IStudentFactory factory, ISchoolService service)
        {
            if (factory==null)
            {
                throw new ArgumentNullException("factory cannot be null");
            }

            if (service == null)
            {
                throw new ArgumentNullException("service cannot be null");
            }

            this.factory = factory;
            this.schoolService = service;
        }

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);

            var student = this.factory.CreateStudent(firstName, lastName, grade);

            var id = this.schoolService.AddStudent(student);

            return $"A new student with name {firstName} {lastName}, grade {grade} and ID {id} was created.";
        }
    }
}
