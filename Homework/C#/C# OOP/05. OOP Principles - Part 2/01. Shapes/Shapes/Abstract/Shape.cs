namespace ShapesTask.Shapes.Abstract
{
    using System;

    public abstract class Shape
    {
        private double width;
        private double height;
        private double surface;

        public Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get { return this.width; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Width can't be equal or less than zero");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height can't be equal or less than zero");
                }

                this.height = value;

            }
        }

        public double Surface
        {
            get { return this.surface; }

            protected set
            {
                this.surface = value;
            }
        }

        public abstract double CalculateSurface();
    }
}
