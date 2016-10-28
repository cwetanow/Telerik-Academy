using System.Data.Linq;

namespace EF_Northwind
{
    public partial class Employee
    {
        public EntitySet<Territory> TerritoriesSet
        {
            get
            {
                var territories = new EntitySet<Territory>();
                territories.AddRange(this.Territories);

                return territories;
            }
        }
    }
}
