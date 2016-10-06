namespace Computers.Common.Contracts
{
    public interface IRam
    {
        int MaxAmount
        {
            get; set;
        }

        void SaveValue(int newValue);

        int LoadValue();
    }
}
