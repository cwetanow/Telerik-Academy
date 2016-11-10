using System.Collections.Generic;

namespace Cosmetics.Contracts
{
    internal interface ICommandParser
    {
        IList<ICommand> ReadCommands();
    }
}
