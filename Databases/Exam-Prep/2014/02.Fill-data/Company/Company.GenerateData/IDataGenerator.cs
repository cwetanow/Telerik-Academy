using Company.Data;

namespace Company.GenerateData
{
    public interface IDataGenerator
    {
        void GenerateData(CompanyEntities data, IRandomGenerator random, int count);
    }
}
