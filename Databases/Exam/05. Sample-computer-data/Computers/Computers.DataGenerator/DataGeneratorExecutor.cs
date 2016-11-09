using Computers.Data;

namespace Computers.DataGenerator
{
    public class DataGeneratorExecutor
    {
        private readonly IDataGenerator dataGenerator;

        private readonly int entriesCount;

        public DataGeneratorExecutor(IDataGenerator dataGenerator, int entriesCount)
        {
            this.dataGenerator = dataGenerator;
            this.entriesCount = entriesCount;
        }

        public void Execute(ComputersEntities data, IRandomGenerator randomGenerator)
        {
            this.dataGenerator.GenerateData(data, randomGenerator, this.entriesCount);
        }
    }
}
