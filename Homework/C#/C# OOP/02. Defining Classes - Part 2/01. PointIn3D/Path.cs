namespace PointIn3D
{
    using System.Collections.Generic;
    using System.Text;

    public class Path
    {
        private static List<Point3D> sequenceOfPoints;

        static Path()
        {
            sequenceOfPoints = new List<Point3D>();
        }

        public static List<Point3D> SequenceOfPoints
        {
            get { return sequenceOfPoints; }
        }

        public static void AddPoint(Point3D point)
        {
            sequenceOfPoints.Add(point);
        }

        public static void RemovePoint(Point3D point)
        {
            sequenceOfPoints.Remove(point);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            foreach (var point in sequenceOfPoints)
            {
                builder.AppendLine(point.ToString());
            }

            return base.ToString();
        }
    }
}
