namespace Computers.Common.Contracts
{
    public interface IHardDrive
    {
        int Capacity { get; }

        void SaveData(int address, string newData);

        string LoadData(int address);
    }
}
