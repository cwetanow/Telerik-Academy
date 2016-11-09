using System.Collections.Generic;
using Computers.Data;

namespace Computers.DataGenerator
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            // Run the script to create the db
            var dataGeneratorExecutors = new List<DataGeneratorExecutor>
                                             {
                                                 new DataGeneratorExecutor(new VendorDataGenerator(), 50),
                                                 new DataGeneratorExecutor(new StorageDevicesDataGenerator(),30 ),
                                                 new DataGeneratorExecutor(new CpuDataGenerator(), 10 ),
                                                 new DataGeneratorExecutor(new GpuDataGenerator(), 15 ),
                                                 new DataGeneratorExecutor(new ComputerDataGenerator(), 50 )
                                                };

            foreach (var dataGeneratorExecutor in dataGeneratorExecutors)
            {
                using (var data = new ComputersEntities())
                {
                    data.Configuration.AutoDetectChangesEnabled = false;

                    dataGeneratorExecutor.Execute(data, RandomGenerator.Instance);
                    data.SaveChanges();
                }
            }
        }
    }
}
