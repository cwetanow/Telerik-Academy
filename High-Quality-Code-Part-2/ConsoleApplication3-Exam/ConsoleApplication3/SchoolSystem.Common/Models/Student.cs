using System;
using System.Collections.Generic;
using System.Text;
using SchoolSystem.Common.Contracts;
using SchoolSystem.Common.Enumerations;
using SchoolSystem.Common.Models.Abstract;
using SchoolSystem.Common.Utils;

namespace SchoolSystem.Common.Models
{
    public class Student : Person, IStudent
    {
        public Student(string firstName, string lastName, Grade grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
            this.Marks = new List<IMark>();
        }

        public ICollection<IMark> Marks { get; private set; }

        public Grade Grade { get; set; }

        public string ListMarks()
        {
            var result = new StringBuilder();

            if (this.Marks.Count == 0)
            {
                result.AppendLine("The student has no marks.");
            }
            else
            {
                result.AppendLine("The student has these marks:");

                foreach (var mark in this.Marks)
                {
                    result.AppendLine($"{mark.Subject} => {mark.Value}");
                }
            }

            return result.ToString();
        }

        public void AddMark(IMark mark)
        {
            if (this.Marks.Count == 20)
            {
                throw new ArgumentOutOfRangeException(GlobalConstants.StudentMaximumGradesReacher);
            }

            this.Marks.Add(mark);
        }
    }
}
