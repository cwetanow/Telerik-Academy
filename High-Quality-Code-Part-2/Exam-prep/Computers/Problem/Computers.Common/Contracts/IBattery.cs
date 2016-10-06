namespace Computers.Common.Contracts
{
    public interface IBattery
    {
        int PercentagePowerLeft { get; }

        void Charge(int percentage);
    }
}
