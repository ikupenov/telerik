namespace ShapesTask.Shapes
{
    using ShapesTask.Shapes.Abstract;

    public class Rectangle : Shape
    {
        public Rectangle(double width, double height) : base(width, height) { }

        public override double CalculateSurface()
        {
            base.Surface = base.Width * base.Height;
            return base.Surface;
        }
    }
}
