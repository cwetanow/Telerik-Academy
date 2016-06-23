using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework03.Students
{
    class Group
    {
        private int groupNumber;
        private string departmentName;
        public int GroupNumber
        {
            get { return this.groupNumber; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Non existend group");
                }
                this.groupNumber = value;
            }
        }


        public string DepartmentName
        {
            get { return this.departmentName; }
            set
            {
                this.departmentName = value; }
        }
        public Group(int groupNum, string department)
        {
            
            this.GroupNumber = groupNum;
            this.DepartmentName = department;
          
        }

    }
}
