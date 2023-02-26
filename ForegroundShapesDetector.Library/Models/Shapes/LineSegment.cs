using ForegroundShapesDetector.Library.Models.Abstractions;

namespace ForegroundShapesDetector.Library.Models.Shapes
{
    public class LineSegment : ShapeBase, IShapeHasSides
    {
        private Point a;
        private Point b;
        private LineSegment[] sides;

        public LineSegment(Point a, Point b)
        {
            A = a;
            B = b;

            CheckLineIsValid();
            SetSides();
        }

        public Point A
        {
            get => a;
            private set
            {
                if (value is null)
                    throw new ArgumentNullException("Line's point can't be null");
                a = value;
            }
        }

        public Point B
        {
            get => b;
            private set
            {
                if (value is null)
                    throw new ArgumentNullException("Line's point can't be null");
                b = value;
            }
        }

        public LineSegment[] Sides
        {
            get
                => (LineSegment[])sides.Clone();
            private set
                => sides = value;
        }

        public sealed override double GetSquare() => 0;

        private void CheckLineIsValid()
        {
            if (a.X == b.X && a.Y == b.Y)
                throw new ArgumentException("Invalid line");
        }

        private void SetSides() => Sides = new LineSegment[1] { this };
    }
}