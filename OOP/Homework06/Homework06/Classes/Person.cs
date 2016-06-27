using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework06.Classes
{
    public class Person
    {
        public int? Age { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            
            return this.Age == null ? string.Format("Name: {0}, Age: not specified ", this.Name): string.Format("Name: {0}, Age: {1}", this.Name,this.Age);
            
        }
    }
}
