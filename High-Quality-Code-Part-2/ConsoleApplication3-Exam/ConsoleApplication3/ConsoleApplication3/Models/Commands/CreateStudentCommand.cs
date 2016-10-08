using System.Collections.Generic;
using System.ComponentModel;
using SchoolSystem.Common.Enumerations;
using SchoolSystem.Common.Models;
using SchoolSystem.UI.Models.Contracts;
using SchoolSystem.UI.Utils;

namespace SchoolSystem.UI.Models.Commands
{
    /// <summary>
    /// Class implements the ICommand interface with the functionality to create a student
    /// </summary>
    public class CreateStudentCommand : ICommand
    {
        public string Execute(IList<string> paramslList)
        {
            var firstName = paramslList[0];
            var lastName = paramslList[1];
            var gradeNumber = int.Parse(paramslList[2]);

            if (gradeNumber > 12 || gradeNumber < 1)
            {
                throw new InvalidEnumArgumentException("Grade must be between 1 and 12");
            }

            var grade = (Grade)gradeNumber;

            var student = new Student(firstName, lastName, grade);
            var id = IdGenerator.GenerateStudentId();

            Engine.AddStudent(id, student);

            var result = $"A new student with name {student.GetNames()}, grade {grade} and ID {id} was created.";
            return result;
        }
    }
}
