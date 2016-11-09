using System;
using System.Collections.Generic;
using System.Linq;
using Computers.Data;

namespace Computers.DataGenerator
{
    public class StorageDevicesDataGenerator : IDataGenerator
    {
        public void GenerateData(ComputersEntities data, IRandomGenerator random, int count)
        {
            var vendorIds = data.Vendors
                .Select(x => x.VendorId)
                .ToList();

            for (var i = 0; i < count; i++)
            {
                var device = new StorageDevice
                {
                    VendorId = vendorIds[random.GetRandomNumber(0, vendorIds.Count - 1)],
                    Model = random.GetRandomString(random.GetRandomNumber(1, 30)),
                    SizeInGb = random.GetRandomNumber(1, 256),
                    Type = i%4 == 0 ? "SSD" : "HDD"
                };
                
                data.StorageDevices.Add(device);
            }
        }
    }
}
