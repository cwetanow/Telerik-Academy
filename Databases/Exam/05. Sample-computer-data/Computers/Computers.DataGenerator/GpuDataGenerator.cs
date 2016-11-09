using System.Linq;
using Computers.Data;

namespace Computers.DataGenerator
{
    public class GpuDataGenerator : IDataGenerator
    {
        public void GenerateData(ComputersEntities data, IRandomGenerator random, int count)
        {
            var vendorIds = data.Vendors
                .Select(x => x.VendorId)
                .ToList();

            for (var i = 0; i < count; i++)
            {
                var gpu = new Gpu
                {
                    MemoryInGb = random.GetRandomNumber(1, 32),
                    VendorId = vendorIds[random.GetRandomNumber(0, vendorIds.Count - 1)],
                    Model = random.GetRandomString(random.GetRandomNumber(1, 30)),
                    Type = i % 3 == 0 ? "internal" : "external"
                };

                data.Gpus.Add(gpu);
            }
        }
    }
}
