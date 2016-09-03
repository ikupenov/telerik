namespace ClassSize
{
    using System;

    public class Rectangle
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Width cannot be less than 1");
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
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Height cannot be less than 1");
                }

                this.height = value;
            }
        }

        public static Rectangle GetRotatedSize(Rectangle rectangle, double rotationAngle)
        {
            var rotationAngleSinus = Math.Abs(Math.Sin(rotationAngle));
            var rotationAngleCosinus = Math.Abs(Math.Cos(rotationAngle));

            double width = (rotationAngleSinus * rectangle.Width) +
                (rotationAngleSinus * rectangle.Height);

            double height = (rotationAngleCosinus * rectangle.Width) +
                (rotationAngleSinus * rectangle.Height);

            var rotatedRectangle = new Rectangle(width, height);

            return rotatedRectangle;
        }
    }
}