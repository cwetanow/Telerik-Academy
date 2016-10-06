using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
   public class MitsubishiEclipse:MotorVehicle
    {
        private static decimal InitialPrice = 29999;
        private static int InitialWeight = 1400000;
        private static int InitialTopSpeed = 230;
        private static int InitialAcceleration = 24;
        public MitsubishiEclipse():base(InitialPrice,InitialWeight,InitialAcceleration,InitialTopSpeed)
        {

        }
    }
}
