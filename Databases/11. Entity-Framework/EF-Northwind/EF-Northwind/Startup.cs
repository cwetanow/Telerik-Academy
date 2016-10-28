using System;
using System.Collections.Generic;
using System.Linq;

namespace EF_Northwind
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            // 01. Using the Visual Studio Entity Framework designer create a DbContext for the Northwind database
            var context = new NorthwindEntities();

            // 03. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
            var customersWithMethod = CustomersWithOrdersIn97AndFromCanada(context).ToList();

            PrintCustomers(customersWithMethod);

            // 04. Implement previous by using native SQL query and executing it through the DbContext.
            var query = @"
                        SELECT DISTINCT c.ContactName
                        FROM Orders o
                        JOIN Customers c
                        ON o.CustomerID=c.CustomerID
                        WHERE YEAR(o.OrderDate)=1997 AND
                        o.ShipCountry='Canada' ";

            var customersWithQuery = context.Database.SqlQuery<string>(query).ToList();

            foreach (var customer in customersWithQuery)
            {
                Console.WriteLine(customer);
            }

            // 05. Write a method that finds all the sales by specified region and period (start / end dates).
            var orders = OrdersByRegionAndDate("RJ", new DateTime(1222, 12, 23), DateTime.Now, context).ToList();

            // 07. Try to open two different data contexts and perform concurrent changes on the same records.
            ConcurrentChanges(context);

            // 08. By inheriting the Employee entity class create a class which allows employees to access their corresponding territories as property of type EntitySet<T>.
            // Set is in class ExtendedEmployee !
        }

        public static IEnumerable<Customer> CustomersWithOrdersIn97AndFromCanada(NorthwindEntities context)
        {
            var result =
                context.Orders
                    .Where(x => x.OrderDate.Value.Year == 1997 && x.ShipCountry == "Canada")
                    .Select(x => x.Customer)
                    .Distinct();

            return result;
        }

        public static IEnumerable<Order> OrdersByRegionAndDate(string region, DateTime startDate, DateTime endDate, NorthwindEntities context)
        {
            var orders = context.Orders
                .Where(x => x.ShipRegion == region && x.OrderDate > startDate && x.OrderDate < endDate);

            return orders;
        }

        public static void ConcurrentChanges(NorthwindEntities firstContext)
        {
            /*
             The second context overrides the first one.
             Pessimistic concurency can be used so the changes are in the db.
             In order for everything to be consistent you can use transactions.
             */

            firstContext.Orders.FirstOrDefault().OrderDate = DateTime.Now;

            var secondContext = new NorthwindEntities();
            secondContext.Orders.FirstOrDefault().OrderDate = DateTime.Now;

            firstContext.SaveChanges();
            secondContext.SaveChanges();
        }

        private static void PrintCustomers(IEnumerable<Customer> customers)
        {
            foreach (var item in customers)
            {
                Console.WriteLine(item.ContactName);
            }
        }
    }
}
