using SchoolSystem.Common.Contracts;
using SchoolSystem.Common.Enumerations;
using SchoolSystem.Common.Models.Abstract;

namespace SchoolSystem.Common.Models
{
    public class Teacher : Person
    {
        public Teacher(string firstName, string lastName, Subject subject)
            : base(firstName, lastName)
        {
            this.Subject = subject;
        }

        public Subject Subject { get; set; }

        public void AddMark(IStudent student, IMark mark)
        {
            student.AddMark(mark);
        }
    }
}
