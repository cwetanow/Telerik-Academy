using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NamingIdentifiers.Make_Chuek.Enumerations;

namespace NamingIdentifiers.Make_Chuek.Models
{
    public class Human
    {
        public GenderType Gender { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
