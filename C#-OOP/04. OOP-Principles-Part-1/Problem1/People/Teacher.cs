using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem1.Disciplines;

namespace Problem1.People
{
    public class Teacher: Person
    {
        private List<Discipline> disciplines;

        public List<Discipline> Disciplines
        {
            get { return disciplines; }
            set { disciplines = value; }
        }      
        
        
        public Teacher(string name, List<Discipline> disciplines) : base(name) {
            this.Disciplines = disciplines;
        }
        public override string ToString()
        {
            return string.Format("{0}: {1}", this.Name,string.Join(", ",this.Disciplines));
        }
        
    }
}
