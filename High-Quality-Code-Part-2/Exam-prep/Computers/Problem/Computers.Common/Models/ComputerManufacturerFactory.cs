using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Computers.Common.Contracts;
using Computers.Common.Exceptions;
using Computers.Common.Manufacturers;
using Computers.Common.Utils;

namespace Computers.Common.Models
{
    public static class ComputerManufacturerFactory
    {
        public static IComputerManufacturer GetManufacturer(string manufacturerName)
        {
            IComputerManufacturer manufacturer;

            switch (manufacturerName)
            {
                case GlobalConstants.HpName:
                    {
                        manufacturer = new HpManufacturer();
                        break;
                    }
                case GlobalConstants.DellName:
                    {
                        manufacturer = new DellManufacturer();
                        break;
                    }

                default:
                    {
                        throw new InvalidArgumentException("Invalid manufacturer name");
                    }
            }

            return manufacturer;
        }
    }
}
