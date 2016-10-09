using System.Collections.Generic;
using SchoolSystem.UI.Models.Contracts;

namespace SchoolSystem.UI.Models.Commands
{
    /// <summary>
    /// Class implements the ICommand interface with the functionality to remove a teacher
    /// </summary>
    public class RemoveTeacherCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var id = int.Parse(parameters[0]);

            Engine.RemoveTeacher(id);

            var result = $"Teacher with ID {id} was sucessfully removed.";
            return result;
        }
    }
}
