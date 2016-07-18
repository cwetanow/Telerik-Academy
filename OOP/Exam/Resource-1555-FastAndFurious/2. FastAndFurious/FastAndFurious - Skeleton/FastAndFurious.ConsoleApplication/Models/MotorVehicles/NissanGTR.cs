using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    class NissanGTR : MotorVehicle
    {
        private static decimal InitialPrice = 125000;
        private static int InitialWeight = 1850000;
        private static int InitialTopSpeed = 300;
        private static int InitialAcceleration = 45;
        public NissanGTR() : base(InitialPrice, InitialWeight, InitialAcceleration, InitialTopSpeed)
        {

        }
    }
}
