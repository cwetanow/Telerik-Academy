namespace FurnitureManufacturer.Engine.Factories
{
    using Interfaces;
    using Interfaces.Engine;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class CompanyFactory : ICompanyFactory
    {
        public ICompany CreateCompany(string name, string registrationNumber)
        {
            ICompany company = new Company(name, registrationNumber);
            return company;
        }
        
    }
}
