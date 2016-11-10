using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Factories
{
    public interface IUserFactory
    {
        IUser CreateUser(string username, string firstName, string lastName, string password, Role role);
    }
}
