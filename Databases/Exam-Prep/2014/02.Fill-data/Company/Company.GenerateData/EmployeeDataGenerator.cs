using System.Collections.Generic;
using System.Linq;
using Company.Data;

namespace Company.GenerateData
{
    public class EmployeeDataGenerator : IDataGenerator
    {
        public void GenerateData(CompanyEntities data, IRandomGenerator random, int count)
        {
            var allEmployees = new List<Employee>();

            for (var i = 0; i < count; i++)
            {
                var employee = new Employee
                {
                    DepartmentId = random.GetRandomNumber(1, data.Departments.Count()),
                    Firstname = random.GetRandomString(random.GetRandomNumber(5, 20)),
                    Lastname = random.GetRandomString(random.GetRandomNumber(5, 20)),
                    Salary = random.GetRandomNumber(50000, 200000)
                };

                if (allEmployees.Any() && random.GetRandomNumber(1, 100) <= 95)
                {
                    employee.Employee1 = allEmployees[random.GetRandomNumber(0, data.Employees.Count() - 1)];
                }

                allEmployees.Add(employee);
            }

            data.Employees.AddRange(allEmployees);
        }
    }
}
