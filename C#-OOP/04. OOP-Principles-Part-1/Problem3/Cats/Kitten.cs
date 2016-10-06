using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3.Cats
{
    public class Kitten : Cat
    {
        public Kitten(string name,  int age)
            : base(name, "Female", age)
        {

        }
    }
}
