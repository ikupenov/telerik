namespace PointIn3D
{
    public struct Point3D
    {
        private static readonly double start = 0;

        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        
        public static double StartPoint
        {
            get
            {
                return start;
            }
        }

        public override string ToString()
        {
            return string.Format(@"{{{0}, {1}, {2}}}", this.X, this.Y, this.Z);
        }
    }
}
