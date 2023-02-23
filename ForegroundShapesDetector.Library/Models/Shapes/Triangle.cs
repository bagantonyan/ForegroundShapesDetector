using ForegroundShapesDetector.Library.Models.Abstractions;

namespace ForegroundShapesDetector.Library.Models.Shapes
{
    public class Triangle : ShapeBase, IHasSides
    {
        private Point a;
        private Point b;
        private Point c;
        private LineSegment[] sides;

        public Triangle(Point a, Point b, Point c)
        {
            A = a;
            B = b;
            C = c;

            CheckTriangleIsValid();

            Sides = new LineSegment[3]
            {
                new LineSegment(a, b),
                new LineSegment(a, c),
                new LineSegment(b, c),
            };
        }

        public Point A
        {
            get { return a; }
            private set
            {
                if (value is null)
                    throw new ArgumentNullException("Triangle's point can't be null");
                a = value;
            }
        }

        public Point B
        {
            get { return b; }
            private set
            {
                if (value is null)
                    throw new ArgumentNullException("Triangle's point can't be null");
                b = value;
            }
        }

        public Point C
        {
            get { return c; }
            private set
            {
                if (value is null)
                    throw new ArgumentNullException("Triangle's point can't be null");
                c = value;
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
            return Math.Abs((A.X * (B.Y - C.Y)
                           + B.X * (C.Y - A.Y)
                           + C.X * (A.Y - B.Y))
                           / 2);
        }

        protected sealed override bool WithLineSegment(LineSegment line)
            => ShapesOverlapHelper.LineSegmentWithTriangle(line, this);

        protected sealed override bool WithTriangle(Triangle triangle)
            => ShapesOverlapHelper.TriangleWithTriangle(this, triangle);

        protected sealed override bool WithRectangle(Rectangle rectangle)
            => ShapesOverlapHelper.TriangleWithRectangle(this, rectangle);

        protected sealed override bool WithCircle(Circle circle)
            => ShapesOverlapHelper.CircleWithTriangle(circle, this);

        private void CheckTriangleIsValid()
        {
            double triangleArea = GetArea();

            if (triangleArea == 0)
                throw new ArgumentException("Invalid triangle");
        }
    }
}