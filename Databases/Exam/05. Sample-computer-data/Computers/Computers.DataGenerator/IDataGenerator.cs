using Computers.Data;

namespace Computers.DataGenerator
{
    public interface IDataGenerator
    {
        void GenerateData(ComputersEntities data, IRandomGenerator random, int count);

    }
}