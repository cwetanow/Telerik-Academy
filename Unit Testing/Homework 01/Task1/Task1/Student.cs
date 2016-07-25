using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Utils;

namespace Task1
{
    public class Student
    {
        private string name;
        private int un;
        public Student(string name)
        {
            this.Name = name;
            this.UN = DataGenerator.GenerateId();
        }

        public int UN
        {
            get
            {
                return this.un;
            }
            private set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.un = value;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.name = value;
            }
        }

    }
}
