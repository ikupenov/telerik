namespace ShapesTask.Shapes
{
    using ShapesTask.Shapes.Abstract;

    public class Square : Shape
    {
        public Square(double side) : base(side, side) { }

        public override double CalculateSurface()
        {
            base.Surface = base.Width * base.Height;
            return base.Surface;
        }
    }
}
