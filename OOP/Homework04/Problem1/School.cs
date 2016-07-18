using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem1.Classes;
namespace Problem1
{
    public class School
    {
        private string name;
        private List<Class> classes;

        public List<Class> Classes
        {
            get { return this.classes; }
            set { this.classes = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public School(string name, List<Class> classes)
        {
            this.Name = name;
            this.Classes = classes;
        }
        public void AddClass(Class clas)
        {
            this.Classes.Add(clas);
        }
        public override string ToString()
        {
            return string.Join(", ",this.Classes);
        }
    }
}
