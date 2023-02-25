using ForegroundShapesDetector.Library.Models.Abstractions;

namespace ForegroundShapesDetector.Library.Models.Shapes
{
    public class Rectangle : ShapeBase, IShapeHasSides
    {
        private Point topLeftPoint;
        private double width;
        private double height;
        private LineSegment[] sides;

        public Rectangle(Point topLeftPoint, double width, double height)
        {
            TopLeftPoint = topLeftPoint;
            Width = width;
            Height = height;

            Sides = new LineSegment[4]
            {
                new LineSegment(topLeftPoint, new Point(topLeftPoint.X + width, topLeftPoint.Y)),
                new LineSegment(new Point(topLeftPoint.X + width, topLeftPoint.Y), 
                                new Point(topLeftPoint.X + width, topLeftPoint.Y - height)),
                new LineSegment(new Point(topLeftPoint.X + width, topLeftPoint.Y - height), 
                                new Point(topLeftPoint.X, topLeftPoint.Y - height)),
                new LineSegment(new Point(topLeftPoint.X, topLeftPoint.Y - height), topLeftPoint)
            };
        }

        public Point TopLeftPoint
        {
            get => topLeftPoint;
            set
            {
                if (value is null)
                    throw new ArgumentNullException("Rectangle's center point can't be null");
                topLeftPoint = value;
            }
        }

        public double Width
        {
            get => width;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Rectangle's width must be greater than 0");
                width = value;
            }
        }

        public double Height
        {
            get => height;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Rectangle's height must be greater than 0");
                height = value;
            }
        }

        public LineSegment[] Sides
        {
            get
                => (LineSegment[])sides.Clone();
            private set
                => sides = value;
        }

        public sealed override double GetSquare() => Width * Height;
    }
}
