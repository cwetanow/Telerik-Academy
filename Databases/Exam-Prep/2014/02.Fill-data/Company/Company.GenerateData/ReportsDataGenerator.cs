using System;
using System.Linq;
using Company.Data;

namespace Company.GenerateData
{
    public class ReportsDataGenerator : IDataGenerator
    {
        public void GenerateData(CompanyEntities data, IRandomGenerator random, int count)
        {
            var employeeIds = data.Employees.Select(x => x.EmployeeId).ToList();
            foreach (var employee in employeeIds)
            {
                var employeeReports = random.GetRandomNumber((int)count / 2, (int)(count * 1.5));

                for (var i = 0; i < employeeReports; i++)
                {
                    var timeForReport = random.GetRandomNumber(-60 * 24 * 1000, 60 * 24 * 1000);

                    var report = new Report
                    {
                        EmployeeId = employee,
                        ReportTime = DateTime.Now.AddMinutes(timeForReport)
                    };

                    data.Reports.Add(report);
                }
            }
        }
    }
}