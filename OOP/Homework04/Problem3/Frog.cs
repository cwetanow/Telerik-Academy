using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3
{
   public class Frog:Animal
    {
        public Frog(string name, string sex, int age)
            : base(name, sex, age)
        {

        }
        public override void ProduceSound()
        {
            Console.WriteLine("Ribbit-ribbit");
        }
    }
}
