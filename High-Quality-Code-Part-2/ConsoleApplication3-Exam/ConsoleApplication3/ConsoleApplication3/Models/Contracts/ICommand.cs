using System.Collections.Generic;

namespace SchoolSystem.UI.Models.Contracts
{
    /// <summary>
    /// ICommand interface provides a method Execute for all its implementations
    /// </summary>
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
