using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NamingIdentifiers.Make_Chuek.Enumerations;
using NamingIdentifiers.Make_Chuek.Models;

namespace NamingIdentifiers.Make_Chuek
{
    public class HumanCreator
    {
        public void CreateHuman(int age)
        {
            var human = new Human();
            human.Age = age;

            if (age%2==0)
            {
                human.Name = "Batkata";
                human.Gender = GenderType.Male;
            }
            else
            {
                human.Name = "Mackata";
                human.Gender=GenderType.Female;
            }
        }
    }
}
