namespace CohesionAndCoupling.Models
{
    using System;

    using Contracts;

    public abstract class Shape2D : IShape2D
    {
        private double width;
        private double height;

        protected Shape2D(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Width cannot be less than 0!");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Height cannot be less than 0!");
                }

                this.height = value;
            }
        }
    }
}