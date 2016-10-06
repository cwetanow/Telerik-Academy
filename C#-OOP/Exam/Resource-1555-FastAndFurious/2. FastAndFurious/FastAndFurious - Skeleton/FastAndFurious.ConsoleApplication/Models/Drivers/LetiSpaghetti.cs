using FastAndFurious.ConsoleApplication.Models.Drivers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Models.Drivers
{
    class LetiSpaghetti : Driver
    {
        public LetiSpaghetti() : base("Leti Spaghetti", GenderType.Female)
        {
        }
    }
}
