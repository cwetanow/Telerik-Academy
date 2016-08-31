using Task1_Class_chef.FoodsModels;
using Task1_Class_chef.FoodsModels.Abstract;

namespace Task1_Class_chef
{
    public class Chef
    {
        public void Cook()
        {
            var potato = this.GetPotato();
            var carrot = this.GetCarrot();
            var bowl = this.GetBowl();

            this.Peel(potato);
            this.Peel(carrot);

            this.Cut(potato);
            this.Cut(carrot);

            bowl.Add(carrot);
            bowl.Add(potato);
        }

        private Potato GetPotato()
        {
            return new Potato();
        }

        private Bowl GetBowl()
        {
            return new Bowl();
        }

        private Carrot GetCarrot()
        {
            return new Carrot();
        }

        private void Cut(Vegetable potato)
        {
            //...
        }

        private void Peel(Vegetable vegetable)
        {
            // Peel veggie
        }
    }
}
