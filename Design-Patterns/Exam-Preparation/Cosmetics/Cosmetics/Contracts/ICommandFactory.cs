namespace Cosmetics.Contracts
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string input);
    }
}
