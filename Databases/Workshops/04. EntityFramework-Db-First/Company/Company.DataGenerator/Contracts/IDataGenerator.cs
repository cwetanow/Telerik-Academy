using Company.Data;

namespace Company.DataGenerator.Contracts
{
    public interface IDataGenerator
    {
        void GenerateData(CompanyEntities context, IRandomGenerator random, int count);
    }
}
