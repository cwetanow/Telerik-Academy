using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1_Class_chef.FoodsModels;

namespace Task2
{
    public class RefactoredStatements
    {
        public void FirstStatement()
        {
            var potato = DigUpPotato();

            if (potato != null)
            {
                if (!potato.HasNotBeenPeeled && !potato.IsRotten)
                {
                    Cook(potato);
                }
            }
        }

        public void SecondStatement(int x, int y, bool canBeVisited)
        {
            var minX = 0;
            var minY = 0;
            var maxX = 10;
            var maxY = 10;
            var shouldNotVisitCell = canBeVisited;

            if (x >= minX && (x <= maxX && ((maxY >= y && minY <= y) && !shouldNotVisitCell)))
            {
                VisitCell();
            }
        }

        private void Cook(Potato potato)
        {

        }

        private Potato DigUpPotato()
        {
            return new Potato();
        }

        private void VisitCell()
        {
            
        }
    }
}
