namespace ClassChef.Models.Vegetables
{
    using System;

    using Contracts;

    public abstract class Vegetable : IVegetable
    {
        private bool isCut;
        private bool isPeeled;

        protected Vegetable() : this(false, false)
        {
        }

        protected Vegetable(bool isPeeled, bool isCut)
        {
            this.IsCut = isCut;
            this.IsPeeled = isPeeled;
        }

        public bool IsCut
        {
            get
            {
                return this.isCut;
            }

            set
            {
                if (this.isCut && !value)
                {
                    throw new ArgumentException("The vegetable has been cut already!");
                }

                this.isCut = value;
            }
        }

        public bool IsPeeled
        {
            get
            {
                return this.isPeeled;
            }

            set
            {
                if (this.isPeeled && !value)
                {
                    throw new ArgumentException("The vegetable has been peeled already!");
                }

                this.isCut = value;
            }
        }
    }
}