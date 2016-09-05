namespace CohesionAndCoupling.Models
{
    using System;

    using Contracts;

    public abstract class Shape3D : IShape3D
    {
        private double width;
        private double height;
        private double depth;

        protected Shape3D(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
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

        public double Depth
        {
            get
            {
                return this.depth;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Depth cannot be lesss than 0!");
                }

                this.depth = value;
            }
        }
    }
}