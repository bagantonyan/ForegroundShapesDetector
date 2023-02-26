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

            SetSides();
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

        private void SetSides()
        {
            Point b = new Point(topLeftPoint.X + Width, topLeftPoint.Y);
            Point c = new Point(b.X, b.Y - Height);
            Point d = new Point(c.X - Width, c.Y);

            Sides = new LineSegment[4]
            {
                new LineSegment(topLeftPoint, b),
                new LineSegment(b, c),
                new LineSegment(c, d),
                new LineSegment(d, topLeftPoint),
            };
        }
    }
}
