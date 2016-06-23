using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework01.GSM;
using Homework01.GSMTest;

namespace Homework01
{
    class Program
    {
        static void Main(string[] args)
        {
            GSMTest.GSMTest.GsmTest();
            Console.WriteLine();
            CallHistoryTest.CallTest();
        }
    }
}
