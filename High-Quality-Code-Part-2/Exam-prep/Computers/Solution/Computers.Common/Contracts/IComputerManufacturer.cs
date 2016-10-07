using Computers.Common.Models.Computers;

namespace Computers.Common.Contracts
{
    public interface IComputerManufacturer
    {
        Laptop CreateLaptop();

        Server CreateServer();

        PersonalComputer CreatePersonalComputer();
    }
}
