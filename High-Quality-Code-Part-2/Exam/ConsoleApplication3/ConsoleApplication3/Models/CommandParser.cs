using System;
using System.Linq;
using SchoolSystem.UI.Models.Commands;
using SchoolSystem.UI.Models.Contracts;
using SchoolSystem.UI.Utils;

namespace SchoolSystem.UI.Models
{
    public class CommandParser : ICommandParser
    {
        public string ParseCommand(string commandInput)
        {
            var splitCommand = commandInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var commandName = splitCommand[0];

            splitCommand.RemoveAt(0);

            var command = GetCommand(commandName);

            var result = command.Execute(splitCommand);
            return result;
        }

        private static ICommand GetCommand(string commandName)
        {
            switch (commandName)
            {
                case GlobalConstants.CreateStudentCommand:
                    {
                        return new CreateStudentCommand();
                    }

                case GlobalConstants.CreateTeacherCommand:
                    {
                        return new CreateTeacherCommand();
                    }

                case GlobalConstants.RemoveStudentCommand:
                    {
                        return new RemoveStudentCommand();
                    }

                case GlobalConstants.RemoveTeacherCommand:
                    {
                        return new RemoveTeacherCommand();
                    }

                case GlobalConstants.StudentListMarksCommand:
                    {
                        return new StudentsListMarksCommand();
                    }

                case GlobalConstants.TeacherAddMarkCommand:
                    {
                        return new TeacherAddMarkCommand();
                    }

                default:
                    {
                        throw new ArgumentNullException("Invalid command");
                    }
            }
        }
    }
}
