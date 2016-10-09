using System.Collections.Generic;
using SchoolSystem.UI.Models.Contracts;

namespace SchoolSystem.UI.Models.Commands
{
    /// <summary>
    /// Class implements the ICommand interface with the functionality to remove a student
    /// </summary>
    public class RemoveStudentCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var id = int.Parse(parameters[0]);

            Engine.RemoveStudent(id);

            var result = $"Student with ID {id} was sucessfully removed.";
            return result;
        }
    }
}
