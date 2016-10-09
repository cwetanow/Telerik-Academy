using System.Collections.Generic;
using SchoolSystem.UI.Models.Contracts;

namespace SchoolSystem.UI.Models.Commands
{
    /// <summary>
    /// Class implements the ICommand interface with the functionality to list all the students marks
    /// </summary>
    public class StudentsListMarksCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var id = int.Parse(parameters[0]);

            var result = Engine.GetStudentById(id)
                .ListMarks();

            return result;
        }
    }
}
