using Company.Data;

namespace Company.GenerateData
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

        public void Execute(CompanyEntities data, IRandomGenerator randomGenerator)
        {
            this.dataGenerator.GenerateData(data, randomGenerator, this.entriesCount);
        }
    }
}
