using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework01.GSM;

namespace Homework01.GSMTest
{
    class GSMTest
    {
        
        public static void GsmTest()
        {
           
            Console.WriteLine();

            // Create an array of few instances of the GSM class.
            var lion = new Battery("pesho123", 100, 30, BatteryType.LiIon);
            var gorilla = new Display(5, 6000000);
            var samsung = new GSM.GSM("galaxy s2", "samsung", 400, "Stoyan", lion, gorilla);
            var htc = new GSM.GSM("m8", "HTC", 350, "Dragan", lion, gorilla);
            var sony = new GSM.GSM("xperia z5", "Sony", 500, "Pesho", lion, gorilla);
            var onePlusOne = new GSM.GSM("onePlusOne", "onePlusOne", 600, "Ivan", lion, gorilla);

            var gsmList = new List<GSM.GSM> { samsung, htc, sony, onePlusOne };

            // Display the information about the GSMs in the array.
            Console.WriteLine(string.Join(Environment.NewLine, gsmList));
            Console.WriteLine(GSM.GSM.Iphone4S);
        }

    }
}
