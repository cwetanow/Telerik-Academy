namespace Company.DataGenerator.Contracts
{
    public interface IRandomGenerator
    {
        int GetNumber(int min, int max);

        string GetString(int minLen, int maxLen);
    }
}
