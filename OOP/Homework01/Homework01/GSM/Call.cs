using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework01.GSM
{
    class Call
    {
        private string date;
        private string time;
        private string dialledPhone;
        private int duration;
        public Call(string date, string time, string dialled, int duration)
        {
            this.Date = date;
            this.Time = time;
            this.DialledPhone = dialled;
            this.Duration = duration;
        }
        public string Date
        {
            get { return this.date; }
            private set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Invalid date");
                }

                this.date = value;

            }
        }
        public string Time
        {
            get { return this.time; }
            private set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Invalid time");
                }

                this.time = value;

            }
        }
        public string DialledPhone
        {
            get { return this.dialledPhone; }
            private set
            {
                bool isLegit = true;
                foreach (var item in value)
                {
                    if (!char.IsDigit(item))
                    {
                        isLegit = false;
                    }
                }
                if (value.Length == 0 || !isLegit)
                {
                    throw new ArgumentException("Invalid number");
                }

                this.dialledPhone = value;

            }
        }
        public int Duration
        {
            get { return this.duration; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid duration");
                }
                this.duration = value;
            }
        }
        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("Date: ");
            result.Append(this.Date);
            result.Append("; Time: ");
            result.Append(this.Time);
            result.Append("; To number: ");
            result.Append(this.DialledPhone);
            result.Append("; Duration: ");
            result.Append(this.Duration);
            

            return result.ToString();
        }
    }
}
