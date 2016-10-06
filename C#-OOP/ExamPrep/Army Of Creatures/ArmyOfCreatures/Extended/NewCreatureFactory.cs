using ArmyOfCreatures.Extended.Creatures;
using ArmyOfCreatures.Logic.Creatures;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyOfCreatures.Logic
{
   public class NewCreatureFactory : CreaturesFactory
    {
        public override Creature CreateCreature(string name)
        {
            switch (name)
            {
                case "AncientBehemoth":
                    return new AncientBehemoth();
                case "CyclopsKing":
                    return new CyclopsKing();
                case "Goblin":
                    return new Goblin();
                case "Griffin":
                    return new Griffin();
                case "WolfRaider":
                    return new WolfRaider();
                case "Angel":
                    return new Angel();
                case "Archangel":
                    return new Archangel();
                case "ArchDevil":
                    return new ArchDevil();
                case "Behemoth":
                    return new Behemoth();
                case "Devil":
                    return new Devil();
                default:
                    throw new ArgumentException(
                        string.Format(CultureInfo.InvariantCulture, "Invalid creature type \"{0}\"!", name));
            }
        }
    }
}
