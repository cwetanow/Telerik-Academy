using Homework01.GSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework01
{
    class CallHistoryTest
    {
        public static void CallTest() {
            var lion = new Battery("pesho123", 100, 30, BatteryType.LiIon);
            var gorilla = new Display(5, 6000000);
            var samsung = new GSM.GSM("galaxy s2", "samsung", 400, "Stoyan", lion, gorilla);
            var tempCall = new Call("11.05", "13:45", "0851782516", 240);
            samsung.AddCall(tempCall);
            tempCall = new Call("12.05", "11:45", "0851782516", 120);
            samsung.AddCall(tempCall);
            tempCall = new Call("14.05", "12:33", "0851782516", 24);
            samsung.AddCall(tempCall);
            tempCall = new Call("15.05", "04:45", "0851782516", 1790);
            samsung.AddCall(tempCall);
            
            foreach (var item in samsung.CallHistory)
            {
                Console.WriteLine(item);                
            }
            decimal bill = 0;
            foreach (var item in samsung.CallHistory)
            {
                bill += samsung.CallPrice(item, (decimal)0.37);
            }
            Console.WriteLine("Bill is: {0}",bill);
            int maxIndex=0;
            int maxDuration=0;
            for (int i = 0; i < samsung.CallHistory.Count; i++)
            {
                if (samsung.CallHistory[i].Duration>maxDuration)
                {
                    maxDuration = samsung.CallHistory[i].Duration;
                    maxIndex = i;
                }
            }
            samsung.DeleteCall(maxIndex);
             bill = 0;
            foreach (var item in samsung.CallHistory)
            {
                bill += samsung.CallPrice(item, (decimal)0.37);
            }
            Console.WriteLine("Bill is: {0}", bill);
            foreach (var item in samsung.CallHistory)
            {
                Console.WriteLine(item);
            }
            samsung.ClearHistory();
            
        }
    }
}
