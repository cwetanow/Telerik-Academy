using System;
using Company.Data;
using Company.DataGenerator.Contracts;

namespace Company.DataGenerator.Generators
{
    public class ReportGenerator : IDataGenerator
    {
        public void GenerateData(CompanyEntities context, IRandomGenerator random, int count)
        {
        }
    }
}
