using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    class SubaruImprezaWRX : MotorVehicle
    {
        private static decimal InitialPrice = 55999;
        private static int InitialWeight = 1560000;
        private static int InitialTopSpeed = 260;
        private static int InitialAcceleration = 35;
        public SubaruImprezaWRX() : base(InitialPrice, InitialWeight, InitialAcceleration, InitialTopSpeed)
        {

        }
    }
}
