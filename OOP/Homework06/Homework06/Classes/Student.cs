using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework06.Enumerations;
namespace Homework06.Classes
{
    class Student
    {
        public Student(string first, string middle, string last, string ssn, string address, Faculty faculty,
            Specialty specialty, University university, string phone, string email)
        {
            this.FirstName = first;
            this.MiddleName = middle;
            this.LastName = last;
            this.SSN = ssn;
            this.Address = address;
            this.Faculty = faculty;
            this.Specialty = specialty;
            this.University = university;
            this.MobilePhone = phone;
            this.Email = email;
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public string Address { get; set; }
        public Faculty Faculty { get; set; }
        public Specialty Specialty { get; set; }
        public University University { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }

        public override bool Equals(object obj)
        {
            if (obj==null )
            {
                return false;
            }
            Student temp = obj as Student;
            if (temp==null)
            {
                return false;
            }
            return (this.FirstName.Equals(obj.fi));
        }
    }
}
