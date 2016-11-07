using Company.Data;

namespace Company.GenerateData
{
    public class DepartmentDataGenerator : IDataGenerator
    {
        public void GenerateData(CompanyEntities data, IRandomGenerator random, int count)
        {
            for (var i = 0; i < count; i++)
            {
                var department = new Department
                {
                    Name = random.GetRandomString(random.GetRandomNumber(10, 50))
                };

                data.Departments.Add(department);
            }
        }
    }
}
