using ForegroundShapesDetector.Library.Models.Abstractions;

namespace ForegroundShapesDetector.Library.Models.Shapes
{
    public class Circle : ShapeBase
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
            get => center;
            private set
            {
                if (value is null)
                    throw new ArgumentNullException("Circle's center point can't be null");
                center = value;
            }
        }

        public double Radius
        {
            get => radius;
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Circle's radius must be greater than 0");
                radius = value;
            }
        }

        public override double GetSquare() => Math.PI * Math.Pow(Radius, 2);
    }
}