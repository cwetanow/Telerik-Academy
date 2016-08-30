using System;

namespace Methods
{
    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            var firstDate = ParseDate(this.OtherInfo);
            var secondDate = ParseDate(other.OtherInfo);

            return firstDate > secondDate;
        }

        private DateTime ParseDate(string input)
        {
            var result = DateTime.Parse(input.Substring(input.Length - 10));

            return result;
        }
    }
}
