namespace Cars.Data
{
    using System.Collections.Generic;

    using Cars.Contracts;
    using Cars.Models;

    public class Database : IDatabase
    {
        public IList<Car> Cars { get; set; }
        // Added this constructor, otherwise never initialises Cars
        public Database()
        {
            this.Cars = new List<Car>();
        }
    }
}
