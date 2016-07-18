using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1.People
{
    public abstract class Person
    {
        protected string name;

        public string Name
        {
            
            get { return this.name; }
            set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException("Give the man a name!");
                }
                this.name = value;
            }
        }
        public Person(string name)
        {
            this.Name = name;
        }
        public override string ToString()
        {
            return this.Name;
        }

    }
}
