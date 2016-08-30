using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class RefactoredLoop
    {
        public void Loop(object[] array, object expectedValue)
        {
            var i = 0;

            for (i = 0; i < 100; i++)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine(array[i]);
                    if (array[i] == expectedValue)
                    {
                        i = 666;
                    }
                }
                else
                {
                    Console.WriteLine(array[i]);
                }
            }

            if (i == 666)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
