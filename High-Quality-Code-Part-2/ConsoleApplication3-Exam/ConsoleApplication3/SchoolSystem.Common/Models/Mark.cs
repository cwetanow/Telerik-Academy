using System;
using SchoolSystem.Common.Contracts;
using SchoolSystem.Common.Enumerations;
using SchoolSystem.Common.Utils;

namespace SchoolSystem.Common.Models
{
    public class Mark : IMark
    {
        private float value;

        public Mark(Subject subject, float value)
        {
            this.Subject = subject;
            this.Value = value;
        }

        public Subject Subject { get; private set; }

        public float Value
        {
            get
            {
                return this.value;
            }

            private set
            {
                if (value < 2 || value > 6)
                {
                    throw new ArgumentOutOfRangeException(GlobalConstants.InvalidMarkValue);
                }

                this.value = value;
            }
        }
    }
}
