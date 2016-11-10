using Dealership.Contracts;

namespace Dealership.Factories
{
    public interface ICommentFactory
    {
        IComment CreateComment(string content);
    }
}
