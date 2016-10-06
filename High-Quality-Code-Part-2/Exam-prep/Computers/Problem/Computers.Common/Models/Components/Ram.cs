using Computers.Common.Contracts;

namespace Computers.Common.Models.Components
{
    public class Ram : IRam
    {
        private int value;

        public Ram(int amount)
        {
            this.MaxAmount = amount;
        }

        public int MaxAmount
        {
            get; set;
        }

        public void SaveValue(int newValue)
        {
            this.value = newValue;
        }

        public int LoadValue()
        {
            return this.value;
        }
    }
}
