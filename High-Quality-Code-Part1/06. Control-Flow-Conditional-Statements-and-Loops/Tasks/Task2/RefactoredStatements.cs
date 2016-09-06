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
                var potatoCanBeCooked = !potato.HasNotBeenPeeled && !potato.IsRotten;
                if (potatoCanBeCooked)
                {
                    this.Cook(potato);
                }
            }
        }

        public void SecondStatement(int x, int y, bool canBeVisited)
        {
            var minX = 0;
            var minY = 0;
            var maxX = 10;
            var maxY = 10;
            var canVisitCell = canBeVisited;

            var xIsInRange = (x >= minX && x <= maxX);
            var yIsInRange = (y >= minY && y <= maxY);


            if (canVisitCell && xIsInRange && yIsInRange)
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
