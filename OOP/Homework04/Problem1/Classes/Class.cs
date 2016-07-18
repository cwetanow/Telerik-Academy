using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem1.People;

namespace Problem1.Classes
{
    public class Class
    {
        private string uniqueID;
        private List<Teacher> teachers;

        public List<Teacher> Teachers
        {
            get { return this.teachers; }
            set { this.teachers = value; }
        }
        public override string ToString()
        {
            return string.Format("{0}: {1}",this.UniqueID,string.Join(", ", this.teachers));
        }

        public string UniqueID
        {
            get { return this.uniqueID; }
            set { this.uniqueID = value; }
        }

    }
}
