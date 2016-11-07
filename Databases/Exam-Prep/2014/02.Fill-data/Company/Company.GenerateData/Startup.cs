using System.Collections.Generic;
using Company.Data;

namespace Company.GenerateData
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var dataGeneratorExecutors = new List<DataGeneratorExecutor>
                                             {
                                                 new DataGeneratorExecutor(new DepartmentDataGenerator(), 100),
                                                 new DataGeneratorExecutor(new EmployeeDataGenerator(), 5000),
                                                 new DataGeneratorExecutor(new ProjectDataGenerator(), 1000),
                                                 new DataGeneratorExecutor(new EmployeesInProjectsDataGenerator(), 10), // per employee
                                                 new DataGeneratorExecutor(new ReportsDataGenerator(), 50), // per employee
                                             };

            foreach (var dataGeneratorExecutor in dataGeneratorExecutors)
            {
                using (var data = new CompanyEntities())
                {
                    data.Configuration.AutoDetectChangesEnabled = false;

                    dataGeneratorExecutor.Execute(data, RandomGenerator.Instance);
                    data.SaveChanges();
                }
            }
        }
    }
}
