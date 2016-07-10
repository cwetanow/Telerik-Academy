using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class AncientBehemoth : Creature
    {
        public AncientBehemoth() : base(19, 19, 300, 40m)
        {
            AddSpecialty(new ReduceEnemyDefenseByPercentage(80));
            AddSpecialty(new DoubleDefenseWhenDefending(5));

        }
    }
}
