using Cosmetics.Contracts;
using System.Collections.Generic;

namespace Cosmetics.Engine
{
    internal class ConsoleCommandParser : ICommandParser
    {
        private readonly IReader reader;
        private readonly ICommandFactory factory;

        public ConsoleCommandParser(IReader reader, ICommandFactory factory)
        {
            this.reader = reader;
            this.factory = factory;
        }

        public IList<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();

            var input = this.reader.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                var currentCommand = this.factory.CreateCommand(input);
                commands.Add(currentCommand);

                input = this.reader.ReadLine();
            }

            return commands;
        }
    }
}
