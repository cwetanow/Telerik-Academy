using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework01.GSM
{
    class GSM
    {
        private string model;
        private string manufacturer;
        private double? price;
        private string owner;
        private Battery battery;
        private Display display;
        private List<Call> callHistory;
        public static GSM Iphone4S = new GSM(
                "Iphone 4s",
                "Apple",
                1000,
                "Pesho",
                new Battery("AppleBat", 10, 10, BatteryType.LiIon),
                new Display(6, 2));

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

        public string Manufacturer
        {
            get { return this.manufacturer; }
            private set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Manufacturer name should be longer than 0");
                }

                this.manufacturer = value;

            }
        }
        public double? Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid price");
                }
                this.price = value;
            }
        }
        public string Owner
        {
            get { return this.owner; }
            private set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Model name should be longer than 0");
                }

                this.owner = value;

            }
        }

        public Battery Battery
        {
            get { return this.battery; }
            set
            {
                this.battery = value;
            }
        }
        public Display Display
        {
            get { return this.display; }
            set
            {
                this.display = value;
            }
        }
        public List<Call> CallHistory
        {
            get { return this.callHistory; }
            set {
                this.callHistory = value;
            }
        }
        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("Model: ");
            result.Append(this.Model);
            result.Append("; Manufacturer: ");
            result.Append(this.Manufacturer);
            result.Append("; Price: ");
            result.Append(this.Price);
            result.Append("; Owner: ");
            result.Append(this.Owner);
            result.Append("; Battery: ");
            result.Append(this.Battery);
            result.Append("; Display - ");
            result.Append(this.display);

            return result.ToString();
        }
        public GSM(string model, string manufacturer, double? price, string owner, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
            callHistory = new List<Call>();
        }
        public GSM(string model, string manufacturer)
            : this(model, manufacturer, null, null, null, null)
        {

        }
        public void AddCall(Call call) {
            this.CallHistory.Add(call);
        }
        public void DeleteCall(int index) {
            
            this.CallHistory.RemoveAt(index);
        }
        public void ClearHistory() { 
            this.CallHistory.Clear();
        }
        public decimal CallPrice(Call call, decimal price) {
            return (call.Duration / 60) * price;
        }

    }
}
