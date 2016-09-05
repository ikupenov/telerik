namespace Abstraction.Figures
{
    using System;

    using Contracts;

    public abstract class Figure : IFigure
    {
        public virtual double CalculatePerimeter()
        {
            throw new NotImplementedException();
        }

        public virtual double CalculateSurface()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            var perimeter = this.CalculatePerimeter();
            var surface = this.CalculateSurface();

            string figureToString = $"I am a {this.GetType().Name}. " +
                $"My perimeter is {perimeter:F2}. My surface is {surface:F2}";

            return figureToString;
        }
    }
}