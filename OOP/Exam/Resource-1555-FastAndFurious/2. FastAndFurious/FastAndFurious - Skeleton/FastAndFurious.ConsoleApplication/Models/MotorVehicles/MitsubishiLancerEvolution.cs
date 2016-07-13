using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    class MitsubishiLancerEvolution:MotorVehicle
    {
        private static decimal InitialPrice = 56999;
        private static int InitialWeight = 1780000;
        private static int InitialTopSpeed = 300;
        private static int InitialAcceleration = 20;
        public MitsubishiLancerEvolution():base(InitialPrice,InitialWeight,InitialAcceleration,InitialTopSpeed)
        {

        }
    }
}
