using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    class NissanSkylineR34 : MotorVehicle
    {
        private static decimal InitialPrice = 45999;
        private static int InitialWeight = 1850000;
        private static int InitialTopSpeed = 280;
        private static int InitialAcceleration = 50;
        public NissanSkylineR34() : base(InitialPrice, InitialWeight, InitialAcceleration, InitialTopSpeed)
        {

        }
    }
}
