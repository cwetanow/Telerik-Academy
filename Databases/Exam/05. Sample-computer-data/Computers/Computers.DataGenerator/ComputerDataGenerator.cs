using System;
using System.Collections.Generic;
using System.Linq;
using Computers.Data;

namespace Computers.DataGenerator
{
    public class ComputerDataGenerator : IDataGenerator
    {
        public void GenerateData(ComputersEntities data, IRandomGenerator random, int count)
        {
            var vendorIds = data.Vendors
                  .Select(x => x.VendorId)
                  .ToList();

            var cpuIds = data.Cpus
                .Select(x => x.CpuId)
                .ToList();

            var allGpus = data.Gpus
                .ToList();

            var allStorageDevices = data.StorageDevices
                .ToList();

            for (var i = 0; i < count; i++)
            {
                var computer = new Computer()
                {
                    VendorId = vendorIds[random.GetRandomNumber(0, vendorIds.Count - 1)],
                    Model = random.GetRandomString(random.GetRandomNumber(1, 30)),
                    CpuId = cpuIds[random.GetRandomNumber(1, cpuIds.Count - 1)],
                    MemoryInGb = random.GetRandomNumber(1, 64),
                    Type = i < count / 3 ? "ultrabook" : i > (count / 3) * 2 ? "notebook" : "desktop",
                };

                var gpuCount = random.GetRandomNumber(1, 5);

                for (var j = 0; j < gpuCount; j++)
                {
                    computer.Gpus.Add(allGpus[random.GetRandomNumber(0, allGpus.Count - 1)]);
                }
                var storageDevicesCount = random.GetRandomNumber(1, 5);

                for (var j = 0; j < storageDevicesCount; j++)
                {
                    computer.StorageDevices.Add(allStorageDevices[random.GetRandomNumber(0, allStorageDevices.Count - 1)]);
                }
                
                data.Computers.Add(computer);
            }
        }
    }
}
