namespace CohesionAndCoupling.Contracts
{
    public interface IShape3D : IShape2D
    {
        double Depth { get; }
    }
}