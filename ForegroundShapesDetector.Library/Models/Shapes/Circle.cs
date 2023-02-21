using ForegroundShapesDetector.Library.Models.Interfaces;

namespace ForegroundShapesDetector.Library.Models.Shapes
{
    public class Circle : IShape
    {
        private Point center;
        private double radius;

        public Circle(Point center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public Point Center
        {
            get { return center; }
            set
            {
                if (value is null)
                    throw new ArgumentNullException("Circle's center point can't be null");
                center = value;
            }
        }

        public double Radius
        {
            get { return radius; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Circle's radius must be greater than 0");
                radius = value;
            }
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
