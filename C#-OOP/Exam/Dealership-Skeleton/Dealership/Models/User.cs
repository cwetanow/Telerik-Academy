using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Common.Enums;
using Dealership.Common;
using Dealership.Engine;

namespace Dealership.Models
{
    public class User : IUser
    {
        private string firstName;
        private string lastName;
        private string password;
        private string username;

        public User(string first, string last, string pass, string username, Role role)
        {
            this.FirstName = first;
            this.LastName = last;
            this.Password = pass;
            this.Username = username;
            this.Role = role;
            this.Vehicles = new List<IVehicle>();
        }
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            protected set
            {
                Validator.ValidateNull(value, Constants.UserCannotBeNull);
                Validator.ValidateIntRange(value.Length, Constants.MinNameLength, Constants.MaxNameLength,
                     string.Format(Constants.StringMustBeBetweenMinAndMax, "Firstname", Constants.MinNameLength, Constants.MaxNameLength));
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            protected set
            {
                Validator.ValidateNull(value, Constants.UserCannotBeNull);
                Validator.ValidateIntRange(value.Length, Constants.MinNameLength, Constants.MaxNameLength,
                     string.Format(Constants.StringMustBeBetweenMinAndMax, "Lastname", Constants.MinNameLength, Constants.MaxNameLength));
                this.lastName = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            protected set
            {
                Validator.ValidateNull(value, Constants.UserCannotBeNull);
                Validator.ValidateIntRange(value.Length, Constants.MinPasswordLength, Constants.MaxPasswordLength,
                     string.Format(Constants.StringMustBeBetweenMinAndMax, "Password", Constants.MinPasswordLength, Constants.MaxPasswordLength));
                Validator.ValidateSymbols(value, Constants.PasswordPattern, string.Format(Constants.InvalidSymbols, "Password"));
                this.password = value;
            }
        }

        public Role Role
        {
            get; protected set;
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            protected set
            {
                Validator.ValidateNull(value, Constants.UserCannotBeNull);
                Validator.ValidateIntRange(value.Length, Constants.MinNameLength, Constants.MaxNameLength,
                     string.Format(Constants.StringMustBeBetweenMinAndMax, "Username", Constants.MinNameLength, Constants.MaxNameLength));
                Validator.ValidateSymbols(value, Constants.UsernamePattern, string.Format(Constants.InvalidSymbols, "Username"));
                this.username = value;
            }
        }

        public IList<IVehicle> Vehicles
        {
            get; protected set;
        }

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            vehicleToAddComment.Comments.Add(commentToAdd);
           
        }

        public void AddVehicle(IVehicle vehicle)
        {
            if (this.Role == Role.Admin)
            {
                throw new InvalidOperationException(Constants.AdminCannotAddVehicles);
            }
            else
            {
                if (this.Vehicles.Count==5  && this.Role != Role.VIP)
                {
                    throw new InvalidOperationException(string.Format(Constants.NotAnVipUserVehiclesAdd,Constants.MaxVehiclesToAdd));
                }
                else
                {                    
                    this.Vehicles.Add(vehicle);                    
                }
            }
           
        }

        public string PrintVehicles()
        {
            var builder = new StringBuilder();
            builder.AppendLine(string.Format("--USER {0}--", this.Username));
            if (this.Vehicles.Count == 0)
            {
                builder.Append("--NO VEHICLES--");
                return builder.ToString();
            }
            for (int i = 1; i <= this.Vehicles.Count; i++)
            {
                if (i == this.Vehicles.Count)
                {
                    builder.Append(i.ToString() + ". " + this.Vehicles[i - 1]);
                }
                else
                {
                    builder.AppendLine(i.ToString() + ". " + this.Vehicles[i - 1]);
                }
            }
            return builder.ToString();
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {            
            if (this.username.Equals(commentToRemove.Author))
            {
                vehicleToRemoveComment.Comments.Remove(commentToRemove);
            }
            else
            {
                throw new InvalidOperationException(Constants.YouAreNotTheAuthor);               
            }
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            this.Vehicles.Remove(vehicle);
        }

        public override string ToString()
        {
            return string.Format("Username: {0}, FullName: {1} {2}, Role: {3}",
                this.Username, this.FirstName, this.LastName, this.Role);
        }
    }
}
