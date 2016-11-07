using System;
using System.Linq;
using Company.Data;

namespace Company.GenerateData
{
    public class EmployeesInProjectsDataGenerator : IDataGenerator
    {
        public void GenerateData(CompanyEntities data, IRandomGenerator random, int count)
        {
            var employeeIds = data.Employees.Select(x => x.EmployeeId);
            var projectIds = data.Projects.Select(x => x.ProjectId).ToList();

            foreach (var employee in employeeIds)
            {
                var employeeProjects = random.GetRandomNumber((int)count / 2, (int)(count * 1.5));

                for (var i = 0; i < employeeProjects; i++)
                {
                    var projectId = projectIds[random.GetRandomNumber(1, projectIds.Count - 1)];

                    var startDate = DateTime.Now.AddDays(-random.GetRandomNumber(-500, 1000));
                    var endDate = startDate.AddDays(random.GetRandomNumber(1, 1234));

                    var employeeInProj = new Employees_Projects
                    {
                        ProjectId = projectId,
                        Startdate = startDate,
                        Enddate = endDate,
                        EmployeeId = employee
                    };

                    data.Employees_Projects.Add(employeeInProj);
                }
            }
        }
    }
}