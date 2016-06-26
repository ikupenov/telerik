namespace ShapesTask.Shapes
{
    using ShapesTask.Shapes.Abstract;

    public class Triangle : Shape
    {
        public Triangle(double width, double height) : base(width, height) { }

        public override double CalculateSurface()
        {
            base.Surface = base.Height * (base.Width / 2);
            return base.Surface;
        }
    }
}
