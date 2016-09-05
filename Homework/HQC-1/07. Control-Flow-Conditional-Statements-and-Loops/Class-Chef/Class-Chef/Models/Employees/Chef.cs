namespace ClassChef.Models.Employees
{
    using System.Collections.Generic;

    using Contracts;
    using Kitchenware;
    using Meals;
    using Vegetables;

    public class Chef
    {
        public IMeal Cook(IEnumerable<IIngredient> ingredients)
        {
            var potato = this.GetPotato();
            this.Peel(potato);
            this.Cut(potato);

            var carrot = this.GetCarrot();
            this.Peel(carrot);
            this.Cut(carrot);

            var bowl = this.GetBowl();
            bowl.Add(carrot);
            bowl.Add(potato);

            IMeal meal = new Lasagne();

            return meal;
        }

        private Bowl GetBowl()
        {
            var bowl = new Bowl();

            return bowl;
        }

        private Carrot GetCarrot()
        {
            var carrot = new Carrot();

            return carrot;
        }

        private Potato GetPotato()
        {
            var potato = new Potato();

            return potato;
        }

        private void Cut(IVegetable vegetable)
        {
            vegetable.IsCut = true;
        }

        private void Peel(IVegetable vegetable)
        {
            vegetable.IsPeeled = true;
        }
    }
}