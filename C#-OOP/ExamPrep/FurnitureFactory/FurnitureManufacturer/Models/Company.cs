using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;

        public Company(string name, string regnum)
        {
            this.Name = name;
            this.RegistrationNumber = regnum;
            this.Furnitures = new List<IFurniture>();
        }
        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return this.furnitures;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.furnitures = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length < 5 || value == null)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }
            private set
            {
                if (value.Length != 10 || value == null)
                {
                    throw new ArgumentNullException();
                }
                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsDigit(value[i]))
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                this.registrationNumber = value;
            }
        }

        public void Add(IFurniture furniture)
        {
            this.Furnitures.Add(furniture);
            
        }

        public string Catalog()
        {
            var builder = new StringBuilder();
            this.Furnitures = this.Furnitures.OrderBy(x => x.Price).ThenBy(x => x.Model).Select(x => x).ToList();
            builder.AppendLine(
                string.Format("{0} - {1} - {2} {3}",
                            this.Name,
                            this.RegistrationNumber,
                            this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                            this.Furnitures.Count != 1 ? "furnitures" : "furniture"
                ));

            for (int i = 0; i < this.Furnitures.Count; i++)
            {
                
                if (i==this.furnitures.Count-1)
                {
                    builder.Append(this.Furnitures.ElementAt(i).ToString());
                }
                else
                {
                    builder.AppendLine(this.Furnitures.ElementAt(i).ToString());
                }
            }
            
            return builder.ToString();
        }

        public IFurniture Find(string model)
        {
            var fur = this.Furnitures.Where(x => x.Model.ToLower() == model.ToLower()).Select(x => x);
            
            return fur.FirstOrDefault();
        }

        public void Remove(IFurniture furniture)
        {
            this.Furnitures.Remove(furniture);
        }
    }
}
