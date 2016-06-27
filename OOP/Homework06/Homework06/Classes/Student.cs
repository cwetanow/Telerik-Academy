using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework06.Enumerations;
namespace Homework06.Classes
{
    public class Student : ICloneable, IComparable<Student>
    {
        public Student(string first, string middle, string last, long ssn, string address, Faculty faculty,
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
        public long SSN { get; set; }
        public string Address { get; set; }
        public Faculty Faculty { get; set; }
        public Specialty Specialty { get; set; }
        public University University { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Student temp = obj as Student;
            if (temp == null)
            {
                return false;
            }
            return (this.FirstName.Equals(temp.FirstName)
                && this.MiddleName.Equals(temp.MiddleName)
                 && this.LastName.Equals(temp.LastName)
                  && this.SSN.Equals(temp.SSN)
                   && this.Address.Equals(temp.Address)
                    && this.Faculty.Equals(temp.Faculty)
                     && this.Specialty.Equals(temp.Specialty)
                      && this.University.Equals(temp.University)
                       && this.MobilePhone.Equals(temp.MobilePhone)
                        && this.Email.Equals(temp.Email));
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.FirstName, this.MiddleName, this.LastName);
        }
        public override int GetHashCode()
        {
            return new
            {
                this.FirstName,
                this.MiddleName,
                this.LastName,
                this.SSN,
                this.Address,
                this.Faculty,
                this.Specialty,
                this.University,
                this.MobilePhone,
                this.Email
            }.GetHashCode();
        }
        public static bool operator ==(Student one, Student second)
        {
            return one.FirstName == second.FirstName && one.MiddleName == second.MiddleName && one.LastName == second.LastName &&
                one.SSN == second.SSN && one.Address == second.Address && one.Faculty == second.Faculty && one.Specialty == second.Specialty &&
                one.University == second.University && one.MobilePhone == second.MobilePhone && one.Email == second.Email;

        }
        public static bool operator !=(Student one, Student second)
        {
            return !(one.FirstName == second.FirstName && one.MiddleName == second.MiddleName && one.LastName == second.LastName &&
                one.SSN == second.SSN && one.Address == second.Address && one.Faculty == second.Faculty && one.Specialty == second.Specialty &&
                one.University == second.University && one.MobilePhone == second.MobilePhone && one.Email == second.Email);

        }
        public object Clone()
        {
            return new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN, this.Address, this.Faculty, this.Specialty, this.University, this.MobilePhone, this.Email);
        }
        public int CompareTo(Student a) {
            var comparingName = this.FirstName.CompareTo(a.FirstName);
            if (comparingName==0)
            {
                return this.SSN.CompareTo(a.SSN);
            }
            else
            {
                return comparingName;
            }

        }
    }
}
