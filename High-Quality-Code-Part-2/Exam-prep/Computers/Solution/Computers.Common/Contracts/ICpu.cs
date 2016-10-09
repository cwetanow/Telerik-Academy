namespace Computers.Common.Contracts
{
    public interface ICpu
    {
        byte NumberOfCores { get; }

        void AttachToMotherboard(IMotherboard motherboard);

        void GenerateRandom(int maxValue, int minValue);

        void SquareNumber();
    }
}
