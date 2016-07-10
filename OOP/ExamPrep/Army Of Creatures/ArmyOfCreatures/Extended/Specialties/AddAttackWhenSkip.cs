using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Specialties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyOfCreatures.Extended.Specialties
{
    public class AddAttackWhenSkip:Specialty
    {
        private int attack;
        public AddAttackWhenSkip(int att)
        {
            if (att<1 || att>10)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.attack = att;
        }
        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0}({1})",
                base.ToString(),
                this.attack);
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
            if (skipCreature == null)
            {
                throw new ArgumentNullException("skipCreature");
            }
            skipCreature.PermanentAttack += this.attack;
        }
    }
}
