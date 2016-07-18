using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    class Supplement : ISupplement
    {

        public Supplement(int agg, int hp, int powa)
        {
            this.AggressionEffect = agg;
            this.HealthEffect = hp;
            this.PowerEffect = powa;
        }
        public int AggressionEffect
        {
            get; protected set;
        }

        public int HealthEffect
        {
            get; protected set;
        }

        public int PowerEffect
        {
            get; protected set;
        }

        public virtual void ReactTo(ISupplement otherSupplement) { }
        
    }
}
