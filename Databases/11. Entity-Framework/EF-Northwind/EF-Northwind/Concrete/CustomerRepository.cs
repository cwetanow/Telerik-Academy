using System;
using System.Linq;

namespace EF_Northwind.Concrete
{
    public class CustomerRepository
    {
        private readonly NorthwindEntities dbContext;

        public CustomerRepository(NorthwindEntities context)
        {
            this.dbContext = context;
        }

        public void AddCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException();
            }

            this.dbContext.Customers.Add(customer);

            this.Save();
        }

        public void ChangeCustomer(string customerId, Customer customer)
        {
            var customerToChange = this.dbContext.Customers.Find(customerId);

            if (customerToChange == null)
            {
                throw new ArgumentNullException();
            }

            customerToChange.City = customer.City;
            customerToChange.CompanyName = customer.CompanyName;
            customerToChange.Region = customer.Region;
            customerToChange.ContactName = customer.ContactName;
            customerToChange.ContactTitle = customer.ContactTitle;
            customerToChange.Country = customer.Country;
            customerToChange.CustomerDemographics = customer.CustomerDemographics;
            customerToChange.Fax = customer.Fax;
            customerToChange.Orders = customer.Orders;
            customerToChange.Phone = customer.Phone;
            customerToChange.PostalCode = customer.PostalCode;

            this.Save();
        }

        public void RemoveCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException();
            }

            this.dbContext.Customers.Remove(customer);

            this.Save();
        }

        private void Save()
        {
            this.dbContext.SaveChanges();
        }
    }
}
