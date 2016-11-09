using System;
using System.Linq;
using Computers.Data;

namespace Computers.DataGenerator
{
    public class CpuDataGenerator : IDataGenerator
    {
        public void GenerateData(ComputersEntities data, IRandomGenerator random, int count)
        {
            var vendorIds = data.Vendors
                  .Select(x => x.VendorId)
                  .ToList();

            for (var i = 0; i < count; i++)
            {
                var cpu = new Cpu
                {
                    VendorId = vendorIds[random.GetRandomNumber(0, vendorIds.Count - 1)],
                    Model = random.GetRandomString(random.GetRandomNumber(1, 30)),
                    ClockCyclesInGhz = (double)random.GetRandomNumber(1, 40) / random.GetRandomNumber(1, 20),
                    NumberOfCores = random.GetRandomNumber(1, 32)
                };

                data.Cpus.Add(cpu);
            }
        }
    }
}
