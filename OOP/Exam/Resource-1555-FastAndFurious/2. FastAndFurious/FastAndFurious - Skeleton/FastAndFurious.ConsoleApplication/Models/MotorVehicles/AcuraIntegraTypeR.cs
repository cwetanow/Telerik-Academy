using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class AcuraIntegraTypeR : MotorVehicle

    {
        private static decimal InitialPrice = 24999;
        private static int InitialWeight = 1700000;
        private static int InitialTopSpeed = 200;
        private static int InitialAcceleration = 15;
        public AcuraIntegraTypeR():base(InitialPrice,InitialWeight,InitialAcceleration,InitialTopSpeed)
        {

        }
    }
}
