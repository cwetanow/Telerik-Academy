using System.Collections.Generic;
using Company.Data;
using Company.DataGenerator.Contracts;

namespace Company.DataGenerator.Generators
{
    public class DepartmentGenerator : IDataGenerator
    {
        public void GenerateData(CompanyEntities context, IRandomGenerator random, int count)
        {
            for (var i = 0; i < count; i++)
            {
                var name = random.GetString(10, 50);

                var department = new Department
                {
                    Name = name
                };

                context.Departments.Add(department);
            }
        }
    }
}
