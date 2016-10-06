using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    class InfestationSpores : Supplement
    {
        public InfestationSpores() : base(20, 0, -1)
        {

        }
        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement.GetType().Name == "InfestationSpores")
            {
                this.AggressionEffect = 0;
                this.HealthEffect = 0;
                this.PowerEffect = 0;
            }
        }
    }
}
