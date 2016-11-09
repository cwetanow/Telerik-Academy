using System;
using Computers.Data;

namespace Computers.DataGenerator
{
    public class VendorDataGenerator : IDataGenerator
    {
        public void GenerateData(ComputersEntities data, IRandomGenerator random, int count)
        {
            for (var i = 0; i < count; i++)
            {
                var vendor = new Vendor
                {
                    Name = random.GetRandomString(random.GetRandomNumber(1, 40))
                };

                data.Vendors.Add(vendor);
            }
        }
    }
}
