using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Class_chef.FoodsModels.Abstract
{
    public abstract class Vegetable
    {
        public bool HasNotBeenPeeled { get; set; }

        public bool IsRotten { get; set; }
    }
}
