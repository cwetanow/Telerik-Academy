using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    class Nissan350Z : MotorVehicle
    {
        private static decimal InitialPrice = 25999;
        private static int InitialWeight = 1280000;
        private static int InitialTopSpeed = 220;
        private static int InitialAcceleration = 55;
        public Nissan350Z() : base(InitialPrice, InitialWeight, InitialAcceleration, InitialTopSpeed)
        {

        }
    }
}
