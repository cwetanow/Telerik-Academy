using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public abstract class Human
    {
        protected string firstName;
        protected string lastName;
        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException("Give him a name!");
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException("Give him a name!");
                }
                this.lastName = value;
            }
        }
        public Human(string first, string last)
        {
            this.FirstName = first;
            this.LastName = last;
        }

    }
}
