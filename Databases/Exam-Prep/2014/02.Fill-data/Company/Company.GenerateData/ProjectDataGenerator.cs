using Company.Data;

namespace Company.GenerateData
{
    public class ProjectDataGenerator : IDataGenerator
    {
        public void GenerateData(CompanyEntities data, IRandomGenerator random, int count)
        {
            for (var i = 0; i < count; i++)
            {
                var project = new Project
                {
                    Name = random.GetRandomString(random.GetRandomNumber(5, 50))
                };

                data.Projects.Add(project);
            }
        }
    }
}
