using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework01.GSM
{
    class Battery
    {
        private string model;
        private int? hoursIdle;
        private int? hoursTalk;
        private BatteryType? batteryType;
        public string Model
        {
            get { return this.model; }
            private set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Model name should be longer than 0");
                }

                this.model = value;

            }
        }

        public int? HoursIdle
        {
            get { return this.hoursIdle; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Battery idle hours should be longer than 0");
                }

                this.hoursIdle = value;

            }
        }

        public int? HoursTalk
        {
            get { return this.hoursTalk; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Battery talk hours should be longer than 0");
                }

                this.hoursTalk = value;

            }
        }

        public BatteryType? BatteryType
        {
            get { return this.batteryType; }
            set
            {
                this.batteryType = value;
            }
        }
        public Battery(string model, int? hoursIdle, int? hoursTalk, BatteryType? batteryType)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.BatteryType = batteryType;
        }
        public Battery()
            : this(null, null, null, null)
        {

        }
        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("Model: ");
            result.Append(this.Model);
            result.Append(" / Hours idle: ");
            result.Append(this.HoursIdle);
            result.Append(" / Hours talk: ");
            result.Append(this.HoursTalk);
            result.Append(" / Type: ");
            result.Append(this.BatteryType);
            return result.ToString();
        }
    }
}
