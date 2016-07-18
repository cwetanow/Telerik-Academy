using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Drivers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAndFurious.ConsoleApplication.Models.Drivers
{
    class VinBenzin : Driver
    {
        public VinBenzin() : base("Vin Benzin", GenderType.Female)
        {
        }
    }
}
