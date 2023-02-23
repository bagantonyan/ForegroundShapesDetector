using ForegroundShapesDetector.Library.Models.Abstractions;

namespace ForegroundShapesDetector.Library.Models.Shapes
{
    public class Rectangle : ShapeBase, IHasSides
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
            get { return topLeftPoint; }
            set
            {
                if (value is null)
                    throw new ArgumentNullException("Rectangle's center point can't be null");
                topLeftPoint = value;
            }
        }

        public double Width
        {
            get { return width; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Rectangle's width must be greater than 0");
                width = value;
            }
        }

        public double Height
        {
            get { return height; }
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

        public sealed override double GetArea()
        {
            return Width * Height;
        }

        protected sealed override bool WithLineSegment(LineSegment line)
            => ShapesOverlapHelper.LineSegmentWithRectangle(line, this);

        protected sealed override bool WithTriangle(Triangle triangle)
            => ShapesOverlapHelper.TriangleWithRectangle(triangle, this);

        protected sealed override bool WithRectangle(Rectangle rectangle)
            => ShapesOverlapHelper.RectangleWithRectangle(this, rectangle);

        protected sealed override bool WithCircle(Circle circle)
            => ShapesOverlapHelper.CircleWithRectangle(circle, this);
    }
}
