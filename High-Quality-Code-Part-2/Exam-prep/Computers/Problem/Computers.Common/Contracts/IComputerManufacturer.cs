using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
