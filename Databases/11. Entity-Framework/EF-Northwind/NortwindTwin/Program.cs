using EF_Northwind;

namespace NortwindTwin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new NorthwindEntities();

            context.Database.CreateIfNotExists();
        }
    }
}
