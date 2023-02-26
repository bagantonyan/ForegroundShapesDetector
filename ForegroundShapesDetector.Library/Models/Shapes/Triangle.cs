using ForegroundShapesDetector.Library.Models.Abstractions;

namespace ForegroundShapesDetector.Library.Models.Shapes
{
    public class Triangle : ShapeBase, IShapeHasSides
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
            SetSides();
        }

        public Point A
        {
            get => a;
            private set
            {
                if (value is null)
                    throw new ArgumentNullException("Triangle's point can't be null");
                a = value;
            }
        }

        public Point B
        {
            get => b;
            private set
            {
                if (value is null)
                    throw new ArgumentNullException("Triangle's point can't be null");
                b = value;
            }
        }

        public Point C
        {
            get => c;
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

        public sealed override double GetSquare()
            => Math.Abs((A.X * (B.Y - C.Y)
                       + B.X * (C.Y - A.Y)
                       + C.X * (A.Y - B.Y))
                       / 2);

        private void CheckTriangleIsValid()
        {
            double triangleArea = GetSquare();

            if (triangleArea == 0)
                throw new ArgumentException("Invalid triangle");
        }

        private void SetSides()
        {
            Sides = new LineSegment[3]
            {
                new LineSegment(A, B),
                new LineSegment(B, C),
                new LineSegment(C, A),
            };
        }
    }
}