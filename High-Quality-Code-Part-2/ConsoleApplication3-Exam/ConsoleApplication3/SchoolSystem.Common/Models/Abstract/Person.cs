using System;
using System.Text.RegularExpressions;
using SchoolSystem.Common.Utils;

namespace SchoolSystem.Common.Models.Abstract
{
    public abstract class Person
    {
        private string firstName;
        private string lastName;

        protected Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;

            }
            set
            {
                if (value.Length < 2 || value.Length > 31)
                {
                    throw new ArgumentException(GlobalConstants.InvalidNameLength);
                }

                if (!Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                {
                    throw new ArgumentException(GlobalConstants.InvalidCharactersInName);
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;

            }
            set
            {
                if (value.Length < 2 || value.Length > 31)
                {
                    throw new ArgumentException(GlobalConstants.InvalidNameLength);
                }

                if (!Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                {
                    throw new ArgumentException(GlobalConstants.InvalidCharactersInName);
                }

                this.lastName = value;
            }
        }

        public string GetNames()
        {
            var result = $"{this.FirstName} {this.LastName}";

            return result;
        }
    }
}
