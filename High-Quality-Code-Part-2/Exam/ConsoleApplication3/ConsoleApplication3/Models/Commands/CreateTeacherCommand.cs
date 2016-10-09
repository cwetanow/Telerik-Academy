using System.Collections.Generic;
using SchoolSystem.Common.Enumerations;
using SchoolSystem.Common.Models;
using SchoolSystem.UI.Models.Contracts;
using SchoolSystem.UI.Utils;

namespace SchoolSystem.UI.Models.Commands
{
    /// <summary>
    /// Class implements the ICommand interface with the functionality to create a teacher
    /// </summary>
    public class CreateTeacherCommand : ICommand
    {
        public string Execute(IList<string> paramslList)
        {
            var firstName = paramslList[0];
            var lastName = paramslList[1];
            var subject = (Subject)int.Parse(paramslList[2]);

            var teacher = new Teacher(firstName, lastName, subject);
            var id = IdGenerator.GenerateTeacherId();

            Engine.AddTeacher(id, teacher);

            var result = $"A new teacher with name {teacher.GetNames()}, subject {subject} and ID {id} was created.";
            return result;
        }
    }
}
