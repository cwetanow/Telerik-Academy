using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    class Weapon : Supplement
    {
        public Weapon() : base(0,0,0)
        {
            
        }
        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement.GetType().Name=="WeaponrySkill")
            {
                this.AggressionEffect = 3;
                this.HealthEffect = 0;
                this.PowerEffect = 10;
            }
        }
    }
}
