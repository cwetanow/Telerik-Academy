using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1.Utils
{
   public static class DataGenerator
    {
        private static int idCounter;

        static DataGenerator()
        {
            idCounter = 10000;
        }

        public static int GenerateId()
        {
            return Interlocked.Increment(ref idCounter);
        }
    }
}
