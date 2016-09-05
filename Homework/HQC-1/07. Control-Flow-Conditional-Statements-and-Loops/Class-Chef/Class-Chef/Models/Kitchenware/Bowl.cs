namespace ClassChef.Models.Kitchenware
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    public class Bowl : ICookware
    {
        private const int DefaultCapacity = 10;

        private readonly int capacity;

        private IList<IVegetable> vegetablesInBowl;

        public Bowl() : this(DefaultCapacity)
        {
        }

        public Bowl(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Capacity cannot be negative!");
            }

            this.vegetablesInBowl = new List<IVegetable>();
            this.capacity = capacity;
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        public void Add(IVegetable vegetable)
        {
            if (this.vegetablesInBowl.Count > this.Capacity)
            {
                throw new ArgumentOutOfRangeException("The bowl has reached it's capacity!");
            }

            this.vegetablesInBowl.Add(vegetable);
        }
    }
}